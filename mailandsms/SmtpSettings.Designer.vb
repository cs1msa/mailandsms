<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmtpSettings
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxSmtpServer = New System.Windows.Forms.TextBox()
        Me.CheckBoxTLS = New System.Windows.Forms.CheckBox()
        Me.TextBoxSMTPPort = New System.Windows.Forms.TextBox()
        Me.TextBoxSMTPUsername = New System.Windows.Forms.TextBox()
        Me.TextBoxSMTPPassword = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxFrom = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SMTP server: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Enable SSL:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(217, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "SMTP port:"
        '
        'TextBoxSmtpServer
        '
        Me.TextBoxSmtpServer.Location = New System.Drawing.Point(83, 16)
        Me.TextBoxSmtpServer.Name = "TextBoxSmtpServer"
        Me.TextBoxSmtpServer.Size = New System.Drawing.Size(270, 20)
        Me.TextBoxSmtpServer.TabIndex = 5
        '
        'CheckBoxTLS
        '
        Me.CheckBoxTLS.AutoSize = True
        Me.CheckBoxTLS.Location = New System.Drawing.Point(83, 72)
        Me.CheckBoxTLS.Name = "CheckBoxTLS"
        Me.CheckBoxTLS.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxTLS.TabIndex = 6
        Me.CheckBoxTLS.UseVisualStyleBackColor = True
        '
        'TextBoxSMTPPort
        '
        Me.TextBoxSMTPPort.Location = New System.Drawing.Point(284, 70)
        Me.TextBoxSMTPPort.Name = "TextBoxSMTPPort"
        Me.TextBoxSMTPPort.Size = New System.Drawing.Size(69, 20)
        Me.TextBoxSMTPPort.TabIndex = 7
        '
        'TextBoxSMTPUsername
        '
        Me.TextBoxSMTPUsername.Location = New System.Drawing.Point(83, 101)
        Me.TextBoxSMTPUsername.Name = "TextBoxSMTPUsername"
        Me.TextBoxSMTPUsername.Size = New System.Drawing.Size(270, 20)
        Me.TextBoxSMTPUsername.TabIndex = 8
        '
        'TextBoxSMTPPassword
        '
        Me.TextBoxSMTPPassword.Location = New System.Drawing.Point(83, 133)
        Me.TextBoxSMTPPassword.Name = "TextBoxSMTPPassword"
        Me.TextBoxSMTPPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxSMTPPassword.Size = New System.Drawing.Size(270, 20)
        Me.TextBoxSMTPPassword.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(278, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(197, 161)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "From address: "
        '
        'TextBoxFrom
        '
        Me.TextBoxFrom.Location = New System.Drawing.Point(83, 42)
        Me.TextBoxFrom.Name = "TextBoxFrom"
        Me.TextBoxFrom.Size = New System.Drawing.Size(268, 20)
        Me.TextBoxFrom.TabIndex = 13
        '
        'SmtpSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 193)
        Me.Controls.Add(Me.TextBoxFrom)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBoxSMTPPassword)
        Me.Controls.Add(Me.TextBoxSMTPUsername)
        Me.Controls.Add(Me.TextBoxSMTPPort)
        Me.Controls.Add(Me.CheckBoxTLS)
        Me.Controls.Add(Me.TextBoxSmtpServer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SmtpSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SmtpSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSmtpServer As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxTLS As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxSMTPPort As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSMTPUsername As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSMTPPassword As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFrom As System.Windows.Forms.TextBox
End Class
