Public Class SmsSettings

    Private Sub SmsSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBoxUsername.Text = My.Settings.smsUsername
        TextBoxPassword.Text = My.Settings.smsPassword
    End Sub

    Private Sub ButtonCancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonSave_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSave.Click
        My.Settings.smsUsername = TextBoxUsername.Text
        My.Settings.smsPassword = TextBoxPassword.Text
        Me.Close()
    End Sub
End Class