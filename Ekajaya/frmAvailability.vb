Imports MySql.Data.MySqlClient
Imports System.Data
Public Class frmAvailability

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        If txtTotal.Text = "" Then
            MsgBox("Please set Available Sit?", vbInformation, "Error")
            txtTotal.Focus()
            Exit Sub
        End If
        Dim dstart As Date = txtstart.Value.Date
        Dim dend As Date = txtend.Value.Date
        Dim sdate As Date = dstart
        Dim sql, ddate As String

        While (sdate <= dend)
            ddate = Str2Date(sdate)
            If cxField("tgl", "availability", "tgl='" & ddate & "'") = 0 Then
                sql = "insert into availability(tgl,TTLSit)values('" & ddate & "'," & txtTotal.Text & ")"
            Else
                sql = "update availability set TTLSit=" & txtTotal.Text & " where Tgl='" & ddate & "'"
            End If
            Try
                Call ConnectDatabase()
                Dim Cmd As MySqlCommand = New MySqlCommand(sql, conn)
                Cmd.ExecuteNonQuery()
                Dim strLog As String
                strLog = "Set Alotment Date : " & ddate & " = " & txtTotal.Text
                FillLog(usr, "Set Seat Allocation", strLog, "", "")
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try

            sdate = DateAdd(DateInterval.Day, 1, sdate)
        End While
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        MsgBox("Process is under Constuction",vbInformation,"Ups Sorry...")
    End Sub
End Class