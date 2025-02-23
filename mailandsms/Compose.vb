﻿Imports System.Net.Mail
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Compose
    Dim dbCon As New MySqlConnection("Server=" & My.Settings.mysqlServer & ";Database=" & My.Settings.mysqlDatabase & ";Uid=" & My.Settings.mysqlUsername & ";Pwd=" & My.Settings.mysqlPassword & ";encrypt=" & My.Settings.mysqlSSL)
    Dim strQuery As String
    Dim mysqlCmd As MySqlCommand
    Dim dr As MySqlDataReader
    Dim thread As System.Threading.Thread
    Private textSaved As Boolean = True

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click
        RichTextBox1.Text = ""
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim res As DialogResult
        Dim fname As String
        SaveFileDialog1.Filter = "RTF files|*rtf"
        SaveFileDialog1.InitialDirectory = "C:\"
        res = SaveFileDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            fname = SaveFileDialog1.FileName
            RichTextBox1.SaveFile(fname)
            textSaved = True
        End If
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        If textSaved = False Then
            If MessageBox.Show("You have unsaved changes. Continue closing window?", "Warning", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                RichTextBox1.Text = ""
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim res As DialogResult
        OpenFileDialog1.Filter = "RTF files|*rtf"
        OpenFileDialog1.InitialDirectory = "C:\"
        res = OpenFileDialog1.ShowDialog
        If res = Windows.Forms.DialogResult.OK Then
            RichTextBox1.LoadFile(OpenFileDialog1.FileName)
            textSaved = True
        End If
    End Sub

    Private Sub RichTextBox1_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyUp
        textSaved = False
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        RichTextBox1.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CutToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FindToolStripMenuItem.Click
        Dim strFind As String
        Dim pos As Integer
        strFind = InputBox("enter String to find")
        If strFind = "" Then
            Exit Sub
        End If
        pos = RichTextBox1.Find(strFind)
        If pos = -1 Then
            MsgBox("String not found...")
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FontToolStripMenuItem.Click
        Dim res As DialogResult
        FontDialog1.ShowColor = True
        res = FontDialog1.ShowDialog
        If res = Windows.Forms.DialogResult.OK Then
            RichTextBox1.SelectionFont = FontDialog1.Font
            RichTextBox1.SelectionColor = FontDialog1.Color
        End If
    End Sub

    Private Sub SelectionBackColorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SelectionBackColorToolStripMenuItem.Click
        Dim res As DialogResult
        res = ColorDialog1.ShowDialog
        If res = Windows.Forms.DialogResult.OK Then
            RichTextBox1.SelectionBackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub FontToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles FontToolStripMenuItem1.Click
        Dim res As DialogResult
        res = ColorDialog1.ShowDialog
        If res = Windows.Forms.DialogResult.OK Then
            RichTextBox1.SelectionColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub LeftToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LeftToolStripMenuItem.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub CenterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CenterToolStripMenuItem.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub RightToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RightToolStripMenuItem.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub IndentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IndentToolStripMenuItem.Click
        RichTextBox1.SelectionIndent = 200
        RichTextBox1.SelectionHangingIndent = 150
    End Sub

    Private Sub XToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles XToolStripMenuItem.Click
        RichTextBox1.ZoomFactor = 1
    End Sub

    Private Sub XToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles XToolStripMenuItem1.Click
        RichTextBox1.ZoomFactor = 2
    End Sub

    Private Sub XToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles XToolStripMenuItem2.Click
        RichTextBox1.ZoomFactor = 3
    End Sub

    Private Sub BulletsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BulletsToolStripMenuItem.Click
        RichTextBox1.SelectionBullet = True
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Compose_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DateTimePicker.MinDate = Now
        ListBoxHour.SelectedIndex = 0
        ListBoxMinute.SelectedIndex = 0
    End Sub

    Private Sub CheckBoxSendLater_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxSendLater.CheckedChanged
        If CheckBoxSendLater.Checked Then
            DateTimePicker.Enabled = True
            ListBoxHour.Enabled = True
            ListBoxMinute.Enabled = True
        Else
            DateTimePicker.Enabled = False
            ListBoxHour.Enabled = False
            ListBoxMinute.Enabled = False
            ListBoxHour.SetSelected(0, True)
            ListBoxMinute.SetSelected(0, True)
            DateTimePicker.Value = Now

        End If
    End Sub

    'Private Sub sendEmail(ByVal recipients() As String, ByVal subject As String, ByVal body As String)
    'Dim mail As New MailMessage
    '   mail.Subject = subject
    '  mail.Body = body
    ' mail.From = New MailAddress("konte.yiannis@gmail.com")
    'mail.BodyEncoding = System.Text.Encoding.UTF8
    'mail.IsBodyHtml = True
    '
    '   For Each recipient As String In recipients
    'Dim smtp As New SmtpClient("smtp.gmail.com")
    'smtp.EnableSsl = Application property
    '   Next
    'End Sub

    Private Sub SendToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SendToolStripMenuItem.Click

        If Main.TabControl1.SelectedTab.Text = "Emails" Then
            'GET HIGHEST ID of table MESSAGE

            Dim idcounter As Integer
            Try
                strQuery = "SELECT * FROM Message "
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()
                dr = mysqlCmd.ExecuteReader
                While dr.Read()
                    'vlepo to id tis telefteas seiras tou pinaka Subscriber
                    idcounter = dr.Item("ID")
                End While
                dr.Close()
                dbCon.Close()

                idcounter = idcounter + 1
            Catch ex As Exception
                MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
            End Try


            'Convert RichTextBox text to HTML
            Dim strHTML As String
            strHTML = ConvertToHTML(RichTextBox1)

            'INSERT INTO TABLE MESSAGE
            Dim subject As String = TextBox1.Text
            TextBox1.Text = ""
            RichTextBox1.Text = ""
            Try
                strQuery = "insert into message(id,subject,message) values(" & idcounter & ",'" & subject & "','" & strHTML & "')"
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()
                dr = mysqlCmd.ExecuteReader

                While dr.Read

                End While

                dr.Close()
                dbCon.Close()

            Catch ex As Exception
                MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
            End Try
            'CHECK IF TO SEND NOW OR LATER
            Dim timeString As String
            If CheckBoxSendLater.Checked Then
                timeString = DateTimePicker.Value.Year & "-" & DateTimePicker.Value.Month & "-" & DateTimePicker.Value.Day & " " & _
                   ListBoxHour.SelectedItem & ":" & ListBoxMinute.SelectedItem.ToString
            Else
                timeString = "CURRENT_TIMESTAMP"
            End If

            'INSERT TO TABLE LISTMESSAGE
            Try
                strQuery = "insert into listmessage(list_id,message_id,date) values(" & Main.ListBoxLists.SelectedValue & ",'" & idcounter & "','" & timeString & "')"
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()
                mysqlCmd.ExecuteNonQuery()
                dr.Close()
                dbCon.Close()

            Catch ex As Exception
                MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
            End Try

            CheckBoxSendLater.Checked = False

            MsgBox("Email has been sent")
            Me.Close()

        Else
            ' almost the same goes for sms but not here. More like in the ComposeSMS
        End If
    End Sub
    Public Function ConvertToHTML(ByVal Box As RichTextBox) As String
        ' Takes a RichTextBox control and returns a
        ' simple HTML-formatted version of its contents
        Dim strHTML As String
        Dim strColour As String
        Dim blnBold As Boolean
        Dim blnItalic As Boolean
        Dim strFont As String
        Dim shtSize As Short
        Dim lngOriginalStart As Long
        Dim lngOriginalLength As Long
        Dim intCount As Integer
        ' If nothing in the box, exit
        If Box.Text.Length = 0 Then
            strHTML = ""
            Return strHTML
            Exit Function
        End If
        ' Store original selections, then select first character
        lngOriginalStart = 0
        lngOriginalLength = Box.TextLength
        Box.Select(0, 1)
        ' Add HTML header
        Dim encode As String = "UTF-8"
        strHTML = "<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">"
        strHTML += "<html><head><title>Newsletter</title></head>"
        ' Set up initial parameters
        strHTML += "<body>"
        strColour = Box.SelectionColor.ToKnownColor.ToString
        blnBold = Box.SelectionFont.Bold
        blnItalic = Box.SelectionFont.Italic
        strFont = Box.SelectionFont.FontFamily.Name
        shtSize = Box.SelectionFont.Size
        ' Include first 'style' parameters in the HTML
        strHTML += "<span style=" & Chr(34) & "font-family: " & strFont & "; font-size: " & shtSize & "pt; color: " & strColour & Chr(34) & ">"
        ' Include bold tag, if required
        If blnBold = True Then
            strHTML += "<b>"
        End If
        ' Include italic tag, if required
        If blnItalic = True Then
            strHTML += "<i>"
        End If
        ' Finally, add our first character
        strHTML += Box.Text.Substring(0, 1)
        ' Loop around all remaining characters
        For intCount = 2 To Box.Text.Length
            ' Select current character
            Box.Select(intCount - 1, 1)
            ' If this is a line break, add HTML tag
            If Box.Text.Substring(intCount - 1, 1) = Convert.ToChar(10) Then
                strHTML += "<br>"
            End If
            ' Check/implement any changes in style
            If Box.SelectionColor.ToKnownColor.ToString <> strColour Or Box.SelectionFont.FontFamily.Name <> strFont Or Box.SelectionFont.Size <> shtSize Then
                strHTML += "</span><span style=" & Chr(34) & "font-family: " & Box.SelectionFont.FontFamily.Name & "; font-size: " & Box.SelectionFont.Size & "pt; color: " & Box.SelectionColor.ToKnownColor.ToString & Chr(34) & ">"
            End If
            ' Check for bold changes
            If Box.SelectionFont.Bold <> blnBold Then
                If Box.SelectionFont.Bold = False Then
                    strHTML += "</b>"
                Else
                    strHTML += "<b>"
                End If
            End If
            ' Check for italic changes
            If Box.SelectionFont.Italic <> blnItalic Then
                If Box.SelectionFont.Italic = False Then
                    strHTML += "</i>"
                Else
                    strHTML += "<i>"
                End If
            End If
            ' Add the actual character
            strHTML += Mid(Box.Text, intCount, 1)
            ' Update variables with current style
            strColour = Box.SelectionColor.ToKnownColor.ToString
            blnBold = Box.SelectionFont.Bold
            blnItalic = Box.SelectionFont.Italic
            strFont = Box.SelectionFont.FontFamily.Name
            shtSize = Box.SelectionFont.Size
        Next
        ' Close off any open bold/italic tags
        If blnBold = True Then strHTML += ""
        If blnItalic = True Then strHTML += ""
        ' Terminate outstanding HTML tags
        strHTML += "</span><p><p>"

        'This should be added after we add the unsubscribe link strHTML += "</body></html>"
        ' Restore original RichTextBox selection
        Box.Select(lngOriginalStart, lngOriginalLength)
        ' Return HTML
        Return strHTML
    End Function


End Class