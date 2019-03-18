Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmagentlist
    Public forms As String
    Sub fillData(ByVal str As String)
        If str = "0" Then
            str = "select AgentID,AgentName,Note,if(Payment=1,'Cash Only','Allow Credit') as Payment,if(status=0,'void','Active') as Status from agent"
        End If
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
        LsData.Columns(0).Visible = False
        LsData.Columns(1).ReadOnly = True
        LsData.Columns(2).ReadOnly = True
        LsData.Columns(3).ReadOnly = True
        LsData.Columns(4).ReadOnly = True
        Call DisconnectDatabase()
    End Sub
    Private Sub frmagentlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillData("0")
    End Sub

    Private Sub LsData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellClick
        If forms = "AgentRate" Then
            frmAgentRate.Show()
            frmAgentRate.txtid.Text = LsData.CurrentRow.Cells(0).Value
            frmAgentRate.txtname.Text = LsData.CurrentRow.Cells(1).Value
            Me.Hide()
        End If
        If forms = "Booking" Then
            frmBooking.Show()
            frmBooking.txtagentid.Text = LsData.CurrentRow.Cells(0).Value
            frmBooking.txtagent.Text = LsData.CurrentRow.Cells(1).Value
            Me.Hide()
        End If
    End Sub

    Private Sub LsData_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles LsData.CellFormatting
        Dim i As Integer
        For i = 0 To LsData.Rows.Count() - 1 Step +1
            Dim val As String
            val = LsData.Rows(i).Cells(4).Value
            If val = "void" Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        If forms = "AgentRate" Then
            frmAgentRate.Show()
            frmAgentRate.txtid.Text = LsData.CurrentRow.Cells(0).Value
            frmAgentRate.txtname.Text = LsData.CurrentRow.Cells(1).Value
            Me.Close()
        End If
        If forms = "Booking" Then
            frmBooking.Show()
            frmBooking.txtagentid.Text = LsData.CurrentRow.Cells(0).Value
            frmBooking.txtagent.Text = LsData.CurrentRow.Cells(1).Value
            Me.Close()
        End If
        If forms = "3ABooking" Then
            frmBooking3A.Show()
            frmBooking3A.txtagentid.Text = LsData.CurrentRow.Cells(0).Value
            frmBooking3A.txtagent.Text = LsData.CurrentRow.Cells(1).Value
            Me.Close()
        End If
        If forms = "mBooking" Then
            frmMultiBooking.Show()
            frmMultiBooking.txtagentid.Text = LsData.CurrentRow.Cells(0).Value
            frmMultiBooking.txtagent.Text = LsData.CurrentRow.Cells(1).Value
            Me.Close()
        End If
        If forms = "EdtBooking" Then
            frmEditBooking.Show()
            frmEditBooking.txtagentid.Text = LsData.CurrentRow.Cells(0).Value
            frmEditBooking.txtagent.Text = LsData.CurrentRow.Cells(1).Value
            Me.Close()
        End If
        If forms = "tour" Then
            frmTourList.Show()
            frmTourList.txtagentid.Text = LsData.CurrentRow.Cells(0).Value
            frmTourList.txtagent.Text = LsData.CurrentRow.Cells(1).Value
            Me.Close()
        End If
        If forms = "tourorder" Then
            frmTourOrder.Show()
            frmTourOrder.txtagentid.Text = LsData.CurrentRow.Cells(0).Value
            frmTourOrder.txtagent.Text = LsData.CurrentRow.Cells(1).Value
            Me.Close()
        End If
    End Sub

    Private Sub cmdFillter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        Dim sts As String = ""
        sts = "select AgentID,AgentName,Note,if(Payment=1,'Cash Only','Allow Credit') as Payment,if(status=0,'void','Active') as Status from agent where AgentName like '%" & txtName.Text & "%'"
        fillData(sts)
    End Sub
End Class