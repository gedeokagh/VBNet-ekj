Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class frmCollectPayment
    Sub BookNo()
        Dim x = cxField("NoCollect", "colpay", "NoCollect Like 'EJC/" & Month(Now) & "/%'")
        If x = 0 Then
            txtno.Text = "EJC/" & Month(Now) & "/000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("NoCollect", "colpay", "NoCollect Like 'EJC/" & Month(Now) & "/%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            txtno.Text = "EJC/" & Month(Now) & "/" & numx(Lst, 6)
        End If

    End Sub
    Private Sub txtstart_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstart.Leave
        txtstart.Text = UCase(txtstart.Text)
    End Sub
    Private Sub txtend_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtend.KeyDown
        If e.KeyData = Keys.Tab Or e.KeyCode = Keys.Enter Then
            txtend.Text = UCase(txtend.Text)
            
            If Len(txtstart.Text) = Len(txtend.Text) Then
                If Mid(txtstart.Text, 1, 4) = Mid(txtend.Text, 1, 4) Then
                    txtttltiket.Text = (Val(Mid(txtend.Text, 6)) - Val(Mid(txtstart.Text, 6))) + 1
                Else
                    MsgBox("Please Check Start and End Tiket" & vbCrLf & "Tipe Ticket Ist'n same!", vbInformation, "Ticket Error")
                    Exit Sub
                End If
            Else
                MsgBox("Please Check Start and End Tiket", vbInformation, "Ticket Error")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtend_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtend.Leave
        txtend.Text = UCase(txtend.Text)
    End Sub

    Private Sub txtend_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtend.PreviewKeyDown
        If e.KeyData = Keys.Tab Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub txtend_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtend.TextChanged
        If txtstart.Text = "" Then
            MsgBox("Please Fill Start Tiket", vbInformation, "Collect Payment")
            txtstart.Focus()
            Exit Sub
        ElseIf Len(txtstart.Text) < 11 Then
            MsgBox("Please Fill Start Tiket", vbInformation, "Collect Payment")
            txtstart.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
        If txtttltiket.Text = "" Or Val(txtttltiket.Text) <= 0 Then
            MsgBox("Please Check Your Tiket!!", vbInformation, "Collect Payment")
            txtstart.Focus()
            Exit Sub
        Else
            txtcoltiket.Text = Val(txtTotal.Text) / Val(txtttltiket.Text)
        End If
    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        If txtttltiket.Text = "" Then
            MsgBox("Please Check Your Tiket!!", vbInformation, "Collect Payment")
            txtstart.Focus()
            Exit Sub
        End If
        If txtcoltiket.Text = "" Then
            MsgBox("Please Check Your Total Collect!!", vbInformation, "Collect Payment")
            txtstart.Focus()
            Exit Sub
        End If
        BookNo()
        Dim a, b, i As Integer
        Dim str As String
        Dim tjual, sisa, komisi As Double
        str = txtstart.Text
        b = Val(Mid(txtend.Text, 6, 6))
        Dim strSQL As String
        Dim cmd As MySqlCommand
        i = 1
        For a = Val(Mid(txtstart.Text, 6, 6)) To b

            Try
                Call ConnectDatabase()


                If cxField("NoTiket", "tiketdtl", "notiket='" & str & "'") = 1 Then

                    tjual = GetField("TotalJual", "tiketdtl", "notiket='" & str & "'")

                    komisi = Val(txtcoltiket.Text) - NZx(tjual)
                    If (komisi <= 0) Then
                        sisa = komisi * -1

                    Else
                        sisa = 0
                    End If
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If
                    strSQL = "Update tiketdtl set NoCollect='" & txtno.Text & "', TotalCollect=" & txtcoltiket.Text & ", sisa=" & sisa & ", komisi=" & komisi & " where NoTiket='" & str & "'"
                    cmd = New MySqlCommand(strSQL, conn)
                    cmd.ExecuteScalar()
                    
                End If
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                strSQL = "insert into coldtl (ID,NoCollect,NoTiket,Total) values(" & i & ",'" & txtno.Text & "','" & str & "'," & txtcoltiket.Text & ")"
                cmd = New MySqlCommand(strSQL, conn)
                cmd.ExecuteScalar()
                Call DisconnectDatabase()
            Catch ex As SqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
            Dim s As Integer = Val(Mid(str, 6, 6)) + 1
            str = Mid(str, 1, 5) & numx(s, 6)
            i = i + 1
        Next

        Call ConnectDatabase()

        strSQL = "insert into colpay(NoCollect,Tgl,StartTiket,EndTiket,Total,Pertiket,user)values('" & txtno.Text & "','" & Str2Date(txttgl.Text) & "','" & txtstart.Text & "','" & txtend.Text & "'," & txtTotal.Text & "," & txtcoltiket.Text & ",'" & usr & "')"
        Cmd = New MySqlCommand(strSql, conn)
        Cmd.ExecuteScalar()
        FillLog(usr, "Add New Collect", " Tiket No.: " & txtno.Text, "", "")
        Call DisconnectDatabase()
        MsgBox("Collect Payment For  " & txtstart.Text & " to " & txtend.Text & " Success", vbInformation, "Success")

    End Sub

    Private Sub frmCollectPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txttgl.Format = DateTimePickerFormat.Custom
        txttgl.CustomFormat = "dd/MM/yyyy"
    End Sub

    
End Class