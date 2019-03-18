Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class frmAgent
    Dim Cmd As MySqlCommand
    Sub cls()
        txtAgentID.Text = ""
        txtket.Text = ""
        txtAgentName.Text = ""
        txtAddress.Text = ""
        txtPhone.Text = ""
        txtemail.Text = ""
        txtpicname.Text = ""
        txtpicemail.Text = ""
        txtpicmobile.Text = ""
        cxpay.CheckState = CheckState.Unchecked
    End Sub
    Sub fillData()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID,AgentName,Address,Email,Phone,CPName,CPMobile,CPEmail,Note,if(Payment=1,'Cash Only','Allow Credit') as Payment,if(status=0,'void','Active') as Status from agent ORDER BY AgentName Asc", conn)
        dt = New DataTable
        da.Fill(dt)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        lsData.Columns(0).ReadOnly = True
        lsData.Columns(1).ReadOnly = True
        lsData.Columns(2).ReadOnly = True
        lsData.Columns(3).ReadOnly = True
        lsData.Columns(4).ReadOnly = True
        lsData.Columns(5).ReadOnly = True
        lsData.Columns(6).ReadOnly = True
        lsData.Columns(7).ReadOnly = True
        lsData.Columns(8).ReadOnly = True
        lsData.Columns(9).ReadOnly = True
        lsData.Columns(10).ReadOnly = True
        Call DisconnectDatabase()
    End Sub

    Private Sub frmAgent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillData()
        cls()
        GB3.Visible = False
    End Sub
    Private Sub lsData_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles lsData.CellFormatting
        Dim i As Integer
        For i = 0 To lsData.Rows.Count() - 1 Step +1
            Dim val As String
            val = lsData.Rows(i).Cells(10).Value
            If val = "void" Then
                lsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Hide()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        cls()
        txtsrc.Text = ""
        GB3.Visible = True
        GB3.Enabled = True
        txtAgentID.Focus()
        lsData.Enabled = False
        GroupBox1.Enabled = False
    End Sub

    Private Sub txtAgentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAgentID.LostFocus
        txtAgentID.Text = UCase(txtAgentID.Text)
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        GB3.Visible = False
        GB2.Enabled = True
        GroupBox1.Enabled = True
        lsData.Enabled = True
        'lsData.Rows.Clear()
        fillData()
    End Sub


    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        txtsrc.Text = ""
        txtAgentID.Text = lsData.CurrentRow.Cells(0).Value
        txtAgentName.Text = lsData.CurrentRow.Cells(1).Value
        txtAddress.Text = lsData.CurrentRow.Cells(2).Value
        txtemail.Text = lsData.CurrentRow.Cells(3).Value
        txtPhone.Text = lsData.CurrentRow.Cells(4).Value
        txtpicname.Text = lsData.CurrentRow.Cells(5).Value
        txtpicmobile.Text = lsData.CurrentRow.Cells(6).Value
        txtpicemail.Text = lsData.CurrentRow.Cells(7).Value
        txtket.Text = lsData.CurrentRow.Cells(8).Value
        If (lsData.CurrentRow.Cells(9).Value) = "Allow Credit" Then
            cxpay.CheckState = CheckState.Checked
        Else
            cxpay.CheckState = CheckState.Unchecked
        End If

        cmdSave.Text = "&Update"
        GB3.Visible = True
        GB3.Enabled = True
        lsData.Enabled = False
        GroupBox1.Enabled = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Select Case cmdSave.Text
            Case "&Save"
                Try
                    Dim chk = cxField("AgentName", "agent", "AgentName='" & UCase(txtAgentName.Text) & "'")
                    If chk = 1 Then
                        MsgBox("Agent sudah ada sebelumnya", vbOKOnly, "Error Agent")
                        Exit Sub
                    End If
                    Dim chk2 = cxField("AgentID", "agent", "AgentID='" & UCase(txtAgentID.Text) & "'")
                    If chk2 = 1 Then
                        MsgBox("AgentID sudah Digunakan sebelumnya", vbOKOnly, "Error Agent")
                        Exit Sub
                    End If
                    ''MsgBox(div(0), vbOKOnly, )
                    Dim strSql As String
                    Call ConnectDatabase()
                    Dim pays As Char
                    If cxpay.CheckState = CheckState.Checked Then
                        pays = "2"
                    Else
                        pays = "1"
                    End If
                    strSql = "insert into agent(AgentID,AgentName,Address,Email,Phone,CPName,CPMobile,CPEmail,Note,Payment)values('" & txtAgentID.Text & "','" & txtAgentName.Text & "','" & txtAddress.Text & "','" & txtemail.Text & "','" & txtPhone.Text & "', '" & txtpicname.Text & "', '" & txtpicmobile.Text & "', '" & txtpicemail.Text & "', '" & txtket.Text & "', '" & pays & "')"
                    Cmd = New MySqlCommand(strSql, conn)
                    Cmd.ExecuteScalar()
                    FillLog(usr, "Add New Agent", "Add New Agent : " & txtAgentID.Text & ", Name= " & txtAgentName.Text, "", "")
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

                fillData()
                cls()
            Case "&Update"

                Try
                    Dim strSql As String
                    Dim cname = GetField("AgentName", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim caddr = GetField("Address", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim cphn = GetField("Phone", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim cnote = GetField("Note", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim cemail = GetField("email", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim cpname = GetField("CPName", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim cpmbl = GetField("CPMobile", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim cpmail = GetField("CPEmail", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim cpay = GetField("Payment", "agent", "AgentID='" & txtAgentID.Text & "'")
                    Dim pays As Char
                    If cxpay.CheckState = CheckState.Checked Then
                        pays = "2"
                    Else
                        pays = "1"
                    End If
                    Call ConnectDatabase()
                    strSql = "update agent set AgentName='" & txtAgentName.Text & "',Address='" & txtAddress.Text & "',phone='" & txtPhone.Text & "',Note='" & txtket.Text & "',email='" & txtemail.Text & "',CPName='" & txtpicname.Text & "',CPEmail='" & txtpicemail.Text & "',CPMobile='" & txtpicmobile.Text & "',Payment='" & pays & "' where AgentID='" & txtAgentID.Text & "'"
                    Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                    Comd.ExecuteNonQuery()
                    Dim strLog As String
                    strLog = ""
                    If txtAgentName.Text <> cname Then
                        strLog = strLog & " Change AgentName from `" & cname & "` to `" & txtAgentName.Text & "`"
                    End If
                    If txtAddress.Text <> caddr Then
                        strLog = strLog & " Change Agent Address from `" & caddr & "` to `" & txtAddress.Text & "`"
                    End If
                    If txtPhone.Text <> cphn Then
                        strLog = strLog & " Change Agent Phone to `" & txtPhone.Text & "`"
                    End If
                    If txtket.Text <> cnote Then
                        strLog = strLog & " Change Agent Note to `" & txtket.Text & "`"
                    End If
                    If txtemail.Text <> cemail Then
                        strLog = strLog & " Change Agent Email to `" & txtemail.Text & "`"
                    End If
                    If txtpicname.Text <> cpname Then
                        strLog = strLog & " Change Agent PIC Name to `" & txtpicname.Text & "`"
                    End If
                    If txtpicemail.Text <> cpmail Then
                        strLog = strLog & " Change Agent PIC Email to `" & txtpicemail.Text & "`"
                    End If
                    If txtpicmobile.Text <> cpmbl Then
                        strLog = strLog & " Change Agent PIC Mobile  to `" & txtpicmobile.Text & "`"
                    End If
                    If pays <> cpay Then

                        strLog = strLog & " Change Payment `" & pays & "`"
                        
                       
                    End If
                    Dim strold = "AgentName=" & cname & ",Address=" & caddr & ",Phone=" & cphn & ",Note=" & cnote & ",email=" & cemail & ",CPName=" & cpname & ",CPMobile=" & cpmbl & ",CPEmail=" & cpmail & ",Payment=" & cpay & " where AgentID=" & txtAgentID.Text & ""
                    Dim strnew = "AgentName=" & txtAgentName.Text & ",Address=" & txtAddress.Text & ",Phone=" & txtPhone.Text & ",Note=" & txtket.Text & ",email=" & txtemail.Text & ",CPName=" & txtpicname.Text & ",CPMobile=" & txtpicmobile.Text & ",CPEmail=" & txtpicmobile.Text & ",Payment=" & pays & " where AgentID=" & txtAgentID.Text & ""
                    FillLog(usr, "Update Data Agent", strLog, strold, strnew)
                    Call DisconnectDatabase()
                Catch ex As SqlException
                    MsgBox(ex.Message)
                Finally
                    ' Close connection
                    Call DisconnectDatabase()
                End Try
                GroupBox1.Enabled = False
                GB3.Visible = False
                lsData.Enabled = True
                fillData()
                cls()
                cmdSave.Text = "&Save"
        End Select
        GroupBox1.Enabled = True
        txtsrc.Text = ""
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        If (MsgBox("Are you sure to Void!" & vbCrLf & " Agent : " & lsData.CurrentRow.Cells(1).Value, vbYesNo, "Error Update")) = vbNo Then
            Exit Sub
        End If
        Try
            Dim div
            div = lsData.CurrentRow.Cells(0).Value

            Dim strSql As String
            strSql = "update agent set status=0 where AgentID='" & div & "'"
            Call ConnectDatabase()
            Cmd = New MySqlCommand(strSql, conn)
            Cmd.ExecuteNonQuery()
            FillLog(usr, "Void Agent", " AgentName : " & lsData.CurrentRow.Cells(1).Value & "-" & lsData.CurrentRow.Cells(0).Value, "", "")
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
        fillData()
    End Sub

    Private Sub txtAgentName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAgentName.LostFocus
        txtAgentName.Text = UCase(txtAgentName.Text)
    End Sub

    Private Sub txtsrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsrc.TextChanged
        If txtsrc.Text <> "" Then
            Call ConnectDatabase()
            Dim da As MySqlDataAdapter
            Dim dt As DataTable
            da = New MySqlDataAdapter("select AgentID,AgentName,Address,Email,Phone,CPName,CPMobile,CPEmail,Note,if(Payment=1,'Cash Only','Allow Credit') as Payment,if(status=0,'void','Active') as Status from agent where AgentName like '%" & txtsrc.Text & "%'", conn)
            dt = New DataTable
            da.Fill(dt)
            lsData.DataSource = dt
            lsData.AllowUserToAddRows = False
            lsData.AllowUserToDeleteRows = False
            lsData.Columns(0).ReadOnly = True
            lsData.Columns(1).ReadOnly = True
            lsData.Columns(2).ReadOnly = True
            lsData.Columns(3).ReadOnly = True
            lsData.Columns(4).ReadOnly = True
            lsData.Columns(5).ReadOnly = True
            lsData.Columns(6).ReadOnly = True
            lsData.Columns(7).ReadOnly = True
            lsData.Columns(8).ReadOnly = True
            lsData.Columns(9).ReadOnly = True
            lsData.Columns(10).ReadOnly = True
            Call DisconnectDatabase()
        End If
    End Sub

   
    Private Sub cmdact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdact.Click
        If (MsgBox("Are you sure to RE-ACTIVATED! " & vbCrLf & "Agent : " & lsData.CurrentRow.Cells(1).Value, vbYesNo, "Error Update")) = vbNo Then
            Exit Sub
        End If
        Try
            Dim div
            div = lsData.CurrentRow.Cells(0).Value

            Dim strSql As String
            strSql = "update agent set status=1 where AgentID='" & div & "'"
            Call ConnectDatabase()
            Cmd = New MySqlCommand(strSql, conn)
            Cmd.ExecuteNonQuery()
            FillLog(usr, "Void Agent", " AgentName : " & lsData.CurrentRow.Cells(1).Value & "-" & lsData.CurrentRow.Cells(0).Value, "", "")
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
        fillData()
    End Sub
End Class