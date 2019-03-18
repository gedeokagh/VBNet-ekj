Imports MySql.Data.MySqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmAdminManager
    Dim totalpax, adl, chd, inf As Integer
    Dim totalko, totalj, totalc, totalp, sisa, totalls As Decimal
    Dim strgo, strback As String
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


            Dim val = Trim(LsData.Rows(i).Cells(28).Value)
            'val = LsData.Rows(i).Cells(44).ToString
            Dim vals = Trim(LsData.Rows(i).Cells(29).Value)
            'val = LsData.Rows(i).Cells(44).ToString
            If vals = 1 Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
            If val = 0 Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            Else

                adl = adl + NZx(LsData.Rows(i).Cells(10).Value)
                chd = chd + NZx(LsData.Rows(i).Cells(11).Value)
                inf = inf + NZx(LsData.Rows(i).Cells(13).Value)
                totalpax = totalpax + inf + adl + chd
                totalj = totalj + NZx(LsData.Rows(i).Cells(17).Value)
                totalc = totalc + NZx(LsData.Rows(i).Cells(18).Value)
                totalko = totalko + NZx(LsData.Rows(i).Cells(20).Value)
                totalp = totalp + NZx(LsData.Rows(i).Cells(21).Value)
                totalls = totalls + NZx(LsData.Rows(i).Cells(22).Value)
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
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
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
        cboGotrip.DataSource = dt
        cboGotrip.DisplayMember = "tripName"

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

    Sub filldata(ByVal strCriteria As String)
        Dim strQry As String
        If strCriteria = "0" Then
            'strQry = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip, `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE tiketdtl.Godate='" & Str2Date(Format(Now, "dd/MM/yyyy")) & "' ORDER BY  `agent`.`AgentName`"
            strQry = "SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'Depart' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`GoDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, (`tiketdtl`.`GoRate`+`tiketdtl`.`BackRate`) AS DepartRate, (`tiketdtl`.`GoExtra` +`tiketdtl`.`BackExtra`)AS DepartExtra, (`tiketdtl`.`GoTranRate`+`tiketdtl`.`BackTransRate`) AS DepartShutlePrice, (`tiketdtl`.`GoTransExtra`+`tiketdtl`.`BackTransExtra` ) AS DepartShutleExtraCost, `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, IF( ISNULL(`tiketdtl`.tgllunas), `tiketdtl`.`Komisi`, 0 ) AS UPiutang, IF( ISNULL(`tiketdtl`.tgllunas), 0, IF( `tiketdtl`.`Komisi` < 0, `tiketdtl`.`Komisi`, 0 ) ) AS pelPiutang, IF( NOT ISNULL(`tiketdtl`.tgllunas), IF( `tiketdtl`.`Komisi` > 0, `tiketdtl`.`Komisi`, 0 ), 0 ) AS PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`GoRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`GoTrip` = `trip`.`TripID` ) WHERE tiketdtl.Godate = '" & Str2Date(Format(Now, "dd/MM/yyyy")) & "' UNION SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'Return' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`backDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, 0 AS DepartRate, 0 AS DepartExtra, 0 AS DepartShutlePrice, 0 AS DepartShutleExtraCost, 0 AS `TotalJual`, 0 AS `TotalCollect`, `tiketdtl`.`tglcollect`, 0 AS UPiutang, 0 pelPiutang, 0 PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`BackDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`backRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`tripback` = `trip`.`TripID` ) WHERE tiketdtl.backdate = '" & Str2Date(Format(Now, "dd/MM/yyyy")) & "' UNION SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'StopOver' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`soDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, 0 AS DepartRate, 0 AS DepartExtra, 0 AS DepartShutlePrice, 0 AS DepartShutleExtraCost, 0 AS `TotalJual`, 0 AS `TotalCollect`, `tiketdtl`.`tglcollect`, 0 AS UPiutang, 0 pelPiutang, 0 PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`soDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`GoRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`GoTrip` = `trip`.`TripID` ) WHERE tiketdtl.sodate = '" & Str2Date(Format(Now, "dd/MM/yyyy")) & "' ORDER BY `AgentName`,noetiket"
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
        ' LsData.ColumnCount = 30
        LsData.Columns(0).HeaderText = "ID"
        LsData.Columns(0).Visible = False
        LsData.Columns(1).HeaderText = "No.ETiket"
        LsData.Columns(1).Width = 125
        LsData.Columns(2).HeaderText = "No.Tiket"
        LsData.Columns(3).HeaderText = "Tipe"
        LsData.Columns(3).Width = 50
        LsData.Columns(4).HeaderText = "Tiket"
        LsData.Columns(5).HeaderText = "Agent"
        LsData.Columns(6).HeaderText = "Rute "
        LsData.Columns(7).HeaderText = "Tgl "
        LsData.Columns(7).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(7).Width = 75
        LsData.Columns(8).HeaderText = "Trip"
        LsData.Columns(8).Width = 50
       
        LsData.Columns(9).HeaderText = "Guest"
        LsData.Columns(10).HeaderText = "Adl"
        LsData.Columns(10).Width = 40
        LsData.Columns(11).HeaderText = "Chd"
        LsData.Columns(11).Width = 40
        LsData.Columns(12).HeaderText = "FOC"
        LsData.Columns(12).Width = 40
        LsData.Columns(13).HeaderText = "Harga"
        LsData.Columns(13).DefaultCellStyle.Format = "#,###"
        LsData.Columns(14).HeaderText = "Extra Charge"
        LsData.Columns(14).DefaultCellStyle.Format = "#,###"
        LsData.Columns(15).HeaderText = "Transport"
        LsData.Columns(15).DefaultCellStyle.Format = "#,###"
        LsData.Columns(16).HeaderText = "Extra Trans."
        LsData.Columns(16).DefaultCellStyle.Format = "#,###"
        LsData.Columns(17).HeaderText = "Total"
        LsData.Columns(17).DefaultCellStyle.Format = "#,###"
        LsData.Columns(18).HeaderText = "Collect"
        LsData.Columns(18).DefaultCellStyle.Format = "#,###"
        LsData.Columns(19).HeaderText = "Tgl Collect"
        LsData.Columns(19).Width = 75
        LsData.Columns(19).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(20).HeaderText = "Utamg/Piutang"
        LsData.Columns(20).DefaultCellStyle.Format = "#,###"
        LsData.Columns(21).HeaderText = "Pel.Piutang"
        LsData.Columns(21).DefaultCellStyle.Format = "#,###"
        LsData.Columns(22).HeaderText = "Pel.Komisi"
        LsData.Columns(22).DefaultCellStyle.Format = "#,###"
        LsData.Columns(23).HeaderText = "No.Inv"
        LsData.Columns(24).HeaderText = "Tgl.Inv"
        LsData.Columns(24).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(24).Width = 75
        LsData.Columns(25).HeaderText = "Tgl.Lunas"
        LsData.Columns(25).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(25).Width = 75
        LsData.Columns(26).HeaderText = "Driver "
        LsData.Columns(27).HeaderText = "Remark"
        LsData.Columns(28).HeaderText = "Status"
        LsData.Columns(28).Visible = False
        LsData.Columns(29).HeaderText = "Depart"
        LsData.Columns(29).Visible = False
        Dim x As Integer
        For x = 0 To 29
            LsData.Columns(x).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        Call DisconnectDatabase()
        'head()
        colorx()
    End Sub

    Private Sub frmAdminMan_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    Private Sub frmAdminMan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MenuStrip1.Visible = False
        fillagent()
        fillRute()
        filltrip()
        lblUser.Text = usr
        filldata("0")
        fillPort()
        filldriver()


        MenuStrip1.Visible = True

        Text1.Text = ""
        txtgodate.Format = DateTimePickerFormat.Custom
        txtgodate.CustomFormat = "dd/MM/yyyy"
        txtgodate2.Format = DateTimePickerFormat.Custom
        txtgodate2.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmUser.Show()
    End Sub

    Private Sub ToolStripMenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem29.Click
        frmRute.Show()
    End Sub

    Private Sub ToolStripMenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem30.Click
        frmTrip.Show()
    End Sub

    Private Sub ToolStripMenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem31.Click
        frmAgent.Show()
    End Sub

    Private Sub ToolStripMenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem32.Click
        frmArea.Show()
    End Sub

    Private Sub ToolStripMenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem34.Click
        frmPort.Show()
    End Sub

    Private Sub ToolStripMenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem36.Click
        frmAgentRate.Show()
    End Sub

    Private Sub ToolStripMenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem37.Click
        frmPromo.Show()
    End Sub

    Private Sub ToolStripMenuItem39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSurcharge.Show()
    End Sub

    Private Sub ToolStripMenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem40.Click
        frmSpecial.Show()
    End Sub

    Private Sub ToolStripMenuItem46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem46.Click
        frmColPay.Show()
    End Sub

    Private Sub ToolStripMenuItem47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem47.Click
        frmCancelColPay.Show()
    End Sub

    Private Sub ToolStripMenuItem48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem48.Click
        frmInvoicing.Show()
    End Sub

    Private Sub ToolStripMenuItem49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem49.Click
        frmCancelInvoice.Show()
    End Sub

    Private Sub ToolStripMenuItem50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem50.Click
        frmInvPayment.Show()
    End Sub

    Private Sub ToolStripMenuItem53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem53.Click
        frmCancelPayment.Show()
    End Sub

    Private Sub cmdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBook.Click
        frmBooking.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        frmBooking3A.Show()
    End Sub

    Private Sub cmdEdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdBook.Click
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
        'If (LsData.CurrentRow.Cells(2).Value = "3A") Then
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

    Private Sub cmdvoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdvoid.Click
        If LsData.CurrentRow.Cells(38).Value = 0 Then
            Exit Sub
        End If
        If (Not IsDBNull(LsData.CurrentRow.Cells(33).Value)) Or (LsData.CurrentRow.Cells(33).Value <> "") Then
            MsgBox("Tiket already Invoicing", vbInformation, "Void Tiket")
            Exit Sub
        End If
        If (Not IsDBNull(LsData.CurrentRow.Cells(34).Value)) Or (LsData.CurrentRow.Cells(34).Value <> "") Then
            MsgBox("Tiket already Paid", vbInformation, "Void Tiket")
            Exit Sub
        End If
        Try
            Dim strSql As String

            Call ConnectDatabase()
            strSql = "update tiketdtl set status=0 where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'"
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Comd.ExecuteNonQuery()

            Call DisconnectDatabase()
            LsData.CurrentRow.DefaultCellStyle.BackColor = Color.Red

            FillLog(usr, "Void Tiket", " Void Tiket=" & LsData.CurrentRow.Cells(2).Value & ", No.Etiket =" & LsData.CurrentRow.Cells(1).Value & " ", "status=1", "status=0")
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub

    Private Sub cmdreactive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreactive.Click
        Dim strSql As String = ""
        strSql = "update tiketdtl set status=1 where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "'"

        Call ConnectDatabase()

        Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
        Comd.ExecuteNonQuery()

        Call DisconnectDatabase()
        LsData.CurrentRow.DefaultCellStyle.BackColor = Color.Empty

        FillLog(usr, "Active Tiket", " Reset Tiket , TiketNo=" & LsData.CurrentRow.Cells(1).Value & ", Etiket =" & LsData.CurrentRow.Cells(1).Value, "", "")

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        frmOpenReturn.Show()
    End Sub


    Private Sub cmdShutle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShutle.Click

        frmShutle.from = False
        frmShutle.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim strc1 As String = ""
        If cboPort.Text = "" Then
            MsgBox("Please select Port", vbInformation, "Select  Port")
            Exit Sub
        End If
        If Trim(txtgodate.Text) = "" Then
            MsgBox("Please Choose Date", vbInformation, "Choose  Date")
            Exit Sub
        End If
        If cboGotrip.Text = "" Then
            MsgBox("Please select Trip", vbInformation, "Select  Trip")
            Exit Sub
        End If

        Dim andx As Boolean = False
        strgo = ""
        strback = ""
        If Trim(txtgodate.Text) = "" Then
        Else
            If andx = False Then
                'strgo = " ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                strgo = " (tiketdtl.GoDate='" & Str2Date(txtgodate.Text) & "')"
                strback = " (tiketdtl.BackDate='" & Str2Date(txtgodate.Text) & "')"
                andx = True
            Else
                'strgo = strgo & " and ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                strgo = strgo & " and (tiketdtl.GoDate='" & Str2Date(txtgodate.Text) & "')"
                strback = strback & " and (tiketdtl.BackDate='" & Str2Date(txtgodate.Text) & "')"
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
        If cboGotrip.Text = "" Then
        Else
            If andx = False Then
                'strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                strgo = " (tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & " )"
                strback = " ( tiketdtl.TripBACK=" & cboGotrip.SelectedItem("TripID").ToString & ")"
                andx = True
            Else
                'strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                strgo = strgo & " and  (tiketdtl.GoTrip=" & cboGotrip.SelectedItem("TripID").ToString & " )"
                strback = strback & " and  (tiketdtl.TripBACK=" & cboGotrip.SelectedItem("TripID").ToString & ")"
            End If
        End If
        strc1 = "SELECT '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket, tiketdtl.remark, tiketdtl.NoTiket, agent.AgentName, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.mrs, tiketdtl.Guest, `tiketdtl`.`GoDate` AS Dates, IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( tiketdtl.GoRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF( tiketdtl.Gotrip = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName, IF( `tiketdtl`.`GoTrans` = 0, 'No', 'Yes' ) AS Transport, IF( tiketdtl.GoArea = 0, '', (SELECT area.AreaName FROM AREA WHERE area.AreaID = tiketdtl.GoArea) ) AS AREA, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver,if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS RETURNDate, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS RuteBack FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) WHERE " & strgo & " UNION SELECT '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket, tiketdtl.NoTiket, agent.AgentName, tiketdtl.remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.mrs, tiketdtl.Guest,tiketdtl.BackDate AS Dates, IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS Rute, IF( tiketdtl.tripback = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.Tripback) ) AS Trip, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName, IF( `tiketdtl`.`backTrans` = 0, 'No', 'Yes' ) AS Transport, IF( tiketdtl.backArea = 0, '', (SELECT area.AreaName FROM AREA WHERE area.AreaID = tiketdtl.backArea) ) AS AREA, tiketdtl.backPickUp AS Location, tiketdtl.backDriver AS Driver,if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS RETURNDate, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS RuteBack FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strback
        'strc1 = "Select '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket , tiketdtl.remark,  tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.departgo, tiketdtl.departBACK , tiketdtl.inv FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strgo & "union Select '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket , tiketdtl.remark,  tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.departgo, tiketdtl.departBACK , tiketdtl.inv FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strback
        frmPrintTikets.sqlPrint = strc1
        frmPrintTikets.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        frmCekBording.Show()
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
            If str = "" Then
                sql = "SELECT  `tiketdtl`.`AGENTID`, `agent`.`AgentName` FROM `tiketdtl` INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) WHERE (" & go & " or " & back & ") GROUP BY `tiketdtl`.`AgentID`  ORDER BY  `agent`.`AgentName`"
            Else
                sql = "SELECT  `tiketdtl`.`AGENTID`, `agent`.`AgentName` FROM `tiketdtl` INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) WHERE " & str & " and(" & go & " or " & back & ")  GROUP BY `tiketdtl`.`AgentID` ORDER BY  `agent`.`AgentName` "
            End If

        Else

            '' from PBai & Serangan
            'If cboAgent.Text = "" Then
            'Else
            '    str = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString() & "'"
            '    ands = True
            'End If
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

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        Dim str As String = ""
        Dim go As String = ""
        Dim SO As String = ""
        Dim back As String = ""
        Dim sql As String = ""
        Dim ands As Boolean = False

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
                    str = str & " and (tiketdtl.INV=0) AND (tiketdtl.PAY=0) and (tiketdtl.NoInv='' or isnull(tiketdtl.NoInv)) and tiketdtl.status=1"
                Case "Invoice"
                    str = str & " and (tiketdtl.INV=1) AND (tiketdtl.PAY=0)  and tiketdtl.status=1"
                Case "Sudah Lunas"
                    str = str & " ANd (tiketdtl.PAY=1 OR TIKETDTL.TGLLUNAS<>'')  and tiketdtl.status=1"
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
                    str = " ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.backrate between '" & price1.Text & "' and '" & price2.Text & "')) "
                    ands = True
                Else
                    str = str & " AND ((tiketdtl.gorate between '" & price1.Text & "' and '" & price2.Text & "') or (tiketdtl.backrate between '" & price1.Text & "' and '" & price2.Text & "')) "
                    ands = True
                End If
            End If

        End If
        If str = "" Then
            'sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE (" & go & " )  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE ( " & back & ") ORDER BY  `NOETIKET`"
            'sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE (" & go & " )  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali, IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE ( " & back & ") UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali, IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE ( " & SO & ") ORDER BY  `NOETIKET`"
            sql = "SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'Depart' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`GoDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, (`tiketdtl`.`GoRate`+`tiketdtl`.`BackRate`) AS DepartRate, (`tiketdtl`.`GoExtra` +`tiketdtl`.`BackExtra`)AS DepartExtra, (`tiketdtl`.`GoTranRate`+`tiketdtl`.`BackTransRate`) AS DepartShutlePrice, (`tiketdtl`.`GoTransExtra`+`tiketdtl`.`BackTransExtra` ) AS DepartShutleExtraCost, `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, IF( ISNULL(`tiketdtl`.tgllunas), `tiketdtl`.`Komisi`, 0 ) AS UPiutang, IF( ISNULL(`tiketdtl`.tgllunas), 0, IF( `tiketdtl`.`Komisi` < 0, `tiketdtl`.`Komisi`, 0 ) ) AS pelPiutang, IF( NOT ISNULL(`tiketdtl`.tgllunas), IF( `tiketdtl`.`Komisi` > 0, `tiketdtl`.`Komisi`, 0 ), 0 ) AS PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`GoRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`GoTrip` = `trip`.`TripID` ) WHERE ( " & go & ") UNION SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'Return' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`backDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, 0 AS DepartRate, 0 AS DepartExtra, 0 AS DepartShutlePrice, 0 AS DepartShutleExtraCost, 0 AS `TotalJual`, 0 AS `TotalCollect`, `tiketdtl`.`tglcollect`, 0 AS UPiutang, 0 pelPiutang, 0 PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`BackDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`backRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`tripback` = `trip`.`TripID` ) WHERE ( " & back & ") UNION SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'StopOver' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`soDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, 0 AS DepartRate, 0 AS DepartExtra, 0 AS DepartShutlePrice, 0 AS DepartShutleExtraCost, 0 AS `TotalJual`, 0 AS `TotalCollect`, `tiketdtl`.`tglcollect`, 0 AS UPiutang, 0 pelPiutang, 0 PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`soDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`GoRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`GoTrip` = `trip`.`TripID` ) WHERE ( " & SO & ") ORDER BY `AgentName`,noetiket"
        Else
            'sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and(" & go & ")  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & back & ") ORDER BY  `AgentName`"
            'sql = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and(" & go & ")  UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & back & ") UNION SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,  IF(tiketdtl.SORUTE = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute)) AS StopOver,  IF(tiketdtl.soDate IS NULL OR tiketdtl.soDate = '','',tiketdtl.soDate) AS SOverDate,  IF( tiketdtl.sotrip = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip)) AS SOverTrip,  `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, if(isnull(`tiketdtl`.tgllunas),`tiketdtl`.`Komisi`,0) as UPiutang, if(isnull(`tiketdtl`.tgllunas),0,if(`tiketdtl`.`Komisi`<0,`tiketdtl`.`Komisi`,0))  as pelPiutang,if(not isnull(`tiketdtl`.tgllunas),if(`tiketdtl`.`Komisi`>0,`tiketdtl`.`Komisi`,0),0)  as PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & str & " and( " & SO & ") ORDER BY  `AgentName`"
            sql = "SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'Depart' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`GoDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, (`tiketdtl`.`GoRate`+`tiketdtl`.`BackRate`) AS DepartRate, (`tiketdtl`.`GoExtra` +`tiketdtl`.`BackExtra`)AS DepartExtra, (`tiketdtl`.`GoTranRate`+`tiketdtl`.`BackTransRate`) AS DepartShutlePrice, (`tiketdtl`.`GoTransExtra`+`tiketdtl`.`BackTransExtra` ) AS DepartShutleExtraCost, `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`tglcollect`, IF( ISNULL(`tiketdtl`.tgllunas), `tiketdtl`.`Komisi`, 0 ) AS UPiutang, IF( ISNULL(`tiketdtl`.tgllunas), 0, IF( `tiketdtl`.`Komisi` < 0, `tiketdtl`.`Komisi`, 0 ) ) AS pelPiutang, IF( NOT ISNULL(`tiketdtl`.tgllunas), IF( `tiketdtl`.`Komisi` > 0, `tiketdtl`.`Komisi`, 0 ), 0 ) AS PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`GoRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`GoTrip` = `trip`.`TripID` ) WHERE " & str & " and ( " & go & ") UNION SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'Return' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`backDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, 0 AS DepartRate, 0 AS DepartExtra, 0 AS DepartShutlePrice, 0 AS DepartShutleExtraCost, 0 AS `TotalJual`, 0 AS `TotalCollect`, `tiketdtl`.`tglcollect`, 0 AS UPiutang, 0 pelPiutang, 0 PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`BackDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`backRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`tripback` = `trip`.`TripID` ) WHERE " & str & " and ( " & back & ") UNION SELECT 0 AS ID, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, 'StopOver' AS Tiket, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat, `tiketdtl`.`soDate` AS TglBerangkat, `trip`.`TripName` AS TripBerangkat, `tiketdtl`.`Guest`, IF( `tiketdtl`.QtyTipe = 1, tiketdtl.qty, 0 ) AS Adult, IF( `tiketdtl`.QtyTipe = 2, tiketdtl.qty, 0 ) AS Child, IF( `tiketdtl`.QtyTipe >= 3, tiketdtl.qty, 0 ) AS FOC, 0 AS DepartRate, 0 AS DepartExtra, 0 AS DepartShutlePrice, 0 AS DepartShutleExtraCost, 0 AS `TotalJual`, 0 AS `TotalCollect`, `tiketdtl`.`tglcollect`, 0 AS UPiutang, 0 pelPiutang, 0 PelKomisi, `tiketdtl`.`NoInv`, `tiketdtl`.`tglinv`, `tiketdtl`.`tgllunas`, `tiketdtl`.`soDriver` AS DepartDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO` FROM `tiketdtl` INNER JOIN `rute` ON ( `tiketdtl`.`GoRuteID` = `rute`.`RuteID` ) INNER JOIN `agent` ON ( `tiketdtl`.`AgentID` = `agent`.`AgentID` ) INNER JOIN `trip` ON ( `tiketdtl`.`GoTrip` = `trip`.`TripID` ) WHERE  " & str & " and( " & SO & ") ORDER BY `AgentName`,noetiket"
        End If



        filldata(sql)
        'colorx()
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


    Private Sub TopSuooprtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopSuooprtToolStripMenuItem.Click
        frmTopSupport.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtgodate.CustomFormat = " "
        txtgodate.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtgodate2.CustomFormat = " "
        txtgodate2.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub txtgodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgodate.ValueChanged
        txtgodate.Format = DateTimePickerFormat.Custom
        txtgodate.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub txtgodate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgodate2.ValueChanged
        txtgodate2.Format = DateTimePickerFormat.Custom
        txtgodate2.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick

    End Sub

    Private Sub DataLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataLogsToolStripMenuItem.Click
        frmLog.Show()
    End Sub
End Class