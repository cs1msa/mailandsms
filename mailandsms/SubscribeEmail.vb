﻿Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Public Class SubscribeEmail
    Dim dbCon As New MySqlConnection("Server=" & My.Settings.mysqlServer & ";Database=" & My.Settings.mysqlDatabase & ";Uid=" & My.Settings.mysqlUsername & ";Pwd=" & My.Settings.mysqlPassword & ";encrypt=" & My.Settings.mysqlSSL)
    Dim strQuery As String
    Dim mysqlCmd As MySqlCommand
    Dim dr As MySqlDataReader
    Dim thread As System.Threading.Thread
    


    Overridable Sub onload() Handles Me.Load
        'LIST BOX ME TOUS SUBSCRIBERS OLOUS
        strQuery = "SELECT * FROM subscriber order by name"

        mysqlCmd = New MySqlCommand(strQuery, dbCon)

        dbCon.Open()
        dr = mysqlCmd.ExecuteReader

        Dim listElements As New ArrayList
        While dr.Read
            listElements.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")" & " (" & dr.Item("sms") & ")", dr.Item("id")))
        End While
        dr.Close()
        dbCon.Close()
        ListBox1.DataSource = listElements
        ListBox1.DisplayMember = "LongName"
        ListBox1.ValueMember = "ShortName"
        'MsgBox(ListBoxLists.SelectedValue.ToString)

        'LIST BOX ME TOUS SUBSCRIBERS TIS CURRENT LISTAS
        strQuery = "select subscriber.id, subscriber.name, subscriber.email from subscriber, subscribed_to_list " & _
                            "where subscribed_to_list.subscriber_id=subscriber.id and subscribed_to_list.list_id" & _
                            "=" & Main.ListBoxLists.SelectedValue.ToString & " order by subscriber.name asc"
        mysqlCmd = New MySqlCommand(strQuery, dbCon)

        dbCon.Open()
        dr = mysqlCmd.ExecuteReader

        Dim listElements2 As New ArrayList
        Dim temp_string As String
        While dr.Read
            listElements2.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")", dr.Item("id")))
            temp_string = dr.Item("name")
        End While
        dr.Close()
        dbCon.Close()
        If temp_string <> "" Then
            ListBox2.DataSource = listElements2
            ListBox2.DisplayMember = "LongName"
            ListBox2.ValueMember = "ShortName"
        End If
        'MsgBox(ListBoxLists.SelectedValue.ToString)


        '  Label2.Text = Main.ListBoxLists.SelectedItem()




        'ONOMA CURRENT LISTAS STO LABEL
        strQuery = "SELECT * FROM List where id=" & Main.ListBoxLists.SelectedValue.ToString

        mysqlCmd = New MySqlCommand(strQuery, dbCon)

        dbCon.Open()
        dr = mysqlCmd.ExecuteReader
        Dim whatlistisit As String
        '   Dim listElements3 As New ArrayList
        While dr.Read
            whatlistisit = dr.Item("name")
            '     listElements3.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")" & " (" & dr.Item("sms") & ")", dr.Item("id")))
        End While
        dr.Close()
        dbCon.Close()
        ' ListBox1.DataSource = listElements3
        '   ListBox1.DisplayMember = "LongName"
        '   ListBox1.ValueMember = "ShortName"
        Label7.Text = whatlistisit


    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            Label4.Enabled = False
            Label5.Enabled = False
            Label6.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            Button3.Enabled = False

        Else
            Label4.Enabled = True
            Label5.Enabled = True
            Label6.Enabled = True
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            Button3.Enabled = True
        End If
    End Sub





    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Function RandomString(ByVal cb As Integer) As String
        'CREATE RANDOM STRING
        Randomize()
        Dim rgch As String
        ' rgch = "abcdefghijklmnopqrstuvwxyz"
        ' rgch = rgch & UCase(rgch) & "0123456789"
        rgch = "0123456789"

        Dim i As Long
        For i = 1 To cb
            RandomString = RandomString & Mid$(rgch, Int(Rnd() * Len(rgch) + 1), 1)
        Next

    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' BUTTON ADD TO LIST
        ' MsgBox(Main.ListBoxLists.SelectedValue.ToString)
        ' MsgBox(ListBox1.SelectedValue.ToString)
        Dim random_string As String = "http://83.212.99.225/mailsms/index.php?unsubscribe="
        random_string = random_string & RandomString(10)



        Try
            strQuery = "insert into subscribed_to_list(subscriber_id,list_id,random_string) values(" & ListBox1.SelectedValue.ToString & ",'" & Main.ListBoxLists.SelectedValue.ToString & "','" & random_string & "')"
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

        strQuery = "select subscriber.id, subscriber.name, subscriber.email from subscriber, subscribed_to_list " & _
                            "where subscribed_to_list.subscriber_id=subscriber.id and subscribed_to_list.list_id" & _
                            "=" & Main.ListBoxLists.SelectedValue.ToString & " order by subscriber.name asc"
        mysqlCmd = New MySqlCommand(strQuery, dbCon)

        dbCon.Open()
        dr = mysqlCmd.ExecuteReader

        Dim listElements2 As New ArrayList
        While dr.Read
            listElements2.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")", dr.Item("id")))
        End While
        dr.Close()
        dbCon.Close()
        ListBox2.DataSource = listElements2
        ListBox2.DisplayMember = "LongName"
        ListBox2.ValueMember = "ShortName"

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'BUTTON CREATE SUBSCRIBER
        Dim idcounter As Integer
        Try
            strQuery = "SELECT * FROM Subscriber "
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

        Try
            strQuery = "insert into Subscriber(id,name,email,sms) values(" & idcounter & ",'" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
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

        Try
            strQuery = "SELECT * FROM subscriber order by name"
            mysqlCmd = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()

            dr = mysqlCmd.ExecuteReader
            Dim listElements As New ArrayList
            While dr.Read
                listElements.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")" & " (" & dr.Item("sms") & ")", dr.Item("id")))
            End While

            dr.Close()
            dbCon.Close()

            ListBox1.DataSource = listElements
            ListBox1.DisplayMember = "LongName"
            '  Main.ListBoxLists.ValueMember = "ShortName"

        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'BUTTON DELETE a SUBSCRIBER

        If ListBox1.SelectedIndex <> -1 Then
            If ListBox1.SelectedValue.GetType.FullName = "System.String" Then
                strQuery = "delete from Subscriber where id=" & ListBox1.SelectedValue.ToString

                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()
                dr = mysqlCmd.ExecuteReader

                Dim listElements As New ArrayList
                While dr.Read
                    listElements.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")", dr.Item("id")))
                End While
                dr.Close()
                dbCon.Close()
                ListBox1.DataSource = listElements
                ListBox1.DisplayMember = "LongName"
                ' Main.ListBoxSubscribers.ValueMember = "ShortName"
                'MsgBox(ListBoxLists.SelectedValue.ToString)
            End If

            '  MsgBox(ListBox1.SelectedValue.GetType.FullName)


        End If

        Try
            strQuery = "SELECT * FROM subscriber order by name"
            mysqlCmd = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()

            dr = mysqlCmd.ExecuteReader
            Dim listElements As New ArrayList
            While dr.Read
                listElements.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")" & " (" & dr.Item("sms") & ")", dr.Item("id")))
            End While

            dr.Close()
            dbCon.Close()

            ListBox1.DataSource = listElements
            ListBox1.DisplayMember = "LongName"
            '  Main.ListBoxLists.ValueMember = "ShortName"

        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try

        strQuery = "select subscriber.id, subscriber.name, subscriber.email from subscriber, subscribed_to_list " & _
                            "where subscribed_to_list.subscriber_id=subscriber.id and subscribed_to_list.list_id" & _
                            "=" & Main.ListBoxLists.SelectedValue.ToString & " order by subscriber.name asc"
        mysqlCmd = New MySqlCommand(strQuery, dbCon)

        dbCon.Open()
        dr = mysqlCmd.ExecuteReader

        Dim listElements2 As New ArrayList
        While dr.Read
            listElements2.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")", dr.Item("id")))
        End While
        dr.Close()
        dbCon.Close()
        ListBox2.DataSource = listElements2
        ListBox2.DisplayMember = "LongName"
        ListBox2.ValueMember = "ShortName"

    End Sub


    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'BUTTON REMOVE FROM LIST   EMAIL


        If ListBox2.SelectedIndex <> -1 Then
            '   MsgBox(ListBox2.SelectedValue.ToString)
            ' MsgBox(Main.ListBoxLists.SelectedValue.ToString)

            If ListBox2.SelectedValue.GetType.FullName = "System.String" Then
                strQuery = "delete from Subscribed_to_list where subscriber_id=" & ListBox2.SelectedValue.ToString & " AND list_id=" & Main.ListBoxLists.SelectedValue.ToString

                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()
                dr = mysqlCmd.ExecuteReader

                Dim listElements As New ArrayList
                While dr.Read
                    listElements.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")", dr.Item("id")))
                End While
                dr.Close()
                dbCon.Close()
                ListBox2.DataSource = listElements
                ListBox2.DisplayMember = "LongName"
                ListBox2.ValueMember = "ShortName"
                'MsgBox(ListBoxLists.SelectedValue.ToString)
            End If




        End If

        strQuery = "select subscriber.id, subscriber.name, subscriber.email from subscriber, subscribed_to_list " & _
                            "where subscribed_to_list.subscriber_id=subscriber.id and subscribed_to_list.list_id" & _
                            "=" & Main.ListBoxLists.SelectedValue.ToString & " order by subscriber.name asc"
        mysqlCmd = New MySqlCommand(strQuery, dbCon)

        dbCon.Open()
        dr = mysqlCmd.ExecuteReader

        Dim listElements2 As New ArrayList
        While dr.Read
            listElements2.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")", dr.Item("id")))
        End While
        dr.Close()
        dbCon.Close()
        ListBox2.DataSource = listElements2
        ListBox2.DisplayMember = "LongName"

    End Sub
End Class