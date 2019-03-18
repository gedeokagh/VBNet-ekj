Imports MySql.Data.MySqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmTopSupport


    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        Dim sql As String = ""
        If cboPort.Text = "By Qty" Then
            sql = "select agent.agentid As AgentID,agent.agentname as AgentName, sum(tiketdtl.qty) as Total from tiketdtl inner join agent on tiketdtl.agentid=agent.agentid where (tiketdtl.qtytipe<=2) and (tiketdtl.godate between '" & Str2Date(txtstart.Text) & "' and '" & Str2Date(txtend.Text) & "') and tiketdtl.status=1 group by AgentName order by total desc"
        ElseIf cboPort.Text = "By Harga" Then
            sql = "select agent.agentid As AgentID,agent.agentname as AgentName, sum(tiketdtl.gorate+tiketdtl.backrate) as Total from tiketdtl inner join agent on tiketdtl.agentid=agent.agentid where  (tiketdtl.qtytipe<=2) and (tiketdtl.godate between '" & Str2Date(txtstart.Text) & "' and '" & Str2Date(txtend.Text) & "') and tiketdtl.status=1 group by AgentName order by total desc"
        Else
            Exit Sub
        End If
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(sql, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.Columns(0).Width = 100
        LsData.Columns(1).Width = 300
        LsData.Columns(2).Width = 200
        LsData.Columns(0).HeaderText = "Kode Agent"
        LsData.Columns(1).HeaderText = "Nama Agent"
        LsData.Columns(2).HeaderText = "Total"
        LsData.Columns(2).DefaultCellStyle.Format = "#,###"
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        Call DisconnectDatabase()
    End Sub

    Private Sub frmTopSupport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtstart.Text = "01/" & Format(Now, "MM") & "/" & Format(Now, "yyyy")
        txtstart.CustomFormat = "dd/MM/yyyy"
        txtstart.Format = DateTimePickerFormat.Custom
        txtend.CustomFormat = "dd/MM/yyyy"
        txtend.Format = DateTimePickerFormat.Custom
    End Sub
End Class