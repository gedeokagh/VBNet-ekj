Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class frmArea
    Dim Cmd As MySqlCommand
    Sub cls()
        txttrip.Text = ""
    End Sub
    Sub fillData()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AreaID,AreaName from area", conn)
        dt = New DataTable
        da.Fill(dt)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        lsData.Columns(0).ReadOnly = True
        lsData.Columns(1).ReadOnly = True

        Call DisconnectDatabase()
    End Sub

    Private Sub frmTrip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillData()
        cls()
        GB3.Visible = False
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Hide()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        cls()

        GB3.Visible = True
        GB3.Enabled = True
        txttrip.Focus()
        lsData.Enabled = False
        GroupBox1.Enabled = False
    End Sub

    Private Sub txttrip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttrip.LostFocus
        txttrip.Text = UCase(txttrip.Text)
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
        txtID.Text = lsData.CurrentRow.Cells(0).Value
        txttrip.Text = lsData.CurrentRow.Cells(1).Value
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
                    Dim chk = cxField("AreaName", "area", "AreaName='" & UCase(txttrip.Text) & "'")
                    If chk = 1 Then
                        MsgBox("Area sudah ada sebelumnya", vbOKOnly, "Error Trip")
                        Exit Sub
                    End If
                    ''MsgBox(div(0), vbOKOnly, )
                    Dim strSql As String
                    Call ConnectDatabase()
                    strSql = "insert into area(`AreaName`)values('" & txttrip.Text & "')"
                    Cmd = New MySqlCommand(strSql, conn)
                    Cmd.ExecuteScalar()
                    FillLog(usr, "Add New Area", "AreaName: : " & txttrip.Text & " ", "", "")
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
                    Dim cpss = GetField("AreaName", "area", "areaID='" & txtID.Text & "'")

                    Call ConnectDatabase()
                    strSql = "update area set AreaName='" & txttrip.Text & "' where AreaID='" & txtID.Text & "'"
                    Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                    Comd.ExecuteNonQuery()
                    Dim strLog As String
                    strLog = ""
                    If txttrip.Text <> cpss Then
                        strLog = strLog & " Change AreaName from `" & cpss & "` to `" & txttrip.Text & "`"
                    End If
                    FillLog(usr, "Update Area", strLog, "AreaName = " & cpss & "", "AreaName =" & txttrip.Text & "")
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

    End Sub

End Class