Imports MySql.Data.MySqlClient
Imports System.Data
Public Class frmColPays
    Sub BookcOLL()
        'Dim x = cxField("NoCollect", "colpay", "NoCollect Like 'EJC/" & GetField("TCode", "user", "username='" & usr & "'") & "-%'")
        Dim x = cxField("NoCollect", "colpay", "NoCollect Like 'EJC/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-%'")
        If x = 0 Then
            'txtNoBook.Text = "EJC/" & GetField("TCode", "user", "username='" & usr & "'") & "-000001"
            txtNoBook.Text = "EJC/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("NoCollect", "colpay", "NoCollect Like 'EJC/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            'txtNoBook.Text = "EJC/" & GetField("TCode", "user", "username='" & usr & "'") & "-" & numx(Lst, 6)
            txtNoBook.Text = "EJC/" & Format(Now, "yy") & "" & Format(Now, "MM") & "-" & numx(Lst, 6)
        End If

    End Sub
    Sub fillPort()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select PortID,PortName from port", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("PortID") = 0
        dr("PortName") = ""
        dt.Rows.InsertAt(dr, 0)
        'da.Fill(dt)
        cboPort.DataSource = dt
        cboPort.DisplayMember = "PortName"

        Call DisconnectDatabase()
    End Sub
    Sub fillagent()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select agent.AgentID,agent.AgentName from agent inner join tiketdtl on agent.agentid=tiketdtl.agentid where tiketdtl.godate='" & Str2Date(txtdate.Text) & "' GROUP BY AGENT.AGENTID", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("AgentID") = 0
        dr("AgentName") = ""
        dt.Rows.InsertAt(dr, 0)
        cboAgent.DataSource = dt
        cboAgent.DisplayMember = "AgentName"

        Call DisconnectDatabase()
    End Sub

    Sub filltrip()

        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select TripID,TripName from trip", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("TripID") = 0
        dr("TripName") = ""
        dt.Rows.InsertAt(dr, 0)
        'da.Fill(dt)
        cbotrip.DataSource = dt
        cbotrip.DisplayMember = "tripName"

        Call DisconnectDatabase()
    End Sub
    Sub filltiket()
        Dim strgo As String
        Dim andx As Boolean = False
        strgo = ""

        If cboAgent.Text = "" Then
        Else
            strgo = " tiketdtl.AgentID='" & cboAgent.SelectedItem("AgentID").ToString & "'"
            andx = True
        End If
        If Trim(txtdate.Text) = "" Then
        Else
            If andx = False Then
                'strgo = " ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                strgo = " (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
                andx = True
            Else
                'strgo = strgo & " and ((tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "') OR (IF (tiketdtl.BackDate='','',tiketdtl.BackDate='" & Str2Date(txtdate.Text) & "')))"
                strgo = strgo & " and (tiketdtl.GoDate='" & Str2Date(txtdate.Text) & "')"
            End If
        End If

        If cboPort.Text = "" Then
        Else
            Dim ctr = cboPort.SelectedItem("PortID")
            If andx = False Then
                'strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                strgo = " (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
                andx = True
            Else
                'strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & ") OR (IF(Tiketdtl.BackRuteID='','',tiketdtl.backRuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))))"
                strgo = strgo & " and (tiketdtl.GORuteID IN (SELECT ruteID FROM rute WHERE PortStart=" & ctr & "))"
            End If
        End If
        If cbotrip.Text = "" Then
        Else
            If andx = False Then
                'strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                strgo = " (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
                andx = True
            Else
                'strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " or tiketdtl.TripBACK=" & cbotrip.SelectedItem("TripID").ToString & ")"
                strgo = strgo & " and  (tiketdtl.GoTrip=" & cbotrip.SelectedItem("TripID").ToString & " )"
            End If
        End If

        lsData.Columns.Clear()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("SELECT tiketdtl.NoETiket as NoETiket,tiketdtl.NoTiket as NoTiket, tiketdtl.GoDate as DateGo, trip.TripName as GoTrip, rute.RuteName as RuteGo,agent.AgentName as Agent, tiketdtl.TotalJual, tiketdtl.ReqCollect, 0 as Collect FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID) INNER JOIN agent ON tiketdtl.AgentID = agent.AgentID )  WHERE    (tiketdtl.NoCollect = '' OR ISNULL(tiketdtl.NoCollect))   AND (tiketdtl.NoInv = ''OR ISNULL(tiketdtl.NoInv))   AND (tiketdtl.NoPay = ''OR ISNULL(tiketdtl.NoPay))  and (tiketdtl.ReqCollect>0) and " & strgo & " ", conn)
        dt = New DataTable
        da.Fill(dt)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        'Dim chk As New DataGridViewCheckBoxColumn()
        'chk.HeaderText = ""
        'chk.Name = "ID"
        txttotal.Text = 0
        'lsData.Columns.Insert(0, chk)
        lsData.Columns(0).ReadOnly = True
        'lsData.Columns(2).Width = 150
        lsData.Columns(1).ReadOnly = True
        'lsData.Columns(1).Visible = False
        lsData.Columns(2).ReadOnly = True
        lsData.Columns(3).ReadOnly = True
        lsData.Columns(4).ReadOnly = True

        lsData.Columns(5).ReadOnly = True
        lsData.Columns(6).ReadOnly = True
        lsData.Columns(7).ReadOnly = True
        lsData.Columns(8).ReadOnly = False
    End Sub
    
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmColPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()
        txttgltrans.Text = Format(Now, "dd/MM/yyyy")
        filltrip()
        fillPort()
    End Sub

    Private Sub cmdfilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfilter.Click
        filltiket()
    End Sub

    Private Sub lsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lsData.CellContentClick
        'If lsData.Rows(e.RowIndex).Cells(0).Value = False Then
        '    '' MsgBox(LsData.Rows(e.RowIndex.ToString).Cells(5).Value & "Clicked", vbOKOnly, "Process")
        '    txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(e.RowIndex).Cells(9).Value)
        '    lsData.Rows(e.RowIndex).Cells(0).Value = True

        '    lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 1
        '    Exit Sub
        'Else
        '    txttotal.Text = Val(txttotal.Text) - Val(lsData.Rows(e.RowIndex).Cells(9).Value)

        '    lsData.Rows(e.RowIndex.ToString).Cells(0).Value = False
        '    lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 0
        '    Exit Sub
        'End If
        'If lsData.Rows(e.RowIndex).Cells(1).Value = 0 Then
        '    '' MsgBox(LsData.Rows(e.RowIndex.ToString).Cells(5).Value & "Clicked", vbOKOnly, "Process")
        '    txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(e.RowIndex).Cells(9).Value)
        '    lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 1
        '    Exit Sub
        'Else
        '    txttotal.Text = Val(txttotal.Text) - Val(lsData.Rows(e.RowIndex).Cells(9).Value)
        '    lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 0
        '    Exit Sub
        'End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If lsData.RowCount = 0 Then
            MsgBox("Please Select data to Collect", vbInformation, "Collect Payment")
            Exit Sub
        End If
        Dim I As Integer = lsData.RowCount
        Dim a, x As Integer
        Dim strSql, stSql As String
        BookcOLL()
        ''Dim dtx, dty As Date
        x = 0
        For a = 0 To (I - 1)
            If lsData.Rows(a).Cells(8).Value > 0 Then
                x = x + 1
                Try
                    Call ConnectDatabase()
                    'Dim cmd As MySqlCommand
                    'strSql = "insert into coldtl (ID,NoCollect,NoTiket,NoEtiket,Total)value(" & a & ", '" & txtNoBook.Text & "','" & lsData.Rows(a).Cells(3).Value & "','" & lsData.Rows(a).Cells(2).Value & "'," & lsData.Rows(a).Cells(9).Value & ")"
                    'cmd = New MySqlCommand(strSql, conn)
                    'cmd.ExecuteScalar()
                    Dim ttl, tsisa, tkomisi
                    'Dim ttlj = NZx(GetField("TotalJual", "tiketdtl", "NoEtiket='" & lsData.Rows(a).Cells(2).Value & "'"))
                    'Dim ttlc = NZx(GetField("TotalCollect", "tiketdtl", "NoEtiket='" & lsData.Rows(a).Cells(2).Value & "'"))
                    Dim ttlj = lsData.Rows(a).Cells(6).Value
                    Dim ttlc = lsData.Rows(a).Cells(8).Value
                    'Dim sisa = NZx(GetField("Sisa", "tiketdtl", "NoEtiket='" & lsData.Rows(a).Cells(2).Value & "'"))

                    'If (sisa <> 0) Then
                    'ttl = ttlc + lsData.Rows(a).Cells(9).Value
                    tsisa = ttlj - ttlc
                    If tsisa <> 0 Then
                        tkomisi = tsisa * -1
                        tsisa = 0
                        stSql = "Update tiketdtl set  NoCollect='" & txtNoBook.Text & "',TglCollect='" & Str2Date(txtdate.Text) & "',sisa=" & tsisa & ",komisi=" & tkomisi & ",TotalCollect=" & lsData.Rows(a).Cells(8).Value & " where NoETiket='" & lsData.Rows(a).Cells(0).Value & "'"
                    Else
                        tkomisi = 0
                        tsisa = tsisa

                        stSql = "Update tiketdtl set  NoCollect='" & txtNoBook.Text & "',TglCollect='" & Str2Date(txtdate.Text) & "',NopAY='" & txtNoBook.Text & "',Tgllunas='" & Str2Date(txtdate.Text) & "',pay=1,sisa=" & tsisa & ",komisi=" & tkomisi & ",TotalCollect=" & lsData.Rows(a).Cells(8).Value & " where NoETiket='" & lsData.Rows(a).Cells(0).Value & "'"
                    End If
                    'Else
                    '    ' ttl = lsData.Rows(a).Cells(9).Value
                    '    'tsisa = ttlj - lsData.Rows(a).Cells(9).Value
                    '    tsisa = ttlj - ttlc
                    '    If tsisa < 0 Then
                    '        tkomisi = tsisa * -1
                    '        tsisa = 0
                    '    Else
                    '        tkomisi = 0
                    '        tsisa = tsisa
                    '    End If
                    'End If
                    Call ConnectDatabase()
                    Dim cmds As MySqlCommand
                    

                    cmds = New MySqlCommand(stSql, conn)
                    cmds.ExecuteScalar()
                    Call DisconnectDatabase()
                Catch ex As MySqlException
                    MsgBox(ex.Message)
                Finally
                    ' Close connection
                    Call DisconnectDatabase()
                End Try
            End If
        Next
        If x > 0 Then
            Try
                Call ConnectDatabase()
                Dim cmd As MySqlCommand
                strSql = "insert into colpay (NoCollect,Tgl,User,Total)value( '" & txtNoBook.Text & "','" & Str2Date(txttgltrans.Text) & "','" & usr & "'," & txttotal.Text & ")"
                cmd = New MySqlCommand(strSql, conn)
                cmd.ExecuteScalar()
                FillLog(usr, "Add Collect", " No.Collect " & txtNoBook.Text, "", "")
                If (MsgBox("Process Saved Are You want to Create NewOne?", vbYesNo, "Success")) = vbNo Then
                    Me.Close()
                Else

                    lsData.DataSource = ""

                    fillagent()
                    txtNoBook.Text = ""
                    txttgltrans.Text = Format(Now, "dd/MM/yyyy")
                End If
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
        Else
            MsgBox("Please Select data to Collect", vbInformation, "Collect Payment")
            Exit Sub
        End If
    End Sub

    Private Sub txtdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdate.ValueChanged
        fillagent()
    End Sub
End Class