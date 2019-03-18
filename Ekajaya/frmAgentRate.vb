Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class frmAgentRate
    Dim cmd As MySqlCommand
    Sub NoRate()
        Dim x = cxField("RateID", "agentrate", "AgentID='" & txtid.Text & "'")
        If x = 0 Then
            txtnobook.Text = txtid.Text & "-000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("RateID", "agentrate", "AgentID='" & txtid.Text & "'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            txtnobook.Text = txtid.Text & "-" & numx(Lst, 6)
        End If

    End Sub

    Sub cls()
        txtid.Text = ""
        txtname.Text = ""
        txtnobook.Text = ""
        txtsurecharge.Text = "0"

    End Sub
    Sub fillcombo()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID,AgentName from agent where status=1", conn)
        dt = New DataTable
        da.Fill(dt)
        CboAgent.DataSource = dt
        CboAgent.DisplayMember = "AgentName"
        Call DisconnectDatabase()
    End Sub
    Sub filllsrute()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("Select RuteID,RuteName,0 AS `OW-Adult`,  0 AS `RT-Adult`,  0 AS `OW-Child`,  0 AS `RT-Child`, 0 As Infant, 0 as FOC from rute", conn)
        dt = New DataTable
        da.Fill(dt)
        lsRute.DataSource = dt
        lsRute.AllowUserToAddRows = False
        lsRute.AllowUserToDeleteRows = False
        lsRute.Columns(0).Visible = False
        lsRute.Columns(1).ReadOnly = True
        Call DisconnectDatabase()
    End Sub


    Sub filldata(ByVal AgentID As String)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        Dim sql As String = "select AgentRatedtl.RuteID,AgentRatedtl.agentID,AgentRatedtl.RateID,agent.AgentName,AgentRatedtl.StartDate,AgentRatedtl.EndDate,rute.RuteName,AgentRatedtl.Adult as `OW-Adl`,AgentRatedtl.Adult2 as `RT-Adl`,AgentRatedtl.Child as `OW-Chd`,AgentRatedtl.Child2 as `RT-Chd`,AgentRatedtl.Inf,AgentRatedtl.FOC,AGentrate.`3ANGLE`,AgentRatedtl.SurCharge,if(AgentRatedtl.Shuttle='1','Price With Shuttle','Price No Shuttle') as Shuttle from AgentRatedtl inner join Agent on agentratedtl.AgentID=agent.AgentID inner join rute on rute.RuteID=AgentRatedtl.RuteID INNER JOIN agentrate ON agentrate.`RateID`=agentratedtl.`RateID` where agentratedtl.AgentID='" & AgentID & "'"
        da = New MySqlDataAdapter(sql, conn)
        dt = New DataTable
        da.Fill(dt)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        lsData.Columns(0).Visible = False
        lsData.Columns(1).Visible = False
        Call DisconnectDatabase()
    End Sub
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Hide()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'MsgBox(txtagentid.text(), vbOKOnly, "Agent PriceList")
        filldata(CboAgent.SelectedItem("AgentID").ToString)
    End Sub

    Private Sub frmAgentRate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcombo()
        GB3.Visible = False
    End Sub


    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        cls()

        GroupBox1.Enabled = False
        GB3.Visible = True
        lsData.Enabled = False
        filllsrute()
        cmdSave.Text = "&Save"
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        GroupBox1.Enabled = True
        lsData.Enabled = True
        GB3.Visible = False
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        GroupBox1.Enabled = False
        cls()
        GB3.Visible = True
        lsData.Enabled = False
        cmdSave.Text = "&Update"
        txtnobook.Text = lsData.CurrentRow.Cells(2).Value
        txtid.Text = lsData.CurrentRow.Cells(1).Value
        txtname.Text = lsData.CurrentRow.Cells(3).Value
        txtstart.Text = lsData.CurrentRow.Cells(4).Value
        txtend.Text = lsData.CurrentRow.Cells(5).Value
        txtsurecharge.Text = lsData.CurrentRow.Cells(11).Value
        If lsData.CurrentRow.Cells(12).ToString = "Price With Shuttle" Then
            cxshuttle.CheckState = CheckState.Checked
        Else
            cxshuttle.CheckState = CheckState.Unchecked
        End If
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("Select rute.RuteID,rute.RuteName,agentratedtl.Adult as `OW-Adult`,agentratedtl.Adult2 as `RT-Adult`,agentratedtl.Child As `OW-Child`,agentratedtl.Child2 As `RT-Child`,agentratedtl.inf As Infant, agentratedtl.foc as FOC from agentratedtl inner join rute on agentratedtl.ruteid=rute.ruteid where agentratedtl.RateID='" & txtnobook.Text & "' union Select RuteID,RuteName,0 AS `OW-Adult`,  0 AS `RT-Adult`,  0 AS `OW-Child`,  0 AS `RT-Child`, 0 As Infant, 0 as FOC from rute where RuteID not in(select RuteID from agentratedtl where RateID='" & txtnobook.Text & "' )", conn)
        dt = New DataTable
        da.Fill(dt)
        lsRute.DataSource = dt
        lsRute.AllowUserToAddRows = False
        lsRute.AllowUserToDeleteRows = False
        lsRute.Columns(0).Visible = False
        lsRute.Columns(1).ReadOnly = True
        Call DisconnectDatabase()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtname.Text = "" Then
            MsgBox("Please Select Agent?", vbInformation, "Agent Rate")
        End If
        Select Case cmdSave.Text
            Case "&Save"
                Try
                    Dim chk = cxField("AgentID", "agentrate", "AgentID='" & txtid.Text & "' and DateStart>'" & Str2Date(txtstart.Text) & "' and DateEnd<'" & Str2Date(txtstart.Text) & "'")
                    If chk = 1 Then
                        MsgBox("Rate sudah ada sebelumnya", vbOKOnly, "Error Rate")
                        Exit Sub
                    End If
                    Dim shutle As Integer = 0
                    'If cxshuttle.CheckState = CheckState.Checked Then
                    '    shutle = 1
                    'Else
                    '    shutle = 0
                    'End If
                    Dim i As Integer
                    NoRate()
                    Call ConnectDatabase()
                    For i = 0 To lsRute.Rows.Count() - 1 Step +1
                        'strSql = "insert into agentrate(AgentID,RuteID,Adult,Chd)values('" & cboAgents.SelectedItem("AgentID").ToString & "','" & CboRute.SelectedItem("RuteID").ToString & "','" & txtadl.Text & "','" & txtchd.Text & "')"
                        cmd = New MySqlCommand("insert into agentratedtl(RateID,AgentID,RuteID,Adult,Adult2,Child,Child2,Inf,Foc,Surcharge,StartDate,EndDate,Shuttle)values('" & txtnobook.Text & "','" & txtid.Text & "','" & lsRute.Rows(i).Cells(0).Value & "'," & lsRute.Rows(i).Cells(2).Value & "," & lsRute.Rows(i).Cells(3).Value & "," & lsRute.Rows(i).Cells(4).Value & "," & lsRute.Rows(i).Cells(5).Value & "," & lsRute.Rows(i).Cells(6).Value & "," & lsRute.Rows(i).Cells(7).Value & "," & txtsurecharge.Text & ",'" & Str2Date(txtstart.Text) & "','" & Str2Date(txtend.Text) & "','" & shutle & "')", conn)
                        cmd.ExecuteScalar()
                    Next
                    ''MsgBox(div(0), vbOKOnly, )
                    Dim strSql As String

                    strSql = "insert into agentrate(RateID,agentID,DateStart,DateEnd,SureCharge,Shuttle,3ANGLE)values('" & txtnobook.Text & "','" & txtid.Text & "','" & Str2Date(txtstart.Text) & "','" & Str2Date(txtend.Text) & "'," & txtsurecharge.Text & ",'" & shutle & "'," & txt3a.Text & ")"
                    cmd = New MySqlCommand(strSql, conn)
                    cmd.ExecuteScalar()
                    FillLog(usr, "Add New Agent Rate", "No. : " & txtnobook.Text & "  Agent : " & txtname.Text & "-" & txtid.Text & " ", "", "")
                    Call DisconnectDatabase()
                Catch ex As SqlException
                    MsgBox(ex.Message)
                Finally
                    ' Close connection
                    Call DisconnectDatabase()
                End Try
                GB3.Visible = False
                lsData.Enabled = True
                GroupBox1.Enabled = True

                filldata(txtid.Text)
                'cls()
            Case "&Update"
                Try
                    Dim shutle As Integer = 0
                    'If cxshuttle.CheckState = CheckState.Checked Then
                    '    shutle = 1
                    'Else
                    '    shutle = 0
                    'End If
                    Dim i, S As Integer
                    'NoRate()

                    For i = 0 To lsRute.Rows.Count() - 1 Step +1


                        Dim logs As String = ""
                        S = cxField("Adult", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value)
                        If S < 1 Then
                            Call ConnectDatabase()
                            cmd = New MySqlCommand("insert into agentratedtl(RateID,AgentID,RuteID,Adult,Adult2,Child,Child2,Inf,Foc,Surcharge,StartDate,EndDate,Shuttle)values('" & txtnobook.Text & "','" & txtid.Text & "','" & lsRute.Rows(i).Cells(0).Value & "'," & lsRute.Rows(i).Cells(2).Value & "," & lsRute.Rows(i).Cells(3).Value & "," & lsRute.Rows(i).Cells(4).Value & "," & lsRute.Rows(i).Cells(5).Value & "," & lsRute.Rows(i).Cells(6).Value & "," & lsRute.Rows(i).Cells(7).Value & "," & txtsurecharge.Text & ",'" & Str2Date(txtstart.Text) & "','" & Str2Date(txtend.Text) & "','" & shutle & "')", conn)
                            cmd.ExecuteScalar()
                            Call DisconnectDatabase()
                            If logs <> "" Then
                                Dim newVal = " Adult=" & lsRute.Rows(i).Cells(2).Value & ",Child=" & lsRute.Rows(i).Cells(3).Value & ",Inf=" & lsRute.Rows(i).Cells(4).Value & ",Foc=" & lsRute.Rows(i).Cells(5).Value & ",Surcharge=" & txtsurecharge.Text & ",StartDate=" & Str2Date(txtstart.Text) & ",EndDate=" & Str2Date(txtend.Text) & ",Shuttle=" & shutle & " where RateID=" & txtnobook.Text & " and AgentID=" & txtid.Text & " and RuteID=" & lsRute.Rows(i).Cells(0).Value & ""
                                Dim oldVal = " Adult=0,Child=0,Inf=0,Foc=0,Surcharge=0,Shuttle=" & shutle & " where RateID=" & txtnobook.Text & " and AgentID=" & txtid.Text & " and RuteID=" & lsRute.Rows(i).Cells(0).Value & ""
                                logs = "Rate Change Rate ID=" & txtnobook.Text & " and Rute=" & lsRute.Rows(i).Cells(0).Value & " with " & logs
                                FillLog(usr, "Update Rute Rate", logs, oldVal, newVal)
                            End If
                        Else

                            Dim cadl = GetField("Adult", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value)
                            Dim cchd = GetField("Child", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value)
                            Dim cadl2 = GetField("Adult2", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value)
                            Dim cchd2 = GetField("Child2", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value)

                            Dim cinf = GetField("Inf", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value)
                            Dim cfoc = GetField("foc", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value)
                            Dim srcg = GetField("Surcharge", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value)
                            If cadl <> lsRute.Rows(i).Cells(2).Value Then
                                logs = " Adult Rate to " & lsRute.Rows(i).Cells(2).Value
                            End If
                            If cchd <> lsRute.Rows(i).Cells(4).Value Then
                                logs = logs & " Child Rate " & lsRute.Rows(i).Cells(4).Value
                            End If
                            If cadl2 <> lsRute.Rows(i).Cells(3).Value Then
                                logs = " Adult Rate to " & lsRute.Rows(i).Cells(3).Value
                            End If
                            If cchd2 <> lsRute.Rows(i).Cells(5).Value Then
                                logs = logs & " Child Rate " & lsRute.Rows(i).Cells(5).Value
                            End If
                            If cinf <> lsRute.Rows(i).Cells(6).Value Then
                                logs = logs & " Infant Rate  to " & lsRute.Rows(i).Cells(6).Value
                            End If
                            If cfoc <> lsRute.Rows(i).Cells(7).Value Then
                                logs = logs & " Foc Rate to " & lsRute.Rows(i).Cells(7).Value
                            End If

                            'strSql = "insert into agentrate(AgentID,RuteID,Adult,Chd)values('" & cboAgents.SelectedItem("AgentID").ToString & "','" & CboRute.SelectedItem("RuteID").ToString & "','" & txtadl.Text & "','" & txtchd.Text & "')"
                            Call ConnectDatabase()
                            cmd = New MySqlCommand("update agentratedtl set Adult=" & lsRute.Rows(i).Cells(2).Value & ",Child=" & lsRute.Rows(i).Cells(4).Value & ",Adult2=" & lsRute.Rows(i).Cells(3).Value & ",Child2=" & lsRute.Rows(i).Cells(5).Value & ",Inf=" & lsRute.Rows(i).Cells(6).Value & ",Foc=" & lsRute.Rows(i).Cells(7).Value & ",Surcharge=" & txtsurecharge.Text & ",StartDate='" & Str2Date(txtstart.Text) & "',EndDate='" & Str2Date(txtend.Text) & "',Shuttle='" & shutle & "' where RateID='" & txtnobook.Text & "' and AgentID='" & txtid.Text & "' and RuteID='" & lsRute.Rows(i).Cells(0).Value & "'", conn)
                            cmd.ExecuteScalar()
                            Call DisconnectDatabase()
                            If logs <> "" Then
                                Dim newVal = " Adult=" & lsRute.Rows(i).Cells(2).Value & ",Child=" & lsRute.Rows(i).Cells(3).Value & ",Inf=" & lsRute.Rows(i).Cells(4).Value & ",Foc=" & lsRute.Rows(i).Cells(5).Value & ",Surcharge=" & txtsurecharge.Text & ",StartDate=" & Str2Date(txtstart.Text) & ",EndDate=" & Str2Date(txtend.Text) & ",Shuttle=" & shutle & " where RateID=" & txtnobook.Text & " and AgentID=" & txtid.Text & " and RuteID=" & lsRute.Rows(i).Cells(0).Value & ""
                                Dim oldVal = " Adult=" & cadl & ",Child=" & cchd & ",Inf=" & cinf & ",Foc=" & cfoc & ",Surcharge=" & srcg & ",StartDate=" & GetField("StartDate", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value) & ",EndDate=" & GetField("EndDate", "agentratedtl", "RateID='" & txtnobook.Text & "' and RuteID=" & lsRute.Rows(i).Cells(0).Value) & ",Shuttle=" & shutle & " where RateID=" & txtnobook.Text & " and AgentID=" & txtid.Text & " and RuteID=" & lsRute.Rows(i).Cells(0).Value & ""
                                logs = "Rate Change Rate ID=" & txtnobook.Text & " and Rute=" & lsRute.Rows(i).Cells(0).Value & " with " & logs
                                FillLog(usr, "Update Rute Rate", logs, oldVal, newVal)
                            End If
                        End If
                    Next
                    ''MsgBox(div(0), vbOKOnly, )
                    Dim strSql As String
                    Dim cst = GetField("DateStart", "agentrate", "RateID='" & txtnobook.Text & "'")
                    Dim cen = GetField("DateEnd", "agentrate", "RateID='" & txtnobook.Text & "'")
                    Dim csc = GetField("SureCharge", "agentrate", "RateID='" & txtnobook.Text & "'")
                    Dim csh = GetField("Shuttle", "agentrate", "RateID='" & txtnobook.Text & "'")
                    Dim ulog As String = ""
                    If cst <> Str2Date(txtstart.Text) Then
                        ulog = " StartDate Rate From " & cst & " to " & Str2Date(txtstart.Text)
                    End If
                    If cen <> txtend.Text Then
                        ulog = ulog & " EndDate Rate From " & cst & " to " & Str2Date(txtend.Text)
                    End If
                    If csc <> txtsurecharge.Text Then
                        ulog = ulog & " Surchage Rate From " & csc & " to " & txtsurecharge.Text
                    End If
                    Dim cxsh As String = ""
                    If cxshuttle.CheckState = CheckState.Checked Then
                        cxsh = "1"
                    Else
                        cxsh = "0"
                    End If
                    If csh <> cxsh Then
                        ulog = ulog & " Surchage Rate From " & csc & " to " & cxsh
                    End If
                    ConnectDatabase()
                    strSql = "update agentrate set DateStart='" & Str2Date(txtstart.Text) & "',DateEnd='" & Str2Date(txtend.Text) & "',SureCharge=" & txtsurecharge.Text & ",3ANGLE=" & txt3a.Text & ",Shuttle='" & shutle & "' where RateID='" & txtnobook.Text & "' and agentID='" & txtid.Text & "'"
                    cmd = New MySqlCommand(strSql, conn)
                    cmd.ExecuteScalar()
                    DisconnectDatabase()

                    If ulog <> "" Then
                        ulog = "Rate Change Rate ID=" & txtnobook.Text & " with " & ulog
                        FillLog(usr, "Update Agent Rate", "Rate Change" & ulog, "", "")
                    End If

                Catch ex As SqlException
                    MsgBox(ex.Message)
                Finally
                    ' Close connection
                    Call DisconnectDatabase()
                End Try
                GB3.Visible = False
                lsData.Enabled = True
                GroupBox1.Enabled = True

                filldata(txtid.Text)
                'cls()
        End Select
    End Sub

    Private Sub cmdAgLs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgLs.Click
        frmagentlist.Show()
        frmagentlist.forms = "AgentRate"
        Me.Hide()
    End Sub

End Class