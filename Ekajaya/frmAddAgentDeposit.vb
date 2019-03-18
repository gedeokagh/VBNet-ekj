Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddAgentDeposit
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
    Sub BookNo()
        Dim x = cxField("Number", "agentdp", "Number Like 'EAD/" & Year(Now) & Month(Now) & "/%'")
        If x = 0 Then
            txtno.Text = "EAD/" & Month(Now) & "/000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("Number", "agentdp", "Number Like 'EAD/" & Year(Now) & Month(Now) & "/%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            txtno.Text = "EAD/" & Year(Now) & Month(Now) & "/" & numx(Lst, 6)
        End If

    End Sub
    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        If cboagent.Text = "" Then
            MsgBox("Harap Pilih Agent", vbInformation, "Agent Kosong")
            Exit Sub
        End If
        If Not IsNumeric(txtstart.Text) Then
            MsgBox("Harap isi Nominal dengan Angka", vbInformation, "Nominal Error")
            Exit Sub
        End If
        BookNo()
        Dim strsql As String
        Dim cmd As MySqlCommand
        Call ConnectDatabase()
        strsql = "Insert into agentdp (Number,Tgl,AgentID,nominal,Keterangan,user) value ('" & txtno.Text & "','" & Str2Date(txttgl.Text) & "', '" & cboagent.SelectedItem("AgentID").ToString & "'," & txtstart.Text & ",'" & txtend.Text & "','" & usr & "')"
        Dim sstrsql = "Insert into agentacchistory (NoTrans,Tgl,AgentID,nominal,desk) value ('" & txtno.Text & "','" & Str2Date(txttgl.Text) & "', '" & cboagent.SelectedItem("AgentID").ToString & "'," & txtstart.Text & ",'deposit')"
        cmd = New MySqlCommand(strsql, conn)
        cmd.ExecuteScalar()
        cmd = New MySqlCommand(sstrsql, conn)
        cmd.ExecuteScalar()
        Call DisconnectDatabase()
        Dim ex = cxField("AgentID", "agentacc", "AgentID='" & cboagent.SelectedItem("AgentID").ToString & "'")
        Call ConnectDatabase()
        If ex = 0 Then
            strsql = "Insert into agentacc (AgentID,aMOUNT) value ('" & cboagent.SelectedItem("AgentID").ToString & "'," & txtstart.Text & ")"
            cmd = New MySqlCommand(strsql, conn)
            cmd.ExecuteScalar()
        Else
            strsql = "update agentacc set  Amount=amount+" & Val(NZx(txtstart.Text)) & " WHERE AgentID='" & cboagent.SelectedItem("AgentID").ToString & "'"
            cmd = New MySqlCommand(strsql, conn)
            cmd.ExecuteScalar()
        End If
        Call DisconnectDatabase()
        txtno.Text = ""
        txtstart.Text = ""
        txtend.Text = ""
        cboagent.Text = ""

    End Sub

    Private Sub frmAddAgentDeposit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()
        txttgl.Text = Format(Now, "dd/MM/yyyy")
    End Sub
End Class