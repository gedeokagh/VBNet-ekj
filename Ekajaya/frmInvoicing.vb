Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmInvoicing

    
    Sub fillagent()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select tiketdtl.AgentID as AgentID,agent.AgentName as AgentName from tiketdtl inner join agent on tiketdtl.agentID=agent.AgentID where tiketdtl.inv=0  AND tiketdtl.pay=0 and godate>='2018-09-01' group by tiketdtl.AgentID", conn)
        dt = New DataTable

        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("AgentID") = 0
        dr("AgentName") = ""
        dt.Rows.InsertAt(dr, 0)
        cboAgent.DataSource = dt
        cboAgent.DisplayMember = "AgentName"
        Dim da2 As MySqlDataAdapter
        Dim dt2 As DataTable
        da2 = New MySqlDataAdapter("select tiketdtl.AgentID as AgentID,agent.AgentName as AgentName from tiketdtl inner join agent on tiketdtl.agentID=agent.AgentID where tiketdtl.inv=1  AND tiketdtl.pay=0 and godate>='2018-09-01' group by tiketdtl.AgentID", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("AgentID") = 0
        dr2("AgentName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        cboAgent2.DataSource = dt2
        cboAgent2.DisplayMember = "AgentName"
        Call DisconnectDatabase()
        ''
    End Sub
    Sub fillBook()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("Select NoBook from tiketdtl where AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "' and tiketdtl.inv=0 and tiketdtl.Sisa<>0 AND tiketdtl.pay=0 and godate>='2018-09-01'  group by NoBook", conn)
        dt = New DataTable
        da.Fill(dt)
        CboNoBook.DataSource = dt
        CboNoBook.DisplayMember = "NoBook"
        Call DisconnectDatabase()
    End Sub
    Sub fillInv()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("Select NoInv from tiketdtl where AgentID='" & cboAgent2.SelectedItem("AgentID").ToString() & "' and tiketdtl.inv=1 AND tiketdtl.pay=0 and godate>='2018-09-01' group by NoInv", conn)
        ''
        dt = New DataTable
        da.Fill(dt)
        cboInv.DataSource = dt
        cboInv.DisplayMember = "NoInv"
        Call DisconnectDatabase()
    End Sub
    Sub BookInv()
        'Dim x = cxField("NoInv", "invoice", "NoInv Like 'IEJ/" & GetField("TCode", "user", "username='" & usr & "'") & "-%'")
        Dim x = cxField("NoInv", "invoice", "NoInv Like 'INV/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-%'")
        If x = 0 Then
            'txtNoBook.Text = "IEJ/" & GetField("TCode", "user", "username='" & usr & "'") & "-000001"
            txtNoBook.Text = "INV/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            'Dim Lst = DLast("NoInv", "invoice", "NoInv Like 'IEJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'")
            Dim Lst = DLast("NoInv", "invoice", "NoInv Like 'INV/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6)) + 1
            'txtNoBook.Text = "IEJ/" & GetField("TCode", "user", "username='" & usr & "'") & "-" & numx(Lst, 6)
            txtNoBook.Text = "INV/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-" & numx(Lst, 6)
        End If

    End Sub
    Sub filltiket(ByVal sql As String)
        If lsData.RowCount > 0 Then
            lsData.Columns.Clear()
        End If

        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        'da = New MySqlDataAdapter("SELECT 0 as ID, tiketdtl.NoETiket as NoETiket,tiketdtl.NoTiket as NoTiket, tiketdtl.GoDate as DateGo, tiketdtl.GoTrip, trip.TripName as GoTrip,tiketdtl.GoRuteID, rute.RuteName as RuteGo, tiketdtl.GoRate As GoRate, tiketdtl.GoExtra as GoExtraRate, tiketdtl.GoTranRate as GoTransportRate, tiketdtl.GoTransExtra as GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,  rute_1.RuteName as BackRute, tiketdtl.TripBack, trip_1.TripName as TripBack, tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, (tiketdtl.GoRate+ tiketdtl.GoExtra + tiketdtl.GoTranRate + tiketdtl.GoTransExtra + tiketdtl.BackRate + tiketdtl.BackExtra + tiketdtl.BackTransRate + tiketdtl.BackTransExtra)as total FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) INNER JOIN rute AS rute_1 ON tiketdtl.BackRuteID = rute_1.RuteID) INNER JOIN trip AS trip_1 ON tiketdtl.TripBack = trip_1.TripID WHERE (((tiketdtl.AgentID)='" & cboAgent.SelectedItem("AgentID").ToString & "') AND ((tiketdtl.NoBook)='" & CboNoBook.Text & "'))", conn)
        ''
        'sql = "SELECT 0 as ID, tiketdtl.NoETiket as NoETiket,tiketdtl.NoTiket as NoTiket, tiketdtl.GoDate as DateGo, tiketdtl.GoTrip, trip.TripName as GoTrip,tiketdtl.GoRuteID, rute.RuteName as RuteGo, tiketdtl.GoRate As GoRate, tiketdtl.GoExtra as GoExtraRate, tiketdtl.GoTranRate as GoTransportRate, tiketdtl.GoTransExtra as GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,  rute_1.RuteName as BackRute, tiketdtl.TripBack, trip_1.TripName as TripBack, tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, (tiketdtl.GoRate+ tiketdtl.GoExtra + tiketdtl.GoTranRate + tiketdtl.GoTransExtra + tiketdtl.BackRate + tiketdtl.BackExtra + tiketdtl.BackTransRate + tiketdtl.BackTransExtra)as total FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) INNER JOIN rute AS rute_1 ON tiketdtl.BackRuteID = rute_1.RuteID) INNER JOIN trip AS trip_1 ON tiketdtl.TripBack = trip_1.TripID WHERE (tiketdtl.sisa<>0) and (((tiketdtl.AgentID)='" & cboAgent.SelectedItem("AgentID").ToString & "') AND ((tiketdtl.NoBook)='" & CboNoBook.Text & "'))"

        da = New MySqlDataAdapter(sql, conn)

        dt = New DataTable
        da.Fill(dt)
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = ""
        chk.Name = "ID"
        txttotal.Text = 0
        lsData.Columns.Insert(0, chk)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        
        lsData.Columns(0).Width = 40

        lsData.Columns(0).ReadOnly = True
        lsData.Columns(2).Width = 120
        lsData.Columns(3).Width = 100
        lsData.Columns(5).Width = 75
        lsData.Columns(6).Width = 50
        lsData.Columns(1).ReadOnly = False
        lsData.Columns(1).Visible = False
        lsData.Columns(10).Visible = False
        lsData.Columns(2).ReadOnly = True
        lsData.Columns(3).ReadOnly = True
        lsData.Columns(4).ReadOnly = True
        
        lsData.Columns(5).ReadOnly = True
        lsData.Columns(6).ReadOnly = True

        lsData.Columns(7).ReadOnly = True
        lsData.Columns(8).ReadOnly = True
        lsData.Columns(9).ReadOnly = True
        lsData.Columns(11).DefaultCellStyle.Format = "#,###"
        lsData.Columns(7).DefaultCellStyle.Format = "#,###"
        lsData.Columns(8).DefaultCellStyle.Format = "#,###"
        lsData.Columns(9).DefaultCellStyle.Format = "#,###"
        


        Call DisconnectDatabase()
    End Sub
    Private Sub frmInvoicing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()

        txttgltrans.Text = Format(Now, "dd/MM/yyyy")
        txtdate.CustomFormat = " "
        txtdate.Format = DateTimePickerFormat.Custom
        txtdate2.CustomFormat = " "
        txtdate2.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cboAgent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgent.SelectedIndexChanged
        'fillBook()
    End Sub

    Private Sub CboNoBook_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboNoBook.SelectedIndexChanged
        ' filltiket()
    End Sub

    Private Sub lsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lsData.CellContentClick
        If lsData.Rows(e.RowIndex).Cells(0).Value = False Then
            '' MsgBox(LsData.Rows(e.RowIndex.ToString).Cells(5).Value & "Clicked", vbOKOnly, "Process")
            txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(e.RowIndex).Cells(10).Value)
            lsData.Rows(e.RowIndex).Cells(0).Value = True

            lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 1
            Exit Sub
        Else
            txttotal.Text = Val(txttotal.Text) - Val(lsData.Rows(e.RowIndex).Cells(10).Value)

            lsData.Rows(e.RowIndex.ToString).Cells(0).Value = False
            Exit Sub
        End If
        'If lsData.Rows(e.RowIndex).Cells(1).Value = 0 Then
        '    '' MsgBox(LsData.Rows(e.RowIndex.ToString).Cells(5).Value & "Clicked", vbOKOnly, "Process")
        '    txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(e.RowIndex).Cells(10).Value)

        '    lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 1
        '    Exit Sub
        'Else
        '    '            txttotal.Text = Val(txttotal.Text) - Val(lsData.Rows(e.RowIndex).Cells(23).Value)

        '    txttotal.Text = Val(txttotal.Text) - Val(lsData.Rows(e.RowIndex).Cells(10).Value)
        '    lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 0
        '    Exit Sub
        'End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        BookInv()
        Dim I As Integer = lsData.RowCount
        Dim a, x As Integer
        Dim strSql, stSql As String
        ''Dim dtx, dty As Date
        x = 0
        For a = 0 To (I - 1)
            ''If lsData.Rows(a).Cells(1).Value = 1 Then  
            If lsData.Rows(a).Cells(0).Value = True Then
                x = x + 1
                Try
                    Call ConnectDatabase()
                    Dim cmd As MySqlCommand
                    strSql = "insert into invoicedtl (ID,NoInv,NoTiket,NoETiket,Total)value(" & a & ", '" & txtNoBook.Text & "','" & lsData.Rows(a).Cells(2).Value & "','" & lsData.Rows(a).Cells(3).Value & "'," & lsData.Rows(a).Cells(10).Value & ")"
                    cmd = New MySqlCommand(strSql, conn)
                    cmd.ExecuteScalar()

                    Dim cmds As MySqlCommand
                    stSql = "Update tiketdtl set Inv=1, NoInv='" & txtNoBook.Text & "', tGLInv='" & Str2Date(txttgltrans.Text) & "' where NoETiket='" & lsData.Rows(a).Cells(2).Value & "'"
                    cmds = New MySqlCommand(stSql, conn)
                    cmds.ExecuteScalar()
                    Call DisconnectDatabase()
                Catch ex As SqlException
                    MsgBox(ex.Message)
                Finally
                    ' Close connection
                    Call DisconnectDatabase()
                End Try
            End If
        Next
        If x > 0 Then
            Try
                Call ConnectDatabase()
                Dim cmd As MySqlCommand
                strSql = "insert into invoice (NoInv,Tgl,User,AgentID,Total)value( '" & txtNoBook.Text & "','" & Str2Date(txttgltrans.Text) & "','" & usr & "','" & cboAgent.SelectedItem("AgentID").ToString & "'," & txttotal.Text & ")"
                cmd = New MySqlCommand(strSql, conn)
                cmd.ExecuteScalar()
                FillLog(usr, "Add Invoice", " No. " & txtNoBook.Text, "", "")
                If (MsgBox("Print Proforma Invoice?", vbYesNo, "Success")) = vbYes Then
                    frmPrintInv.NoInvPrint = txtNoBook.Text
                    frmPrintInv.Show()
                End If
                If (MsgBox("Process Saved Are You want to Create NewOne?", vbYesNo, "Success")) = vbNo Then
                    Me.Close()
                Else
                    fillagent()
                    'BookInv()
                    txtNoBook.Text = ""
                    'If lsData.RowCount > 0 Then
                    'lsData.Rows.Clear()
                    lsData.DataSource = Nothing
                    'End If
                    txttgltrans.Text = Format(Now, "dd/MM/yyyy")
                    txttotal.Text = 0
                End If
                Call DisconnectDatabase()
            Catch ex As SqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtdate.CustomFormat = " "
        txtdate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtdate2.CustomFormat = " "
        txtdate2.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub cmdfilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfilter.Click
        Dim sql As String = ""
        If cboAgent.Text = "" Then
            MsgBox("Please fill Agent", vbInformation, "Agent is Empty")
            Exit Sub
        Else
            sql = "((tiketdtl.AgentID)='" & cboAgent.SelectedItem("AgentID").ToString & "')"
        End If
       
        If Trim(txtdate.Text) <> "" Then
            If Trim(txtdate2.Text) <> "" Then
                'sql = sql & " and (((tiketdtl.GoDate) between '" & Str2Date(txtdate.Text) & "' and '" & Str2Date(txtdate2.Text) & "') or ((tiketdtl.BackDate) between '" & Str2Date(txtdate.Text) & "' and '" & Str2Date(txtdate2.Text) & "'))"
                ''
                sql = sql & " and ((tiketdtl.GoDate) between '" & Str2Date(txtdate.Text) & "' and '" & Str2Date(txtdate2.Text) & "') "
            Else
                MsgBox("Please fill To Date", vbInformation, "To Date is Empty")
                Exit Sub
            End If
        End If
        If Trim(txtstart.Text) <> "" Then
            If Trim(txtend.Text) <> "" Then
                sql = sql & " and ((tiketdtl.Notiket) between '" & txtstart.Text & "' and '" & txtend.Text & "') "
            Else
                MsgBox("Please End No.Tiket", vbInformation, "To No.Tiket is Empty")
                txtend.Focus()
                Exit Sub
            End If
        End If
        
        'sql = "SELECT 0 as ID, tiketdtl.NoETiket as NoETiket,tiketdtl.NoTiket as NoTiket, tiketdtl.GoDate as DateGo, tiketdtl.GoTrip, trip.TripName as GoTrip,tiketdtl.GoRuteID, rute.RuteName as RuteGo, tiketdtl.GoRate As GoRate, tiketdtl.GoExtra as GoExtraRate, tiketdtl.GoTranRate as GoTransportRate, tiketdtl.GoTransExtra as GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,  rute_1.RuteName as BackRute, tiketdtl.TripBack, trip_1.TripName as TripBack, tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, (tiketdtl.GoRate+ tiketdtl.GoExtra + tiketdtl.GoTranRate + tiketdtl.GoTransExtra + tiketdtl.BackRate + tiketdtl.BackExtra + tiketdtl.BackTransRate + tiketdtl.BackTransExtra)as total,tiketdtl.sisa FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) INNER JOIN rute AS rute_1 ON tiketdtl.BackRuteID = rute_1.RuteID) INNER JOIN trip AS trip_1 ON tiketdtl.TripBack = trip_1.TripID WHERE (tiketdtl.sisa<>0) and (tiketdtl.inv=0) and " & sql
        'sql = "SELECT 0 as ID, tiketdtl.NoETiket as NoETiket,tiketdtl.NoTiket as NoTiket, tiketdtl.GoDate as DateGo, tiketdtl.GoTrip, trip.TripName as GoTrip,tiketdtl.GoRuteID, rute.RuteName as RuteGo, tiketdtl.GoRate As GoRate, tiketdtl.GoExtra as GoExtraRate, tiketdtl.GoTranRate as GoTransportRate, tiketdtl.GoTransExtra as GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,  rute_1.RuteName as BackRute, tiketdtl.TripBack, trip_1.TripName as TripBack, tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, tiketdtl.Totaljual ,tiketdtl.sisa FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) INNER JOIN rute AS rute_1 ON tiketdtl.BackRuteID = rute_1.RuteID) INNER JOIN trip AS trip_1 ON tiketdtl.TripBack = trip_1.TripID WHERE  (tiketdtl.inv=0) and " & sql
        'sql = "SELECT 0 AS ID, tiketdtl.NoETiket AS NoETiket,tiketdtl.NoTiket AS NoTiket, tiketdtl.GoDate AS DateGo, tiketdtl.GoTrip, trip.TripName AS GoTrip,tiketdtl.GoRuteID, rute.RuteName AS RuteGo, tiketdtl.GoRate AS GoRate, tiketdtl.GoExtra AS GoExtraRate, tiketdtl.GoTranRate AS GoTransportRate, tiketdtl.GoTransExtra AS GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,   tiketdtl.TripBack,  tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, (tiketdtl.GoRate+ tiketdtl.GoExtra + tiketdtl.GoTranRate + tiketdtl.GoTransExtra + tiketdtl.BackRate + tiketdtl.BackExtra + tiketdtl.BackTransRate + tiketdtl.BackTransExtra)AS total,tiketdtl.sisa FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) )  WHERE (tiketdtl.sisa<>0) AND (tiketdtl.inv=0)and " & sql
        Dim sqlq = "SELECT 0 AS ID, tiketdtl.NoETiket AS NoETiket,tiketdtl.NoTiket AS NoTiket, tiketdtl.`guest`,tiketdtl.GoDate AS DateGo, trip.TripName AS GoTrip, rute.RuteName AS RuteGo, tiketdtl.TotalJual,tiketdtl.TotalCollect,tiketdtl.Komisi,tiketdtl.Komisi AS `Sisa` FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) )   WHERE  (tiketdtl.NoInv = ''OR ISNULL(tiketdtl.NoInv)) and (tiketdtl.status=1)  AND (tiketdtl.NoPay = ''OR ISNULL(tiketdtl.NoPay))  AND (tiketdtl.inv=0) AND  " & sql
        filltiket(sqlq)
        ''

    End Sub

    Private Sub cboAgent2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgent2.SelectedIndexChanged
        fillInv()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If cboInv.Text = "" Then
            MsgBox("Please Select No Invoice", vbInformation, "Select Invoice")
        Else
            frmPrintInv.NoInvPrint = cboInv.Text
            frmPrintInv.Show()
        End If
       
        ''
    End Sub

    Private Sub txtdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdate.ValueChanged
        txtdate.CustomFormat = "dd/MM/yyyy"
        txtdate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub txtdate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdate2.ValueChanged
        txtdate2.CustomFormat = "dd/MM/yyyy"
        txtdate2.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub lsData_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles lsData.CellMouseClick
        'If lsData.Rows(e.RowIndex).Cells(0).Value <> "" Then
        '    If Val(lsData.Rows(e.RowIndex).Cells(11).Value) = 0 Then
        '        txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(e.RowIndex).Cells(10).Value)
        '    Else
        '        txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(e.RowIndex).Cells(11).Value)
        '    End If
        'End If
    End Sub

    Private Sub lsData_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lsData.CellValueChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim i As Integer
        If lsData.Rows.Count() = 0 Then
            MsgBox("Please Filter Data Fist", vbInformation, "Error")
            CheckBox1.CheckState = CheckState.Unchecked
            Exit Sub
        End If
        If CheckBox1.CheckState = CheckState.Checked Then
            For i = 0 To lsData.Rows.Count() - 1 Step +1
                txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(i).Cells(10).Value)
                lsData.Rows(i).Cells(0).Value = True
                lsData.Rows(i.ToString).Cells(1).Value = 1
            Next
        Else
            For i = 0 To lsData.Rows.Count() - 1 Step +1
                'txttotal.Text = Val(txttotal.Text) - Val(lsData.Rows(i).Cells(10).Value)
                lsData.Rows(i).Cells(0).Value = False
                lsData.Rows(i.ToString).Cells(1).Value = 0
            Next
            txttotal.Text = 0

        End If
    End Sub

    Private Sub txttotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttotal.TextChanged
        txtttls.Text = CDbl(txttotal.Text).ToString("#,###")
    End Sub
End Class