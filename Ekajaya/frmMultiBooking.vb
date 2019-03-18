Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmMultiBooking
    Public list As String
    Dim strSql, ruteg, ruteb, tripg, tripb, dateg, dateb, locg, locb, drg, drb As String
    Dim areab, areag As Integer
    Dim surchargeg, surchargeb As String
    Dim valida, validb As String
    Sub valid(ByVal dates As String, ByVal rutes As Integer, ByVal stx As String)
        If stx = "Go" Then
            If dates = "" Then
                MsgBox("Depart Date is empty, Please fill Depart Date", vbInformation, "Error Booking")
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select RateID from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & rutes & " and StartDate<='" & Str2Date(dates) & "' and Enddate>='" & Str2Date(dates) & "'"
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
            If dates = " " Then
                Exit Sub
            End If
            Call ConnectDatabase()
            Try

                Dim strSql As String
                strSql = "select RateID from `agentratedtl` where AgentID='" & txtagentid.Text & "' and RuteID=" & rutes & " and StartDate<='" & Str2Date(dates) & "' and Enddate>='" & Str2Date(dates) & "'"
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
    Sub filldata()

        Call ConnectDatabase()
        Try

            strSql = "SELECT tiketdtl.AgentID, tiketdtl.GoTrip, tiketdtl.BackTrans, tiketdtl.BackArea, tiketdtl.BackPickup, tiketdtl.BackDriver, tiketdtl.GoRuteID, tiketdtl.GoDate, tiketdtl.GoTrans, tiketdtl.GoArea, tiketdtl.GoPickUp, tiketdtl.GoDriver, tiketdtl.BackRuteID,tiketdtl.BackDate, tiketdtl.TripBack FROM tiketdtl WHERE (" & list & ") GROUP BY tiketdtl.AgentID, tiketdtl.GoTrip, tiketdtl.BackTrans, tiketdtl.BackArea, tiketdtl.BackPickup, tiketdtl.BackDriver, tiketdtl.GoRuteID, tiketdtl.GoDate, tiketdtl.GoTrans, tiketdtl.GoArea, tiketdtl.GoPickUp, tiketdtl.GoDriver, tiketdtl.BackRuteID, tiketdtl.BackDate, tiketdtl.TripBack;"
            Dim ComdX As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim readerX As MySqlDataReader = ComdX.ExecuteReader
            While (readerX.Read)
                txtaid.Text = readerX("AgentID").ToString
                txtagentid.Text = readerX("AgentID").ToString
                ruteg = readerX("GoRuteID").ToString
                ruteb = readerX("BackRuteID").ToString
                tripg = readerX("gotrip").ToString
                cboGotrip.SelectedIndex = readerX("gotrip").ToString
                If IsDBNull(readerX("TripBack").ToString) Or (readerX("TripBack").ToString = "") Then
                Else
                    tripb = readerX("TripBack").ToString
                    cbotripback.SelectedIndex = readerX("TRIPBACK").ToString
                End If
                cboBackArea.SelectedIndex = Val(readerX("BackArea").ToString)
                cboGoArea.SelectedIndex = Val(readerX("GoArea").ToString)
                areag = Val(readerX("GoArea").ToString)
                areab = Val(readerX("BackArea").ToString)
                txtpickupgo.Text = readerX("GoPickup").ToString
                locg = txtpickupgo.Text
                txtPickupBack.Text = readerX("BackPickup").ToString
                locb = txtPickupBack.Text
                txtbackDrive.Text = readerX("BackDriver").ToString
                drb = txtbackDrive.Text
                txtdrivego.Text = readerX("GoDriver").ToString
                drg = txtdrivego.Text
                txtgodate.Format = DateFormat.ShortDate
                txtgodate.Text = readerX("gODATE").ToString
                dateg = txtgodate.Text
                If IsDBNull(readerX("BACKDATE").ToString) Or (readerX("BACKDATE").ToString = "") Then
                    txtbackdate.Text = ""
                    dateb = txtbackdate.Text
                Else
                    txtbackdate.Format = DateFormat.ShortDate
                    txtbackdate.Text = readerX("BACKDATE").ToString
                    dateb = txtbackdate.Text
                End If
                
            End While
            
            Call DisconnectDatabase()
            cboGorute.Text = ruteg & " - " & GetField("RuteName", "rute", "RuteID=" & ruteg)
            cboruteback.Text = ruteb & " - " & GetField("RuteName", "rute", "RuteID=" & ruteb)
            txtagent.Text = GetField("AgentName", "agent", "AgentID='" & txtaid.Text & "'")
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub

    Private Sub frmMultiBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillarea()
        fillRute()
        filltrip()
        txtgodate.CustomFormat = " "
        txtgodate.Format = DateTimePickerFormat.Custom
        txtbackdate.CustomFormat = " "
        txtbackdate.Format = DateTimePickerFormat.Custom
        filldata()

    End Sub

    
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Sub returnt()
        Dim adlg
        Dim chdg
        Dim Infg
        Dim focg
        Dim surg
        Dim adlb
        Dim chdb
        Dim Infb
        Dim focb
        Dim surb
        Dim ttls
        Dim komisi
        Dim sisa
        Dim rtgo = cboGorute.Text.Split(New Char() {" - "})
        Dim rtbk = cboruteback.Text.Split(New Char() {" - "})
        Dim list = txtlist.Text.Split(New Char() {"|"})
        Dim upd, slog, Uupd, Uslog As String
        upd = ""
        slog = ""
        Dim agc As Boolean = False
        Dim rtgc As Boolean = False
        Dim rtbc As Boolean = False
        Dim gtripc As Boolean = False
        Dim btripc As Boolean = False
        Dim gdtc As Boolean = False
        Dim bdtc As Boolean = False
        If txtagentid.Text = txtaid.Text Then
        Else
            upd = " AgentID='" & txtagentid.Text & "'"
            slog = " AgentID = '" & txtaid.Text & "' "
            agc = True
        End If
        If rtgo(0) = ruteg Then
        Else
            rtgc = True

            If upd <> "" Then
                upd = upd & " ,GoRuteID=" & rtgo(0)
                slog = slog & " ,GoRuteID = " & ruteg
            Else
                upd = " GoRuteID=" & rtgo(0)
                slog = " GoRuteID = " & ruteg
            End If
        End If
        If cboruteback.Text <> "" Then

            If rtbk(0) = ruteb Then
            Else
                rtbc = True

                If upd <> "" Then
                    upd = upd & " ,BackRuteID=" & rtbk(0)
                    slog = slog & " ,BackRuteID= " & ruteb
                Else
                    upd = " BackRuteID=" & rtbk(0)
                    slog = " BackRuteID = " & ruteb
                End If
            End If
        End If
        If cboGotrip.SelectedIndex = tripg Then
        Else

            If upd <> "" Then
                upd = upd & " , gotrip=" & cboGotrip.SelectedIndex
                slog = slog & " ,gotrip = " & tripg
            Else
                upd = " gotrip=" & cboGotrip.SelectedIndex
                slog = " gotrip = " & tripg
            End If
        End If
        If cbotripback.Text <> "" Then

            If cbotripback.SelectedIndex = tripb Then
            Else
                If upd <> "" Then
                    upd = upd & " ,TripBack=" & cbotripback.SelectedIndex
                    slog = slog & " ,TripBack  = " & tripb
                Else
                    upd = " TripBack=" & cbotripback.SelectedIndex
                    slog = " TripBack  = " & tripb
                End If
            End If
        End If
        If txtgodate.Text = dateg Then
        Else
            gdtc = True
            If upd <> "" Then
                upd = upd & " , GoDate=" & Str2Date(txtgodate.Text)
                slog = slog & " ,GoDate = " & dateg
            Else
                slog = " GoDate = " & dateg
                upd = " GoDate=" & Str2Date(txtgodate.Text)
            End If
        End If
        If txtbackdate.Text <> "" Then

            If txtbackdate.Text = dateb Then
            Else
                bdtc = True

                If upd <> "" Then
                    upd = upd & " ,BACKDATE='" & Str2Date(txtbackdate.Text) & "'"
                    slog = slog & " ,BACKDATE = " & dateb
                Else
                    upd = " BACKDATE='" & Str2Date(txtbackdate.Text) & "'"
                    slog = " BACKDATE = " & dateb
                End If
            End If
        End If
        If cboGoArea.SelectedIndex = areag Then
        Else
            If upd <> "" Then
                upd = upd & " , goArea=" & cboGoArea.SelectedIndex
                slog = slog & " ,goArea = " & areag
            Else
                upd = "  goArea=" & cboGoArea.SelectedIndex
                slog = " goArea = " & areag
            End If
        End If
        If cboBackArea.Text <> "" Then

            If cboBackArea.SelectedIndex = areab Then
            Else
                If upd <> "" Then
                    upd = upd & " , BackArea=" & cboBackArea.SelectedIndex
                    slog = slog & " ,BackArea = " & areab
                Else
                    upd = " BackArea=" & cboBackArea.SelectedIndex
                    slog = " BackArea = " & areab
                End If
            End If
        End If
        If txtpickupgo.Text = locg Then
        Else
            If upd <> "" Then
                'upd = upd & " , GoPickUp='" & txtpickupgo.Text & "'"
                upd = upd & " , GoPickUp=@gopick"
                slog = slog & " ,GoPickUp = " & locg
            Else
                'upd = " GoPickUp='" & txtpickupgo.Text & "'"
                upd = "  GoPickUp=@gopick"
                slog = " GoPickUp = " & locg
            End If
        End If
        If txtPickupBack.Text = locb Then
        Else
            If upd <> "" Then
                'upd = upd & " , BackPickup='" & txtPickupBack.Text & "'"
                upd = upd & " , BackPickup=@backpick"
                slog = slog & " ,BackPickup = " & locb
            Else
                'upd = " BackPickup='" & txtPickupBack.Text & "'"
                upd = "  BackPickup=@backpick"
                slog = " BackPickup = " & locb
            End If
        End If
        If txtdrivego.Text = drg Then
        Else
            If upd <> "" Then
                'upd = upd & " , GoDriver='" & txtdrivego.Text & "'"
                upd = upd & " , GoDriver=@godrv"
                slog = slog & " GoDriver = " & drg
            Else
                upd = upd & " , GoDriver=@godrv"
                'upd = " GoDriver='" & txtdrivego.Text & "'"
                slog = slog & " GoDriver = " & drg
            End If
        End If
        If txtbackDrive.Text = drb Then
        Else
            If upd <> "" Then
                'upd = upd & " , BackDriver='" & txtbackDrive.Text & "'"
                upd = upd & " , BackDriver=@backdrv"
                slog = slog & " ,BackDriver = " & drb
            Else
                upd = upd & " , BackDriver=@backdrv"
                'upd = " BackDriver='" & txtbackDrive.Text & "'"
                slog = " BackDriver = " & drb
            End If
        End If


        For Each n As String In list
            If agc = True Or rtgc = True Or rtbc = True Or gdtc = True Or bdtc = True Then
                valid(txtgodate.Text, rtgo(0), "Go")
                If valida <> "" Then
                    adlg = GetField("Adult", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    chdg = GetField("Child", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    Infg = GetField("Inf", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    focg = GetField("FOC", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")

                    surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
                    If surchargeg <> "" Then
                        surg = GetField("Surcharge", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    Else
                        surg = 0
                    End If
                Else
                    adlg = GetField("Adult", "rute", "RuteID=" & rtgo(0) & " ")
                    chdg = GetField("Child", "rute", "RuteID=" & rtgo(0) & " ")
                    Infg = GetField("Inf", "rute", "RuteID=" & rtgo(0) & " ")
                    focg = GetField("FOC", "rute", "RuteID=" & rtgo(0) & "  ")
                    surg = 0
                End If
                If txtbackdate.Text <> " " Then
                    valid(txtbackdate.Text, rtbk(0), "Back")
                Else
                    valid(txtgodate.Text, rtbk(0), "Back")
                End If
                If validb <> "" Then

                    adlb = GetField("Adult", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    chdb = GetField("Child", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    Infb = GetField("Inf", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    focb = GetField("FOC", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                    If txtbackdate.Text <> "" Then
                        surcharge(txtbackdate.Value.Day, txtbackdate.Value.Month, "Back")
                        If surchargeb <> "" Then
                            surb = GetField("Surcharge", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                        Else
                            surb = 0
                        End If
                    Else
                        surb = 0
                    End If
                Else
                    adlb = GetField("Adult", "rute", "RuteID=" & rtgo(0) & " ")
                    chdb = GetField("Child", "rute", "RuteID=" & rtgo(0) & " ")
                    Infb = GetField("Inf", "rute", "RuteID=" & rtgo(0) & " ")
                    focb = GetField("FOC", "rute", "RuteID=" & rtgo(0) & "  ")
                    surb = 0
                End If
                Dim sst = GetField("QtyTIpe", "tiketdtl", "NoEtiket='" & n.ToString & "'")
                Dim tt = GetField("Qty", "tiketdtl", "NoEtiket='" & n.ToString & "'")
                Dim cl = GetField("TotalCollect", "tiketdtl", "NoEtiket='" & n.ToString & "'")

                Select Case sst
                    Case 1
                        If upd <> "" Then
                            ttls = adlg + surg + adlb + surb + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                            komisi = NZx(cl) - ttls

                            If (ttls - NZx(cl)) > 0 Then
                                sisa = ttls - NZx(cl)
                            Else
                                sisa = 0
                            End If
                            upd = upd & " , Gorate=" & adlg & ", goextra= " & surg & ", backrate= " & adlb & ", backextra=" & surb & ", TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "


                        End If

                    Case 2
                        If upd <> "" Then
                            ttls = chdg + surg + chdb + surb + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                            komisi = NZx(cl) - ttls

                            If (ttls - NZx(cl)) > 0 Then
                                sisa = ttls - NZx(cl)
                            Else
                                sisa = 0
                            End If
                            upd = upd & " , Gorate=" & chdg & ", goextra= " & surg & ", backrate= " & chdb & ", backextra=" & surb & ", TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "


                        End If
                    Case 3
                        If upd <> "" Then
                            ttls = Infg + surg + Infb + surb + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                            komisi = NZx(cl) - ttls

                            If (ttls - NZx(cl)) > 0 Then
                                sisa = ttls - NZx(cl)
                            Else
                                sisa = 0
                            End If
                            upd = upd & " , Gorate=" & Infg & ", goextra= " & surg & ", backrate =" & Infb & ", backextra=" & surb & ", TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "


                        End If
                    Case 4
                        If upd <> "" Then
                            ttls = focg + surg + focb + surb + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("backtransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                            komisi = NZx(cl) - ttls

                            If (ttls - cl) > 0 Then
                                sisa = ttls - NZx(cl)
                            Else
                                sisa = 0
                            End If
                            upd = upd & " , Gorate=" & focg & ", goextra= " & surg & ", backrate= " & focb & ", backextra=" & surb & ", TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "


                        End If
                End Select


                Call ConnectDatabase()
                Dim cmd As MySqlCommand
                Dim strsql As String

                strsql = "update tiketdtl set " & upd & " where NoEtiket='" & n.ToString & "' "

                cmd = New MySqlCommand(strsql, conn)
                cmd.Parameters.AddWithValue("@gopick", txtpickupgo.Text)
                cmd.Parameters.AddWithValue("@backpick", txtPickupBack.Text)
                cmd.Parameters.AddWithValue("@godrv", txtdrivego.Text)
                cmd.Parameters.AddWithValue("@backdrv", txtbackDrive.Text)
                cmd.ExecuteScalar()
                Uslog = Replace(slog, "'", " ")
                Uupd = Replace(upd, "'", " ")
                FillLog(usr, "EDIT Ticket", "  No.Etiket : " & n.ToString, Uslog, Uupd)
                'Me.Close()
                Call DisconnectDatabase()
            Else
                If upd = "" Then
                Else

                    Call ConnectDatabase()
                    Dim cmd As MySqlCommand
                    Dim strsql As String

                    strsql = "update tiketdtl set " & upd & " where NoEtiket='" & n.ToString & "' "

                    cmd = New MySqlCommand(strsql, conn)
                    cmd.Parameters.AddWithValue("@gopick", txtpickupgo.Text)
                    cmd.Parameters.AddWithValue("@backpick", txtPickupBack.Text)
                    cmd.Parameters.AddWithValue("@godrv", txtdrivego.Text)
                    cmd.Parameters.AddWithValue("@backdrv", txtbackDrive.Text)
                    cmd.ExecuteScalar()
                    Uslog = Replace(slog, "'", " ")
                    Uupd = Replace(upd, "'", " ")
                    FillLog(usr, "EDIT Ticket", "  No.Etiket : " & n.ToString, Uslog, Uupd)
                    'Me.Close()
                    Call DisconnectDatabase()
                End If
            End If
        Next
    End Sub
    Sub onew()
        Dim adlg
        Dim chdg
        Dim Infg
        Dim focg
        Dim surg
        
        Dim ttls As Double
        Dim komisi
        Dim sisa
        Dim rtgo = cboGorute.Text.Split(New Char() {" - "})
        Dim rtbk = cboruteback.Text.Split(New Char() {" - "})
        Dim list = txtlist.Text.Split(New Char() {"|"})
        Dim upd, slog, Uupd, Uslog As String
        upd = ""
        slog = ""
        Dim agc As Boolean = False
        Dim rtgc As Boolean = False
        Dim rtbc As Boolean = False
        Dim gtripc As Boolean = False
        Dim btripc As Boolean = False
        Dim gdtc As Boolean = False
        Dim bdtc As Boolean = False
        If txtagentid.Text = txtaid.Text Then
        Else
            upd = " AgentID='" & txtagentid.Text & "'"
            slog = " AgentID = '" & txtaid.Text & "' "
            agc = True
        End If
        If rtgo(0) = ruteg Then
        Else
            rtgc = True

            If upd <> "" Then
                upd = upd & " ,GoRuteID=" & rtgo(0)
                slog = slog & " ,GoRuteID = " & ruteg
            Else
                upd = " GoRuteID=" & rtgo(0)
                slog = " GoRuteID = " & ruteg
            End If
        End If
        If cboruteback.Text <> "" Then

            If rtbk(0) = ruteb Then
            Else
                rtbc = True

                If upd <> "" Then
                    upd = upd & " ,BackRuteID=null"
                    slog = slog & " ,BackRuteID=null "
                Else
                    upd = " BackRuteID=null"
                    slog = " BackRuteID =null "
                End If
            End If
        Else
            rtbc = False
            If upd <> "" Then
                upd = upd & " ,BackRuteID=null"
                slog = slog & " ,BackRuteID=null "
            Else
                upd = " BackRuteID=null"
                slog = " BackRuteID =null "
            End If
        End If
        If cboGotrip.SelectedIndex = tripg Then
        Else

            If upd <> "" Then
                upd = upd & " , gotrip=" & cboGotrip.SelectedIndex
                slog = slog & " ,gotrip = " & tripg
            Else
                upd = " gotrip=" & cboGotrip.SelectedIndex
                slog = " gotrip = " & tripg
            End If
        End If
        If cbotripback.Text <> "" Then

            If cbotripback.SelectedIndex = tripb Then
            Else
                If upd <> "" Then
                    upd = upd & " ,TripBack=null"
                    slog = slog & " ,TripBack  =null "
                Else
                    upd = " TripBack=null "
                    slog = " TripBack  =null "
                End If
            End If
        Else
            
            If upd <> "" Then
                upd = upd & " ,TripBack=null"
                slog = slog & " ,TripBack  =null "
            Else
                upd = " TripBack=null "
                slog = " TripBack  =null "
            End If
        End If
        If txtgodate.Text = dateg Then
        Else
            gdtc = True
            If upd <> "" Then
                upd = upd & " , GoDate=" & Str2Date(txtgodate.Text)
                slog = slog & " ,GoDate = " & dateg
            Else
                slog = " GoDate = " & dateg
                upd = " GoDate=" & Str2Date(txtgodate.Text)
            End If
        End If
        If txtbackdate.Text <> "" Then

            If txtbackdate.Text = dateb Then
            Else
                bdtc = True

                If upd <> "" Then
                    upd = upd & " ,BACKDATE=null"
                    slog = slog & " ,BACKDATE = null"
                Else
                    upd = " BACKDATE=null"
                    slog = " BACKDATE = null"
                End If
            End If
        Else
            bdtc = False

            If upd <> "" Then
                upd = upd & " ,BACKDATE=null"
                slog = slog & " ,BACKDATE = null"
            Else
                upd = " BACKDATE=null"
                slog = " BACKDATE = null"
            End If
        End If
        If cboGoArea.SelectedIndex = areag Then
        Else
            If upd <> "" Then
                upd = upd & " , goArea=" & cboGoArea.SelectedIndex
                slog = slog & " ,goArea = " & areag
            Else
                upd = "  goArea=" & cboGoArea.SelectedIndex
                slog = " goArea = " & areag
            End If
        End If
        If cboBackArea.Text <> "" Then

            If cboBackArea.SelectedIndex = areab Then
            Else
                If upd <> "" Then
                    upd = upd & " , BackArea=null"
                    slog = slog & " ,BackArea =null "
                Else
                    upd = " BackArea=null"
                    slog = " BackArea =null "
                End If
            End If
        Else
            If upd <> "" Then
                upd = upd & " , BackArea=null"
                slog = slog & " ,BackArea =null "
            Else
                upd = " BackArea=null"
                slog = " BackArea =null "
            End If
        End If
        If txtpickupgo.Text = locg Then
        Else
            If upd <> "" Then
                'upd = upd & " , GoPickUp='" & txtpickupgo.Text & "'"
                upd = upd & " , GoPickUp=@gopick"
                slog = slog & " ,GoPickUp = " & locg
            Else
                'upd = " GoPickUp='" & txtpickupgo.Text & "'"
                upd = "  GoPickUp=@gopick"
                slog = " GoPickUp = " & locg
            End If
        End If
        If txtPickupBack.Text = locb Then
        Else
            If upd <> "" Then
                'upd = upd & " , BackPickup='" & txtPickupBack.Text & "'"
                upd = upd & " , BackPickup=''"
                slog = slog & " ,BackPickup ='' "
            Else
                'upd = " BackPickup='" & txtPickupBack.Text & "'"
                upd = "  BackPickup=''"
                slog = " BackPickup ='' "
            End If

        End If
        If txtdrivego.Text = drg Then
        Else
            If upd <> "" Then
                'upd = upd & " , GoDriver='" & txtdrivego.Text & "'"
                upd = upd & " , GoDriver=@godrv"
                slog = slog & " GoDriver = " & drg
            Else
                upd = upd & " , GoDriver=@godrv"
                'upd = " GoDriver='" & txtdrivego.Text & "'"
                slog = slog & " GoDriver = " & drg
            End If
        End If
        If txtbackDrive.Text = drb Then
        Else
            If upd <> "" Then
                'upd = upd & " , BackDriver='" & txtbackDrive.Text & "'"
                upd = upd & " , BackDriver=''"
                slog = slog & " ,BackDriver ='' "
            Else
                upd = upd & " , BackDriver=''"
                'upd = " BackDriver='" & txtbackDrive.Text & "'"
                slog = " BackDriver ='' "
            End If
        End If


        For Each n As String In list
            If agc = True Or rtgc = True Or rtbc = True Or gdtc = True Or bdtc = True Then
                valid(txtgodate.Text, rtgo(0), "Go")
                If valida <> "" Then
                    adlg = GetField("Adult", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    chdg = GetField("Child", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    Infg = GetField("Inf", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    focg = GetField("FOC", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")

                    surcharge(txtgodate.Value.Day, txtgodate.Value.Month, "Go")
                    If surchargeg <> "" Then
                        surg = GetField("Surcharge", "agentratedtl", "RuteID=" & rtgo(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & valida & "'")
                    Else
                        surg = 0
                    End If
                Else
                    adlg = GetField("Adult", "rute", "RuteID=" & rtgo(0) & " ")
                    chdg = GetField("Child", "rute", "RuteID=" & rtgo(0) & " ")
                    Infg = GetField("Inf", "rute", "RuteID=" & rtgo(0) & " ")
                    focg = GetField("FOC", "rute", "RuteID=" & rtgo(0) & "  ")
                    surg = 0
                End If
                'If txtbackdate.Text <> " " Then
                '    valid(txtbackdate.Text, rtbk(0), "Back")
                'Else
                '    valid(txtgodate.Text, rtbk(0), "Back")
                'End If
                'If validb <> "" Then

                '    adlb = GetField("Adult", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '    chdb = GetField("Child", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '    Infb = GetField("Inf", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '    focb = GetField("FOC", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '    If txtbackdate.Text <> "" Then
                '        surcharge(txtbackdate.Value.Day, txtbackdate.Value.Month, "Back")
                '        If surchargeb <> "" Then
                '            surb = GetField("Surcharge", "agentratedtl", "RuteID=" & rtbk(0) & " and AgentID='" & txtagentid.Text & "' and RateID='" & validb & "'")
                '        Else
                '            surb = 0
                '        End If
                '    Else
                '        surb = 0
                '    End If
                'Else
                '    adlb = GetField("Adult", "rute", "RuteID=" & rtgo(0) & " ")
                '    chdb = GetField("Child", "rute", "RuteID=" & rtgo(0) & " ")
                '    Infb = GetField("Inf", "rute", "RuteID=" & rtgo(0) & " ")
                '    focb = GetField("FOC", "rute", "RuteID=" & rtgo(0) & "  ")
                '    surb = 0
                'End If
                Dim sst = GetField("QtyTIpe", "tiketdtl", "NoEtiket='" & n.ToString & "'")
                Dim tt = GetField("Qty", "tiketdtl", "NoEtiket='" & n.ToString & "'")
                Dim cl = GetField("TotalCollect", "tiketdtl", "NoEtiket='" & n.ToString & "'")

                Select Case sst
                    Case 1
                        If upd <> "" Then
                            ttls = adlg + surg + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                            komisi = NZx(cl) - ttls

                            If (ttls - NZx(cl)) > 0 Then
                                sisa = ttls - NZx(cl)
                            Else
                                sisa = 0
                            End If
                            upd = upd & " , Gorate=" & adlg & ", goextra= " & surg & ", backrate=0 , backextra=0, TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "


                        End If

                    Case 2
                        If upd <> "" Then
                            ttls = chdg + surg + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                            komisi = NZx(cl) - ttls

                            If (ttls - NZx(cl)) > 0 Then
                                sisa = ttls - NZx(cl)
                            Else
                                sisa = 0
                            End If
                            upd = upd & " , Gorate=" & chdg & ", goextra= " & surg & ", backrate=0, backextra=0, TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "


                        End If
                    Case 3
                        If upd <> "" Then
                            ttls = Infg + surg + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                            komisi = NZx(cl) - ttls

                            If (ttls - NZx(cl)) > 0 Then
                                sisa = ttls - NZx(cl)
                            Else
                                sisa = 0
                            End If
                            upd = upd & " , Gorate=" & Infg & ", goextra= " & surg & ", backrate =0, backextra=0, TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "


                        End If
                    Case 4
                        If upd <> "" Then
                            ttls = focg + surg + NZx(GetField("gotranrate", "tiketdtl", "NoEtiket='" & n.ToString & "'")) + NZx(GetField("gotransextra", "tiketdtl", "NoEtiket='" & n.ToString & "'"))
                            komisi = NZx(cl) - ttls

                            If (ttls - cl) > 0 Then
                                sisa = ttls - NZx(cl)
                            Else
                                sisa = 0
                            End If
                            upd = upd & " , Gorate=" & focg & ", goextra= " & surg & ", backrate=0, backextra=0, TotalJual=" & ttls & ", komisi =" & komisi & ", sisa=" & sisa & " "


                        End If
                End Select


                Call ConnectDatabase()
                Dim cmd As MySqlCommand
                Dim strsql As String

                strsql = "update tiketdtl set " & upd & ",babacktransrate=0, backtransextra=0 where NoEtiket='" & n.ToString & "' "

                cmd = New MySqlCommand(strsql, conn)
                cmd.Parameters.AddWithValue("@gopick", txtpickupgo.Text)
                'cmd.Parameters.AddWithValue("@backpick", txtPickupBack.Text)
                cmd.Parameters.AddWithValue("@godrv", txtdrivego.Text)
                'cmd.Parameters.AddWithValue("@backdrv", txtbackDrive.Text)
                cmd.ExecuteScalar()
                Uslog = Replace(slog, "'", " ")
                Uupd = Replace(upd, "'", " ")
                FillLog(usr, "EDIT Ticket", "  No.Etiket : " & n.ToString, Uslog, Uupd)
                'Me.Close()
                Call DisconnectDatabase()
            Else
                If upd = "" Then
                Else

                    Call ConnectDatabase()
                    Dim cmd As MySqlCommand
                    Dim strsql As String

                    strsql = "update tiketdtl set " & upd & " where NoEtiket='" & n.ToString & "' "

                    cmd = New MySqlCommand(strsql, conn)
                    cmd.Parameters.AddWithValue("@gopick", txtpickupgo.Text)
                    'cmd.Parameters.AddWithValue("@backpick", txtPickupBack.Text)
                    cmd.Parameters.AddWithValue("@godrv", txtdrivego.Text)
                    'cmd.Parameters.AddWithValue("@backdrv", txtbackDrive.Text)
                    cmd.ExecuteScalar()
                    Uslog = Replace(slog, "'", " ")
                    Uupd = Replace(upd, "'", " ")
                    FillLog(usr, "EDIT Ticket", "  No.Etiket : " & n.ToString, Uslog, Uupd)
                    'Me.Close()
                    Call DisconnectDatabase()
                End If
            End If
        Next
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If MsgBox("Are you sure tu update data??", vbYesNo, "Update Data") = vbNo Then
            Exit Sub
        Else
            If cbotipe.Text = "OW - One Way" Then
                onew()
            Else
                returnt()
            End If
        End If

        Me.Close()
    End Sub

    Private Sub cmdAgent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgent.Click
        frmagentlist.Show()
        frmagentlist.forms = "mBooking"
        Me.Hide()
    End Sub

    Private Sub cbotipe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotipe.SelectedIndexChanged
        If Mid(cbotipe.Text, 1, 2) = "RT" Then
            GroupBox4.Enabled = True
            'GroupBox6.Enabled = True
        Else
            GroupBox4.Enabled = False
            CxBackTrans.Checked = False
            'txtbackExtra.Text = ""
            'txtexback.Text = ""
            'txttransbackrate.Text = ""
            cboBackArea.Text = ""
            cboruteback.Text = ""
            cbotripback.Text = ""
            'txtbackrate.Text = ""
            'txtbackExtra.Text = ""
            txtPickupBack.Text = ""
            txtbackDrive.Text = ""
            txtbackdate.CustomFormat = " "
            txtbackdate.Format = DateTimePickerFormat.Custom
            'GroupBox6.Enabled = False
        End If
    End Sub
End Class