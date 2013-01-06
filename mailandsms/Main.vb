Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Imports System.Net

Public Class Main
    Dim dbCon As New MySqlConnection("Server=" & My.Settings.mysqlServer & ";Database=" & My.Settings.mysqlDatabase & ";Uid=" & My.Settings.mysqlUsername & ";Pwd=" & My.Settings.mysqlPassword & ";encrypt=" & My.Settings.mysqlSSL)
    Dim strQuery As String
    Dim mysqlCmd As MySqlCommand
    Dim dr As MySqlDataReader
    Dim thread As System.Threading.Thread

    Private Sub HelpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        Help.Show()
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://aetos.it.teithe.gr/~ikont/adopse/version.txt")
        Dim response As System.Net.HttpWebResponse = request.GetResponse()

        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

        Dim latestVersion As String = sr.ReadToEnd()
        Dim currentVersion As String = Application.ProductVersion
        If latestVersion.Contains(currentVersion) Then
            MessageBox.Show("You are running the latest version of ListManager")
        Else
            Dim result = MessageBox.Show("A new version is available. Yould you like to download the new version", "New version", MessageBoxButtons.OKCancel)
            If result = Windows.Forms.DialogResult.OK Then
                My.Computer.Network.DownloadFile("http://aetos.it.teithe.gr/~ikont/adopse/latest.zip", "C:\latest.zip")
                Process.Start("C:\latest.zip")
            End If
        End If

    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ComposeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ComposeToolStripMenuItem.Click
        If TabControl1.SelectedTab.Text = "Emails" Then
            Compose.Show()
        Else
            ComposeSMS.Show()
        End If
    End Sub

    Private Sub SmtpServerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SmtpServerToolStripMenuItem.Click
        SmtpSettings.Show()
    End Sub

    Private Sub MySQLAccountToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MySQLAccountToolStripMenuItem.Click
        MySQLSettings.Show()
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CreditsToolStripMenuItem.Click
        Credits.Show()
    End Sub

    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
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
            ListBoxLists.DataSource = listElements
            ListBoxLists.DisplayMember = "LongName"
            ListBoxLists.ValueMember = "ShortName"

            '  ListBoxLists.ClearSelected()
        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try

        Dim rows As Integer
        Try
            strQuery = "SELECT COUNT(*) FROM List where type='email'"
            mysqlCmd = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()

            'Metrao tis seires tou pinaka List me type email
            mysqlCmd.CommandText = strQuery
            rows = mysqlCmd.ExecuteScalar()
            'Emfanizo tis seires tou pinaka List me type email
            Label7.Text = rows

            dbCon.Close()

        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            'ListBoxLists.Items.Clear()
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
                ListBoxLists.DataSource = listElements
                ListBoxLists.DisplayMember = "LongName"
                ListBoxLists.ValueMember = "ShortName"
            Catch ex As Exception
                MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
            End Try

            Dim rows As Integer
            Try
                strQuery = "SELECT COUNT(*) FROM List where type='email'"
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()

                'Metrao tis seires tou pinaka List me type email
                mysqlCmd.CommandText = strQuery
                rows = mysqlCmd.ExecuteScalar()
                'Emfanizo tis seires tou pinaka List me type email
                Label7.Text = rows

                dbCon.Close()

            Catch ex As Exception
                MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
            End Try



        ElseIf TabControl1.SelectedIndex = 1 Then
            '  ListBoxSubscribers.Items.Clear()
            Try
                strQuery = "select id, name from list where type='sms' order by name asc"
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()
                dr = mysqlCmd.ExecuteReader

                Dim listElements As New ArrayList
                While dr.Read
                    listElements.Add(New ListElement(dr.Item("name"), dr.Item("id")))
                End While
                dr.Close()
                dbCon.Close()
                ListBox2.DataSource = listElements
                ListBox2.DisplayMember = "LongName"
                ListBox2.ValueMember = "ShortName"

                '   ListBoxLists.ClearSelected()
            Catch ex As Exception
                MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
            End Try

            Dim rows As Integer
            Try
                strQuery = "SELECT COUNT(*) FROM List where type='sms'"
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()

                'Metrao tis seires tou pinaka List me type sms
                mysqlCmd.CommandText = strQuery
                rows = mysqlCmd.ExecuteScalar()
                'Emfanizo tis seires tou pinaka List me type sms
                Label8.Text = rows

                dbCon.Close()

            Catch ex As Exception
                MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
            End Try
        End If
    End Sub



    Private Sub ListBoxLists_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxLists.SelectedIndexChanged
        'TOY TAB EMAIL


        If ListBoxLists.SelectedIndex <> -1 Then
            If ListBoxLists.SelectedValue.GetType.FullName = "System.String" Then
                strQuery = "select subscriber.id, subscriber.name, subscriber.email from subscriber, subscribed_to_list " & _
                            "where subscribed_to_list.subscriber_id=subscriber.id and subscribed_to_list.list_id" & _
                            "=" & ListBoxLists.SelectedValue.ToString & " order by subscriber.name asc"
                mysqlCmd = New MySqlCommand(strQuery, dbCon)
                dbCon.Open()
                dr = mysqlCmd.ExecuteReader

                Dim listElements As New ArrayList
                While dr.Read
                    listElements.Add(New ListElement(dr.Item("name") & " (" & dr.Item("email") & ")", dr.Item("id")))
                End While
                dr.Close()
                'dbCon.Close()
                ListBoxSubscribers.DataSource = listElements
                ListBoxSubscribers.DisplayMember = "LongName"
                If ListBoxSubscribers.ValueMember <> "" Then
                    ListBoxSubscribers.ValueMember = "ShortName"
                End If


                strQuery = "SELECT COUNT(*) FROM subscribed_to_list where list_id=" & ListBoxLists.SelectedValue
                mysqlCmd = New MySqlCommand(strQuery, dbCon)


                'Metrao tis seires tou pinaka List me type email
                mysqlCmd.CommandText = strQuery
                Label9.Text = mysqlCmd.ExecuteScalar()

                dbCon.Close()

            End If
        End If


    End Sub

    Private Sub sendEmail(ByVal recipients As ArrayList, ByVal subject As String, ByVal body As String)

        For Each recipientAndString As String In recipients

            Dim recipient As String = recipientAndString.Split(" ")(0)
            Dim randomString As String = recipientAndString.Split(" ")(1)
            Dim mail As New MailMessage
            mail.Subject = subject
            mail.To.Add(recipient)
            mail.From = New MailAddress(My.Settings.fromAddress)
            mail.Body = body & vbCrLf & "If you wish to unsubscribe from the list follow <a href=""" & randomString & """>this link</a></body></html>"
            'MessageBox.Show(mail.Body)
            mail.IsBodyHtml = True
            mail.BodyEncoding = System.Text.Encoding.UTF8

            Dim SMTP As New SmtpClient(My.Settings.smtpServer)
            SMTP.Credentials = New System.Net.NetworkCredential(My.Settings.SMTPUsername, My.Settings.SMTPPassword)

            SMTP.Port = My.Settings.SMTPPort
            SMTP.EnableSsl = My.Settings.SMTLSSL

            SMTP.Send(mail)

        Next
    End Sub

    Private Sub sendSMS(ByVal recipients As ArrayList, ByVal message As String)

    End Sub

    Private Sub processQueue()
        Dim dbCon As New MySqlConnection("Server=" & My.Settings.mysqlServer & ";Database=" & _
                                         My.Settings.mysqlDatabase & ";Uid=" & My.Settings.mysqlUsername & _
                                         ";Pwd=" & My.Settings.mysqlPassword & ";encrypt=" & My.Settings.mysqlSSL)
        Try
            Dim strQuery As String = "select subscriber.email, message.subject, message.message, subscribed_to_list.random_string from message, subscriber, subscribed_to_list, " & _
                "listmessage, list where list.type='email' and list.id = subscribed_to_list.list_id and message.id = listmessage.message_id " & _
                "and listmessage.list_id = subscribed_to_list.list_id and subscribed_to_list.subscriber_id = subscriber.id " & _
                "and listmessage.date < CURRENT_TIMESTAMP"

            Dim mysqlCmd As MySqlCommand = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()
            Dim dr As MySqlDataReader = mysqlCmd.ExecuteReader

            Dim recipients As ArrayList = New ArrayList
            While dr.Read
                recipients.Add(dr.Item("email") & " " & dr.Item("random_string"))
            End While
            Try
                If recipients.Count > 0 Then

                    sendEmail(recipients, dr.Item("subject"), dr.Item("message"))
                    dr.Close()

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            dr.Close()
            dbCon.Close()
        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try


        '
        ' Send sms
        '

        Try
            
            Dim strQuery As String = "select subscriber.sms as sms, message.message as msg from message, subscriber, subscribed_to_list, listmessage, " & _
                "list where list.type='sms' and list.id = subscribed_to_list.list_id and message.id = listmessage.message_id  " & _
                "and subscribed_to_list.subscriber_id = subscriber.id and listmessage.date < CURRENT_TIMESTAMP"

            Dim mysqlCmd As MySqlCommand = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()
            Dim dr As MySqlDataReader = mysqlCmd.ExecuteReader

            While dr.Read
                Dim sms As String = dr.Item("sms")
                Dim msg As String = dr.Item("msg")

                Dim url As String = "https://www.smsn.gr/api/http/send.php?username=" + My.Settings.smsUsername + "&password=" + My.Settings.smsPassword + "&from=mailsms&message=" + msg + "&to=" + sms
                MessageBox.Show(url)
                WebBrowser1.Navigate(url)
            End While
            dr.Close()
            
            strQuery = "delete from listmessage where date < CURRENT_TIMESTAMP"
            mysqlCmd = New MySqlCommand(strQuery, dbCon)
            mysqlCmd.ExecuteNonQuery()

            dbCon.Close()

        Catch ex As Exception
            MsgBox("Failure to communicate with server" & vbCrLf & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        thread = New System.Threading.Thread(AddressOf processQueue)
        thread.Start()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        'TOY TAB SMS
        If ListBox2.SelectedIndex <> -1 Then
            If ListBox2.SelectedValue.GetType.FullName = "System.String" Then
                strQuery = "select subscriber.id, subscriber.name, subscriber.sms from subscriber, subscribed_to_list " & _
                           "where subscribed_to_list.subscriber_id=subscriber.id and subscribed_to_list.list_id" & _
                          "=" & ListBox2.SelectedValue.ToString & " order by subscriber.name asc"
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                dbCon.Open()
                dr = mysqlCmd.ExecuteReader

                Dim listElements As New ArrayList
                While dr.Read
                    listElements.Add(New ListElement(dr.Item("name") & " (" & dr.Item("sms") & ")", dr.Item("id")))
                End While
                dr.Close()
                ListBox1.DataSource = listElements
                ListBox1.DisplayMember = "LongName"
                If ListBox1.ValueMember <> "" Then
                    ListBox1.ValueMember = "ShortName"
                End If

                strQuery = "SELECT COUNT(*) FROM subscribed_to_list where list_id=" & ListBox2.SelectedValue
                mysqlCmd = New MySqlCommand(strQuery, dbCon)

                mysqlCmd.CommandText = strQuery
                Label4.Text = "Subscribers #: " & mysqlCmd.ExecuteScalar()

                dbCon.Close()
            End If


        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'BUTTON CREATE from EMAIL TAB
        CreateEmailList.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'BUTTON DELETE from EMAIL TAB
        DeleteEmailList.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'BUTTON CREATE from SMS TAB
        CreateSmsList.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'BUTTON DELETE from SMS TAB
        DeleteSmsList.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'BUTTON SUBSCRIBE from EMAIL TAB
        SubscribeEmail.Show()
    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'BUTOON SUBSCRIBE from SMS TAB
        SubscribeSms.Show()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        About.Show()
    End Sub

    Private Sub LicenceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LicenceToolStripMenuItem.Click
        License.Show()
    End Sub

    Private Sub ClearQueueToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearQueueToolStripMenuItem.Click
        strQuery = "delete from message"
        mysqlCmd = New MySqlCommand(strQuery, dbCon)

        dbCon.Open()
        mysqlCmd.ExecuteNonQuery()
        dbCon.Close()
        MessageBox.Show("The message queue has been purged")
    End Sub

    Private Sub ShowQueueToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowQueueToolStripMenuItem.Click
        strQuery = "SELECT list.name as name, list.type as type, listmessage.date  as date FROM listmessage, list WHERE list.id = listmessage.list_id"
        mysqlCmd = New MySqlCommand(strQuery, dbCon)

        dbCon.Open()
        Dim dr As MySqlDataReader = mysqlCmd.ExecuteReader
        Form2.TextBox1.Text = ""
        While dr.Read
            Form2.TextBox1.Text = Form2.TextBox1.Text & dr.GetString("name") & ", " & dr.GetString("type") & vbCrLf
        End While
        dr.Close()
        dbCon.Close()
        Form2.Show()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Dim res As DialogResult
        Dim fname As String
        SaveFileDialog1.Filter = "Txt files|*txt"
        SaveFileDialog1.InitialDirectory = "C:\"
        res = SaveFileDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then

            strQuery = "SELECT list.name as lname, list.type as ltype, subscriber.name as sname, subscriber.email as semail, subscriber.sms as ssms FROM list, subscribed_to_list, " & _
                        "subscriber where list.id = subscribed_to_list.list_id and subscribed_to_list.subscriber_id = subscriber.id"
            mysqlCmd = New MySqlCommand(strQuery, dbCon)

            dbCon.Open()
            Dim dr As MySqlDataReader = mysqlCmd.ExecuteReader
            Dim objWriter As New System.IO.StreamWriter(SaveFileDialog1.FileName)


            While dr.Read
                objWriter.Write(dr.GetString("lname") & ", " & dr.GetString("ltype") & ", " & dr.GetString("sname") & ", " & dr.GetString("semail") & ", " & dr.GetString("ssms") & vbCrLf)
            End While
            objWriter.Close()
            dr.Close()
            dbCon.Close()


            
        End If
    End Sub

    Private Sub SMSAccountToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SMSAccountToolStripMenuItem.Click
        SmsSettings.Show()
    End Sub
End Class

Public Class ListElement
    Private myShortName As String
    Private myLongName As String

    Public Sub New(ByVal strLongName As String, ByVal strShortName As String)
        Me.myShortName = strShortName
        Me.myLongName = strLongName
    End Sub 'New 

    Public ReadOnly Property ShortName() As String
        Get
            Return myShortName
        End Get
    End Property

    Public ReadOnly Property LongName() As String
        Get
            Return myLongName
        End Get
    End Property

End Class 'ListElement
