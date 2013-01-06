Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Public Class ComposeSMS
    Dim dbCon As New MySqlConnection("Server=" & My.Settings.mysqlServer & ";Database=" & My.Settings.mysqlDatabase & ";Uid=" & My.Settings.mysqlUsername & ";Pwd=" & My.Settings.mysqlPassword & ";encrypt=" & My.Settings.mysqlSSL)
    Dim strQuery As String
    Dim mysqlCmd As MySqlCommand
    Dim dr As MySqlDataReader
    Dim thread As System.Threading.Thread
    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click

    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click

    End Sub


    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click

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
        'MsgBox(idcounter)
        'INSERT INTO TABLE MESSAGE
       Try
            strQuery = "insert into message(id,subject,message) values(" & idcounter & ",'null','" & TextBox1.Text & "')"
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
            timeString = Me.DateTimePicker.Value.Year & "-" & Me.DateTimePicker.Value.Month & "-" & Me.DateTimePicker.Value.Day & " " & _
               Me.ListBoxHour.SelectedItem & ":" & Me.ListBoxMinute.SelectedItem
        Else
            timeString = "CURRENT_TIMESTAMP"
        End If
        Try
            strQuery = "insert into listmessage(list_id,message_id,date) values(" & Main.ListBox2.SelectedValue & ",'" & idcounter & "','" & timeString & "')"
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

        CheckBoxSendLater.Checked = False


        MsgBox("SMS has been sent")
        Me.Close()

    End Sub

    Private Sub CheckBoxSendLater_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSendLater.CheckedChanged
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


    Private Sub ComposeSMS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class