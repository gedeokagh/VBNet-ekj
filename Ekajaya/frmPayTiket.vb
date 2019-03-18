Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmPayTiket

    Sub fillagent()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select tiketdtl.AgentID as AgentID,agent.AgentName as AgentName from tiketdtl inner join agent on tiketdtl.agentID=agent.AgentID where tiketdtl.inv=0 and  tiketdtl.pay=0 group by tiketdtl.AgentID", conn)
        dt = New DataTable
        da.Fill(dt)
        cboAgent.DataSource = dt
        cboAgent.DisplayMember = "AgentName"
        Call DisconnectDatabase()
    End Sub
    Sub fillBook()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("Select NoBook from tiketdtl where AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "' and tiketdtl.inv=0 and  tiketdtl.pay=0  group by NoBook", conn)
        dt = New DataTable
        da.Fill(dt)
        CboNoBook.DataSource = dt
        CboNoBook.DisplayMember = "NoBook"
        Call DisconnectDatabase()
    End Sub
    Sub BookInv()
        Dim x = cxField("NoInv", "invoice", "NoInv Like 'IEJ/" & GetField("TCode", "user", "username='" & usr & "'") & "-%'")
        If x = 0 Then
            txtNoBook.Text = "IEJ/" & GetField("TCode", "user", "username='" & usr & "'") & "-000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("NoInv", "invoice", "NoInv Like 'IEJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            txtNoBook.Text = "IEJ/" & GetField("TCode", "user", "username='" & usr & "'") & "-" & numx(Lst, 6)
        End If

    End Sub
    Sub filltiket()
        lsData.Columns.Clear()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("SELECT 0 as ID, tiketdtl.NoTiket as NoTiket, tiketdtl.GoDate as DateGo, tiketdtl.GoTrip, trip.TripName as GoTrip,tiketdtl.GoRuteID, rute.RuteName as RuteGo, tiketdtl.GoRate As GoRate, tiketdtl.GoExtra as GoExtraRate, tiketdtl.GoTranRate as GoTransportRate, tiketdtl.GoTransExtra as GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,  rute_1.RuteName as BackRute, tiketdtl.TripBack, trip_1.TripName as TripBack, tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, (tiketdtl.GoRate+ tiketdtl.GoExtra + tiketdtl.GoTranRate + tiketdtl.GoTransExtra + tiketdtl.BackRate + tiketdtl.BackExtra + tiketdtl.BackTransRate + tiketdtl.BackTransExtra)as total FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) INNER JOIN rute AS rute_1 ON tiketdtl.BackRuteID = rute_1.RuteID) INNER JOIN trip AS trip_1 ON tiketdtl.TripBack = trip_1.TripID WHERE (((tiketdtl.AgentID)='" & cboAgent.SelectedItem("AgentID").ToString & "') AND ((tiketdtl.NoBook)='" & CboNoBook.Text & "'))", conn)
        dt = New DataTable
        da.Fill(dt)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = ""
        chk.Name = "ID"
        txttotal.Text = 0
        lsData.Columns.Insert(0, chk)
        lsData.Columns(0).Width = 40
        lsData.Columns(0).ReadOnly = False
        lsData.Columns(19).ReadOnly = True
        lsData.Columns(1).ReadOnly = True
        lsData.Columns(1).Visible = False
        lsData.Columns(2).ReadOnly = True
        lsData.Columns(3).ReadOnly = True
        lsData.Columns(4).ReadOnly = True
        lsData.Columns(4).Visible = False
        lsData.Columns(5).ReadOnly = True
        lsData.Columns(6).ReadOnly = True
        lsData.Columns(7).ReadOnly = True
        lsData.Columns(8).ReadOnly = True
        lsData.Columns(9).ReadOnly = True
        lsData.Columns(10).ReadOnly = True
        lsData.Columns(11).ReadOnly = True
        lsData.Columns(11).Visible = False
        lsData.Columns(12).ReadOnly = True
        lsData.Columns(13).ReadOnly = True
        lsData.Columns(13).Visible = False
        lsData.Columns(14).ReadOnly = True
        lsData.Columns(15).ReadOnly = True
        lsData.Columns(16).ReadOnly = True
        lsData.Columns(17).ReadOnly = True
        lsData.Columns(18).ReadOnly = True
        lsData.Columns(19).ReadOnly = True
        lsData.Columns(20).ReadOnly = True
        lsData.Columns(21).ReadOnly = True
        Call DisconnectDatabase()
    End Sub
    Private Sub frmInvoicing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()
        BookInv()
        txttgltrans.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cboAgent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgent.SelectedIndexChanged
        fillBook()
    End Sub

    Private Sub CboNoBook_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboNoBook.SelectedIndexChanged
        filltiket()
    End Sub

    Private Sub lsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lsData.CellContentClick
        If lsData.Rows(e.RowIndex).Cells(1).Value = 0 Then
            '' MsgBox(LsData.Rows(e.RowIndex.ToString).Cells(5).Value & "Clicked", vbOKOnly, "Process")
            txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(e.RowIndex).Cells(21).Value)
            lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 1
            Exit Sub
        Else
            txttotal.Text = Val(txttotal.Text) - Val(lsData.Rows(e.RowIndex).Cells(21).Value)
            lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 0
            Exit Sub
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        MsgBox("Proggress is underconstruction", vbInformation, "Ups Sorry")
        'Dim I As Integer = lsData.RowCount
        'Dim a, x As Integer
        'Dim strSql, stSql As String
        ' ''Dim dtx, dty As Date
        'x = 0
        'For a = 0 To (I - 1)
        '    If lsData.Rows(a).Cells(1).Value = 1 Then
        '        x = x + 1
        '        Try
        '            Call ConnectDatabase()
        '            Dim cmd As MySqlCommand
        '            strSql = "insert into invoicedtl (ID,NoInv,NoTiket,Total)value(" & a & ", '" & txtNoBook.Text & "','" & lsData.Rows(a).Cells(2).Value & "'," & lsData.Rows(a).Cells(21).Value & ")"
        '            cmd = New MySqlCommand(strSql, conn)
        '            cmd.ExecuteScalar()

        '            Dim cmds As MySqlCommand
        '            stSql = "Update tiketdtl set Inv=1, NoInv='" & txtNoBook.Text & "' where NoTiket='" & lsData.Rows(a).Cells(2).Value & "'"
        '            cmds = New MySqlCommand(stSql, conn)
        '            cmds.ExecuteScalar()
        '            Call DisconnectDatabase()
        '        Catch ex As SqlException
        '            MsgBox(ex.Message)
        '        Finally
        '            ' Close connection
        '            Call DisconnectDatabase()
        '        End Try
        '    End If
        'Next
        'If x > 0 Then
        '    Try
        '        Call ConnectDatabase()
        '        Dim cmd As MySqlCommand
        '        strSql = "insert into invoice (NoInv,Tgl,User,AgentID,Total)value( '" & txtNoBook.Text & "','" & Str2Date(txttgltrans.Text) & "','" & usr & "','" & cboAgent.SelectedItem("AgentID").ToString & "'," & txttotal.Text & ")"
        '        cmd = New MySqlCommand(strSql, conn)
        '        cmd.ExecuteScalar()
        '        FillLog(usr, "Add Invoice No. " & txtNoBook.Text)
        '        If (MsgBox("Process Saved Are You want to Create NewOne?", vbYesNo, "Success")) = vbNo Then
        '            Me.Close()
        '        Else
        '            fillagent()
        '            BookInv()
        '            txttgltrans.Text = Format(Now, "dd/MM/yyyy")
        '        End If
        '        Call DisconnectDatabase()
        '    Catch ex As SqlException
        '        MsgBox(ex.Message)
        '    Finally
        '        ' Close connection
        '        Call DisconnectDatabase()
        '    End Try
        'End If
    End Sub
End Class