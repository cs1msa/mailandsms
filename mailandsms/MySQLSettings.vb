Public Class MySQLSettings

    Dim changed As Boolean = False

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub MySQLSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBoxMySQLServer.Text = My.Settings.mysqlServer
        CheckBoxSSL.Checked = My.Settings.mysqlSSL
        TextBoxMySQLPort.Text = My.Settings.mysqlPort
        TextBoxMySQLUsername.Text = My.Settings.mysqlUsername
        TextBoxMySQLPassword.Text = My.Settings.mysqlPassword
        TextBoxMysqlDatabase.Text = My.Settings.mysqlDatabase
        Button2.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        My.Settings.mysqlServer = TextBoxMySQLServer.Text
        My.Settings.mysqlSSL = CheckBoxSSL.Checked
        My.Settings.mysqlPort = TextBoxMySQLPort.Text
        My.Settings.mysqlUsername = TextBoxMySQLUsername.Text
        My.Settings.mysqlPassword = TextBoxMySQLPassword.Text
        My.Settings.mysqlDatabase = TextBoxMysqlDatabase.Text
        Button2.Enabled = False
        Me.Close()
    End Sub

    Private Sub TextBoxMySQLServer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxMySQLServer.KeyPress
        Button2.Enabled = True
    End Sub

    Private Sub CheckBoxSSL_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBoxSSL.KeyPress
        Button2.Enabled = True
    End Sub

    Private Sub TextBoxMySQLPort_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxMySQLPort.KeyPress
        Button2.Enabled = True
    End Sub

    Private Sub TextBoxMySQLUsername_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxMySQLUsername.TextChanged
        Button2.Enabled = True
    End Sub

    Private Sub TextBoxMySQLPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxMySQLPassword.TextChanged
        Button2.Enabled = True
    End Sub

End Class