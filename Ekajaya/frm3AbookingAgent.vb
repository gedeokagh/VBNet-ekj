Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frm3AbookingAgent

    Dim ttl As Integer
    Dim valida, validb As String
    Dim promoa, promob As String
    Dim SPa, SPb As String
    Dim surchargeg, surchargeb
    Dim dls As Integer = 0
    Sub filltransport()
        Call ConnectDatabase()
        Dim da, da2, da3 As MySqlDataAdapter
        Dim dt, dt2, dt3 As DataTable
        da = New MySqlDataAdapter("select ID,Nominal from transport", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        'da.Fill(dt)
        cbotrans1.DataSource = dt
        cbotrans1.DisplayMember = "Nominal"
        da2 = New MySqlDataAdapter("select ID,Nominal from transport", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        cbotrans2.DataSource = dt2
        cbotrans2.DisplayMember = "Nominal"
        da3 = New MySqlDataAdapter("select ID,Nominal from transport", conn)
        dt3 = New DataTable
        Dim dr3 As DataRow = dt2.NewRow
        da3.Fill(dt3)
        cbotrans3.DataSource = dt3
        cbotrans3.DisplayMember = "Nominal"
        Call DisconnectDatabase()
    End Sub

    Sub surcharge(ByVal days, ByVal mons, ByVal stat)


        If txtagentid.Text = "" Then
            MsgBox("Agent is empty, Please Select An Agent", vbInformation, "Error Booking")
            Exit Sub
        End If

        Dim strSql As String
        Dim x As Integer
        x = Len(mons.ToString)
        If Len(days.ToString) = 1 Then
            days = numx(days, 2)
        End If
        If Len(mons.ToString) = 1 Then
            mons = numx(mons, 2)
        End If
        strSql = "select ID from `surchargedtl` where day='" & days & "' and mon='" & mons & "' "
        Dim Comd = ChField(strSql)
        If Comd <> "" Then
            Dim SQLS As String = "select SureCharge from agentrate where agentid='" & txtagentid.Text & "' and DateStart<='" & Str2Date(txtgodate.Text) & "' and DateEnd>='" & Str2Date(txtgodate.Text) & "' "
            txtextrago.Text = ChField(SQLS)
        Else
            txtextrago.Text = 0
        End If


    End Sub


    Sub clrs()
        txtagentid.Text = ""
        txtgoextra.Text = ""
        txtextrago.Text = ""
        cbomrs.Text = ""
        txtName.Text = ""
        cbotipeID.Text = ""
        txtnoID.Text = ""
        cboCountry.Text = ""
        cboGst.Text = ""
        cboGorute.Text = ""
        cboGotrip.Text = ""
        cboGoArea.Text = ""
        txtgorate.Text = ""
        cbotrans1.Text = ""
        cbotrans2.Text = ""
        cbotrans1.Text = ""
        CxGoTrans.Checked = False
        CxBackTrans.Checked = False
        txtgoextra.Text = ""
        txtpickupgo.Text = ""

        dls = 0
        txtgodate.CustomFormat = " "
        txtgodate.Format = DateTimePickerFormat.Custom

        txtbackExtra.Text = ""

        cboBackArea.Text = ""
        cbotripback.Text = ""
        txtbackExtra.Text = ""
        txtPickupBack.Text = ""
        cbosorute.Text = ""
        cboruteback.Text = ""
        txtbackdate.CustomFormat = " "
        txtbackdate.Format = DateTimePickerFormat.Custom

        cbosoarea.Text = ""
        cbotripso.Text = ""
        txtsoextra.Text = ""
        txtPickupso.Text = ""
        CxSo.CheckState = CheckState.Unchecked
        GroupBox4.Enabled = False
        txtsodate.CustomFormat = " "
        txtsodate.Format = DateTimePickerFormat.Custom

        txtcollect.Text = "0"
        txtagent.Text = ""
        If LsData.RowCount > 0 Then
            LsData.Rows.Clear()
        End If


    End Sub

    Sub fillCountry()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select CountryID,CountryName from country", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("CountryID") = 0
        dr("CountryName") = ""
        dt.Rows.InsertAt(dr, 0)
        cboCountry.DataSource = dt
        cboCountry.DisplayMember = "CountryName"
        Call DisconnectDatabase()
    End Sub
    Sub fillRute()
        Call ConnectDatabase()
        'Dim da, da2 As MySqlDataAdapter
        Dim strSql As String = "Select RuteID,RuteName FROM Rute"
        Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
        Dim reader As MySqlDataReader = Comd.ExecuteReader
        While (reader.Read)
            cboGorute.Items.Add(reader("RuteID").ToString() & " - " & reader("RuteName").ToString())
            cbosorute.Items.Add(reader("RuteID").ToString() & " - " & reader("RuteName").ToString())
            cboruteback.Items.Add(reader("RuteID").ToString() & " - " & reader("RuteName").ToString())
        End While

        Call DisconnectDatabase()
    End Sub
    Sub filltrip()

        Call ConnectDatabase()
        Dim da, da2, da3 As MySqlDataAdapter
        Dim dt, dt2, dt3 As DataTable
        da = New MySqlDataAdapter("select TripID,TripName from trip", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("TripID") = 0
        dr("TripName") = ""
        dt.Rows.InsertAt(dr, 0)
        'da.Fill(dt)
        cboGotrip.DataSource = dt
        cboGotrip.DisplayMember = "tripName"
        da2 = New MySqlDataAdapter("select TripID,TripName from trip", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("TripID") = 0
        dr2("TripName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        cbotripback.DataSource = dt2
        cbotripback.DisplayMember = "tripName"
        da3 = New MySqlDataAdapter("select TripID,TripName from trip", conn)
        dt3 = New DataTable
        Dim dr3 As DataRow = dt3.NewRow
        da3.Fill(dt3)
        dr3("TripID") = 0
        dr3("TripName") = ""
        dt3.Rows.InsertAt(dr3, 0)
        cbotripso.DataSource = dt3
        cbotripso.DisplayMember = "tripName"
        Call DisconnectDatabase()
    End Sub
    Sub fillarea()
        Call ConnectDatabase()
        Dim da, da2, da3 As MySqlDataAdapter
        Dim dt, dt2, dt3 As DataTable
        da = New MySqlDataAdapter("select AreaID,AreaName from area", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("AreaID") = 0
        dr("AreaName") = ""
        dt.Rows.InsertAt(dr, 0)
        'da.Fill(dt)
        cboGoArea.DataSource = dt
        cboGoArea.DisplayMember = "AreaName"
        da2 = New MySqlDataAdapter("select AreaID,AreaName from area", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("AreaID") = 0
        dr2("AreaName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        cboBackArea.DataSource = dt2
        cboBackArea.DisplayMember = "AreaName"
        da3 = New MySqlDataAdapter("select AreaID,AreaName from area", conn)
        dt3 = New DataTable
        Dim dr3 As DataRow = dt3.NewRow
        da3.Fill(dt3)
        dr3("AreaID") = 0
        dr3("AreaName") = ""
        dt3.Rows.InsertAt(dr3, 0)
        cbosoarea.DataSource = dt3
        cbosoarea.DisplayMember = "AreaName"
        Call DisconnectDatabase()
    End Sub
    Sub BookNo()
        Dim x = cxField("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "/%'")
        If x = 0 Then
            txtNoBook.Text = "EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "/000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, (lenX - 6) + 1, 6) + 1)
            txtNoBook.Text = "EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "/" & numx(Lst, 6)
        End If

    End Sub
    Sub dlist()
        LsData.ColumnCount = 53
        LsData.Columns(0).Name = "No."
        LsData.Columns(1).Name = "AgentID"
        'LsData.Columns(1).Visible = False
        LsData.Columns(2).Name = "Tiket Type"
        LsData.Columns(3).Name = "AgentName"
        ' lsData.Columns(2).Visible = False
        LsData.Columns(4).Name = "NoTiket"
        LsData.Columns(5).Name = "Title"
        LsData.Columns(6).Name = "Name"
        LsData.Columns(7).Name = "IDType"
        LsData.Columns(8).Name = "No.ID"
        LsData.Columns(9).Name = "CountryID"
        'LsData.Columns(9).Visible = False
        LsData.Columns(10).Name = "CountryName"
        LsData.Columns(11).Name = "Guest"
        ''GO 
        LsData.Columns(12).Name = "GoRuteID"
        'LsData.Columns(12).Visible = False
        LsData.Columns(13).Name = "GoRute"
        LsData.Columns(14).Name = "GoDate"
        LsData.Columns(15).Name = "GoTripID"
        'LsData.Columns(15).Visible = False
        LsData.Columns(16).Name = "GoTrip"
        LsData.Columns(17).Name = "GoRate"
        LsData.Columns(18).Name = "GoExtraCharge"
        LsData.Columns(19).Name = "Transport"
        LsData.Columns(20).Name = "GoTransportRate"
        LsData.Columns(21).Name = "GoTransportExtraCharge"
        LsData.Columns(22).Name = "GoAreaID"
        'LsData.Columns(22).Visible = False
        LsData.Columns(23).Name = "PickupArea"
        LsData.Columns(24).Name = "PickupLocation"

        ''bACK
        LsData.Columns(25).Name = "BackRuteID"
        'LsData.Columns(25).Visible = False
        LsData.Columns(26).Name = "BackRute"
        LsData.Columns(27).Name = "BackDate"
        LsData.Columns(28).Name = "BackTripID"
        'LsData.Columns(28).Visible = False
        LsData.Columns(29).Name = "BackTrip"
        LsData.Columns(30).Name = "BackRate"
        LsData.Columns(31).Name = "BackExtraCharge"
        LsData.Columns(32).Name = "Transport"
        LsData.Columns(33).Name = "BackTransportRate"
        LsData.Columns(34).Name = "BackTransportExtraCharge"
        LsData.Columns(35).Name = "BackAreaID"
        'LsData.Columns(35).Visible = False
        LsData.Columns(36).Name = "PickupArea"
        LsData.Columns(37).Name = "PickupLocation"

        'STOP OVER
        LsData.Columns(38).Name = "S.Over RuteID"
        'LsData.Columns(38).Visible = False
        LsData.Columns(39).Name = "S.Over Rute"
        LsData.Columns(40).Name = "S.Over Date"
        LsData.Columns(41).Name = "S.Over TripID"
        'LsData.Columns(41).Visible = False
        LsData.Columns(42).Name = "S.Over Trip"
        LsData.Columns(43).Name = "Transport"
        LsData.Columns(44).Name = "SOTransportRate"
        LsData.Columns(45).Name = "SOTransportExtraCharge"
        LsData.Columns(46).Name = "S.Over AreaID"
        'LsData.Columns(46).Visible = False
        LsData.Columns(47).Name = "PickupArea"
        LsData.Columns(48).Name = "PickupLocation"


        LsData.Columns(49).Name = "Request Collect"
        LsData.Columns(50).Name = "Remark"
        LsData.Columns(51).Name = "Total"
        LsData.Columns(52).Name = "Tipe"
        'LsData.Columns(52).Visible = False
        LsData.ReadOnly = True
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
    End Sub

    Private Sub frmBooking3A_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboGst.Text = "1 - Adult"
        'fillagent()
        'txtagentid.Text = "OFFICE KUTA"
        filltrip()
        fillRute()
        fillarea()
        fillCountry()
        filltransport()

        dlist()
        txttgltrans.Text = Format(Now, "dd/MM/yyyy")
        clrs()

        GroupBox4.Enabled = False
        GroupBox5.Enabled = False
        GroupBox6.Enabled = False
        txtNoBook.ReadOnly = True
        txttgltrans.ReadOnly = True
        txtcollect.Text = 0
        txtagentid.Text = AgentID
        txtagent.Text = GetField("AgentName", "agent", "AgentID='" & AgentID & "'")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cboGorute_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGorute.SelectedIndexChanged
        If cboGorute.Text <> "" Then
            Dim rutesa As String = cboGorute.Text
            Dim rutesas = rutesa.Split(New Char() {" - "})

        End If
    End Sub

    Private Sub CxGoTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CxGoTrans.CheckedChanged
        If CxGoTrans.Checked = True Then

            GroupBox5.Enabled = True
        Else
            GroupBox5.Enabled = False
            cbotrans1.Text = 0
        End If
    End Sub

    Private Sub CxBackTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CxBackTrans.CheckedChanged
        If CxBackTrans.Checked = True Then

            GroupBox6.Enabled = True
        Else
            GroupBox6.Enabled = False
            cbotrans3.Text = 0
        End If
    End Sub

    Private Sub cboAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdd.Click
        Dim x As Boolean
        txttiket.Text = "-"
        If txttiket.Text <> "-" Then
            Dim AGN = GetField("AgentID", "ticket", "notiket='" & txttiket.Text & "'")
            If AGN = txtagentid.Text Then
            ElseIf AGN = "" Then
            Else
                MsgBox("This Ticket Number Already assign to other Agent!", vbInformation, "Ticket Error")
                Exit Sub
            End If
        End If
        'If txtstart.Text = "" Then
        '    MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
        '    txtstart.Focus()
        '    Exit Sub
        'ElseIf Len(txtstart.Text) < 11 Then
        '    MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
        '    txtstart.Focus()
        '    Exit Sub
        'End If
        If txtagentid.Text = "" Then
            MsgBox("Please Choose Agent!", vbInformation, "Ticket Error")
            Exit Sub
        End If

        If Trim(txtgodate.Text) = "" Then
            MsgBox("Please Fill Departure Date!", vbInformation, "Ticket Error")
            Exit Sub
        End If
        If CxOpen.CheckState = CheckState.Checked Then
            x = True
        End If
        Dim country, rute1, rute2, rute3, trip1, trip2, trip3, area1, area2, area3 As String
        If cboCountry.Text = "" Then
            country = ""
        Else
            country = cboCountry.SelectedItem("CountryID").ToString
        End If
        If cboGorute.Text = "" Then
            rute1 = ""
            MsgBox("Please Fill Departure Rute", vbInformation, "Departure Rute Empty")
            Exit Sub
        Else
            Dim rutesb As String = cboGorute.Text
            Dim rutesbs = rutesb.Split(New Char() {" - "})
            rute1 = rutesbs(0)
            'rute1 = cboGorute.SelectedItem("RuteID").ToString

        End If
        If cboGotrip.Text = "" Then
            trip1 = ""
            MsgBox("Please Fill Departure Trip", vbInformation, "Departure Trip Empty")
            Exit Sub
        Else
            trip1 = cboGotrip.SelectedItem("TripID").ToString
        End If

        If cboGoArea.Text = "" Then
            area1 = ""
        Else
            area1 = cboGoArea.SelectedItem("AreaID").ToString
        End If
        If x = True Then
            If cbotripback.Text = "" Then
                trip2 = ""
            Else
                trip2 = cbotripback.SelectedItem("TripID").ToString
            End If
            If cbotripso.Text = "" Then
                trip3 = ""
            Else
                trip3 = cbotripso.SelectedItem("TripID").ToString
            End If
            If cboruteback.Text = "" Then
                rute2 = ""
            Else
                Dim rutesX As String = cboruteback.Text
                Dim rutesXs = rutesX.Split(New Char() {" - "})
                rute2 = rutesXs(0)
                'rute2 = cboruteback.SelectedItem("RuteID").ToString
            End If
            If cbosorute.Text = "" Then
                rute3 = ""
            Else
                Dim ruteX As String = cbosorute.Text
                Dim ruteXs = ruteX.Split(New Char() {" - "})
                rute3 = ruteXs(0)
                'rute2 = cboruteback.SelectedItem("RuteID").ToString
            End If
        Else

            If cbotripback.Text = "" Then
                trip2 = ""
                MsgBox("Please Fill Arrival Trip", vbInformation, "Arrival Trip Empty")
                Exit Sub
            Else
                trip2 = cbotripback.SelectedItem("TripID").ToString
            End If

            If cbotripso.Text = "" Then
                trip3 = ""
            Else
                trip3 = cbotripso.SelectedItem("TripID").ToString
            End If
            If cboruteback.Text = "" Then
                rute2 = ""
                MsgBox("Please Fill Arrival Rute", vbInformation, "Arrival Rute Empty")
                Exit Sub
            Else
                Dim rutesxs As String = cboruteback.Text
                Dim rutesxss = rutesxs.Split(New Char() {" - "})
                rute2 = rutesxss(0)
                'rute2 = cboruteback.SelectedItem("RuteID").ToString
            End If
            If cbosorute.Text = "" Then
                rute3 = ""
            Else
                Dim ruteX As String = cbosorute.Text
                Dim ruteXs = ruteX.Split(New Char() {" - "})
                rute3 = ruteXs(0)
                'rute2 = cboruteback.SelectedItem("RuteID").ToString
            End If
            If txtbackdate.Text = " " Then
                MsgBox("Please Fill Arrival Date", vbInformation, "Arrival Date Empty")
                Exit Sub
            End If
            If txtsodate.Text = " " Then
                MsgBox("Please Fill Arrival Date", vbInformation, "Arrival Date Empty")
                Exit Sub
            End If


        End If
        If txtcollect.Text = "" Or (Not IsNumeric(txtcollect.Text)) Then
            txtcollect.Text = 0
        End If
        If cboBackArea.Text = "" Then
            area2 = ""
        Else
            area2 = cboBackArea.SelectedItem("AreaID").ToString
        End If
        If cbosoarea.Text = "" Then
            area3 = ""
        Else
            area3 = cbosoarea.SelectedItem("AreaID").ToString
        End If
        'If txtgorate.Text = "" Then
        '    MsgBox("Please Select Depart Rate", vbInformation, "Rate is Empty")
        '    Exit Sub
        'Else
        '    If x = False Then

        '        If txtbackdate.Text = " " Then
        '            MsgBox("Please Select Arrival Date", vbInformation, "Return Date is Empty")
        '            Exit Sub
        '        End If
        '    End If
        'End If
        If dls = 0 Then
            dls = 1
        Else
            dls = dls + 1
        End If
        Dim totals As Double = Val(txtgorate.Text) + Val(txtgoextra.Text) + Val(txtextrago.Text) + Val(cbotrans1.Text) + Val(txtbackExtra.Text) + Val(cbotrans2.Text) + Val(txtsoextra.Text) + Val(cbotrans3.Text)
        'lsData.Rows.Add(txtagentid.text(), txtagentid.Text, cbotipe.Text, txttiket.Text, cbomrs.Text, txtName.Text, cbotipeID.Text, txtnoID.Text, cboCountry.SelectedItem("CountryID").ToString(), cboCountry.Text, cboGst.Text, cboGorute.SelectedItem("RuteID").ToString(), cboGorute.Text, txtgodate.Text, cboGotrip.SelectedItem("TripID").ToString(), cboGotrip.Text, txtgorate.Text, txtextrago.Text, CxGoTrans.CheckState, txttransgorate.Text, txtgoextra.Text, cboGoArea.SelectedItem("AreaID").ToString(), cboGoArea.Text, txtpickupgo.Text, txtdrivego.Text, cboruteback.SelectedItem("RuteID").ToString(), cboruteback.Text, txtbackdate.Text, cbotripback.SelectedItem("TripID").ToString(), cbotripback.Text, txtbackrate.Text, txtexback.Text, CxBackTrans.CheckState, txttransbackrate.Text, txtbackExtra.Text, cboBackArea.SelectedItem("AreaID").ToString(), cboBackArea.Text, txtPickupBack.Text, txtbackDrive.Text, txtremark.Text, totals)
        LsData.Rows.Add(dls, txtagentid.Text, "3A - 3angle", txtagent.Text, txttiket.Text, cbomrs.Text, txtName.Text, cbotipeID.Text, txtnoID.Text, country, cboCountry.Text, cboGst.Text, rute1, cboGorute.Text, txtgodate.Text, trip1, cboGotrip.Text, txtgorate.Text, txtextrago.Text, CxGoTrans.CheckState, cbotrans1.Text, txtgoextra.Text, area1, cboGoArea.Text, txtpickupgo.Text, rute2, cboruteback.Text, txtbackdate.Text, trip2, cbotripback.Text, "0", "0", CxBackTrans.CheckState, cbotrans3.Text, txtbackExtra.Text, area2, cboBackArea.Text, txtPickupBack.Text, rute3, cbosorute.Text, txtsodate.Text, trip3, cbotripso.Text, CxSo.CheckState, cbotrans2.Text, txtsoextra.Text, area3, cbosoarea.Text, txtPickupso.Text, txtcollect.Text, txtremark.Text, totals, "3A")
        LsData.AllowUserToDeleteRows = True
        ttl = 0
        valida = ""
        validb = ""
        promoa = ""
        promob = ""
        surchargeg = ""
        surchargeb = ""
    End Sub

    Private Sub txtgodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgodate.ValueChanged
        txtgodate.Format = DateTimePickerFormat.Custom
        txtgodate.CustomFormat = "dd/MM/yyyy"
        If Trim(txtgodate.Text) = "" Then
            Exit Sub
        End If
        txtgorate.Text = ChField("select 3angle from agentrate where agentid='" & txtagentid.Text & "' and DateStart<='" & Str2Date(txtgodate.Text) & "' and DateEnd>='" & Str2Date(txtgodate.Text) & "' ")
        surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If LsData.RowCount = 0 Then
            MsgBox("Please Fill Booking Tiket", vbInformation, "Booking")
            Exit Sub
        End If
        ''
        BookNo()
        Dim I As Integer = LsData.RowCount
        Dim a, leni, b As Integer
        Dim strSql As String
        Dim strVal As String
        Dim trango, tranback, transso, Total
        Dim godt, bkdt, sodt, gdt, bdt, sdt, dtg, dtb, dts As String
        Total = 0
        leni = Len(I)
        ''Dim dtx, dty As Date
        For a = 0 To (I - 1)
            Total = Total + NZx(LsData.Rows(a).Cells(42).Value)
            If LsData.Rows(a).Cells(19).Value = 1 Then
                trango = 1
            Else
                trango = 0
            End If
            If LsData.Rows(a).Cells(33).Value = 1 Then
                tranback = 1
            Else
                tranback = 0
            End If
            If LsData.Rows(a).Cells(43).Value = 1 Then
                transso = 1
            Else
                transso = 0
            End If

            If LsData.Rows(a).Cells(14).Value = " " Then
                godt = ""
                gdt = ""
                dtg = ""
            Else
                godt = "GoDate='" & Str2Date(LsData.Rows(a).Cells(14).Value) & "', "
                gdt = " GoDate, "
                dtg = "'" & Str2Date(LsData.Rows(a).Cells(14).Value) & "',"
            End If
            If LsData.Rows(a).Cells(27).Value = " " Then
                bkdt = ""
                bdt = ""
                dtb = ""
            Else
                bkdt = " BackDate='" & Str2Date(LsData.Rows(a).Cells(27).Value) & "',"
                bdt = " BackDate, "
                dtb = "'" & Str2Date(LsData.Rows(a).Cells(27).Value) & "',"
            End If
            If LsData.Rows(a).Cells(40).Value = " " Then
                sodt = ""
                sdt = ""
                dts = ""
            Else
                sodt = " SODate='" & Str2Date(LsData.Rows(a).Cells(40).Value) & "',"
                sdt = " SODate, "
                dts = "'" & Str2Date(LsData.Rows(a).Cells(40).Value) & "',"
            End If

            Call ConnectDatabase()
            Dim cmd As MySqlCommand
            b = a + 1

            If LsData.Rows(a).Cells(4).Value = "-" Then
                'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(3).Value & "','" & LsData.Rows(a).Cells(0).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & NZx(LsData.Rows(a).Cells(16).Value) & "," & NZx(LsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(33).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & ",'" & LsData.Rows(a).Cells(37).Value & "','" & LsData.Rows(a).Cells(38).Value & "',1,'" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(5).Value & "'," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & ",'" & LsData.Rows(a).Cells(23).Value & "','" & LsData.Rows(a).Cells(24).Value & "','" & LsData.Rows(a).Cells(40).Value & "','" & LsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(28).Value & "'," & NZx(LsData.Rows(a).Cells(30).Value) & "," & Mid(LsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "'," & NZx(LsData.Rows(a).Cells(41).Value) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ")"
                strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra, GoTrans, GoTranRate, GoTransExtra, GoArea, GoPickUp, Remark, BackRuteID, " & bdt & "  TripBack, BackRate, QtyTipe, TotalJual, NoBook, Tipe, reqcollect, komisi, sisa, " & sdt & " sorute, sotrip, sotrans, soextra, soarea, sopickup, sotransp ) values ('" & txtNoBook.Text & "-" & b & "', '" & LsData.Rows(a).Cells(4).Value & "', '" & LsData.Rows(a).Cells(1).Value & "', " & NZx(LsData.Rows(a).Cells(15).Value) & ", " & NZx(LsData.Rows(a).Cells(17).Value) & ", " & NZx(LsData.Rows(a).Cells(31).Value) & ", " & tranback & ", " & NZx(LsData.Rows(a).Cells(33).Value) & ", " & NZx(LsData.Rows(a).Cells(34).Value) & ", " & NZx(LsData.Rows(a).Cells(35).Value) & ", @backpickup, 1, '" & LsData.Rows(a).Cells(5).Value & "' ,@name, " & NZx(LsData.Rows(a).Cells(9).Value) & ", '" & LsData.Rows(a).Cells(7).Value & "', '" & LsData.Rows(a).Cells(8).Value & "', " & NZx(LsData.Rows(a).Cells(12).Value) & ", " & dtg & "  " & NZx(LsData.Rows(a).Cells(18).Value) & ", " & trango & ", " & NZx(LsData.Rows(a).Cells(20).Value) & ", " & NZx(LsData.Rows(a).Cells(21).Value) & ", " & NZx(LsData.Rows(a).Cells(22).Value) & ", @gopickup, @remark, '" & NZx(LsData.Rows(a).Cells(25).Value) & "', " & dtb & " " & NZx(LsData.Rows(a).Cells(28).Value) & ", " & NZx(LsData.Rows(a).Cells(30).Value) & ", " & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & ", " & NZx(LsData.Rows(a).Cells(51).Value) & ", '" & txtNoBook.Text & "', '" & LsData.Rows(a).Cells(52).Value & "', " & NZx(LsData.Rows(a).Cells(40).Value) & ", " & (NZx(LsData.Rows(a).Cells(51).Value) * -1) & ", " & NZx(LsData.Rows(a).Cells(51).Value) & ", " & dts & " " & NZx(LsData.Rows(a).Cells(38).Value) & ", " & NZx(LsData.Rows(a).Cells(41).Value) & ", " & NZx(LsData.Rows(a).Cells(44).Value) & ", " & NZx(LsData.Rows(a).Cells(45).Value) & ", " & NZx(LsData.Rows(a).Cells(46).Value) & ", @sopickup, " & transso & ")"
                Call ConnectDatabase()
                cmd = New MySqlCommand(strVal, conn)
                cmd.Parameters.AddWithValue("@name", LsData.Rows(a).Cells(6).Value)
                cmd.Parameters.AddWithValue("@remark", LsData.Rows(a).Cells(50).Value)
                cmd.Parameters.AddWithValue("@backpickup", LsData.Rows(a).Cells(37).Value)
                cmd.Parameters.AddWithValue("@gopickup", LsData.Rows(a).Cells(24).Value)
                cmd.Parameters.AddWithValue("@sopickup", LsData.Rows(a).Cells(48).Value)
                cmd.ExecuteNonQuery()
                Call DisconnectDatabase()
            Else
                If cxField("NoTiket", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(3).Value & "'") = 1 Then
                    Dim gx = GetField("Total", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(3).Value & "'")
                    Dim NC = GetField("NoCollect", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(3).Value & "'")
                    Dim komisi = NZx(LsData.Rows(a).Cells(42).Value) - gx
                    'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,NoCollect,collect,TotalCollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(3).Value & "','" & LsData.Rows(a).Cells(0).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & NZx(LsData.Rows(a).Cells(16).Value) & "," & NZx(LsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(33).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & ",'" & LsData.Rows(a).Cells(37).Value & "','" & LsData.Rows(a).Cells(38).Value & "',1,'" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(5).Value & "'," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & ",'" & LsData.Rows(a).Cells(23).Value & "','" & LsData.Rows(a).Cells(24).Value & "','" & LsData.Rows(a).Cells(40).Value & "','" & LsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(28).Value & "'," & NZx(LsData.Rows(a).Cells(30).Value) & "," & Mid(LsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "'," & LsData.Rows(a).Cells(39).Value & ",'" & NC & "',1," & gx & "," & komisi & "," & NZx(LsData.Rows(a).Cells(41).Value) & ")"
                    'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,NoCollect,collect,TotalCollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(1).Value & "'," & NZx(LsData.Rows(a).Cells(15).Value) & "," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(32).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & "," & NZx(LsData.Rows(a).Cells(36).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(5).Value & "',@name," & NZx(LsData.Rows(a).Cells(9).Value) & ",'" & LsData.Rows(a).Cells(7).Value & "','" & LsData.Rows(a).Cells(8).Value & "'," & NZx(LsData.Rows(a).Cells(12).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(18).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & "," & NZx(LsData.Rows(a).Cells(22).Value) & ",@gopickup,@godrv,@remark,'" & NZx(LsData.Rows(a).Cells(26).Value) & "'," & dtb & "'" & NZx(LsData.Rows(a).Cells(29).Value) & "'," & NZx(LsData.Rows(a).Cells(31).Value) & "," & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ",'" & txtNoBook.Text & "','" & LsData.Rows(a).Cells(43).Value & "'," & LsData.Rows(a).Cells(40).Value & "c," & NZx(LsData.Rows(a).Cells(42).Value) & ")"
                    strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra, GoTrans, GoTranRate, GoTransExtra, GoArea, GoPickUp, Remark, BackRuteID, " & bdt & "  TripBack, BackRate, QtyTipe, TotalJual, NoBook, Tipe, reqcollect,NoCollect,collect,TotalCollect, komisi, sisa, " & sdt & " sorute, sotrip, sotrans, soextra, soarea, sopickup,sotransp ) values ('" & txtNoBook.Text & "-" & b & "', '" & LsData.Rows(a).Cells(4).Value & "', '" & LsData.Rows(a).Cells(1).Value & "', " & NZx(LsData.Rows(a).Cells(15).Value) & ", " & NZx(LsData.Rows(a).Cells(17).Value) & ", " & NZx(LsData.Rows(a).Cells(31).Value) & ", " & tranback & ", " & NZx(LsData.Rows(a).Cells(33).Value) & ", " & NZx(LsData.Rows(a).Cells(34).Value) & ", " & NZx(LsData.Rows(a).Cells(35).Value) & ", @backpickup, 1, '" & LsData.Rows(a).Cells(5).Value & "' ,@name, " & NZx(LsData.Rows(a).Cells(9).Value) & ", '" & LsData.Rows(a).Cells(7).Value & "', '" & LsData.Rows(a).Cells(8).Value & "', " & NZx(LsData.Rows(a).Cells(12).Value) & ", " & dtg & "  " & NZx(LsData.Rows(a).Cells(18).Value) & ", " & trango & ", " & NZx(LsData.Rows(a).Cells(20).Value) & ", " & NZx(LsData.Rows(a).Cells(21).Value) & ", " & NZx(LsData.Rows(a).Cells(22).Value) & ", @gopickup, @remark, '" & NZx(LsData.Rows(a).Cells(25).Value) & "', '" & dtb & "' " & NZx(LsData.Rows(a).Cells(28).Value) & "', " & NZx(LsData.Rows(a).Cells(30).Value) & ", " & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & ", " & NZx(LsData.Rows(a).Cells(51).Value) & ", '" & txtNoBook.Text & "', '" & LsData.Rows(a).Cells(52).Value & "', " & NZx(LsData.Rows(a).Cells(40).Value) & ",'" & NC & "',1," & gx & "," & komisi & ",  " & komisi & ", '" & dts & "', " & NZx(LsData.Rows(a).Cells(38).Value) & ", " & NZx(LsData.Rows(a).Cells(41).Value) & ", " & NZx(LsData.Rows(a).Cells(44).Value) & ", " & NZx(LsData.Rows(a).Cells(45).Value) & ", " & NZx(LsData.Rows(a).Cells(46).Value) & ", @sopickup, " & transso & ")"
                    Call ConnectDatabase()
                    cmd = New MySqlCommand(strVal, conn)
                    cmd.Parameters.AddWithValue("@name", LsData.Rows(a).Cells(6).Value)
                    cmd.Parameters.AddWithValue("@remark", LsData.Rows(a).Cells(50).Value)
                    cmd.Parameters.AddWithValue("@backpickup", LsData.Rows(a).Cells(37).Value)
                    cmd.Parameters.AddWithValue("@gopickup", LsData.Rows(a).Cells(24).Value)
                    cmd.Parameters.AddWithValue("@sopickup", LsData.Rows(a).Cells(48).Value)
                    cmd.ExecuteNonQuery()
                    Call DisconnectDatabase()
                Else
                    'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(3).Value & "','" & LsData.Rows(a).Cells(0).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & NZx(LsData.Rows(a).Cells(16).Value) & "," & NZx(LsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(33).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & ",'" & LsData.Rows(a).Cells(37).Value & "','" & LsData.Rows(a).Cells(38).Value & "',1,'" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(5).Value & "'," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & ",'" & LsData.Rows(a).Cells(23).Value & "','" & LsData.Rows(a).Cells(24).Value & "','" & LsData.Rows(a).Cells(40).Value & "','" & LsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(28).Value & "'," & NZx(LsData.Rows(a).Cells(30).Value) & "," & Mid(LsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "'," & LsData.Rows(a).Cells(39).Value & "," & NZx(LsData.Rows(a).Cells(41).Value) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ")"
                    strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,Qty,mrs,Guest,Coutry,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra, GoTrans, GoTranRate, GoTransExtra, GoArea, GoPickUp, Remark, BackRuteID, " & bdt & "  TripBack, BackRate, QtyTipe, TotalJual, NoBook, Tipe, reqcollect, komisi, sisa, " & sdt & " sorute, sotrip, sotrans, soextra, soarea, sopickup,sotransp ) values ('" & txtNoBook.Text & "-" & b & "', '" & LsData.Rows(a).Cells(4).Value & "', '" & LsData.Rows(a).Cells(1).Value & "', " & NZx(LsData.Rows(a).Cells(15).Value) & ", " & NZx(LsData.Rows(a).Cells(17).Value) & ", " & NZx(LsData.Rows(a).Cells(31).Value) & ", " & tranback & ", " & NZx(LsData.Rows(a).Cells(33).Value) & ", " & NZx(LsData.Rows(a).Cells(34).Value) & ", " & NZx(LsData.Rows(a).Cells(35).Value) & ", @backpickup, 1, '" & LsData.Rows(a).Cells(5).Value & "' ,@name, " & NZx(LsData.Rows(a).Cells(9).Value) & ", '" & LsData.Rows(a).Cells(7).Value & "', '" & LsData.Rows(a).Cells(8).Value & "', " & NZx(LsData.Rows(a).Cells(12).Value) & ", " & dtg & "  " & NZx(LsData.Rows(a).Cells(18).Value) & ", " & trango & ", " & NZx(LsData.Rows(a).Cells(20).Value) & ", " & NZx(LsData.Rows(a).Cells(21).Value) & ", " & NZx(LsData.Rows(a).Cells(22).Value) & ", @gopickup, @remark, '" & NZx(LsData.Rows(a).Cells(25).Value) & "', '" & dtb & "' " & NZx(LsData.Rows(a).Cells(28).Value) & "', " & NZx(LsData.Rows(a).Cells(30).Value) & ", " & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & ", " & NZx(LsData.Rows(a).Cells(51).Value) & ", '" & txtNoBook.Text & "', '" & LsData.Rows(a).Cells(52).Value & "', " & NZx(LsData.Rows(a).Cells(40).Value) & ", " & (NZx(LsData.Rows(a).Cells(42).Value) * -1) & ", " & NZx(LsData.Rows(a).Cells(42).Value) & ", '" & dts & "', " & NZx(LsData.Rows(a).Cells(38).Value) & ", " & NZx(LsData.Rows(a).Cells(41).Value) & ", " & NZx(LsData.Rows(a).Cells(44).Value) & ", " & NZx(LsData.Rows(a).Cells(45).Value) & ", " & NZx(LsData.Rows(a).Cells(46).Value) & ", @sopickup, " & transso & ")"
                    Call ConnectDatabase()
                    cmd = New MySqlCommand(strVal, conn)
                    cmd.Parameters.AddWithValue("@name", LsData.Rows(a).Cells(6).Value)
                    cmd.Parameters.AddWithValue("@remark", LsData.Rows(a).Cells(50).Value)
                    cmd.Parameters.AddWithValue("@backpickup", LsData.Rows(a).Cells(37).Value)
                    cmd.Parameters.AddWithValue("@gopickup", LsData.Rows(a).Cells(24).Value)
                    cmd.Parameters.AddWithValue("@sopickup", LsData.Rows(a).Cells(48).Value)
                    cmd.ExecuteNonQuery()
                    Call DisconnectDatabase()
                End If

            End If

            Call ConnectDatabase()

            If LsData.Rows(a).Cells(4).Value <> "-" Then
                strSql = "update ticket set AgentID='" & LsData.Rows(a).Cells(4).Value & "',stats=2 where NoTiket='" & LsData.Rows(a).Cells(4).Value & "' "
                cmd = New MySqlCommand(strSql, conn)
                cmd.ExecuteScalar()
            End If
            FillLog(usr, " Add New Booking", " No.Etiket=" & txtNoBook.Text & "-" & b & ", No.Tiket:" & LsData.Rows(a).Cells(4).Value & "", "", "")
            Call DisconnectDatabase()


        Next
        Try
            Call ConnectDatabase()
            Dim cmd As MySqlCommand

            strSql = "insert into booking(NoBooking,TglBooking, User,Total)value('" & txtNoBook.Text & "','" & Str2Date(txttgltrans.Text) & "','" & usr & "'," & Total & ")"

            cmd = New MySqlCommand(strSql, conn)
            cmd.ExecuteScalar()

            If (MsgBox("Booking No." & txtNoBook.Text & " Already Process" & vbCrLf & "Are you want to Add New Transaction?", vbYesNo, "Ticket Success")) = vbYes Then
                cboGst.Text = "1 - Adult"
                'fillagent()
                filltrip()
                fillRute()
                fillarea()
                fillCountry()
                BookNo()
                clrs()
                dlist()

                txttgltrans.Text = Format(Now, "dd/MM/yyyy")
                txtagentid.Focus()
                ' GroupBox4.Enabled = False
                txtNoBook.ReadOnly = True
                'txtttltiket.ReadOnly = True
                txttgltrans.ReadOnly = True

            Else
                Me.Close()
            End If

            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtgodate.CustomFormat = " "
        txtgodate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtbackdate.CustomFormat = " "
        txtbackdate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clrs()
    End Sub

   

    Private Sub LsGo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If cboGst.Text = "" Then
            MsgBox("Please Choose Age", vbInformation, "Error Booking")
            Exit Sub
        End If

    End Sub

    Private Sub LsGo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If cboGst.Text = "" Then
            MsgBox("Please Choose Age", vbInformation, "Error Booking")
            Exit Sub
        End If

    End Sub

    Private Sub cmdlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlist.Click
        If LsData.RowCount > 0 Then
            'If LsData.CurrentRow.Index Then
            LsData.Rows.RemoveAt(LsData.CurrentRow.Index)
            'End If
        Else
            MsgBox("Please select Data First", vbInformation, "Error Booking")
            Exit Sub
        End If
    End Sub

    Private Sub txtbackdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbackdate.ValueChanged
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = "dd/MM/yyyy"
        If Trim(txtbackdate.Text) = "" Then
            Exit Sub
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtsodate.CustomFormat = " "
        txtsodate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub txtsodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsodate.ValueChanged
        txtsodate.Format = DateTimePickerFormat.Custom
        txtsodate.CustomFormat = "dd/MM/yyyy"
        If Trim(txtsodate.Text) = "" Then
            Exit Sub
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CxSo.CheckedChanged
        If CxSo.Checked = True Then

            GroupBox4.Enabled = True
        Else
            GroupBox4.Enabled = False
            cbotrans2.Text = 0
        End If
    End Sub


    Private Sub txtagentid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtagentid.TextChanged
        If txtgodate.Text = " " Then
            txtgorate.Text = ChField("select 3angle from agentrate where agentid='" & txtagentid.Text & "' and DateStart<='" & Format(Now, "yyyy-MM-dd") & "' and DateEnd>='" & Format(Now, "yyyy-MM-dd") & "' ")
        Else
            txtgorate.Text = ChField("select 3angle from agentrate where agentid='" & txtagentid.Text & "' and DateStart<='" & Str2Date(txtgodate.Text) & "' and DateEnd>='" & Str2Date(txtgodate.Text) & "' ")
        End If
    End Sub


End Class