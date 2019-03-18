Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmCekBording
    Dim tipe, dgo, dbback As String
    Sub fillLs(ByVal str As String)
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(str, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.Columns(0).ReadOnly = True
        LsData.Columns(1).ReadOnly = True
        Call DisconnectDatabase()
    End Sub
    Sub NoEtiket(ByVal str As String)
        Call ConnectDatabase()
        Try
            Dim strSql As String
            strSql = "SELECT tiketdtl.noBook,tiketdtl.NoeTiket, agent.AgentName,tiketdtl.mrs, tiketdtl.Guest ,   IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName,`tiketdtl`.`GoDate` AS Dates, IF( tiketdtl.GoRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF( tiketdtl.Gotrip = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS RETURNDate, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS RuteBack, IF( tiketdtl.tripback = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.Tripback) ) AS RETURNTrip,tiketdtl.ReqCollect,  tiketdtl.remark,tiketdtl.departgo,tiketdtl.departback,tiketdtl.Tipe,IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) where tiketdtl.NoEtiket='" & str & "'"
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim reader As MySqlDataReader = Comd.ExecuteReader
            While (reader.Read)
                'GetField = reader(strField).ToString()
                txtNoBook.Text = reader("noBook").ToString()
                txtetiket.Text = reader("NoEtiket").ToString()
                txtagent.Text = reader("Agentname").ToString()
                txtguest.Text = reader("mrs").ToString() & " " & reader("Guest").ToString() & " (" & reader("Age").ToString() & ") "
                txtcountry.Text = reader("countryName").ToString()
                txtdate.Text = reader("Dates").ToString()
                txtrute.Text = reader("Rute").ToString()
                txttrip.Text = reader("Trip").ToString()
                txtrdate.Text = reader("returnDate").ToString()
                txtrrute.Text = reader("RuteBack").ToString()
                txtrtrip.Text = reader("ReturnTrip").ToString()
                txtremark.Text = reader("Remark").ToString()
                txtcolect.Text = reader("reqCollect").ToString()
                tipe = reader("Tipe").ToString()
                dgo = reader("departgo").ToString()
                dbback = reader("Departback").ToString()
                Label16.Text = reader("status").ToString()
            End While
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Sub
    Sub FILTE()
        Dim strLs As String
        If txtnobooking.Text = "" And txtnoetiket.Text = "" Then
            MsgBox("Please fill Booking Number or No. E-Tiket", vbInformation, "error Bording")
            Exit Sub
        ElseIf txtnobooking.Text <> "" And txtnoetiket.Text = "" Then
            'strLs = "select NoBook, NoEtiket from tiketdtl where nobook='" & txtnobooking.Text & "'"
            strLs = "SELECT tiketdtl.noBook,tiketdtl.NoeTiket, agent.AgentName,tiketdtl.mrs, tiketdtl.Guest ,   IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName,`tiketdtl`.`GoDate` AS Dates, IF( tiketdtl.GoRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF( tiketdtl.Gotrip = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS RETURNDate, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS RuteBack, IF( tiketdtl.tripback = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.Tripback) ) AS RETURNTrip,tiketdtl.ReqCollect,  tiketdtl.remark,tiketdtl.departgo,tiketdtl.departback,tiketdtl.Tipe,IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) where tiketdtl.nobook='" & txtnobooking.Text & "'"
            fillLs(strLs)
        ElseIf txtnobooking.Text = "" And txtnoetiket.Text <> "" Then
            'strLs = "select NoBook, NoEtiket from tiketdtl where noetiket='" & txtnoetiket.Text & "'"
            strLs = "SELECT tiketdtl.noBook,tiketdtl.NoeTiket, agent.AgentName,tiketdtl.mrs, tiketdtl.Guest ,   IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName,`tiketdtl`.`GoDate` AS Dates, IF( tiketdtl.GoRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF( tiketdtl.Gotrip = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS RETURNDate, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS RuteBack, IF( tiketdtl.tripback = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.Tripback) ) AS RETURNTrip,tiketdtl.ReqCollect,  tiketdtl.remark,tiketdtl.departgo,tiketdtl.departback,tiketdtl.Tipe,IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) where tiketdtl.NoEtiket='" & txtnoetiket.Text & "'"

            fillLs(strLs)
        ElseIf txtnobooking.Text <> "" And txtnoetiket.Text <> "" Then
            'strLs = "select NoBook, NoEtiket from tiketdtl where nobook='" & txtnobooking.Text & "' and noetiket='" & txtnoetiket.Text & "'"
            strLs = "SELECT tiketdtl.noBook,tiketdtl.NoeTiket, agent.AgentName,tiketdtl.mrs, tiketdtl.Guest ,   IF( tiketdtl.QtyTipe = 1, 'ADL', IF( tiketdtl.QtyTipe = 2, 'CHD', IF( tiketdtl.QtyTipe = 3, 'INF', IF(tiketdtl.QtyTipe = 4, 'FOC', '') ) ) ) AS AGE, IF( `tiketdtl`.`Country` = '', '', (SELECT country.CountryName FROM country WHERE country.CountryID = tiketdtl.Country) ) AS CountryName,`tiketdtl`.`GoDate` AS Dates, IF( tiketdtl.GoRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.GoRuteID) ) AS Rute, IF( tiketdtl.Gotrip = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.goTrip) ) AS Trip, if(tiketdtl.BackDate is null or tiketdtl.BackDate='','',tiketdtl.BackDate) AS RETURNDate, IF( tiketdtl.backRuteID = 0, '', (SELECT rute.RuteName FROM rute WHERE rute.RuteID = tiketdtl.backRuteID) ) AS RuteBack, IF( tiketdtl.tripback = 0, '', (SELECT trip.TripName FROM trip WHERE trip.tripID = tiketdtl.Tripback) ) AS RETURNTrip,tiketdtl.ReqCollect,  tiketdtl.remark,tiketdtl.departgo,tiketdtl.departback,tiketdtl.Tipe,IF(tiketdtl.status>0,'Confirm','Cancel') AS STATUS FROM tiketdtl INNER JOIN agent ON (tiketdtl.AgentID = agent.AgentID) where tiketdtl.nobook='" & txtnobooking.Text & "' and tiketdtl.noetiket='" & txtnoetiket.Text & "'"

            fillLs(strLs)
        End If
    End Sub
    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        FILTE()
        txtNoBook.Text = ""
        txtetiket.Text = ""
        txtagent.Text = ""
        txtguest.Text = ""
        txtcountry.Text = ""
        txtdate.Text = ""
        txtrute.Text = ""
        txttrip.Text = ""
        txtrdate.Text = ""
        txtrrute.Text = ""
        txtrtrip.Text = ""
        txtremark.Text = ""
        txtcolect.Text = ""
        Label16.Text = ""
        tipe = ""
        dgo = ""
        dbback = ""
    End Sub

    Private Sub frmCekBording_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNoBook.Text = ""
        txtetiket.Text = ""
        txtagent.Text = ""
        txtguest.Text = ""
        txtcountry.Text = ""
        txtdate.Text = ""
        txtrute.Text = ""
        txttrip.Text = ""
        txtrdate.Text = ""
        txtrrute.Text = ""
        txtrtrip.Text = ""
        txtremark.Text = ""
        txtcolect.Text = ""
        Label16.Text = ""
        tipe = ""
        dgo = ""
        dbback = ""
        txtnoetiket.Focus()
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        If LsData.RowCount = 0 Then
            Exit Sub
        End If
        If LsData.CurrentRow.Cells(0).Value = "" Then
            Exit Sub
        End If
        txtNoBook.Text = LsData.CurrentRow.Cells(0).Value
        txtetiket.Text = LsData.CurrentRow.Cells(1).Value
        txtagent.Text = LsData.CurrentRow.Cells(2).Value
        txtguest.Text = LsData.CurrentRow.Cells(3).Value & " " & LsData.CurrentRow.Cells(4).Value & " (" & LsData.CurrentRow.Cells(5).Value & ") "
        txtcountry.Text = LsData.CurrentRow.Cells(6).Value
        txtdate.Text = LsData.CurrentRow.Cells(7).Value
        txtrute.Text = LsData.CurrentRow.Cells(8).Value
        txttrip.Text = LsData.CurrentRow.Cells(9).Value
        txtrdate.Text = LsData.CurrentRow.Cells(10).Value
        txtrrute.Text = LsData.CurrentRow.Cells(11).Value
        txtrtrip.Text = LsData.CurrentRow.Cells(12).Value
        txtremark.Text = LsData.CurrentRow.Cells(14).Value
        txtcolect.Text = LsData.CurrentRow.Cells(13).Value
        tipe = LsData.CurrentRow.Cells(17).Value
        dgo = LsData.CurrentRow.Cells(15).Value
        dbback = LsData.CurrentRow.Cells(16).Value
        Label16.Text = LsData.CurrentRow.Cells(18).Value
    End Sub
    Sub cekbording()
        If tipe = "RT" Then
            If dgo = 0 Then
                Try
                    Call ConnectDatabase()

                    Dim strSQL As String
                    Dim cmd As MySqlCommand

                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If
                    strSQL = "Update tiketdtl set departgo=1 where noetiket='" & txtetiket.Text & "'"
                    cmd = New MySqlCommand(strSQL, conn)
                    cmd.ExecuteScalar()
                    strSQL = "insert into boarding(BoardingNo,NoEtiket,User,Boarding)values('" & txtetiket.Text & "','" & txtetiket.Text & "','" & usr & "','1')"
                    cmd = New MySqlCommand(strSQL, conn)
                    cmd.ExecuteScalar()
                    Call DisconnectDatabase()
                Catch ex As SqlException
                    MsgBox(ex.Message)
                Finally
                    ' Close connection
                    Call DisconnectDatabase()
                End Try
                FillLog(usr, "Boarding Ticket No.E-Tiket:" & txtetiket.Text, "", "", "")
                MsgBox("Boarding  Success", vbInformation, "Success")
                dgo = 1
            Else
                If dbback = 0 Then
                    If MsgBox("Ticket already Bording before, Are you want to return boarding?", vbYesNo, "Boarding Return") = vbYes Then
                        Try
                            Call ConnectDatabase()

                            Dim strSQL As String
                            Dim cmd As MySqlCommand

                            If conn.State = ConnectionState.Closed Then
                                conn.Open()
                            End If
                            strSQL = "Update tiketdtl set departback=1 where noetiket='" & txtetiket.Text & "'"
                            cmd = New MySqlCommand(strSQL, conn)
                            cmd.ExecuteScalar()
                            strSQL = "insert into boarding(BoardingNo,NoEtiket,User,Boarding)values('" & txtetiket.Text & "','" & txtetiket.Text & "','" & usr & "','2')"
                            cmd = New MySqlCommand(strSQL, conn)
                            cmd.ExecuteScalar()
                            Call DisconnectDatabase()
                        Catch ex As SqlException
                            MsgBox(ex.Message)
                        Finally
                            ' Close connection
                            Call DisconnectDatabase()
                        End Try
                        FillLog(usr, "Boarding Return Ticket No.E-Tiket:" & txtetiket.Text, "", "", "")
                        MsgBox("Boarding  Success", vbInformation, "Success")

                        dbback = 1
                    End If
                Else
                    MsgBox("Ticket already Used", vbInformation, "Error Boarding")
                    Exit Sub
                End If

            End If
        ElseIf tipe = "OW" Then
            If dgo = 0 Then
                Try
                    Call ConnectDatabase()

                    Dim strSQL As String
                    Dim cmd As MySqlCommand

                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If
                    strSQL = "Update tiketdtl set departgo=1 where noetiket='" & txtetiket.Text & "'"
                    cmd = New MySqlCommand(strSQL, conn)
                    cmd.ExecuteScalar()
                    strSQL = "insert into boarding(BoardingNo,NoEtiket,User,Boarding)values('" & txtetiket.Text & "','" & txtetiket.Text & "','" & usr & "','1')"
                    cmd = New MySqlCommand(strSQL, conn)
                    cmd.ExecuteScalar()
                    Call DisconnectDatabase()
                Catch ex As SqlException
                    MsgBox(ex.Message)
                Finally
                    ' Close connection
                    Call DisconnectDatabase()
                End Try
                FillLog(usr, "Boarding Ticket No.E-Tiket:" & txtetiket.Text, "", "", "")
                MsgBox("Boarding  Success", vbInformation, "Success")
                dgo = 1
            Else
                MsgBox("Ticket already Used", vbInformation, "Error Boarding")
                Exit Sub
            End If
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Label16.Text = "Cancel" Then
            MsgBox("Ticket Canceled", vbInformation, "Error Boarding")
            Exit Sub
        Else
            cekbording()
        End If


        FILTE()
        txtnoetiket.Text = ""
        txtnoetiket.Focus()
    End Sub

  

    Private Sub txtnoetiket_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtnoetiket.PreviewKeyDown
        If e.KeyData = Keys.Enter Then
            If txtnoetiket.Text <> "" Then
                NoEtiket(txtnoetiket.Text)
            End If
        End If
    End Sub

    Private Sub txtnoetiket_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnoetiket.TextChanged
        NoEtiket(txtnoetiket.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtnoetiket.Text = ""
        txtnoetiket.Focus()
    End Sub
End Class