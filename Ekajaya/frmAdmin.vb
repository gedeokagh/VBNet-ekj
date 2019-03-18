Imports MySql.Data.MySqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmAdmin
    Dim totalpax, adl, chd, inf As Integer
    Dim totalko, totalj, totalc, totalp, sisa, totalls As Decimal
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
        Dim da2 As MySqlDataAdapter
        Dim dt2 As DataTable
        da2 = New MySqlDataAdapter("select PortID,PortName from port", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("PortID") = 0
        dr2("PortName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        cboport2.DataSource = dt2
        cboport2.DisplayMember = "PortName"

        Call DisconnectDatabase()
    End Sub


    Sub colorx()
        Dim i As Integer
        totalpax = 0
        adl = 0
        chd = 0
        inf = 0

        totalj = 0
        totalc = 0
        totalko = 0
        totalp = 0
        totalls = 0
        For i = 0 To LsData.Rows.Count() - 1 Step +1
            

            Dim val = Trim(LsData.Rows(i).Cells(38).Value)
            'val = LsData.Rows(i).Cells(44).ToString
            Dim vals = Trim(LsData.Rows(i).Cells(39).Value)
            'val = LsData.Rows(i).Cells(44).ToString
            If vals = 1 Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
            If val = 0 Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            Else

                adl = adl + NZx(LsData.Rows(i).Cells(15).Value)
                chd = chd + NZx(LsData.Rows(i).Cells(16).Value)
                inf = inf + NZx(LsData.Rows(i).Cells(17).Value)
                totalpax = totalpax + inf + adl + chd
                totalj = totalj + NZx(LsData.Rows(i).Cells(26).Value)
                totalc = totalc + NZx(LsData.Rows(i).Cells(27).Value)
                totalko = totalko + NZx(LsData.Rows(i).Cells(29).Value)
                totalp = totalp + NZx(LsData.Rows(i).Cells(30).Value)
                totalls = totalls + NZx(LsData.Rows(i).Cells(31).Value)
            End If
            sisa = totalj - totalc
            lbladl.Text = adl
            lblchd.Text = chd
            lblfoc.Text = inf
            lbljual.Text = CDbl(totalj).ToString("#,###")
            lblcollect.Text = CDbl(totalc).ToString("#,###")
            lblsisa.Text = CDbl(totalko).ToString("#,###")
            lblpiutang.Text = CDbl(totalp).ToString("#,###")
            lbllunas.Text = CDbl(totalls).ToString("#,###")
        Next
    End Sub
   
    Sub fillagent()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID,AgentName from agent ", conn)
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
   
    Sub fillRute()
        Call ConnectDatabase()
        Dim da, da2 As MySqlDataAdapter
        Dim dt, dt2 As DataTable
        da = New MySqlDataAdapter("select RuteID,RuteName from rute", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("RuteID") = 0
        dr("RuteName") = ""
        dt.Rows.InsertAt(dr, 0)
        'da.Fill(dt)
        cboGorute.DataSource = dt
        cboGorute.DisplayMember = "RuteName"
        da2 = New MySqlDataAdapter("select RuteID,RuteName from rute", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("RuteID") = 0
        dr2("RuteName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        cboruteback.DataSource = dt2
        cboruteback.DisplayMember = "RuteName"
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
    Sub filldriver()

        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select DriverID,DriverName from driver", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("DriverID") = 0
        dr("DriverName") = ""
        dt.Rows.InsertAt(dr, 0)
        'da.Fill(dt)
        cbodrv.DataSource = dt
        cbodrv.DisplayMember = "DriverName"

        Call DisconnectDatabase()
    End Sub
    'Sub fillarea()
    '    Call ConnectDatabase()
    '    Dim da, da2 As MySqlDataAdapter
    '    Dim dt, dt2 As DataTable
    '    da = New MySqlDataAdapter("select AreaID,AreaName from area", conn)
    '    dt = New DataTable
    '    Dim dr As DataRow = dt.NewRow
    '    da.Fill(dt)
    '    dr("AreaID") = 0
    '    dr("AreaName") = ""
    '    dt.Rows.InsertAt(dr, 0)
    '    'da.Fill(dt)
    '    cboGoArea.DataSource = dt
    '    cboGoArea.DisplayMember = "AreaName"
    '    da2 = New MySqlDataAdapter("select AreaID,AreaName from area", conn)
    '    dt2 = New DataTable
    '    Dim dr2 As DataRow = dt2.NewRow
    '    da2.Fill(dt2)
    '    dr2("AreaID") = 0
    '    dr2("AreaName") = ""
    '    dt2.Rows.InsertAt(dr2, 0)
    '    cboBackArea.DataSource = dt2
    '    cboBackArea.DisplayMember = "AreaName"
    '    Call DisconnectDatabase()
    'End Sub
    'Sub filldata(ByVal strCriteria As String)
    '    Dim strQry As String
    '    If strCriteria = "0" Then
    '        strQry = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE tiketdtl.Godate='" & Str2Date(Format(Now, "dd/MM/yyyy")) & "' ORDER BY  `agent`.`AgentName`"

    '    Else
    '        strQry = strCriteria
    '    End If
    '    Call ConnectDatabase()
    '    Dim da As MySqlDataAdapter
    '    Dim dt As DataTable


    '    da = New MySqlDataAdapter(strQry, conn)
    '    dt = New DataTable
    '    da.Fill(dt)
    '    LsData.DataSource = dt
    '    LsData.Columns(0).HeaderText = "ID"
    '    LsData.Columns(0).Visible = False
    '    LsData.Columns(1).HeaderText = "No.ETiket"
    '    LsData.Columns(1).Width = 125
    '    LsData.Columns(2).HeaderText = "No.Tiket"
    '    LsData.Columns(3).HeaderText = "Tipe"
    '    LsData.Columns(3).Width = 50
    '    LsData.Columns(4).HeaderText = "Agent"
    '    LsData.Columns(5).HeaderText = "Rute Berangkat"
    '    LsData.Columns(6).HeaderText = "Tgl Berangkat"
    '    LsData.Columns(6).DefaultCellStyle.Format = "dd/MM/yyyy"
    '    LsData.Columns(6).Width = 75
    '    LsData.Columns(7).HeaderText = "trip Berangkat"
    '    LsData.Columns(7).Width = 50
    '    LsData.Columns(8).HeaderText = "Rute Kembali"
    '    LsData.Columns(9).HeaderText = "tgl kembali"
    '    LsData.Columns(9).DefaultCellStyle.Format = "dd/MM/yyyy"
    '    LsData.Columns(9).Width = 75
    '    LsData.Columns(10).HeaderText = "Trip Kembali"
    '    LsData.Columns(10).Width = 50
    '    LsData.Columns(11).HeaderText = "Guest"
    '    LsData.Columns(12).HeaderText = "Adl"
    '    LsData.Columns(12).Width = 40
    '    LsData.Columns(13).HeaderText = "Chd"
    '    LsData.Columns(13).Width = 40
    '    LsData.Columns(14).HeaderText = "FOC"
    '    LsData.Columns(14).Width = 40
    '    LsData.Columns(15).HeaderText = "Harga berangkat"
    '    LsData.Columns(15).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(16).HeaderText = "Extra Berangkat"
    '    LsData.Columns(16).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(17).HeaderText = "Harga Kembali"
    '    LsData.Columns(17).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(18).HeaderText = "Extra Kembali"
    '    LsData.Columns(18).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(19).HeaderText = "tras.Berangkat"
    '    LsData.Columns(19).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(20).HeaderText = "ExtraTrans"
    '    LsData.Columns(20).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(21).HeaderText = "Tras.Kemb"
    '    LsData.Columns(21).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(22).HeaderText = "ExtraCost"
    '    LsData.Columns(22).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(23).HeaderText = "Total"
    '    LsData.Columns(23).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(24).HeaderText = "Collect"
    '    LsData.Columns(24).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(25).HeaderText = "Tgl Collect"
    '    LsData.Columns(25).Width = 75
    '    LsData.Columns(25).DefaultCellStyle.Format = "dd/MM/yyyy"
    '    LsData.Columns(26).HeaderText = "Utamg/Piutang"
    '    LsData.Columns(26).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(27).HeaderText = "PelPiutang"
    '    LsData.Columns(27).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(28).HeaderText = "PelKomisi"
    '    LsData.Columns(28).DefaultCellStyle.Format = "#,###"
    '    LsData.Columns(29).HeaderText = "No.Inv"
    '    LsData.Columns(30).HeaderText = "Tgl Inv"
    '    LsData.Columns(30).DefaultCellStyle.Format = "dd/MM/yyyy"
    '    LsData.Columns(30).Width = 75
    '    LsData.Columns(31).HeaderText = "TglLunas"
    '    LsData.Columns(31).DefaultCellStyle.Format = "dd/MM/yyyy"
    '    LsData.Columns(31).Width = 75
    '    LsData.Columns(32).HeaderText = "Driver Berangkat"
    '    LsData.Columns(33).HeaderText = "Driver Kembali"
    '    LsData.Columns(34).HeaderText = "Remark"
    '    LsData.Columns(35).HeaderText = "Status"
    '    LsData.Columns(35).Visible = False
    '    LsData.Columns(36).Visible = False
    '    Dim x As Integer
    '    For x = 0 To 35
    '        LsData.Columns(x).SortMode = DataGridViewColumnSortMode.NotSortable
    '    Next
    '    LsData.AllowUserToAddRows = False
    '    LsData.AllowUserToDeleteRows = False
    '    Call DisconnectDatabase()
    '    'head()
    '    colorx()
    'End Sub
    Sub filldata(ByVal strCriteria As String)
        Dim strQry As String
        If strCriteria = "0" Then
            strQry = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip, `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE tiketdtl.Godate='" & Str2Date(Format(Now, "dd/MM/yyyy")) & "' ORDER BY  `agent`.`AgentName`"

        Else
            strQry = strCriteria
        End If
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable


        da = New MySqlDataAdapter(strQry, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.Columns(0).HeaderText = "ID"
        LsData.Columns(0).Visible = False
        LsData.Columns(1).HeaderText = "No.ETiket"
        LsData.Columns(1).Width = 125
        LsData.Columns(2).HeaderText = "No.Tiket"
        LsData.Columns(3).HeaderText = "Tipe"
        LsData.Columns(3).Width = 50
        LsData.Columns(4).HeaderText = "Agent"
        LsData.Columns(5).HeaderText = "Rute Berangkat"
        LsData.Columns(6).HeaderText = "Tgl Berangkat"
        LsData.Columns(6).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(6).Width = 75
        LsData.Columns(7).HeaderText = "trip Berangkat"
        LsData.Columns(7).Width = 50
        LsData.Columns(8).HeaderText = "Rute Kembali"
        LsData.Columns(9).HeaderText = "tgl kembali"
        LsData.Columns(9).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(9).Width = 75
        LsData.Columns(10).HeaderText = "Trip Kembali"
        LsData.Columns(10).Width = 50

        LsData.Columns(11).HeaderText = "stopOver Rute"
        LsData.Columns(12).HeaderText = "tgl StopOver"
        LsData.Columns(12).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(12).Width = 75
        LsData.Columns(13).HeaderText = "Trip StopOver"
        LsData.Columns(13).Width = 50

        LsData.Columns(14).HeaderText = "Guest"
        LsData.Columns(15).HeaderText = "Adl"
        LsData.Columns(15).Width = 40
        LsData.Columns(16).HeaderText = "Chd"
        LsData.Columns(16).Width = 40
        LsData.Columns(17).HeaderText = "FOC"
        LsData.Columns(17).Width = 40
        LsData.Columns(18).HeaderText = "Harga berangkat"
        LsData.Columns(18).DefaultCellStyle.Format = "#,###"
        LsData.Columns(19).HeaderText = "Extra Berangkat"
        LsData.Columns(19).DefaultCellStyle.Format = "#,###"
        LsData.Columns(20).HeaderText = "Harga Kembali"
        LsData.Columns(20).DefaultCellStyle.Format = "#,###"
        LsData.Columns(21).HeaderText = "Extra Kembali"
        LsData.Columns(21).DefaultCellStyle.Format = "#,###"
        LsData.Columns(22).HeaderText = "tras.Berangkat"
        LsData.Columns(22).DefaultCellStyle.Format = "#,###"
        LsData.Columns(23).HeaderText = "ExtraTrans"
        LsData.Columns(23).DefaultCellStyle.Format = "#,###"
        LsData.Columns(24).HeaderText = "Tras.Kemb"
        LsData.Columns(24).DefaultCellStyle.Format = "#,###"
        LsData.Columns(25).HeaderText = "ExtraCost"
        LsData.Columns(25).DefaultCellStyle.Format = "#,###"
        LsData.Columns(26).HeaderText = "Total"
        LsData.Columns(26).DefaultCellStyle.Format = "#,###"
        LsData.Columns(27).HeaderText = "Collect"
        LsData.Columns(27).DefaultCellStyle.Format = "#,###"
        LsData.Columns(28).HeaderText = "Tgl Collect"
        LsData.Columns(28).Width = 75
        LsData.Columns(28).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(29).HeaderText = "Utamg/Piutang"
        LsData.Columns(29).DefaultCellStyle.Format = "#,###"
        LsData.Columns(30).HeaderText = "PelPiutang"
        LsData.Columns(30).DefaultCellStyle.Format = "#,###"
        LsData.Columns(31).HeaderText = "PelKomisi"
        LsData.Columns(31).DefaultCellStyle.Format = "#,###"
        LsData.Columns(32).HeaderText = "No.Inv"
        LsData.Columns(33).HeaderText = "Tgl Inv"
        LsData.Columns(33).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(33).Width = 75
        LsData.Columns(34).HeaderText = "TglLunas"
        LsData.Columns(34).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(34).Width = 75
        LsData.Columns(35).HeaderText = "Driver Berangkat"
        LsData.Columns(36).HeaderText = "Driver Kembali"
        LsData.Columns(37).HeaderText = "Remark"
        LsData.Columns(38).HeaderText = "Status"
        LsData.Columns(38).Visible = False
        LsData.Columns(39).Visible = False
        Dim x As Integer
        For x = 0 To 36
            LsData.Columns(x).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        Call DisconnectDatabase()
        'head()
        colorx()
    End Sub
    Private Sub frmAdmin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub frmAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'sLoginForm1.Close()
        MenuStrip2.Visible = False
        fillagent()
        fillRute()
        filltrip()
        lblUser.Text = usr
        filldata("0")
        fillPort()
        filldriver()
        If level >= 3 And level <= 4 Then
            MenuStrip1.Visible = False
        End If
        If level = 1 Then
            MenuStrip2.Visible = True
            MenuStrip1.Visible = False
        End If
        Text1.Text = ""

    End Sub

    Private Sub DataUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmUser.Show()
    End Sub

    Private Sub DataRuteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataRuteToolStripMenuItem.Click
        frmRute.Show()
    End Sub


    Private Sub DataTripToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataTripToolStripMenuItem.Click
        frmTrip.Show()
    End Sub

    Private Sub DataAgentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataAgentToolStripMenuItem.Click
        frmAgent.Show()
    End Sub

    Private Sub DataAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataAreaToolStripMenuItem.Click
        frmArea.Show()
    End Sub

    Private Sub AgentPriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAgentRate.Show()
    End Sub

    Private Sub BookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBooking.Show()
    End Sub

    Private Sub GenerateTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateTicketToolStripMenuItem.Click
        frmGenTiket.Show()
    End Sub

    Private Sub CommisionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmInvoicing.Show()
    End Sub

    Private Sub InvoicingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoicingToolStripMenuItem.Click
        frmInvoicing.Show()
    End Sub

    Private Sub InvoicePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoicePaymentToolStripMenuItem.Click
        frmInvPayment.Show()
    End Sub

    Private Sub CommisionToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''frmBookPay.Show()
    End Sub

    'Private Sub cmdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    frmBooking.Show()
    'End Sub

    'Private Sub cmdEdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If LsData.RowCount = 0 Then
    '        MsgBox("No Data To Update", vbInformation, "Data")
    '        Exit Sub
    '    End If
    '    If Text1.Text = "" Then
    '        MsgBox("Please Choose Data to Update", vbInformation, "Data")
    '        Exit Sub
    '    End If
    '    Dim GST As String = ""
    '    frmEditBooking.txtNoBook.Text = LsData.CurrentRow.Cells(1).Value
    '    frmEditBooking.txttiket.Text = LsData.CurrentRow.Cells(2).Value
    '    frmEditBooking.cbomrs.Text = LsData.CurrentRow.Cells(4).Value
    '    frmEditBooking.txtagent.Text = LsData.CurrentRow.Cells(3).Value
    '    frmEditBooking.txtName.Text = LsData.CurrentRow.Cells(5).Value
    '    frmEditBooking.cbotipeID.Text = LsData.CurrentRow.Cells(6).Value
    '    frmEditBooking.txtnoID.Text = LsData.CurrentRow.Cells(7).Value
    '    frmEditBooking.cboCountry.Text = LsData.CurrentRow.Cells(9).Value
    '    If LsData.CurrentRow.Cells(44).Value = "RT" Then
    '        frmEditBooking.cbotipe.Text = "RT - Return"
    '    Else
    '        frmEditBooking.cbotipe.Text = "OW - One Way"
    '    End If
    '    If LsData.CurrentRow.Cells(10).Value > 0 Then
    '        GST = "1 - Adult"
    '    End If
    '    If LsData.CurrentRow.Cells(11).Value > 0 Then
    '        GST = "2 - Child"
    '    End If
    '    If LsData.CurrentRow.Cells(12).Value > 0 Then
    '        GST = "3 - Infant/FOC"
    '    End If
    '    frmEditBooking.cboGst.Text = GST
    '    frmEditBooking.cboGorute.Text = LsData.CurrentRow.Cells(14).Value
    '    frmEditBooking.txtgodate.Text = LsData.CurrentRow.Cells(15).Value
    '    frmEditBooking.cboGotrip.Text = LsData.CurrentRow.Cells(17).Value
    '    frmEditBooking.txtgorate.Text = LsData.CurrentRow.Cells(18).Value
    '    If LsData.CurrentRow.Cells(20).Value = "yes" Then
    '        frmEditBooking.CxGoTrans.CheckState = CheckState.Checked
    '    Else
    '        frmEditBooking.CxGoTrans.CheckState = CheckState.Unchecked
    '    End If
    '    frmEditBooking.txttransgorate.Text = LsData.CurrentRow.Cells(21).Value
    '    frmEditBooking.txtextrago.Text = LsData.CurrentRow.Cells(19).Value
    '    frmEditBooking.txtgoextra.Text = LsData.CurrentRow.Cells(22).Value
    '    frmEditBooking.cboGoArea.Text = LsData.CurrentRow.Cells(24).Value
    '    frmEditBooking.txtpickupgo.Text = LsData.CurrentRow.Cells(25).Value
    '    frmEditBooking.txtdrivego.Text = LsData.CurrentRow.Cells(26).Value
    '    frmEditBooking.cboruteback.Text = LsData.CurrentRow.Cells(28).Value
    '    If IsDBNull(LsData.CurrentRow.Cells(29).Value) = False Then
    '        frmEditBooking.txtbackdate.Text = LsData.CurrentRow.Cells(29).Value
    '    Else
    '        frmEditBooking.txtbackdate.CustomFormat = " "
    '        frmEditBooking.txtbackdate.Format = DateTimePickerFormat.Custom

    '    End If
    '    'frmEditBooking.txtbackdate.Text = LsData.CurrentRow.Cells(29).Value
    '    frmEditBooking.cbotripback.Text = LsData.CurrentRow.Cells(31).Value
    '    frmEditBooking.txtbackrate.Text = LsData.CurrentRow.Cells(32).Value
    '    frmEditBooking.txtexback.Text = LsData.CurrentRow.Cells(33).Value

    '    If LsData.CurrentRow.Cells(20).Value = "Yes" Then
    '        frmEditBooking.CxGoTrans.CheckState = CheckState.Checked
    '    Else
    '        frmEditBooking.CxGoTrans.CheckState = CheckState.Unchecked
    '    End If
    '    If LsData.CurrentRow.Cells(34).Value = "Yes" Then
    '        frmEditBooking.CxBackTrans.CheckState = CheckState.Checked
    '    Else
    '        frmEditBooking.CxBackTrans.CheckState = CheckState.Unchecked
    '    End If
    '    frmEditBooking.txttransbackrate.Text = LsData.CurrentRow.Cells(35).Value
    '    frmEditBooking.txtbackExtra.Text = LsData.CurrentRow.Cells(36).Value
    '    frmEditBooking.cboBackArea.Text = LsData.CurrentRow.Cells(38).Value
    '    frmEditBooking.txtPickupBack.Text = LsData.CurrentRow.Cells(39).Value
    '    frmEditBooking.txtbackDrive.Text = LsData.CurrentRow.Cells(40).Value
    '    frmEditBooking.txtremark.Text = LsData.CurrentRow.Cells(41).Value
    '    frmEditBooking.Show()
    '    If LsData.CurrentRow.Cells(44).Value = "RT" Then
    '        cbotipe.Text = "RT - Return"
    '    Else
    '        cbotipe.Text = "OW - One Way"
    '    End If
    '    frmEditBooking.cbotripback.Text = LsData.CurrentRow.Cells(31).Value
    '    frmEditBooking.cboBackArea.Text = LsData.CurrentRow.Cells(38).Value
    '    frmEditBooking.cboGotrip.Text = LsData.CurrentRow.Cells(17).Value
    '    frmEditBooking.cboGorute.Text = LsData.CurrentRow.Cells(14).Value
    '    frmEditBooking.cboruteback.Text = LsData.CurrentRow.Cells(28).Value
    '    frmEditBooking.cboGoArea.Text = LsData.CurrentRow.Cells(24).Value

    '    If LsData.CurrentRow.Cells(20).Value = "Yes" Then
    '        frmEditBooking.CxGoTrans.CheckState = CheckState.Checked
    '    Else
    '        frmEditBooking.CxGoTrans.CheckState = CheckState.Unchecked
    '    End If
    '    If LsData.CurrentRow.Cells(34).Value = "Yes" Then
    '        frmEditBooking.CxBackTrans.CheckState = CheckState.Checked
    '    Else
    '        frmEditBooking.CxBackTrans.CheckState = CheckState.Unchecked
    '    End If
    '    frmEditBooking.txtagent.Text = LsData.CurrentRow.Cells(3).Value
    '    frmEditBooking.cboCountry.Text = LsData.CurrentRow.Cells(9).Value
    '    frmEditBooking.cbotipeID.Text = LsData.CurrentRow.Cells(6).Value
    '    frmEditBooking.cboGst.Text = GST
    'End Sub

    Private Sub LsData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellClick
        Text1.Text = LsData.CurrentRow.Cells(3).Value
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        'Text1.Text = LsData.CurrentRow.Cells(3).Value
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        Dim str As String = ""
        Dim go As String = ""
        Dim SO As String = ""
        Dim back As String = ""
        Dim sql As String = ""
        Dim ands As Boolean = False
        'If cboPort.SelectedItem("PortID") > 2 Then
        '    Dim andX As Boolean = False
        '    If cboAgent.Text = "" Then
        '    Else
        '        str = " (tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "')"
        '        ands = True
        '    End If
        '    'If cboGorute.Text = "" Then
        '    'Else
        '    '    If ands = False Then
        '    '        str = " (tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString() & ")"
        '    '        ands = True
        '    '    Else
        '    '        str = str & " and (tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString & ")"
        '    '        ands = True
        '    '    End If
        '    'End If
        '    If cbotipe.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " (tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "')"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "')"
        '            ands = True
        '        End If
        '    End If
        '    'If cboruteback.Text = "" Then
        '    'Else
        '    '    If ands = False Then
        '    '        str = " (tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString & ")"
        '    '        ands = True
        '    '    Else
        '    '        str = str & " and (tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString & ")"
        '    '        ands = True
        '    '    End If
        '    'End If
        '    If cboGotrip.Text = "" Then
        '    Else
        '        If andX = False Then

        '            go = " ((tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & ") )"
        '            'back = " (1=1) "
        '            back = " (tiketdtl.`TripBack`=" & cboGotrip.SelectedItem("TripID").ToString & ")"
        '            andX = True
        '        Else
        '            'str = str & " and ((tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & ") or (tiketdtl.BackTrip=" & cboGotrip.SelectedItem("TripID").ToString & "))"
        '            go = go & " AND ((tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & "))"
        '            back = back & " AND (tiketdtl.`TripBack`=" & cboGotrip.SelectedItem("TripID").ToString & ")"
        '            'back = back & " AND 1=1"
        '            andX = True
        '        End If
        '    End If
        '    If cbotripback.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " (tiketdtl.`TripBack`=" & cbotripback.SelectedItem("TRIPID").ToString & ")"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.`TripBack`=" & cbotripback.SelectedItem("TRIPID").ToString & ")"
        '            ands = True
        '        End If
        '    End If
        '    If Trim(txtgodate.Text) = "" Then
        '    Else
        '        If Trim(txtgodate2.Text) = "" Then
        '            MsgBox("Departure To date is empty", vbInformation, "Error")
        '            Exit Sub
        '        End If
        '        If andX = False Then
        '            go = " (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
        '            back = " (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
        '            andX = True
        '        Else
        '            'str = str & " and ((tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "') or (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "'))"
        '            go = go & " And (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
        '            back = back & " and (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
        '            andX = True
        '        End If
        '    End If
        '    If Trim(txtbackdate.Text) = "" Then
        '    Else
        '        If Trim(txtbackdate2.Text) = "" Then
        '            MsgBox("Arrival To date is empty", vbInformation, "Error")
        '            Exit Sub
        '        End If
        '        If ands = False Then
        '            str = " (tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "'" & ")"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "')"
        '            ands = True
        '        End If
        '    End If
        '    If cboPort.Text = "" Then
        '    Else
        '        Dim ctr = cboPort.SelectedItem("PortID")
        '        If andX = False Then
        '            go = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
        '            back = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '            andX = True
        '        Else
        '            'str = str & " and ((tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) or (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")))"
        '            go = go & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
        '            back = back & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '        End If
        '    End If
        '    If cboport2.Text = "" Then
        '    Else
        '        Dim ctrS = cboport2.SelectedItem("PortID")
        '        If ands = False Then
        '            'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
        '            'str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '            str = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & ")"
        '            ands = True
        '        Else
        '            'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
        '            'str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '            str = str & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & "))"
        '        End If
        '    End If
        '    If cboCountry.Text = "" Then
        '    Else
        '        'If ands = False Then
        '        '    str = " tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString()
        '        '    ands = True
        '        'Else
        '        '    str = str & " and tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString
        '        '    ands = True
        '        'End If
        '        Select Case cboCountry.Text
        '            Case "All"
        '                str = str
        '            Case "Belum(Invoice)"
        '                str = str & " and (tiketdtl.INV=0) AND (tiketdtl.PAY=0) and (NoInv='' or isnull(NoInv))"
        '            Case "Invoice"
        '                str = str & " and (tiketdtl.INV=1) AND (tiketdtl.PAY=0) "
        '            Case "Sudah Lunas"
        '                str = str & " ANd (tiketdtl.PAY=1 OR TIKETDTL.TGLLUNAS<>'')"
        '        End Select
        '    End If
        '    If TextBox1.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
        '            ands = True
        '        End If

        '    End If

        '    If txtremark.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " (tiketdtl.remark like '%" & txtremark.Text & "%')"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.remark like '%" & txtremark.Text & "%')"
        '            ands = True
        '        End If

        '    End If
        '    If txtinv.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " (tiketdtl.noinv = '" & txtinv.Text & "')"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.noinv = '" & txtinv.Text & "')"
        '            ands = True
        '        End If

        '    End If

        '    If cbodrv.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
        '            ands = True
        '        Else
        '            str = str & " AND ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
        '            ands = True
        '        End If
        '    End If
        '    If txtstart.Text = "" Then
        '    Else
        '        If txtend.Text = "" Then
        '            MsgBox("Please Input End Tiket", vbInformation, "Error Filter")
        '            txtend.Focus()
        '            Exit Sub
        '        Else
        '            If ands = False Then
        '                str = " (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
        '                ands = True
        '            Else
        '                str = str & " AND (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
        '                ands = True
        '            End If
        '        End If

        '    End If
        '    If price1.Text = "" Then
        '    Else
        '        If Not IsNumeric(price1.Text) Then
        '            MsgBox("Please Price with Number", vbInformation, "Error Filter")
        '            price1.Focus()
        '            Exit Sub
        '        End If
        '        If price2.Text = "" Then
        '            MsgBox("Please Range Price", vbInformation, "Error Filter")
        '            price2.Focus()
        '            Exit Sub
        '        Else
        '            If Not IsNumeric(price2.Text) Then
        '                MsgBox("Please Price with Number", vbInformation, "Error Filter")
        '                price2.Focus()
        '                Exit Sub
        '            End If
        '            If ands = False Then
        '                str = " ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
        '                ands = True
        '            Else
        '                str = str & " AND ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
        '                ands = True
        '            End If
        '        End If

        '    End If
        '    If str = "" Then
        '        sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE (" & go & " )  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE ( " & back & ") ORDER BY  `NOETIKET`"
        '    Else
        '        sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and(" & go & ")  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & back & ") ORDER BY  `AgentName`"
        '    End If

        'Else

        '    '' from PBai & Serangan
        '    If cboAgent.Text = "" Then
        '    Else
        '        str = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "'"
        '        ands = True
        '    End If
        '    If cboGorute.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString()
        '            ands = True
        '        Else
        '            str = str & " and tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString
        '            ands = True
        '        End If
        '    End If
        '    If cbotipe.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "'"
        '            ands = True
        '        Else
        '            str = str & " and tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "'"
        '            ands = True
        '        End If
        '    End If
        '    If cboruteback.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString
        '            ands = True
        '        Else
        '            str = str & " and tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString
        '            ands = True
        '        End If
        '    End If
        '    If cboGotrip.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString
        '            ands = True
        '        Else
        '            str = str & " and tiketdtl.GoTrip=" & cboGotrip.SelectedItem("tripID").ToString
        '            ands = True
        '        End If
        '    End If
        '    If cbotripback.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " tiketdtl.`TripBack`=" & cbotripback.SelectedItem("tripID").ToString
        '            ands = True
        '        Else
        '            str = str & " and tiketdtl.`TripBack`=" & cbotripback.SelectedItem("tripID").ToString
        '            ands = True
        '        End If
        '    End If
        '    If Trim(txtgodate.Text) = "" Then
        '    Else
        '        If Trim(txtgodate2.Text) = "" Then
        '            MsgBox("Departure To date is empty", vbInformation, "Error")
        '            Exit Sub
        '        End If
        '        If ands = False Then
        '            str = "(tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
        '            ands = True
        '        End If
        '    End If
        '    If Trim(txtbackdate.Text) = "" Then
        '    Else
        '        If Trim(txtbackdate2.Text) = "" Then
        '            MsgBox("Arrival To date is empty", vbInformation, "Error")
        '            Exit Sub
        '        End If
        '        If ands = False Then
        '            str = " tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "'"
        '            ands = True
        '        Else
        '            str = str & " and tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "'"
        '            ands = True
        '        End If
        '    End If
        '    If cboPort.Text = "" Then
        '    Else
        '        Dim ctr = cboPort.SelectedItem("PortID")
        '        If ands = False Then
        '            str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '        End If
        '    End If
        '    If cboport2.Text = "" Then
        '    Else
        '        Dim ctrS = cboport2.SelectedItem("PortID")
        '        If ands = False Then
        '            'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
        '            'str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '            str = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & ")"
        '            ands = True
        '        Else
        '            'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
        '            'str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
        '            str = str & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & "))"
        '        End If
        '    End If
        '    If cboCountry.Text = "" Then
        '    Else
        '        'If ands = False Then
        '        '    str = " tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString()
        '        '    ands = True
        '        'Else
        '        '    str = str & " and tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString
        '        '    ands = True
        '        'End If
        '        Select Case cboCountry.Text
        '            Case "All"
        '                str = str
        '            Case "Belum Invoice"
        '                str = str & " and tiketdtl.INV=0 AND tiketdtl.PAY=0  and (NoInv='' or isnull(NoInv))"
        '            Case "Invoice"
        '                str = str & " and tiketdtl.INV=1 AND tiketdtl.PAY=0 "
        '            Case "Sudah Lunas"
        '                str = str & " ANd (tiketdtl.PAY=1 OR TIKETDTL.TGLLUNAS<>'')"
        '        End Select
        '    End If
        '    If TextBox1.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
        '            ands = True
        '        End If

        '    End If

        '    If txtremark.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " (tiketdtl.remark like '%" & txtremark.Text & "%')"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.remark like '%" & txtremark.Text & "%')"
        '            ands = True
        '        End If

        '    End If
        '    If txtinv.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " (tiketdtl.noinv = '" & txtinv.Text & "')"
        '            ands = True
        '        Else
        '            str = str & " and (tiketdtl.noinv = '" & txtinv.Text & "')"
        '            ands = True
        '        End If

        '    End If

        '    If cbodrv.Text = "" Then
        '    Else
        '        If ands = False Then
        '            str = " ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
        '            ands = True
        '        Else
        '            str = str & " AND ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
        '            ands = True
        '        End If
        '    End If
        '    If txtstart.Text = "" Then
        '    Else
        '        If txtend.Text = "" Then
        '            MsgBox("Please Input End Tiket", vbInformation, "Error Filter")
        '            txtend.Focus()
        '            Exit Sub
        '        Else
        '            If ands = False Then
        '                str = " (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
        '                ands = True
        '            Else
        '                str = str & " AND (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
        '                ands = True
        '            End If
        '        End If

        '    End If
        '    If price1.Text = "" Then
        '    Else
        '        If Not IsNumeric(price1.Text) Then
        '            MsgBox("Please Price with Number", vbInformation, "Error Filter")
        '            price1.Focus()
        '            Exit Sub
        '        End If
        '        If price2.Text = "" Then
        '            MsgBox("Please Range Price", vbInformation, "Error Filter")
        '            price2.Focus()
        '            Exit Sub
        '        Else
        '            If Not IsNumeric(price2.Text) Then
        '                MsgBox("Please Price with Number", vbInformation, "Error Filter")
        '                price2.Focus()
        '                Exit Sub
        '            End If
        '            If ands = False Then
        '                str = " ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
        '                ands = True
        '            Else
        '                str = str & " AND ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
        '                ands = True
        '            End If
        '        End If

        '    End If
        '    sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`,if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " ORDER BY  `agent`.`AgentName`"
        'End If
        If cboPort.SelectedItem("PortID") > 2 Then
            Dim andX As Boolean = False
            If cboAgent.Text = "" Then
            Else
                str = " (tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "')"
                ands = True
            End If
            If cboGorute.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString() & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString & ")"
                    ands = True
                End If
            End If
            If cbotipe.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "')"
                    ands = True
                End If
            End If
            '
            If cboGotrip.Text = "" Then
            Else
                If andX = False Then

                    go = " ((tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & ") )"
                    SO = " ((tiketdtl.sotrip=" & cboGotrip.SelectedItem("TripID").ToString & ") )"
                    'back = " (1=1) "
                    back = " (tiketdtl.`TripBack`=" & cboGotrip.SelectedItem("TripID").ToString & ")"
                    andX = True
                Else
                    'str = str & " and ((tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & ") or (tiketdtl.BackTrip=" & cboGotrip.SelectedItem("TripID").ToString & "))"
                    go = go & " AND ((tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & "))"
                    SO = SO & " And ((tiketdtl.sotrip=" & cboGotrip.SelectedItem("TripID").ToString & ") )"
                    back = back & " AND (tiketdtl.`TripBack`=" & cboGotrip.SelectedItem("TripID").ToString & ")"
                    'back = back & " AND 1=1"
                    andX = True
                End If
            End If

            If Trim(txtgodate.Text) = "" Then
            Else
                If Trim(txtgodate2.Text) = "" Then
                    MsgBox("Departure To date is empty", vbInformation, "Error")
                    Exit Sub
                End If
                If andX = False Then
                    go = " (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    SO = " (tiketdtl.sodate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    back = " (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    andX = True
                Else
                    'str = str & " and ((tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "') or (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "'))"
                    go = go & " And (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    SO = SO & " and (tiketdtl.sodate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    back = back & " and (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    andX = True
                End If
            End If

            If cboPort.Text = "" Then
            Else
                Dim ctr = cboPort.SelectedItem("PortID")
                If andX = False Then
                    go = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
                    SO = " (tiketdtl.sorute IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
                    back = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    andX = True
                Else
                    'str = str & " and ((tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) or (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")))"
                    go = go & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
                    SO = SO & " and (tiketdtl.sorute IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
                    back = back & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                End If
            End If

            If cboCountry.Text = "" Then
            Else
                'If ands = False Then
                '    str = " tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString()
                '    ands = True
                'Else
                '    str = str & " and tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString
                '    ands = True
                'End If
                Select Case cboCountry.Text
                    Case "All"
                        str = str
                    Case "Belum(Invoice)"
                        str = str & " and (tiketdtl.INV=0) AND (tiketdtl.PAY=0) and (NoInv='' or isnull(NoInv))"
                    Case "Invoice"
                        str = str & " and (tiketdtl.INV=1) AND (tiketdtl.PAY=0) "
                    Case "Sudah Lunas"
                        str = str & " ANd (tiketdtl.PAY=1 OR TIKETDTL.TGLLUNAS<>'')"
                End Select
            End If
            If TextBox1.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                    ands = True
                End If

            End If

            If txtremark.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.remark like '%" & txtremark.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.remark like '%" & txtremark.Text & "%')"
                    ands = True
                End If

            End If
            If txtinv.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.noinv = '" & txtinv.Text & "')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.noinv = '" & txtinv.Text & "')"
                    ands = True
                End If

            End If

            If cbodrv.Text = "" Then
            Else
                If ands = False Then
                    str = " ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
                    ands = True
                Else
                    str = str & " AND ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
                    ands = True
                End If
            End If

            If price1.Text = "" Then
            Else
                If Not IsNumeric(price1.Text) Then
                    MsgBox("Please Price with Number", vbInformation, "Error Filter")
                    price1.Focus()
                    Exit Sub
                End If
                If price2.Text = "" Then
                    MsgBox("Please Range Price", vbInformation, "Error Filter")
                    price2.Focus()
                    Exit Sub
                Else
                    If Not IsNumeric(price2.Text) Then
                        MsgBox("Please Price with Number", vbInformation, "Error Filter")
                        price2.Focus()
                        Exit Sub
                    End If
                    If ands = False Then
                        str = " ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
                        ands = True
                    Else
                        str = str & " AND ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
                        ands = True
                    End If
                End If

            End If
            If Trim(txtbackdate.Text) = "" Then
            Else
                If Trim(txtbackdate2.Text) = "" Then
                    MsgBox("Arrival To date is empty", vbInformation, "Error")
                    Exit Sub
                End If
                If ands = False Then
                    str = " (tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "'" & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "')"
                    ands = True
                End If
            End If
            '===================================================
            If cboruteback.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString & ")"
                    ands = True
                End If
            End If
            If txtstart.Text = "" Then
            Else
                If txtend.Text = "" Then
                    MsgBox("Please Input End Tiket", vbInformation, "Error Filter")
                    txtend.Focus()
                    Exit Sub
                Else
                    If ands = False Then
                        str = " (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    Else
                        str = str & " AND (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    End If
                End If

            End If
            If cboport2.Text = "" Then
            Else
                Dim ctrS = cboport2.SelectedItem("PortID")
                If ands = False Then
                    'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                    'str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    str = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & "))"
                    ands = True
                Else
                    'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                    'str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    str = str & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & "))"
                End If
            End If
            If cbotripback.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.`TripBack`=" & cbotripback.SelectedItem("TRIPID").ToString & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.`TripBack`=" & cbotripback.SelectedItem("TRIPID").ToString & ")"
                    ands = True
                End If
            End If
            If txtstart.Text = "" Then
            Else
                If txtend.Text = "" Then
                    MsgBox("Please Input End Tiket", vbInformation, "Error Filter")
                    txtend.Focus()
                    Exit Sub
                Else
                    If ands = False Then
                        str = " (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    Else
                        str = str & " AND (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    End If
                End If

            End If
            If txtetiket.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.NoETiket like '%" & txtetiket.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.NoETiket like '%" & txtetiket.Text & "%')"
                    ands = True
                End If

            End If
            If txtbooking.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.NoBook like '%" & txtbooking.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.NoBook like '%" & txtbooking.Text & "%')"
                    ands = True
                End If

            End If
            '=====================================
            If (ands = False) And andX = False Then
                MsgBox("Please Select Filter", vbInformation, "Error Filter")
                Exit Sub
            ElseIf (ands = True) And (andX = False) Then
                sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & "  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & "  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " ORDER BY  `AgentName`"
            ElseIf (ands = False) And (andX = True) Then
                sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and(" & go & ")  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & back & ") UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & SO & ") ORDER BY  `AgentName`"
            End If
            'If str = "" Then
            '    'sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE (" & go & " )  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE ( " & back & ") ORDER BY  `NOETIKET`"
            '    sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE (" & go & " )  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali, IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE ( " & back & ") UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali, IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE ( " & SO & ") ORDER BY  `NOETIKET`"
            'Else
            '    'sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and(" & go & ")  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & back & ") ORDER BY  `AgentName`"
            '    sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and(" & go & ")  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & back & ") UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & SO & ") ORDER BY  `AgentName`"
            'End If

        Else

            '' from PBai & Serangan
            If cboAgent.Text = "" Then
            Else
                str = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "'"
                ands = True
            End If
            If cboGorute.Text = "" Then
            Else
                If ands = False Then
                    str = " tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString()
                    ands = True
                Else
                    str = str & " and tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString
                    ands = True
                End If
            End If
            If cbotipe.Text = "" Then
            Else
                If ands = False Then
                    str = " tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "'"
                    ands = True
                Else
                    str = str & " and tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "'"
                    ands = True
                End If
            End If

            If cboGotrip.Text = "" Then
            Else
                If ands = False Then
                    str = " tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString
                    ands = True
                Else
                    str = str & " and tiketdtl.GoTrip=" & cboGotrip.SelectedItem("tripID").ToString
                    ands = True
                End If
            End If

            If Trim(txtgodate.Text) = "" Then
            Else
                If Trim(txtgodate2.Text) = "" Then
                    MsgBox("Departure To date is empty", vbInformation, "Error")
                    Exit Sub
                End If
                If ands = False Then
                    str = "(tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    ands = True
                End If
            End If

            If cboPort.Text = "" Then
            Else
                Dim ctr = cboPort.SelectedItem("PortID")
                If ands = False Then
                    str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    ands = True
                Else
                    str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                End If
            End If

            If cboCountry.Text = "" Then
            Else
                'If ands = False Then
                '    str = " tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString()
                '    ands = True
                'Else
                '    str = str & " and tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString
                '    ands = True
                'End If
                Select Case cboCountry.Text
                    Case "All"
                        str = str
                    Case "Belum Invoice"
                        str = str & " and tiketdtl.INV=0 AND tiketdtl.PAY=0  and (NoInv='' or isnull(NoInv))"
                    Case "Invoice"
                        str = str & " and tiketdtl.INV=1 AND tiketdtl.PAY=0 "
                    Case "Sudah Lunas"
                        str = str & " ANd (tiketdtl.PAY=1 OR TIKETDTL.TGLLUNAS<>'')"
                End Select
            End If
            If TextBox1.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                    ands = True
                End If

            End If

            If txtremark.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.remark like '%" & txtremark.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.remark like '%" & txtremark.Text & "%')"
                    ands = True
                End If

            End If
            If txtinv.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.noinv = '" & txtinv.Text & "')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.noinv = '" & txtinv.Text & "')"
                    ands = True
                End If

            End If

            If cbodrv.Text = "" Then
            Else
                If ands = False Then
                    str = " ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
                    ands = True
                Else
                    str = str & " AND ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
                    ands = True
                End If
            End If

            If price1.Text = "" Then
            Else
                If Not IsNumeric(price1.Text) Then
                    MsgBox("Please Price with Number", vbInformation, "Error Filter")
                    price1.Focus()
                    Exit Sub
                End If
                If price2.Text = "" Then
                    MsgBox("Please Range Price", vbInformation, "Error Filter")
                    price2.Focus()
                    Exit Sub
                Else
                    If Not IsNumeric(price2.Text) Then
                        MsgBox("Please Price with Number", vbInformation, "Error Filter")
                        price2.Focus()
                        Exit Sub
                    End If
                    If ands = False Then
                        str = " ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
                        ands = True
                    Else
                        str = str & " AND ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
                        ands = True
                    End If
                End If

            End If
            If Trim(txtbackdate.Text) = "" Then
            Else
                If Trim(txtbackdate2.Text) = "" Then
                    MsgBox("Arrival To date is empty", vbInformation, "Error")
                    Exit Sub
                End If
                If ands = False Then
                    str = " (tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "'" & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "')"
                    ands = True
                End If
            End If
            '===================================================
            If cboruteback.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString & ")"
                    ands = True
                End If
            End If
            If txtstart.Text = "" Then
            Else
                If txtend.Text = "" Then
                    MsgBox("Please Input End Tiket", vbInformation, "Error Filter")
                    txtend.Focus()
                    Exit Sub
                Else
                    If ands = False Then
                        str = " (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    Else
                        str = str & " AND (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    End If
                End If

            End If
            If cboport2.Text = "" Then
            Else
                Dim ctrS = cboport2.SelectedItem("PortID")
                If ands = False Then
                    'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                    'str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    str = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & "))"
                    ands = True
                Else
                    'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                    'str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    str = str & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & "))"
                End If
            End If
            If cbotripback.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.`TripBack`=" & cbotripback.SelectedItem("TRIPID").ToString & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.`TripBack`=" & cbotripback.SelectedItem("TRIPID").ToString & ")"
                    ands = True
                End If
            End If
            If txtstart.Text = "" Then
            Else
                If txtend.Text = "" Then
                    MsgBox("Please Input End Tiket", vbInformation, "Error Filter")
                    txtend.Focus()
                    Exit Sub
                Else
                    If ands = False Then
                        str = " (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    Else
                        str = str & " AND (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    End If
                End If

            End If
            If txtetiket.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.NoETiket like '%" & txtetiket.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.NoETiket like '%" & txtetiket.Text & "%')"
                    ands = True
                End If

            End If
            If txtbooking.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.NoBook like '%" & txtbooking.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.NoBook like '%" & txtbooking.Text & "%')"
                    ands = True
                End If

            End If
            '=====================================
            'If (ands = False) And andX = False Then
            '    MsgBox("Please Select Filter", vbInformation, "Error Filter")
            '    Exit Sub
            'ElseIf (ands = True) And (andX = False) Then
            '    sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & "  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & "  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " ORDER BY  `AgentName`"
            'Else
            '    sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and(" & go & ")  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & back & ") UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & SO & ") ORDER BY  `AgentName`"
            'End If
            If (ands = False) Then
                MsgBox("Please Select Filter", vbInformation, "Error Filter")
                Exit Sub
            Else
                sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & "  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & "  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " ORDER BY  `AgentName`"
            End If
            ' sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`,if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " ORDER BY  `agent`.`AgentName`"
        End If

            filldata(sql)
            'colorx()
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

    Private Sub txtgodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgodate.ValueChanged
        txtgodate.Format = DateTimePickerFormat.Custom
        txtgodate.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub txtbackdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbackdate.ValueChanged
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub SeriesTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeriesTicketToolStripMenuItem.Click
        frmSellBook.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrintTiketList.Show()
    End Sub

    Private Sub CollectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectToolStripMenuItem.Click
        frmColPay.Show()
    End Sub

    Private Sub PromoTiketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPromo.Show()
    End Sub

    Private Sub SitAlotmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAvailability.Show()
    End Sub

    Private Sub DataPortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPortToolStripMenuItem.Click
        frmPort.Show()
    End Sub

    Private Sub SpecialEventToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSpecial.Show()
    End Sub

    Private Sub SurChargeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSurcharge.Show()
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
        xlWorkSheet.Cells(1, 2) = "No.Tiket"
        xlWorkSheet.Cells(1, 3) = "Tipe"
        xlWorkSheet.Cells(1, 4) = "Agent"
        xlWorkSheet.Cells(1, 5) = "Rute Berangkat"
        xlWorkSheet.Cells(1, 6) = "Tgl Berangkat"
        xlWorkSheet.Cells(1, 7) = "trip Berangkat"
        xlWorkSheet.Cells(1, 8) = "Rute Kembali"
        xlWorkSheet.Cells(1, 9) = "tgl kembali"
        xlWorkSheet.Cells(1, 10) = "Trip Kembali"
        xlWorkSheet.Cells(1, 11) = "Rute StopOver"
        xlWorkSheet.Cells(1, 12) = "tgl StopOver"
        xlWorkSheet.Cells(1, 13) = "Trip StopOver"
        xlWorkSheet.Cells(1, 14) = "Guest"
        xlWorkSheet.Cells(1, 15) = "Adl"
        xlWorkSheet.Cells(1, 16) = "Chd"
        xlWorkSheet.Cells(1, 17) = "FOC"
        xlWorkSheet.Cells(1, 18) = "Harga berangkat"
        xlWorkSheet.Cells(1, 19) = "Extra Berangkat"
        xlWorkSheet.Cells(1, 20) = "Harga Kembali"
        xlWorkSheet.Cells(1, 21) = "Extra Kembali"
        xlWorkSheet.Cells(1, 22) = "tras.Berangkat"
        xlWorkSheet.Cells(1, 23) = "ExtraTrans"
        xlWorkSheet.Cells(1, 24) = "Tras.Kemb"
        xlWorkSheet.Cells(1, 25) = "ExtraCost"
        xlWorkSheet.Cells(1, 26) = "Total"
        xlWorkSheet.Cells(1, 27) = "Collect"
        xlWorkSheet.Cells(1, 28) = "Tgl Collect"
        xlWorkSheet.Cells(1, 29) = "Utang/Piutang"
        xlWorkSheet.Cells(1, 30) = "Pelunasan Piutang"
        xlWorkSheet.Cells(1, 31) = "Pelunasan Komisi"
        xlWorkSheet.Cells(1, 32) = "No.Inv"
        xlWorkSheet.Cells(1, 33) = "Tgl Inv"
        xlWorkSheet.Cells(1, 34) = "TglLunas"
        xlWorkSheet.Cells(1, 35) = "Driver Berangkat"
        xlWorkSheet.Cells(1, 36) = "Driver Kembali"
        xlWorkSheet.Cells(1, 37) = "Remark"
        'xlWorkSheet.Cells(1, 35) = "Status"
        Dim A As Integer = 2
        For i = 0 To LsData.RowCount - 1
            If LsData(38, i).Value = 1 Then
                ''For j = 1 To LsData.ColumnCount - 2
                For j = 1 To 37
                    xlWorkSheet.Cells(A, j) = LsData(j, i).Value
                Next
                A = A + 1
            End If
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

    Private Sub CancelCollectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelCollectToolStripMenuItem.Click
        frmCancelColPay.Show()
    End Sub


    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmRute.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmUser.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmTrip.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        frmAgent.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        frmArea.Show()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        frmPort.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        frmAgentRate.Show()
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        frmPromo.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        frmSurcharge.Show()
    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        frmBooking.Show()
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        frmInvoicing.Show()
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        frmInvPayment.Show()
    End Sub

    Private Sub ToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem20.Click
        frmColPay.Show()
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        frmCancelColPay.Show()
    End Sub

    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        frmInvoicing.Show()
    End Sub

    Private Sub CancelInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelInvoiceToolStripMenuItem.Click
        frmCancelInvoice.Show()
    End Sub

    Private Sub ToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click
        frmInvPayment.Show()
    End Sub

    Private Sub ToolStripMenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem25.Click
        frmGenTiket.Show()
    End Sub

    Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        frmSellBook.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        frmChangepass.Show()
    End Sub

    Private Sub cmdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBook.Click
        frmBooking.Show()
    End Sub

    Private Sub cmdEdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdBook.Click
        If LsData.RowCount = 0 Then
            MsgBox("No Data To Update", vbInformation, "No Data")
            Exit Sub
        End If
        'If LsData.CurrentRow.Cells(22).Value = 1 Then
        '    MsgBox("Tiket Already Invoceiced,", vbInformation, "Data Error")
        '    Exit Sub
        'End If
        'If Text1.Text = "" Then
        '    MsgBox("Please Choose Data to Update", vbInformation, "No Data")
        '    Exit Sub
        'End If
        'frmEditBooking.txtetiket.Text = LsData.CurrentRow.Cells(1).Value
        ''frmEditBooking.disables = True
        'frmEditBooking.cprice = True
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

    Private Sub LsData_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellDoubleClick
        If LsData.RowCount = 0 Then
            MsgBox("No Data To Update", vbInformation, "No Data")
            Exit Sub
        End If

        'If (LsData.CurrentRow.Cells(3).Value = "RT") Or (LsData.CurrentRow.Cells(3).Value = "OW") Then
        '    'frmEditBooking.disables = False
        '    frmEditBooking.txtetiket.Text = LsData.CurrentRow.Cells(1).Value
        '    frmEditBooking.cprice = True
        '    frmEditBooking.Show()
        'End If
        'If (LsData.CurrentRow.Cells(3).Value = "3A") Then
        '    frmEdit3ABooking.txtetiket.Text = LsData.CurrentRow.Cells(1).Value
        '    frmEdit3ABooking.Show()
        'End If
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

    Private Sub CollectToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmColPays.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtgodate2.CustomFormat = " "
        txtgodate2.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub txtgodate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgodate2.ValueChanged
        txtgodate2.Format = DateTimePickerFormat.Custom
        txtgodate2.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub txtbackdate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbackdate2.ValueChanged
        txtbackdate2.Format = DateTimePickerFormat.Custom
        txtbackdate2.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtbackdate2.CustomFormat = " "
        txtbackdate2.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub cboAgent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAgent.Click
        

    End Sub

    
    Private Sub cboAgent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAgent.GotFocus
        Dim str As String = ""
        Dim go As String = ""
        Dim back As String = ""
        Dim sql As String = ""
        Dim ands As Boolean = False
        If cboPort.SelectedItem("PortID") > 2 Then
            Dim andX As Boolean = False
            'If cboAgent.Text = "" Then
            'Else
            '    str = " (tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "')"
            '    ands = True
            'End If
            'If cboGorute.Text = "" Then
            'Else
            '    If ands = False Then
            '        str = " (tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString() & ")"
            '        ands = True
            '    Else
            '        str = str & " and (tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString & ")"
            '        ands = True
            '    End If
            'End If
            If cbotipe.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "')"
                    ands = True
                End If
            End If
            'If cboruteback.Text = "" Then
            'Else
            '    If ands = False Then
            '        str = " (tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString & ")"
            '        ands = True
            '    Else
            '        str = str & " and (tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString & ")"
            '        ands = True
            '    End If
            'End If
            If cboGotrip.Text = "" Then
            Else
                If andX = False Then
                    go = " (tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & ")"
                    back = " (tiketdtl.TRIPBACK=" & cboGotrip.SelectedItem("TripID").ToString & ")"
                    andX = True
                Else
                    'str = str & " and ((tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & ") or (tiketdtl.BackTrip=" & cboGotrip.SelectedItem("TripID").ToString & "))"
                    go = go & " AND (tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & ")"
                    back = back & " AND (tiketdtl.TRIPBACK=" & cboGotrip.SelectedItem("TripID").ToString & ")"
                    andX = True
                End If
            End If
            If cbotripback.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.TRIPBACK=" & cbotripback.SelectedItem("RuteID").ToString & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.TRIPBACK=" & cbotripback.SelectedItem("RuteID").ToString & ")"
                    ands = True
                End If
            End If
            If Trim(txtgodate.Text) = "" Then
            Else
                If Trim(txtgodate2.Text) = "" Then
                    MsgBox("Departure To date is empty", vbInformation, "Error")
                    Exit Sub
                End If
                If andX = False Then
                    go = " (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    back = " (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    andX = True
                Else
                    'str = str & " and ((tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "') or (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "'))"
                    go = go & " And (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    back = back & " and (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    andX = True
                End If
            End If
            If Trim(txtbackdate.Text) = "" Then
            Else
                If Trim(txtbackdate2.Text) = "" Then
                    MsgBox("Arrival To date is empty", vbInformation, "Error")
                    Exit Sub
                End If
                If ands = False Then
                    str = " (tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "'" & ")"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "')"
                    ands = True
                End If
            End If
            If cboPort.Text = "" Then
            Else
                Dim ctr = cboPort.SelectedItem("PortID")
                If andX = False Then
                    go = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
                    back = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    andX = True
                Else
                    'str = str & " and ((tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) or (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")))"
                    go = go & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")) "
                    back = back & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                End If
            End If
            If cboport2.Text = "" Then
            Else
                Dim ctrS = cboport2.SelectedItem("PortID")
                If ands = False Then
                    'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                    'str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    str = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & ")"
                    ands = True
                Else
                    'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                    'str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    str = str & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & "))"
                End If
            End If
            If cboCountry.Text = "" Then
            Else
                'If ands = False Then
                '    str = " tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString()
                '    ands = True
                'Else
                '    str = str & " and tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString
                '    ands = True
                'End If
                Select Case cboCountry.Text
                    Case "All"
                        str = str
                    Case "Belum(Invoice)"
                        str = str & " and (tiketdtl.INV=0) AND (tiketdtl.PAY=0) and (NoInv='' or isnull(NoInv))"
                    Case "Invoice"
                        str = str & " and (tiketdtl.INV=1) AND (tiketdtl.PAY=0) "
                    Case "Sudah Lunas"
                        str = str & " ANd (tiketdtl.PAY=1 OR TIKETDTL.TGLLUNAS<>'')"
                End Select
            End If
            If TextBox1.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                    ands = True
                End If

            End If

            If txtremark.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.remark like '%" & txtremark.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.remark like '%" & txtremark.Text & "%')"
                    ands = True
                End If

            End If
            If txtinv.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.noinv = '" & txtinv.Text & "')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.noinv = '" & txtinv.Text & "')"
                    ands = True
                End If

            End If

            If cbodrv.Text = "" Then
            Else
                If ands = False Then
                    str = " ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
                    ands = True
                Else
                    str = str & " AND ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
                    ands = True
                End If
            End If
            If txtstart.Text = "" Then
            Else
                If txtend.Text = "" Then
                    MsgBox("Please Input End Tiket", vbInformation, "Error Filter")
                    txtend.Focus()
                    Exit Sub
                Else
                    If ands = False Then
                        str = " (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    Else
                        str = str & " AND (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    End If
                End If

            End If
            If price1.Text = "" Then
            Else
                If Not IsNumeric(price1.Text) Then
                    MsgBox("Please Price with Number", vbInformation, "Error Filter")
                    price1.Focus()
                    Exit Sub
                End If
                If price2.Text = "" Then
                    MsgBox("Please Range Price", vbInformation, "Error Filter")
                    price2.Focus()
                    Exit Sub
                Else
                    If Not IsNumeric(price2.Text) Then
                        MsgBox("Please Price with Number", vbInformation, "Error Filter")
                        price2.Focus()
                        Exit Sub
                    End If
                    If ands = False Then
                        str = " ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
                        ands = True
                    Else
                        str = str & " AND ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
                        ands = True
                    End If
                End If

            End If
            If str = "" Then
                sql = "SELECT  `tiketdtl`.`AGENTID`, `agent`.`AgentName` FROM `tiketdtl` INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) WHERE (" & go & " or " & back & ") GROUP BY `tiketdtl`.`AgentID`  ORDER BY  `agent`.`AgentName`"
            Else
                sql = "SELECT  `tiketdtl`.`AGENTID`, `agent`.`AgentName` FROM `tiketdtl` INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) WHERE " & str & " and(" & go & " or " & back & ")  GROUP BY `tiketdtl`.`AgentID` ORDER BY  `agent`.`AgentName` "
            End If

        Else

            '' from PBai & Serangan
            If cboAgent.Text = "" Then
            Else
                str = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "'"
                ands = True
            End If
            If cboGorute.Text = "" Then
            Else
                If ands = False Then
                    str = " tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString()
                    ands = True
                Else
                    str = str & " and tiketdtl.GoruteID=" & cboGorute.SelectedItem("RuteID").ToString
                    ands = True
                End If
            End If
            If cbotipe.Text = "" Then
            Else
                If ands = False Then
                    str = " tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "'"
                    ands = True
                Else
                    str = str & " and tiketdtl.TIPE='" & Mid(cbotipe.Text, 1, 2) & "'"
                    ands = True
                End If
            End If
            If cboruteback.Text = "" Then
            Else
                If ands = False Then
                    str = " tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString
                    ands = True
                Else
                    str = str & " and tiketdtl.BackruteID=" & cboruteback.SelectedItem("RuteID").ToString
                    ands = True
                End If
            End If
            If cboGotrip.Text = "" Then
            Else
                If ands = False Then
                    str = " tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString
                    ands = True
                Else
                    str = str & " and tiketdtl.GoTrip=" & cboGotrip.SelectedItem("tripID").ToString
                    ands = True
                End If
            End If
            If cbotripback.Text = "" Then
            Else
                If ands = False Then
                    str = " tiketdtl.BackTrip=" & cbotripback.SelectedItem("RuteID").ToString
                    ands = True
                Else
                    str = str & " and tiketdtl.BackTrip=" & cbotripback.SelectedItem("RuteID").ToString
                    ands = True
                End If
            End If
            If Trim(txtgodate.Text) = "" Then
            Else
                If Trim(txtgodate2.Text) = "" Then
                    MsgBox("Departure To date is empty", vbInformation, "Error")
                    Exit Sub
                End If
                If ands = False Then
                    str = "(tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    ands = True
                End If
            End If
            If Trim(txtbackdate.Text) = "" Then
            Else
                If Trim(txtbackdate2.Text) = "" Then
                    MsgBox("Arrivalc To date is empty", vbInformation, "Error")
                    Exit Sub
                End If
                If ands = False Then
                    str = " tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "'"
                    ands = True
                Else
                    str = str & " and tiketdtl.Backdate='" & Str2Date(txtbackdate.Text) & "'"
                    ands = True
                End If
            End If
            If cboPort.Text = "" Then
            Else
                Dim ctr = cboPort.SelectedItem("PortID")
                If ands = False Then
                    str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    ands = True
                Else
                    str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                End If
            End If
            If cboport2.Text = "" Then
            Else
                Dim ctrS = cboport2.SelectedItem("PortID")
                If ands = False Then
                    'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                    'str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    str = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & ")"
                    ands = True
                Else
                    'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                    'str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                    str = str & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctrS & "))"
                End If
            End If
            If cboCountry.Text = "" Then
            Else
                'If ands = False Then
                '    str = " tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString()
                '    ands = True
                'Else
                '    str = str & " and tiketdtl.Country=" & cboCountry.SelectedItem("CountryID").ToString
                '    ands = True
                'End If
                Select Case cboCountry.Text
                    Case "All"
                        str = str
                    Case "Belum Invoice"
                        str = str & " and tiketdtl.INV=0 AND tiketdtl.PAY=0  and (NoInv='' or isnull(NoInv))"
                    Case "Invoice"
                        str = str & " and tiketdtl.INV=1 AND tiketdtl.PAY=0 "
                    Case "Sudah Lunas"
                        str = str & " ANd (tiketdtl.PAY=1 OR TIKETDTL.TGLLUNAS<>'')"
                End Select
            End If
            If TextBox1.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.Guest like '%" & TextBox1.Text & "%')"
                    ands = True
                End If

            End If

            If txtremark.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.remark like '%" & txtremark.Text & "%')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.remark like '%" & txtremark.Text & "%')"
                    ands = True
                End If

            End If
            If txtinv.Text = "" Then
            Else
                If ands = False Then
                    str = " (tiketdtl.noinv = '" & txtinv.Text & "')"
                    ands = True
                Else
                    str = str & " and (tiketdtl.noinv = '" & txtinv.Text & "')"
                    ands = True
                End If

            End If

            If cbodrv.Text = "" Then
            Else
                If ands = False Then
                    str = " ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
                    ands = True
                Else
                    str = str & " AND ((tiketdtl.Godriver='" & cbodrv.Text & "') or (tiketdtl.backdriver='" & cbodrv.Text & "'))"
                    ands = True
                End If
            End If
            If txtstart.Text = "" Then
            Else
                If txtend.Text = "" Then
                    MsgBox("Please Input End Tiket", vbInformation, "Error Filter")
                    txtend.Focus()
                    Exit Sub
                Else
                    If ands = False Then
                        str = " (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    Else
                        str = str & " AND (tiketdtl.NoTiket between '" & txtstart.Text & "' and '" & txtend.Text & "') "
                        ands = True
                    End If
                End If

            End If
            If price1.Text = "" Then
            Else
                If Not IsNumeric(price1.Text) Then
                    MsgBox("Please Price with Number", vbInformation, "Error Filter")
                    price1.Focus()
                    Exit Sub
                End If
                If price2.Text = "" Then
                    MsgBox("Please Range Price", vbInformation, "Error Filter")
                    price2.Focus()
                    Exit Sub
                Else
                    If Not IsNumeric(price2.Text) Then
                        MsgBox("Please Price with Number", vbInformation, "Error Filter")
                        price2.Focus()
                        Exit Sub
                    End If
                    If ands = False Then
                        str = " ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
                        ands = True
                    Else
                        str = str & " AND ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "')) "
                        ands = True
                    End If
                End If

            End If
            If (str = "") Or (ands = False) Then
                sql = "select AgentID,AgentName from agent"
            Else
                sql = "SELECT  `tiketdtl`.`AGENTID`, `agent`.`AgentName` FROM `tiketdtl` INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`)  WHERE " & str & "  GROUP BY `tiketdtl`.`AgentID`  ORDER BY  `agent`.`AgentName`"
            End If

        End If
        Call ConnectDatabase()
        cboAgent.DataSource = Nothing
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(sql, conn)
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

    Private Sub DataAgentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataAgentToolStripMenuItem1.Click
        frmAgent.Show()
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        frmCancelInvoice.Show()
    End Sub

    Private Sub CancelPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelPaymentToolStripMenuItem.Click
        frmCancelPayment.Show()
    End Sub

    Private Sub CancelPaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelPaymentToolStripMenuItem1.Click
        frmCancelPayment.Show()
    End Sub

    Private Sub cboAgent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgent.SelectedIndexChanged

    End Sub

    Private Sub ListDepositToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListDepositToolStripMenuItem.Click
        frmAgentListDeposit.Show()
    End Sub

    Private Sub AddDepositToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddDepositToolStripMenuItem.Click
        'frmAddAgentDeposit.Show()
        frmListAgentDeposit.Show()
    End Sub

    Private Sub ListDepositToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListDepositToolStripMenuItem1.Click
        frmAgentListDeposit.Show()
    End Sub

    Private Sub AddDepositToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddDepositToolStripMenuItem1.Click
        'frmAddAgentDeposit.Show()
        frmListAgentDeposit.Show()
    End Sub

    Private Sub LogfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogfileToolStripMenuItem.Click
        frmLog.Show()
    End Sub

    Private Sub TourToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TourToolStripMenuItem.Click
        frmTourList.Show()
    End Sub
End Class