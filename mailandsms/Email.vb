Imports System.Net.Mail

Public Class Email

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProgressBar1.Value = 5
        Dim message As System.Net.Mail.MailMessage
        ProgressBar1.Value = 10
        Dim smtp As New System.Net.Mail.SmtpClient(TextBox4.Text, 587)
        ProgressBar1.Value = 25
        message = New System.Net.Mail.MailMessage(TextBox2.Text, TextBox5.Text, TextBox5.Text, TextBox1.Text)
        ProgressBar1.Value = 40
        smtp.EnableSsl = True
        ProgressBar1.Value = 60
        smtp.Credentials = New System.Net.NetworkCredential(TextBox2.Text, TextBox3.Text)
        ProgressBar1.Value = 70
        ProgressBar1.Value = 80
        Try
            smtp.Send(message)
            ProgressBar1.Value = 100
            MessageBox.Show("Message has been send", " Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProgressBar1.Value = 0
        Catch ex As Net.Mail.SmtpException
            MessageBox.Show("An Error Occured Please try again", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Try Entering your password again or maybe your not connected to the internet", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
End Class