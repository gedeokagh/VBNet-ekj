Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmSellBook
    Sub fillagent()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID,AgentName from agent where status=1 order by AgentName asc", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("AgentID") = 0
        dr("AgentName") = ""
        dt.Rows.InsertAt(dr, 0)
        cboAgent.DataSource = dt
        cboAgent.DisplayMember = "AgentName"

        Call DisconnectDatabase()
    End Sub
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
    Sub BookNo()
        Dim x = cxField("NoBuy", "tiketbuy", "NoBuy Like 'EJB/" & Year(Now) & Month(Now) & "/%'")
        If x = 0 Then
            txtno.Text = "EJB/" & Month(Now) & "/000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("NoBuy", "tiketbuy", "NoBuy Like 'EJB/" & Year(Now) & Month(Now) & "/%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            txtno.Text = "EJB/" & Year(Now) & Month(Now) & "/" & numx(Lst, 6)
        End If

    End Sub
    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        If txtstart.Text = "" Then
            MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
            txtstart.Focus()
            Exit Sub
        ElseIf Len(txtstart.Text) < 11 Then
            MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
            txtstart.Focus()
            Exit Sub
        End If
        If txtend.Text = "" Then
            MsgBox("Please Fill End Tiket", vbInformation, "End Tiket Empty")
            txtend.Focus()
            Exit Sub
        ElseIf Len(txtend.Text) < 11 Then
            MsgBox("Please Fill End Tiket", vbInformation, "End Tiket Empty")
            txtend.Focus()
            Exit Sub
        End If
        If cxField("NoTiket", "tiketdtl", "notiket between '" & txtstart.Text & "' and '" & txtend.Text & "'") <> 0 Then
            MsgBox("Tiket from '" & txtstart.Text & "' to '" & txtend.Text & "' already sell before!!", vbInformation, "Tiket Error")
            Exit Sub
        End If
        BookNo()
        Dim a, b, c As Integer
        Dim str As String
        str = txtstart.Text
        b = Val(Mid(txtend.Text, 6, 6))
        c = 1

        Dim strSQL As String
        Dim cmd As MySqlCommand
        For a = Val(Mid(txtstart.Text, 6, 6)) To b

            Try
                Call ConnectDatabase()

                If cxField("NoTiket", "ticket", "notiket='" & str & "'") = 0 Then
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    strSQL = "Insert into ticket (NoTiket,TipeTiket,AgentID) value ('" & str & "','" & Mid(cbotipe.Text, 1, 2) & "', '" & cboagent.SelectedItem("AgentID").ToString & "')"
                    cmd = New MySqlCommand(strSQL, conn)
                    cmd.ExecuteScalar()
                Else
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    strSQL = "UPDATE ticket set AgentID='" & cboagent.SelectedItem("AgentID").ToString & "' where NoTiket='" & str & "'"
                    cmd = New MySqlCommand(strSQL, conn)
                    cmd.ExecuteScalar()
                End If
                ' ''strSQL = "Insert into tiketdtl (NoEtiket,NoTiket,Tipe,AgentID,NoBook) values ('" & txtno.Text & "-" & c & "','" & str & "','" & Mid(cbotipe.Text, 1, 2) & "', '" & cboagent.SelectedItem("AgentID").ToString & "','" & txtno.Text & "')"
                ' ''cmd = New MySqlCommand(strSQL, conn)
                ' ''cmd.ExecuteScalar()
                Call DisconnectDatabase()
            Catch ex As SqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
            Dim s As Integer = Val(Mid(str, 6, 6)) + 1
            str = Mid(str, 1, 5) & numx(s, 6)
            c = c + 1
        Next
        Call ConnectDatabase()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        strSQL = "Insert into tiketbuy (Nobuy,tgl,user,StartTiket,EndTiket,AgentID) values ('" & txtno.Text & "','" & Str2Date(txttgl.Text) & "','" & usr & "','" & txtstart.Text & "','" & txtend.Text & "', '" & cboagent.SelectedItem("AgentID").ToString & "')"
        cmd = New MySqlCommand(strSQL, conn)
        cmd.ExecuteScalar()
        Call DisconnectDatabase()
        MsgBox("Trasaction Number " & txtno.Text & "  Success", vbInformation, "Success")
        FillLog(usr, "Add New Book Series", " Tiket No. " & txtno.Text, "", "")
        If (MsgBox("Are You want to Add New Transaction?", vbYesNo, "Add New?") = vbYes) Then
            txtno.Text = ""
            cboagent.Text = ""
            cbotipe.Text = ""
            txtstart.Text = ""
            txtend.Text = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub txtstart_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstart.LostFocus
        txtstart.Text = UCase(txtstart.Text)
    End Sub

    Private Sub txtend_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtend.LostFocus
        txtend.Text = UCase(txtend.Text)
    End Sub

    Private Sub txtstart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstart.TextChanged
        If cbotipe.Text = "" Then
            MsgBox("Please Select Ticket Type", vbInformation, "Tiket Type Empty")
        End If
    End Sub

    Private Sub frmSellBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()
        txttgl.Text = Format(Now, "dd/MM/yyyy")
    End Sub
End Class