<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Me.RichTextBoxAbout = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'RichTextBoxAbout
        '
        Me.RichTextBoxAbout.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBoxAbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxAbout.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBoxAbout.Name = "RichTextBoxAbout"
        Me.RichTextBoxAbout.ReadOnly = True
        Me.RichTextBoxAbout.Size = New System.Drawing.Size(514, 204)
        Me.RichTextBoxAbout.TabIndex = 0
        Me.RichTextBoxAbout.Text = ""
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 204)
        Me.Controls.Add(Me.RichTextBoxAbout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBoxAbout As System.Windows.Forms.RichTextBox
End Class
