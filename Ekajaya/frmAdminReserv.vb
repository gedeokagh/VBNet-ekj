Imports MySql.Data.MySqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmAdminReserv
     Dim totalpax As Integer
    Dim strgo, strback As String
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Sub colorx()
        Dim i As Integer
        totalpax = 0
        For i = 0 To LsData.Rows.Count() - 1 Step +1
            'Dim val = Trim(LsData.Rows(i).Cells(44).Value)
            'Dim vals = Trim(LsData.Rows(i).Cells(45).Value)
            ''val = LsData.Rows(i).Cells(44).ToString

            '    If val = 0 Then
            '        LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            '    End If

            'If vals = 1 Then
            '    LsData.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            'End If
            Dim val = Trim(LsData.Rows(i).Cells(19).Value)
            Dim vals = Trim(LsData.Rows(i).Cells(20).Value)
            'val = LsData.Rows(i).Cells(44).ToString
            If vals = 1 Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
            If val = 0 Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            Else
                totalpax = totalpax + 1
            End If


        Next
    End Sub
    Sub SETFILTER()


        Dim andx As Boolean = False
        strgo = ""
        strback = ""
        totalpax = 0
        lblTotal.Text = "0 PAX"
        If cboAgent.Text = "" Then
        Else
            strgo = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "'"
            strback = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "'"
            andx = True
        End If
        If Trim(txtdate.Text) = "" Then
        Else
            If andx = False Then
                strgo = " ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                ' strgo = " (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
                strback = " (tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')"
                andx = True
            Else
                strgo = strgo & " and ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                'strgo = strgo & " and (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
                strback = strback & " and (tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')"
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
        If cbotrip.Text = "" Then
        Else
            If andx = False Then
                strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                'strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = " ( tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                andx = True
            Else
                strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                'strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = strback & " and  (tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
            End If
        End If
        If cboRute.Text = "" Then
        Else
            If andx = False Then
                strgo = " (tiketdtl.GoRuteID=" & cboRute.SelectedItem("RuteID").ToString & " or tiketdtl.BACKRuteID=" & cboRute.SelectedItem("RuteID").ToString & ")"
                'strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = " ( tiketdtl.BACKRuteID=" & cboRute.SelectedItem("RuteID").ToString & ")"
                andx = True
            Else
                strgo = strgo & " and  (tiketdtl.GoRuteID=" & cboRute.SelectedItem("RuteID").ToString & " or tiketdtl.BACKRuteID=" & cboRute.SelectedItem("RuteID").ToString & ")"
                'strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = strback & " and  (tiketdtl.BACKRuteID=" & cboRute.SelectedItem("RuteID").ToString & ")"
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
        If TextBox1.Text = "" Then
        Else
            If andx = False Then
                strgo = " (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                'strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = " (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                andx = True
            Else
                strgo = strgo & " and (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                'strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = strback & " and (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
            End If
        End If
    End Sub
    Sub sumls()
        Dim i As Integer
        totalpax = 0
        For i = 0 To LsData.Rows.Count() - 1 Step +1
            'totalpax = totalpax + LsData.Rows(i).Cells(11).Value + LsData.Rows(i).Cells(12).Value + LsData.Rows(i).Cells(13).Value + LsData.Rows(i).Cells(14).Value
            totalpax = totalpax + LsData.Rows(i).Cells(7).Value + LsData.Rows(i).Cells(8).Value + LsData.Rows(i).Cells(9).Value + LsData.Rows(i).Cells(6).Value
        Next
        lblTotal.Text = totalpax & " PAX"
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
        'da.Fill(dt)
        cbotrip.DataSource = dt
        cbotrip.DisplayMember = "tripName"

        Call DisconnectDatabase()
    End Sub

    Sub fillrute()

        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select RuteID,RuteName from Rute", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("RuteID") = 0
        dr("RuteName") = ""
        dt.Rows.InsertAt(dr, 0)
        'da.Fill(dt)
        cboRute.DataSource = dt
        cboRute.DisplayMember = "RuteName"

        Call DisconnectDatabase()
    End Sub

    Sub fillPort()
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
        'da.Fill(dt)
        cboPort.DataSource = dt
        cboPort.DisplayMember = "PortName"

        Call DisconnectDatabase()
    End Sub
    Sub filldata(ByVal strCriteria1 As String, ByVal strCriteria2 As String)
        Dim strCriterias1, strCriterias2, strQry As String
        If strCriteria1 = "0" Then
            strCriterias1 = "(tiketdtl.Godate='" & Str2Date(Format(Now, "dd/MM/yyyy")) & "')"
            strCriterias2 = "(tiketdtl.backdate='" & Str2Date(Format(Now, "dd/MM/yyyy")) & "')"
            ''strCriterias = " NoBook<>'' "
        Else
            strCriterias1 = strCriteria1
            strCriterias2 = strCriteria2
        End If
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        'strQry = "SELECT 0 as ID, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, tiketdtl.GuestID, tiketdtl.GuestIDNO, tiketdtl.Country, IF(tiketdtl.Country='','',(SELECT country.CountryName FROM country WHERE country.CountryID=tiketdtl.Country)) AS CountryName, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC,tiketdtl.GoRuteID, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate, tiketdtl.GoTrip, trip.TripName , tiketdtl.GoRate , tiketdtl.GoExtra, IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, tiketdtl.GoTranRate, tiketdtl.GoTransExtra, tiketdtl.GoArea, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS DepartPickupArea, tiketdtl.GoPickUp AS PickupLocation, tiketdtl.GoDriver, tiketdtl.BackRuteID, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate, tiketdtl.TripBack, IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, tiketdtl.BackRate, tiketdtl.BackExtra, IF(tiketdtl.BackTrans=0,'No','Yes') AS Transport, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, tiketdtl.BackArea, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS ArrivalPickupArea, tiketdtl.BackPickup AS DepartPickupLocation, tiketdtl.BackDriver, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.Tipe, tiketdtl.NoTiket FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strCriterias1
        'strQry = "Select tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.departBACK FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strCriterias1 & " union select tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.departBACK FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strCriterias2
        strQry = "Select tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.departBACK , tiketdtl.inv FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strCriterias1 & " union select tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.departBACK,tiketdtl.inv FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strCriterias2
        'strQry = "SELECT 0 as ID, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, tiketdtl.GuestID, tiketdtl.GuestIDNO, tiketdtl.Country, IF(tiketdtl.Country='','',(SELECT country.CountryName FROM country WHERE country.CountryID=tiketdtl.Country)) AS CountryName, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC,tiketdtl.GoRuteID, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate, tiketdtl.GoTrip, trip.TripName , tiketdtl.GoRate , tiketdtl.GoExtra, IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, tiketdtl.GoTranRate, tiketdtl.GoTransExtra, tiketdtl.GoArea, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS DepartPickupArea, tiketdtl.GoPickUp AS PickupLocation, tiketdtl.GoDriver, tiketdtl.BackRuteID, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate, tiketdtl.TripBack, IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, tiketdtl.BackRate, tiketdtl.BackExtra, IF(tiketdtl.BackTrans=0,'No','Yes') AS Transport, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, tiketdtl.BackArea, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS ArrivalPickupArea, tiketdtl.BackPickup AS DepartPickupLocation, tiketdtl.BackDriver, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.Tipe FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strCriterias1 & "union SELECT 0 as ID, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, tiketdtl.GuestID, tiketdtl.GuestIDNO, tiketdtl.Country, IF(tiketdtl.Country='','',(SELECT country.CountryName FROM country WHERE country.CountryID=tiketdtl.Country)) AS CountryName, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC,tiketdtl.GoRuteID, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate, tiketdtl.GoTrip, trip.TripName , tiketdtl.GoRate , tiketdtl.GoExtra, IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, tiketdtl.GoTranRate, tiketdtl.GoTransExtra, tiketdtl.GoArea, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS DepartPickupArea, tiketdtl.GoPickUp AS PickupLocation, tiketdtl.GoDriver, tiketdtl.BackRuteID, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate, tiketdtl.TripBack, IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, tiketdtl.BackRate, tiketdtl.BackExtra, IF(tiketdtl.BackTrans=0,'No','Yes') AS Transport, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, tiketdtl.BackArea, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS ArrivalPickupArea, tiketdtl.BackPickup AS DepartPickupLocation, tiketdtl.BackDriver, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.Tipe FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strCriterias2
        da = New MySqlDataAdapter(strQry, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt

        'LsData.Columns(18).Visible = False
        LsData.Columns(19).Visible = False
        LsData.Columns(20).Visible = False
        LsData.Columns(21).Visible = False
        LsData.Columns(22).Visible = False
        LsData.Columns(7).Visible = False
        LsData.Columns(8).Visible = False
        LsData.Columns(9).Visible = False
        LsData.Columns(6).Visible = False
        LsData.Columns(17).Visible = False
        LsData.Columns(13).Visible = False
        Dim i As Integer = 0
        For i = 0 To 22
            If i = 1 Then
                LsData.Columns(i).ReadOnly = False
            Else
                LsData.Columns(i).ReadOnly = True
            End If

        Next


        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        LsData.MultiSelect = True
        Call DisconnectDatabase()
        ''head()
    End Sub
    Sub fillshutle(ByVal sAgent As String, ByVal sPort As Integer, ByVal sdate As String, ByVal strip As String)
        Dim strQry, strCriteriasA, strCriteriasB As String
        strCriteriasA = ""
        strCriteriasB = ""
        Dim ands As Boolean = False
        strQry = ""
        If sAgent = "0" Then
        Else
            strCriteriasA = " (tiketdtl.agentID='" & sAgent & "')"
            strCriteriasB = " (tiketdtl.agentID='" & sAgent & "')"
            ands = True
        End If
        If sPort = 0 Then
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasB = " (tiketdtl.BackRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasB = strCriteriasB & " and (tiketdtl.BackRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
            End If

        End If
        If strip = "0" Then
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoTrip='" & strip & "')"
                strCriteriasB = " (tiketdtl.TripBack='" & strip & "')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoTrip='" & strip & "')"
                strCriteriasB = strCriteriasB & " and (tiketdtl.TripBack='" & strip & "')"
            End If

        End If
        If sdate = " " Then
        Else
            sdate = Str2Date(sdate)
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoDATE='" & sdate & "')"
                strCriteriasB = " (tiketdtl.BackDATE='" & sdate & "')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoDATE='" & sdate & "')"
                strCriteriasB = strCriteriasB & " and (tiketdtl.BackDATE='" & sdate & "')"
            End If

        End If
        If ands = False Then
            Exit Sub
        End If
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        strQry = "SELECT '0' as ID, 'go' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS Area, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasA & " union SELECT '0' as ID, 'bk' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS Area, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver,tiketdtl.NoTiket  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE  " & strCriteriasB & ";"
        da = New MySqlDataAdapter(strQry, conn)
        dt = New DataTable
        da.Fill(dt)
        'frmShutle.LsData.DataSource = dt
        'frmShutle.LsData.AllowUserToAddRows = False
        'frmShutle.LsData.AllowUserToDeleteRows = False
        'Dim dr As DataRow = dt.NewRow
        ' da.Fill(dt)

        'Dim da2 As MySqlDataAdapter
        'Dim dt2 As New DataTable
        'strQry = "SELECT 0 as ID, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) Area, tiketdtl.BackPickup AS Location, tiketdtl.BackDriveras Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasB
        'da2 = New MySqlDataAdapter(strQry, conn)
        'dt2 = New DataTable
        'da2.Fill(dt2)
        'dt.Rows.Add()
        frmShutle.LsData.DataSource = dt
        'frmShutle.LsData.Rows.Insert(dt2)
        frmShutle.LsData.AllowUserToAddRows = False
        frmShutle.LsData.AllowUserToDeleteRows = False
        frmShutle.LsData.Columns(0).Visible = False
        frmShutle.LsData.Columns(1).Visible = False
        Call DisconnectDatabase()

    End Sub

    Private Sub frmAdminRes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    Private Sub frmAdminRes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillagent()
        filltrip()
        fillrute()
        fillPort()
        '''filldata("0", "0")
        lblUser.Text = usr
        Text1.Text = ""
        txtdate.CustomFormat = " "
        txtdate.Format = DateTimePickerFormat.Custom
        'txtdate.Text = Format(Now, "dd/MM/yyyy")

        lblTotal.Text = "0 PAX"
    End Sub

   Private Sub cmdEdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdBook.Click
        If LsData.RowCount = 0 Then
            MsgBox("No Data To Update", vbInformation, "No Data")
            Exit Sub
        End If
        If LsData.CurrentRow.Cells(22).Value = 1 Then
            MsgBox("Tiket Already Invoceiced,", vbInformation, "Data Error")
            Exit Sub
        End If
        If Text1.Text = "" Then
            MsgBox("Please Choose Data to Update", vbInformation, "No Data")
            Exit Sub
        End If
        frmEditBooking.txtetiket.Text = LsData.CurrentRow.Cells(0).Value
        frmEditBooking.Show()

    End Sub

    Private Sub LsData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellClick
        'Text1.Text = LsData.CurrentRow.Cells(3).Value
        Text1.Text = LsData.CurrentRow.Cells(0).Value
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        'Text1.Text = LsData.CurrentRow.Cells(3).Value
        Text1.Text = LsData.CurrentRow.Cells(0).Value
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        SETFILTER()
        filldata(strgo, strback)
        'sumls()

        colorx()
        lblTotal.Text = totalpax & " PAX"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtdate.CustomFormat = " "
        txtdate.Format = DateTimePickerFormat.Custom
        ''txtgodate.Text = ""
    End Sub

    Private Sub txtdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdate.TextChanged
        txtdate.CustomFormat = "dd/MM/yyyy"
        txtdate.Format = DateTimePickerFormat.Custom
    End Sub


    Private Sub txtdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdate.ValueChanged
        txtdate.CustomFormat = "dd/MM/yyyy"
        txtdate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub cmdShutle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShutle.Click

        frmShutle.from = False
        frmShutle.Show()
    End Sub

    Private Sub LsData_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellDoubleClick
        If LsData.RowCount = 0 Then
            MsgBox("No Data To Update", vbInformation, "Data")
            Exit Sub
        End If
        If Text1.Text = "" Then
            MsgBox("Please Choose Data to Update", vbInformation, "Data")
            Exit Sub
        End If
        'frmEditBooking.txtetiket.Text = LsData.CurrentRow.Cells(0).Value
        'frmEditBooking.Show()
        If (LsData.CurrentRow.Cells(3).Value = "RT") Or (LsData.CurrentRow.Cells(3).Value = "OW") Then
            frmEditBooking.cprice = True
            frmEditBooking.txtetiket.Text = LsData.CurrentRow.Cells(1).Value
            frmEditBooking.Show()
        End If
        If (LsData.CurrentRow.Cells(3).Value = "3A") Then
            frmEdit3ABooking.txtetiket.Text = LsData.CurrentRow.Cells(1).Value
            frmEdit3ABooking.Show()
        End If
        If (LsData.CurrentRow.Cells(3).Value = "OD") Or (LsData.CurrentRow.Cells(3).Value = "ODT") Then
            frmTourOrdeEdit.txtetiket.Text = LsData.CurrentRow.Cells(1).Value
            frmTourOrdeEdit.Show()
        End If
    End Sub

    Private Sub LsData_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellEndEdit

        If LsData.RowCount > 0 Then
            'If Trim(LsData.CurrentRow.Cells(2).Value) = Trim(LsData.CurrentRow.Cells(47).Value) Then
            '    Exit Sub
            'Else
            '    MsgBox(LsData.CurrentRow.Cells(2).Value & " = " & LsData.CurrentRow.Cells(47).Value)
            '    Exit Sub
            'End If
            If Trim(LsData.CurrentRow.Cells(1).Value) = "-" Then
                Dim strval As String
                Call ConnectDatabase()
                Dim cmd As MySqlCommand
                strval = "update tiketdtl set  NoTiket='-'  where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'"
                cmd = New MySqlCommand(strval, conn)
                cmd.ExecuteScalar()
                Call DisconnectDatabase()
                Exit Sub
            End If
            ''' MsgBox(LsData.CurrentRow.Cells(1).Value, MsgBoxStyle.Information, "Test")
            If cxField("Notiket", "Ticket", "NoTiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "'") = 1 Then
                Dim agn = GetField("AgentID", "ticket", "NoTiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "'")
                Dim tr As Boolean = False
                Dim trs As Boolean = False
                Dim ags = GetField("AgentID", "tiketdtl", "NoTiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "'")
                If IsDBNull(agn) Then
                    tr = True
                End If

                If (agn = ags) Then
                    trs = True
                End If
                If tr = False Then
                    If trs = False Then
                        MsgBox("No.Tiket " & Trim(LsData.CurrentRow.Cells(1).Value) & " Not for Current Agent.", MsgBoxStyle.Information, "Error")
                        LsData.CurrentRow.Cells(2).Value = "-"
                        Exit Sub
                    Else
                        Dim strval As String
                        Dim tjual, sisa, komisi As Double
                        Call ConnectDatabase()
                        Dim cmd As MySqlCommand
                        If cxField("NoTiket", "coldtl", "NoTiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "'") = 1 Then
                            Dim gx = GetField("Total", "coldtl", "NoTiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "'")
                            Dim NC = GetField("NoCollect", "coldtl", "NoTiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "'")
                            tjual = GetField("TotalJual", "tiketdtl", "notiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "'")

                            komisi = Val(gx) - NZx(tjual)
                            If (komisi <= 0) Then
                                sisa = komisi * -1

                            Else
                                sisa = 0
                            End If
                            strval = "update tiketdtl set  NoTiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "',NoCollect='" & NC & "', collect=1,TotalCollect=" & gx & ",sisa=" & sisa & ",komisi=" & komisi & " where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'"
                        Else
                            strval = "update tiketdtl set  NoTiket='" & Trim(LsData.CurrentRow.Cells(1).Value) & "'  where NoEtiket='" & Trim(LsData.CurrentRow.Cells(0).Value) & "'"
                        End If
                        If conn.State = ConnectionState.Closed Then
                            conn.Open()
                        End If
                        cmd = New MySqlCommand(strval, conn)
                        cmd.ExecuteScalar()
                        Call DisconnectDatabase()
                    End If
                    Exit Sub
                End If
            Else
                MsgBox("No.Tiket " & Trim(LsData.CurrentRow.Cells(1).Value) & " Not Register. Please Generate Ticket First.", MsgBoxStyle.Information, "Error")
                LsData.CurrentRow.Cells(1).Value = "-"
                Exit Sub

            End If
        End If
    End Sub


    Private Sub cmdDepart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDepart.Click
        If LsData.CurrentRow.Cells(19).Value = 0 Then
            MsgBox("Tiket Is Voided, Cannot Depart", vbInformation, "Error")
            Exit Sub
        End If
        Try
            Dim strSql As String

            Call ConnectDatabase()
            strSql = "update tiketdtl set departgo=1,status=1 where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'"
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Comd.ExecuteNonQuery()

            Call DisconnectDatabase()
            LsData.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen
            LsData.CurrentRow.Cells(20).Value = 1
            FillLog(usr, "Depart Tiket", " Tiket No. Tiket=" & LsData.CurrentRow.Cells(2).Value & ", Etiket =" & LsData.CurrentRow.Cells(1).Value & " ", "tiketdtl.departgo=0", "tiketdtl.departgo=1")
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub

    Private Sub cmdreturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreturn.Click
        If LsData.CurrentRow.Cells(19).Value = 0 Then
            MsgBox("Tiket Is Voided, Cannot Depart", vbInformation, "Error")
            Exit Sub
        End If
        Try
            Dim strSql As String

            Call ConnectDatabase()
            strSql = "update tiketdtl set departback=1,status=1 where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'"
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Comd.ExecuteNonQuery()

            Call DisconnectDatabase()
            LsData.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen
            FillLog(usr, "Depart Tiket", " Depart Return Tiket=" & LsData.CurrentRow.Cells(2).Value & ", Etiket =" & LsData.CurrentRow.Cells(1).Value & " ", "tiketdtl.departback=0", "tiketdtl.departback=1")
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub

    Private Sub cmdvoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdvoid.Click
        If LsData.CurrentRow.Cells(19).Value = 0 Then
            Exit Sub
        End If
        Try
            Dim strSql As String

            Call ConnectDatabase()
            strSql = "update tiketdtl set status=0 where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'"
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Comd.ExecuteNonQuery()

            Call DisconnectDatabase()
            LsData.CurrentRow.DefaultCellStyle.BackColor = Color.Red
            LsData.CurrentRow.Cells(19).Value = 0
            FillLog(usr, "Void Tiket", " Void Tiket=" & LsData.CurrentRow.Cells(1).Value & ", No.Etiket =" & LsData.CurrentRow.Cells(0).Value & " ", "status=1", "status=0")
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub

    Private Sub cmdreactive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim strSql As String = ""
            Dim sts As String
            If ChField("select pay from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'") = 1 Then
                sts = "Finish"
            Else
                If ChField("select inv from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'") = 1 Then
                    sts = "Invoicing"
                Else
                    If IsDBNull(ChField("select nocollect from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'")) Then
                        sts = "Booking"
                    ElseIf ChField("select nocollect from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'") = "" Then
                        sts = "Booking"
                    Else
                        sts = "Collect"
                    End If
                End If
            End If
            Select Case sts
                Case "Finish"
                    strSql = "update tiketdtl set status=4 where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'"
                    LsData.CurrentRow.Cells(44).Value = 4
                Case "Invoicing"
                    strSql = "update tiketdtl set status=3 where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'"
                    LsData.CurrentRow.Cells(44).Value = 3
                Case "Collect"
                    strSql = "update tiketdtl set status=2 where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'"
                    LsData.CurrentRow.Cells(44).Value = 2
                Case "Booking"
                    strSql = "update tiketdtl set status=1 where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'"
                    LsData.CurrentRow.Cells(44).Value = 1
            End Select
            If strSql = "" Then
                Exit Sub
            End If
            Call ConnectDatabase()

            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Comd.ExecuteNonQuery()

            Call DisconnectDatabase()
            LsData.CurrentRow.DefaultCellStyle.BackColor = Color.Empty

            FillLog(usr, "Active Tiket", " Return Tiket from Void to " & sts & ", TiketNo=" & LsData.CurrentRow.Cells(2).Value & ", Etiket =" & LsData.CurrentRow.Cells(1).Value, "", "")
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub

    Private Sub cmdTiketPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPayTiket.Show()
    End Sub

    Private Sub poforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poforma.Click
        frmInvoicing.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        frmOpenReturn.Show()
    End Sub

    Private Sub cmdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBook.Click
        frmBooking.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim strc1 As String = ""
        If cboPort.Text = "" Then
            MsgBox("Please select Port", vbInformation, "Select  Port")
            Exit Sub
        End If
        If Trim(txtdate.Text) = "" Then
            MsgBox("Please Choose Date", vbInformation, "Choose  Date")
            Exit Sub
        End If
        If cbotrip.Text = "" Then
            MsgBox("Please select Trip", vbInformation, "Select  Trip")
            Exit Sub
        End If
        ' Dim strgo, strback As String
        'Dim andx As Boolean = False
        'strgo = ""
        'strback = ""


        'If Trim(txtdate.Text) = "" Then
        'Else
        '    If andx = False Then
        '         strgo = " (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
        '        strback = " (tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')"
        '        andx = True
        '    Else
        '        strgo = strgo & " and (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
        '        strback = strback & " and (tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')"
        '    End If
        'End If

        'If cboPort.Text = "" Then
        'Else
        '    Dim ctr = cboPort.SelectedItem("PortID")
        '    If andx = False Then
        '        strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '        strback = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")"
        '        andx = True
        '    Else
        '        strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '        strback = strback & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '    End If
        'End If
        'If cbotrip.Text = "" Then
        'Else
        '    If andx = False Then
        '         strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
        '        strback = " ( tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
        '        andx = True
        '    Else
        '        'strgo = strgo & " and  (tiketdtl.GoTrip=" & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & ")"
        '        strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
        '        strback = strback & " and  (tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
        '    End If
        'End If
        Dim andx As Boolean = False
        strgo = ""
        strback = ""
        If Trim(txtdate.Text) = "" Then
        Else
            If andx = False Then
                'strgo = " ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                strgo = " (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
                strback = " (tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')"
                andx = True
            Else
                'strgo = strgo & " and ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                strgo = strgo & " and (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
                strback = strback & " and (tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')"
            End If
        End If

        If cboPort.Text = "" Then
        Else
            Dim ctr = cboPort.SelectedItem("PortID")
            If andx = False Then
                'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                strback = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")"
                andx = True
            Else
                'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                strback = strback & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
            End If
        End If
        If cbotrip.Text = "" Then
        Else
            If andx = False Then
                'strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = " ( tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                andx = True
            Else
                'strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                strback = strback & " and  (tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
            End If
        End If
        strc1 = "SELECT '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket, tiketdtl.remark, tiketdtl.NoTiket, agent.AgentName, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.mrs, tiketdtl.Guest, `tiketdtl`.`GoDate` AS Dates, IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( tiketdtl.GoRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF( tiketdtl.Gotrip = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName, IF( `tiketdtl`.`GoTrans` = 0, 'No', 'Yes' ) AS Transport, IF( tiketdtl.GoArea = 0, '', (SELECT area.AreaName FROM AREA WHERE area.AreaID = tiketdtl.GoArea) ) AS AREA, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver,if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS RETURNDate, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS RuteBack FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) WHERE " & strgo & " UNION SELECT '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket, tiketdtl.NoTiket, agent.AgentName, tiketdtl.remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.mrs, tiketdtl.Guest,tiketdtl.BackDate AS Dates, IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS Rute, IF( tiketdtl.tripback = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.Tripback) ) AS Trip, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName, IF( `tiketdtl`.`backTrans` = 0, 'No', 'Yes' ) AS Transport, IF( tiketdtl.backArea = 0, '', (SELECT area.AreaName FROM AREA WHERE area.AreaID = tiketdtl.backArea) ) AS AREA, tiketdtl.backPickUp AS Location, tiketdtl.backDriver AS Driver,if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS RETURNDate, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS RuteBack FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strback
        'strc1 = "Select '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket , tiketdtl.remark,  tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.departgo, tiketdtl.departBACK , tiketdtl.inv FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strgo & "union Select '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket , tiketdtl.remark,  tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.departgo, tiketdtl.departBACK , tiketdtl.inv FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strback
        frmPrintTikets.sqlPrint = strc1
        frmPrintTikets.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmArea.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        FrmPrintTiketList.Show()
    End Sub

    Private Sub LsData_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellLeave

    End Sub

    Private Sub LsData_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellValueChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmColPay.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmlistEditTiket.Show()
    End Sub

    Private Sub LsData_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LsData.CurrentCellChanged

    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        ''xlApp = New Excel.ApplicationClass
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        xlWorkSheet.Cells(1, 1) = "NoETiket"
        xlWorkSheet.Cells(1, 2) = "NoTiket"
        xlWorkSheet.Cells(1, 3) = "AgentName"
        xlWorkSheet.Cells(1, 4) = "Title"
        xlWorkSheet.Cells(1, 5) = "GuestName"
        xlWorkSheet.Cells(1, 6) = "Age"
        xlWorkSheet.Cells(1, 7) = "Adl"
        xlWorkSheet.Cells(1, 8) = "Child"
        xlWorkSheet.Cells(1, 9) = "InFant"
        xlWorkSheet.Cells(1, 10) = "FOC"
        xlWorkSheet.Cells(1, 11) = "Depart Rute"
        xlWorkSheet.Cells(1, 12) = "Depart Date"
        xlWorkSheet.Cells(1, 13) = "Depart Trip"
        xlWorkSheet.Cells(1, 14) = "Depart Transport"
        xlWorkSheet.Cells(1, 15) = "Return Rute"
        xlWorkSheet.Cells(1, 16) = "Return Date"
        xlWorkSheet.Cells(1, 17) = "Return Trip"
        xlWorkSheet.Cells(1, 18) = "Return Transport"
        xlWorkSheet.Cells(1, 19) = "Remark"

        'LsData.Columns(19).Visible = False
        'LsData.Columns(20).Visible = False
        'LsData.Columns(21).Visible = False
        'LsData.Columns(22).Visible = False
        'LsData.Columns(7).Visible = False
        'LsData.Columns(8).Visible = False
        'LsData.Columns(9).Visible = False
        'LsData.Columns(6).Visible = False
        'LsData.Columns(17).Visible = False
        'LsData.Columns(13).Visible = False
        For i = 1 To LsData.RowCount - 1
            For j = 0 To LsData.ColumnCount - 1
                If (j + 1 > 19) Then
                Else
                    xlWorkSheet.Cells(i + 1, j + 1) = LsData(j, i).Value
                End If

            Next
        Next

        'xlWorkSheet.SaveAs("C:\vbexcel.xlsx", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive)
        xlWorkSheet.SaveAs("D:\vbexcel.xlsx")
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        MsgBox("You can find the file D:\vbexcel.xlsx")
    End Sub

    Private Sub UpdateUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateUserToolStripMenuItem.Click
        frmUser.userlv = 3
        frmUser.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        
        frmLogin.Show()
        Me.Close()
        usr = ""
    End Sub

    Private Sub UbahPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahPasswordToolStripMenuItem.Click
        frmChangepass.Show()
    End Sub

    Private Sub ProformaInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProformaInvoiceToolStripMenuItem.Click
        frmInvoicing.Show()
    End Sub

    Private Sub AddPicupAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPicupAreaToolStripMenuItem.Click
        frmArea.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Dim strSql As String = ""
            Dim sts As String
            If ChField("select pay from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'") = 1 Then
                sts = "Finish"
            Else
                If ChField("select inv from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'") = 1 Then
                    sts = "Invoicing"
                Else
                    If IsDBNull(ChField("select nocollect from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'")) Then
                        sts = "Booking"
                    ElseIf ChField("select nocollect from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'") = "" Then
                        sts = "Booking"
                    Else
                        sts = "Collect"
                    End If
                End If
            End If
            Select Case sts
                Case "Finish"
                    strSql = "update tiketdtl set status=1 where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'"
                    LsData.CurrentRow.Cells(19).Value = 1
                Case "Invoicing"
                    strSql = "update tiketdtl set status=1 where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'"
                    LsData.CurrentRow.Cells(19).Value = 1
                Case "Collect"
                    strSql = "update tiketdtl set status=1 where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'"
                    LsData.CurrentRow.Cells(19).Value = 1
                Case "Booking"
                    strSql = "update tiketdtl set status=1 where NoEtiket='" & LsData.CurrentRow.Cells(0).Value & "'"
                    LsData.CurrentRow.Cells(19).Value = 1
            End Select
            If strSql = "" Then
                Exit Sub
            End If
            Call ConnectDatabase()

            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Comd.ExecuteNonQuery()

            Call DisconnectDatabase()
            LsData.CurrentRow.DefaultCellStyle.BackColor = Color.Empty

            FillLog(usr, "Active Tiket", " Reset Tiket , TiketNo=" & LsData.CurrentRow.Cells(1).Value & ", Etiket =" & LsData.CurrentRow.Cells(0).Value, "", "")
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        frmCekBording.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        
    End Sub
End Class