Public Class About

    Private Sub About_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RichTextBoxAbout.LoadFile(My.Application.Info.DirectoryPath & "\About.rtf")
    End Sub
End Class