Imports SharpDX.XInput 'for using xinput controller
Imports System.Threading 'running controller checks on seperate thread
Imports System.ComponentModel

Public Class controller

    Dim Controller As SharpDX.XInput.Controller = New SharpDX.XInput.Controller(UserIndex.One) 'connect to first controller
    Dim button As Integer
    Dim gamepadButtons As Array = System.Enum.GetValues(GetType(GamepadButtonFlags)) 'buttons on gamepad
    Dim gamepadValues() As String

    Dim arduino As Solid.Arduino.SerialConnection 'serial connection to arduino
    Dim arduinoSession As Solid.Arduino.ArduinoSession 'create new firmata session
    Dim firmata As Solid.Arduino.Firmata.IFirmataProtocol

    'pins for motor
    Dim enable_a As Integer = 2
    Dim enable_b As Integer = 4 '3 originally
    Dim in_a As Integer = 3 '4 orignally
    Dim in_b As Integer = 5
    Dim motorPin As Integer = 11

    'pins for servo
    Dim servoPin As Integer = 9

    'pins for distance sensor
    Dim echoPin As Integer = 6
    Dim trigPin As Integer = 7

    'various constants
    Dim speedMax As Integer = 255
    Dim speedMin As Integer = 0
    Dim steeringMax As Integer = 130
    Dim steeringMin As Integer = 40
    Dim steeringCenter As Integer = 80

    'when close com port, disable checking for controller inputs
    Dim processingInput As Boolean = False

    Function firmataVersion(ByVal msg As Boolean) As String()
        'gets the firmata version. good check to see if we are connected
        Dim firmataFw As Solid.Arduino.Firmata.Firmware = firmata.GetFirmware()
        'if you want a message box with the version or just return values instead
        If msg = False Then 'false gives values, true give messagebox
            Return {firmataFw.Name.ToString, firmataFw.MajorVersion.ToString, firmataFw.MinorVersion.ToString}
        ElseIf msg = True Then
            MsgBox("Firmata Version: " + firmataFw.Name.ToString + " " + firmataFw.MajorVersion.ToString + "." + firmataFw.MinorVersion.ToString)
            Return {}
        Else
            Return {}
        End If
    End Function

    Sub pinMode(ByVal pin As Integer, ByVal mode As String)
        'basically arduino-like pinMode equivalent
        If mode = "output" Then
            arduinoSession.SetDigitalPinMode(pin, Solid.Arduino.Firmata.PinMode.DigitalOutput)
        ElseIf mode = "input" Then
            arduinoSession.SetDigitalPinMode(pin, Solid.Arduino.Firmata.PinMode.DigitalInput)
        ElseIf mode = "pwm" Then
            arduinoSession.SetDigitalPinMode(pin, Solid.Arduino.Firmata.PinMode.PwmOutput)
        End If
    End Sub

    Sub digitalWrite(ByVal pin As Integer, ByVal value As Boolean)
        'write digital value to port
        arduinoSession.SetDigitalPin(pin, value)
    End Sub

    Function digitalAnalogRead(ByVal pin As Integer) As Long
        'read a pin's value
        'true or false for bool values, otherwise actual value
        Return arduinoSession.GetPinState(pin).Value
    End Function

    Sub analogWrite(ByVal pin As Integer, ByVal value As Long)
        'write pwm values
        arduinoSession.SetDigitalPin(pin, value)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'disable buttons till connection
        disableButtons()
        'run controller key press detection code
        backGroundWorker.RunWorkerAsync()
    End Sub

    'background task uses to report progess
    Private Sub backGroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles backGroundWorker.ProgressChanged
        'call my processing function
        processController(CType(e.UserState, List(Of String)))
    End Sub

    'not needed since the worker never finishes
    Private Sub backGroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles backGroundWorker.RunWorkerCompleted
    End Sub

    Sub enableButtons()
        'enable buttons
        enableMotorButton.Enabled = True
        disableMotorButton.Enabled = False
        enableServoButton.Enabled = True
        disableServoButton.Enabled = False
        forwardDirectionButton.Enabled = True
        neutralDirectionButton.Enabled = True
        reverseDirectionButton.Enabled = True
    End Sub

    Sub disableButtons()
        'disable buttons
        enableMotorButton.Enabled = False
        disableMotorButton.Enabled = False
        enableServoButton.Enabled = False
        disableServoButton.Enabled = False
        forwardDirectionButton.Enabled = False
        neutralDirectionButton.Enabled = False
        reverseDirectionButton.Enabled = False
    End Sub

    Sub enableMotor()
        digitalWrite(enable_a, True)
        digitalWrite(enable_b, True)
        pinMode(motorPin, "pwm")
        enableButtons("en")
    End Sub

    Sub disableMotor()
        digitalWrite(enable_a, False)
        digitalWrite(enable_b, False)
        pinMode(motorPin, "input")
        enableButtons("dis")
    End Sub

    Sub setDirection(ByVal dir As String)
        If dir = "forward" Then
            digitalWrite(in_a, True)
            digitalWrite(in_b, False)
            directionButtons("f")
        ElseIf dir = "reverse" Then
            digitalWrite(in_a, False)
            digitalWrite(in_b, True)
            directionButtons("r")
        ElseIf dir = "neutral" Then
            digitalWrite(in_a, False)
            digitalWrite(in_b, False)
            directionButtons("n")

        End If
    End Sub

    Sub processController(ByVal items As List(Of String))
        '[Button 0, Value 1, LT 2, Value 3, RT 4, Value 5,  LX 6, Value 7, LY 8, Value 9, RX 10, Value 11, RY 12, Value 13]

        'extract values from array for further use
        Dim button As String = items(1).TrimStart(CType(" ", Char()))
        Dim lTrig As Integer = CInt(items(3))
        Dim rTrig As Integer = CInt(items(5))
        Dim lX As Integer = CInt(items(7))
        Dim lY As Integer = CInt(items(9))
        Dim rX As Integer = CInt(items(11))
        Dim rY As Integer = CInt(items(13))
        Dim steering As Integer = steeringCenter

        'steering has a center, the analog sticks center are not zero so to copensate
        If lX > -32767 And lX <= -127 Then
            steering = valueMap(-32767, -127, steeringMin, steeringCenter, lX)
        ElseIf lX > -127 And lX <= 130 Then
            steering = steeringCenter
        Else
            steering = valueMap(130, 32767, steeringCenter, steeringMax, lX)
        End If

        'map values of trigger to min and max
        Dim speed As Integer = valueMap(0, 255, speedMin, speedMax, rTrig)

        If button = "Start" Then
            'if press start the do the followjng

            Dim comport As String = comPortTextBox.Text
            enableButtons()
            arduino = New Solid.Arduino.SerialConnection(comport, Solid.Arduino.SerialBaudRate.Bps_57600)
            arduinoSession = New Solid.Arduino.ArduinoSession(arduino, 250)
            firmata = CType(arduinoSession, Solid.Arduino.Firmata.IFirmataProtocol)

            'check if we are connected
            Label3.Text = firmataVersion(False)(0)
            enableButtons("start")

            'for some reason the motor gets enabled at startup so just to make sure its in neutral pos
            digitalWrite(in_a, False)
            digitalWrite(in_b, False)
            processingInput = True

        ElseIf button = "Back" Then

            'for disconnection from arduino
            arduinoSession.ResetBoard()
            arduino.Close()
            enableButtons("back")
            processingInput = False
            disableButtons()

        End If

        'check if we need to process gamepad inputs
        If processingInput = True Then
            If button = "Y" Then
                'forward direction
                setDirection("forward")
            ElseIf button = "A" Then
                'reverse direction
                setDirection("reverse")
            ElseIf button = "B" Then
                'neutral
                setDirection("neutral")
            ElseIf button = "X" Then
                'lower max speed
                speedMax = 64
                Label1.Text = speedMax.ToString
            ElseIf button = "LeftShoulder" Then
                'set speed to max
                speedMax = 255
                Label1.Text = speedMax.ToString
            ElseIf button = "RightShoulder" Then
                'set speed to half of max
                speedMax = 128
                Label1.Text = speedMax.ToString
            ElseIf button = "DPadLeft" Then
                'enable motor
                enableMotor()
            ElseIf button = "DPadRight" Then
                'disable motor
                disableMotor()
            ElseIf button = "DPadUp" Then
                'enable servo
                arduinoSession.ConfigureServo(servoPin, 540, 2400)
                enableButtons("sen")
            ElseIf button = "DPadDown" Then
                'disable servo
                pinMode(servoPin, "input")
                enableButtons("sdis")
            End If

            'write pwm values to respective component
            analogWrite(servoPin, steering)
            analogWrite(motorPin, speed)

            'update progress bars
            steeringBar.Value = Math.Abs(valueMap(40, 130, 0, 100, steering))
            speedBar.Value = CInt((speed / speedMax) * 100)
        End If

    End Sub

    Sub directionButtons(ByVal dir As String)
        'if forward is chosen, disable its button and enable rest
        If dir = "f" Then
            forwardDirectionButton.Enabled = False
            neutralDirectionButton.Enabled = True
            reverseDirectionButton.Enabled = True
        ElseIf dir = "r" Then
            forwardDirectionButton.Enabled = True
            neutralDirectionButton.Enabled = True
            reverseDirectionButton.Enabled = False
        ElseIf dir = "n" Then
            forwardDirectionButton.Enabled = True
            neutralDirectionButton.Enabled = False
            reverseDirectionButton.Enabled = True

        End If
    End Sub

    Sub enableButtons(ByVal dir As String)
        'depending on what to enable, this enables and disable respective buttons
        If dir = "en" Then
            enableMotorButton.Enabled = False
            disableMotorButton.Enabled = True
        ElseIf dir = "dis" Then
            enableMotorButton.Enabled = True
            disableMotorButton.Enabled = False
        ElseIf dir = "sen" Then
            enableServoButton.Enabled = False
            disableServoButton.Enabled = True
        ElseIf dir = "sdis" Then
            enableServoButton.Enabled = True
            disableServoButton.Enabled = False
        ElseIf dir = "start" Then
            comPortButton.Enabled = False
            disconnectButton.Enabled = True
        ElseIf dir = "back" Then
            comPortButton.Enabled = True
            disconnectButton.Enabled = False
        End If

    End Sub

    Function valueMap(ByVal in_min As Integer, ByVal in_max As Integer, ByVal out_min As Integer, ByVal out_max As Integer, ByVal value As Integer) As Integer
        'maps a range from one to another
        Dim y As Integer
        y = CInt(((value - in_min) / (in_max - in_min)) * (out_max - out_min) + out_min)
        Return y
    End Function

    Private Sub backGroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backGroundWorker.DoWork
        'check controller for keys
        Dim prevState As SharpDX.XInput.State = Controller.GetState()
        Dim currState As SharpDX.XInput.State
        Dim valueArray() As String
        Dim processedArray As New List(Of String)

        'while controller is connected
        While Controller.IsConnected
            currState = Controller.GetState()
            'check if state is different
            If prevState.PacketNumber <> currState.PacketNumber Then
                valueArray = currState.Gamepad.ToString.Split(CType(",", Char()))

                For Each item As String In valueArray
                    'add key and values
                    For Each subitem As String In item.Split(CType(":", Char()))
                        processedArray.Add(subitem)
                    Next
                Next

                'calls this function with array of valyes
                backGroundWorker.ReportProgress(0, processedArray)

                'vb,net will keep increasing the array each time, so zero it to start again
                processedArray = New List(Of String)

            End If
            'thread to sleep
            Thread.Sleep(10)
            prevState = currState
        End While

    End Sub

    Private Sub ComPortButton_Click(sender As Object, e As EventArgs) Handles comPortButton.Click

    End Sub
End Class
