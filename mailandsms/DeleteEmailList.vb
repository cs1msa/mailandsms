Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Public Class DeleteEmailList
    Dim dbCon As New MySqlConnection("Server=" & My.Settings.mysqlServer & ";Database=" & My.Settings.mysqlDatabase & ";Uid=" & My.Settings.mysqlUsername & ";Pwd=" & My.Settings.mysqlPassword & ";encrypt=" & My.Settings.mysqlSSL)
    Dim strQuery As String
    Dim mysqlCmd As MySqlCommand
    Dim dr As MySqlDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If Main.ListBoxLists.SelectedIndex <> -1 Then
            If Main.ListBoxLists.SelectedValue.GetType.FullName = "System.String" Then
                strQuery = "delete from List where id=" & Main.ListBoxLists.SelectedValue.ToString
            
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()
                dr = mysqlCmd.ExecuteReader

                Dim listElements As New ArrayList
                While dr.Read
                    '      listElements.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")", dr.Item("id")))
                End While
                dr.Close()
                dbCon.Close()
                '  Main.ListBoxSubscribers.DataSource = listElements
                '   Main.ListBoxSubscribers.DisplayMember = "LongName"
                'Main.ListBoxSubscribers.ValueMember = "ShortName"
                'MsgBox(ListBoxLists.SelectedValue.ToString)
            End If



        End If
        Dim rows As Integer
        Try
            strQuery = "SELECT COUNT(*) FROM List where type='email'"
            mysqlCmd = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()

            'Metrao tis seires tou pinaka List
            mysqlCmd.CommandText = strQuery
            rows = mysqlCmd.ExecuteScalar()
            'Emfanizo tis seires tou pinaka List
            Main.Label7.Text = rows

            dbCon.Close()

        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try

        Try
            strQuery = "select id, name from list where type='email' order by name asc"
            mysqlCmd = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()

            dr = mysqlCmd.ExecuteReader
            Dim listElements As New ArrayList
            While dr.Read
                listElements.Add(New ListElement(dr.Item("name"), dr.Item("id")))
            End While

            dr.Close()
            dbCon.Close()

            Main.ListBoxLists.DataSource = listElements
            Main.ListBoxLists.DisplayMember = "LongName"
            Main.ListBoxLists.ValueMember = "ShortName"

        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try

        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class