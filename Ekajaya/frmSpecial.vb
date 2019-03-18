Imports MySql.Data.MySqlClient
Imports System.Data
Public Class frmSpecial

    Dim strLogs As String
    Sub fillRute()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID,AgentName from Agent", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)

        'da.Fill(dt)
        cboGorute.DataSource = dt
        cboGorute.DisplayMember = "AgentName"

        Call DisconnectDatabase()
    End Sub
    Sub NoEvents()
        Dim x = cxField("NoEvent", "special", "NoEvent Like 'EV-" & Month(Now) & "%'")
        If x = 0 Then
            txtno.Text = "EV-" & Month(Now) & "-0001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("NoEvent", "special", "NoEvent Like 'EV-" & Month(Now) & "%'")
            Dim lLast = Len(Lst)
            Lst = Val(Mid(Lst, lLast - 3, 4) + 1)
            txtno.Text = "EV-" & Month(Now) & "-" & numx(Lst, 4)
        End If

    End Sub
    Sub fillData()
        Call ConnectDatabase()
        'LsData.Rows.Clear()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select special.NoEvent,special.Name,special.StartDate,special.EndDate,special.Adult,special.Child,special.Infant,special.FOC,special.AgentID,agent.AgentName as AgentName,max as Maximum from special inner join agent on agent.agentid=special.agentid order by NoEvent desc", conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.ReadOnly = True
        LsData.Columns(8).Visible = False
        Call DisconnectDatabase()
    End Sub
    Sub save()
        If txtadl.Text = "" Then
            MsgBox("Please Input Adult Price", vbInformation, "Error Input")
            txtadl.Focus()
            Exit Sub
        End If
        If txtchd.Text = "" Then
            MsgBox("Please Input Child Price", vbInformation, "Error Input")
            txtchd.Focus()
            Exit Sub
        End If

        Dim dstart As Date = txtstart.Value.Date
        Dim dend As Date = txtEnd.Value.Date
        Dim sdate As Date = dstart
        Dim sql, ddate As String
        Dim strSql As String
        If txtno.Text = "" Then
            If cxField("NoEvent", "special", "StartDate='" & Str2Date(txtstart.Text) & "' and EndDate='" & Str2Date(txtEnd.Text) & "'") = 0 Then
                NoEvents()
                strSql = "insert into special (NoEvent,StartDate,EndDate,Adult,Child,Infant,FOC,User,AgentID,Name,Max) values('" & txtno.Text & "','" & Str2Date(txtstart.Text) & "','" & Str2Date(txtEnd.Text) & "'," & NZx(txtadl.Text) & "," & NZx(txtchd.Text) & "," & NZx(txtinf.Text) & "," & NZx(txtfoc.Text) & ",'" & usr & "','" & cboGorute.SelectedItem("AgentID").ToString & "','" & txtname.Text & "'," & NZx(txtsit.Text) & ")"
            Else
                Dim NoEvent As String = GetField("NoEvent", "special", "StartDate='" & Str2Date(txtstart.Text) & "' and EndDate='" & Str2Date(txtEnd.Text) & "',RuteID=" & cboGorute.SelectedItem("RuteID").ToString & ")")
                strSql = "insert into special (NoEvent,StartDate,EndDate,Adult,Child,Infant,FOC,User,AgentID,Name,Max) values('" & txtno.Text & "','" & Str2Date(txtstart.Text) & "','" & Str2Date(txtEnd.Text) & "'," & NZx(txtadl.Text) & "," & NZx(txtchd.Text) & "," & NZx(txtinf.Text) & "," & NZx(txtfoc.Text) & ",'" & usr & "','" & cboGorute.SelectedItem("AgentID").ToString & "','" & txtname.Text & "'," & NZx(txtsit.Text) & ")"
                'strSql = "update special set Adult='" & txtadl.Text & "',Child='" & txtchd.Text & "' where NoEvent='" & NoEvent & "'"
            End If
        Else
            'strSql = "update special set Adult='" & txtadl.Text & "',Child='" & txtchd.Text & "',INFANT='" & txtinf.Text & "',FOC='" & txtfoc.Text & "' where NoEvent='" & txtno.Text & "'"
            strSql = "insert into special (NoEvent,StartDate,EndDate,Adult,Child,Infant,FOC,User,AgentID,Name,Max) values('" & txtno.Text & "','" & Str2Date(txtstart.Text) & "','" & Str2Date(txtEnd.Text) & "'," & NZx(txtadl.Text) & "," & NZx(txtchd.Text) & "," & NZx(txtinf.Text) & "," & NZx(txtfoc.Text) & ",'" & usr & "','" & cboGorute.SelectedItem("AgentID").ToString & "','" & txtname.Text & "'," & NZx(txtsit.Text) & ")"
        End If
        While (sdate <= dend)
            ddate = Str2Date(sdate)

            sql = "insert into specialDtl(NoEvent,Date,Adl,Chd,Infant,FOC,AgentID,Name,max)values('" & txtno.Text & "','" & ddate & "'," & NZx(txtadl.Text) & "," & NZx(txtchd.Text) & "," & NZx(txtinf.Text) & "," & NZx(txtfoc.Text) & ",'" & cboGorute.SelectedItem("AgentID").ToString & "','" & txtname.Text & "'," & NZx(txtsit.Text) & ")"

            Try
                Call ConnectDatabase()
                Dim Cmd As MySqlCommand = New MySqlCommand(sql, conn)
                Cmd.ExecuteNonQuery()
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try

            sdate = DateAdd(DateInterval.Day, 1, sdate)
        End While
        Try

            Call ConnectDatabase()

            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Comd.ExecuteNonQuery()
            Dim strLog As String = ""

            If cmdSave.Text = "&Save" Then
                strLog = " No." & txtno.Text
                FillLog(usr, "Add special Event", strLog, "", "")
            ElseIf cmdSave.Text = "&Update" Then
                strLog = "StartDate =" & txtstart.Text & ", Adl=" & txtadl.Text & ", Chd=" & txtchd.Text & ", Infant=" & txtinf.Text & ", FOC=" & txtfoc.Text & " ,Rute = " & cboGorute.SelectedItem("AgentID").ToString & ""

                FillLog(usr, "Update Special Event", "No." & txtno.Text, "", strLog)
            End If

            Call DisconnectDatabase()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
        'LsData.Rows.Clear()
        txtno.Text = ""
        fillData()
    End Sub


    Private Sub frmPromo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillData()
        GroupBox2.Visible = False
        GroupBox1.Visible = True
        cmdAdd.Enabled = True
        cmdUpdate.Enabled = True
        cmdDel.Enabled = True
        Call fillRute()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        GroupBox1.Visible = False
        GroupBox2.Visible = True
        cmdSave.Text = "&Save"
        cmdAdd.Enabled = False
        cmdUpdate.Enabled = False
        cmdDel.Enabled = False
        txtno.Text = ""
        txtstart.Text = ""
        txtEnd.Text = ""
        txtadl.Text = ""
        txtchd.Text = ""
        txtinf.Text = ""
        txtfoc.Text = ""

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        GroupBox2.Visible = False
        GroupBox1.Visible = True
        cmdAdd.Enabled = True
        cmdUpdate.Enabled = True
        cmdDel.Enabled = True
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If LsData.RowCount = 0 Then
            MsgBox("No Data To Update", vbInformation, "Data")
            Exit Sub
        End If
        If LsData.CurrentCell.ToString = "" Then
            MsgBox("Please Choose Data to Update", vbInformation, "Data")
            Exit Sub
        End If
        LsData.Enabled = False
        txtno.Text = LsData.CurrentRow.Cells(0).Value
        txtstart.Text = LsData.CurrentRow.Cells(2).Value
        txtname.Text = LsData.CurrentRow.Cells(1).Value
        txtEnd.Text = LsData.CurrentRow.Cells(3).Value
        txtadl.Text = LsData.CurrentRow.Cells(4).Value
        txtchd.Text = LsData.CurrentRow.Cells(5).Value
        txtinf.Text = LsData.CurrentRow.Cells(6).Value
        txtfoc.Text = LsData.CurrentRow.Cells(7).Value
        txtsit.Text = LsData.CurrentRow.Cells(10).Value
        cboGorute.Text = LsData.CurrentRow.Cells(9).Value
        strLogs = " From Date Start :`" & LsData.CurrentRow.Cells(1).Value & "` to : `" & LsData.CurrentRow.Cells(2).Value & "`, with Adl : `" & LsData.CurrentRow.Cells(3).Value & "`, Chd : `" & LsData.CurrentRow.Cells(4).Value & "`, Infant: `" & LsData.CurrentRow.Cells(5).Value & "`, FOC : `" & LsData.CurrentRow.Cells(6).Value & "`, Rute : `" & cboGorute.Text & "` "

        GroupBox1.Visible = False
        GroupBox2.Visible = True
        cmdSave.Text = "&Update"
        cmdAdd.Enabled = False
        cmdUpdate.Enabled = False
        cmdDel.Enabled = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtadl.Text = "" Then
            MsgBox("Please Input Adult Price", vbInformation, "Adult Price")
            Exit Sub
        End If
        If txtchd.Text = "" Then
            MsgBox("Please Input Child Price", vbInformation, "Child Price")
            Exit Sub
        End If
        If txtname.Text = "" Then
            MsgBox("Please Input Promo Name", vbInformation, "Promo Name")
            Exit Sub
        End If
        If cmdSave.Text = "&Save" Then
            save()
        ElseIf cmdSave.Text = "&Update" Then
            Dim sql As String = "delete from special where NoEvent='" & txtno.Text & "'"
            Dim sql1 As String = "delete from specialdtl where NoEvent='" & txtno.Text & "'"
            Try
                Call ConnectDatabase()
                Dim Cmd As MySqlCommand = New MySqlCommand(sql, conn)
                Cmd.ExecuteNonQuery()
                Dim Cmd2 As MySqlCommand = New MySqlCommand(sql1, conn)
                Cmd2.ExecuteNonQuery()
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
            save()
        End If
        cmdAdd.Enabled = True
        cmdUpdate.Enabled = True
        cmdDel.Enabled = True
        GroupBox1.Visible = True
        GroupBox2.Visible = False
        fillData()
        LsData.Enabled = True
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        If MsgBox("Are You Sure to delete selected Special Event??", vbYesNo, "Delete Data") = vbYes Then
            Dim sql As String = "delete from special where NoEvent='" & LsData.CurrentRow.Cells(0).Value & "'"
            Dim sql1 As String = "delete from specialdtl where NoEvent='" & LsData.CurrentRow.Cells(0).Value & "'"
            Try
                Call ConnectDatabase()
                Dim Cmd As MySqlCommand = New MySqlCommand(sql, conn)
                Cmd.ExecuteNonQuery()
                Dim Cmd2 As MySqlCommand = New MySqlCommand(sql1, conn)
                Cmd2.ExecuteNonQuery()
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
            fillData()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call ConnectDatabase()
        'LsData.Rows.Clear()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select special.NoEvent,special.Name,special.StartDate,special.EndDate,special.Adult,special.Child,special.Infant,special.FOC,special.AgentID,agent.AgentName as Agent,max as Maximum from special inner join agent on special.agentid=agent.agentid where (special.StartDate between '" & Str2Date(txtstart.Text) & "' and '" & Str2Date(txtEnd.Text) & "') and (special.EndDate between '" & Str2Date(txtstart.Text) & "' and '" & Str2Date(txtEnd.Text) & "') order by NoEvent desc", conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.ReadOnly = True
        LsData.Columns(7).Visible = False
        Call DisconnectDatabase()
    End Sub
End Class