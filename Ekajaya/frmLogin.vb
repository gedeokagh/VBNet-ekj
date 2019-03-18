Imports System.IO

Public Class frmLogin
    Sub login()
        Dim ch = cxField("password", "user", "username='" & txtuser.Text & "'")
        If ch = 1 Then
            Dim cpass = GetField("password", "user", "username='" & txtuser.Text & "'")
            If txtpass.Text = cpass Then
                usr = txtuser.Text
                Select Case GetField("divisi", "user", "username='" & txtuser.Text & "'")
                    Case "1" '''Administrator
                        level = 1
                        frmAdmin.Show()
                    Case "2" '''Accounting
                        level = 2

                        frmAdmin.Show()
                    Case "3" '''AdminReservasi
                        level = 3

                        frmAdminReserv.Show()
                    Case "4" ''''Reservasi
                        level = 4
                        frmAdminRes.Show()
                    Case "5" '''Sales
                        level = 5
                        frmAdmins.Show()
                   
                    Case "6" '''mANAGER
                        level = 6
                        'frmAdminManager.Show()
                        frmAdminMan.Show()
                    Case "7" '''Agent
                        level = 7
                        frmAdminAgent.Show()
                        AgentID = GetField("agentID", "user", "username='" & txtuser.Text & "'")
                End Select

                Me.Hide()
                FillLog(usr, "User Login", usr, "", "")
                Exit Sub
            Else
                MsgBox("Password Salah!!!", vbCritical, "Login Errors")
                Exit Sub
            End If

        Else
            MsgBox("Username Tidak Ditemukan!!!", vbCritical, "Login Errors")
            Exit Sub
        End If
    End Sub

    Sub readfile()
        Dim file As StreamReader
        Dim strLine As String
        Dim strPath As String = AppDomain.CurrentDomain.BaseDirectory
        file = New StreamReader(strPath & "config.inc")
        strLine = file.ReadLine
        msg = ""
        Do While Not strLine Is Nothing
            msg = msg & strLine
            strLine = file.ReadLine
        Loop
        ' MsgBox(msg, vbInformation, "Read File")
        'Close the file.
        file.Close()
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        login()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub txtuser_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuser.LostFocus
        txtuser.Text = UCase(txtuser.Text)
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        readfile()

    End Sub

    Private Sub txtuser_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtuser.PreviewKeyDown
        If e.KeyData = Keys.Enter Then
            txtuser.Text = UCase(txtuser.Text)
            txtpass.Focus()
        End If
    End Sub

    Private Sub txtpass_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtpass.PreviewKeyDown
        If e.KeyData = Keys.Enter Then
            login()
        End If
    End Sub

   
End Class