Imports MySql.Data.MySqlClient
Imports System.Data.DataTable
Public Class frmShutle
    Public from As Boolean
    Sub cls()
        txtetiket.Text = ""
        txttiket.Text = ""
        txtagent.Text = ""
        txtname.Text = ""
        cboarea.Text = ""
        txtlokasi.Text = ""
        txtdriver.Text = ""
        txtarea.Text = ""
        txlokasi.Text = ""
        txdriver.Text = ""
        txtsts.Text = ""
    End Sub
    Sub head()
        LsData.ColumnCount = 10
        LsData.Columns(0).Name = "ID"
        LsData.Columns(0).Visible = False
        LsData.Columns(1).Name = "sts"
        LsData.Columns(1).Visible = False
        LsData.Columns(2).Name = "ETiket"
        LsData.Columns(2).HeaderText = "No. ETiket"
        LsData.Columns(3).Name = "NoTiket"
        LsData.Columns(3).HeaderText = "No. Tiket"
        'LsData.Columns(2).Visible = False
        LsData.Columns(4).Name = "Agent"
        LsData.Columns(5).Name = "Name"
        LsData.Columns(6).Name = "AGE"
        LsData.Columns(7).Name = "Area"

        LsData.Columns(8).Name = "Location"
        LsData.Columns(9).Name = "Driver"

        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
    End Sub
    Sub fillarea()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da, da2 As MySqlDataAdapter
        Dim dt, dt2 As DataTable
        da = New MySqlDataAdapter("select AreaID,areaName from area", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("areaID") = 0
        dr("AreaName") = ""
        dt.Rows.InsertAt(dr, 0)
        cboarea.DataSource = dt
        cboarea.DisplayMember = "AreaName"
        da2 = New MySqlDataAdapter("select AreaID,areaName from area", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("areaID") = 0
        dr2("AreaName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        cboarea2.DataSource = dt2
        cboarea2.DisplayMember = "AreaName"

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
        cbotrip.DataSource = dt
        cbotrip.DisplayMember = "tripName"
        da2 = New MySqlDataAdapter("select TripID,TripName from trip", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("TripID") = 0
        dr2("TripName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        'da.Fill(dt)
        cbotrip2.DataSource = dt2
        cbotrip2.DisplayMember = "tripName"

        Call DisconnectDatabase()
    End Sub
    Sub filldriver()

        Call ConnectDatabase()
        Dim da, da2 As MySqlDataAdapter
        Dim dt, dt2 As DataTable
        da = New MySqlDataAdapter("select DriverID,DriverName from driver", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("DriverID") = 0
        dr("DriverName") = ""
        dt.Rows.InsertAt(dr, 0)
        'da.Fill(dt)
        txtdrive2.DataSource = dt
        txtdrive2.DisplayMember = "DriverName"

        da2 = New MySqlDataAdapter("select DriverID,DriverName from driver", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("DriverID") = 0
        dr2("DriverName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        'da.Fill(dt)
        txtdriver2.DataSource = dt2
        txtdriver2.DisplayMember = "DriverName"
        Call DisconnectDatabase()
    End Sub
    Sub fillPort()
        Call ConnectDatabase()
        Dim da, da2 As MySqlDataAdapter
        Dim dt, dt2 As DataTable
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
        da2 = New MySqlDataAdapter("select PortID,PortName from port", conn)
        dt2 = New DataTable
        Dim dr2 As DataRow = dt2.NewRow
        da2.Fill(dt2)
        dr2("PortID") = 0
        dr2("PortName") = ""
        dt2.Rows.InsertAt(dr2, 0)
        'da.Fill(dt)
        cboPort2.DataSource = dt2
        cboPort2.DisplayMember = "PortName"

        Call DisconnectDatabase()
    End Sub
    Sub fillshutle()
        Dim sPort As Integer = cboPort.SelectedItem("PortID")
        Dim sdate As String = Str2Date(txtdate.Text)
        Dim strip
        If cbotrip.Text = "" Then
            strip = "0"
        Else
            strip = cbotrip.SelectedItem("TripID")
        End If
        Dim sArea
        If cboarea2.Text = "" Then
            sArea = "0"
        Else
            sArea = cboarea2.SelectedItem("AreaID")

        End If
        Dim sDriver As String = txtdrive2.Text
        Dim strQry, strCriteriasA, strCriteriasB, strCriteriasC As String
        strCriteriasA = ""
        strCriteriasB = ""
        strCriteriasC = ""
        Dim ands As Boolean = False
        strQry = ""
        If Trim(sdate) = "" Then
        Else
            strCriteriasA = " (tiketdtl.GoDATE='" & sdate & "')"
            strCriteriasB = " (tiketdtl.BackDATE='" & sdate & "')"
            strCriteriasC = " (tiketdtl.soDATE='" & sdate & "')"
            ands = True
        End If
        If sPort = 0 Then
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasB = " (tiketdtl.BackRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasC = " (tiketdtl.doRute IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasB = strCriteriasB & " and (tiketdtl.BackRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasC = strCriteriasC & " and (tiketdtl.sorute IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
            End If

        End If
        If strip = "0" Then
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoTrip='" & strip & "')"
                strCriteriasB = " (tiketdtl.TripBack='" & strip & "')"
                strCriteriasC = " (tiketdtl.sotrip='" & strip & "')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoTrip='" & strip & "')"
                strCriteriasB = strCriteriasB & " and (tiketdtl.TripBack='" & strip & "')"
                strCriteriasC = strCriteriasC & " and (tiketdtl.sotrip='" & strip & "')"
            End If

        End If
        If sArea = "0" Then
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoArea='" & sArea & "')"
                strCriteriasB = " (tiketdtl.BackArea='" & sArea & "')"
                strCriteriasC = " (tiketdtl.soarea='" & sArea & "')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoArea='" & sArea & "')"
                strCriteriasB = strCriteriasB & " and (tiketdtl.Backarea='" & sArea & "')"
                strCriteriasC = strCriteriasC & " and (tiketdtl.soarea='" & sArea & "')"
            End If

        End If
        If sDriver = "" Then
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoDriver like'%" & sDriver & "%')"
                strCriteriasB = " (tiketdtl.BackDriver like'%" & sDriver & "%')"
                strCriteriasC = " (tiketdtl.sodriver like'%" & sDriver & "%')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoDriver like'%" & sDriver & "%')"
                strCriteriasB = strCriteriasB & " and (tiketdtl.BackDriver like'%" & sDriver & "%')"
                strCriteriasC = strCriteriasC & " and (tiketdtl.sodriver like'%" & sDriver & "%')"
            End If

        End If

        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        strQry = "SELECT 0 as ID, 'go' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS Area, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasA & " and tiketdtl.GoTrans=1 AND tiketdtl.STATUS=1 union SELECT 0 as ID, 'back' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.BackArea)) Area, tiketdtl.BackPickup AS Location, tiketdtl.BackDriver as Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasB & " and tiketdtl.BackTrans=1  AND tiketdtl.STATUS=1 union SELECT 0 as ID, 'sover' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.soArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.soArea)) Area, tiketdtl.sopickup AS Location, tiketdtl.sodriver as Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasC & "  and tiketdtl.SOTransp=1   AND tiketdtl.STATUS=1 ;"

        da = New MySqlDataAdapter(strQry, conn)
        dt = New DataTable
        da.Fill(dt)
        'frmShutle.LsData.DataSource = dt
        'frmShutle.LsData.AllowUserToAddRows = False
        'frmShutle.LsData.AllowUserToDeleteRows = False
        'Dim dr As DataRow = dt.NewRow
        'da.Fill(dt)

        'Dim da2 As MySqlDataAdapter
        'Dim dt2 As New DataTable
        'strQry = "select areaID,AreaName from area"
        'da2 = New MySqlDataAdapter(strQry, conn)
        'dt2 = New DataTable
        'da2.Fill(dt2)
        ''Dim col As New DataGridViewComboBoxColumn
        'Dim col As New DataGridViewComboBoxCell
        'col.DataSource = dt2
        'col.DisplayMember = "AreaName"
        'col.HeaderText = "Area"
        'col.ValueMember = "AreaName"

        'LsData.DataSource = dt
        If LsData.Rows.Count > 0 Then
            ' LsData.Rows.Clear()
        End If
        'LsData.DataSource = Nothing
        'head()
        'Dim i As Integer
        'For i = 0 To dt.Rows.Count - 1
        '    LsData.Rows.Add()

        '    LsData.Rows(i).Cells(0).Value = dt.Rows(i).ItemArray(0)
        '    LsData.Rows(i).Cells(1).Value = dt.Rows(i).ItemArray(1)
        '    LsData.Rows(i).Cells(2).Value = dt.Rows(i).ItemArray(2)
        '    LsData.Rows(i).Cells(3).Value = dt.Rows(i).ItemArray(3)
        '    LsData.Rows(i).Cells(4).Value = dt.Rows(i).ItemArray(4)
        '    LsData.Rows(i).Cells(5).Value = dt.Rows(i).ItemArray(5)
        '    LsData.Rows(i).Cells(6).Value = dt.Rows(i).ItemArray(6)
        '    'LsData.Rows(i).Cells(7) = dt.Rows(i).ItemArray(7)
        '    Dim colX As DataGridViewComboBoxCell = DirectCast(LsData.Rows(i).Cells(7), DataGridViewComboBoxCell)
        '    colX.Value = dt.Rows(i).ItemArray(7)

        '    LsData.Rows(i).Cells(8).Value = dt.Rows(i).ItemArray(8)
        '    LsData.Rows(i).Cells(9).Value = dt.Rows(i).ItemArray(9)

        'Next
        LsData.DataSource = dt
        'frmShutle.LsData.Rows.Insert(dt2)
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.AllowDrop = False
        LsData.Columns(0).Visible = False
        LsData.Columns(1).Visible = False
        LsData.Columns(2).ReadOnly = True
        LsData.Columns(3).ReadOnly = True
        LsData.Columns(4).ReadOnly = True
        LsData.Columns(5).ReadOnly = True
        LsData.Columns(6).ReadOnly = True
        'LsData.Columns.Insert(7, col)
        '        LsData.Columns(7).HeaderText = "Area"
        Call DisconnectDatabase()

    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        cls()
        fillshutle()
    End Sub

    Private Sub frmShutle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillPort()
        filldriver()
        filltrip()
        fillarea()
        If from = True Then
            Panel2.Visible = False
        Else
            Panel2.Visible = True

        End If
    End Sub

    Private Sub LsData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellClick
        txtetiket.Text = LsData.CurrentRow.Cells(2).Value
        txttiket.Text = LsData.CurrentRow.Cells(3).Value
        txtagent.Text = LsData.CurrentRow.Cells(4).Value
        txtname.Text = LsData.CurrentRow.Cells(5).Value
        cboarea.Text = NNULL(LsData.CurrentRow.Cells(7).Value)
        txtlokasi.Text = NNULL(LsData.CurrentRow.Cells(8).Value)
        txtdriver.Text = NNULL(LsData.CurrentRow.Cells(9).Value)
        txtarea.Text = NNULL(LsData.CurrentRow.Cells(7).Value)
        txlokasi.Text = NNULL(LsData.CurrentRow.Cells(8).Value)
        txdriver.Text = NNULL(LsData.CurrentRow.Cells(9).Value)
        txtsts.Text = NNULL(LsData.CurrentRow.Cells(1).Value)
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        txtetiket.Text = LsData.CurrentRow.Cells(2).Value
        txttiket.Text = LsData.CurrentRow.Cells(3).Value
        txtagent.Text = LsData.CurrentRow.Cells(4).Value
        txtname.Text = LsData.CurrentRow.Cells(5).Value
        cboarea.Text = NNULL(LsData.CurrentRow.Cells(7).Value)
        txtlokasi.Text = NNULL(LsData.CurrentRow.Cells(8).Value)
        txtdriver.Text = NNULL(LsData.CurrentRow.Cells(9).Value)
        txtarea.Text = NNULL(LsData.CurrentRow.Cells(7).Value)
        txlokasi.Text = NNULL(LsData.CurrentRow.Cells(8).Value)
        txdriver.Text = NNULL(LsData.CurrentRow.Cells(9).Value)
        txtsts.Text = NNULL(LsData.CurrentRow.Cells(1).Value)
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If MsgBox("Are You sure to update Data?", vbYesNo, "Update data") = vbYes Then
            Try
                Dim strSql As String = ""
                Dim strSqlc As String = ""
                Dim strLog As String = ""
                Dim wit As Boolean = False
                If txtsts.Text = "go" Then
                    If cboarea.Text = txtarea.Text Then
                    Else
                        strSql = strSql & " GoArea='" & cboarea.SelectedItem("AreaID").ToString & "'"
                        strLog = strLog & " ,GoArea=" & txtarea.Text
                        wit = True
                    End If
                    If txtlokasi.Text = txlokasi.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " GoPickup='" & txtlokasi.Text & "'"
                        strLog = strLog & " ,GoPickup= " & txlokasi.Text
                        wit = True
                    End If
                    If txtdriver.Text = txdriver.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " GoDriver='" & txtdriver.Text & "'"
                        strLog = strLog & " ,GoDriver=" & txdriver.Text

                    End If
                End If
                If txtsts.Text = "back" Then
                    If cboarea.Text = txtarea.Text Then
                    Else

                        strSql = strSql & " BackArea='" & cboarea.SelectedItem("AreaID").ToString & "'"
                        strLog = strLog & " ,BackArea=" & txtarea.Text
                        wit = True
                    End If
                    If txtlokasi.Text = txlokasi.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " BackPickup='" & txtlokasi.Text & "'"
                        strLog = strLog & " ,BackPickup= " & txlokasi.Text
                        wit = True
                    End If
                    If txtdriver.Text = txdriver.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " BackDriver='" & txtdriver.Text & "'"
                        strLog = strLog & " ,BackDriver= " & txdriver.Text

                    End If

                End If
                If txtsts.Text = "sover" Then
                    If cboarea.Text = txtarea.Text Then
                    Else

                        strSql = strSql & " soArea='" & cboarea.SelectedItem("AreaID").ToString & "'"
                        strLog = strLog & " , soArea=" & txtarea.Text
                        wit = True
                    End If
                    If txtlokasi.Text = txlokasi.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " soPickup='" & txtlokasi.Text & "'"
                        strLog = strLog & " ,soPickup= " & txlokasi.Text
                        wit = True
                    End If
                    If txtdriver.Text = txdriver.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " soDriver='" & txtdriver.Text & "'"
                        strLog = strLog & " ,soDriver= " & txdriver.Text

                    End If

                End If
                Call ConnectDatabase()
                strSqlc = "update tiketdtl set " & strSql & " where NoEtiket='" & txtetiket.Text & "' and notiket='" & txttiket.Text & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSqlc, conn)
                Comd.ExecuteNonQuery()

                Call DisconnectDatabase()
                ''strLog = "Update No Etiket='" & txtetiket.Text & "' and NoTiket='" & txttiket.Text & "' for " & strLog
                strSql = Replace(strSql, "'", " ")
                strLog = Replace(strLog, "'", " ")
                FillLog(usr, "Update Shutle Tiket", " No Etiket=" & txtetiket.Text & " and NoTiket=" & txttiket.Text & "", strLog, strSql)
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
            cls()
        Else

            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmDriverlist.Show()
        frmDriverlist.forms = "frmShutle"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sPort As Integer = cboPort2.SelectedItem("PortID")
        Dim sdate As String = Str2Date(txtdate2.Text)
        Dim strip = cbotrip2.SelectedItem("TripID")
        Dim sArea = cboarea2.SelectedItem("areaID")
        Dim sDriver As String = txtdriver2.Text
        Dim strQry, strCriteriasA, strCriteriasB, strCriteriasC As String
        strCriteriasA = ""
        strCriteriasB = ""
        strCriteriasC = ""
        Dim ands As Boolean = False
        strQry = ""
        If Trim(sdate) = "" Then
            MsgBox("Please Choose Date to Print", vbInformation, "Print Shuttle")
            Exit Sub
        Else
            strCriteriasA = " (tiketdtl.GoDATE='" & sdate & "')"
            strCriteriasB = " (tiketdtl.BackDATE='" & sdate & "')"
            strCriteriasC = " (tiketdtl.sodate='" & sdate & "')"
            ands = True
        End If
        If sPort = 0 Then
            MsgBox("Please Choose Port to Print", vbInformation, "Print Shuttle")
            Exit Sub
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasB = " (tiketdtl.BackRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasC = " (tiketdtl.sorute IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasB = strCriteriasB & " and (tiketdtl.BackRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
                strCriteriasC = strCriteriasC & " and (tiketdtl.sorute IN (SELECT ruteID FROM rute WHERE PortStart=" & sPort & "))"
            End If

        End If
        If strip = "0" Then
            MsgBox("Please Choose Trip to Print", vbInformation, "Print Shuttle")
            Exit Sub
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoTrip='" & strip & "')"
                strCriteriasB = " (tiketdtl.TripBack='" & strip & "')"
                strCriteriasC = " (tiketdtl.sotrip='" & strip & "')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoTrip='" & strip & "')"
                strCriteriasB = strCriteriasB & " and (tiketdtl.TripBack='" & strip & "')"
                strCriteriasC = strCriteriasC & " and (tiketdtl.sotrip='" & strip & "')"
            End If

        End If
        If sArea = "0" Then
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoArea='" & sArea & "')"
                strCriteriasB = " (tiketdtl.BackArea='" & sArea & "')"
                strCriteriasC = " (tiketdtl.soArea='" & sArea & "')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoArea='" & sArea & "')"
                strCriteriasB = strCriteriasB & " and (tiketdtl.Backarea='" & sArea & "')"
                strCriteriasC = strCriteriasC & " and (tiketdtl.soarea='" & sArea & "')"
            End If

        End If
        If sDriver = "" Then
            MsgBox("Please Choose Driver to Print", vbInformation, "Print Shuttle")
            Exit Sub
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoDriver like'%" & sDriver & "%')"
                strCriteriasB = " (tiketdtl.BackDriver like'%" & sDriver & "%')"
                strCriteriasC = " (tiketdtl.soDriver like'%" & sDriver & "%')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoDriver like'%" & sDriver & "%')"
                strCriteriasB = strCriteriasB & " and (tiketdtl.BackDriver like'%" & sDriver & "%')"
                strCriteriasC = strCriteriasC & " and (tiketdtl.soDriver like'%" & sDriver & "%')"
            End If

        End If

        'strQry = "SELECT '" & cboPort2.Text & "' as Port, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`mrs`, `tiketdtl`.`Guest`, `tiketdtl`.`GoDate`, `trip`.`TripName`, `agent`.`AgentName`, `tiketdtl`.`GoPickUp`, `tiketdtl`.`GoDriver`, `tiketdtl`.`Remark` FROM `ekajaya`.`agent` INNER JOIN `ekajaya`.`tiketdtl` ON ( `agent`.`AgentID` = `tiketdtl`.`AgentID` ) INNER JOIN `ekajaya`.`trip` ON ( `tiketdtl`.`GoTrip` = `trip`.`TripID` )   WHERE " & strCriteriasA & " and tiketdtl.GoTrans=1 AND tiketdtl.STATUS=1"
        strQry = "SELECT '" & cboPort2.Text & "' as Port, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`mrs`, `tiketdtl`.`Guest`, `tiketdtl`.`GoDate`, `trip`.`TripName`, `agent`.`AgentName`, `tiketdtl`.`GoPickUp`, `tiketdtl`.`GoDriver`, `tiketdtl`.`Remark` FROM `ekajaya`.`agent` INNER JOIN `ekajaya`.`tiketdtl` ON ( `agent`.`AgentID` = `tiketdtl`.`AgentID` ) INNER JOIN `ekajaya`.`trip` ON ( `tiketdtl`.`GoTrip` = `trip`.`TripID` )   WHERE " & strCriteriasA & " and tiketdtl.GoTrans=1 AND tiketdtl.STATUS=1"
        'strQry = "SELECT 0 as ID, 'go' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.GoArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) AS Area, tiketdtl.GoPickUp AS Location, tiketdtl.GoDriver AS Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasA & " and tiketdtl.GoTrans=1 AND tiketdtl.STATUS=1"
        frmPrintShuttle.sql = strQry
        frmPrintShuttle.Show()

    End Sub
End Class