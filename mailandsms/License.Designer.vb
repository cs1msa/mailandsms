<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class License
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
        Me.RichTextBoxLicense = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'RichTextBoxLicense
        '
        Me.RichTextBoxLicense.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBoxLicense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxLicense.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBoxLicense.Name = "RichTextBoxLicense"
        Me.RichTextBoxLicense.ReadOnly = True
        Me.RichTextBoxLicense.Size = New System.Drawing.Size(508, 380)
        Me.RichTextBoxLicense.TabIndex = 0
        Me.RichTextBoxLicense.Text = ""
        '
        'License
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 380)
        Me.Controls.Add(Me.RichTextBoxLicense)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "License"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "License"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBoxLicense As System.Windows.Forms.RichTextBox
End Class
