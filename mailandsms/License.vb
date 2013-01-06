Public Class License

    Private Sub License_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RichTextBoxLicense.LoadFile(My.Application.Info.DirectoryPath & "\License.rtf")
    End Sub
End Class