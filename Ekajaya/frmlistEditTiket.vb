Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class frmlistEditTiket

    Sub filltiket(ByVal criteria As String)
        LsData.Columns.Clear()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        'da = New MySqlDataAdapter("SELECT 0 as ID, tiketdtl.NoETiket as NoETiket, tiketdtl.NoTiket as NoTiket, tiketdtl.GoDate as DateGo, tiketdtl.GoTrip, trip.TripName as GoTrip,tiketdtl.GoRuteID, rute.RuteName as RuteGo, tiketdtl.GoRate As GoRate, tiketdtl.GoExtra as GoExtraRate, tiketdtl.GoTranRate as GoTransportRate, tiketdtl.GoTransExtra as GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,  rute_1.RuteName as BackRute, tiketdtl.TripBack, trip_1.TripName as TripBack, tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.BackTransExtra, (tiketdtl.GoRate+ tiketdtl.GoExtra + tiketdtl.GoTranRate + tiketdtl.GoTransExtra + tiketdtl.BackRate + tiketdtl.BackExtra + tiketdtl.BackTransRate + tiketdtl.BackTransExtra)as total FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) INNER JOIN rute AS rute_1 ON tiketdtl.BackRuteID = rute_1.RuteID) INNER JOIN trip AS trip_1 ON tiketdtl.TripBack = trip_1.TripID WHERE " & criteria & "", conn)
        da = New MySqlDataAdapter("SELECT 0 AS ID, tiketdtl.NoETiket AS NoETiket, tiketdtl.NoTiket AS NoTiket, tiketdtl.GoDate AS DateGo, tiketdtl.Guest As Name, trip.TripName AS GoTrip,tiketdtl.GoRuteID, rute.RuteName AS RuteGo, tiketdtl.GoRate AS GoRate, tiketdtl.GoExtra AS GoExtraRate, tiketdtl.GoTranRate AS GoTransportRate, tiketdtl.GoTransExtra AS GoTransportExtra, tiketdtl.BackDate, tiketdtl.BackRuteID,   tiketdtl.BackRate,tiketdtl.BackExtra, tiketdtl.BackTransRate, tiketdtl.`AgentID` FROM ((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) where " & criteria & " and pay<>1", conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = ""
        chk.Name = "ID"

        LsData.Columns.Insert(0, chk)
        LsData.Columns(0).Width = 40
        LsData.Columns(0).ReadOnly = False
        'LsData.Columns(19).ReadOnly = True
        LsData.Columns(1).ReadOnly = True
        LsData.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        LsData.Columns(1).Visible = False
        LsData.Columns(2).ReadOnly = True
        LsData.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        LsData.Columns(3).ReadOnly = True
        LsData.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        LsData.Columns(4).ReadOnly = True

        LsData.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        LsData.Columns(6).ReadOnly = True
        LsData.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        LsData.Columns(7).Visible = False
        LsData.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        LsData.Columns(8).Visible = False
        LsData.Columns(9).Visible = False
        LsData.Columns(10).Visible = False
        LsData.Columns(11).Visible = False
        LsData.Columns(12).Visible = False
        LsData.Columns(13).Visible = False
        LsData.Columns(14).Visible = False
        LsData.Columns(15).Visible = False
        LsData.Columns(16).Visible = False
        LsData.Columns(17).Visible = False
        LsData.Columns(18).Visible = False

        Call DisconnectDatabase()
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

    Private Sub frmlistEditTiket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        Dim x As Integer = 0
        Dim filt As String = ""
        If cboAgent.Text = "" Then
            MsgBox("Please Fill Agent Name", vbInformation, "Data Is Empty")
            Exit Sub
        Else
            x = x + 1
            filt = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "'"
        End If
        If cbotipe.Text = "" Then
        Else
            x = x + 1
            If filt = "" Then
                filt = " tiketdtl.Tipe='" & Mid(cbotipe.Text, 1, 2) & "'"
            Else
                filt = filt & " and tiketdtl.Tipe='" & Mid(cbotipe.Text, 1, 2) & "'"
            End If

        End If
        If txtgodate.Text = "" Then
            MsgBox("Please Fill Depart Date", vbInformation, "Date Is Empty")
            Exit Sub
        Else
            x = x + 1
            If filt = "" Then
                filt = " (tiketdtl.godate='" & Str2Date(txtgodate.Text) & "') "
            Else
                filt = filt & " and tiketdtl.godate='" & Str2Date(txtgodate.Text) & "'"
            End If

        End If

        filltiket(filt)
    End Sub

    Private Sub LsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LsData.CellContentClick
        If LsData.Rows(e.RowIndex).Cells(1).Value = 0 Then
            LsData.Rows(e.RowIndex.ToString).Cells(1).Value = 1
            Exit Sub
        Else
            LsData.Rows(e.RowIndex.ToString).Cells(1).Value = 0
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim I As Integer = LsData.RowCount
        Dim cxf
        Dim a As Integer
        Dim fil As String = ""
        Dim lst As String = ""
        For a = 0 To (I - 1)
            If LsData.Rows(a).Cells(1).Value = 1 Then
                If fil = "" Then
                    fil = " NoETiket='" & LsData.Rows(a).Cells(2).Value & "'"
                    lst = LsData.Rows(a).Cells(2).Value
                Else
                    fil = fil & " or NoETiket='" & LsData.Rows(a).Cells(2).Value & "'"
                    lst = lst & "|" & LsData.Rows(a).Cells(2).Value
                End If
            End If
        Next
        'MsgBox("Print Tiket is on Proggress", vbInformation, "Print Tiket")

        Call ConnectDatabase()
        Try
            Dim dt As New DataTable
            Dim sql As String = "SELECT tiketdtl.AgentID, tiketdtl.GoTrip, tiketdtl.BackTrans, tiketdtl.BackArea, tiketdtl.BackPickup, tiketdtl.BackDriver, tiketdtl.GoRuteID, tiketdtl.GoDate, tiketdtl.GoTrans, tiketdtl.GoArea, tiketdtl.GoPickUp, tiketdtl.GoDriver, tiketdtl.BackRuteID,tiketdtl.BackDate, tiketdtl.TripBack FROM tiketdtl WHERE (" & fil & ") GROUP BY tiketdtl.AgentID, tiketdtl.GoTrip, tiketdtl.BackTrans, tiketdtl.BackArea, tiketdtl.BackPickup, tiketdtl.BackDriver, tiketdtl.GoRuteID, tiketdtl.GoDate, tiketdtl.GoTrans, tiketdtl.GoArea, tiketdtl.GoPickUp, tiketdtl.GoDriver, tiketdtl.BackRuteID, tiketdtl.BackDate, tiketdtl.TripBack;"
            Dim Comd As MySqlCommand = New MySqlCommand(sql, conn)
            Dim reader As MySqlDataReader = Comd.ExecuteReader
            dt.Load(reader)
            cxf = dt.Rows.Count
            If cxf = 1 Then
                frmMultiBooking.list = fil
                frmMultiBooking.txtlist.Text = lst
                frmMultiBooking.Show()
            ElseIf cxf = 0 Then
                MsgBox("Data Not Found Please select Data to Update", vbInformation, "No Data")
            Else
                If MsgBox("Departure or Return Data is Different" & vbCrLf & "Are Your Sure to Update?", vbYesNo, "No Data") = vbYes Then
                    frmMultiBooking.list = fil
                    frmMultiBooking.txtlist.Text = lst
                    frmMultiBooking.Show()
                Else
                    Exit Sub
                End If
            End If
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try

    End Sub
End Class