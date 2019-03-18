Imports MySql.Data.MySqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmTourOrder
    Sub NoRate()
        Dim x = cxField("OrderID", "tourorder", "OrderID like 'EKT/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-%'")
        If x = 0 Then
            txtnobook.Text = "EKT/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-" & "000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("OrderID", "tourorder", "OrderID like 'EKT/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            txtnobook.Text = "EKT/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-" & numx(Lst, 6)
        End If

    End Sub
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
    Private Sub frmTourOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        filltour()
        fillarea()
        lsAgent.ColumnCount = 6
        lsAgent.Columns(0).HeaderText = "Guest Naame"
        lsAgent.Columns(1).HeaderText = "Age"
        lsAgent.Columns(2).HeaderText = "Area"
        lsAgent.Columns(3).HeaderText = "Pickup Location"
        lsAgent.Columns(4).HeaderText = "ID"
        lsAgent.Columns(5).HeaderText = "No. ID"
        lsAgent.AllowUserToAddRows = False
        lsAgent.AllowUserToDeleteRows = False
        lsAgent.AllowUserToOrderColumns = False
        txtgodate.Format = DateTimePickerFormat.Custom
        txtgodate.CustomFormat = "dd/MM/yyyy"
        TXTTGL.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub cbotour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotour.SelectedIndexChanged
        Dim strSql As String
        Call ConnectDatabase()
        strSql = "SELECT `tour`.`TourID` , `tour`.`TourName` , `tour`.`Gorute` , `tour`.`BackRute` , `tour`.`Gotrip` , `tour`.`BackTrip` , `rute`.`RuteName` AS DepartRute , `rute_1`.`RuteName` AS ReturnRute , `trip`.`TripName` AS DepartTrip , `trip_1`.`TripName` AS ReturnTrip  FROM `rute` INNER JOIN `tour` ON (`rute`.`RuteID` = `tour`.`Gorute`) INNER JOIN `rute` AS `rute_1` ON (`rute_1`.`RuteID` = `tour`.`BackRute`) INNER JOIN `trip` ON (`trip`.`TripID` = `tour`.`Gotrip`) INNER JOIN `trip` AS `trip_1` ON (`trip_1`.`TripID` = `tour`.`BackTrip`) where tourid='" & cbotour.SelectedItem("TourID").ToString & "' "
        Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
        Dim reader As MySqlDataReader

        reader = Comd.ExecuteReader
        While (reader.Read)
            txtgorute.Text = reader("DepartRute").ToString()
            txtgoruteid.Text = reader("Gorute").ToString()
            txtbackrute.Text = reader("ReturnRute").ToString()
            txtbackruteid.Text = reader("BackRute").ToString()
            txtgotrip.Text = reader("DepartTrip").ToString()
            txtgotripid.Text = reader("Gotrip").ToString()
            txtbacktrip.Text = reader("ReturnTrip").ToString()
            txtbacktripID.Text = reader("BackTrip").ToString()
        End While
        reader.Close()
        Call DisconnectDatabase()
        If txtagentid.Text = "" Then
        Else
            txttprice.Text = GetField("Price", "TOURprice", "tourid='" & cbotour.SelectedItem("TourID").ToString & "' and AgentID='" & txtagentid.Text & "'")
        End If
    End Sub

    Private Sub cmdAgLs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgLs.Click
        frmagentlist.Show()
        frmagentlist.forms = "tourorder"
    End Sub

    Private Sub txtagentid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtagentid.TextChanged
        txttprice.Text = GetField("Price", "TOURprice", "tourid='" & cbotour.SelectedItem("TourID").ToString & "' and AgentID='" & txtagentid.Text & "'")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cboadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboadd.Click
        lsAgent.Rows.Add(txtguest.Text, cboGst.Text, cboGoArea.SelectedItem("AreaID").ToString, txtpickupgo.Text, cbotipeID.Text, txtnoID.Text)
        txtguest.Text = ""
    End Sub

    Private Sub cboremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboremove.Click
        If lsAgent.Rows.Count = 0 Then
            Exit Sub
        End If
        lsAgent.Rows.RemoveAt(lsAgent.CurrentRow.Index)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If lsAgent.Rows.Count = 0 Then
            MsgBox("Guest List is Empty", vbInformation, "Error Guest")
            Exit Sub
        End If
        If txtagent.Text = "" Then
            MsgBox("Agent is Empty", vbInformation, "Error Agent")
            Exit Sub
        End If
        If cbotour.Text = "" Then
            MsgBox("Tour is Empty", vbInformation, "Error Tour")
            Exit Sub
        End If
        Dim i As Integer
        NoRate()
        Call ConnectDatabase()
        Dim cmd As MySqlCommand
        For i = 0 To lsAgent.Rows.Count() - 1 Step +1
            Call ConnectDatabase()
            'strSql = "insert into agentrate(AgentID,RuteID,Adult,Chd)values('" & cboAgents.SelectedItem("AgentID").ToString & "','" & CboRute.SelectedItem("RuteID").ToString & "','" & txtadl.Text & "','" & txtchd.Text & "')"
            Dim ag = Mid(lsAgent.Rows(i).Cells(1).Value, 1, 1)
            cmd = New MySqlCommand("insert into tourorderdtl(ID,OrderID,Guest,age,Pickup,pickuparea,guestid,noid)values('" & txtnobook.Text & "-" & i + 1 & "','" & txtnobook.Text & "','" & lsAgent.Rows(i).Cells(0).Value & "','" & ag & "','" & lsAgent.Rows(i).Cells(2).Value & "','" & lsAgent.Rows(i).Cells(3).Value & "','" & lsAgent.Rows(i).Cells(4).Value & "','" & lsAgent.Rows(i).Cells(5).Value & "')", conn)
            cmd.ExecuteScalar()
            'Dim strVal As String = "insert into tiketdtl (NoETiket, NoTiket, AgentID,GoTrip,GoRate,BackExtra,BackTrans,BackTransRate,BackTransExtra,BackArea,BackPickup,BackDriver,Qty,mrs,Guest,Country,GuestID,GuestIDNO,GoRuteID, " & gdt & " GoExtra,GoTrans,GoTranRate,GoTransExtra,GoArea,GoPickUp,GoDriver,Remark,BackRuteID," & bdt & " TripBack,BackRate,QtyTipe,TotalJual,NoBook,Tipe,reqcollect,komisi,sisa) values ('" & txtnobook.Text & "-" & b & "','" & LsData.Rows(a).Cells(4).Value & "','" & LsData.Rows(a).Cells(1).Value & "'," & NZx(LsData.Rows(a).Cells(15).Value) & "," & NZx(LsData.Rows(a).Cells(17).Value) & "," & NZx(LsData.Rows(a).Cells(32).Value) & "," & tranback & "," & NZx(LsData.Rows(a).Cells(34).Value) & "," & NZx(LsData.Rows(a).Cells(35).Value) & "," & NZx(LsData.Rows(a).Cells(36).Value) & ",@backpickup,@backdrv,1,'" & LsData.Rows(a).Cells(5).Value & "',@name," & NZx(LsData.Rows(a).Cells(9).Value) & ",'" & LsData.Rows(a).Cells(7).Value & "','" & LsData.Rows(a).Cells(8).Value & "'," & NZx(LsData.Rows(a).Cells(12).Value) & "," & dtg & " " & NZx(LsData.Rows(a).Cells(18).Value) & "," & trango & "," & NZx(LsData.Rows(a).Cells(20).Value) & "," & NZx(LsData.Rows(a).Cells(21).Value) & "," & NZx(LsData.Rows(a).Cells(22).Value) & ",@gopickup,@godrv,@remark,'" & NZx(LsData.Rows(a).Cells(26).Value) & "'," & dtb & "'" & NZx(LsData.Rows(a).Cells(29).Value) & "'," & NZx(LsData.Rows(a).Cells(31).Value) & "," & Mid(LsData.Rows(a).Cells(11).Value, 1, 1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ",'" & txtnobook.Text & "','" & LsData.Rows(a).Cells(43).Value & "'," & NZx(LsData.Rows(a).Cells(40).Value) & "," & (NZx(LsData.Rows(a).Cells(42).Value) * -1) & "," & NZx(LsData.Rows(a).Cells(42).Value) & ")"
            Dim strVal As String = "INSERT INTO tiketdtl ( NoETiket, AgentID, GoTrip, GoRate, BackTrans, BackArea, BackPickup, Qty, Guest, GuestID, GuestIDNO, GoRuteID, GODATE, GoTrans, GoArea, GoPickUp, BackRuteID, BACKDATE, TripBack, BackRate, QtyTipe, TotalJual, NoBook, Tipe, komisi, sisa, remark,ReqCollect ) VALUES ( '" & txtnobook.Text & "-" & i + 1 & "', '" & txtagentid.Text & "', '" & txtgotripid.Text & "', " & NZx(txttprice.Text) & ", 1, '" & lsAgent.Rows(i).Cells(3).Value & "', @backpickup, 1, @name, '" & lsAgent.Rows(i).Cells(4).Value & "', '" & lsAgent.Rows(i).Cells(5).Value & "', '" & txtgoruteid.Text & "', '" & Str2Date(txtgodate.Text) & "', 1, '" & lsAgent.Rows(i).Cells(3).Value & "', @gopickup, '" & txtbackruteid.Text & "', '" & Str2Date(txtgodate.Text) & "', '" & txtbacktripID.Text & "', 0, " & ag & ", " & NZx(txttprice.Text) & ", '" & txtnobook.Text & "', 'ODT', " & (NZx(txttprice.Text) * -1) & ", " & NZx(txttprice.Text) & ", @remark ," & txtcollect.Text & ")"
            cmd = New MySqlCommand(strVal, conn)
            cmd.Parameters.AddWithValue("@name", lsAgent.Rows(i).Cells(0).Value)
            cmd.Parameters.AddWithValue("@remark", txtremark.Text)
            cmd.Parameters.AddWithValue("@backpickup", lsAgent.Rows(i).Cells(3).Value)
            cmd.Parameters.AddWithValue("@gopickup", lsAgent.Rows(i).Cells(3).Value)
            cmd.ExecuteNonQuery()
            Call DisconnectDatabase()
            FillLog(usr, "Add New Tour Tiket", "No.E-Tiket : " & txtnobook.Text & "-" & i + 1 & "  Agent : " & txtagent.Text & "-" & txtagentid.Text & " ", "", "")

        Next
        ''MsgBox(div(0), vbOKOnly, )
        Call ConnectDatabase()
        Dim strSql As String

        strSql = "insert into tourorder(OrderID,TourID,AgentID,date,GoDate,remark,ReqCollect)values('" & txtnobook.Text & "','" & cbotour.SelectedItem("tourID").ToString & "','" & txtagentid.Text & "','" & Str2Date(TXTTGL.Text) & "','" & Str2Date(txtgodate.Text) & "','" & txtremark.Text & "'," & txtcollect.Text & ")"
        cmd = New MySqlCommand(strSql, conn)
        cmd.ExecuteScalar()
        Call DisconnectDatabase()
        FillLog(usr, "Add New Tour oRDER", "No. : " & txtnobook.Text & "  Agent : " & txtagent.Text & "-" & txtagentid.Text & " ", "", "")

        cbotour.Text = ""
        txtagent.Text = ""
        txtagentid.Text = ""
        txtbackrute.Text = ""
        txtbackruteid.Text = ""
        txtbacktrip.Text = ""
        txtbacktripID.Text = ""
        'txtgodate.Text = ""
        txtgorute.Text = ""
        txtgoruteid.Text = ""
        txtgotrip.Text = ""
        txtgotripid.Text = ""
        cboGoArea.Text = ""
        txtpickupgo.Text = ""
        txtnobook.Text = ""
        txtguest.Text = ""
        txttprice.Text = 0
        cboGst.Text = ""
        lsAgent.Rows.Clear()
    End Sub
End Class