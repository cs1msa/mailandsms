Public Class Help

    Private Sub Help_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.LoadFile(My.Application.Info.DirectoryPath & "\Manual.rtf")
    End Sub
End Class