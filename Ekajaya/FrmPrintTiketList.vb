Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmPrintTiketList
    Dim strgo, strback As String
    Sub FILLPORT()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select PortID,PortName from port", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("PortID") = 0
        dr("PortName") = ""
        dt.Rows.InsertAt(dr, 0)
        cboPort.DataSource = dt
        cboPort.DisplayMember = "PortName"

        Call DisconnectDatabase()
    End Sub
    Sub SETFILTER()


        Dim andx As Boolean = False
        strgo = ""
        strback = ""
        If cboAgent.Text = "" Then
        Else
            strgo = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "'"
            strback = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "'"
            andx = True
        End If
        If Trim(txtgodate.Text) = "" Then
        Else
            If andx = False Then
                strgo = " ((tiketdtl.GoDate='" & Str2Date(txtgodate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtgodate.Text) & "')))"
                ' strgo = " (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
                strback = " (tiketdtl.BackDate='" & Str2Date(txtgodate.Text) & "')"
                andx = True
            Else
                strgo = strgo & " and ((tiketdtl.GoDate='" & Str2Date(txtgodate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtgodate.Text) & "')))"
                'strgo = strgo & " and (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
                strback = strback & " and (tiketdtl.BackDate='" & Str2Date(txtgodate.Text) & "')"
            End If
        End If

        If cboPort.Text = "" Then
        Else
            Dim ctr = cboPort.SelectedItem("PortID")
            If andx = False Then
                strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                strback = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")"
                andx = True
            Else
                strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                strback = strback & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
            End If
        End If
        
        If cboAgent.Text = "" Then
        Else
            If andx = False Then
                strgo = " (tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "')"
                'strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = " (tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "')"
                andx = True
            Else
                strgo = strgo & " and (tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "')"
                'strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = strback & " and  (tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "')"
            End If
        End If
        
    End Sub
    Sub filltiket(ByVal criteria As String)
        LsData.Columns.Clear()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        Dim sql = "SELECT 0 as ID,tiketdtl.NoETiket, tiketdtl.NoTiket, IF( tiketdtl.Gotrip = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip,IF(tiketdtl.TIPE='OW','One-Way','Return') as Tiket, agent.AgentName,  tiketdtl.mrs, tiketdtl.Guest, `tiketdtl`.`GoDate` AS DepartDate,IF(tiketdtl.BackDate='','',tiketdtl.Backdate) AS ReturnDate, IF( tiketdtl.GoRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS DepartRute, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS ReturnRute FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) WHERE " & criteria & " AND tiketdtl.STATUS=1"
        ''da = New MySqlDataAdapter("SELECT 0 as ID, tiketdtl.NoETiket as NoETiket, tiketdtl.NoTiket as NoTiket, tiketdtl.GoDate as DateGo, tiketdtl.GoTrip, trip.TripName as GoTrip,tiketdtl.GoRuteID, rute.RuteName as RuteGo, tiketdtl.GoRate As GoRate, tiketdtl.GoExtra as GoExtraRate, tiketdtl.GoTranRate as GoTransportRate, tiketdtl.GoTransExtra as GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,  rute_1.RuteName as BackRute, tiketdtl.TripBack, trip_1.TripName as TripBack, tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, (tiketdtl.GoRate+ tiketdtl.GoExtra + tiketdtl.GoTranRate + tiketdtl.GoTransExtra + tiketdtl.BackRate + tiketdtl.BackExtra + tiketdtl.BackTransRate + tiketdtl.BackTransExtra)as total FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) INNER JOIN rute AS rute_1 ON tiketdtl.BackRuteID = rute_1.RuteID) INNER JOIN trip AS trip_1 ON tiketdtl.TripBack = trip_1.TripID WHERE " & criteria & "", conn)
        da = New MySqlDataAdapter(sql, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = ""
        chk.Name = "ID"

        LsData.Columns.Insert(0, chk)
        LsData.Columns(0).ReadOnly = False
        'LsData.Columns(19).ReadOnly = True
        LsData.Columns(1).ReadOnly = True
        LsData.Columns(1).Visible = False
        Call DisconnectDatabase()
    End Sub
    Sub fillagent()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID,AgentName from agent where status=1", conn)
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
    Sub filltrip()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select TripID,TripName from trip", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("TripID") = 0
        dr("TripName") = ""
        dt.Rows.InsertAt(dr, 0)
        cbotrip.DataSource = dt
        cbotrip.DisplayMember = "TripName"

        Call DisconnectDatabase()
    End Sub
    Private Sub FrmPrintTiketList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        filltrip()
        fillagent()
        FILLPORT()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        Dim x As Integer = 0
        Dim filt As String = ""
        If cboAgent.Text = "" Then

        Else
            x = x + 1
            filt = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "'"
        End If
        If cbotrip.Text = "" Then

        Else
            x = x + 1
            filt = " tiketdtl.goTrip='" & cbotrip.SelectedItem("TripID").ToString & "'"
        End If
        If cbotipe.Text = "" Then

        Else
            x = x + 1
            If filt = "" Then
                filt = " tiketdtl.Tipe='" & Mid(cbotipe.Text, 1, 2) & "'"
            Else
                filt = filt & " and tiketdtl.Tipe='" & Mid(cbotipe.Text, 1, 2) & "'"
            End If

        End If

        If txtgodate.Text = "" Then
            MsgBox("Please Fill Depart Date", vbInformation, "Date Is Empty")
            Exit Sub
        Else
            x = x + 1
            If filt = "" Then
                filt = " (tiketdtl.godate='" & Str2Date(txtgodate.Text) & "') "
            Else
                filt = filt & " and tiketdtl.godate='" & Str2Date(txtgodate.Text) & "'"
            End If

        End If
        If x = 0 Then
            If txtStart.Text = "" Then
                MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
                txtStart.Focus()
                Exit Sub
            ElseIf Len(txtStart.Text) < 11 Then
                MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
                txtStart.Focus()
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
            If Mid(txtStart.Text, 1, 4) <> Mid(txtend.Text, 1, 4) Then
                MsgBox("Start Tiket Not same with End Tiket, Please Check Tiket Number!!", vbInformation, "Start Tiket Empty")
                txtStart.Focus()
                Exit Sub
            End If
            If filt = "" Then
                filt = " tiketdtl.NoTiket Between '" & txtStart.Text & "' and '" & txtend.Text & "'"
            Else
                filt = filt & " and tiketdtl.NoTiket Between '" & txtStart.Text & "' and '" & txtend.Text & "'"
            End If
        Else
            If txtStart.Text <> "" Then
                If Len(txtStart.Text) < 11 Then
                    MsgBox("Please Check Start Tiket", vbInformation, "Start Tiket Empty")
                    txtStart.Focus()
                    Exit Sub
                End If
            End If
            If txtend.Text <> "" Then
                If Len(txtend.Text) < 11 Then
                    MsgBox("Please Check End Tiket", vbInformation, "End Tiket Empty")
                    txtend.Focus()
                    Exit Sub
                End If
            End If
            If Mid(txtStart.Text, 1, 4) <> Mid(txtend.Text, 1, 4) Then
                MsgBox("Start Tiket Not same with End Tiket, Please Check Tiket Number!!", vbInformation, "Start Tiket Empty")
                txtStart.Focus()
                Exit Sub
            End If
            If txtStart.Text = "" Then
            Else
                filt = filt & " and tiketdtl.NoTiket Between '" & txtStart.Text & "' and '" & txtend.Text & "'"
            End If


        End If
        If cboPort.Text = "" Then
        Else
            Dim ctr = cboPort.SelectedItem("PortID")
            'If andx = False Then
            '    strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
            '    'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
            '    strback = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")"
            '    andx = True
            'Else
            '    strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
            '    'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
            '    strback = strback & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
            'End If
            If filt = "" Then
                filt = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))  "
            Else
                filt = filt & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
            End If
        End If
        filltiket(filt)
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        If LsData.Rows(e.RowIndex).Cells(1).Value = 0 Then
            LsData.Rows(e.RowIndex.ToString).Cells(1).Value = 1
            Exit Sub
        Else
            LsData.Rows(e.RowIndex.ToString).Cells(1).Value = 0
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim I As Integer = LsData.RowCount
        Dim a As Integer
        Dim fil As String = ""
        For a = 0 To (I - 1)
            If LsData.Rows(a).Cells(1).Value = 1 Then
                If fil = "" Then
                    fil = " NoETiket='" & LsData.Rows(a).Cells(2).Value & "'"
                Else
                    fil = fil & " or NoETiket='" & LsData.Rows(a).Cells(2).Value & "'"
                End If
            End If
        Next
        If fil = "" Then
            Exit Sub
        End If
        'MsgBox("Print Tiket is on Proggress", vbInformation, "Print Tiket")
        frmTiketPrint.where = fil
        frmTiketPrint.Show()
    End Sub

End Class
