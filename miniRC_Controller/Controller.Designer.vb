<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class controller
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.enableMotorButton = New System.Windows.Forms.Button()
        Me.motorLabel = New System.Windows.Forms.Label()
        Me.disableMotorButton = New System.Windows.Forms.Button()
        Me.disableServoButton = New System.Windows.Forms.Button()
        Me.servoLabel = New System.Windows.Forms.Label()
        Me.enableServoButton = New System.Windows.Forms.Button()
        Me.reverseDirectionButton = New System.Windows.Forms.Button()
        Me.neutralDirectionButton = New System.Windows.Forms.Button()
        Me.forwardDirectionButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.backGroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.comPortButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comPortTextBox = New System.Windows.Forms.TextBox()
        Me.disconnectButton = New System.Windows.Forms.Button()
        Me.steeringBar = New System.Windows.Forms.ProgressBar()
        Me.speedBar = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'enableMotorButton
        '
        Me.enableMotorButton.Location = New System.Drawing.Point(12, 34)
        Me.enableMotorButton.Name = "enableMotorButton"
        Me.enableMotorButton.Size = New System.Drawing.Size(83, 36)
        Me.enableMotorButton.TabIndex = 1
        Me.enableMotorButton.Text = "Enable Motor"
        Me.enableMotorButton.UseVisualStyleBackColor = True
        '
        'motorLabel
        '
        Me.motorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.motorLabel.Location = New System.Drawing.Point(12, 12)
        Me.motorLabel.Name = "motorLabel"
        Me.motorLabel.Size = New System.Drawing.Size(172, 19)
        Me.motorLabel.TabIndex = 2
        Me.motorLabel.Text = "Enable or Disable Motor"
        Me.motorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'disableMotorButton
        '
        Me.disableMotorButton.Location = New System.Drawing.Point(101, 34)
        Me.disableMotorButton.Name = "disableMotorButton"
        Me.disableMotorButton.Size = New System.Drawing.Size(83, 36)
        Me.disableMotorButton.TabIndex = 3
        Me.disableMotorButton.Text = "Disable Motor"
        Me.disableMotorButton.UseVisualStyleBackColor = True
        '
        'disableServoButton
        '
        Me.disableServoButton.Location = New System.Drawing.Point(101, 97)
        Me.disableServoButton.Name = "disableServoButton"
        Me.disableServoButton.Size = New System.Drawing.Size(83, 36)
        Me.disableServoButton.TabIndex = 6
        Me.disableServoButton.Text = "Disable Servo"
        Me.disableServoButton.UseVisualStyleBackColor = True
        '
        'servoLabel
        '
        Me.servoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.servoLabel.Location = New System.Drawing.Point(12, 75)
        Me.servoLabel.Name = "servoLabel"
        Me.servoLabel.Size = New System.Drawing.Size(172, 19)
        Me.servoLabel.TabIndex = 5
        Me.servoLabel.Text = "Enable or Disable Servo"
        Me.servoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'enableServoButton
        '
        Me.enableServoButton.Location = New System.Drawing.Point(12, 97)
        Me.enableServoButton.Name = "enableServoButton"
        Me.enableServoButton.Size = New System.Drawing.Size(83, 36)
        Me.enableServoButton.TabIndex = 4
        Me.enableServoButton.Text = "Enable Servo"
        Me.enableServoButton.UseVisualStyleBackColor = True
        '
        'reverseDirectionButton
        '
        Me.reverseDirectionButton.Location = New System.Drawing.Point(124, 158)
        Me.reverseDirectionButton.Name = "reverseDirectionButton"
        Me.reverseDirectionButton.Size = New System.Drawing.Size(60, 36)
        Me.reverseDirectionButton.TabIndex = 23
        Me.reverseDirectionButton.Text = "Reverse"
        Me.reverseDirectionButton.UseVisualStyleBackColor = True
        '
        'neutralDirectionButton
        '
        Me.neutralDirectionButton.Location = New System.Drawing.Point(71, 158)
        Me.neutralDirectionButton.Name = "neutralDirectionButton"
        Me.neutralDirectionButton.Size = New System.Drawing.Size(50, 36)
        Me.neutralDirectionButton.TabIndex = 22
        Me.neutralDirectionButton.Text = "Neutral"
        Me.neutralDirectionButton.UseVisualStyleBackColor = True
        '
        'forwardDirectionButton
        '
        Me.forwardDirectionButton.Location = New System.Drawing.Point(12, 158)
        Me.forwardDirectionButton.Name = "forwardDirectionButton"
        Me.forwardDirectionButton.Size = New System.Drawing.Size(56, 36)
        Me.forwardDirectionButton.TabIndex = 21
        Me.forwardDirectionButton.Text = "Forward"
        Me.forwardDirectionButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(12, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 19)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Direction"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'backGroundWorker
        '
        Me.backGroundWorker.WorkerReportsProgress = True
        Me.backGroundWorker.WorkerSupportsCancellation = True
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(191, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 19)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Steering"
        '
        'comPortButton
        '
        Me.comPortButton.Location = New System.Drawing.Point(190, 34)
        Me.comPortButton.Name = "comPortButton"
        Me.comPortButton.Size = New System.Drawing.Size(56, 21)
        Me.comPortButton.TabIndex = 25
        Me.comPortButton.Text = "Connect"
        Me.comPortButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(191, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 19)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Throttle"
        '
        'comPortTextBox
        '
        Me.comPortTextBox.Location = New System.Drawing.Point(191, 12)
        Me.comPortTextBox.Name = "comPortTextBox"
        Me.comPortTextBox.Size = New System.Drawing.Size(133, 20)
        Me.comPortTextBox.TabIndex = 32
        Me.comPortTextBox.Text = "COM19"
        '
        'disconnectButton
        '
        Me.disconnectButton.Location = New System.Drawing.Point(252, 34)
        Me.disconnectButton.Name = "disconnectButton"
        Me.disconnectButton.Size = New System.Drawing.Size(72, 21)
        Me.disconnectButton.TabIndex = 33
        Me.disconnectButton.Text = "Disconnect"
        Me.disconnectButton.UseVisualStyleBackColor = True
        '
        'steeringBar
        '
        Me.steeringBar.Location = New System.Drawing.Point(191, 125)
        Me.steeringBar.MarqueeAnimationSpeed = 5
        Me.steeringBar.Name = "steeringBar"
        Me.steeringBar.Size = New System.Drawing.Size(133, 22)
        Me.steeringBar.TabIndex = 34
        '
        'speedBar
        '
        Me.speedBar.Location = New System.Drawing.Point(190, 172)
        Me.speedBar.Name = "speedBar"
        Me.speedBar.Size = New System.Drawing.Size(133, 22)
        Me.speedBar.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(190, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 19)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Firmata Status"
        '
        'controller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 203)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.speedBar)
        Me.Controls.Add(Me.steeringBar)
        Me.Controls.Add(Me.disconnectButton)
        Me.Controls.Add(Me.comPortTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.comPortButton)
        Me.Controls.Add(Me.reverseDirectionButton)
        Me.Controls.Add(Me.neutralDirectionButton)
        Me.Controls.Add(Me.forwardDirectionButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.disableServoButton)
        Me.Controls.Add(Me.servoLabel)
        Me.Controls.Add(Me.enableServoButton)
        Me.Controls.Add(Me.disableMotorButton)
        Me.Controls.Add(Me.motorLabel)
        Me.Controls.Add(Me.enableMotorButton)
        Me.Name = "controller"
        Me.Text = "miniRC Controller"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents enableMotorButton As Button
    Friend WithEvents motorLabel As Label
    Friend WithEvents disableMotorButton As Button
    Friend WithEvents disableServoButton As Button
    Friend WithEvents servoLabel As Label
    Friend WithEvents enableServoButton As Button
    Friend WithEvents reverseDirectionButton As Button
    Friend WithEvents neutralDirectionButton As Button
    Friend WithEvents forwardDirectionButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents backGroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label5 As Label
    Friend WithEvents comPortButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents comPortTextBox As TextBox
    Friend WithEvents disconnectButton As Button
    Friend WithEvents steeringBar As ProgressBar
    Friend WithEvents speedBar As ProgressBar
    Friend WithEvents Label3 As Label
End Class
