Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmTourList
    Dim cmd As MySqlCommand
    Sub NoRate()
        Dim x = cxField("TourID", "tour", "TourID like '%TR%'")
        If x = 0 Then
            txtnobook.Text = "TR-000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("TourID", "tour", "TourID like '%TR%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            txtnobook.Text = "TR-" & numx(Lst, 6)
        End If

    End Sub
    Sub cls()
        txtagentid.Text = ""
        txtagent.Text = ""
        txtnobook.Text = ""
        cbobackrute.Text = ""
        cbobacktrip.Text = ""
        cboGorute.Text = ""
        cboGotrip.Text = ""

    End Sub
    Sub filltour()
        If LsData.Rows.Count > 0 Then
            LsData.DataSource = Nothing
        End If
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        Dim sql As String = "SELECT `tour`.`TourID` , `tour`.`TourName` , `tour`.`Gorute` , `tour`.`BackRute` , `tour`.`Gotrip` , `tour`.`BackTrip` , `rute`.`RuteName` AS DepartRute , `rute_1`.`RuteName` AS ReturnRute , `trip`.`TripName` AS DepartTrip , `trip_1`.`TripName` AS ReturnTrip  FROM `rute` INNER JOIN `tour` ON (`rute`.`RuteID` = `tour`.`Gorute`) INNER JOIN `rute` AS `rute_1` ON (`rute_1`.`RuteID` = `tour`.`BackRute`) INNER JOIN `trip` ON (`trip`.`TripID` = `tour`.`Gotrip`) INNER JOIN `trip` AS `trip_1` ON (`trip_1`.`TripID` = `tour`.`BackTrip`); "
        da = New MySqlDataAdapter(sql, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.Columns(2).Visible = False
        LsData.Columns(3).Visible = False
        LsData.Columns(4).Visible = False
        LsData.Columns(5).Visible = False
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
        cbobackrute.DataSource = dt2
        cbobackrute.DisplayMember = "RuteName"
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
        cbobacktrip.DataSource = dt2
        cbobacktrip.DisplayMember = "tripName"
        Call DisconnectDatabase()
    End Sub
    Private Sub frmTourList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GB3.Visible = False
        filltour()
        fillRute()
        filltrip()
    End Sub

    Private Sub cmdAgLs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgLs.Click
        frmagentlist.Show()
        frmagentlist.forms = "tour"
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        cls()
        If lsAgent.Rows.Count > 0 Then
            lsAgent.Rows.Clear()
        End If
        GB3.Visible = True
        LsData.Enabled = False
        cmdAdd.Enabled = False
        cmdEdit.Enabled = False
        cmdExit.Enabled = False
        cmdSave.Text = "&Save"
        lsAgent.ColumnCount = 3
        lsAgent.Columns(0).HeaderText = "Agent ID"
        lsAgent.Columns(1).HeaderText = "Agent Name"
        lsAgent.Columns(2).HeaderText = "Price"
        lsAgent.AllowUserToAddRows = False
        lsAgent.AllowUserToDeleteRows = False
        lsAgent.AllowUserToOrderColumns = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If lsAgent.Rows.Count = 0 Then
            MsgBox("Please Select Agent?", vbInformation, "Tour List")
            Exit Sub
        End If
        Select Case cmdSave.Text
            Case "&Save"


                Dim i As Integer
                NoRate()
                Call ConnectDatabase()
                For i = 0 To lsAgent.Rows.Count() - 1 Step +1
                    'strSql = "insert into agentrate(AgentID,RuteID,Adult,Chd)values('" & cboAgents.SelectedItem("AgentID").ToString & "','" & CboRute.SelectedItem("RuteID").ToString & "','" & txtadl.Text & "','" & txtchd.Text & "')"
                    cmd = New MySqlCommand("insert into tourprice(TourID,AgentID,Price)values('" & txtnobook.Text & "','" & lsAgent.Rows(i).Cells(0).Value & "'," & lsAgent.Rows(i).Cells(2).Value & ")", conn)
                    cmd.ExecuteScalar()
                Next
                ''MsgBox(div(0), vbOKOnly, )
                Dim strSql As String

                strSql = "insert into tour(TourID,TourName,Gorute,BackRute,Gotrip,BackTrip)values('" & txtnobook.Text & "','" & txtname.Text & "'," & cboGorute.SelectedItem("RuteID").ToString & "," & cbobackrute.SelectedItem("RuteID").ToString & "," & cboGotrip.SelectedItem("TripID").ToString & "," & cbobacktrip.SelectedItem("TripID").ToString & ")"
                cmd = New MySqlCommand(strSql, conn)
                cmd.ExecuteScalar()
                FillLog(usr, "Add New Agent Tour Rate", "No. : " & txtnobook.Text & "  Agent : " & txtagent.Text & "-" & txtagentid.Text & " ", "", "")
                Call DisconnectDatabase()
               
            Case "&Update"

                Dim shutle As Integer = 0
                
                Dim i, S As Integer
                'NoRate()

                For i = 0 To lsAgent.Rows.Count() - 1 Step +1


                    Dim logs As String = ""
                    S = cxField("TourID", "tourprice", "TourID='" & txtnobook.Text & "' and AgentID='" & lsAgent.Rows(i).Cells(0).Value & "'")
                    If S < 1 Then
                        Call ConnectDatabase()
                        cmd = New MySqlCommand("insert into tourprice(TourID,AgentID,Price)values('" & txtnobook.Text & "','" & lsAgent.Rows(i).Cells(0).Value & "'," & lsAgent.Rows(i).Cells(2).Value & ")", conn)
                        cmd.ExecuteScalar()
                        Call DisconnectDatabase()
                        If logs = "" Then
                            Dim newVal = " Price=" & lsAgent.Rows(i).Cells(2).Value & " where TourID=" & txtnobook.Text & " and AgentID=" & lsAgent.Rows(i).Cells(0).Value
                            Dim oldVal = " Price=0 where TourID=" & txtnobook.Text & " and AgentID=" & lsAgent.Rows(i).Cells(0).Value
                            logs = "Tour Change Rate ID=" & txtnobook.Text & " and AgentID=" & lsAgent.Rows(i).Cells(0).Value
                            FillLog(usr, "Update Tour Rate", logs, oldVal, newVal)
                            logs = ""
                        End If
                    Else

                        Dim cprice = GetField("Price", "tourprice", "TourID='" & txtnobook.Text & "' and AgentID='" & lsAgent.Rows(i).Cells(0).Value & "'")
                        If cprice <> lsAgent.Rows(i).Cells(2).Value Then
                            logs = " Price Tour Rate to " & lsAgent.Rows(i).Cells(2).Value
                        End If

                        'strSql = "insert into agentrate(AgentID,RuteID,Adult,Chd)values('" & cboAgents.SelectedItem("AgentID").ToString & "','" & CboRute.SelectedItem("RuteID").ToString & "','" & txtadl.Text & "','" & txtchd.Text & "')"
                        Call ConnectDatabase()
                            cmd = New MySqlCommand("update tourprice set Price=" & lsAgent.Rows(i).Cells(2).Value & " where TourID='" & txtnobook.Text & "' and AgentID='" & lsAgent.Rows(i).Cells(0).Value & "'", conn)
                        cmd.ExecuteScalar()
                        Call DisconnectDatabase()
                        If logs <> "" Then
                            Dim newVal = " Price=" & lsAgent.Rows(i).Cells(2).Value & " where TourID=" & txtnobook.Text & " and AgentID=" & lsAgent.Rows(i).Cells(0).Value
                            Dim oldVal = " Price=" & cprice & " where TourID=" & txtnobook.Text & " and AgentID=" & lsAgent.Rows(i).Cells(0).Value
                            logs = "Rate Change Rate ID=" & txtnobook.Text & " and Rute=" & lsAgent.Rows(i).Cells(0).Value & " with " & logs
                            FillLog(usr, "Update Rute Rate", logs, oldVal, newVal)
                        End If
                    End If
                Next
                ''MsgBox(div(0), vbOKOnly, )
                Dim strSql As String
                Dim cname = GetField("TourName", "tour", "TourID='" & txtnobook.Text & "'")
                Dim cgorute = GetField("Gorute", "tour", "TourID='" & txtnobook.Text & "'")
                Dim cbackrute = GetField("BackRute", "tour", "TourID='" & txtnobook.Text & "'")
                Dim cgotrip = GetField("Gotrip", "tour", "TourID='" & txtnobook.Text & "'")
                Dim cbacktrip = GetField("BackTrip", "tour", "TourID='" & txtnobook.Text & "'")
                Dim ulog As String = ""
                If cname <> txtname.Text Then
                    ulog = " TourName From " & cname & " to " & txtname.Text
                End If
                If cgorute <> cboGorute.SelectedItem("RuteID").ToString Then
                    ulog = ulog & " Gorute From " & cgorute & " to " & cboGorute.SelectedItem("RuteID").ToString
                End If
                If cbackrute <> cbobackrute.SelectedItem("RuteID").ToString Then
                    ulog = ulog & " BackRute From " & cgorute & " to " & cbobackrute.SelectedItem("RuteID").ToString
                End If
                If cgotrip <> cboGotrip.SelectedItem("tripID").ToString Then
                    ulog = ulog & " Gotrip From " & cgorute & " to " & cboGotrip.SelectedItem("TripID").ToString
                End If
                If cbacktrip <> cbobacktrip.SelectedItem("TripID").ToString Then
                    ulog = ulog & " BackTrip From " & cgorute & " to " & cbobacktrip.SelectedItem("TripID").ToString
                End If
                ConnectDatabase()
                strSql = "update tour set TourName='" & txtname.Text & "',Gorute=" & cboGorute.SelectedItem("RuteID").ToString & ",BackRute=" & cbobackrute.SelectedItem("RuteID").ToString & ",Gotrip=" & cboGotrip.SelectedItem("TripID").ToString & ",BackTrip=" & cbobacktrip.SelectedItem("TripID").ToString & " where TourID='" & txtnobook.Text & "'"
                cmd = New MySqlCommand(strSql, conn)
                cmd.ExecuteScalar()
                DisconnectDatabase()

                If ulog <> "" Then
                    ulog = "Tour Change Change Tour ID=" & txtnobook.Text & " with " & ulog
                    FillLog(usr, "Update tour Rate", "Rate Change" & ulog, "", "")
                End If

               
        End Select

        GB3.Visible = False
        LsData.Enabled = True
        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdExit.Enabled = True
        cls()
        filltour()
    End Sub

    Private Sub cboadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboadd.Click
        If txtagent.Text = "" Then
            MsgBox("Please Select Agent first", vbInformation, "Empty Agent")
            Exit Sub
        End If
        lsAgent.Rows.Add(txtagentid.Text, txtagent.Text, txtprice.Text)
        txtagent.Text = ""
        txtagentid.Text = ""
    End Sub

    Private Sub cboremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboremove.Click
        If lsAgent.Rows.Count = 0 Then
            Exit Sub
        End If
        lsAgent.Rows.RemoveAt(lsAgent.CurrentRow.Index)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        GB3.Visible = False
        LsData.Enabled = True
        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdExit.Enabled = True
        cls()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        
        cls()
        If lsAgent.Rows.Count > 0 Then
            lsAgent.Rows.Clear()
        End If
        GB3.Visible = True
        LsData.Enabled = False
        cmdAdd.Enabled = False
        cmdEdit.Enabled = False
        cmdExit.Enabled = False
        cmdSave.Text = "&Update"
        lsAgent.ColumnCount = 3
        lsAgent.Columns(0).HeaderText = "Agent ID"
        lsAgent.Columns(1).HeaderText = "Agent Name"
        lsAgent.Columns(2).HeaderText = "Price"
        txtnobook.Text = LsData.CurrentRow.Cells(0).Value
        txtname.Text = LsData.CurrentRow.Cells(1).Value
        cboGorute.Text = LsData.CurrentRow.Cells(6).Value
        cbobackrute.Text = LsData.CurrentRow.Cells(7).Value
        cboGotrip.Text = LsData.CurrentRow.Cells(8).Value
        cbobacktrip.Text = LsData.CurrentRow.Cells(9).Value
        Dim strSql As String
        Call ConnectDatabase()
        strSql = "select tourprice.*,agent.agentname from touRprice inner join agent on agent.agentid=tourprice.agentID where tourid='" & LsData.CurrentRow.Cells(0).Value & "'"
        Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
        Dim reader As MySqlDataReader = Comd.ExecuteReader
        While (reader.Read)
            lsAgent.Rows.Add(reader("AgentID").ToString(), reader("AgentName").ToString(), reader("Price").ToString())
        End While
        Call DisconnectDatabase()
        lsAgent.AllowUserToAddRows = False
        lsAgent.AllowUserToDeleteRows = False
    End Sub
End Class