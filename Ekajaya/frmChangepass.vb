Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient


Public Class frmChangepass
    Dim old As String = GetField("password", "user", "username='" & usr & "'")

    Private Sub frmChangepass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpass.Text = old
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If txtnpass.Text = "" Then
            MsgBox("Please Fill New Password", vbInformation, "Change Password")
            txtnpass.Focus()
            Exit Sub
        
        End If
        

            Try
                Call ConnectDatabase()

                Dim strSQL As String
                Dim cmd As MySqlCommand

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            strSQL = "Update user set password='" & txtnpass.Text & "' where username='" & usr & "'"
            cmd = New MySqlCommand(strSQL, conn)
            cmd.ExecuteScalar()

            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
        FillLog(usr, "Change Password", "", "", "")
        MsgBox("Change Password  Success", vbInformation, "Success")

    End Sub
End Class