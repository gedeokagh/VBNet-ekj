''Option Strict On
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class frmBooking
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
                strSql = "select RateID from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & rutes & " and Enddate>='" & Str2Date(dates) & "' ORDER BY RateID DESC LIMIT 0,1 "
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

    Sub fillcontract(ByVal dates As String, ByVal rutes As Integer, ByVal stx As String)
        If stx = "Go" Then
            If txtgodate.Text = "" Then
                MsgBox("Depart Date is empty, Please fill Depart Date", vbInformation, "Error Booking")
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select * from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & rutes & " and Enddate>='" & Str2Date(dates) & "' and StartDate<='" & Str2Date(dates) & "' order by RateID desc limit 0,1"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    'valida = reader("RateID").ToString()
                    LsGo.Rows.Add("Contract One-Way", reader("Adult").ToString(), reader("Child").ToString(), reader("INF").ToString(), reader("FOC").ToString(), 0)
                    LsGo.Rows.Add("Contract Return", reader("Adult2").ToString(), reader("Child2").ToString(), reader("INF").ToString(), reader("FOC").ToString(), 0)
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
                strSql = "select * from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & rutes & " and Enddate>='" & Str2Date(dates) & "' and StartDate<='" & Str2Date(dates) & "' ORDER BY RateID DESC LIMIT 0,1 "
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    'validb = reader("RateID").ToString()
                    LsBack.Rows.Add("Contract One-Way", reader("Adult").ToString(), reader("Child").ToString(), reader("Inf").ToString(), reader("FOC").ToString(), 0)
                    LsBack.Rows.Add("Contract Return", reader("Adult2").ToString(), reader("Child2").ToString(), reader("Inf").ToString(), reader("FOC").ToString(), 0)
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
    Sub surcharge(ByVal days, ByVal mons, ByVal RUTES, ByVal dates, ByVal stat)
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


            Dim adl = GetField("Adult", "rute", "RuteID=" & RUTES)
            Dim Name = "Publish Rate"
            Dim chd = GetField("Child", "rute", "RuteID=" & RUTES)
            Dim Inf = GetField("Inf", "rute", "RuteID=" & RUTES)
            Dim foc = GetField("FOC", "rute", "RuteID=" & RUTES)
            Dim strSql As String
            Dim x As Integer
            x = Len(mons.ToString)
            If Len(days.ToString) = 1 Then
                days = numx(days, 2)
            End If
            If Len(mons.ToString) = 1 Then
                mons = numx(mons, 2)
            End If
            Call ConnectDatabase()
            strSql = "select ID from `surchargedtl` where day='" & days & "' and mon='" & mons & "' "
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim reader As MySqlDataReader = Comd.ExecuteReader
            While (reader.Read)
                surchargeg = reader("ID").ToString()
            End While
            reader.Close()
            If surchargeg <> "" Then
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

                LsGo.Rows.Add(Name, adl, chd, Inf, foc, 0)
                strSql = "select * from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & RUTES & " and Enddate>='" & Str2Date(dates) & "' and Startdate<='" & Str2Date(dates) & "' order by RateID desc limit 0,1"
                Dim ComdS As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim readerS As MySqlDataReader = ComdS.ExecuteReader
                While (readerS.Read)
                    'valida = reader("RateID").ToString()
                    LsGo.Rows.Add("One-Way  w/ Surcharge", readerS("Adult").ToString(), readerS("Child").ToString(), readerS("INF").ToString(), readerS("FOC").ToString(), readerS("SURcharge").ToString())
                    LsGo.Rows.Add("Return  w/ Surcharge", readerS("Adult2").ToString(), readerS("Child2").ToString(), readerS("INF").ToString(), readerS("FOC").ToString(), readerS("SURcharge").ToString())
                End While
                readerS.Close()
            End If
            Call DisconnectDatabase()
            
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



            Dim adl = GetField("Adult", "rute", "RuteID=" & RUTES)
            Dim chd = GetField("Child", "rute", "RuteID=" & RUTES)
            Dim Inf = GetField("Inf", "rute", "RuteID=" & RUTES)
            Dim foc = GetField("FOC", "rute", "RuteID=" & RUTES)
            Dim Name = "Publish Rate"
            Dim strSql As String
            Dim x As Integer
            x = Len(mons.ToString)
            If Len(days.ToString) = 1 Then
                days = numx(days, 2)
            End If
            If Len(mons.ToString) = 1 Then
                mons = numx(mons, 2)
            End If
            Call ConnectDatabase()
            strSql = "select ID from `surchargedtl` where day='" & days & "' and mon='" & mons & "' "
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim reader As MySqlDataReader = Comd.ExecuteReader
            While (reader.Read)
                surchargeb = reader("ID").ToString()
            End While

            reader.Close()
            If surchargeb <> "" Then
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
                LsBack.Rows.Add(Name, adl, chd, Inf, foc, 0)
                strSql = "select * from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & RUTES & " and Enddate>='" & Str2Date(dates) & "' and Startdate<='" & Str2Date(dates) & "' order by RateID desc limit 0,1"
                Dim ComdS As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim readerS As MySqlDataReader = ComdS.ExecuteReader
                While (readerS.Read)

                    'valida = reader("RateID").ToString()
                    LsBack.Rows.Add("One-Way  w/ Surcharge", readerS("Adult").ToString(), readerS("Child").ToString(), readerS("INF").ToString(), readerS("FOC").ToString(), readerS("SURcharge").ToString())
                    LsBack.Rows.Add("Return  w/ Surcharge", readerS("Adult2").ToString(), readerS("Child2").ToString(), readerS("INF").ToString(), readerS("FOC").ToString(), readerS("SURcharge").ToString())
                End While
                readerS.Close()
            End If
            Call DisconnectDatabase()


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
                strSql = "select * from `promo` where  RuteID=" & Rutes & " and StartDate<='" & Str2Date(days) & "' and EndDate>='" & Str2Date(days) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    'promoa = reader("Nopromo").ToString
                    LsGo.Rows.Add("Promo", reader("Adult").ToString(), reader("Child").ToString(), reader("INFant").ToString(), reader("FOC").ToString(), 0)
                    'LsGo.Rows.Add("Return  w/ Surcharge", readerS("Adult2").ToString(), readerS("Child2").ToString(), readerS("INF").ToString(), readerS("FOC").ToString(), readerS("SURcharge").ToString())
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
                strSql = "select * from `promo` where  RuteID=" & Rutes & " and StartDate<='" & Str2Date(days) & "' and EndDate>='" & Str2Date(days) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    'promob = reader("Nopromo").ToString
                    LsBack.Rows.Add("Promo", reader("Adult").ToString(), reader("Child").ToString(), reader("INFant").ToString(), reader("FOC").ToString(), 0)
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
                strSql = "select * from `special` where  AgentID='" & agn & "' and StartDate<='" & Str2Date(days) & "' and EndDate>='" & Str2Date(days) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    'SPa = reader("Noevent").ToString
                    LsGo.Rows.Add("Special Event", reader("Adult").ToString(), reader("Child").ToString(), reader("INFant").ToString(), reader("FOC").ToString(), 0)
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
                strSql = "select * from `special` where  AgentID='" & agn & "' and StartDate<='" & Str2Date(days) & "' and EndDate>='" & Str2Date(days) & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                Dim reader As MySqlDataReader = Comd.ExecuteReader
                While (reader.Read)
                    'SPb = reader("Noevent").ToString
                    LsBack.Rows.Add("Special Event", reader("Adult").ToString(), reader("Child").ToString(), reader("INFant").ToString(), reader("FOC").ToString(), 0)
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
                If txtgodate.Text = " " Then
                    fillcontract(Format(Now, "dd/MM/yyyy"), RuteID, "Go")
                Else
                    fillcontract(txtgodate.Text, RuteID, "Go")
                End If
                '

                'valid(Format(Now, "dd/MM/yyyy"), RuteID, "Go")
                'If valida <> "" Then
                '    name = "Contract"
                '    adl = GetField("Adult", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                '    chd = GetField("Child", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                '    Inf = GetField("Inf", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                '    foc = GetField("FOC", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                '    LsGo.Rows.Add(name, adl, chd, Inf, foc, sur)
                'End If
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
                If txtbackdate.Text = " " Then
                    fillcontract(Format(Now, "dd/MM/yyyy"), RuteID, "Back")
                Else
                    fillcontract(txtbackdate.Text, RuteID, "Back")
                End If

                '

                'valid(Format(Now, "dd/MM/yyyy"), RuteID, "Back")
                'If valida <> "" Then
                '    name = "Contract"
                '    adl = GetField("Adult", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '    chd = GetField("Child", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '    Inf = GetField("Inf", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '    foc = GetField("FOC", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '    LsBack.Rows.Add(name, adl, chd, Inf, foc, sur)
                'End If
            End If
        End If
    End Sub
    Sub fillprice()
        If txtagentid.Text = "" Then
            MsgBox("Please Choose Agent?", vbInformation, "Ticket Error")
            Exit Sub
        Else
            If cboGst.Text = "" Then
                MsgBox("Please Choose Guest Age", vbInformation, "Ticket Error")
                Exit Sub
            Else
                If cboGorute.Text = "" Then

                Else
                    Select Case Mid(cboGst.Text, 1, 1)
                        Case "1"
                            txtgorate.Text = GetField("Adult", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
                        Case "2"
                            txtgorate.Text = GetField("Chd", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
                        Case "3"
                            txtgorate.Text = 0
                        Case "4"
                            txtgorate.Text = 0
                    End Select
                End If
            End If
        End If
    End Sub
    Sub fillData(ByVal NoBooking, ByVal lvl)
        Dim strQry As String
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        strQry = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `agent`.`AgentName`, `tiketdtl`.`mrs`, `tiketdtl`.`Guest`, `tiketdtl`.`GuestID`, `tiketdtl`.`GuestIDNO`, `tiketdtl`.`Country`, IF(`tiketdtl`.`Country`='','',(SELECT country.CountryName FROM country WHERE country.CountryID=tiketdtl.Country)) AS CountryName, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC,`tiketdtl`.`GoRuteID`, `rute`.`RuteName` AS DepartRute , `tiketdtl`.`GoDate` AS DepartDate, `tiketdtl`.`GoTrip`, `trip`.`TripName` , `tiketdtl`.`GoRate` , `tiketdtl`.`GoExtra`, IF(`tiketdtl`.`GoTrans`=0,'No','Yes') AS Transport, `tiketdtl`.`GoTranRate`, `tiketdtl`.`GoTransExtra`, `tiketdtl`.`GoArea`, IF(`tiketdtl`.`GoArea`=0,'',(SELECT area.AreaName FROM AREA WHERE area.`AreaID`=tiketdtl.GoArea)) AS DepartPickupArea, `tiketdtl`.`GoPickUp` AS PickupLocation, `tiketdtl`.`GoDriver`, `tiketdtl`.`BackRuteID`, IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS ArrivalRute, tiketdtl.BackDate AS ArrivalDate, tiketdtl.`TripBack`, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS ArrivalTrip, `tiketdtl`.`BackRate`, `tiketdtl`.`BackExtra`, IF(`tiketdtl`.`BackTrans`=0,'No','Yes') AS Transport, `tiketdtl`.`BackTransRate`, `tiketdtl`.`BackTransExtra`, `tiketdtl`.`BackArea`, IF(`tiketdtl`.`BackArea`=0,'',(SELECT area.AreaName FROM AREA WHERE area.`AreaID`=tiketdtl.GoArea)) AS ArrivalPickupArea, `tiketdtl`.`BackPickup` AS DepartPickupLocation, `tiketdtl`.`BackDriver`, `tiketdtl`.`Remark`, `tiketdtl`.`TotalJual`, `tiketdtl`.`AgentID` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE tiketdtl.NoBook='" & NoBooking & "'"
        da = New MySqlDataAdapter("select * from tiketdtl where NoBook='" & NoBooking & "'", conn)
        dt = New DataTable
        da.Fill(dt)

        frmAdmin.LsData.DataSource = dt
        frmAdmin.LsData.AllowUserToAddRows = False
        frmAdmin.LsData.AllowUserToDeleteRows = False

        Call DisconnectDatabase()
    End Sub
    Sub cekpromo()

        Select Case Mid(cboGst.Text, 1, 1)
            Case "1"
                txtgorate.Text = GetField("Adult", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
            Case "2"
                txtgorate.Text = GetField("Chd", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
            Case "3"
                txtgorate.Text = 0
            Case "4"
                txtgorate.Text = 0
        End Select
    End Sub
    Sub dlist()
        LsData.ColumnCount = 44
        LsData.Columns(0).Name = "No."
        LsData.Columns(1).Name = "AgentID"
        'lsData.Columns(0).Visible = False
        LsData.Columns(2).Name = "Tiket Type"
        LsData.Columns(3).Name = "AgentName"
        ' lsData.Columns(2).Visible = False
        LsData.Columns(4).Name = "NoTiket"
        LsData.Columns(5).Name = "Title"
        LsData.Columns(6).Name = "Name"
        LsData.Columns(7).Name = "IDType"
        LsData.Columns(8).Name = "No.ID"
        LsData.Columns(9).Name = "CountryID"
        LsData.Columns(9).Visible = False
        LsData.Columns(10).Name = "CountryName"
        LsData.Columns(11).Name = "Guest"
        LsData.Columns(12).Name = "GoRuteID"
        LsData.Columns(12).Visible = False
        LsData.Columns(13).Name = "GoRute"
        LsData.Columns(14).Name = "GoDate"
        LsData.Columns(15).Name = "GoTripID"
        LsData.Columns(15).Visible = False
        LsData.Columns(16).Name = "GoTrip"
        LsData.Columns(17).Name = "GoRate"
        LsData.Columns(18).Name = "GoExtraCharge"
        LsData.Columns(19).Name = "Transport"
        LsData.Columns(20).Name = "GoTransportRate"
        LsData.Columns(21).Name = "GoTransportExtraCharge"
        LsData.Columns(22).Name = "GoAreaID"
        LsData.Columns(22).Visible = False
        LsData.Columns(23).Name = "PickupArea"
        LsData.Columns(24).Name = "PickupLocation"
        LsData.Columns(25).Name = "GoDrivers"
        LsData.Columns(26).Name = "BackRuteID"
        LsData.Columns(26).Visible = False
        LsData.Columns(27).Name = "BackRute"
        LsData.Columns(28).Name = "BackDate"
        LsData.Columns(29).Name = "BackTripID"
        LsData.Columns(29).Visible = False
        LsData.Columns(30).Name = "BackTrip"
        LsData.Columns(31).Name = "BackRate"
        LsData.Columns(32).Name = "BackExtraCharge"
        LsData.Columns(33).Name = "Transport"
        LsData.Columns(34).Name = "BackTransportRate"
        LsData.Columns(35).Name = "BackTransportExtraCharge"
        LsData.Columns(36).Name = "BackAreaID"
        LsData.Columns(36).Visible = False
        LsData.Columns(37).Name = "PickupArea"
        LsData.Columns(38).Name = "PickupLocation"
        LsData.Columns(39).Name = "BackDrivers"
        LsData.Columns(40).Name = "Request Collect"
        LsData.Columns(41).Name = "Remark"
        LsData.Columns(42).Name = "Total"
        LsData.Columns(43).Name = "Tipe"
        LsData.Columns(43).Visible = False
        lsData.ReadOnly = True
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
    End Sub
    Sub clrs()
        txtagentid.Text = ""
        txtgoextra.Text = ""
        txtextrago.Text = ""
        cbotipe.Text = ""
        txtstart.Text = ""
        txtend.Text = ""
        txtttltiket.Text = ""
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
        txttransgorate.Text = ""
        CxGoTrans.Checked = False
        CxBackTrans.Checked = False
        txtgoextra.Text = ""
        txtpickupgo.Text = ""
        txtdrivego.Text = ""
        dls = 0
        txtgodate.CustomFormat = " "
        txtgodate.Format = DateTimePickerFormat.Custom

        txtbackExtra.Text = ""
        txtexback.Text = ""
        txttransbackrate.Text = ""
        cboBackArea.Text = ""
        cboruteback.Text = ""
        cbotripback.Text = ""
        txtbackrate.Text = ""
        txtbackExtra.Text = ""
        txtPickupBack.Text = ""
        txtbackDrive.Text = ""
        txtbackdate.CustomFormat = " "
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtcollect.Text = "0"
        txtagent.Text = ""
        If LsData.RowCount > 0 Then
            LsData.Rows.Clear()
        End If
        If LsGo.RowCount > 0 Then
            LsGo.Rows.Clear()
        End If
        If LsBack.RowCount > 0 Then
            LsBack.Rows.Clear()
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
        Dim strSql As String = "Select RuteID,RuteName FROM Rute WHERE TIPE=1"
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

    Sub filltransport()
        Call ConnectDatabase()
        Dim da, da2 As MySqlDataAdapter
        Dim dt, dt2 As DataTable
        da = New MySqlDataAdapter("select ID,Nominal from transport", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        'da.Fill(dt)
        txttransgorate.DataSource = dt
        txttransgorate.DisplayMember = "Nominal"
        da2 = New MySqlDataAdapter("select ID,Nominal from transport", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        txttransbackrate.DataSource = dt2
        txttransbackrate.DisplayMember = "Nominal"
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
    Sub getprice()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID,AgentName from agent where status=1", conn)
        dt = New DataTable
        da.Fill(dt)
        'txtagentid.DataSource = dt
        'txtagentid.DisplayMember = "AgentName"
        Call DisconnectDatabase()
    End Sub

    Sub cxtiket()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID from ticket where NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "' group by AgentID", conn)
        dt = New DataTable
        dt.Rows.Clear()
        da.Fill(dt)
        ttl = dt.Rows.Count
        Call DisconnectDatabase()
    End Sub

    Private Sub frmBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboGst.Text = "1 - Adult"
        'fillagent()
        'txtagentid.Text = "OFFICE KUTA"
        filltrip()
        fillRute()
        filltransport()
        fillarea()
        fillCountry()

        dlist()
        txttgltrans.Text = Format(Now, "dd/MM/yyyy")
        clrs()
        txtagentid.Focus()
        GroupBox4.Enabled = False
        GroupBox6.Enabled = False
        GroupBox5.Enabled = False
        txtNoBook.ReadOnly = True
        txtttltiket.ReadOnly = True
        txttgltrans.ReadOnly = True
        txtcollect.Text = 0
    End Sub


    Private Sub cbotipe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotipe.SelectedIndexChanged
        If Mid(cbotipe.Text, 1, 2) = "RT" Then
            GroupBox4.Enabled = True
            'GroupBox6.Enabled = True
        Else
            GroupBox4.Enabled = False
            CxBackTrans.Checked = False
            txtbackExtra.Text = ""
            txtexback.Text = ""
            txttransbackrate.Text = ""
            cboBackArea.Text = ""
            cboruteback.Text = ""
            cbotripback.Text = ""
            txtbackrate.Text = ""
            txtbackExtra.Text = ""
            txtPickupBack.Text = ""
            txtbackDrive.Text = ""
            txtbackdate.CustomFormat = " "
            txtbackdate.Format = DateTimePickerFormat.Custom
            'GroupBox6.Enabled = False
        End If
    End Sub


    Private Sub txtstart_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstart.Leave
        txtstart.Text = UCase(txtstart.Text)
    End Sub

    Private Sub txtstart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstart.TextChanged
        If cbotipe.Text = "" Then
            MsgBox("Please Choose Tiket Tipe", vbInformation, "Tipe Tiket Empty!!!")
            txtstart.Focus()
        End If
    End Sub

    Private Sub txtend_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtend.KeyDown
        If e.KeyData = Keys.Tab Or e.KeyCode = Keys.Enter Then
            txtend.Text = UCase(txtend.Text)
            If txtagentid.Text = "" Then
                MsgBox("Please Choose Agent!", vbInformation, "Ticket Error")
                Exit Sub
            End If
            If Len(txtstart.Text) = Len(txtend.Text) Then
                If Mid(txtstart.Text, 1, 4) = Mid(txtend.Text, 1, 4) Then
                    txtttltiket.Text = (Val(Mid(txtend.Text, 6)) - Val(Mid(txtstart.Text, 6))) + 1

                    cxtiket()
                    If ttl = 1 Then
                        Dim ag = Trim(GetField("AgentID", "ticket", "NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "' group by AgentID"))
                        If ag = txtagentid.Text() Then
                        ElseIf ag = "" Then
                        Else
                            MsgBox("No Tiket Already Used by other Agent!" & vbCrLf & "Please check Again!", vbInformation, "Ticket Error")
                        End If
                    ElseIf ttl = 0 Then
                        MsgBox("No Tiket Not Ganerate Yet!" & vbCrLf & "Please check Again!", vbInformation, "Ticket Error")
                    Else
                        MsgBox("No Tiket Not not for This Agent!" & vbCrLf & "Please check Again!", vbInformation, "Ticket Error")
                    End If
                Else
                    MsgBox("Please Check Start and End Tiket" & vbCrLf & "Tipe Ticket Ist'n same!", vbInformation, "Ticket Error")
                    Exit Sub
                End If
            Else
                MsgBox("Please Check Start and End Tiket", vbInformation, "Ticket Error")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtend_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtend.Leave
        txtend.Text = UCase(txtend.Text)
    End Sub

    Private Sub txtend_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtend.PreviewKeyDown
        If e.KeyData = Keys.Tab Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub txtend_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtend.TextChanged
        If txtstart.Text = "" Then
            MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
            txtstart.Focus()
            Exit Sub
        ElseIf Len(txtstart.Text) < 11 Then
            MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
            txtstart.Focus()
            Exit Sub
        Else
            cmdlist.Enabled = False
        End If
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cboGorute_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGorute.SelectedIndexChanged
        If cboGorute.Text <> "" Then
            Dim rutesa As String = cboGorute.Text
            Dim rutesas = rutesa.Split(New Char() {" - "})
            fillpublishrate(rutesas(0), "Go")
        End If
        'If txtagentid.Text = "" Then
        '    MsgBox("Please Choose Agent?", vbInformation, "Ticket Error")
        '    Exit Sub
        'Else
        '    If cboGst.Text = "" Then
        '        MsgBox("Please Choose Guest", vbInformation, "Ticket Error")
        '        Exit Sub
        '    Else
        '        If cboGorute.Text = "" Then
        '            txtgorate.Text = ""
        '        Else
        '            Select Case Mid(cboGst.Text, 1, 1)
        '                Case "1"
        '                    txtgorate.Text = GetField("Adult", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '                Case "2"
        '                    txtgorate.Text = GetField("Chd", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '                Case "3"
        '                    txtgorate.Text = 0
        '                Case "4"
        '                    txtgorate.Text = 0
        '            End Select
        '        End If
        '    End If
        'End If


    End Sub

    Private Sub txtagentid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If cboGst.Text <> "" Then
        '    If cboGorute.Text <> "" Then
        '        Select Case Mid(cboGst.Text, 1, 1)
        '            Case "1"
        '                txtgorate.Text = GetField("Adult", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '            Case "2"
        '                txtgorate.Text = GetField("Chd", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '            Case "3"
        '                txtgorate.Text = 0
        '            Case "4"
        '                txtgorate.Text = 0
        '        End Select
        '    End If
        'End If
        'If cboGst.Text <> "" Then
        '    If cboruteback.Text <> "" Then
        '        Select Case Mid(cboGst.Text, 1, 1)
        '            Case "1"
        '                txtbackrate.Text = GetField("Adult", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '            Case "2"
        '                txtbackrate.Text = GetField("Chd", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '            Case "3"
        '                txtbackrate.Text = 0
        '            Case "4"
        '                txtbackrate.Text = 0
        '        End Select
        '    End If
        'End If
    End Sub

    Private Sub cboGst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGst.SelectedIndexChanged
        'If txtagentid.Text <> "" Then
        '    If cboGorute.Text <> "" Then
        '        Select Case Mid(cboGst.Text, 1, 1)
        '            Case "1"
        '                txtgorate.Text = GetField("Adult", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '            Case "2"
        '                txtgorate.Text = GetField("Chd", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '            Case "3"
        '                txtgorate.Text = 0
        '            Case "4"
        '                txtgorate.Text = 0
        '        End Select
        '    End If
        'End If
        'If txtagentid.Text <> "" Then
        '    If cboruteback.Text <> "" Then
        '        Select Case Mid(cboGst.Text, 1, 1)
        '            Case "1"
        '                txtbackrate.Text = GetField("Adult", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '            Case "2"
        '                txtbackrate.Text = GetField("Chd", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboGorute.SelectedItem("RuteID").ToString)
        '            Case "3"
        '                txtbackrate.Text = 0
        '            Case "4"
        '                txtbackrate.Text = 0
        '        End Select
        '    End If
        'End If
    End Sub


    Private Sub cboruteback_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboruteback.SelectedIndexChanged
        If cboruteback.Text <> "" Then
            Dim rutesb As String = cboruteback.Text
            Dim rutesbs = rutesb.Split(New Char() {" - "})
            fillpublishrate(rutesbs(0), "Back")
            'pfillpublishrate(cboGorute.SelectedItem("RuteID").ToString, "Back")
        End If
        'If txtagentid.Text = "" Then
        '    MsgBox("Please Choose Agent?", vbInformation, "Ticket Error")
        '    Exit Sub
        'Else
        '    If cboGst.Text = "" Then
        '        MsgBox("Please Choose Guest", vbInformation, "Ticket Error")
        '        Exit Sub
        '    Else
        '        If cboruteback.Text = "" Then
        '            txtbackrate.Text = ""
        '        Else
        '            Select Case Mid(cboGst.Text, 1, 1)
        '                Case "1"
        '                    txtbackrate.Text = GetField("Adult", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboruteback.SelectedItem("RuteID").ToString)
        '                Case "2"
        '                    txtbackrate.Text = GetField("Chd", "agentrate", "AgentID='" & txtagentid.Text & "' and RuteID=" & cboruteback.SelectedItem("RuteID").ToString)
        '                Case "3"
        '                    txtbackrate.Text = 0
        '                Case "4"
        '                    txtbackrate.Text = 0
        '            End Select
        '        End If
        '    End If
        'End If
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

    Private Sub cboAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdd.Click
        Dim x As Boolean = False
        If txtstart.Text <> "" Then
            If txttiket.Text >= txtend.Text Then
                MsgBox("Ticket already to last Number", vbInformation, "Start Tiket Empty")
                Exit Sub
            End If
            If txttiket.Text = "" Then
                txttiket.Text = txtstart.Text
            Else
                Dim s As Integer = Val(Mid(txttiket.Text, 6, 6)) + 1
                txttiket.Text = Mid(txttiket.Text, 1, 5) & numx(s, 6)
            End If
        Else
            txttiket.Text = "-"
        End If
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
        If dls = 0 Then
            dls = 1
        Else
            dls = dls + 1
        End If
        Dim totals As Double = Val(txtgorate.Text) + Val(txtgoextra.Text) + Val(txtextrago.Text) + Val(txttransgorate.Text) + Val(txtbackrate.Text) + Val(txtbackExtra.Text) + Val(txttransbackrate.Text) + Val(txtexback.Text)
        'lsData.Rows.Add(txtagentid.text(), txtagentid.Text, cbotipe.Text, txttiket.Text, cbomrs.Text, txtName.Text, cbotipeID.Text, txtnoID.Text, cboCountry.SelectedItem("CountryID").ToString(), cboCountry.Text, cboGst.Text, cboGorute.SelectedItem("RuteID").ToString(), cboGorute.Text, txtgodate.Text, cboGotrip.SelectedItem("TripID").ToString(), cboGotrip.Text, txtgorate.Text, txtextrago.Text, CxGoTrans.CheckState, txttransgorate.Text, txtgoextra.Text, cboGoArea.SelectedItem("AreaID").ToString(), cboGoArea.Text, txtpickupgo.Text, txtdrivego.Text, cboruteback.SelectedItem("RuteID").ToString(), cboruteback.Text, txtbackdate.Text, cbotripback.SelectedItem("TripID").ToString(), cbotripback.Text, txtbackrate.Text, txtexback.Text, CxBackTrans.CheckState, txttransbackrate.Text, txtbackExtra.Text, cboBackArea.SelectedItem("AreaID").ToString(), cboBackArea.Text, txtPickupBack.Text, txtbackDrive.Text, txtremark.Text, totals)
        LsData.Rows.Add(dls, txtagentid.Text, cbotipe.Text, txtagent.Text, txttiket.Text, cbomrs.Text, txtName.Text, cbotipeID.Text, txtnoID.Text, country, cboCountry.Text, cboGst.Text, rute1, cboGorute.Text, txtgodate.Text, trip1, cboGotrip.Text, txtgorate.Text, txtextrago.Text, CxGoTrans.CheckState, txttransgorate.Text, txtgoextra.Text, area1, cboGoArea.Text, txtpickupgo.Text, txtdrivego.Text, rute2, cboruteback.Text, txtbackdate.Text, trip2, cbotripback.Text, txtbackrate.Text, txtexback.Text, CxBackTrans.CheckState, txttransbackrate.Text, txtbackExtra.Text, area2, cboBackArea.Text, txtPickupBack.Text, txtbackDrive.Text, txtcollect.Text, txtremark.Text, totals, Mid(cbotipe.Text, 1, 2))
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
        'surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
        surcharge(txtgodate.Value.Day, txtgodate.Value.Month, rutesl(0), txtgodate.Text, "Go")
        'If surchargeg <> "" Then
        '    valid(txtgodate.Text, rutesl(0), "Go")
        '    If valida <> "" Then
        '        Name = "SurCharge"
        '        Dim adl = GetField("Adult", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '        Dim chd = GetField("Child", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '        Dim Inf = GetField("Inf", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '        Dim foc = GetField("FOC", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '        Dim sur = GetField("Surcharge", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '        LsGo.Rows.Add(Name, adl, chd, Inf, foc, sur)
        '    End If
        'End If
        'promo(txtgodate.Text, cboGorute.SelectedItem("RuteID"), "Go")
        promo(txtgodate.Text, rutesl(0), "Go")
        'If promoa <> "" Then
        '    Name = "promo"
        '    Dim adla = GetField("Adl", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '    Dim chda = GetField("Chd", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '    Dim Infa = GetField("Infant", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '    Dim foca = GetField("FOC", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '    Dim sura = 0
        '    LsGo.Rows.Add(Name, adla, chda, Infa, foca, sura)
        'End If
        spevent(txtgodate.Text, txtagentid.Text, "Go")
        'If SPa <> "" Then
        '    Name = GetField("Name", "specialdtl", "AgentID='" & txtagentid.Text & "' and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPa & "'")
        '    Dim adlsa = GetField("Adl", "specialdtl", "AgentID='" & txtagentid.Text & "' and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPa & "'")
        '    Dim chdsa = GetField("Chd", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPa & "'")
        '    Dim Infsa = GetField("Infant", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "'and NoEvent='" & SPa & "'")
        '    Dim focsa = GetField("FOC", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPa & "'")
        '    Dim sura = 0
        '    LsGo.Rows.Add(Name, adlsa, chdsa, Infsa, focsa, sura)
        'End If

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
        Dim trango, tranback, Total
        Dim godt, bkdt, gdt, bdt, dtg, dtb As String
        Total = 0
        leni = Len(I)
        ''Dim dtx, dty As Date
        Call ConnectDatabase()
        Dim cmd As MySqlCommand

        strSql = "insert into booking(NoBooking,TglBooking, User)value('" & txtNoBook.Text & "','" & Str2Date(txttgltrans.Text) & "','" & usr & "')"

        cmd = New MySqlCommand(strSql, conn)
        cmd.ExecuteScalar()
        Call DisconnectDatabase()
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

            If LsData.Rows(a).Cells(14).Value = " " Then
                godt = ""
                gdt = ""
                dtg = ""
            Else
                godt = "GoDate='" & Str2Date(LsData.Rows(a).Cells(14).Value) & "', "
                gdt = " GoDate, "
                dtg = "'" & Str2Date(LsData.Rows(a).Cells(14).Value) & "',"
            End If
            If LsData.Rows(a).Cells(28).Value = " " Then
                bkdt = ""
                bdt = ""
                dtb = ""
            Else
                bkdt = " BackDate='" & Str2Date(LsData.Rows(a).Cells(28).Value) & "',"
                bdt = " BackDate, "
                dtb = "'" & Str2Date(LsData.Rows(a).Cells(28).Value) & "',"
            End If
            Try
                Call ConnectDatabase()
                '' Dim cmd As MySqlCommand

                'strSql = "Update tiketdtl set AgentID='" & lsData.Rows(a).Cells(0).Value & "', NoBook='" & txtNoBook.Text & "',GoTrip=" & NZx(lsData.Rows(a).Cells(14).Value) & ",GoRate=" & NZx(lsData.Rows(a).Cells(16).Value) & ",BackExtra=" & NZx(lsData.Rows(a).Cells(31).Value) & ",BackTrans=" & tranback & ",BackTransRate=" & NZx(lsData.Rows(a).Cells(33).Value) & ",BackTransExtra=" & NZx(lsData.Rows(a).Cells(34).Value) & ",BackArea=" & NZx(lsData.Rows(a).Cells(35).Value) & ",BackPickup='" & lsData.Rows(a).Cells(37).Value & "',BackDriver='" & lsData.Rows(a).Cells(38).Value & "',Qty=1,mrs='" & lsData.Rows(a).Cells(4).Value & "',Guest='" & lsData.Rows(a).Cells(5).Value & "',Country=" & NZx(lsData.Rows(a).Cells(8).Value) & ",GuestID='" & lsData.Rows(a).Cells(6).Value & "',GuestIDNO='" & lsData.Rows(a).Cells(7).Value & "',GoRuteID=" & NZx(lsData.Rows(a).Cells(11).Value) & "," & godt & " GoExtra=" & NZx(lsData.Rows(a).Cells(17).Value) & ",GoTrans=" & trango & ",GoTranRate=" & NZx(lsData.Rows(a).Cells(19).Value) & ",GoTransExtra=" & NZx(lsData.Rows(a).Cells(20).Value) & ",GoArea=" & NZx(lsData.Rows(a).Cells(21).Value) & ",GoPickUp='" & lsData.Rows(a).Cells(23).Value & "',GoDriver='" & lsData.Rows(a).Cells(24).Value & "',Remark='" & lsData.Rows(a).Cells(39).Value & "',BackRuteID=" & NZx(lsData.Rows(a).Cells(25).Value) & ", " & bkdt & "TripBack=" & NZx(lsData.Rows(a).Cells(28).Value) & ",BackRate=" & NZx(lsData.Rows(a).Cells(30).Value) & ",QtyTipe=" & Mid(lsData.Rows(a).Cells(10).Value, 1, 1) & ",TotalJual=" & NZx(lsData.Rows(a).Cells(40).Value) & ", Cash=" & CboPay.Text & ",Other='" & txtnote.Text & "',Sisa=" & NZx(lsData.Rows(a).Cells(40).Value) & " where NoTiket='" & lsData.Rows(a).Cells(3).Value & "'"
                'cmd = New MySqlCommand(strSql, conn)
                'cmd.ExecuteScalar()
                b = a + 1
                'strVal = "insert into bookingdtl (ID, NoBooking,NoTiket, AgentID,TipeTiket,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual) values (" & a & ",'" & txtNoBook.Text & "','" & lsData.Rows(a).Cells(3).Value & "','" & lsData.Rows(a).Cells(0).Value & "','" & Mid(lsData.Rows(a).Cells(1).Value, 1, 2) & "'," & NZx(lsData.Rows(a).Cells(14).Value) & "," & NZx(lsData.Rows(a).Cells(16).Value) & "," & NZx(lsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(lsData.Rows(a).Cells(33).Value) & "," & NZx(lsData.Rows(a).Cells(34).Value) & "," & NZx(lsData.Rows(a).Cells(35).Value) & ",'" & lsData.Rows(a).Cells(37).Value & "','" & lsData.Rows(a).Cells(38).Value & "',1,'" & lsData.Rows(a).Cells(4).Value & "','" & lsData.Rows(a).Cells(5).Value & "'," & NZx(lsData.Rows(a).Cells(8).Value) & ",'" & lsData.Rows(a).Cells(6).Value & "','" & lsData.Rows(a).Cells(7).Value & "'," & NZx(lsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(lsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(lsData.Rows(a).Cells(19).Value) & "," & NZx(lsData.Rows(a).Cells(20).Value) & "," & NZx(lsData.Rows(a).Cells(21).Value) & ",'" & lsData.Rows(a).Cells(23).Value & "','" & lsData.Rows(a).Cells(24).Value & "','" & lsData.Rows(a).Cells(39).Value & "','" & lsData.Rows(a).Cells(25).Value & "'," & bkdt & "'" & lsData.Rows(a).Cells(28).Value & "'," & NZx(lsData.Rows(a).Cells(30).Value) & "," & Mid(lsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(lsData.Rows(a).Cells(40).Value) & ")"
                'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe) values ('" & txtNoBook.Text & "-" & b & "','" & lsData.Rows(a).Cells(3).Value & "','" & txtagentid.text() & "'," & NZx(lsData.Rows(a).Cells(14).Value) & "," & NZx(lsData.Rows(a).Cells(16).Value) & "," & NZx(lsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(lsData.Rows(a).Cells(33).Value) & "," & NZx(lsData.Rows(a).Cells(34).Value) & "," & NZx(lsData.Rows(a).Cells(35).Value) & ",'" & lsData.Rows(a).Cells(37).Value & "','" & lsData.Rows(a).Cells(38).Value & "',1,'" & lsData.Rows(a).Cells(4).Value & "','" & lsData.Rows(a).Cells(5).Value & "'," & NZx(lsData.Rows(a).Cells(8).Value) & ",'" & lsData.Rows(a).Cells(6).Value & "','" & lsData.Rows(a).Cells(7).Value & "'," & NZx(lsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(lsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(lsData.Rows(a).Cells(19).Value) & "," & NZx(lsData.Rows(a).Cells(20).Value) & "," & NZx(lsData.Rows(a).Cells(21).Value) & ",'" & lsData.Rows(a).Cells(23).Value & "','" & lsData.Rows(a).Cells(24).Value & "','" & lsData.Rows(a).Cells(39).Value & "','" & lsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & lsData.Rows(a).Cells(28).Value & "'," & NZx(lsData.Rows(a).Cells(30).Value) & "," & Mid(lsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(lsData.Rows(a).Cells(40).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "')"
                If LsData.Rows(a).Cells(4).Value = "-" Then
                    'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(3).Value & "','" & LsData.Rows(a).Cells(0).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & NZx(LsData.Rows(a).Cells(16).Value) & "," & NZx(LsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(33).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & ",'" & LsData.Rows(a).Cells(37).Value & "','" & LsData.Rows(a).Cells(38).Value & "',1,'" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(5).Value & "'," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & ",'" & LsData.Rows(a).Cells(23).Value & "','" & LsData.Rows(a).Cells(24).Value & "','" & LsData.Rows(a).Cells(40).Value & "','" & LsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(28).Value & "'," & NZx(LsData.Rows(a).Cells(30).Value) & "," & Mid(LsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "'," & NZx(LsData.Rows(a).Cells(41).Value) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ")"
                    strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(1).Value & "'," & NZx(LsData.Rows(a).Cells(15).Value) & "," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(32).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & "," & NZx(LsData.Rows(a).Cells(36).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(5).Value & "',@name," & NZx(LsData.Rows(a).Cells(9).Value) & ",'" & LsData.Rows(a).Cells(7).Value & "','" & LsData.Rows(a).Cells(8).Value & "'," & NZx(LsData.Rows(a).Cells(12).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(18).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & "," & NZx(LsData.Rows(a).Cells(22).Value) & ",@gopickup,@godrv,@remark,'" & NZx(LsData.Rows(a).Cells(26).Value) & "'," & dtb & "'" & NZx(LsData.Rows(a).Cells(29).Value) & "'," & NZx(LsData.Rows(a).Cells(31).Value) & "," & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ",'" & txtNoBook.Text & "','" & LsData.Rows(a).Cells(43).Value & "'," & NZx(LsData.Rows(a).Cells(40).Value) & "," & (NZx(LsData.Rows(a).Cells(42).Value) * -1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ")"
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
                    If cxField("NoTiket", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(3).Value & "'") = 1 Then
                        Dim gx = GetField("Total", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(3).Value & "'")
                        Dim NC = GetField("NoCollect", "coldtl", "NoTiket='" & LsData.Rows(a).Cells(3).Value & "'")
                        Dim komisi = NZx(LsData.Rows(a).Cells(42).Value) - gx
                        'strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,NoCollect,collect,TotalCollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(3).Value & "','" & LsData.Rows(a).Cells(0).Value & "'," & NZx(LsData.Rows(a).Cells(14).Value) & "," & NZx(LsData.Rows(a).Cells(16).Value) & "," & NZx(LsData.Rows(a).Cells(31).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(33).Value) & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & ",'" & LsData.Rows(a).Cells(37).Value & "','" & LsData.Rows(a).Cells(38).Value & "',1,'" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(5).Value & "'," & NZx(LsData.Rows(a).Cells(8).Value) & ",'" & LsData.Rows(a).Cells(6).Value & "','" & LsData.Rows(a).Cells(7).Value & "'," & NZx(LsData.Rows(a).Cells(11).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(17).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(19).Value) & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & ",'" & LsData.Rows(a).Cells(23).Value & "','" & LsData.Rows(a).Cells(24).Value & "','" & LsData.Rows(a).Cells(40).Value & "','" & LsData.Rows(a).Cells(25).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(28).Value & "'," & NZx(LsData.Rows(a).Cells(30).Value) & "," & Mid(LsData.Rows(a).Cells(10).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(41).Value) & ",'" & txtNoBook.Text & "','" & Mid(cbotipe.Text, 1, 2) & "'," & LsData.Rows(a).Cells(39).Value & ",'" & NC & "',1," & gx & "," & komisi & "," & NZx(LsData.Rows(a).Cells(41).Value) & ")"
                        strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,NoCollect,collect,TotalCollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(1).Value & "'," & NZx(LsData.Rows(a).Cells(15).Value) & "," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(32).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & "," & NZx(LsData.Rows(a).Cells(36).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(5).Value & "',@name," & NZx(LsData.Rows(a).Cells(9).Value) & ",'" & LsData.Rows(a).Cells(7).Value & "','" & LsData.Rows(a).Cells(8).Value & "'," & NZx(LsData.Rows(a).Cells(12).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(18).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & "," & NZx(LsData.Rows(a).Cells(22).Value) & ",@gopickup,@godrv,@remark,'" & NZx(LsData.Rows(a).Cells(26).Value) & "'," & dtb & "'" & NZx(LsData.Rows(a).Cells(29).Value) & "'," & NZx(LsData.Rows(a).Cells(31).Value) & "," & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ",'" & txtNoBook.Text & "','" & LsData.Rows(a).Cells(43).Value & "'," & LsData.Rows(a).Cells(40).Value & ",'" & NC & "',1," & gx & "," & komisi & "," & NZx(LsData.Rows(a).Cells(42).Value) & ")"
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
                        strVal = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi,sisa) values ('" & txtNoBook.Text & "-" & b & "','" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(1).Value & "'," & NZx(LsData.Rows(a).Cells(15).Value) & "," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(32).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & "," & NZx(LsData.Rows(a).Cells(36).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(5).Value & "',@name," & NZx(LsData.Rows(a).Cells(9).Value) & ",'" & LsData.Rows(a).Cells(7).Value & "','" & LsData.Rows(a).Cells(8).Value & "'," & NZx(LsData.Rows(a).Cells(12).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(18).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & "," & NZx(LsData.Rows(a).Cells(22).Value) & ",@gopickup,@godrv,@remark,'" & LsData.Rows(a).Cells(26).Value & "'," & dtb & "'" & LsData.Rows(a).Cells(29).Value & "'," & NZx(LsData.Rows(a).Cells(31).Value) & "," & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ",'" & txtNoBook.Text & "','" & LsData.Rows(a).Cells(43).Value & "'," & NZx(LsData.Rows(a).Cells(40).Value) & "," & (NZx(LsData.Rows(a).Cells(42).Value) * -1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ")"
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
                If LsData.Rows(a).Cells(4).Value <> "-" Then
                    strSql = "update ticket set AgentID='" & LsData.Rows(a).Cells(4).Value & "',stats=2 where NoTiket='" & LsData.Rows(a).Cells(4).Value & "' "
                    cmd = New MySqlCommand(strSql, conn)
                    cmd.ExecuteScalar()
                End If
                FillLog(usr, " Add New Booking", " No.Etiket=" & txtNoBook.Text & "-" & b & ", No.Tiket:" & LsData.Rows(a).Cells(4).Value & "", "", "")
                Call DisconnectDatabase()
            Catch ex As SqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try

        Next

       
        'FillLog(usr, "Add Booking" & txtNoBook.Text)
        Call ConnectDatabase()
        Dim cmds As MySqlCommand

        strSql = "UPDATE booking SET TOTAL=" & Total & " WHERE NoBooking= '" & txtNoBook.Text & "'"

        cmds = New MySqlCommand(strSql, conn)
        cmds.ExecuteScalar()
        Call DisconnectDatabase()

        Select Case level
            Case "1" '''Administrator
                fillData(txtNoBook.Text, "frmAdmin")
            Case "2" '''Accounting
                fillData(txtNoBook.Text, "frmAdmin")
            Case "3" '''AdminReservasi
                fillData(txtNoBook.Text, "frmAdminRes")
            Case "4" ''''Reservasi
                fillData(txtNoBook.Text, "frmAdminres")
            Case "5" '''Sales
                fillData(txtNoBook.Text, "frmAdmins")
        End Select
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
            GroupBox4.Enabled = False
            txtNoBook.ReadOnly = True
            txtttltiket.ReadOnly = True
            txttgltrans.ReadOnly = True

        Else
            Me.Close()
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
        surcharge(txtbackdate.Value.Day, txtbackdate.Value.Month, rutesas(0), txtbackdate.Text, "Back")
        'If surchargeb <> "" Then
        '    valid(txtbackdate.Text, rutesas(0), "Back")
        '    If validb <> "" Then
        '        Name = "SurCharge"
        '        Dim adl = GetField("Adult", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '        Dim chd = GetField("Child", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '        Dim Inf = GetField("Inf", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '        Dim foc = GetField("FOC", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '        Dim sur = GetField("Surcharge", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '        LsBack.Rows.Add(Name, adl, chd, Inf, foc, sur)
        '    End If
        'End If
        promo(txtbackdate.Text, rutesas(0), "Back")
        'If promob <> "" Then
        '    Name = "promo"
        '    Dim adlb = GetField("Adl", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '    Dim chdb = GetField("Chd", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '    Dim Infb = GetField("Infant", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '    Dim focb = GetField("FOC", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '    Dim surb = 0
        '    LsBack.Rows.Add(Name, adlb, chdb, Infb, focb, surb)
        'End If
        spevent(txtbackdate.Text, txtagentid.Text, "Back")
        'If SPb <> "" Then
        '    Name = "Special Event"
        '    Dim adlsa = GetField("Adl", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPb & "'")
        '    Dim chdsa = GetField("Chd", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPb & "'")
        '    Dim Infsa = GetField("Infant", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPb & "'")
        '    Dim focsa = GetField("FOC", "specialdtl", "AgentID='" & txtagentid.Text & "'  and Date='" & Str2Date(txtgodate.Text) & "' and NoEvent='" & SPb & "'")
        '    Dim sura = 0
        '    LsBack.Rows.Add(Name, adlsa, chdsa, Infsa, focsa, sura)
        'End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtgodate.CustomFormat = " "
        txtgodate.Format = DateTimePickerFormat.Custom
        ''txtgodate.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtbackdate.CustomFormat = " "
        txtbackdate.Format = DateTimePickerFormat.Custom
        ''txtbackdate.Text = ""
    End Sub

    Private Sub cboGotrip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGotrip.LostFocus
        If cboGotrip.Text = "" Then
            cboGotrip.Text = ""
            'cboGotrip.SelectedItem("TripID").ToString() = ""
            cboGotrip.SelectedIndex = -1
        End If
    End Sub


    Private Sub cboGotrip_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGotrip.SelectedValueChanged
        'If cboGotrip.Text = "" Then
        '    cboGotrip.SelectedItem("TripID") = -1
        '    'cboGotrip.SelectedItem("TripID").ToString() = ""
        'End If
    End Sub

    Private Sub cboGorute_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGorute.SelectedValueChanged
        'If cboGorute.Text = "" Then
        '    cboGorute.Text = ""
        '    'cboGorute.SelectedItem("RuteID") = ""
        'End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clrs()
    End Sub

    Private Sub cmdAgent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgent.Click
        frmagentlist.Show()
        frmagentlist.forms = "Booking"
        'Me.Hide()
    End Sub

    Private Sub txtagent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtagent.TextChanged

        'fillprice()
    End Sub

    Private Sub LsGo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsGo.CellClick
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
                txtextrago.Text = 0
            Case "4" ''''Reservasi
                txtgorate.Text = LsGo.CurrentRow.Cells(4).Value
                txtextrago.Text = 0
        End Select
    End Sub

    ''Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    ''End Sub

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
                txtextrago.Text = 0
            Case "4" ''''Reservasi
                txtgorate.Text = LsGo.CurrentRow.Cells(4).Value
                txtextrago.Text = 0
        End Select
    End Sub

    Private Sub LsBack_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsBack.CellClick
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
                txtexback.Text = 0
            Case "4" ''''Reservasi
                txtbackrate.Text = LsBack.CurrentRow.Cells(4).Value
                txtexback.Text = 0
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
                txtexback.Text = 0
            Case "4" ''''Reservasi
                txtbackrate.Text = LsBack.CurrentRow.Cells(4).Value
                txtexback.Text = 0
        End Select
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

    
    Private Sub txtagent_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtagent.TextChanged

    End Sub

    
End Class