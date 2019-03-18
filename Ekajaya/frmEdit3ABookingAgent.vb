Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmEdit3ABookingAgent

    Dim ttl As Integer
    Dim valida, validb As String
    Dim promoa, promob As String
    Dim surchargeg, surchargeb
    Dim oagent, otipe, otitle, oname, oidtipe, oidno, oguest, oremark, ocountry, odate1, odate2, odate3, orute1, orute2, orute3, otrip1, otrip2, otrip3, oarea1, oarea2, oarea3, orate1, orate2, oext1, oext2, otrans1, otrans2, otransrate1, otransrate2, otransrate3, oextrans1, oextrans2, oextrans3, opick1, opick2, opick3, odrv1, odrv2, ototal, oqty, otrans3 As String
    Sub filldata()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        Dim strqry As String
        strqry = "SELECT 0 as ID, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, tiketdtl.GuestID, tiketdtl.GuestIDNO, tiketdtl.Country, IF(tiketdtl.Country='','',(SELECT country.CountryName FROM country WHERE country.CountryID=tiketdtl.Country)) AS CountryName, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC,tiketdtl.GoRuteID, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate, tiketdtl.GoTrip, trip.TripName , tiketdtl.GoRate , tiketdtl.GoExtra, IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, tiketdtl.GoTranRate, tiketdtl.GoTransExtra, tiketdtl.GoArea, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS DepartPickupArea, tiketdtl.GoPickUp AS PickupLocation, tiketdtl.GoDriver, tiketdtl.BackRuteID, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate, tiketdtl.TripBack, IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, tiketdtl.BackRate, tiketdtl.BackExtra, IF(tiketdtl.BackTrans=0,'No','Yes') AS Transport, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, tiketdtl.BackArea, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.BACKArea)) AS ArrivalPickupArea, tiketdtl.BackPickup AS DepartPickupLocation, tiketdtl.BackDriver, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.Tipe, tiketdtl.sorute, IF(tiketdtl.sorute='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.sorute)) AS StopOverRute, if(tiketdtl.soDate is null or tiketdtl.soDate='','',tiketdtl.soDate) AS SoverDate, tiketdtl.soTrip, IF(tiketdtl.soTrip='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.soTrip)) AS SOverTrip, tiketdtl.sotrans, tiketdtl.soExtra,  tiketdtl.soArea, IF(tiketdtl.soArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.soArea)) AS soArea, tiketdtl.SOPickup AS SOPickupLocation, IF(tiketdtl.soTransp=0,'No','Yes') AS Transport FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE NoEtiket='" & txtetiket.Text & "'"
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

        cbotipe.Text = "3A - TREE-ANGEL"

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
            cbotrans1.Text = LsData.CurrentRow.Cells(23).Value

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
            opick1 = ",GoPickup='" & LsData.CurrentRow.Cells(27).Value & "'"
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

        If LsData.CurrentRow.Cells(36).Value = "Yes" Then
            otrans2 = ",BackTrans=1"
            CxBackTrans.CheckState = CheckState.Checked
        Else
            CxBackTrans.CheckState = CheckState.Unchecked
            otrans2 = ",BackTrans=0"
        End If
        cbotrans3.Text = LsData.CurrentRow.Cells(37).Value
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


        '' SO
        cbosorute.Text = LsData.CurrentRow.Cells(47).Value & " - " & LsData.CurrentRow.Cells(48).Value
        If IsDBNull(LsData.CurrentRow.Cells(49).Value) = True Or (LsData.CurrentRow.Cells(49).Value = "") Then
            odate3 = ",soDate=NULL"
            txtsodate.CustomFormat = " "
            txtsodate.Format = DateTimePickerFormat.Custom
        Else
            Dim xs As String = LsData.CurrentRow.Cells(49).Value
            If xs.IndexOf("-") > -1 Then
                odate3 = ",soDate='" & (LsData.CurrentRow.Cells(49).Value) & "'"
                txtsodate.Text = LsData.CurrentRow.Cells(49).Value
            Else
                odate3 = ",soDate='" & Str2Date(LsData.CurrentRow.Cells(49).Value) & "'"
                txtsodate.Text = LsData.CurrentRow.Cells(49).Value
            End If

        End If
        'frmEditBooking.txtbackdate.Text = LsData.CurrentRow.Cells(29).Value
        If IsDBNull(LsData.CurrentRow.Cells(51).Value) Then
            otrip3 = ",soTrip=0"
        Else
            cbotripso.Text = LsData.CurrentRow.Cells(51).Value
            otrip3 = ",soTrip=" & LsData.CurrentRow.Cells(50).Value
        End If


        cbotrans2.Text = LsData.CurrentRow.Cells(52).Value
        otransrate2 = " ,sotrans=" & LsData.CurrentRow.Cells(52).Value
        If IsDBNull(LsData.CurrentRow.Cells(53).Value) Then
            oextrans3 = ",soExtra=0"
        Else
            txtsoextra.Text = LsData.CurrentRow.Cells(53).Value
            oextrans3 = ",soExtra=" & LsData.CurrentRow.Cells(53).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(55).Value) Then
            oarea3 = ",soArea=0"
        Else
            oarea3 = ",soArea=" & LsData.CurrentRow.Cells(54).Value
            cbosoarea.Text = LsData.CurrentRow.Cells(55).Value
        End If
        If IsDBNull(LsData.CurrentRow.Cells(56).Value) Then
            opick3 = ", SOPickup='' "
        Else
            txtPickupso.Text = LsData.CurrentRow.Cells(56).Value
            opick3 = ", SOPickup='" & LsData.CurrentRow.Cells(56).Value & "' "
        End If
        If LsData.CurrentRow.Cells(57).Value = "Yes" Then
            otrans3 = ",soTransp=1"
            CxSo.CheckState = CheckState.Checked
        Else
            CxSo.CheckState = CheckState.Unchecked
            otrans3 = ",soTransp=0"
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
        ElseIf stat = "back" Then
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
            cbosorute.Items.Add(reader("RuteID").ToString() & " - " & reader("RuteName").ToString())
        End While

        Call DisconnectDatabase()
    End Sub
    Sub filltrip()

        Call ConnectDatabase()
        Dim da, da2, DA3 As MySqlDataAdapter
        Dim dt, dt2, DT3 As DataTable
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
        DA3 = New MySqlDataAdapter("select TripID,TripName from trip", conn)
        DT3 = New DataTable
        Dim dr3 As DataRow = DT3.NewRow
        DA3.Fill(DT3)
        dr3("TripID") = 0
        dr3("TripName") = ""
        DT3.Rows.InsertAt(dr3, 0)
        cbotripso.DataSource = DT3
        cbotripso.DisplayMember = "tripName"
        Call DisconnectDatabase()
    End Sub
    Sub fillarea()
        Call ConnectDatabase()
        Dim da, da2, DA3 As MySqlDataAdapter
        Dim dt, dt2, DT3 As DataTable
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
        DA3 = New MySqlDataAdapter("select AreaID,AreaName from area", conn)
        DT3 = New DataTable
        Dim dr3 As DataRow = DT3.NewRow
        DA3.Fill(DT3)
        dr3("AreaID") = 0
        dr3("AreaName") = ""
        DT3.Rows.InsertAt(dr3, 0)
        cbosoarea.DataSource = DT3
        cbosoarea.DisplayMember = "AreaName"
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
    Private Sub frmEditBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If txtNoBook.Text = "" Then
        'Me.Close()
        ' Else
        'cboGst.Text = "1 - Adult"

        filltrip()
        fillRute()
        fillarea()
        fillCountry()
        filldata()

        'If cbotipe.Text = "OW - One Way" Then
        '    GroupBox4.Enabled = False
        '    GroupBox6.Enabled = False
        'Else
        '    GroupBox4.Enabled = True
        '    GroupBox6.Enabled = True
        'End If
        txtNoBook.ReadOnly = True
        'ArData(txtNoBook.Text)
        ' End If

    End Sub
    Private Sub cbotipe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mid(cbotipe.Text, 1, 2) = "RT" Then
            GroupBox4.Enabled = True
            'GroupBox6.Enabled = True
        Else
            GroupBox4.Enabled = False
            'GroupBox6.Enabled = False
        End If
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (MsgBox("Discart Chang and Close?", vbYesNo, "Close Form")) = vbYes Then
            Me.Close()
        End If
    End Sub





    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim agent, tipe, title, name, idtipe, idno, guest, remark, country, date1, date2, date3, rute1, rute2, rute3, trip1, trip2, area1, area2, rate1, rate2, ext1, ext2, trans1, trans2, transrate1, transrate2, extrans1, extrans2, pick1, pick2, extrans3, transrate3, pick3, trip3, area3, drv1, drv2, total, colls, komis, sis, trans3 As String
        Dim komisi
        Dim sisa
        Dim x As Boolean = False

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
        If CxSo.CheckState = CheckState.Checked Then
            trans3 = ", soTransp=1"
        Else
            trans3 = ", sotransp=0"
        End If
        If cbotrans1.Text = "" Then
            transrate1 = ", GoTranRate=0"
        Else
            transrate1 = ", GoTranRate=" & cbotrans1.Text
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



        If CxBackTrans.CheckState = CheckState.Checked Then
            trans2 = ", BackTrans=1"
        Else
            trans2 = ", Backtrans=0"
        End If

        If cbotrans3.Text = "" Then
            transrate2 = ", BackTransRate=0"
        Else
            transrate2 = ", BackTransRate=" & cbotrans3.Text
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

        If cbotrans2.Text = "" Then
            transrate3 = ", sotrans=0"
        Else
            transrate3 = ", sotrans=" & cbotrans2.Text
        End If

        If txtsoextra.Text = "" Then
            extrans3 = ", soextra=0"
        Else
            extrans3 = ", soextra=" & txtsoextra.Text
        End If

        If txtPickupso.Text = "" Then
            pick3 = ""
        Else
            'pick2 = ", BackPickUp='" & txtpickupgo.Text & "'"
            pick3 = ", sopickup=@SOPICK"
        End If





        If Trim(txtbackdate.Text) = "" Then
            date2 = ""
        Else
            date2 = ",BackDate='" & Str2Date(txtbackdate.Text) & "'"
        End If
        If Trim(txtsodate.Text) = "" Then
            date3 = ""
        Else
            date3 = ",sodate='" & Str2Date(txtsodate.Text) & "'"
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
        If cbosorute.Text = "" Then
            rute3 = ""
        Else
            Dim rutesO As String = cbosorute.Text
            Dim rutesOs = rutesO.Split(New Char() {" - "})
            'rute2 = ",BackRuteID=" & cboruteback.SelectedItem("RuteID").ToString
            rute3 = ", sorute=" & NZx(rutesOs(0))
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
        If cbotripso.Text = "" Then
            trip3 = ""
            'trip2 = NZx(cbotripback.SelectedItem("TripID").ToString)
        Else
            trip3 = ", sotrip=" & NZx(cbotripso.SelectedItem("TripID").ToString) & ""
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
        If cbosoarea.Text = "" Then
            area3 = ""
        Else
            area3 = ", soarea=" & cbosoarea.SelectedItem("AreaID").ToString
        End If
        Dim totals As Double = Val(NZx(txtgorate.Text)) + Val(NZx(txtgoextra.Text)) + Val(NZx(txtextrago.Text)) + Val(NZx(cbotrans1.Text)) + Val(NZx(txtsoextra.Text)) + Val(NZx(txtbackExtra.Text)) + Val(NZx(cbotrans3.Text)) + Val(NZx(cbotrans2.Text))
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

        Call ConnectDatabase()
        Dim cmd As MySqlCommand
        Dim strsql As String

        strsql = "UPDATE tiketdtl set NoTiket='" & txttiket.Text & "'" & agent & tipe & title & name & idtipe & idno & remark & country & date1 & date2 & rute1 & rute2 & trip1 & trip2 & area1 & trans1 & trans2 & area2 & rate1 & rate2 & ext1 & ext2 & trans1 & trans2 & transrate1 & transrate2 & extrans1 & extrans2 & pick1 & pick2 & total & colls & komis & sis & date3 & rute3 & extrans3 & transrate3 & pick3 & trip3 & area3 & trans3 & guest & " where NoETiket='" & txtetiket.Text & "'"

        cmd = New MySqlCommand(strsql, conn)
        cmd.Parameters.AddWithValue("@name", txtName.Text)
        cmd.Parameters.AddWithValue("@gopick", txtpickupgo.Text)
        cmd.Parameters.AddWithValue("@backpick", txtPickupBack.Text)
        cmd.Parameters.AddWithValue("@SOPICK", txtPickupso.Text)
        cmd.Parameters.AddWithValue("@remark", txtremark.Text)
        cmd.ExecuteScalar()
        Dim Oldv = oagent & otipe & otitle & oname & oidtipe & oidno & oguest & oremark & ocountry & odate1 & odate2 & odate3 & orute1 & orute2 & orute3 & otrip1 & otrip2 & otrip3 & oarea1 & oarea2 & oarea3 & orate1 & orate2 & oext1 & oext2 & otrans1 & otrans2 & otransrate1 & otransrate2 & otransrate3 & oextrans1 & oextrans2 & oextrans3 & opick1 & opick2 & opick3 & odrv1 & odrv2 & ototal & oqty & trans3
        Oldv = Replace(Oldv, "'", " ")
        Dim newval = "NoTiket=" & txttiket.Text & "," & agent & tipe & title & ", nAME=" & txtName.Text & ", " & idtipe & idno & ", remark=" & txtremark.Text & ", " & country & date1 & date2 & rute1 & rute2 & trip1 & trip2 & area1 & area2 & rate1 & rate2 & ext1 & ext2 & trans1 & trans2 & transrate1 & transrate2 & extrans1 & extrans2 & ",gOpICKUP " & txtpickupgo.Text & ", bACKpICKUP" & txtPickupBack.Text & ",  " & total & colls & komis & sis & date3 & rute3 & extrans3 & transrate3 & pick3 & trip3 & area3 & trans3 & guest & " where NoETiket='" & txtetiket.Text & "'"
        newval = Replace(newval, "'", " ")
        FillLog(usr, "EDIT Ticket", " No. : " & txttiket.Text & " | No.Etiket : " & txtetiket.Text, Oldv, newval)
        Me.Close()
        Call DisconnectDatabase()




    End Sub

    Private Sub txtbackdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub cmdCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdAgent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmagentlist.Show()
        frmagentlist.forms = "EdtBooking"
        Me.Hide()
    End Sub






    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = " "
    End Sub



    Private Sub CxGoTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CxGoTrans.Checked = True Then
            cbotrans1.Text = "35000"
            GroupBox5.Enabled = True
        Else
            GroupBox5.Enabled = False
            cbotrans1.Text = "0"

        End If
    End Sub

    Private Sub CxBackTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CxBackTrans.Checked = True Then
            cbotrans3.Text = "35000"
            GroupBox6.Enabled = True
        Else
            GroupBox6.Enabled = False
            cbotrans3.Text = "0"
        End If
    End Sub

    Private Sub txtagentid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtagentid.TextChanged
        If txtgodate.Text = " " Then
            txtgorate.Text = ChField("select 3angle from agentrate where agentid='" & txtagentid.Text & "' and DateStart<='" & Format(Now, "yyyy-MM-dd") & "' and DateEnd>='" & Format(Now, "yyyy-MM-dd") & "' ")
        Else
            txtgorate.Text = ChField("select 3angle from agentrate where agentid='" & txtagentid.Text & "' and DateStart<='" & Str2Date(txtgodate.Text) & "' and DateEnd>='" & Str2Date(txtgodate.Text) & "' ")
        End If
    End Sub

    Private Sub txtgodate_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgodate.ValueChanged
        txtgodate.Format = DateTimePickerFormat.Custom
        txtgodate.CustomFormat = "dd/MM/yyyy"
        If Trim(txtgodate.Text) = "" Then
            Exit Sub
        End If
        txtgorate.Text = ChField("select 3angle from agentrate where agentid='" & txtagentid.Text & "' and DateStart<='" & Str2Date(txtgodate.Text) & "' and DateEnd>='" & Str2Date(txtgodate.Text) & "' ")
        surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
    End Sub

    Private Sub txtsodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsodate.ValueChanged
        txtsodate.Format = DateTimePickerFormat.Custom
        txtsodate.CustomFormat = "dd/MM/yyyy"
        If Trim(txtsodate.Text) = "" Then
            Exit Sub
        End If
    End Sub

    Private Sub txtbackdate_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbackdate.ValueChanged
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

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtbackdate.CustomFormat = " "
        txtbackdate.Format = DateTimePickerFormat.Custom
    End Sub
End Class
