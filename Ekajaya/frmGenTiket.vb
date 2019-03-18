Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient


Public Class frmGenTiket

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        If txtstart.Text = "" Then
            MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
            txtstart.Focus()
            Exit Sub
        ElseIf Len(txtstart.Text) < 11 Then
            MsgBox("Please Fill Start Tiket", vbInformation, "Start Tiket Empty")
            txtstart.Focus()
            Exit Sub
        End If
        If txtend.Text = "" Then
            MsgBox("Please Fill End Tiket", vbInformation, "End Tiket Empty")
            txtend.Focus()
            Exit Sub
        ElseIf Len(txtend.Text) < 11 Then
            MsgBox("Please Fill End Tiket", vbInformation, "End Tiket Empty")
            txtend.Focus()
            Exit Sub
        End If
        Dim a, b As Integer
        Dim str As String
        str = txtstart.Text
        b = Val(Mid(txtend.Text, 6, 6))
        For a = Val(Mid(txtstart.Text, 6, 6)) To b

            Try
                Call ConnectDatabase()

                Dim strSQL As String
                Dim cmd As MySqlCommand
                If cxField("NoTiket", "ticket", "notiket='" & str & "'") = 0 Then
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If
                    strSQL = "Insert into ticket (NoTiket,TipeTiket) value ('" & str & "','" & Mid(cbotipe.Text, 1, 2) & "')"
                    cmd = New MySqlCommand(strSQL, conn)
                    cmd.ExecuteScalar()
                End If
                Call DisconnectDatabase()
            Catch ex As SqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
            Dim s As Integer = Val(Mid(str, 6, 6)) + 1
            str = Mid(str, 1, 5) & numx(s, 6)
        Next
        MsgBox("Generate " & txtstart.Text & " to " & txtend.Text & " Success", vbInformation, "Success")

    End Sub

    Private Sub txtstart_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstart.LostFocus
        txtstart.Text = UCase(txtstart.Text)
    End Sub

    Private Sub txtend_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtend.LostFocus
        txtend.Text = UCase(txtend.Text)
    End Sub

    Private Sub txtstart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstart.TextChanged
        If cbotipe.Text = "" Then
            MsgBox("Please Select Ticket Type", vbInformation, "Tiket Type Empty")
        End If
    End Sub

    
    Private Sub frmGenTiket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class