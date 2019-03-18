Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmEditBookingAgent
    Public disables As Boolean
    Public cprice As Boolean
    Dim ttl As Integer
    Dim valida, validb As String
    Dim promoa, promob As String
    Dim surchargeg, surchargeb
    Dim oagent, otipe, otitle, oname, oidtipe, oidno, oguest, oremark, ocountry, odate1, odate2, orute1, orute2, otrip1, otrip2, oarea1, oarea2, orate1, orate2, oext1, oext2, otrans1, otrans2, otransrate1, otransrate2, oextrans1, oextrans2, opick1, opick2, odrv1, odrv2, ototal, oqty As String
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
    Sub filldata()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        Dim strqry As String
        strqry = "SELECT 0 as ID, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, tiketdtl.GuestID, tiketdtl.GuestIDNO, tiketdtl.Country, IF(tiketdtl.Country='','',(SELECT country.CountryName FROM country WHERE country.CountryID=tiketdtl.Country)) AS CountryName, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC,tiketdtl.GoRuteID, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate, tiketdtl.GoTrip, trip.TripName , tiketdtl.GoRate , tiketdtl.GoExtra, IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, tiketdtl.GoTranRate, tiketdtl.GoTransExtra, tiketdtl.GoArea, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS DepartPickupArea, tiketdtl.GoPickUp AS PickupLocation, tiketdtl.GoDriver, tiketdtl.BackRuteID, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate, tiketdtl.TripBack, IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, tiketdtl.BackRate, tiketdtl.BackExtra, IF(tiketdtl.BackTrans=0,'No','Yes') AS Transport, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, tiketdtl.BackArea, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.BACKArea)) AS ArrivalPickupArea, tiketdtl.BackPickup AS DepartPickupLocation, tiketdtl.BackDriver, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.Tipe, tiketdtl.NoTiket FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE NoEtiket='" & txtetiket.Text & "'"
        da = New MySqlDataAdapter(strqry, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        Call DisconnectDatabase()
        Dim GST As String = ""
        txtNoBook.Text = GetField("NoBook", "tiketdtl", "NoEtiket='" & txtetiket.Text & "'")
        'txtetiket.Text = LsData.CurrentRow.Cells(1).Value
        txttiket.Text = LsData.CurrentRow.Cells(2).Value
        If IsDBNull(LsData.CurrentRow.Cells(4).Value) Then
            otitle = ",mrs=''"
        Else
            cbomrs.Text = LsData.CurrentRow.Cells(4).Value
            otitle = ",mrs='" & LsData.CurrentRow.Cells(4).Value & "'"
        End If

        txtagent.Text = LsData.CurrentRow.Cells(3).Value
        txtagentid.Text = GetField("AgentID", "tiketdtl", "NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'")
        oagent = " ,agentID='" & txtagentid.Text & "'"
        txtName.Text = LsData.CurrentRow.Cells(5).Value
        oname = ",Name='" & LsData.CurrentRow.Cells(5).Value & "'"
        If IsDBNull(LsData.CurrentRow.Cells(7).Value) Then
            oqty = ",GuestID=''"
        Else
            cbotipeID.Text = LsData.CurrentRow.Cells(7).Value
            oqty = ",GuestID='" & LsData.CurrentRow.Cells(7).Value & "'"
        End If

        If IsDBNull(LsData.CurrentRow.Cells(8).Value) Then
            oidno = ",GuestNoID=''"
        Else
            txtnoID.Text = LsData.CurrentRow.Cells(8).Value
            oidno = ",GuestNoID='" & LsData.CurrentRow.Cells(8).Value & "'"
        End If
        If IsDBNull(LsData.CurrentRow.Cells(10).Value) Then
            ocountry = ",Country=''"
        Else
            cboCountry.Text = LsData.CurrentRow.Cells(10).Value
            ocountry = ",Country='" & LsData.CurrentRow.Cells(8).Value & "'"
        End If
        If LsData.CurrentRow.Cells(46).Value = "RT" Then
            cbotipe.Text = "RT - Return"
        Else
            cbotipe.Text = "OW - One Way"
        End If
        If LsData.CurrentRow.Cells(11).Value > 0 Then
            GST = "1 - Adult"
            oqty = ",QtyTipe=1"
        End If
        If LsData.CurrentRow.Cells(12).Value > 0 Then
            GST = "2 - Child"
            oqty = ",QtyTipe=2"
        End If
        If LsData.CurrentRow.Cells(13).Value > 0 Then
            GST = "3 - Infant"
            oqty = ",QtyTipe=3"
        End If
        If LsData.CurrentRow.Cells(14).Value > 0 Then
            GST = "4 - FOC"
            oqty = ",QtyTipe=4"
        End If
        cboGst.Text = GST
        cboGorute.Text = LsData.CurrentRow.Cells(15).Value & " - " & LsData.CurrentRow.Cells(16).Value
        orute1 = ",GoRuteID=" & LsData.CurrentRow.Cells(15).Value
        txtgodate.Text = LsData.CurrentRow.Cells(17).Value
        odate1 = ",Godate='" & Str2Date(txtgodate.Text) & "'"
        cboGotrip.Text = LsData.CurrentRow.Cells(19).Value
        otrip1 = ",GoTrip=" & LsData.CurrentRow.Cells(19).Value
        txtgorate.Text = LsData.CurrentRow.Cells(20).Value
        orate1 = ",GoRate=" & LsData.CurrentRow.Cells(20).Value
        If IsDBNull(LsData.CurrentRow.Cells(21).Value) Then
            oext1 = ",GoExtra=0"
        Else
            txtextrago.Text = LsData.CurrentRow.Cells(21).Value
            oext1 = ",GoExtra=" & LsData.CurrentRow.Cells(21).Value
        End If
        If LsData.CurrentRow.Cells(22).Value = "Yes" Then
            otrans1 = ",GoTrans=1"
            CxGoTrans.CheckState = CheckState.Checked
        Else
            CxGoTrans.CheckState = CheckState.Unchecked
            otrans1 = ",GoTrans=0"
        End If
        If IsDBNull(LsData.CurrentRow.Cells(23).Value) Then
            otransrate1 = ",GotranRate=0"
        Else
            txttransgorate.Text = LsData.CurrentRow.Cells(23).Value
            otransrate1 = ",GotranRate=" & LsData.CurrentRow.Cells(23).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(24).Value) Then
            oextrans1 = ", GoTransExtra=0"
        Else
            txtgoextra.Text = LsData.CurrentRow.Cells(24).Value
            oextrans1 = ", GoTransExtra=" & LsData.CurrentRow.Cells(24).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(26).Value) Then
            oarea1 = ",GoArea=0"
        Else
            cboGoArea.Text = LsData.CurrentRow.Cells(26).Value
            oarea1 = ",GoArea=" & LsData.CurrentRow.Cells(26).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(27).Value) Then
            opick1 = ",GoPickup=''"
        Else
            txtpickupgo.Text = LsData.CurrentRow.Cells(27).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(28).Value) Then
        Else
            txtdrivego.Text = LsData.CurrentRow.Cells(28).Value
            opick1 = ",GoPickup='" & LsData.CurrentRow.Cells(28).Value & "'"
        End If
        cboruteback.Text = LsData.CurrentRow.Cells(29).Value & " - " & LsData.CurrentRow.Cells(30).Value
        If IsDBNull(LsData.CurrentRow.Cells(31).Value) = True Or (LsData.CurrentRow.Cells(31).Value = "") Then
            odate2 = ",BackDate=NULL"
            txtbackdate.CustomFormat = " "
            txtbackdate.Format = DateTimePickerFormat.Custom
        Else
            Dim xs As String = LsData.CurrentRow.Cells(31).Value
            If xs.IndexOf("-") > -1 Then
                odate2 = ",BackDate='" & (LsData.CurrentRow.Cells(31).Value) & "'"
                txtbackdate.Text = LsData.CurrentRow.Cells(31).Value
            Else
                odate2 = ",BackDate='" & Str2Date(LsData.CurrentRow.Cells(31).Value) & "'"
                txtbackdate.Text = LsData.CurrentRow.Cells(31).Value
            End If


        End If
        'frmEditBooking.txtbackdate.Text = LsData.CurrentRow.Cells(29).Value
        If IsDBNull(LsData.CurrentRow.Cells(33).Value) Then
            otrip2 = ",TripBack=0"
        Else
            cbotripback.Text = LsData.CurrentRow.Cells(33).Value
            otrip2 = ",TripBack=" & LsData.CurrentRow.Cells(33).Value
        End If
        txtbackrate.Text = LsData.CurrentRow.Cells(34).Value
        orate2 = ", BackRate=" & LsData.CurrentRow.Cells(34).Value
        txtexback.Text = LsData.CurrentRow.Cells(35).Value
        oext2 = ", BackExtra=" & LsData.CurrentRow.Cells(35).Value
        If LsData.CurrentRow.Cells(36).Value = "Yes" Then
            otrans2 = ",BackTrans=1"
            CxBackTrans.CheckState = CheckState.Checked
        Else
            CxBackTrans.CheckState = CheckState.Unchecked
            otrans2 = ",BackTrans=0"
        End If
        txttransbackrate.Text = LsData.CurrentRow.Cells(37).Value
        otransrate2 = " ,BackTransRate=" & LsData.CurrentRow.Cells(37).Value
        If IsDBNull(LsData.CurrentRow.Cells(38).Value) Then
            oextrans2 = ",BackTransExtra=0"
        Else
            txtbackExtra.Text = LsData.CurrentRow.Cells(38).Value
            oextrans2 = ",BackTransExtra=" & LsData.CurrentRow.Cells(38).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(40).Value) Then
            oarea2 = ",BackArea=0"
        Else
            oarea2 = ",BackArea=" & LsData.CurrentRow.Cells(40).Value
            cboBackArea.Text = LsData.CurrentRow.Cells(40).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(41).Value) Then
            opick2 = ", BackPicup=''"
        Else
            txtPickupBack.Text = LsData.CurrentRow.Cells(41).Value
            opick2 = ", BackPicup='" & LsData.CurrentRow.Cells(41).Value & "'"
        End If
        If IsDBNull(LsData.CurrentRow.Cells(42).Value) Then
            odrv2 = ", BackDriver=''"
        Else
            odrv2 = ", BackDriver='" & LsData.CurrentRow.Cells(42).Value & "'"
            txtbackDrive.Text = LsData.CurrentRow.Cells(42).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(43).Value) Then
        Else
            txtremark.Text = LsData.CurrentRow.Cells(43).Value
        End If

        txtcollect.Text = GetField("reqcollect", "tiketdtl", "NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'")

    End Sub
    Sub valid(ByVal dates As String, ByVal rutes As Integer, ByVal stx As String)

        If stx = "Go" Then
            'If txtgodate.Text = "" Then
            '    MsgBox("Depart Date is empty, Please fill Depart Date", vbInformation, "Error Booking")
            '    Exit Sub
            'End If
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
    Sub surcharge(ByVal days, ByVal mons, ByVal RUTES, ByVal dates, ByVal stat)
        'Sub surcharge(ByVal days, ByVal mons, ByVal stat)
        'If stat = "Go" Then
        '    If txtgodate.Text = "" Then
        '        MsgBox("Depart Date is empty, Please fill Depart Date", vbInformation, "Error Booking")
        '        Exit Sub
        '    End If
        '    If cboGorute.Text = "" Then
        '        MsgBox("Depart Rute is empty, Please fill Depart Rute", vbInformation, "Error Booking")
        '        Exit Sub
        '    End If
        '    If txtagentid.Text = "" Then
        '        MsgBox("Agent is empty, Please Select An Agent", vbInformation, "Error Booking")
        '        Exit Sub
        '    End If
        '    Call ConnectDatabase()
        '    Try

        '        Dim strSql As String
        '        Dim x As Integer
        '        x = Len(mons.ToString)
        '        If Len(days.ToString) = 1 Then
        '            days = numx(days, 2)
        '        End If
        '        If Len(mons.ToString) = 1 Then
        '            mons = numx(mons, 2)
        '        End If
        '        strSql = "select ID from `surchargedtl` where day='" & days & "' and mon='" & mons & "' "
        '        Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
        '        Dim reader As MySqlDataReader = Comd.ExecuteReader
        '        While (reader.Read)
        '            surchargeg = reader("ID").ToString()
        '        End While
        '        Call DisconnectDatabase()
        '    Catch ex As MySqlException
        '        MsgBox(ex.Message)
        '    Finally
        '        ' Close connection
        '        Call DisconnectDatabase()
        '    End Try
        'ElseIf stat = "back" Then
        '    If txtbackdate.Text = "" Then
        '        Exit Sub
        '    End If
        '    If cboGorute.Text = "" Then
        '        MsgBox("Return Rute is empty, Please fill Depart Rute", vbInformation, "Error Booking")
        '        Exit Sub
        '    End If
        '    If txtagentid.Text = "" Then
        '        MsgBox("Agent is empty, Please Select An Agent", vbInformation, "Error Booking")
        '        Exit Sub
        '    End If
        '    Call ConnectDatabase()
        '    Try

        '        Dim strSql As String
        '        Dim x As Integer
        '        x = Len(mons.ToString)
        '        If Len(days.ToString) = 1 Then
        '            days = numx(days, 2)
        '        End If
        '        If Len(mons.ToString) = 1 Then
        '            mons = numx(mons, 2)
        '        End If
        '        strSql = "select ID from `surchargedtl` where day='" & days & "' and mon='" & mons & "' "
        '        Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
        '        Dim reader As MySqlDataReader = Comd.ExecuteReader
        '        While (reader.Read)
        '            surchargeb = reader("ID").ToString()
        '        End While
        '        Call DisconnectDatabase()
        '    Catch ex As MySqlException
        '        MsgBox(ex.Message)
        '    Finally
        '        ' Close connection
        '        Call DisconnectDatabase()
        '    End Try

        'End If
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
                strSql = "select * from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & RUTES & " and Enddate>='" & Str2Date(dates) & "' order by RateID desc limit 0,1"
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
                MsgBox("Return Rute is empty, Please fill Return Rute", vbInformation, "Error Booking")
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
                strSql = "select * from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & RUTES & " and Enddate>='" & Str2Date(dates) & "' order by RateID desc limit 0,1"
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
                    'fillcontract(Format(Now, "dd/MM/yyyy"), RuteID, "Go")
                    If txtgodate.Text = "" Then
                        fillcontract(Format(Now, "dd/MM/yyyy"), RuteID, "Go")
                    Else
                        fillcontract(txtgodate.Text, RuteID, "Go")
                    End If
                    'name = "Contract"
                    'adl = GetField("Adult", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    'chd = GetField("Child", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    'Inf = GetField("Inf", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    'foc = GetField("FOC", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    'LsGo.Rows.Add(name, adl, chd, Inf, foc, sur)
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
                    'fillcontract(Format(Now, "dd/MM/yyyy"), RuteID, "Back")
                    If txtgodate.Text = "" Then
                        fillcontract(Format(Now, "dd/MM/yyyy"), RuteID, "Back")
                    Else
                        fillcontract(txtgodate.Text, RuteID, "Back")
                    End If
                    'name = "Contract"
                    'adl = GetField("Adult", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    'chd = GetField("Child", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    'Inf = GetField("Inf", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    'foc = GetField("FOC", "agentratedtl", "RuteID=" & RuteID & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    'LsBack.Rows.Add(name, adl, chd, Inf, foc, sur)
                End If
            End If
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
                strSql = "select * from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & rutes & " and Enddate>='" & Str2Date(dates) & "' and StartDate<='" & Str2Date(dates) & "'  ORDER BY RateID DESC LIMIT 0,1 "
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

    'Sub cxtiket()
    '    Call ConnectDatabase()
    '    Dim da As MySqlDataAdapter
    '    Dim dt As DataTable
    '    da = New MySqlDataAdapter("select AgentID from ticket where NoTiket between '" & txtetiket.Text & "' and '" & txt.Text & "' group by AgentID", conn)
    '    dt = New DataTable
    '    dt.Rows.Clear()
    '    da.Fill(dt)
    '    ttl = dt.Rows.Count
    '    Call DisconnectDatabase()
    'End Sub
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

    Private Sub frmEditBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If txtNoBook.Text = "" Then
        'Me.Close()
        ' Else
        'cboGst.Text = "1 - Adult"
        filltransport()
        filltrip()
        fillRute()
        fillarea()
        fillCountry()
        filldata()

        'disabling(disables)

        If cbotipe.Text = "OW - One Way" Then
            GroupBox4.Enabled = False
            GroupBox6.Enabled = False
        Else
            GroupBox4.Enabled = True
            GroupBox6.Enabled = True
        End If
        txtNoBook.ReadOnly = True
        txttgltrans.ReadOnly = True
        txtetiket.ReadOnly = True
        'ArData(txtNoBook.Text)
        ' End If
        If cprice = False Then
            LsGo.Enabled = False
            LsBack.Enabled = False
        Else
            LsGo.Enabled = True
            LsBack.Enabled = True
        End If
    End Sub
    Sub disabling(ByVal disables)

        txtagent.Enabled = disables
        txtagentid.Enabled = disables
        cbotipe.Enabled = disables
        CxOpen.Enabled = disables
        txttiket.Enabled = disables
        cbomrs.Enabled = disables
        txtName.Enabled = disables
        cbotipeID.Enabled = disables
        txtnoID.Enabled = disables
        cboCountry.Enabled = disables
        cboGst.Enabled = disables
        txtremark.Enabled = disables
        cmdSave.Enabled = disables
        GroupBox4.Enabled = disables
        GroupBox6.Enabled = disables
        GroupBox4.Enabled = disables
        GroupBox6.Enabled = disables
        txtcollect.Enabled = disables
    End Sub
    Private Sub cbotipe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotipe.SelectedIndexChanged
        If Mid(cbotipe.Text, 1, 2) = "RT" Then
            GroupBox4.Enabled = True
            'GroupBox6.Enabled = True
        Else
            GroupBox4.Enabled = False
            GroupBox6.Enabled = False
            cboruteback.Text = ""
            txtbackdate.Format = DateTimePickerFormat.Custom
            txtbackdate.CustomFormat = " "
            cbotripback.Text = ""
            txtbackrate.Text = 0
            txtexback.Text = 0
            txttransbackrate.Text = 0
            txtbackDrive.Text = ""
            txtPickupBack.Text = ""
            cboBackArea.Text = ""
            txtbackExtra.Text = ""
            CxBackTrans.Checked = CheckState.Unchecked

        End If
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (MsgBox("Discart Chang and Close?", vbYesNo, "Close Form")) = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub cboGorute_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGorute.SelectedIndexChanged
        'If cboGorute.Text <> "" Then
        '    Dim rutesa As String = cboGorute.Text
        '    Dim rutesas = rutesa.Split(New Char() {" - "})
        '    fillpublishrate(rutesas(0), "Go")
        '    If txtgodate.Text <> "" Then
        '        Dim rutes As String = cboGorute.Text
        '        Dim rutesl = rutes.Split(New Char() {" - "})

        '        If cboGorute.Text <> "" Then

        '            fillpublishrate(rutesl(0), "Go")
        '        End If
        '        txtgodate.Format = DateTimePickerFormat.Custom
        '        txtgodate.CustomFormat = "dd/MM/yyyy"
        '        If Trim(txtgodate.Text) = "" Then
        '            Exit Sub
        '        End If
        '        surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
        '        If surchargeg <> "" Then
        '            valid(txtgodate.Text, rutesl(0), "Go")
        '            If valida <> "" Then
        '                Name = "SurCharge"
        '                Dim adl = GetField("Adult", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '                Dim chd = GetField("Child", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '                Dim Inf = GetField("Inf", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '                Dim foc = GetField("FOC", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '                Dim sur = GetField("Surcharge", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '                LsGo.Rows.Add(Name, adl, chd, Inf, foc, sur)
        '            End If
        '        End If
        '        'promo(txtgodate.Text, cboGorute.SelectedItem("RuteID"), "Go")
        '        promo(txtgodate.Text, rutesl(0), "Go")
        '        If promoa <> "" Then
        '            Name = "promo"
        '            Dim adla = GetField("Adl", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '            Dim chda = GetField("Chd", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '            Dim Infa = GetField("Infant", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '            Dim foca = GetField("FOC", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '            Dim sura = 0
        '            LsGo.Rows.Add(Name, adla, chda, Infa, foca, sura)
        '        End If
        '    End If
        'End If
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

        surcharge(txtgodate.Value.Day, txtgodate.Value.Month, rutesl(0), txtgodate.Text, "Go")

        promo(txtgodate.Text, rutesl(0), "Go")

        spevent(txtgodate.Text, txtagentid.Text, "Go")
    End Sub


    Private Sub cboGst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboruteback_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboruteback.SelectedIndexChanged
        'If cboruteback.Text <> "" Then
        '    Dim rutesa As String = cboGorute.Text
        '    Dim rutesas = rutesa.Split(New Char() {" - "})
        '    fillpublishrate(rutesas(0), "Go")
        '    If txtbackdate.Text <> "" Then
        '        Dim rutes As String = cboruteback.Text
        '        Dim rutesl = rutes.Split(New Char() {" - "})

        '        If cboruteback.Text <> "" Then

        '            fillpublishrate(rutesl(0), "Back")
        '        End If
        '        'txtbackdate.Format = DateTimePickerFormat.Custom
        '        'txtbackdate.CustomFormat = "dd/MM/yyyy"
        '        If Trim(txtbackdate.Text) = "" Then
        '            Exit Sub
        '        End If
        '        surcharge(txtbackdate.Value.Day, txtbackdate.Value.Month, "Back")
        '        If surchargeg <> "" Then
        '            valid(txtbackdate.Text, rutesl(0), "Go")
        '            If valida <> "" Then
        '                Name = "SurCharge"
        '                Dim adl = GetField("Adult", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '                Dim chd = GetField("Child", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '                Dim Inf = GetField("Inf", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '                Dim foc = GetField("FOC", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '                Dim sur = GetField("Surcharge", "agentratedtl", "RuteID=" & rutesl(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '                LsBack.Rows.Add(Name, adl, chd, Inf, foc, sur)
        '            End If
        '        End If
        '        'promo(txtgodate.Text, cboGorute.SelectedItem("RuteID"), "Go")
        '        promo(txtbackdate.Text, rutesl(0), "Go")
        '        If promob <> "" Then
        '            Name = "promo"
        '            Dim adla = GetField("Adl", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & promob & "'")
        '            Dim chda = GetField("Chd", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & promob & "'")
        '            Dim Infa = GetField("Infant", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & promob & "'")
        '            Dim foca = GetField("FOC", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & promob & "'")
        '            Dim sura = 0
        '            LsBack.Rows.Add(Name, adla, chda, Infa, foca, sura)
        '        End If
        '    End If
        'End If
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

        promo(txtbackdate.Text, rutesas(0), "Back")

        spevent(txtbackdate.Text, txtagentid.Text, "Back")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim agent, tipe, title, name, idtipe, idno, guest, remark, country, date1, date2, rute1, rute2, trip1, trip2, area1, area2, rate1, rate2, ext1, ext2, trans1, trans2, transrate1, transrate2, extrans1, extrans2, pick1, pick2, drv1, drv2, total, colls, komis, sis As String
        Dim komisi
        Dim sisa
        Dim x As Boolean = False


        'If cboAgent.Text = "" Then
        '    MsgBox("Please Choose Agent!", vbInformation, "Ticket Error")
        '    Exit Sub
        'Else
        '    agent = ", AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "'"
        'End If
        If txtagentid.Text = "" Then
            MsgBox("Please Choose Agent!", vbInformation, "Ticket Error")
            Exit Sub
        Else
            agent = ", AgentID='" & txtagentid.Text & "'"
        End If
        If cbotipe.Text = "" Then
            MsgBox("Please Choose Ticket Type!", vbInformation, "Ticket Error")
            Exit Sub
        Else
            tipe = ", Tipe='" & Mid(cbotipe.Text, 1, 2) & "'"
        End If
        If Trim(txtgodate.Text) = "" Then
            MsgBox("Please Fill Departure Date!", vbInformation, "Ticket Error")
            Exit Sub
        Else
            date1 = ",GoDate='" & Str2Date(txtgodate.Text) & "'"
        End If

        If cbomrs.Text = "" Then
            title = ""
        Else
            title = ", mrs='" & cbomrs.Text & "'"
        End If
        If txtName.Text = "" Then
            name = ""
        Else
            'name = ", Guest='" & txtName.Text & "'"
            name = ", Guest=@name"
        End If
        If cbotipeID.Text = "" Then
            idtipe = ""
        Else
            idtipe = ", GuestID='" & cbotipeID.Text & "'"
        End If
        If txtnoID.Text = "" Then
            idno = ""
        Else
            idno = ", GuestIDNO='" & txtnoID.Text & "'"
        End If
        If txtcollect.Text = "" Or txtcollect.Text = "0" Then
            colls = ""
        Else
            colls = ", ReqCollect=" & txtcollect.Text
        End If
        If txtremark.Text = "" Then
            remark = ""
        Else
            remark = ", remark=@remark"
        End If
        If cboGst.Text = "" Then
            guest = ""
            MsgBox("Please Fill Guest", vbInformation, "ErrorEdit")
            Exit Sub
        Else
            Select Case Mid(cboGst.Text, 1, 1)
                Case "1"
                    guest = ", Qty=1, QtyTipe=1"
                Case "2"
                    guest = ", Qty=1, QtyTipe=2"
                Case "3"
                    guest = ", Qty=1, QtyTipe=3"
                Case "4"
                    guest = ", Qty=1, QtyTipe=4"
            End Select

        End If
        If cboCountry.Text = "" Then
            country = ""
        Else
            country = ", Country=" & cboCountry.SelectedItem("CountryID").ToString
        End If
        If txtgorate.Text = "" Then
            rate1 = ", Gorate=0"
        Else
            rate1 = ", Gorate=" & txtgorate.Text
        End If

        If txtextrago.Text = "" Then
            ext1 = ",GoExtra=0"
        Else
            ext1 = ", GoExtra=" & txtextrago.Text
        End If
        If CxGoTrans.CheckState = CheckState.Checked Then
            trans1 = ", GoTrans=1"
        Else
            trans1 = ", Gotrans=0"
        End If
        If txttransgorate.Text = "" Then
            transrate1 = ", GoTranRate=0"
        Else
            transrate1 = ", GoTranRate=" & txttransgorate.Text
        End If
        If txtgoextra.Text = "" Then
            extrans1 = ", GoTransExtra=0"
        Else
            extrans1 = ", GoTransExtra=" & txtgoextra.Text
        End If
        If txtpickupgo.Text = "" Then
            pick1 = ""
        Else
            'pick1 = ", GoPickUp='" & txtpickupgo.Text & "'"
            pick1 = ", GoPickUp=@gopick"
        End If

        If txtbackrate.Text = "" Then
            rate2 = ",BackRate=0"
        Else
            rate2 = ", backRate=" & txtbackrate.Text
        End If
        If txtexback.Text = "" Then
            ext2 = ", BackExtra=0"
        Else
            ext2 = ", BackExtra=" & txtexback.Text
        End If

        If CxBackTrans.CheckState = CheckState.Checked Then
            trans2 = ", BackTrans=1"
        Else
            trans2 = ", Backtrans=0"
        End If

        If txttransbackrate.Text = "" Then
            transrate2 = ", BackTransRate=0"
        Else
            transrate2 = ", BackTransRate=" & txttransbackrate.Text
        End If

        If txtbackExtra.Text = "" Then
            extrans2 = ", BackTransExtra=0"
        Else
            extrans2 = ", BackTransExtra=" & txtbackExtra.Text
        End If

        If txtPickupBack.Text = "" Then
            pick2 = ""
        Else
            'pick2 = ", BackPickUp='" & txtpickupgo.Text & "'"
            pick2 = ", BackPickUp=@backpick"
        End If

        If txtdrivego.Text = "" Then
            drv1 = ""
        Else
            'drv1 = ", GoDriver='" & txtdrivego.Text & "'"
            drv1 = ", GoDriver=@godrv"
        End If

        If txtbackDrive.Text = "" Then
            drv2 = ""
        Else
            'drv2 = ", BackDriver='" & txtbackDrive.Text & "'"
            drv2 = ", BackDriver=@backdrv"
        End If

        If Trim(txtbackdate.Text) = "" Then
            If cbotipe.Text = "RT - Return" Then
                If CxOpen.CheckState = CheckState.Checked Then
                    date2 = ",BackDate=NULL"
                Else
                    MsgBox("Please Fill Return Date", vbInformation, "Return Date is Empty")
                    Exit Sub
                End If
            Else
                date2 = ",BackDate=NULL"
            End If

        Else
            date2 = ",BackDate='" & Str2Date(txtbackdate.Text) & "'"
        End If
        If cboruteback.Text = "" Then
            rute2 = ""
            'rute2 = ", BackRuteID=NULL"
            'rute2 = NZx(cboruteback.Text)
        Else
            Dim rutesb As String = cboruteback.Text
            Dim rutesbs = rutesb.Split(New Char() {" - "})
            'rute2 = ",BackRuteID=" & cboruteback.SelectedItem("RuteID").ToString
            rute2 = ",BackRuteID=" & NZx(rutesbs(0))
        End If
        If cboGorute.Text = "" Then
            rute1 = ""
            MsgBox("Please Fill Departure Rute", vbInformation, "Departure Rute Empty")
            Exit Sub
        Else
            Dim rutesa As String = cboGorute.Text
            Dim rutesas = rutesa.Split(New Char() {" - "})
            'rute2 = ",BackRuteID=" & cboruteback.SelectedItem("RuteID").ToString
            rute1 = ", GoRuteID=" & NZx(rutesas(0))
            'rute1 = ", GoRuteID =" & cboGorute.SelectedItem("RuteID").ToString
        End If
        If cboGotrip.Text = "" Then
            trip1 = ""
            MsgBox("Please Fill Departure Trip", vbInformation, "Departure Trip Empty")
            Exit Sub
        Else
            trip1 = ", GoTrip=" & NZx(cboGotrip.SelectedItem("TripID").ToString) & " "
        End If
        If cbotripback.Text = "" Then
            trip2 = ""
            'trip2 = NZx(cbotripback.SelectedItem("TripID").ToString)
        Else
            trip2 = ", TripBack=" & NZx(cbotripback.SelectedItem("TripID").ToString) & ""
        End If
        If cboGoArea.Text = "" Then
            area1 = ""
        Else
            area1 = ", GoArea=" & cboGoArea.SelectedItem("AreaID").ToString
        End If
        If cboBackArea.Text = "" Then
            area2 = ""
        Else
            area2 = ", BackArea=" & cboBackArea.SelectedItem("AreaID").ToString
        End If
        Dim totals As Double = Val(txtgorate.Text) + Val(txtgoextra.Text) + Val(txtextrago.Text) + Val(txttransgorate.Text) + Val(txtbackrate.Text) + Val(txtbackExtra.Text) + Val(txttransbackrate.Text) + Val(txtexback.Text)
        total = ",Totaljual=" & totals
        Dim cl = GetField("TotalCollect", "tiketdtl", "NoEtiket='" & txtetiket.Text & "'")
        Select Case Mid(cboGst.Text, 1, 1)
            Case 1
                ' If upd <> "" Then
                'ttls = adlg + surg + adlb + surb + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                komisi = NZx(cl) - totals

                If (totals - NZx(cl)) > 0 Then
                    sisa = totals - NZx(cl)
                Else
                    sisa = 0
                End If
                'upd = upd & " , Gorate=" & adlg & ", goextra= " & surg & ", backrate= " & adlb & ", backextra=" & surb & ", TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "
                komis = ", komisi=" & komisi
                sis = ", sisa=" & sisa
                ' End If

            Case 2
                ' If upd <> "" Then
                'ttls = chdg + surg + chdb + surb + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                komisi = NZx(cl) - totals

                If (totals - NZx(cl)) > 0 Then
                    sisa = totals - NZx(cl)
                Else
                    sisa = 0
                End If
                ' upd = upd & " , Gorate=" & chdg & ", goextra= " & surg & ", backrate= " & chdb & ", backextra=" & surb & ", TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "

                komis = ", komisi=" & komisi
                sis = ", sisa=" & sisa
                ' End If
            Case 3
                'If upd <> "" Then
                ' ttls = Infg + surg + Infb + surb + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                komisi = NZx(cl) - totals

                If (totals - NZx(cl)) > 0 Then
                    sisa = totals - NZx(cl)
                Else
                    sisa = 0
                End If
                'pd = upd & " , Gorate=" & Infg & ", goextra= " & surg & ", backrate =" & Infb & ", backextra=" & surb & ", TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "
                komis = ", komisi=" & komisi
                sis = ", sisa=" & sisa

                'End If
            Case 4
                'If upd <> "" Then
                'ttls = focg + surg + focb + surb + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                komisi = NZx(cl) - totals

                If (totals - NZx(cl)) > 0 Then
                    sisa = totals - NZx(cl)
                Else
                    sisa = 0
                End If
                'upd = upd & " , Gorate=" & focg & ", goextra= " & surg & ", backrate= " & focb & ", backextra=" & surb & ", TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "
                komis = ", komisi=" & komisi
                sis = ", sisa=" & sisa

                'End If
        End Select
        If Mid(cbotipe.Text, 1, 2) = "OW" Then
            date2 = ", backdate=null"
            rute2 = ", backruteID=null"
            trip2 = ", TripBack=null"
            area2 = ", backarea=null"
            rate2 = ", BackRate=0"
            ext2 = ", backextra=0"
            trans2 = ", backextra=0"
            transrate2 = ", BackTransRate=0"
            extrans2 = ", backtransextra=0"
            pick2 = ", BackPickup='" & Nothing & "'"
            drv2 = ", Backdriver='" & Nothing & "'"
            totals = Val(txtgorate.Text) + Val(txtgoextra.Text) + Val(txtextrago.Text) + Val(txttransgorate.Text) + Val(txtbackrate.Text)
            total = ",Totaljual=" & totals
            Try
                Call ConnectDatabase()
                Dim cmd As MySqlCommand
                Dim strsql As String

                strsql = "UPDATE tiketdtl set NoTiket='" & txttiket.Text & "'" & agent & tipe & title & name & idtipe & idno & remark & country & date1 & date2 & rute1 & rute2 & trip1 & trip2 & area1 & trans1 & trans2 & area2 & rate1 & rate2 & ext1 & ext2 & trans1 & trans2 & transrate1 & transrate2 & extrans1 & extrans2 & pick1 & pick2 & drv1 & drv2 & total & colls & komis & sis & guest & " where NoETiket='" & txtetiket.Text & "'"

                cmd = New MySqlCommand(strsql, conn)
                cmd.Parameters.AddWithValue("@name", txtName.Text)
                cmd.Parameters.AddWithValue("@gopick", txtpickupgo.Text)
                cmd.Parameters.AddWithValue("@godrv", txtdrivego.Text)
                cmd.Parameters.AddWithValue("@remark", txtremark.Text)
                cmd.ExecuteScalar()
                Dim Oldv = oagent & otipe & otitle & oname & oidtipe & oidno & oguest & oremark & ocountry & odate1 & odate2 & orute1 & orute2 & otrip1 & otrip2 & oarea1 & oarea2 & orate1 & orate2 & oext1 & oext2 & otrans1 & otrans2 & otransrate1 & otransrate2 & oextrans1 & oextrans2 & opick1 & opick2 & odrv1 & odrv2 & ototal & oqty
                Oldv = Replace(Oldv, "'", " ")
                Dim newval = "NoTiket=" & txttiket.Text & "," & agent & tipe & title & ", nAME=" & txtName.Text & ", " & idtipe & idno & ", remark=" & txtremark.Text & ", " & country & date1 & date2 & rute1 & rute2 & trip1 & trip2 & area1 & area2 & rate1 & rate2 & ext1 & ext2 & trans1 & trans2 & transrate1 & transrate2 & extrans1 & extrans2 & guest & ",gOpICKUP " & txtpickupgo.Text & ", bACKpICKUP" & txtPickupBack.Text & ", dRIVERGO=" & txtdrivego.Text & ", dRIVERBACK=" & drv2 & ", " & total & colls & komis & sis & " where NoETiket='" & txtetiket.Text & "'"
                newval = Replace(newval, "'", " ")
                FillLog(usr, "EDIT Ticket", " No. : " & txttiket.Text & " | No.Etiket : " & txtetiket.Text, Oldv, newval)
                Me.Close()
                Call DisconnectDatabase()
            Catch ex As SqlException

                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        Else
            Try
                Call ConnectDatabase()
                Dim cmd As MySqlCommand
                Dim strsql As String

                strsql = "UPDATE tiketdtl set NoTiket='" & txttiket.Text & "'" & agent & tipe & title & name & idtipe & idno & remark & country & date1 & date2 & rute1 & rute2 & trip1 & trip2 & area1 & trans1 & trans2 & area2 & rate1 & rate2 & ext1 & ext2 & trans1 & trans2 & transrate1 & transrate2 & extrans1 & extrans2 & pick1 & pick2 & drv1 & drv2 & total & colls & komis & sis & guest & " where NoETiket='" & txtetiket.Text & "'"

                cmd = New MySqlCommand(strsql, conn)
                cmd.Parameters.AddWithValue("@name", txtName.Text)
                cmd.Parameters.AddWithValue("@gopick", txtpickupgo.Text)
                cmd.Parameters.AddWithValue("@backpick", txtPickupBack.Text)
                cmd.Parameters.AddWithValue("@godrv", txtdrivego.Text)
                cmd.Parameters.AddWithValue("@backdrv", txtbackDrive.Text)
                cmd.Parameters.AddWithValue("@remark", txtremark.Text)
                cmd.ExecuteScalar()
                Dim Oldv = oagent & otipe & otitle & oname & oidtipe & oidno & oguest & oremark & ocountry & odate1 & odate2 & orute1 & orute2 & otrip1 & otrip2 & oarea1 & oarea2 & orate1 & orate2 & oext1 & oext2 & otrans1 & otrans2 & otransrate1 & otransrate2 & oextrans1 & oextrans2 & opick1 & opick2 & odrv1 & odrv2 & ototal & oqty
                Oldv = Replace(Oldv, "'", " ")
                Dim newval = "NoTiket=" & txttiket.Text & "," & agent & tipe & title & ", nAME=" & txtName.Text & ", " & idtipe & idno & ", remark=" & txtremark.Text & ", " & country & date1 & date2 & rute1 & rute2 & trip1 & trip2 & area1 & area2 & rate1 & rate2 & ext1 & ext2 & trans1 & trans2 & transrate1 & transrate2 & extrans1 & extrans2 & ",gOpICKUP " & txtpickupgo.Text & ", bACKpICKUP" & txtPickupBack.Text & ", dRIVERGO=" & txtdrivego.Text & ", dRIVERBACK=" & drv2 & ", " & total & colls & komis & sis & guest & " where NoETiket='" & txtetiket.Text & "'"
                newval = Replace(newval, "'", " ")
                FillLog(usr, "EDIT Ticket", " No. : " & txttiket.Text & " | No.Etiket : " & txtetiket.Text, Oldv, newval)
                Me.Close()
                Call DisconnectDatabase()
            Catch ex As SqlException

                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        End If


    End Sub

    Private Sub txtbackdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub cmdCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

   

    Private Sub txtagent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtagent.TextChanged
        'Dim rutesa As String = cboruteback.Text
        'Dim rutesas = rutesa.Split(New Char() {" - "})
        'If cboruteback.Text <> "" Then
        '    fillpublishrate(rutesas(0), "Back")
        'Else
        '    Exit Sub
        'End If
        'If Trim(txtbackdate.Text) = "" Then
        '    Exit Sub
        'Else



        '    txtbackdate.Format = DateTimePickerFormat.Custom
        '    txtbackdate.CustomFormat = "dd/MM/yyyy"
        '    surcharge(txtbackdate.Value.Day, txtbackdate.Value.Month, "Back")
        '    If surchargeb <> "" Then
        '        valid(txtbackdate.Text, rutesas(0), "Back")
        '        If validb <> "" Then
        '            Name = "SurCharge"
        '            Dim adl = GetField("Adult", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '            Dim chd = GetField("Child", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '            Dim Inf = GetField("Inf", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '            Dim foc = GetField("FOC", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '            Dim sur = GetField("Surcharge", "agentratedtl", "RuteID=" & rutesas(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
        '            LsBack.Rows.Add(Name, adl, chd, Inf, foc, sur)
        '        End If
        '    End If
        '    promo(txtbackdate.Text, rutesas(0), "Back")
        '    If promob <> "" Then
        '        Name = "promo"
        '        Dim adlb = GetField("Adl", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '        Dim chdb = GetField("Chd", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '        Dim Infb = GetField("Infant", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '        Dim focb = GetField("FOC", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '        Dim surb = 0
        '        LsBack.Rows.Add(Name, adlb, chdb, Infb, focb, surb)
        '    End If
        'End If
        'Dim rutesB As String = cboGorute.Text
        'Dim rutesBs = rutesa.Split(New Char() {" - "})
        'If cboGorute.Text <> "" Then
        '    fillpublishrate(rutesBs(0), "Go")
        'End If
        'If Trim(txtgodate.Text) = "" Then
        '    Exit Sub
        'Else



        '    txtgodate.Format = DateTimePickerFormat.Custom
        '    txtgodate.CustomFormat = "dd/MM/yyyy"
        '    surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
        '    If surchargeg <> "" Then
        '        valid(txtgodate.Text, rutesBs(0), "Go")
        '        If validb <> "" Then
        '            Name = "SurCharge"
        '            Dim adl = GetField("Adult", "agentratedtl", "RuteID=" & rutesBs(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '            Dim chd = GetField("Child", "agentratedtl", "RuteID=" & rutesBs(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '            Dim Inf = GetField("Inf", "agentratedtl", "RuteID=" & rutesBs(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '            Dim foc = GetField("FOC", "agentratedtl", "RuteID=" & rutesBs(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '            Dim sur = GetField("Surcharge", "agentratedtl", "RuteID=" & rutesBs(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
        '            LsGo.Rows.Add(Name, adl, chd, Inf, foc, sur)
        '        End If
        '    End If
        '    promo(txtgodate.Text, rutesBs(0), "Go")
        '    If promoa <> "" Then
        '        Name = "promo"
        '        Dim adlb = GetField("Adl", "promodtl", "RuteID=" & rutesBs(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & validb & "'")
        '        Dim chdb = GetField("Chd", "promodtl", "RuteID=" & rutesBs(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & validb & "'")
        '        Dim Infb = GetField("Infant", "promodtl", "RuteID=" & rutesBs(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & validb & "'")
        '        Dim focb = GetField("FOC", "promodtl", "RuteID=" & rutesBs(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & validb & "'")
        '        Dim surb = 0
        '        LsGo.Rows.Add(Name, adlb, chdb, Infb, focb, surb)
        '    End If
        'End If

        Dim rutes As String = cboGorute.Text
        Dim rutesl = rutes.Split(New Char() {" - "})

        If cboGorute.Text <> "" Then

            fillpublishrate(rutesl(0), "Go")
            'Exit Sub
        Else
            Exit Sub
        End If
        txtgodate.Format = DateTimePickerFormat.Custom
        txtgodate.CustomFormat = "dd/MM/yyyy"
        If Trim(txtgodate.Text) = "" Then
            Exit Sub
        End If

        surcharge(txtgodate.Value.Day, txtgodate.Value.Month, rutesl(0), txtgodate.Text, "Go")

        promo(txtgodate.Text, rutesl(0), "Go")

        spevent(txtgodate.Text, txtagentid.Text, "Go")
    End Sub

    Private Sub txtgodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgodate.ValueChanged
        'Dim rutes As String = cboGorute.Text
        'Dim rutesl = rutes.Split(New Char() {" - "})

        'If cboGorute.Text <> "" Then

        '    fillpublishrate(rutesl(0), "Go")
        'End If
        'txtgodate.Format = DateTimePickerFormat.Custom
        'txtgodate.CustomFormat = "dd/MM/yyyy"
        'If Trim(txtgodate.Text) = "" Then
        '    Exit Sub
        'End If
        'surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
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
        ''promo(txtgodate.Text, cboGorute.SelectedItem("RuteID"), "Go")
        'promo(txtgodate.Text, rutesl(0), "Go")
        'If promoa <> "" Then
        '    Name = "promo"
        '    Dim adla = GetField("Adl", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '    Dim chda = GetField("Chd", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '    Dim Infa = GetField("Infant", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '    Dim foca = GetField("FOC", "promodtl", "RuteID=" & rutesl(0) & " and Date='" & Str2Date(txtgodate.Text) & "' and Nopromo='" & promoa & "'")
        '    Dim sura = 0
        '    LsGo.Rows.Add(Name, adla, chda, Infa, foca, sura)
        'End If
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

        surcharge(txtgodate.Value.Day, txtgodate.Value.Month, rutesl(0), txtgodate.Text, "Go")

        promo(txtgodate.Text, rutesl(0), "Go")

        spevent(txtgodate.Text, txtagentid.Text, "Go")

    End Sub

    Private Sub txtbackdate_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbackdate.ValueChanged
        'Dim rutesa As String = cboruteback.Text
        'Dim rutesas = rutesa.Split(New Char() {" - "})

        'If cboruteback.Text <> "" Then
        '    fillpublishrate(rutesas(0), "Back")
        'End If
        'txtbackdate.Format = DateTimePickerFormat.Custom
        'txtbackdate.CustomFormat = "dd/MM/yyyy"
        'If txtbackdate.Text = " " Then
        '    Exit Sub
        'End If
        'surcharge(txtbackdate.Value.Day, txtbackdate.Value.Month, "Back")
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
        'promo(txtbackdate.Text, rutesas(0), "Back")
        'If promob <> "" Then
        '    Name = "promo"
        '    Dim adlb = GetField("Adl", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '    Dim chdb = GetField("Chd", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '    Dim Infb = GetField("Infant", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '    Dim focb = GetField("FOC", "promodtl", "RuteID=" & rutesas(0) & " and Date='" & Str2Date(txtbackdate.Text) & "' and Nopromo='" & validb & "'")
        '    Dim surb = 0
        '    LsBack.Rows.Add(Name, adlb, chdb, Infb, focb, surb)
        'End If
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

        promo(txtbackdate.Text, rutesas(0), "Back")

        spevent(txtbackdate.Text, txtagentid.Text, "Back")

    End Sub


    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = " "
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
                txtextrago.Text = LsGo.CurrentRow.Cells(5).Value
            Case "4" ''''Reservasi
                txtgorate.Text = LsGo.CurrentRow.Cells(4).Value
                txtextrago.Text = LsGo.CurrentRow.Cells(5).Value
        End Select
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
                txtexback.Text = LsBack.CurrentRow.Cells(5).Value
            Case "4" ''''Reservasi
                txtbackrate.Text = LsBack.CurrentRow.Cells(4).Value
                txtexback.Text = LsBack.CurrentRow.Cells(5).Value
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

    Private Sub LsBack_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsBack.CellContentDoubleClick
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

    Private Sub LsBack_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsBack.CellDoubleClick
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

    Private Sub LsGo_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsGo.CellContentDoubleClick
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

    Private Sub LsGo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsGo.CellDoubleClick
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

    Private Sub CxGoTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CxGoTrans.CheckedChanged
        If CxGoTrans.Checked = True Then
            txttransgorate.Text = "35000"
            GroupBox5.Enabled = True
        Else
            GroupBox5.Enabled = False
            txttransgorate.Text = "0"
        End If
    End Sub

    Private Sub CxBackTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CxBackTrans.CheckedChanged
        If CxBackTrans.Checked = True Then
            txttransbackrate.Text = "35000"
            GroupBox6.Enabled = True
        Else
            GroupBox6.Enabled = False
            txttransbackrate.Text = "0"
        End If
    End Sub

    Private Sub txtbackrate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbackrate.TextChanged

    End Sub



End Class