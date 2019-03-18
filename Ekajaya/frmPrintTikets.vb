Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
''Imports CrystalDecisions.Shared

Public Class frmPrintTikets
    Public sqlPrint As String
    'Public sport As String
    'Public portid As String
    'Public sdate As String
    'Public strip As String
   
    Private Sub frmPrintTikets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''Dim wgo, wback As String
        'Dim strgo, strback As String
        'Dim andx As Boolean = False
        'strgo = ""
        'strback = ""


        'If Trim(frmAdminRes.txtdate.Text) = "" Then
        'Else
        '    If andx = False Then
        '        strgo = " ((tiketdtl.GoDate='" & Str2Date(frmAdminRes.txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(frmAdminRes.txtdate.Text) & "')))"
        '        ' strgo = " (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
        '        strback = " (tiketdtl.BackDate='" & Str2Date(frmAdminRes.txtdate.Text) & "')"
        '        andx = True
        '    Else
        '        strgo = strgo & " and ((tiketdtl.GoDate='" & Str2Date(frmAdminRes.txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(frmAdminRes.txtdate.Text) & "')))"
        '        'strgo = strgo & " and (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
        '        strback = strback & " and (tiketdtl.BackDate='" & Str2Date(frmAdminRes.txtdate.Text) & "')"
        '    End If
        'End If

        'If frmAdminRes.cboPort.Text = "" Then
        'Else
        '    Dim ctr = frmAdminRes.cboPort.SelectedItem("PortID")
        '    If andx = False Then
        '        strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
        '        'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '        strback = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")"
        '        andx = True
        '    Else
        '        strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
        '        'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '        strback = strback & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '    End If
        'End If
        'If frmAdminRes.cbotrip.Text = "" Then
        'Else
        '    If andx = False Then
        '        strgo = " (tiketdtl.GoTrip=" & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & ")"
        '        'strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
        '        strback = " ( tiketdtl.TripBACK=" & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & ")"
        '        andx = True
        '    Else
        '        strgo = strgo & " and  (tiketdtl.GoTrip=" & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & ")"
        '        'strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
        '        strback = strback & " and  (tiketdtl.TripBACK=" & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & ")"
        '    End If
        'End If
        ' '''wgo = "(tiketdtl.goRuteID IN (SELECT ruteID FROM  rute WHERE rute.PortStart=" & frmAdminRes.cboPort.SelectedItem("PortID") & ")) AND (tiketdtl.GoDate = '" & Str2Date(frmAdminRes.txtdate.Text) & "')  AND (tiketdtl.GoTrip = " & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & ")"
        ' '''wback = "(tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE rute.PortStart =" & frmAdminRes.cboPort.SelectedItem("PortID") & ")) AND (tiketdtl.BackDate = '" & Str2Date(frmAdminRes.txtdate.Text) & "') AND (tiketdtl.TripBACK = " & frmAdminRes.cbotrip.SelectedItem("TripID").ToString & ")"
        ' '''sqlPrint = "SELECT '" & frmAdminRes.cboPort.Text & "' AS PORT,tiketdtl.NoETiket,tiketdtl.NoTiket,agent.AgentName,IF(tiketdtl.status > 0,   'Confirm',   'Cancel' ) AS STATUS, tiketdtl.mrs, tiketdtl.Guest, `tiketdtl`.`GoDate` AS Dates, IF(   tiketdtl.QtyTipe = 1,   'ADL',   IF(     tiketdtl.QtyTipe = 2,     'CHD',     IF(       tiketdtl.QtyTipe = 3,       'INF',       IF(tiketdtl.QtyTipe = 4, 'FOC', '')     )   ) ) AS AGE, IF(   tiketdtl.GoRuteID = 0,   '',   (SELECT      rute.RuteName    FROM     rute    WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF(   tiketdtl.Gotrip = 0,   '',   (SELECT      trip.TripName    FROM     trip    WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, IF(   `tiketdtl`.`Country` = '',   '',   (SELECT      country.CountryName    FROM     country    WHERE country.CountryID = tiketdtl.Country) ) AS CountryName, IF(   `tiketdtl`.`GoTrans` = 0,   'No',   'Yes' ) AS Transport, IF(   tiketdtl.GoArea = 0,   '',   (SELECT      area.AreaName    FROM     AREA   WHERE area.AreaID = tiketdtl.GoArea) ) AS AREA, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver FROM tiketdtl  INNER JOIN agent    ON (tiketdtl.AgentID = agent.AgentID) WHERE " & wgo & " UNION SELECT '" & frmAdminRes.cboPort.Text & "' AS PORT,   tiketdtl.NoETiket,   tiketdtl.NoTiket,   agent.AgentName,   IF(     tiketdtl.status > 0,     'Confirm',     'Cancel'   ) AS STATUS,   tiketdtl.mrs,   tiketdtl.Guest,   tiketdtl.BackDate AS Dates,   IF(     tiketdtl.QtyTipe = 1,     'ADL',     IF(       tiketdtl.QtyTipe = 2,       'CHD',       IF(         tiketdtl.QtyTipe = 3,         'INF',         IF(tiketdtl.QtyTipe = 4, 'FOC', '')       )     )   ) AS AGE,   IF(     tiketdtl.backRuteID = 0,     '',     (SELECT        rute.RuteName      FROM       rute      WHERE rute.RuteID = tiketdtl.backRuteID)   ) AS Rute,   IF(     tiketdtl.tripback = 0,     '',     (SELECT        trip.TripName      FROM       trip      WHERE trip.tripID = tiketdtl.Tripback)   ) AS Trip,   IF(     `tiketdtl`.`Country` = '',     '',     (SELECT        country.CountryName      FROM       country      WHERE country.CountryID = tiketdtl.Country)   ) AS CountryName,   IF(     `tiketdtl`.`backTrans` = 0,     '',     'Yes'   ) AS Transport,   IF(     tiketdtl.backArea = 0,     '',     (SELECT        area.AreaName      FROM       AREA     WHERE area.AreaID = tiketdtl.backArea)   ) AS AREA,   tiketdtl.backPickUp AS Location,   tiketdtl.backDriver AS Driver  FROM   tiketdtl    INNER JOIN agent      ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & wback
        ' '''sqlPrint = "SELECT '" & frmAdminRes.cboPort.Text & "' AS PORT,tiketdtl.ReqCollect,tiketdtl.NoETiket,tiketdtl.NoTiket,agent.AgentName,IF(tiketdtl.status > 0,   'Confirm',   'Cancel' ) AS STATUS, tiketdtl.mrs, tiketdtl.Guest, `tiketdtl`.`GoDate` AS Dates, IF(   tiketdtl.QtyTipe = 1,   'ADL',   IF(     tiketdtl.QtyTipe = 2,     'CHD',     IF(       tiketdtl.QtyTipe = 3,       'INF',       IF(tiketdtl.QtyTipe = 4, 'FOC', '')     )   ) ) AS AGE, IF(   tiketdtl.GoRuteID = 0,   '',   (SELECT      rute.RuteName    FROM     rute    WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF(   tiketdtl.Gotrip = 0,   '',   (SELECT      trip.TripName    FROM     trip    WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, IF(   `tiketdtl`.`Country` = '',   '',   (SELECT      country.CountryName    FROM     country    WHERE country.CountryID = tiketdtl.Country) ) AS CountryName, IF(   `tiketdtl`.`GoTrans` = 0,   'No',   'Yes' ) AS Transport, IF(   tiketdtl.GoArea = 0,   '',   (SELECT      area.AreaName    FROM     AREA   WHERE area.AreaID = tiketdtl.GoArea) ) AS AREA, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver FROM tiketdtl  INNER JOIN agent    ON (tiketdtl.AgentID = agent.AgentID) WHERE " & strgo & " UNION SELECT '" & frmAdminRes.cboPort.Text & "' AS PORT,tiketdtl.ReqCollect,   tiketdtl.NoETiket,   tiketdtl.NoTiket,   agent.AgentName,   IF(     tiketdtl.status > 0,     'Confirm',     'Cancel'   ) AS STATUS,   tiketdtl.mrs,   tiketdtl.Guest,   tiketdtl.BackDate AS Dates,   IF(     tiketdtl.QtyTipe = 1,     'ADL',     IF(       tiketdtl.QtyTipe = 2,       'CHD',       IF(         tiketdtl.QtyTipe = 3,         'INF',         IF(tiketdtl.QtyTipe = 4, 'FOC', '')       )     )   ) AS AGE,   IF(     tiketdtl.backRuteID = 0,     '',     (SELECT        rute.RuteName      FROM       rute      WHERE rute.RuteID = tiketdtl.backRuteID)   ) AS Rute,   IF(     tiketdtl.tripback = 0,     '',     (SELECT        trip.TripName      FROM       trip      WHERE trip.tripID = tiketdtl.Tripback)   ) AS Trip,   IF(     `tiketdtl`.`Country` = '',     '',     (SELECT        country.CountryName      FROM       country      WHERE country.CountryID = tiketdtl.Country)   ) AS CountryName,   IF(     `tiketdtl`.`backTrans` = 0,     '',     'Yes'   ) AS Transport,   IF(     tiketdtl.backArea = 0,     '',     (SELECT        area.AreaName      FROM       AREA     WHERE area.AreaID = tiketdtl.backArea)   ) AS AREA,   tiketdtl.backPickUp AS Location,   tiketdtl.backDriver AS Driver  FROM   tiketdtl    INNER JOIN agent      ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strback
        'sqlPrint = "SELECT '" & frmAdminRes.cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket, tiketdtl.remark, tiketdtl.NoTiket, agent.AgentName, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.mrs, tiketdtl.Guest, `tiketdtl`.`GoDate` AS Dates, IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( tiketdtl.GoRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF( tiketdtl.Gotrip = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName, IF( `tiketdtl`.`GoTrans` = 0, 'No', 'Yes' ) AS Transport, IF( tiketdtl.GoArea = 0, '', (SELECT area.AreaName FROM AREA WHERE area.AreaID = tiketdtl.GoArea) ) AS AREA, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) WHERE " & strgo & " UNION SELECT 'port' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket, tiketdtl.NoTiket, agent.AgentName, tiketdtl.remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.mrs, tiketdtl.Guest,tiketdtl.BackDate AS Dates, IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS Rute, IF( tiketdtl.tripback = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.Tripback) ) AS Trip, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName, IF( `tiketdtl`.`backTrans` = 0, 'No', 'Yes' ) AS Transport, IF( tiketdtl.backArea = 0, '', (SELECT area.AreaName FROM AREA WHERE area.AreaID = tiketdtl.backArea) ) AS AREA, tiketdtl.backPickUp AS Location, tiketdtl.backDriver AS Driver FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strback
        ''sqlPrint = "SELECT 0 as ID, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs,tiketdtl.ReqCollect, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, tiketdtl.GuestID, tiketdtl.GuestIDNO, tiketdtl.Country, IF(tiketdtl.Country='','',(SELECT country.CountryName FROM country WHERE country.CountryID=tiketdtl.Country)) AS CountryName, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC,tiketdtl.GoRuteID, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate, tiketdtl.GoTrip, trip.TripName , tiketdtl.GoRate , tiketdtl.GoExtra, IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, tiketdtl.GoTranRate, tiketdtl.GoTransExtra, tiketdtl.GoArea, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS DepartPickupArea, tiketdtl.GoPickUp AS PickupLocation, tiketdtl.GoDriver, tiketdtl.BackRuteID, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate, tiketdtl.TripBack, IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, tiketdtl.BackRate, tiketdtl.BackExtra, IF(tiketdtl.BackTrans=0,'No','Yes') AS Transport, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, tiketdtl.BackArea, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS ArrivalPickupArea, tiketdtl.BackPickup AS DepartPickupLocation, tiketdtl.BackDriver, tiketdtl.Remark, tiketdtl.status, tiketdtl.departgo, tiketdtl.Tipe FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strgo
        Dim crp As New RptTiketDaili
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(sqlPrint, conn)
        dt = New DataTable
        da.Fill(dt)
        crp.SetDataSource(dt)
        CrystalReportViewer1.ReportSource = crp
        CrystalReportViewer1.Refresh()
        Call DisconnectDatabase()
    End Sub

End Class