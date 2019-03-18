Imports MySql.Data.MySqlClient
Imports System.Data.DataTable
Public Class frmOpenReturn
    Sub cls()
        txtetiket.Text = ""
        txttiket.Text = ""
        txtname.Text = ""
        cbotripback.Text = ""
        txtbtrip.Text = ""
        cboruteback.Text = ""
        txtbrute.Text = ""
        txtbackdate.CustomFormat = " "
        txtbdate.Text = ""
        txtbackdate.Format = DateTimePickerFormat.Custom
        cboBackArea.Text = ""
        txtbarea.Text = ""
        txtPickupBack.Text = ""
        txtblokasi.Text = ""
        txtbackDrive.Text = ""
        txtbdriver.Text = ""
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
        cbotripback.DataSource = dt2
        cbotripback.DisplayMember = "tripName"
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
    Sub fillRute()
        Call ConnectDatabase()
        Dim da2 As MySqlDataAdapter
        Dim dt2 As DataTable

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

    Sub fillarea()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AreaID,areaName from area", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("areaID") = 0
        dr("AreaName") = ""
        dt.Rows.InsertAt(dr, 0)
        cboBackArea.DataSource = dt
        cboBackArea.DisplayMember = "AreaName"

        Call DisconnectDatabase()
    End Sub


    Sub fillshutle(ByVal sPort As Integer, ByVal sdate As String, ByVal strip As String)
        Dim strQry, strCriteriasA, strCriteriasB, strCriteriasC As String
        strCriteriasA = ""
        strCriteriasB = ""
        strCriteriasC = ""
        Dim ands As Boolean = False
        strQry = ""
        If sPort = 0 Then
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
        If sdate = " " Or sdate = Nothing Then
        Else
            If ands = False Then
                strCriteriasA = " (tiketdtl.GoDATE='" & sdate & "')"
                'strCriteriasB = " (tiketdtl.BackDATE='" & sdate & "')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and (tiketdtl.GoDATE='" & sdate & "')"
                'strCriteriasB = strCriteriasB & " and (tiketdtl.BackDATE='" & sdate & "')"
            End If

        End If
        If txtnotiket.Text = "" Then
        Else
            If ands = False Then
                strCriteriasA = " ((tiketdtl.noetiket like '%" & txtnotiket.Text & "%') or (tiketdtl.notiket like '%" & txtnotiket.Text & "%'))"
                'strCriteriasB = " (tiketdtl.BackDATE='" & sdate & "')"
                ands = True
            Else
                strCriteriasA = strCriteriasA & " and ((tiketdtl.noetiket like '%" & txtnotiket.Text & "%') or (tiketdtl.notiket like '%" & txtnotiket.Text & "%'))"
                'strCriteriasB = strCriteriasB & " and (tiketdtl.BackDATE='" & sdate & "')"
            End If
        End If
        If strCriteriasA = "" Then
            Exit Sub
        End If
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        'strQry = "SELECT 'back' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE,tiketdtl.BackRuteID, IF(tiketdtl.BackRuteID = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.BackRuteID)) AS ArrivalRute, tiketdtl.BackDate AS ArrivalDate, tiketdtl.TripBack,IF(tiketdtl.TripBack = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.TripBack)) AS ArrivalTrip,if (tiketdtl.BackTrans=1,'Yes','No') as Transport, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) Area, tiketdtl.BackPickup AS Location, tiketdtl.BackDriver as Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasA & " and ((tiketdtl.tipe = 'RT') OR (tiketdtl.tipe = '3A') ) and ((tiketdtl.backdate is null ) or(tiketdtl.backdate='')or(tiketdtl.backarea='')or(tiketdtl.backpickup='')or(tiketdtl.backdriver='')or(tiketdtl.backruteid='')or(tiketdtl.backruteid=0)or(tiketdtl.backruteid is null )or(tiketdtl.tripback='')or(tiketdtl.tripback=0)or(tiketdtl.tripback is null ) ) ;"
        strQry = "SELECT 'back' as sts, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE,tiketdtl.BackRuteID, IF(tiketdtl.BackRuteID = '','',(SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.BackRuteID)) AS ArrivalRute, tiketdtl.BackDate AS ArrivalDate, tiketdtl.TripBack,IF(tiketdtl.TripBack = '','',(SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.TripBack)) AS ArrivalTrip,if (tiketdtl.BackTrans=1,'Yes','No') as Transport, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) Area, tiketdtl.BackPickup AS Location, tiketdtl.BackDriver as Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasA & " and ((tiketdtl.tipe = 'RT')) and ((tiketdtl.backdate is null ) or(tiketdtl.backdate='')or(tiketdtl.backruteid='')or(tiketdtl.backruteid=0)or(tiketdtl.backruteid is null )or(tiketdtl.tripback='')or(tiketdtl.tripback=0)or(tiketdtl.tripback is null ) ) union SELECT 'sover' AS sts, tiketdtl.NoETiket, tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest, IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, tiketdtl.sorute, IF( tiketdtl.sorute = '', '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.sorute) ) AS ArrivalRute, tiketdtl.soDate AS ArrivalDate, tiketdtl.sotrip, IF( tiketdtl.sotrip = '', '', (SELECT trip.TripName FROM trip WHERE trip.TripID = tiketdtl.sotrip) ) AS ArrivalTrip, IF (tiketdtl.sotransp = 1, 'Yes', 'No') AS Transport, IF( tiketdtl.soarea = 0, '', (SELECT area.AreaName FROM AREA WHERE area.AreaID = tiketdtl.soarea) ) AREA, tiketdtl.soPickup AS Location, tiketdtl.soDriver AS Driver FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) WHERE (" & strCriteriasA & ") AND ( (tiketdtl.tipe = '3A') ) AND ( (tiketdtl.sodate IS NULL) OR (tiketdtl.sodate = '') OR (tiketdtl.sorute = '') OR (tiketdtl.sorute = 0) OR (tiketdtl.sorute IS NULL) OR (tiketdtl.sotrip = '') OR (tiketdtl.sotrip = 0) OR (tiketdtl.sotrip IS NULL) )"
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
        'strQry = "SELECT 0 as ID, tiketdtl.NoETiket , tiketdtl.NoTiket, agent.AgentName, tiketdtl.Guest,IF(tiketdtl.QtyTipe = 1,'ADL',IF(tiketdtl.QtyTipe = 2,'CHD',IF(tiketdtl.QtyTipe = 3,'INF',IF(tiketdtl.QtyTipe = 4,'FOC','')))) AS AGE, IF(tiketdtl.BackArea=0,'',(SELECT area.AreaName FROM AREA WHERE area.AreaID=tiketdtl.GoArea)) Area, tiketdtl.BackPickup AS Location, tiketdtl.BackDriveras Driver  FROM tiketdtl  INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID)  WHERE " & strCriteriasB
        'da2 = New MySqlDataAdapter(strQry, conn)
        'dt2 = New DataTable
        'da2.Fill(dt2)
        'dt.Rows.Add()
        LsData.DataSource = dt
        'frmShutle.LsData.Rows.Insert(dt2)
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.ReadOnly = True
        LsData.Columns(0).Visible = False
        LsData.Columns(6).Visible = False
        LsData.Columns(7).Visible = False
        LsData.Columns(9).Visible = False
        Call DisconnectDatabase()

    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        cls()
        Dim port, trip As String
        If IsDBNull(cboPort.SelectedItem("PortID")) Then
            port = 0
        Else
            port = cboPort.SelectedItem("PortID")
        End If
        If IsDBNull(cbotrip.SelectedItem("TripID")) Then
            trip = 0
        Else
            trip = cbotrip.SelectedItem("TripID")
        End If
        fillshutle(port, Str2Date(txtdate.Text), trip)
    End Sub

    Private Sub frmOpenReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillPort()
        filltrip()
        fillarea()
        fillRute()
        txtdate.Text = Format(Now, "dd/MMM/yyyy")
    End Sub

    Private Sub LsData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellClick
        cls()
        txtetiket.Text = LsData.CurrentRow.Cells(1).Value
        txttiket.Text = LsData.CurrentRow.Cells(2).Value
        txtname.Text = LsData.CurrentRow.Cells(4).Value
        If IsDBNull(LsData.CurrentRow.Cells(10).Value) Then
            cbotripback.Text = ""
            txtbtrip.Text = ""
        Else
            cbotripback.Text = LsData.CurrentRow.Cells(10).Value
            txtbtrip.Text = LsData.CurrentRow.Cells(10).Value
        End If


        cboruteback.Text = LsData.CurrentRow.Cells(7).Value
        txtbrute.Text = LsData.CurrentRow.Cells(7).Value
        'cboBackArea.Text = LsData.CurrentRow.Cells(9).Value
        If IsDBNull(LsData.CurrentRow.Cells(8).Value) Then
            txtbackdate.CustomFormat = " "
            txtbdate.Text = ""
            txtbackdate.Format = DateTimePickerFormat.Custom
        Else
            txtbackdate.Text = LsData.CurrentRow.Cells(8).Value
            txtbdate.Text = LsData.CurrentRow.Cells(8).Value
            txtbackdate.Format = DateTimePickerFormat.Short
        End If
        If LsData.CurrentRow.Cells(11).Value = "Yes" Then
            txtbtrans.Text = "Yes"
            CxBackTrans.Checked = True
            GroupBox6.Enabled = True
            If IsDBNull(LsData.CurrentRow.Cells(12).Value) Then
                cboBackArea.Text = ""
                txtbarea.Text = ""
            Else
                cboBackArea.Text = LsData.CurrentRow.Cells(12).Value
                txtbarea.Text = LsData.CurrentRow.Cells(12).Value
            End If
            If IsDBNull(LsData.CurrentRow.Cells(13).Value) Then
                txtPickupBack.Text = ""
                txtblokasi.Text = ""
            Else
                txtPickupBack.Text = LsData.CurrentRow.Cells(13).Value
                txtblokasi.Text = LsData.CurrentRow.Cells(13).Value
            End If
            If IsDBNull(LsData.CurrentRow.Cells(14).Value) Then
                txtbackDrive.Text = ""
                txtbdriver.Text = ""
            Else
                txtbackDrive.Text = LsData.CurrentRow.Cells(14).Value
                txtbdriver.Text = LsData.CurrentRow.Cells(14).Value
            End If
            
        Else
            GroupBox6.Enabled = False
        End If
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        cls()
        txtsts.Text = LsData.CurrentRow.Cells(0).Value
        txtetiket.Text = LsData.CurrentRow.Cells(1).Value
        txttiket.Text = LsData.CurrentRow.Cells(2).Value
        txtname.Text = LsData.CurrentRow.Cells(4).Value
        txtagent.Text = LsData.CurrentRow.Cells(3).Value
        txtgodate.Text = GetField("godate", "tiketdtl", "noEtiket='" & LsData.CurrentRow.Cells(1).Value & "'")
        txtgorute.Text = ChField("Select RuteName from rute where RuteID=(Select GoruteID from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "')")
        txtgotrip.Text = ChField("Select TripName from trip where TripID=(Select GoTrip from tiketdtl where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "')")
        If IsDBNull(LsData.CurrentRow.Cells(10).Value) Then
            cbotripback.Text = ""
            txtbtrip.Text = ""
        Else
            cbotripback.Text = LsData.CurrentRow.Cells(10).Value
            txtbtrip.Text = LsData.CurrentRow.Cells(10).Value
        End If
        'cbotripback.Text = LsData.CurrentRow.Cells(10).Value
        'txtbtrip.Text = LsData.CurrentRow.Cells(10).Value
        cboruteback.Text = LsData.CurrentRow.Cells(7).Value
        txtbrute.Text = LsData.CurrentRow.Cells(7).Value
        'cboBackArea.Text = LsData.CurrentRow.Cells(9).Value
        If IsDBNull(LsData.CurrentRow.Cells(8).Value) Then
            txtbackdate.CustomFormat = " "
            txtbdate.Text = ""
            txtbackdate.Format = DateTimePickerFormat.Custom
        Else
            txtbackdate.Text = LsData.CurrentRow.Cells(8).Value
            txtbdate.Text = LsData.CurrentRow.Cells(8).Value
            txtbackdate.Format = DateTimePickerFormat.Short
        End If
        If LsData.CurrentRow.Cells(11).Value = "Yes" Then
            txtbtrans.Text = "Yes"
            CxBackTrans.Checked = True
            GroupBox6.Enabled = True
            If IsDBNull(LsData.CurrentRow.Cells(12).Value) Then
                cboBackArea.Text = ""
                txtbarea.Text = ""
            Else
                cboBackArea.Text = LsData.CurrentRow.Cells(12).Value
                txtbarea.Text = LsData.CurrentRow.Cells(12).Value
            End If
            If IsDBNull(LsData.CurrentRow.Cells(13).Value) Then
                txtPickupBack.Text = ""
                txtblokasi.Text = ""
            Else
                txtPickupBack.Text = LsData.CurrentRow.Cells(13).Value
                txtblokasi.Text = LsData.CurrentRow.Cells(13).Value
            End If
            If IsDBNull(LsData.CurrentRow.Cells(14).Value) Then
                txtbackDrive.Text = ""
                txtbdriver.Text = ""
            Else
                txtbackDrive.Text = LsData.CurrentRow.Cells(14).Value
                txtbdriver.Text = LsData.CurrentRow.Cells(14).Value
            End If
        Else
            GroupBox6.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Are You sure to update Data?", vbYesNo, "Update data") = vbYes Then
            Try
                Dim strSql As String = ""
                Dim strSqlc As String = ""
                Dim strLog As String = ""
                Dim wit As Boolean = False
                If txtsts.Text = "back" Then
                    If cbotripback.Text = txtbtrip.Text Then
                    Else
                        strSql = strSql & " tripback=" & cbotripback.SelectedIndex
                        strLog = strLog & " ,tripback=" & txtbtrip.Text
                        wit = True
                    End If
                    If cboruteback.Text = txtbrute.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " BackRuteID=" & cboruteback.SelectedIndex
                        strLog = strLog & " ,BackRuteID=" & txtbrute.Text
                        wit = True
                    End If
                    If txtbackdate.Text = txtbdate.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " BackDate='" & Str2Date(txtbackdate.Text) & "'"
                        strLog = strLog & " ,BackDate= " & Str2Date(txtbackdate.Text)
                        wit = True
                    End If
                    If cboBackArea.Text = txtbarea.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " BackArea='" & cboBackArea.SelectedIndex & "'"
                        strLog = strLog & " ,Backarea = " & cboBackArea.Text
                        wit = True
                    End If
                    If txtPickupBack.Text = txtblokasi.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " BackPickup='" & txtPickupBack.Text & "'"
                        strLog = strLog & " ,BackPickup = " & txtblokasi.Text
                        wit = True
                    End If
                    If txtbackDrive.Text = txtbdriver.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " BackDriver='" & txtbackDrive.Text & "'"
                        strLog = strLog & " ,BackDriver = " & txtbdriver.Text

                    End If
                ElseIf txtsts.Text = "sover" Then
                    If cbotripback.Text = txtbtrip.Text Then
                    Else
                        strSql = strSql & " sotrip=" & cbotripback.SelectedIndex
                        strLog = strLog & " ,sotrip=" & txtbtrip.Text
                        wit = True
                    End If
                    If cboruteback.Text = txtbrute.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " sorute=" & cboruteback.SelectedIndex
                        strLog = strLog & " ,sorute=" & txtbrute.Text
                        wit = True
                    End If
                    If txtbackdate.Text = txtbdate.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " sodate='" & Str2Date(txtbackdate.Text) & "'"
                        strLog = strLog & " ,sodate= " & Str2Date(txtbackdate.Text)
                        wit = True
                    End If
                    If cboBackArea.Text = txtbarea.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " soArea='" & cboBackArea.SelectedIndex & "'"
                        strLog = strLog & " ,soarea = " & cboBackArea.Text
                        wit = True
                    End If
                    If txtPickupBack.Text = txtblokasi.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " soPickup='" & txtPickupBack.Text & "'"
                        strLog = strLog & " ,soPickup = " & txtblokasi.Text
                        wit = True
                    End If
                    If txtbackDrive.Text = txtbdriver.Text Then
                    Else
                        If wit = True Then
                            strSql = strSql & ", "
                        End If
                        strSql = strSql & " soDriver='" & txtbackDrive.Text & "'"
                        strLog = strLog & " ,soDriver = " & txtbdriver.Text

                    End If
                Else
                    Exit Sub
                End If
                Call ConnectDatabase()
                strSqlc = "update tiketdtl set " & strSql & " where NoEtiket='" & LsData.CurrentRow.Cells(1).Value & "' and notiket='" & txttiket.Text & "'"
                Dim Comd As MySqlCommand = New MySqlCommand(strSqlc, conn)
                Comd.ExecuteNonQuery()

                Call DisconnectDatabase()
                strLog = "Update No Etiket='" & txtetiket.Text & "' and NoTiket='" & txttiket.Text & "' for " & strLog
                strLog = Replace(strLog, "'", " ")
                strSql = Replace(strSql, "'", " ")
                FillLog(usr, "Update Tiket:", " No.ETiket : " & txtetiket.Text & " and NoTiket=" & txttiket.Text, strLog, strSql & " where NoEtiket=" & LsData.CurrentRow.Cells(1).Value & " and notiket=" & txttiket.Text & "")
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub txtbackdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbackdate.ValueChanged
        txtbackdate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtdate.CustomFormat = " "
        txtdate.Format = DateTimePickerFormat.Custom
    End Sub
End Class