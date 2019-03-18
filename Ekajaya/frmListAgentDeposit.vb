Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class frmListAgentDeposit
    Sub fillagent()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        Dim strsql As String = "select agent.AgentID,agent.AgentName from agent inner join agentacc on agent.AgentID=agentacc.agentid   order by AgentName asc"
        da = New MySqlDataAdapter(strsql, conn)
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
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmAddAgentDeposit.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtgodate2.CustomFormat = " "
        txtgodate2.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtgodate.CustomFormat = " "
        txtgodate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub frmListAgentDeposit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String
        Dim whr As String = ""
        If txtgodate.Text <> "" Then
            If txtgodate2.Text = "" Then
                MsgBox("Harap isi Periode Tanggal", vbInformation, "Nominal Error")
                Exit Sub
            Else
                If cboAgent.Text = "" Then
                    whr = "(agentdp.tgl between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "') "
                Else
                    whr = "(agentdp.tgl between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "') and agent.agentid='" & cboAgent.SelectedItem("AgentID").ToString() & "'  "
                End If
            End If
        Else
            whr = "agent.agentid='" & cboAgent.SelectedItem("AgentID").ToString() & "'  "
        End If
        str = "select agent.AgentID,agent.AgentName,agentdp.Number,agentdp.Tgl,agentdp.NOMINAL,agentdp.Keterangan,agent.status from agent inner join agentdp on agentdp.agentid=agent.agentid WHERE " & whr
       

        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(str, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.Columns(0).ReadOnly = True
        LsData.Columns(1).ReadOnly = True
        LsData.Columns(2).ReadOnly = True
        LsData.Columns(3).ReadOnly = True
        LsData.Columns(4).ReadOnly = True
        LsData.Columns(5).ReadOnly = True
        LsData.Columns(6).ReadOnly = True
        LsData.Columns(6).Visible = False
        LsData.Columns(4).DefaultCellStyle.Format = "#,###"
        Call DisconnectDatabase()
        Dim i As Integer
        For i = 0 To LsData.Rows.Count() - 1 Step +1
            Dim val As String
            val = LsData.Rows(i).Cells(3).Value
            If val = "0" Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub cboAgent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAgent.Click
        fillagent()
    End Sub

End Class