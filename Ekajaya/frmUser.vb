Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmUser
    Public userlv As Integer
    Dim Cmd As MySqlCommand
    Sub cls()
        txtuser.Text = ""
        txtpass.Text = ""
        cblevel.Text = ""
    End Sub
    Sub fillcombo()
        Call ConnectDatabase()
        Try
            Dim strSql As String
            If userlv = 3 Then
                strSql = "select IDDiv,DivisiName from divisi where IDDiv=3 or IDDiv=4 order by IDDiv"
            Else
                strSql = "select IDDiv,DivisiName from divisi  order by IDDiv"
            End If

            Cmd = New MySqlCommand(strSql, conn)
            Dim rd As MySqlDataReader = Cmd.ExecuteReader
            cblevel.Items.Clear()
            While (rd.Read)
                cblevel.Items.Add(rd("IDDiv").ToString() & " - " & rd("DivisiName").ToString())
            End While
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try

    End Sub
    Sub fillData()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        Dim strSql As String
        If userlv = 3 Then
            strSql = "select user.username as UserName,user.password as Password,divisi.divisiname as Level, IF(user.status=1,'aktif','void') as status, user.divisi from user inner join divisi on user.divisi=divisi.iddiv where user.divisi=3 or user.divisi=4"
        Else
            strSql = "select user.username as UserName,user.password as Password,divisi.divisiname as Level, IF(user.status=1,'aktif','void') as status, user.divisi from user inner join divisi on user.divisi=divisi.iddiv"
        End If
        da = New MySqlDataAdapter(strSql, conn)
        dt = New DataTable
        da.Fill(dt)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        lsData.Columns(0).ReadOnly = True
        lsData.Columns(1).ReadOnly = True
        lsData.Columns(2).ReadOnly = True
        lsData.Columns(3).ReadOnly = True
        lsData.Columns(4).Visible = False
        Call DisconnectDatabase()
    End Sub

    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillData()
        cls()
        GB3.Visible = False
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        cls()
        fillcombo()
        GB3.Visible = True
        GB3.Enabled = True
        txtuser.Focus()
        lsData.Enabled = False
        GroupBox1.Enabled = False
        txtuser.Enabled = True
        txtuser.Focus()
    End Sub

    Private Sub txtuser_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuser.LostFocus
        txtuser.Text = UCase(txtuser.Text)
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        GB3.Visible = False
        GB2.Enabled = True
        GroupBox1.Enabled = True
        lsData.Enabled = True
        'lsData.Rows.Clear()
        fillData()
    End Sub

    Private Sub lsData_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles lsData.CellFormatting
        Dim i As Integer
        For i = 0 To lsData.Rows.Count() - 1 Step +1
            Dim val As String
            val = lsData.Rows(i).Cells(3).Value
            If val = "void" Then
                lsData.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If lsData.CurrentRow.Cells(3).Value = "void" Then
            MsgBox("User sudah Di Void!" & vbCrLf & " Tidak bisa di Ubah lagi", vbOKOnly, "Error Update")
            Exit Sub
        End If
        txtuser.Text = lsData.CurrentRow.Cells(0).Value
        txtpass.Text = lsData.CurrentRow.Cells(1).Value
        cblevel.Text = lsData.CurrentRow.Cells(4).Value & " - " & lsData.CurrentRow.Cells(2).Value
        cmdSave.Text = "&Update"
        fillcombo()
        GB3.Visible = True
        GB3.Enabled = True
        txtuser.Enabled = False
        lsData.Enabled = False
        GroupBox1.Enabled = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Select Case cmdSave.Text
            Case "&Save"

                Try
                    Dim div
                    div = Split(cblevel.SelectedItem, "-", , CompareMethod.Text)
                    Dim tc = numx(Val(LUser("TCode", "user")) + 1, 3)
                    Dim chk = cxField("username", "user", "username='" & txtuser.Text & "'")
                    If chk = 1 Then
                        MsgBox("Username sudah ada sebelumnya", vbOKOnly, "Error User")
                        Exit Sub
                    End If
                    ''MsgBox(div(0), vbOKOnly, )
                    Dim strSql As String
                    Call ConnectDatabase()
                    strSql = "insert into user(TCode,`username`,`password`,`divisi`,`status`)values('" & tc & "','" & txtuser.Text & "', '" & txtpass.Text & "'," & div(0) & ",1)"
                    Cmd = New MySqlCommand(strSql, conn)
                    Cmd.ExecuteScalar()
                    FillLog(usr, "Add New User  ", "New User=" & txtuser.Text & " ", "", "")
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
                    Dim div
                    div = Split(cblevel.Text, "-", , CompareMethod.Text)
                    ''MsgBox(div(0), vbOKOnly, )
                    Dim strSql As String
                    Dim cpss = GetField("password", "user", "username='" & txtuser.Text & "'")
                    Dim cdiv = GetField("divisi", "user", "username='" & txtuser.Text & "'")
                    Call ConnectDatabase()
                    strSql = "update user set password='" & txtpass.Text & "',divisi='" & div(0) & "' where username='" & txtuser.Text & "'"
                    Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                    Comd.ExecuteNonQuery()
                    Dim strLog As String = ""
                    Dim strOld As String = ""

                    FillLog(usr, "ChangePassword", "", "", "")
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

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        If lsData.CurrentRow.Cells(3).Value = "void" Then
            MsgBox("User sudah Di Void!" & vbCrLf & " Tidak bisa di Void lagi", vbOKOnly, "Error Update")
            Exit Sub
        End If
        Try
            Dim div
            div = lsData.CurrentRow.Cells(0).Value

            Dim strSql As String
            strSql = "update user set status=0 where username='" & div & "'"
            Call ConnectDatabase()
            Cmd = New MySqlCommand(strSql, conn)
            Cmd.ExecuteNonQuery()
            FillLog(usr, " Void User  ", "UserName=" & div, "", "")
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
        fillData()
    End Sub


    Private Sub cmdExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class