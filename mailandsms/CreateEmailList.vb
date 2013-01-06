Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Public Class CreateEmailList
    Dim dbCon As New MySqlConnection("Server=" & My.Settings.mysqlServer & ";Database=" & My.Settings.mysqlDatabase & ";Uid=" & My.Settings.mysqlUsername & ";Pwd=" & My.Settings.mysqlPassword & ";encrypt=" & My.Settings.mysqlSSL)
    Dim strQuery As String
    Dim mysqlCmd As MySqlCommand
    Dim dr As MySqlDataReader
    Dim thread As System.Threading.Thread
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim idcounter As Integer
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
            strQuery = "SELECT * FROM List "
            mysqlCmd = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()
            dr = mysqlCmd.ExecuteReader
            While dr.Read()
                'vlepo to id tis telefteas seiras tou pinaka List
                idcounter = dr.Item("ID")
            End While
            dr.Close()
            dbCon.Close()

        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try

        Dim str As String

        str = TextBox1.Text
        idcounter = idcounter + 1
        rows = Main.Label7.Text + 1

        Try
            strQuery = "insert into list(id,name,type) values(" & idcounter & ",'" & str & "','email')"
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
        Main.Label7.Text = rows

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
End Class