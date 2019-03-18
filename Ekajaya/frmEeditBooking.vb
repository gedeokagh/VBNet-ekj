Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmEeditBooking
    Dim ttl As Integer
    Dim valida, validb As String
    Dim promoa, promob As String
    Dim SPa, SPb As String
    Dim surchargeg, surchargeb
    Dim dls As Integer = 0
    Sub valid(ByVal dates As String, ByVal rutes As Integer, ByVal stx As String)
        If stx = "Go" Then
            If txtgodate.Text = "" Then
                MsgBox("Depart Date is empty, Please fill Depart Date", vbInformation, "Error Booking")
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select RateID from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & rutes & " and Enddate>='" & Str2Date(dates) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    valida = reader("RateID").ToString()
                End While
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        ElseIf stx = "Back" Then
            If txtbackdate.Text = "" Then
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select RateID from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & rutes & " and Enddate>='" & Str2Date(dates) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    validb = reader("RateID").ToString()
                End While
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        End If
    End Sub
    Sub surcharge(ByVal days, ByVal mons, ByVal stat)
        If stat = "Go" Then
            If txtgodate.Text = "" Then
                MsgBox("Depart Date is empty, Please fill Depart Date", vbInformation, "Error Booking")
                Exit Sub
            End If
            If cboGorute.Text = "" Then
                MsgBox("Depart Rute is empty, Please fill Depart Rute", vbInformation, "Error Booking")
                Exit Sub
            End If
            If txtagentid.Text = "" Then
                MsgBox("Agent is empty, Please Select An Agent", vbInformation, "Error Booking")
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

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
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    surchargeg = reader("ID").ToString()
                End While
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        ElseIf stat = "Back" Then
            If txtbackdate.Text = "" Then
                Exit Sub
            End If
            If cboGorute.Text = "" Then
                MsgBox("Return Rute is empty, Please fill Depart Rute", vbInformation, "Error Booking")
                Exit Sub
            End If
            If txtagentid.Text = "" Then
                MsgBox("Agent is empty, Please Select An Agent", vbInformation, "Error Booking")
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

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
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    surchargeb = reader("ID").ToString()
                End While
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try

        End If
    End Sub
    Sub promo(ByVal days, ByVal Rutes, ByVal stx)
        If stx = "Go" Then
            If txtgodate.Text = "" Then
                MsgBox("Depart Date is empty, Please fill Depart Date", vbInformation, "Error Booking")
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select Nopromo from `promo` where  RuteID=" & Rutes & " and StartDate<='" & Str2Date(days) & "' and EndDate>='" & Str2Date(days) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    promoa = reader("Nopromo").ToString

                End While
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        ElseIf stx = "Back" Then
            If txtbackdate.Text = "" Then
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select Nopromo from `promo` where  RuteID=" & Rutes & " and StartDate<='" & Str2Date(days) & "' and EndDate>='" & Str2Date(days) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    promob = reader("Nopromo").ToString
                End While
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        End If

    End Sub
    Sub spevent(ByVal days, ByVal agn, ByVal stx)
        If stx = "Go" Then
            If txtgodate.Text = "" Then
                MsgBox("Depart Date is empty, Please fill Depart Date", vbInformation, "Error Booking")
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select nOEVENT from `special` where  AgentID='" & agn & "' and StartDate<='" & Str2Date(days) & "' and EndDate>='" & Str2Date(days) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    SPa = reader("Noevent").ToString

                End While
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        ElseIf stx = "Back" Then
            If txtbackdate.Text = "" Then
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select nOEVENT from `special` where  AgentID='" & agn & "' and StartDate<='" & Str2Date(days) & "' and EndDate>='" & Str2Date(days) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    SPb = reader("Noevent").ToString
                End While
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        End If

    End Sub
    Sub fillpublishrate(ByVal RuteID, ByVal da)
        Dim name As String = "Publish"

        Dim sur = 0

        If da = "Go" Then
            If LsGo.RowCount <> 0 Then
                LsGo.Rows.Clear()
            End If
            LsGo.ColumnCount = 6
            LsGo.Columns(0).Name = "Name"
            LsGo.Columns(1).Name = "Adult"
            LsGo.Columns(2).Name = "Child"
            LsGo.Columns(3).Name = "Infant"
            LsGo.Columns(4).Name = "FOC"
            LsGo.Columns(5).Name = "SurCharge"
            Dim adl = GetField("Adult", "rute", "RuteID=" & RuteID)
            Dim chd = GetField("Child", "rute", "RuteID=" & RuteID)
            Dim Inf = GetField("Inf", "rute", "RuteID=" & RuteID)
            Dim foc = GetField("FOC", "rute", "RuteID=" & RuteID)
            LsGo.Rows.Add(name, adl, chd, Inf, foc, sur)
            If txtagentid.Text <> "" Then
                valid(Format(Now, "dd/MM/yyyy"), RuteID, "Go")
                If valida <> "" Then
                    name = "Contract"
                    adl = GetField("Adult", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    chd = GetField("Child", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    Inf = GetField("Inf", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    foc = GetField("FOC", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    LsGo.Rows.Add(name, adl, chd, Inf, foc, sur)
                End If
            End If
        End If
        If da = "Back" Then
            If LsBack.RowCount <> 0 Then
                LsBack.Rows.Clear()
            End If
            LsBack.ColumnCount = 6
            LsBack.Columns(0).Name = "Name"
            LsBack.Columns(1).Name = "Adult"
            LsBack.Columns(2).Name = "Child"
            LsBack.Columns(3).Name = "Infant"
            LsBack.Columns(4).Name = "FOC"
            LsBack.Columns(5).Name = "SurCharge"

            Dim adl = GetField("Adult", "rute", "RuteID=" & RuteID)
            Dim chd = GetField("Child", "rute", "RuteID=" & RuteID)
            Dim Inf = GetField("Inf", "rute", "RuteID=" & RuteID)
            Dim foc = GetField("FOC", "rute", "RuteID=" & RuteID)
            LsBack.Rows.Add(name, adl, chd, Inf, foc, sur)
            If txtagentid.Text <> "" Then
                valid(Format(Now, "dd/MM/yyyy"), RuteID, "Back")
                If valida <> "" Then
                    name = "Contract"
                    adl = GetField("Adult", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    chd = GetField("Child", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    Inf = GetField("Inf", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    foc = GetField("FOC", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    LsBack.Rows.Add(name, adl, chd, Inf, foc, sur)
                End If
            End If
        End If
    End Sub
    Sub cls()
        LsBack.Rows.Clear()
        LsData.Rows.Clear()
        LsGo.Rows.Clear()
        txtNoBook.Focus()

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
            cboruteback.Items.Add(reader("RuteID").ToString() & " - " & reader("RuteName").ToString())
        End While
        'Dim dt, dt2 As DataTable
        'da = New MySqlDataAdapter("select RuteID,RuteName from rute", conn)
        'dt = New DataTable
        'Dim dr As DataRow = dt.NewRow
        'da.Fill(dt)
        'dr("RuteID") = 0
        'dr("RuteName") = ""
        'dt.Rows.InsertAt(dr, 0)
        ''da.Fill(dt)
        'cboGorute.DataSource = dt
        'cboGorute.DisplayMember = "RuteName"
        'da2 = New MySqlDataAdapter("select RuteID,RuteName from rute", conn)
        'dt2 = New DataTable
        'Dim dr2 As DataRow = dt2.NewRow
        'da2.Fill(dt2)
        'dr2("RuteID") = 0
        'dr2("RuteName") = ""
        'dt2.Rows.InsertAt(dr2, 0)
        'cboruteback.DataSource = dt2
        'cboruteback.DisplayMember = "RuteName"
        Call DisconnectDatabase()
    End Sub
    Sub filltrip()

        Call ConnectDatabase()
        Dim da, da2 As MySqlDataAdapter
        Dim dt, dt2 As DataTable
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
        Call DisconnectDatabase()
    End Sub
    Sub fillarea()
        Call ConnectDatabase()
        Dim da, da2 As MySqlDataAdapter
        Dim dt, dt2 As DataTable
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
        Call DisconnectDatabase()
    End Sub
    Private Sub frmEeditBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillarea()
        fillCountry()
        fillRute()
        filltrip()
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False
        GroupBox5.Enabled = False
        GroupBox6.Enabled = False
        txtgodate.CustomFormat = " "
        txtgodate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = " "
        txtbackdate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub txtNoBook_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtNoBook.PreviewKeyDown
        If e.KeyValue = Keys.Enter Then
            fillbook(txtNoBook.Text)
            
        End If
    End Sub
    Sub colorx()
        Dim i As Integer

        For i = 0 To LsData.Rows.Count() - 1 Step +1


            Dim val = Trim(LsData.Rows(i).Cells(33).Value)
            'val = LsData.Rows(i).Cells(44).ToString

            If val = 0 Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red

            End If

        Next
    End Sub
    Sub fillbook(ByVal str As String)

        Dim strqry As String
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        strqry = "SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(noetiket,'-',2),'-',-1)AS No, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `agent`.`AgentName`, `tiketdtl`.`mrs`, `tiketdtl`.`Guest`, `tiketdtl`.`GuestID`, `tiketdtl`.`GuestIDNO`, `tiketdtl`.`Country`, IF(`tiketdtl`.`Country`='','',(SELECT country.CountryName FROM country WHERE country.CountryID=tiketdtl.Country)) AS CountryName, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe=3,tiketdtl.qty,0)as Infant,if(`tiketdtl`.QtyTipe=4,tiketdtl.qty,0)as foc,`tiketdtl`.`GoRuteID`, `rute`.`RuteName` AS DepartRute , `tiketdtl`.`GoDate` AS DepartDate, `tiketdtl`.`GoTrip`, `trip`.`TripName` , `tiketdtl`.`GoRate` , `tiketdtl`.`GoExtra`, IF(`tiketdtl`.`GoTrans`=0,'No','Yes') AS Transport, `tiketdtl`.`GoTranRate`, `tiketdtl`.`GoTransExtra`, `tiketdtl`.`GoArea`, IF(`tiketdtl`.`GoArea`=0,'',(SELECT area.AreaName FROM AREA WHERE area.`AreaID`=tiketdtl.GoArea)) AS DepartPickupArea, `tiketdtl`.`GoPickUp` AS PickupLocation, `tiketdtl`.`GoDriver`, `tiketdtl`.`BackRuteID`, IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS ArrivalRute, tiketdtl.BackDate AS ArrivalDate, tiketdtl.`TripBack`, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS ArrivalTrip, `tiketdtl`.`BackRate`, `tiketdtl`.`BackExtra`, IF(`tiketdtl`.`BackTrans`=0,'No','Yes') AS Transport2, `tiketdtl`.`BackTransRate`, `tiketdtl`.`BackTransExtra`, `tiketdtl`.`BackArea`, IF(`tiketdtl`.`BackArea`=0,'',(SELECT area.AreaName FROM AREA WHERE area.`AreaID`=tiketdtl.GoArea)) AS ArrivalPickupArea, `tiketdtl`.`BackPickup` AS DepartPickupLocation, `tiketdtl`.`BackDriver`, `tiketdtl`.`Remark`, `tiketdtl`.`TotalJual`, `tiketdtl`.`AgentID`, `tiketdtl`.`Tipe`, `tiketdtl`.`ReqCollect`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`NoCollect`, `tiketdtl`.`NoInv`, `tiketdtl`.`NoPay`, `tiketdtl`.`Komisi`, `tiketdtl`.`Sisa`, `tiketdtl`.`status`,'no' as adel FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE noBook='" & str & "' ORDER BY cAST(No AS SIGNED)"
        'da = New MySqlDataAdapter(strqry, conn)
        'dt = New DataTable
        'da.Fill(dt)
        'LsData.DataSource = dt
        Dim Comd As MySqlCommand = New MySqlCommand(strqry, conn)
        Dim reader As MySqlDataReader = Comd.ExecuteReader
        LsData.ColumnCount = 55
        LsData.Columns(0).Name = "No."
        LsData.Columns(1).Name = "No.Etiket"
        'lsData.Columns(0).Visible = False
        LsData.Columns(2).Name = "No.Tiket"
        LsData.Columns(3).Name = "Agent Name"
        ' lsData.Columns(2).Visible = False
        LsData.Columns(4).Name = "Title"
        LsData.Columns(5).Name = "Name"
        
        LsData.Columns(6).Name = "IDType"
        LsData.Columns(7).Name = "No.ID"
        LsData.Columns(8).Name = "CountryID"
        'LsData.Columns(8).Visible = False
        LsData.Columns(9).Name = "CountryName"
        LsData.Columns(10).Name = "Adult"
        LsData.Columns(11).Name = "Child"
        LsData.Columns(12).Name = "Infant"
        LsData.Columns(13).Name = "FOC"
        LsData.Columns(14).Name = "GoRuteID"
        'LsData.Columns(14).Visible = False
        LsData.Columns(15).Name = "Depart Rute"
        LsData.Columns(16).Name = "Depart Date"
        LsData.Columns(17).Name = "GoTripID"
        'LsData.Columns(17).Visible = False
        LsData.Columns(18).Name = "Depart Trip"
        LsData.Columns(19).Name = "Rate"
        LsData.Columns(20).Name = "GoExtraCharge"
        LsData.Columns(21).Name = "Transport"
        LsData.Columns(22).Name = "GoTransportRate"
        LsData.Columns(23).Name = "GoTransportExtraCharge"
        LsData.Columns(24).Name = "GoAreaID"
        'LsData.Columns(24).Visible = False
        LsData.Columns(25).Name = "PickupArea"
        LsData.Columns(26).Name = "PickupLocation"
        LsData.Columns(27).Name = "GoDrivers"
        LsData.Columns(28).Name = "BackRuteID"
        'LsData.Columns(28).Visible = False
        LsData.Columns(29).Name = "BackRute"
        LsData.Columns(30).Name = "BackDate"
        LsData.Columns(31).Name = "BackTripID"
        ' LsData.Columns(31).Visible = False
        LsData.Columns(32).Name = "BackTrip"
        LsData.Columns(33).Name = "BackRate"
        LsData.Columns(34).Name = "BackExtraCharge"
        LsData.Columns(35).Name = "Transport"
        LsData.Columns(36).Name = "BackTransportRate"
        LsData.Columns(37).Name = "BackTransportExtraCharge"
        LsData.Columns(38).Name = "BackAreaID"
        'LsData.Columns(38).Visible = False
        LsData.Columns(39).Name = "PickupArea"
        LsData.Columns(40).Name = "PickupLocation"
        LsData.Columns(41).Name = "BackDrivers"
        LsData.Columns(42).Name = "Request Collect"
        LsData.Columns(43).Name = "Remark"
        LsData.Columns(44).Name = "Total"
        LsData.Columns(45).Name = "AgentID"
        LsData.Columns(46).Name = "Tipe"
        LsData.Columns(47).Name = "TotalCollect"
        LsData.Columns(48).Name = "NoCollect"
        LsData.Columns(49).Name = "NoInv"
        LsData.Columns(50).Name = "NoPay"
        LsData.Columns(51).Name = "Komisi"
        LsData.Columns(52).Name = "Sisa"
        LsData.Columns(53).Name = "status"
        LsData.Columns(54).Name = "Delete"
        'LsData.Columns.Add("NO", "NoEtiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket", "NoTiket")
        While (reader.Read)
            'GetField = reader(strField).ToString()
            LsData.Rows.Add(reader("NO").ToString(), reader("NoETiket").ToString(), reader("NoTiket").ToString(), reader("AgentName").ToString(), reader("mrs").ToString(), reader("Guest").ToString(), reader("GuestID").ToString(), reader("GuestIDNO").ToString(), reader("Country").ToString(), reader("CountryName").ToString(), reader("Adult").ToString(), reader("Child").ToString(), reader("Infant").ToString(), reader("FOC").ToString(), reader("GoRuteID").ToString(), reader("DepartRute").ToString(), reader("DepartDate").ToString(), reader("GoTrip").ToString(), reader("TripName").ToString(), reader("GoRate").ToString(), reader("GoExtra").ToString(), reader("Transport").ToString(), reader("GoTranRate").ToString(), reader("GoTransExtra").ToString(), reader("GoArea").ToString(), reader("DepartPickupArea").ToString(), reader("PickupLocation").ToString(), reader("GoDriver").ToString(), reader("BackRuteID").ToString(), reader("ArrivalRute").ToString(), reader("ArrivalDate").ToString(), reader("TripBack").ToString(), reader("ArrivalTrip").ToString(), reader("BackRate").ToString(), reader("BackExtra").ToString(), reader("Transport2").ToString(), reader("BackTransRate").ToString(), reader("BackTransExtra").ToString(), reader("BackArea").ToString(), reader("ArrivalPickupArea").ToString(), reader("DepartPickupLocation").ToString(), reader("BackDriver").ToString(), reader("ReqCollect").ToString(), reader("Remark").ToString(), reader("TotalJual").ToString(), reader("AgentID").ToString(), reader("Tipe").ToString(), reader("TotalCollect").ToString(), reader("NoCollect").ToString(), reader("NoInv").ToString(), reader("NoPay").ToString(), reader("Komisi").ToString(), reader("Sisa").ToString(), reader("status").ToString(), reader("ADEL").ToString())

        End While
        DisconnectDatabase()
        'Dim DIRS As ListViewItemMouseHoverEventArgs
        'LsData.Sort(LsData.Columns("NO"), System.ComponentModel.ListSortDirection.Ascending)
        If LsData.Rows.Count = 0 Then
            Exit Sub
        End If
        txttgltrans.Text = GetField("tglbooking", "booking", "Nobooking='" & txtNoBook.Text & "'")
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        TXTNOE.Text = LsData.Rows(LsData.Rows.Count - 1).Cells(0).Value
        txtagentid.Text = LsData.Rows(LsData.Rows.Count - 1).Cells(45).Value
        txtagent.Text = LsData.Rows(LsData.Rows.Count - 1).Cells(3).Value
        cboGst.Text = "1 - Adult"
        'fillagent()
        'txtagentid.Text = "OFFICE KUTA"
        filltrip()
        fillRute()
        fillarea()
        fillCountry()

        txttgltrans.Text = Format(Now, "dd/MM/yyyy")
        txtagentid.Focus()
        GroupBox4.Enabled = False
        GroupBox6.Enabled = False
        GroupBox5.Enabled = False
        txtNoBook.ReadOnly = True
        txttgltrans.ReadOnly = True
        txtcollect.Text = 0
    End Sub



    Private Sub cboGorute_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGorute.SelectedIndexChanged
        If cboGorute.Text <> "" Then
            Dim rutesa As String = cboGorute.Text
            Dim rutesas = rutesa.Split(New Char() {" - "})
            fillpublishrate(rutesas(0), "Go")
        End If
    End Sub

    Private Sub txtgodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgodate.ValueChanged
        Dim rutes As String = cboGorute.Text
        Dim rutesl = rutes.Split(New Char() {" - "})

        If cboGorute.Text <> "" Then

            fillpublishrate(rutesl(0), "Go")
        End If
        txtgodate.Format = DateTimePickerFormat.Custom
        txtgodate.CustomFormat = "dd/MM/yyyy"
        If Trim(txtgodate.Text) = "" Then
            Exit Sub
        End If
        surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
        If surchargeg <> "" Then
            valid(txtgodate.Text, rutesl(0), "Go")
            If valida <> "" Then
                Name = "SurCharge"
                Dim adl = GetField("Adult", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                Dim chd = GetField("Child", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                Dim Inf = GetField("Inf", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                Dim foc = GetField("FOC", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                Dim sur = GetField("Surcharge", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                LsGo.Rows.Add(Name, adl, chd, Inf, foc, sur)
            End If
        End If
        'promo(txtgodate.Text, cboGorute.SelectedItem("RuteID"), "Go")
        promo(txtgodate.Text, rutesl(0), "Go")
        If promoa <> "" Then
            Name = "promo"
            Dim adla = GetField("Adl", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
            Dim chda = GetField("Chd", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
            Dim Infa = GetField("Infant", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
            Dim foca = GetField("FOC", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
            Dim sura = 0
            LsGo.Rows.Add(Name, adla, chda, Infa, foca, sura)
        End If
        spevent(txtgodate.Text, txtagentid.Text, "Go")
        If SPa <> "" Then
            Name = GetField("Name", "specialdtl", "AgentID='" & txtagentid.Text & "' and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPa & "'")
            Dim adlsa = GetField("Adl", "specialdtl", "AgentID='" & txtagentid.Text & "' and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPa & "'")
            Dim chdsa = GetField("Chd", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPa & "'")
            Dim Infsa = GetField("Infant", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "'and NoEvent='" & SPa & "'")
            Dim focsa = GetField("FOC", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPa & "'")
            Dim sura = 0
            LsGo.Rows.Add(Name, adlsa, chdsa, Infsa, focsa, sura)
        End If
    End Sub

    Private Sub cboruteback_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboruteback.SelectedIndexChanged
        If cboruteback.Text <> "" Then
            Dim rutesb As String = cboruteback.Text
            Dim rutesbs = rutesb.Split(New Char() {" - "})
            fillpublishrate(rutesbs(0), "Back")
            'pfillpublishrate(cboGorute.SelectedItem("RuteID").ToString, "Back")
        End If
    End Sub

    Private Sub txtbackdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbackdate.ValueChanged
        Dim rutesa As String = cboruteback.Text
        Dim rutesas = rutesa.Split(New Char() {" - "})

        If cboruteback.Text <> "" Then
            fillpublishrate(rutesas(0), "Back")
        End If
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = "dd/MM/yyyy"
        If txtbackdate.Text = " " Then
            Exit Sub
        End If
        surcharge(txtbackdate.Value.Day, txtbackdate.Value.Month, "Back")
        If surchargeb <> "" Then
            valid(txtbackdate.Text, rutesas(0), "Back")
            If validb <> "" Then
                Name = "SurCharge"
                Dim adl = GetField("Adult", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                Dim chd = GetField("Child", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                Dim Inf = GetField("Inf", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                Dim foc = GetField("FOC", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                Dim sur = GetField("Surcharge", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                LsBack.Rows.Add(Name, adl, chd, Inf, foc, sur)
            End If
        End If
        promo(txtbackdate.Text, rutesas(0), "Back")
        If promob <> "" Then
            Name = "promo"
            Dim adlb = GetField("Adl", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
            Dim chdb = GetField("Chd", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
            Dim Infb = GetField("Infant", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
            Dim focb = GetField("FOC", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
            Dim surb = 0
            LsBack.Rows.Add(Name, adlb, chdb, Infb, focb, surb)
        End If
        spevent(txtbackdate.Text, txtagentid.Text, "Back")
        If SPb <> "" Then
            Name = "Special Event"
            Dim adlsa = GetField("Adl", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPb & "'")
            Dim chdsa = GetField("Chd", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPb & "'")
            Dim Infsa = GetField("Infant", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPb & "'")
            Dim focsa = GetField("FOC", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPb & "'")
            Dim sura = 0
            LsBack.Rows.Add(Name, adlsa, chdsa, Infsa, focsa, sura)
        End If
    End Sub


    Private Sub cboAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdd.Click
        Dim x As Boolean = False
        'If txtstart.Text <> "" Then
        '    If txttiket.Text >= txtend.Text Then
        '        MsgBox("Ticket already to last Number", vbInformation, "Start Tiket Empty")
        '        Exit Sub
        '    End If
        '    If txttiket.Text = "" Then
        '        txttiket.Text = txtstart.Text
        '    Else
        '        Dim s As Integer = Val(Mid(txttiket.Text, 6, 6)) + 1
        '        txttiket.Text = Mid(txttiket.Text, 1, 5) & numx(s, 6)
        '    End If
        'Else
        TXTTIKET.Text = "-"
        'End If
        If TXTTIKET.Text <> "-" Then
            Dim AGN = GetField("AgentID", "ticket", "notiket='" & TXTTIKET.Text & "'")
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
        If cbotipe.Text = "" Then
            MsgBox("Please Choose Ticket Type!", vbInformation, "Ticket Error")
            Exit Sub
        End If
        If Trim(txtgodate.Text) = "" Then
            MsgBox("Please Fill Departure Date!", vbInformation, "Ticket Error")
            Exit Sub
        End If
        If CxOpen.CheckState = CheckState.Checked Then
            x = True
        End If
        Dim country, rute1, rute2, trip1, trip2, area1, area2 As String
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

            If cboruteback.Text = "" Then
                rute2 = ""
            Else
                Dim rutesX As String = cboruteback.Text
                Dim rutesXs = rutesX.Split(New Char() {" - "})
                rute2 = rutesXs(0)
                'rute2 = cboruteback.SelectedItem("RuteID").ToString
            End If
        Else
            If cbotipe.Text = "RT - Return" Then
                If cbotripback.Text = "" Then
                    trip2 = ""
                    MsgBox("Please Fill Arrival Trip", vbInformation, "Arrival Trip Empty")
                    Exit Sub
                Else
                    trip2 = cbotripback.SelectedItem("TripID").ToString
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
                If txtbackdate.Text = " " Then
                    MsgBox("Please Fill Arrival Date", vbInformation, "Arrival Date Empty")
                    Exit Sub
                End If

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
        If txtgorate.Text = "" Then
            MsgBox("Please Select Depart Rate", vbInformation, "Rate is Empty")
            Exit Sub
        Else
            If x = False Then
                If cbotipe.Text = "RT - Return" Then
                    If txtbackrate.Text = "" Then
                        MsgBox("Please Select Arrival Rate", vbInformation, "Rate is Empty")
                        Exit Sub
                    End If
                End If

            End If
        End If
        Dim no As Integer = Val(TXTNOE.Text) + 1
        Dim adl, chd, foc, inf As Integer

        Select Case Mid(cboGst.Text, 1, 1)
            Case "1"
                adl = 1
                chd = 0
                inf = 0
                foc = 0
            Case "2"
                adl = 0
                chd = 1
                inf = 0
                foc = 0
            Case "3"
                adl = 0
                chd = 0
                inf = 1
                foc = 0
            Case "4"
                adl = 0
                chd = 0
                inf = 0
                foc = 1
        End Select

        Dim totals As Double = Val(txtgorate.Text) + Val(txtgoextra.Text) + Val(txtextrago.Text) + Val(txttransgorate.Text) + Val(txtbackrate.Text) + Val(txtbackExtra.Text) + Val(txttransbackrate.Text) + Val(txtexback.Text)

        'LsData.Rows.Add(dls, txtagentid.Text, cbotipe.Text, txtagent.Text, TXTTIKET.Text, cbomrs.Text, txtName.Text, cbotipeID.Text, txtnoID.Text, country, cboCountry.Text, cboGst.Text, rute1, cboGorute.Text, txtgodate.Text, trip1, cboGotrip.Text, txtgorate.Text, txtextrago.Text, CxGoTrans.CheckState, txttransgorate.Text, txtgoextra.Text, area1, cboGoArea.Text, txtpickupgo.Text, txtdrivego.Text, rute2, cboruteback.Text, txtbackdate.Text, trip2, cbotripback.Text, txtbackrate.Text, txtexback.Text, CxBackTrans.CheckState, txttransbackrate.Text, txtbackExtra.Text, area2, cboBackArea.Text, txtPickupBack.Text, txtbackDrive.Text, txtcollect.Text, txtremark.Text, totals, Mid(cbotipe.Text, 1, 2))
        If TXTEDIT.Text = "" Or (IsDBNull(TXTEDIT.Text)) Then

        End If
        LsData.AllowUserToAddRows = True
        LsData.Rows.Add(no, txtNoBook.Text & "-" & no, txtnotiket.Text, txtagent.Text, cbomrs.Text, txtName.Text, cbotipeID.Text, txtnoID.Text, cboCountry.SelectedItem("countryID").ToString, cboCountry.Text, adl, chd, inf, foc, rute1, cboGorute.Text, txtgodate.Text, trip1, cboGotrip.Text, txtgorate.Text, txtextrago.Text, CxGoTrans.CheckState, txttransgorate.Text, txtgoextra.Text, area1, cboGoArea.Text, txtpickupgo.Text, txtdrivego.Text, rute2, cboruteback.Text, txtbackdate.Text, trip2, cbotripback.Text, txtbackrate.Text, txtexback.Text, CxBackTrans.CheckState, txttransbackrate.Text, txtbackExtra.Text, area2, cboBackArea.Text, txtPickupBack.Text, txtbackDrive.Text, NZx(txtcollect.Text), txtremark.Text, totals, txtagentid.Text, Mid(cbotipe.Text, 1, 2), 0, "", 0, 0, (totals * -1), (totals * -1), 1, "yes")

        LsData.AllowUserToDeleteRows = True
        ttl = 0
        valida = ""
        validb = ""
        promoa = ""
        promob = ""
        surchargeg = ""
        surchargeb = ""
        TXTNOE.Text = no
    End Sub

    
    
    Private Sub cbotipe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotipe.SelectedIndexChanged
        If Mid(cbotipe.Text, 1, 2) = "RT" Then
            GroupBox4.Enabled = True
            GroupBox3.Enabled = True
        Else
            GroupBox4.Enabled = False
            'CxBackTrans.Checked = False
            'txtbackExtra.Text = ""
            'txtexback.Text = ""
            'txttransbackrate.Text = ""
            'cboBackArea.Text = ""
            'cboruteback.Text = ""
            'cbotripback.Text = ""
            'txtbackrate.Text = ""
            'txtbackExtra.Text = ""
            'txtPickupBack.Text = ""
            'txtbackDrive.Text = ""
            'txtbackdate.CustomFormat = " "
            'txtbackdate.Format = DateTimePickerFormat.Custom
            GroupBox3.Enabled = True
        End If
    End Sub

    Private Sub LsGo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsGo.CellContentClick
        If cboGst.Text = "" Then
            MsgBox("Please Choose Age", vbInformation, "Error Booking")
            Exit Sub
        End If
        Select Case Mid(cboGst.Text, 1, 1)
            Case "1"
                txtgorate.Text = LsGo.CurrentRow.Cells(1).Value
                txtextrago.Text = LsGo.CurrentRow.Cells(5).Value
            Case "2"
                txtgorate.Text = LsGo.CurrentRow.Cells(2).Value
                txtextrago.Text = LsGo.CurrentRow.Cells(5).Value
            Case "3"
                txtgorate.Text = LsGo.CurrentRow.Cells(3).Value
                txtextrago.Text = LsGo.CurrentRow.Cells(5).Value
            Case "4" ''''Reservasi
                txtgorate.Text = LsGo.CurrentRow.Cells(4).Value
                txtextrago.Text = LsGo.CurrentRow.Cells(5).Value
        End Select
    End Sub

    Private Sub LsBack_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsBack.CellContentClick
        If cboGst.Text = "" Then
            MsgBox("Please Choose Age", vbInformation, "Error Booking")
            Exit Sub
        End If
        Select Case Mid(cboGst.Text, 1, 1)
            Case "1"
                txtbackrate.Text = LsBack.CurrentRow.Cells(1).Value
                txtexback.Text = LsBack.CurrentRow.Cells(5).Value
            Case "2"
                txtbackrate.Text = LsBack.CurrentRow.Cells(2).Value
                txtexback.Text = LsBack.CurrentRow.Cells(5).Value
            Case "3"
                txtbackrate.Text = LsBack.CurrentRow.Cells(3).Value
                txtexback.Text = LsBack.CurrentRow.Cells(5).Value
            Case "4" ''''Reservasi
                txtbackrate.Text = LsBack.CurrentRow.Cells(4).Value
                txtexback.Text = LsBack.CurrentRow.Cells(5).Value
        End Select
    End Sub

    Private Sub CxGoTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CxGoTrans.CheckedChanged
        If CxGoTrans.Checked = True Then
            txttransgorate.Text = "50000"
            GroupBox5.Enabled = True
        Else
            GroupBox5.Enabled = False
            txttransgorate.Text = "0"
        End If
    End Sub

    Private Sub CxBackTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CxBackTrans.CheckedChanged
        If CxBackTrans.Checked = True Then
            txttransbackrate.Text = "50000"
            GroupBox6.Enabled = True
        Else
            GroupBox6.Enabled = False
            txttransbackrate.Text = "0"
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlist.Click

        If LsData.RowCount > 0 Then
            If LsData.CurrentRow.Cells(54).Value = "yes" Then
                LsData.Rows.RemoveAt(LsData.CurrentRow.Index)
            Else
                MsgBox("Data Only can be Void", vbInformation, "Error Booking")
                Exit Sub
            End If
        Else
            MsgBox("Please select Data First", vbInformation, "Error Booking")
            Exit Sub
        End If
    End Sub
    Sub savetiket()

    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim I As Integer = LsData.RowCount
        Dim a, leni, b As Integer
        Dim strSql As String
        Dim strVal As String
        Dim trango, tranback, Total, qttp
        Dim godt, bkdt, gdt, bdt, dtg, dtb As String
        Total = 0
        leni = Len(I)
        ''Dim dtx, dty As Date
        For a = 0 To (I - 1)
            If LsData.Rows(a).Cells(54).Value = "yes" Then
                qttp = 1
                If LsData.Rows(a).Cells(10).Value = 1 Then
                    qttp = 1
                End If
                If LsData.Rows(a).Cells(11).Value = 1 Then
                    qttp = 2
                End If
                If LsData.Rows(a).Cells(12).Value = 1 Then
                    qttp = 3
                End If
                If LsData.Rows(a).Cells(13).Value = 1 Then
                    qttp = 4
                End If


                If LsData.Rows(a).Cells(21).Value = 1 Then
                    trango = 1
                Else
                    trango = 0
                End If
                If LsData.Rows(a).Cells(35).Value = 1 Then
                    tranback = 1
                Else
                    tranback = 0
                End If

                If LsData.Rows(a).Cells(16).Value = " " Then
                    godt = ""
                    gdt = ""
                    dtg = ""
                Else
                    godt = "GoDate='" & Str2Date(LsData.Rows(a).Cells(16).Value) & "', "
                    gdt = " GoDate, "
                    dtg = "'" & Str2Date(LsData.Rows(a).Cells(16).Value) & "',"
                End If
                If LsData.Rows(a).Cells(30).Value = " " Then
                    bkdt = ""
                    bdt = ""
                    dtb = ""
                Else
                    bkdt = " BackDate='" & Str2Date(LsData.Rows(a).Cells(30).Value) & "',"
                    bdt = " BackDate, "
                    dtb = "'" & Str2Date(LsData.Rows(a).Cells(30).Value) & "',"
                End If
                Try
                    Call ConnectDatabase()
                    Dim cmd As MySqlCommand

                    'strSql = "Update tiketdtl set AgentID='" & lsData.Rows(a).Cells(0).Value & "', NoBook='" & txtNoBook.Text & "',GoTrip=" & NZx(lsData.Rows(a).Cells(14).Value) & ",GoRate=" & NZx(lsData.Rows(a).Cells(16).Value) & ",BackExtra=" & NZx(lsData.Rows(a).Cells(31).Value) & ",BackTrans=" & tranback & ",BackTransRate=" & NZx(lsData.Rows(a).Cells(33).Value) & ",BackTransExtra=" & NZx(lsData.Rows(a).Cells(34).Value) & ",BackArea=" & NZx(lsData.Rows(a).Cells(35).Value) & ",BackPickup='" & lsData.Rows(a).Cells(37).Value & "',BackDriver='" & lsData.Rows(a).Cells(38).Value & "',Qty=1,mrs='" & lsData.Rows(a).Cells(4).Value & "',Guest='" & lsData.Rows(a).Cells(5).Value & "',Country=" & NZx(lsData.Rows(a).Cells(8).Value) & ",GuestID='" & lsData.Rows(a).Cells(6).Value & "',GuestIDNO='" & lsData.Rows(a).Cells(7).Value & "',GoRuteID=" & NZx(lsData.Rows(a).Cells(11).Value) & "," & godt & " GoExtra=" & NZx(lsData.Rows(a).Cells(17).Value) & ",GoTrans=" & trango & ",GoTranRate=" & NZx(lsData.Rows(a).Cells(19).Value) & ",GoTransExtra=" & NZx(lsData.Rows(a).Cells(20).Value) & ",GoArea=" & NZx(lsData.Rows(a).Cells(21).Value) & ",GoPickUp='" & lsData.Rows(a).Cells(23).Value & "',GoDriver='" & lsData.Rows(a).Cells(24).Value & "',Remark='" & lsData.Rows(a).Cells(39).Value & "',BackRuteID=" & NZx(lsData.Rows(a).Cells(25).Value) & ", " & bkdt & "TripBack=" & NZx(lsData.Rows(a).Cells(28).Value) & ",BackRate=" & NZx(lsData.Rows(a).Cells(30).Value) & ",QtyTipe=" & Mid(lsData.Rows(a).Cells(10).Value, 1, 1) & ",TotalJual=" & NZx(lsData.Rows(a).Cells(40).Value) & ", Cash=" & CboPay.Text & ",Other='" & txtnote.Text & "',Sisa=" & NZx(lsData.Rows(a).Cells(40).Value) & " where NoTiket='" & lsData.Rows(a).Cells(3).Value & "'"
                    'cmd = New MySqlCommand(strSql, conn)
                    'cmd.ExecuteScalar()
                    b = a + 1
                    'strVal = "insert into bookingdtl (ID, NoBooking,NoTiket, AgentID,TipeTiket,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual) values (" & a & ",'" & txtNoBook.Text & "','" & lsData.Rows(a).Cells(3).Value & "','" & lsData.Rows(a).Cells(0).Value & "','" & Mid(lsData.Rows(a).Cells(1).Value, 1, 2) & "'," & NZx(lsData.Rows(a).Cells(14).Value) & "," & NZx(lsData.Rows(a).Cells(16).Value) & "," & NZx(lsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(lsData.Rows(a).Cells(33).Value) & "," & NZx(lsData.Rows(a).Cells(34).Value) & "," & NZx(lsData.Rows(a).Cells(35).Value) & ",'" & lsData.Rows(a).Cells(37).Value & "','" & lsData.Rows(a).Cells(38).Value & "',1,'" & lsData.Rows(a).Cells(4).Value & "','" & lsData.Rows(a).Cells(5).Value & "'," & NZx(lsData.Rows(a).Cells(8).Value) & ",'" & lsData.Rows(a).Cells(6).Value & "','" & lsData.Rows(a).Cells(7).Value & "'," & NZx(lsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(lsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(lsData.Rows(a).Cells(19).Value) & "," & NZx(lsData.Rows(a).Cells(20).Value) & "," & NZx(lsData.Rows(a).Cells(21).Value) & ",'" & lsData.Rows(a).Cells(23).Value & "','" & lsData.Rows(a).Cells(24).Value & "','" & lsData.Rows(a).Cells(39).Value & "','" & lsData.Rows(a).Cells(25).Value & "'," & bkdt & "'" & lsData.Rows(a).Cells(28).Value & "'," & NZx(lsData.Rows(a).Cells(30).Value) & "," & Mid(lsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(lsData.Rows(a).Cells(40).Value) & ")"
                    'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe) values ('" & txtNoBook.Text & "-" & b & "','" & lsData.Rows(a).Cells(3).Value & "','" & txtagentid.text() & "'," & NZx(lsData.Rows(a).Cells(14).Value) & "," & NZx(lsData.Rows(a).Cells(16).Value) & "," & NZx(lsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(lsData.Rows(a).Cells(33).Value) & "," & NZx(lsData.Rows(a).Cells(34).Value) & "," & NZx(lsData.Rows(a).Cells(35).Value) & ",'" & lsData.Rows(a).Cells(37).Value & "','" & lsData.Rows(a).Cells(38).Value & "',1,'" & lsData.Rows(a).Cells(4).Value & "','" & lsData.Rows(a).Cells(5).Value & "'," & NZx(lsData.Rows(a).Cells(8).Value) & ",'" & lsData.Rows(a).Cells(6).Value & "','" & lsData.Rows(a).Cells(7).Value & "'," & NZx(lsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(lsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(lsData.Rows(a).Cells(19).Value) & "," & NZx(lsData.Rows(a).Cells(20).Value) & "," & NZx(lsData.Rows(a).Cells(21).Value) & ",'" & lsData.Rows(a).Cells(23).Value & "','" & lsData.Rows(a).Cells(24).Value & "','" & lsData.Rows(a).Cells(39).Value & "','" & lsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & lsData.Rows(a).Cells(28).Value & "'," & NZx(lsData.Rows(a).Cells(30).Value) & "," & Mid(lsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(lsData.Rows(a).Cells(40).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "')"
                    If (LsData.Rows(a).Cells(2).Value = "-") Or (LsData.Rows(a).Cells(2).Value = "") Then
                        'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(3).Value & "','" & LsData.Rows(a).Cells(0).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & NZx(LsData.Rows(a).Cells(16).Value) & "," & NZx(LsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(33).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & ",'" & LsData.Rows(a).Cells(37).Value & "','" & LsData.Rows(a).Cells(38).Value & "',1,'" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(5).Value & "'," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & ",'" & LsData.Rows(a).Cells(23).Value & "','" & LsData.Rows(a).Cells(24).Value & "','" & LsData.Rows(a).Cells(40).Value & "','" & LsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(28).Value & "'," & NZx(LsData.Rows(a).Cells(30).Value) & "," & Mid(LsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "'," & NZx(LsData.Rows(a).Cells(41).Value) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ")"
                        ' If LsData.CurrentRow.Cells(54).Value = "yes" Then
                        strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi,sisa) values ('" & LsData.Rows(a).Cells(1).Value & "','" & LsData.Rows(a).Cells(2).Value & "','" & LsData.Rows(a).Cells(45).Value & "'," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(36).Value) & "," & NZx(LsData.Rows(a).Cells(37).Value) & "," & NZx(LsData.Rows(a).Cells(38).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(4).Value & "',@name," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(20).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(22).Value) & "," & NZx(LsData.Rows(a).Cells(23).Value) & "," & NZx(LsData.Rows(a).Cells(24).Value) & ",@gopickup,@godrv,@remark,'" & NZx(LsData.Rows(a).Cells(28).Value) & "'," & dtb & "'" & NZx(LsData.Rows(a).Cells(31).Value) & "'," & NZx(LsData.Rows(a).Cells(33).Value) & "," & qttp & "," & NZx(LsData.Rows(a).Cells(44).Value) & ",'" & txtNoBook.Text & "','" & LsData.Rows(a).Cells(46).Value & "'," & NZx(LsData.Rows(a).Cells(42).Value) & "," & (NZx(LsData.Rows(a).Cells(51).Value) * -1) & "," & NZx(LsData.Rows(a).Cells(52).Value) & ")"
                        'Else

                        'End If

                        Call ConnectDatabase()
                        cmd = New MySqlCommand(strVal, conn)
                        cmd.Parameters.AddWithValue("@name", LsData.Rows(a).Cells(5).Value)
                        cmd.Parameters.AddWithValue("@remark", LsData.Rows(a).Cells(43).Value)
                        cmd.Parameters.AddWithValue("@backpickup", LsData.Rows(a).Cells(40).Value)
                        cmd.Parameters.AddWithValue("@backdrv", LsData.Rows(a).Cells(41).Value)
                        cmd.Parameters.AddWithValue("@gopickup", LsData.Rows(a).Cells(26).Value)
                        cmd.Parameters.AddWithValue("@godrv", LsData.Rows(a).Cells(27).Value)
                        cmd.ExecuteNonQuery()
                        Call DisconnectDatabase()
                    Else
                        If cxField("NoTiket", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(2).Value & "'") = 1 Then
                            Dim gx = GetField("Total", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(2).Value & "'")
                            Dim NC = GetField("NoCollect", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(2).Value & "'")
                            Dim komisi = NZx(LsData.Rows(a).Cells(44).Value) - gx
                            'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,NoCollect,collect,TotalCollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(3).Value & "','" & LsData.Rows(a).Cells(0).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & NZx(LsData.Rows(a).Cells(16).Value) & "," & NZx(LsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(33).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & ",'" & LsData.Rows(a).Cells(37).Value & "','" & LsData.Rows(a).Cells(38).Value & "',1,'" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(5).Value & "'," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & ",'" & LsData.Rows(a).Cells(23).Value & "','" & LsData.Rows(a).Cells(24).Value & "','" & LsData.Rows(a).Cells(40).Value & "','" & LsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(28).Value & "'," & NZx(LsData.Rows(a).Cells(30).Value) & "," & Mid(LsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "'," & LsData.Rows(a).Cells(39).Value & ",'" & NC & "',1," & gx & "," & komisi & "," & NZx(LsData.Rows(a).Cells(41).Value) & ")"
                            'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,NoCollect,collect,TotalCollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(1).Value & "'," & NZx(LsData.Rows(a).Cells(15).Value) & "," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(32).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & "," & NZx(LsData.Rows(a).Cells(36).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(5).Value & "',@name," & NZx(LsData.Rows(a).Cells(9).Value) & ",'" & LsData.Rows(a).Cells(7).Value & "','" & LsData.Rows(a).Cells(8).Value & "'," & NZx(LsData.Rows(a).Cells(12).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(18).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & "," & NZx(LsData.Rows(a).Cells(22).Value) & ",@gopickup,@godrv,@remark,'" & NZx(LsData.Rows(a).Cells(26).Value) & "'," & dtb & "'" & NZx(LsData.Rows(a).Cells(29).Value) & "'," & NZx(LsData.Rows(a).Cells(31).Value) & "," & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ",'" & txtNoBook.Text & "','" & LsData.Rows(a).Cells(43).Value & "'," & LsData.Rows(a).Cells(40).Value & ",'" & NC & "',1," & gx & "," & komisi & "," & NZx(LsData.Rows(a).Cells(42).Value) & ")"
                            strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi,sisa,NoCollect,collect) values ('" & LsData.Rows(a).Cells(1).Value & "','" & LsData.Rows(a).Cells(2).Value & "','" & LsData.Rows(a).Cells(45).Value & "'," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(36).Value) & "," & NZx(LsData.Rows(a).Cells(37).Value) & "," & NZx(LsData.Rows(a).Cells(38).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(4).Value & "',@name," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(20).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(22).Value) & "," & NZx(LsData.Rows(a).Cells(23).Value) & "," & NZx(LsData.Rows(a).Cells(24).Value) & ",@gopickup,@godrv,@remark,'" & NZx(LsData.Rows(a).Cells(28).Value) & "'," & dtb & "'" & NZx(LsData.Rows(a).Cells(31).Value) & "'," & NZx(LsData.Rows(a).Cells(33).Value) & "," & qttp & "," & NZx(LsData.Rows(a).Cells(44).Value) & ",'" & txtNoBook.Text & "','" & LsData.Rows(a).Cells(46).Value & "'," & NZx(LsData.Rows(a).Cells(42).Value) & "," & (NZx(LsData.Rows(a).Cells(51).Value) * -1) & "," & NZx(LsData.Rows(a).Cells(52).Value) & ",'" & NC & "',1)"
                            Call ConnectDatabase()
                            cmd = New MySqlCommand(strVal, conn)
                            cmd.Parameters.AddWithValue("@name", LsData.Rows(a).Cells(6).Value)
                            cmd.Parameters.AddWithValue("@remark", LsData.Rows(a).Cells(41).Value)
                            cmd.Parameters.AddWithValue("@backpickup", LsData.Rows(a).Cells(38).Value)
                            cmd.Parameters.AddWithValue("@backdrv", LsData.Rows(a).Cells(39).Value)
                            cmd.Parameters.AddWithValue("@gopickup", LsData.Rows(a).Cells(24).Value)
                            cmd.Parameters.AddWithValue("@godrv", LsData.Rows(a).Cells(25).Value)
                            cmd.ExecuteNonQuery()
                            Call DisconnectDatabase()
                        Else
                            'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(3).Value & "','" & LsData.Rows(a).Cells(0).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & NZx(LsData.Rows(a).Cells(16).Value) & "," & NZx(LsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(33).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & ",'" & LsData.Rows(a).Cells(37).Value & "','" & LsData.Rows(a).Cells(38).Value & "',1,'" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(5).Value & "'," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & ",'" & LsData.Rows(a).Cells(23).Value & "','" & LsData.Rows(a).Cells(24).Value & "','" & LsData.Rows(a).Cells(40).Value & "','" & LsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(28).Value & "'," & NZx(LsData.Rows(a).Cells(30).Value) & "," & Mid(LsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "'," & LsData.Rows(a).Cells(39).Value & "," & NZx(LsData.Rows(a).Cells(41).Value) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ")"
                            strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi,sisa) values ('" & LsData.Rows(a).Cells(1).Value & "','" & LsData.Rows(a).Cells(2).Value & "','" & LsData.Rows(a).Cells(45).Value & "'," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(36).Value) & "," & NZx(LsData.Rows(a).Cells(37).Value) & "," & NZx(LsData.Rows(a).Cells(38).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(4).Value & "',@name," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(20).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(22).Value) & "," & NZx(LsData.Rows(a).Cells(23).Value) & "," & NZx(LsData.Rows(a).Cells(24).Value) & ",@gopickup,@godrv,@remark,'" & NZx(LsData.Rows(a).Cells(28).Value) & "'," & dtb & "'" & NZx(LsData.Rows(a).Cells(31).Value) & "'," & NZx(LsData.Rows(a).Cells(33).Value) & "," & qttp & "," & NZx(LsData.Rows(a).Cells(44).Value) & ",'" & txtNoBook.Text & "','" & LsData.Rows(a).Cells(46).Value & "'," & NZx(LsData.Rows(a).Cells(42).Value) & "," & (NZx(LsData.Rows(a).Cells(51).Value) * -1) & "," & NZx(LsData.Rows(a).Cells(52).Value) & ")"
                            Call ConnectDatabase()
                            cmd = New MySqlCommand(strVal, conn)
                            cmd.Parameters.AddWithValue("@name", LsData.Rows(a).Cells(6).Value)
                            cmd.Parameters.AddWithValue("@remark", LsData.Rows(a).Cells(41).Value)
                            cmd.Parameters.AddWithValue("@backpickup", LsData.Rows(a).Cells(38).Value)
                            cmd.Parameters.AddWithValue("@backdrv", LsData.Rows(a).Cells(39).Value)
                            cmd.Parameters.AddWithValue("@gopickup", LsData.Rows(a).Cells(24).Value)
                            cmd.Parameters.AddWithValue("@godrv", LsData.Rows(a).Cells(25).Value)
                            cmd.ExecuteNonQuery()
                            Call DisconnectDatabase()
                        End If

                    End If
                    Call ConnectDatabase()
                    'cmd = New MySqlCommand(strVal, conn)
                    'cmd.ExecuteScalar()
                    If (LsData.Rows(a).Cells(2).Value = "-") Or (LsData.Rows(a).Cells(2).Value = "") Then
                    Else
                        strSql = "update ticket set AgentID='" & LsData.Rows(a).Cells(45).Value & "',stats=2 where NoTiket='" & LsData.Rows(a).Cells(2).Value & "' "
                        cmd = New MySqlCommand(strSql, conn)
                        cmd.ExecuteScalar()
                    End If
                    FillLog(usr, " Add New Booking", " No.Etiket=" & LsData.Rows(a).Cells(1).Value & ", No.Tiket:" & LsData.Rows(a).Cells(2).Value & "", "", "")
                    Call DisconnectDatabase()
                Catch ex As SqlException
                    MsgBox(ex.Message)
                Finally
                    ' Close connection
                    Call DisconnectDatabase()
                End Try

                'Else
                '    MsgBox("Data Only can be Void", vbInformation, "Error Booking")
                '    Exit Sub
            End If
        Next
        'Try
        'Call ConnectDatabase()
        'Dim cmd As MySqlCommand

        'strSql = "insert into booking(NoBooking,TglBooking, User,Total)value('" & txtNoBook.Text & "','" & Str2Date(txttgltrans.Text) & "','" & usr & "'," & Total & ")"

        'cmd = New MySqlCommand(strSql, conn)
        'cmd.ExecuteScalar()
        'FillLog(usr, "Add Booking" & txtNoBook.Text)

        Select Case level
            Case "1" '''Administrator
                'fillData(txtNoBook.Text, "frmAdmin")
            Case "2" '''Accounting
                'fillData(txtNoBook.Text, "frmAdmin")
            Case "3" '''AdminReservasi
                'fillData(txtNoBook.Text, "frmAdminRes")
            Case "4" ''''Reservasi
                'fillData(txtNoBook.Text, "frmAdminres")
            Case "5" '''Sales
                'fillData(txtNoBook.Text, "frmAdmins")
        End Select
        If (MsgBox("Booking No." & txtNoBook.Text & " Already Process" & vbCrLf & " ", vbOKOnly, "Ticket Success")) = vbOK Then

            '    cboGst.Text = "1 - Adult"
            '    'fillagent()
            '    filltrip()
            '    fillRute()
            '    fillarea()
            '    fillCountry()
            '    '

            '    txttgltrans.Text = Format(Now, "dd/MM/yyyy")
            '    txtagentid.Focus()
            '    GroupBox4.Enabled = False
            '    txtNoBook.ReadOnly = True '
            '    txttgltrans.ReadOnly = True

            'Else
            Me.Close()
        End If

        'Call DisconnectDatabase()
        'Catch ex As SqlException
        '    MsgBox(ex.Message)
        'Finally
        '    ' Close connection
        '    Call DisconnectDatabase()
        'End Try
    End Sub
End Class