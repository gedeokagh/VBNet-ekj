Imports MySql.Data.MySqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmAdmins
    Dim totalpax, adl, chd, inf As Integer
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

    Sub filldata(ByVal strCriteria As String)
        Dim strCriterias, strQry As String
        If strCriteria = "0" Then
            strCriterias = "tiketdtl.Godate='" & Str2Date(Format(Now, "dd/MM/yyyy")) & "'"
            ''strCriterias = " NoBook<>'' "
        Else
            strCriterias = strCriteria
        End If
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable

        strQry = "SELECT 0 as ID, `tiketdtl`.`NoETiket` , `tiketdtl`.`NoTiket`, `tiketdtl`.`Tipe`, `agent`.`AgentName`, `rute`.`RuteName` AS RuteBerangkat , `tiketdtl`.`GoDate` AS TglBerangkat,`trip`.`TripName` AS TripBerangkat,  IF(`tiketdtl`.`BackRuteID`='','',(SELECT rute.RuteName FROM rute WHERE rute.`RuteID`=tiketdtl.BackRuteID)) AS RuteKembali, tiketdtl.BackDate AS TglKembali, IF(tiketdtl.`TripBack`='','',(SELECT trip.`TripName` FROM trip WHERE trip.`TripID`=tiketdtl.`TripBack`)) AS TripKembali,   `tiketdtl`.`Guest`, if(`tiketdtl`.QtyTipe=1,tiketdtl.qty,0)as Adult,if(`tiketdtl`.QtyTipe=2,tiketdtl.qty,0)as Child,if(`tiketdtl`.QtyTipe>=3,tiketdtl.qty,0)as FOC , `tiketdtl`.`GoRate` as DepartRate , `tiketdtl`.`GoExtra`as DepartExtra,`tiketdtl`.`BackRate` as ReturnRate, `tiketdtl`.`BackExtra` as ReturnExtra,  `tiketdtl`.`GoTranRate`as DepartShutlePrice, `tiketdtl`.`GoTransExtra`as DepartShutleExtraCost,   `tiketdtl`.`BackTransRate` as ReturnShuttlePrice, `tiketdtl`.`BackTransExtra` as ReturnShutleExtra,  `tiketdtl`.`TotalJual`,  `tiketdtl`.`tgllunas`, `tiketdtl`.`GoDriver`as DepartDriver, `tiketdtl`.`BackDriver`as ReturnDriver, `tiketdtl`.`Remark`, `tiketdtl`.`status`, `tiketdtl`.`DEPARTGO`, `tiketdtl`.`INV` FROM `tiketdtl`INNER JOIN `rute` ON (`tiketdtl`.`GoRuteID` = `rute`.`RuteID`)  INNER JOIN `agent` ON (`tiketdtl`.`AgentID` = `agent`.`AgentID`) INNER JOIN `trip` ON (`tiketdtl`.`GoTrip` = `trip`.`TripID`) WHERE " & strCriterias & " ORDER BY  `agent`.`AgentName`"
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
        LsData.Columns(11).HeaderText = "Guest"
        LsData.Columns(12).HeaderText = "Adl"
        LsData.Columns(12).Width = 40
        LsData.Columns(13).HeaderText = "Chd"
        LsData.Columns(13).Width = 40
        LsData.Columns(14).HeaderText = "FOC"
        LsData.Columns(14).Width = 40
        LsData.Columns(15).HeaderText = "Harga berangkat"
        LsData.Columns(15).DefaultCellStyle.Format = "#,###"
        LsData.Columns(16).HeaderText = "Extra Berangkat"
        LsData.Columns(16).DefaultCellStyle.Format = "#,###"
        LsData.Columns(17).HeaderText = "Harga Kembali"
        LsData.Columns(17).DefaultCellStyle.Format = "#,###"
        LsData.Columns(18).HeaderText = "Extra Kembali"
        LsData.Columns(18).DefaultCellStyle.Format = "#,###"
        LsData.Columns(19).HeaderText = "tras.Berangkat"
        LsData.Columns(19).DefaultCellStyle.Format = "#,###"
        LsData.Columns(20).HeaderText = "ExtraTrans"
        LsData.Columns(20).DefaultCellStyle.Format = "#,###"
        LsData.Columns(21).HeaderText = "Tras.Kemb"
        LsData.Columns(21).DefaultCellStyle.Format = "#,###"
        LsData.Columns(22).HeaderText = "ExtraCost"
        LsData.Columns(22).DefaultCellStyle.Format = "#,###"
        LsData.Columns(23).HeaderText = "Total"
        LsData.Columns(23).DefaultCellStyle.Format = "#,###"
        LsData.Columns(24).HeaderText = "TglLunas"
        LsData.Columns(24).DefaultCellStyle.Format = "dd/MM/yyyy"
        LsData.Columns(24).Width = 75
        LsData.Columns(25).HeaderText = "Driver Berangkat"
        LsData.Columns(25).HeaderText = "Driver Kembali"
        LsData.Columns(26).HeaderText = "Remark"
        LsData.Columns(27).HeaderText = "Status"
        LsData.Columns(27).Visible = False
        LsData.Columns(28).Visible = False
        Dim x As Integer
        For x = 0 To 27
            LsData.Columns(x).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        Call DisconnectDatabase()
        'head()
        colorx()
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
            Dim val = Trim(LsData.Rows(i).Cells(28).Value)
            Dim vals = Trim(LsData.Rows(i).Cells(29).Value)
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
        lblTotal.Text = totalpax & " PAX"
    End Sub
    
    Sub sumls()
        Dim i As Integer
        totalpax = 0
        adl = 0
        chd = 0
        inf = 0
        For i = 0 To LsData.Rows.Count() - 1 Step +1
            'totalpax = totalpax + LsData.Rows(i).Cells(11).Value + LsData.Rows(i).Cells(12).Value + LsData.Rows(i).Cells(13).Value + LsData.Rows(i).Cells(14).Value
            Dim val = Trim(LsData.Rows(i).Cells(51).Value)
            'val = LsData.Rows(i).Cells(44).ToString

            If val = 0 Then
                LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            Else

                adl = adl + NZx(LsData.Rows(i).Cells(10).Value)
                chd = chd + NZx(LsData.Rows(i).Cells(11).Value)
                inf = inf + NZx(LsData.Rows(i).Cells(12).Value)
                totalpax = totalpax + inf + adl + chd
            End If
            
        Next
        'lblTotal.Text = totalpax & " PAX"
        
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
        cboGotrip.DataSource = dt
        cboGotrip.DisplayMember = "tripName"

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
        strQry = "SELECT '0' as ID, 'go' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS Area, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasA & " union SELECT '0' as ID, 'bk' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS Area, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE  " & strCriteriasB & ";"
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

    Private Sub frmAdmins_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    Private Sub frmAdmins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()
        filltrip()
        fillPort()
        'filldata("0", "0")
        lblUser.Text = usr
        Text1.Text = ""
        filldata(0)
        'txtdate.CustomFormat = " "
        'txtdate.Format = DateTimePickerFormat.Custom
        'txtdate.Text = Format(Now, "dd/MM/yyyy")
        'lblTotal.Text = "0 PAX"
        colorx()
        lblTotal.Text = totalpax & " PAX"
    End Sub


    Private Sub LsData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellClick
        Text1.Text = LsData.CurrentRow.Cells(1).Value
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        Text1.Text = LsData.CurrentRow.Cells(1).Value
    End Sub

    Private Sub LsData_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellDoubleClick

    End Sub


    

   

    Private Sub LsData_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles LsData.CellFormatting
        'Dim i As Integer
        'totalpax = 0
        'For i = 0 To LsData.Rows.Count() - 1 Step +1
        '    Dim val = LsData.Rows(i).Cells(28).Value
        '    Dim vals = LsData.Rows(i).Cells(29).Value
        '    'val = LsData.Rows(i).Cells(44).ToString
        '    If val = 0 Then
        '        LsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
        '    End If
        '    If vals = 1 Then
        '        LsData.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
        '    End If

        'Next

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

    Private Sub DailyAvailabilityTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyAvailabilityTicketToolStripMenuItem.Click
        frmAvailability.Show()
    End Sub

    Private Sub DataPortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPortToolStripMenuItem.Click
        frmPort.Show()
    End Sub

    Private Sub AgentPriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgentPriceListToolStripMenuItem.Click
        frmAgentRate.Show()
    End Sub

    Private Sub PromoTiketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PromoTiketToolStripMenuItem.Click
        frmPromo.Show()
    End Sub

    Private Sub SitAlotmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAvailability.Show()
    End Sub

    Private Sub SurChargeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSurcharge.Show()
    End Sub

    Private Sub SpecialEventToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpecialEventToolStripMenuItem.Click
        frmSpecial.Show()
    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

        For i = 0 To LsData.RowCount - 2
            For j = 0 To LsData.ColumnCount - 1
                xlWorkSheet.Cells(i + 1, j + 1) = LsData(j, i).Value
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

    Private Sub cmdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBook.Click
        frmBooking.Show()
    End Sub

    Private Sub cmdEdBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdBook.Click
        If LsData.RowCount = 0 Then
            MsgBox("No Data To Update", vbInformation, "No Data")
            Exit Sub
        End If
        If LsData.CurrentRow.Cells(30).Value = 1 Then
            MsgBox("Tiket Already Invoceiced,", vbInformation, "Data Error")
            frmEditBooking.txtetiket.Text = Text1.Text
            frmEditBooking.disables = False
            frmEditBooking.Show()
            Exit Sub
        End If
        If Text1.Text = "" Then
            MsgBox("Please Choose Data to Update", vbInformation, "No Data")
            Exit Sub
        End If
        'frmEditBooking.txtetiket.Text = Text1.Text
        'frmEditBooking.disables = True
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

    Private Sub cmdvoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdvoid.Click
        If LsData.CurrentRow.Cells(19).Value = 0 Then
            Exit Sub
        End If
        If LsData.CurrentRow.Cells(22).Value = 1 Then
            MsgBox("Tiket already Invoicing", vbInformation, "Void Tiket")
            Exit Sub
        End If
        If LsData.CurrentRow.Cells(23).Value = 1 Then
            MsgBox("Tiket already Paid", vbInformation, "Void Tiket")
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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
        'If Trim(txtdate.Text) = "" Then
        '    MsgBox("Please Choose Date", vbInformation, "Choose  Date")
        '    Exit Sub
        'End If
        'If cbotrip.Text = "" Then
        '    MsgBox("Please select Trip", vbInformation, "Select  Trip")
        '    Exit Sub
        'End If
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
        If Trim(txtgodate.Text) = "" Then
        Else
            If Trim(txtgodate.Text) = "" Then
            Else

                If andx = False Then
                    'strgo = " ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                    strgo = " (tiketdtl.GoDate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    strback = " (tiketdtl.BackDate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    andx = True
                Else
                    'strgo = strgo & " and ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                    strgo = strgo & " and (tiketdtl.GoDate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                    strback = strback & " and (tiketdtl.BackDate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                End If
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
        ''strc1 = "Select '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket , tiketdtl.remark,  tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.departgo, tiketdtl.departBACK , tiketdtl.inv FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strgo & "union Select '" & cboPort.Text & "' AS PORT, tiketdtl.ReqCollect, tiketdtl.NoETiket , tiketdtl.remark,  tiketdtl.NoTiket, agent.AgentName, tiketdtl.mrs, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, if(tiketdtl.QtyTipe=1,tiketdtl.qty,0)as Adult,if(tiketdtl.QtyTipe=2,tiketdtl.qty,0)as Child,if(tiketdtl.QtyTipe=3,tiketdtl.qty,0)as Infant,if(tiketdtl.QtyTipe=4,tiketdtl.qty,0)as FOC, rute.RuteName AS DepartRute , tiketdtl.GoDate AS DepartDate,  trip.TripName , IF(tiketdtl.GoTrans=0,'No','Yes') AS Transport, IF(tiketdtl.BackRuteID='','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID=tiketdtl.BackRuteID)) AS ArrivalRute, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS ArrivalDate,IF(tiketdtl.TripBack='','',(SELECT trip.TripName FROM trip WHERE trip.TripID=tiketdtl.TripBack)) AS ArrivalTrip, IF(tiketdtl.BackTrans=0,'No','Yes') AS ReturnTransport, tiketdtl.Remark, IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS, tiketdtl.departgo, tiketdtl.departBACK , tiketdtl.inv FROM tiketdtl INNER JOIN rute ON (tiketdtl.GoRuteID = rute.RuteID)  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) INNER JOIN trip ON (tiketdtl.GoTrip = trip.TripID) WHERE " & strback
        frmPrintTikets.sqlPrint = strc1
        frmPrintTikets.Show()
    End Sub

   
    Private Sub cmdFilter_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        Dim str As String = ""
        Dim ands As Boolean = False
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
                If cboPort.SelectedItem("PortID") > 2 Then
                    str = " ((tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "') or (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "'))"
                Else
                    str = "(tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                End If

                ands = True
            Else
                If cboPort.SelectedItem("PortID") > 2 Then
                    str = str & " and ((tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "') or (tiketdtl.backdate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "'))"
                Else
                    str = str & " and (tiketdtl.Godate between '" & Str2Date(txtgodate.Text) & "' and '" & Str2Date(txtgodate2.Text) & "')"
                End If

                ands = True
            End If
        End If
        

        If cboPort.Text = "" Then
        Else
            Dim ctr = cboPort.SelectedItem("PortID")
            If ands = False Then
                If cboPort.SelectedItem("PortID") > 2 Then
                    str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                Else
                    str = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                End If


                ''strback = " (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ")"
                ands = True
            Else
                If cboPort.SelectedItem("PortID") > 2 Then
                    str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                Else
                    str = str & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                End If


                'strback = strback & " and (tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
            End If
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

        'If txtremark.Text = "" Then
        'Else
        '    If ands = False Then
        '        str = " (tiketdtl.remark like '%" & txtremark.Text & "%')"
        '        ands = True
        '    Else
        '        str = str & " and (tiketdtl.remark like '%" & txtremark.Text & "%')"
        '        ands = True
        '    End If

        'End If


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

        filldata(str)
    End Sub

    Private Sub cmdExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
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
        xlWorkSheet.Cells(1, 11) = "Guest"
        xlWorkSheet.Cells(1, 12) = "Adl"
        xlWorkSheet.Cells(1, 13) = "Chd"
        xlWorkSheet.Cells(1, 14) = "FOC"
        xlWorkSheet.Cells(1, 15) = "Harga berangkat"
        xlWorkSheet.Cells(1, 16) = "Extra Berangkat"
        xlWorkSheet.Cells(1, 17) = "Harga Kembali"
        xlWorkSheet.Cells(1, 18) = "Extra Kembali"
        xlWorkSheet.Cells(1, 19) = "tras.Berangkat"
        xlWorkSheet.Cells(1, 20) = "ExtraTrans"
        xlWorkSheet.Cells(1, 21) = "Tras.Kemb"
        xlWorkSheet.Cells(1, 22) = "ExtraCost"
        xlWorkSheet.Cells(1, 23) = "Total"
       
        xlWorkSheet.Cells(1, 24) = "TglLunas"
        xlWorkSheet.Cells(1, 25) = "Driver Berangkat"
        xlWorkSheet.Cells(1, 26) = "Driver Kembali"
        xlWorkSheet.Cells(1, 27) = "Remark"
        xlWorkSheet.Cells(1, 28) = "Status"
        For i = 0 To LsData.RowCount - 1
            For j = 1 To LsData.ColumnCount - 1

                xlWorkSheet.Cells(i + 2, j) = LsData(j, i).Value

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

    
    Private Sub TourToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TourToolStripMenuItem.Click
        frmTourList.Show()
    End Sub

    Private Sub TopSupportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopSupportToolStripMenuItem.Click
        frmTopSupport.Show()
    End Sub
End Class