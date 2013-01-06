Public Class SmtpSettings

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub SmtpSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBoxSmtpServer.Text = My.Settings.smtpServer
        CheckBoxTLS.Checked = My.Settings.SMTLSSL
        TextBoxSMTPPort.Text = My.Settings.SMTPPort
        TextBoxFrom.Text = My.Settings.fromAddress
        TextBoxSMTPUsername.Text = My.Settings.SMTPUsername
        TextBoxSMTPPassword.Text = My.Settings.SMTPPassword
        Button2.Enabled = False
    End Sub


    Private Sub CheckBoxTLS_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxTLS.CheckedChanged
        Button2.Enabled = True
    End Sub

    Private Sub TextBoxSMTPPort_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxSMTPPort.TextChanged
        Button2.Enabled = True
    End Sub

    Private Sub TextBoxSMTPUsername_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxSMTPUsername.TextChanged
        Button2.Enabled = True
    End Sub

    Private Sub TextBoxSMTPPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxSMTPPassword.TextChanged
        Button2.Enabled = True
    End Sub

    Private Sub TextBoxSmtpServer_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxSmtpServer.TextChanged
        Button2.Enabled = True
    End Sub

    Private Sub TextBoxFrom_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxFrom.TextChanged
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        My.Settings.smtpServer = TextBoxSmtpServer.Text
        My.Settings.SMTLSSL = CheckBoxTLS.Checked
        My.Settings.SMTPPort = TextBoxSMTPPort.Text
        My.Settings.SMTPUsername = TextBoxSMTPUsername.Text
        My.Settings.SMTPPassword = TextBoxSMTPPassword.Text
        Button2.Enabled = False
        Me.Close()
    End Sub
End Class