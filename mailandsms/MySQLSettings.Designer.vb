<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MySQLSettings
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBoxMySQLPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxMySQLUsername = New System.Windows.Forms.TextBox()
        Me.TextBoxMySQLPort = New System.Windows.Forms.TextBox()
        Me.CheckBoxSSL = New System.Windows.Forms.CheckBox()
        Me.TextBoxMySQLServer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxMysqlDatabase = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(195, 134)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(276, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBoxMySQLPassword
        '
        Me.TextBoxMySQLPassword.Location = New System.Drawing.Point(64, 105)
        Me.TextBoxMySQLPassword.Name = "TextBoxMySQLPassword"
        Me.TextBoxMySQLPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxMySQLPassword.Size = New System.Drawing.Size(287, 20)
        Me.TextBoxMySQLPassword.TabIndex = 21
        '
        'TextBoxMySQLUsername
        '
        Me.TextBoxMySQLUsername.Location = New System.Drawing.Point(64, 73)
        Me.TextBoxMySQLUsername.Name = "TextBoxMySQLUsername"
        Me.TextBoxMySQLUsername.Size = New System.Drawing.Size(287, 20)
        Me.TextBoxMySQLUsername.TabIndex = 20
        '
        'TextBoxMySQLPort
        '
        Me.TextBoxMySQLPort.Location = New System.Drawing.Point(101, 42)
        Me.TextBoxMySQLPort.Name = "TextBoxMySQLPort"
        Me.TextBoxMySQLPort.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxMySQLPort.TabIndex = 19
        '
        'CheckBoxSSL
        '
        Me.CheckBoxSSL.AutoSize = True
        Me.CheckBoxSSL.Location = New System.Drawing.Point(45, 44)
        Me.CheckBoxSSL.Name = "CheckBoxSSL"
        Me.CheckBoxSSL.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxSSL.TabIndex = 18
        Me.CheckBoxSSL.UseVisualStyleBackColor = True
        '
        'TextBoxMySQLServer
        '
        Me.TextBoxMySQLServer.Location = New System.Drawing.Point(45, 12)
        Me.TextBoxMySQLServer.Name = "TextBoxMySQLServer"
        Me.TextBoxMySQLServer.Size = New System.Drawing.Size(306, 20)
        Me.TextBoxMySQLServer.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(66, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Port:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = " SSL:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Password:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Username:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Server: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(152, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Database:"
        '
        'TextBoxMysqlDatabase
        '
        Me.TextBoxMysqlDatabase.Location = New System.Drawing.Point(214, 45)
        Me.TextBoxMysqlDatabase.Name = "TextBoxMysqlDatabase"
        Me.TextBoxMysqlDatabase.Size = New System.Drawing.Size(137, 20)
        Me.TextBoxMysqlDatabase.TabIndex = 25
        '
        'MySQLSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 163)
        Me.Controls.Add(Me.TextBoxMysqlDatabase)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBoxMySQLPassword)
        Me.Controls.Add(Me.TextBoxMySQLUsername)
        Me.Controls.Add(Me.TextBoxMySQLPort)
        Me.Controls.Add(Me.CheckBoxSSL)
        Me.Controls.Add(Me.TextBoxMySQLServer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MySQLSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MySQLSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBoxMySQLPassword As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxMySQLUsername As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxMySQLPort As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxSSL As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxMySQLServer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMysqlDatabase As System.Windows.Forms.TextBox
End Class
