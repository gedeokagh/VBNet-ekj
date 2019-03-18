Imports MySql.Data.MySqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmTourOrdeEdit
    Dim oagent, otour, oqtipe, oname, oidtipe, oidno, oguest, oremark, odate1, odate2, orute1, orute2, otrip1, otrip2, oarea1, oarea2, orate1, opick1, opick2, ototal, oqty, ocollect
    Sub filltour()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select TourID,TourName from tour ", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("TourID") = 0
        dr("TourName") = ""
        dt.Rows.InsertAt(dr, 0)
        cbotour.DataSource = dt
        cbotour.DisplayMember = "TourName"

        Call DisconnectDatabase()
    End Sub

    Sub fillarea()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select areaID,Areaname from area ", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("areaid") = 0
        dr("areaname") = ""
        dt.Rows.InsertAt(dr, 0)
        cboGoArea.DataSource = dt
        cboGoArea.DisplayMember = "areaname"

        Call DisconnectDatabase()
    End Sub
    Sub filldata()

        Call ConnectDatabase()
        Dim strSql As String = "select * from tiketdtl where Noetiket='" & txtetiket.Text & "'"
        Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
        Dim reader As MySqlDataReader = Comd.ExecuteReader
        Dim AREAID As Integer = 0
        While (reader.Read)
            txtnobook.Text = reader("NoBook").ToString()
            txtnoID.Text = reader("GuestIDNO").ToString()
            oidno = reader("GuestIDNO").ToString()
            cbotipeID.Text = reader("GuestID").ToString()
            oidtipe = ", GuestTYPEID= " & cbotipeID.Text
            Dim DEPART As String = reader("GoDate").ToString()
            txtgodate.Format = DateTimePickerFormat.Custom
            txtgodate.CustomFormat = "dd/MM/yyyy"
            odate1 = ", goDate= " & txtgodate.Text
            odate2 = ", Backdate= " & txtgodate.Text
            txtgodate.Text = DEPART
            txtagentid.Text = reader("AgentID").ToString()
            oagent = ", AgentID= " & txtagentid.Text
            txtbackruteid.Text = reader("BackRuteID").ToString()
            orute2 = ", BackRuteID= " & txtbackruteid.Text
            txtbacktripID.Text = reader("TripBack").ToString()
            otrip2 = ", BackTripID= " & txtbackruteid.Text
            txtcollect.Text = reader("ReqCollect").ToString()
            ocollect = ", ReqCollect= " & txtcollect.Text
            txtgoruteid.Text = reader("GoRuteID").ToString()
            orute1 = ", GoRuteID= " & txtgoruteid.Text
            txtgotripid.Text = reader("GoTrip").ToString()
            otrip1 = ", GotripID= " & txtgotripid.Text
            txtguest.Text = reader("Guest").ToString()
            oname = ", Name= " & txtguest.Text
            txtpickupgo.Text = reader("GoPickUp").ToString()
            opick1 = ", GoPickup= " & txtpickupgo.Text
            opick2 = ", BackPickup= " & txtpickupgo.Text
            txtremark.Text = reader("remark").ToString()
            oremark = ", Remark= " & txtremark.Text
            txttprice.Text = reader("gorate").ToString()
            ototal = ", Total= " & txttprice.Text

            AREAID = reader("GoArea").ToString()
            oarea1 = ", GoArea= " & AREAID
            oarea2 = ", BackArea= " & AREAID
            Select Case reader("QtyTipe").ToString()
                Case "1"
                    cboGst.Text = "1 - Adult"
                Case "2"
                    cboGst.Text = "2 - Child"
                Case "3"
                    cboGst.Text = "3 - Infan"
                Case "4"
                    cboGst.Text = "4 - FOC"
            End Select
            oqtipe = ", QtyTipe= " & reader("QtyTipe").ToString()
        End While
        reader.Close()
        Call DisconnectDatabase()
        txtgorute.Text = GetField("RuteName", "rute", "RuteID='" & txtgoruteid.Text & "'")

        txtbackrute.Text = GetField("RuteName", "rute", "RuteID='" & txtbacktripID.Text & "'")
        txtgotrip.Text = GetField("TripName", "Trip", "TripID='" & txtgotripid.Text & "'")
        txtbacktrip.Text = GetField("TripName", "Trip", "TripID='" & txtbacktripID.Text & "'")
        txtagent.Text = GetField("agentname", "agent", "agentID='" & txtagentid.Text & "'")
        oagent = " ,Agent=" & txtagentid.Text & " "
        cboGoArea.Text = GetField("areaname", "area", "areaid='" & AREAID & "'")
        otour = " , TourID=" & GetField("TourID", "tourorder", "OrderID='" & txtnobook.Text & "'")
        cbotour.Text = GetField("TourName", "tour", "TourID='" & GetField("TourID", "tourorder", "OrderID='" & txtnobook.Text & "'") & "'")
    End Sub

    Private Sub frmTourOrdeEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillarea()
        filltour()
        filldata()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim agent, tipe, name, idtipe, idno, guest, remark, date1, date2, rute1, rute2, trip1, trip2, area1, area2, rate1, pick1, pick2, total, colls, komis, sis As String
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
        If Trim(txtgodate.Text) = "" Then
            MsgBox("Please Fill Departure Date!", vbInformation, "Ticket Error")
            Exit Sub
        Else
            date1 = ",GoDate='" & Str2Date(txtgodate.Text) & "'"
            date2 = ",BackDate='" & Str2Date(txtgodate.Text) & "'"
        End If

        If txtguest.Text = "" Then
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
            MsgBox("Please Fill Guest Age's", vbInformation, "ErrorEdit")
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

        If txttprice.Text = "" Then
            rate1 = ", Gorate=0"
        Else
            rate1 = ", Gorate=" & txttprice.Text
        End If
        If txtpickupgo.Text = "" Then
            pick1 = ""
            pick2 = ""
        Else
            'pick1 = ", GoPickUp='" & txtpickupgo.Text & "'"
            pick1 = ", GoPickUp=@gopick"
            pick2 = ", BackPickUp=@gopick"
        End If

        Dim rutesb As String = txtbackruteid.Text
        Dim rutesbs = rutesb.Split(New Char() {" - "})
        'rute2 = ",BackRuteID=" & cboruteback.SelectedItem("RuteID").ToString
        rute2 = ",BackRuteID=" & NZx(rutesbs(0))
        Dim rutesa As String = txtgoruteid.Text
        Dim rutesas = rutesa.Split(New Char() {" - "})
        'rute2 = ",BackRuteID=" & cboruteback.SelectedItem("RuteID").ToString
        rute1 = ", GoRuteID=" & NZx(rutesas(0))
        'rute1 = ", GoRuteID =" & cboGorute.SelectedItem("RuteID").ToString

        trip1 = ", GoTrip=" & NZx(txtgotripid.Text) & " "

        trip2 = ", TripBack=" & NZx(txtbacktripID) & ""
        If cboGoArea.Text = "" Then
            area1 = ""
            area2 = ""
        Else
            area1 = ", GoArea=" & cboGoArea.SelectedItem("AreaID").ToString
            area2 = ", BackArea=" & cboGoArea.SelectedItem("AreaID").ToString
        End If
        Dim totals As Double = Val(txttprice.Text)
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

        strsql = "UPDATE tiketdtl set NoTiket='" & txttiket.Text & "'" & agent & tipe & name & idtipe & idno & remark & date1 & date2 & rute1 & rute2 & trip1 & trip2 & area1 & area2 & rate1 & pick1 & pick2 & total & colls & komis & sis & guest & " where NoETiket='" & txtetiket.Text & "'"

        cmd = New MySqlCommand(strsql, conn)
        cmd.Parameters.AddWithValue("@name", txtguest.Text)
        cmd.Parameters.AddWithValue("@gopick", txtpickupgo.Text)
        cmd.Parameters.AddWithValue("@backpick", txtpickupgo.Text)
        cmd.Parameters.AddWithValue("@remark", txtremark.Text)
        cmd.ExecuteScalar()
        Call DisconnectDatabase()
        Dim Oldv = oagent & oname & oidtipe & oidno & oguest & oremark & odate1 & odate2 & orute1 & orute2 & otrip1 & otrip2 & oarea1 & oarea2 & orate1 & opick1 & opick2 & otour & ototal & oqtipe
        Oldv = Replace(Oldv, "'", " ")
        Dim newval = "NoTiket=" & txttiket.Text & "," & agent & tipe & ", nAME=" & txtguest.Text & ", " & idtipe & idno & ", remark=" & txtremark.Text & ", " & date1 & date2 & rute1 & rute2 & trip1 & trip2 & area1 & area2 & rate1 & ",gOpICKUP " & txtpickupgo.Text & ", bACKpICKUP" & txtpickupgo.Text & ",  " & total & colls & komis & sis & guest & " where NoETiket='" & txtetiket.Text & "'"
        newval = Replace(newval, "'", " ")
        FillLog(usr, "EDIT Ticket", " No. : " & txttiket.Text & " | No.Etiket : " & txtetiket.Text, Oldv, newval)
        Me.Close()



    End Sub
End Class