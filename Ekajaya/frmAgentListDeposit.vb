Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmAgentListDeposit
    Sub fillData()
        Dim str As String
        If txtName.Text = "" Then
            str = "select agent.AgentID,agent.AgentName,agentacc.Amount,agent.status from agent inner join agentacc on agentacc.agentid=agent.agentid"
        Else
            str = "select agent.AgentID,agent.AgentName,agentacc.Amount,agent.status from agent inner join agentacc on agentacc.agentid=agent.agentid WHERE agent.agentname like '%" & txtName.Text & "%'"
        End If


        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(Str, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.Columns(0).ReadOnly = True
        LsData.Columns(1).ReadOnly = True
        LsData.Columns(2).ReadOnly = True
        LsData.Columns(3).ReadOnly = True
        LsData.Columns(3).Visible = False
        LsData.Columns(2).DefaultCellStyle.Format = "#,###"
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
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmAgentListDeposit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillData()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        fillData()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        fillData()
    End Sub
End Class