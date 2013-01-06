Public Class Credits

    Private Sub Credits_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.LoadFile(My.Application.Info.DirectoryPath & "\credits.rtf")
    End Sub
End Class