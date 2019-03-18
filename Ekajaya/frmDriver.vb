Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class frmDriver
    Dim Cmd As MySqlCommand
    Public back As String
    Sub cls()
        txtket.Text = ""
        txtName.Text = ""
        txtPhone.Text = ""
    End Sub
    Sub fillData()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select DriverID,DriverName,Phone,Note,if(status=0,'void','Active') as Status from driver", conn)
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
            val = lsData.Rows(i).Cells(4).Value
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
        lsData.Enabled = False
        GroupBox1.Enabled = False
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
        txtID.Text = lsData.CurrentRow.Cells(0).Value
        txtName.Text = lsData.CurrentRow.Cells(1).Value
        txtPhone.Text = lsData.CurrentRow.Cells(2).Value
        txtket.Text = lsData.CurrentRow.Cells(3).Value
        txtName.Enabled = False

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
                    Dim chk = cxField("DriverName", "driver", "DriverName='" & UCase(txtName.Text) & "'")
                    If chk = 1 Then
                        MsgBox("Agent sudah ada sebelumnya", vbOKOnly, "Error Agent")
                        Exit Sub
                    End If
                    
                    ''MsgBox(div(0), vbOKOnly, )
                    Dim strSql As String
                    Call ConnectDatabase()
                   
                    strSql = "insert into driver(DriverName,Phone,Note)values('" & txtName.Text & "','" & txtPhone.Text & "','" & txtket.Text & "')"
                    Cmd = New MySqlCommand(strSql, conn)
                    Cmd.ExecuteScalar()
                    FillLog(usr, "Add New Driver", "Add New Driver Name= " & txtName.Text, "", "")
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
                txtName.Enabled = True
                fillData()
                cls()
            Case "&Update"

                Try
                    Dim strSql As String
                    Dim cname = GetField("DriverName", "driver", "DriverID='" & txtID.Text & "'")
                    Dim cphn = GetField("Phone", "driver", "DriverID='" & txtID.Text & "'")
                    Dim cnote = GetField("Note", "driver", "DriverID='" & txtID.Text & "'")

                    Call ConnectDatabase()
                    strSql = "update driver set DriverName='" & txtName.Text & "', Phone='" & txtPhone.Text & "',Note='" & txtket.Text & "' where DriverID='" & txtID.Text & "'"
                    Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                    Comd.ExecuteNonQuery()
                    Dim strLog As String
                    strLog = ""
                    If txtName.Text <> cname Then
                        strLog = strLog & " Change AgentName from `" & cname & "` to `" & txtName.Text & "`"
                    End If
                    If txtPhone.Text <> cphn Then
                        strLog = strLog & " Change Agent Phone to `" & txtPhone.Text & "`"
                    End If
                    If txtket.Text <> cnote Then
                        strLog = strLog & " Change Agent Note to `" & txtket.Text & "`"
                    End If
                    Dim strold = "DriverName=" & cname & ", Phone=" & cphn & ",Note=" & cnote & " where DriverID=" & txtID.Text & ""
                    Dim strnew = "DriverName=" & txtName.Text & ",Phone=" & txtPhone.Text & ",Note=" & txtket.Text & " where DriverID=" & txtID.Text & ""
                    FillLog(usr, "Update Data Driver", strLog, strold, strnew)
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
                txtName.Enabled = True
        End Select
        GroupBox1.Enabled = True
        txtsrc.Text = ""
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        If (MsgBox("Are you sure to Void!" & vbCrLf & " Name : " & lsData.CurrentRow.Cells(1).Value, vbYesNo, "Void Driver")) = vbNo Then
            Exit Sub
        End If
        Try
            Dim div
            div = lsData.CurrentRow.Cells(0).Value

            Dim strSql As String
            strSql = "update driver set status=0 where DriverID='" & div & "'"
            Call ConnectDatabase()
            Cmd = New MySqlCommand(strSql, conn)
            Cmd.ExecuteNonQuery()
            FillLog(usr, "Void Driver", " DriverName : " & lsData.CurrentRow.Cells(1).Value & "-" & lsData.CurrentRow.Cells(0).Value, "", "")
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
        fillData()
    End Sub

    Private Sub txtAgentName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus
        txtName.Text = UCase(txtName.Text)
    End Sub

    Private Sub txtsrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsrc.TextChanged
        If txtsrc.Text <> "" Then
            Call ConnectDatabase()
            Dim da As MySqlDataAdapter
            Dim dt As DataTable
            da = New MySqlDataAdapter("select DriverID,DriverName,Phone,Note,if(status=0,'void','Active') as Status from driver where DriverName like '%" & txtsrc.Text & "%'", conn)
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
            Call DisconnectDatabase()
        End If
    End Sub
End Class