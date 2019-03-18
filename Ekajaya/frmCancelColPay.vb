Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmCancelColPay
    Sub BookcOLL()
        Dim x = cxField("NoCollect", "colpay", "NoCollect Like 'EJC/" & GetField("TCode", "user", "username='" & usr & "'") & "-%'")
        If x = 0 Then
            txtNoBook.Text = "EJC/" & GetField("TCode", "user", "username='" & usr & "'") & "-000001"
        Else
            ''Dim Lst = Val(Mid(DLast("noBooking", "booking", "nobooking Like 'EKJ/" & GetField("TCode", "user", "username='" & usr & "'") & "%'"), 8, 6)) + 1
            Dim Lst = DLast("NoCollect", "colpay", "NoCollect Like 'EJC/" & GetField("TCode", "user", "username='" & usr & "'") & "-%'")
            Dim lenX = Len(Lst)
            Lst = Val(Mid(Lst, lenX - 5, 6) + 1)
            txtNoBook.Text = "EJC/" & GetField("TCode", "user", "username='" & usr & "'") & "-" & numx(Lst, 6)
        End If

    End Sub
    Sub fillagent()
        'cboAgent.Items.Add(0)
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select AgentID,AgentName from agent where status=1", conn)
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
        Dim WHR As String = ""
        If cboAgent.Text = "" Then
        Else
            WHR = WHR & " aND ((tiketdtl.aGENTid)='" & cboAgent.SelectedItem("AgentID").ToString & "') "
        End If
        If cbotrip.Text = "" Then
        Else
            If WHR = "" Then
                WHR = WHR & " aND ((tiketdtl.goTrip)='" & cbotrip.SelectedItem("TripID").ToString & "') "
            Else
                WHR = WHR & " AND ((tiketdtl.GoTrip)='" & cbotrip.SelectedItem("TripID").ToString & "') "
            End If
        End If
        If txtNoBook.Text = "" Then
        Else
            If WHR = "" Then
                WHR = " AND ((tiketdtl.NoCollect)='" & txtNoBook.Text & "') "
            Else
                WHR = WHR & " AND ((tiketdtl.NoCollect)='" & txtNoBook.Text & "') "
            End If
            'WHR = "AND ((tiketdtl.GoTrip)='" & cbotrip.SelectedItem("TripID").ToString & "') and nocollect='" & txtNoBook.Text & "' "
        End If
       
        

        lsData.Columns.Clear()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        Dim sql As String = "SELECT 0 AS ID, tiketdtl.NoETiket AS NoETiket,tiketdtl.NoTiket AS NoTiket, AGENT.`AgentName`,tiketdtl.GoDate AS DateGo, trip.TripName AS GoTrip, rute.RuteName AS RuteGo,tiketdtl.NoCollect,tiketdtl.TotalJual ,tiketdtl.TotalCollect,tiketdtl.Komisi  FROM (((trip INNER JOIN tiketdtl ON trip.TripID = tiketdtl.GoTrip) INNER JOIN rute ON tiketdtl.GoRuteID = rute.RuteID)INNER JOIN agent ON agent.`AgentID`=tiketdtl.`AgentID` )   WHERE  ((tiketdtl.GoDate)='" & Str2Date(txtdate.Text) & "') and (tiketdtl.NoCollect<>''or Not IsNull(NoCollect)) AND (tiketdtl.NoInv = ''OR ISNULL(tiketdtl.NoInv))   AND (tiketdtl.NoPay = ''OR ISNULL(tiketdtl.NoPay))   AND TIKETDTL.STATUS=1  " & WHR & ""
        da = New MySqlDataAdapter(sql, conn)
        dt = New DataTable
        da.Fill(dt)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = ""
        chk.Name = "ID"
        txttotal.Text = 0
        lsData.Columns.Insert(0, chk)
        lsData.Columns(0).Width = 40
        lsData.Columns(0).ReadOnly = False
        lsData.Columns(2).Width = 150
        lsData.Columns(1).ReadOnly = True
        lsData.Columns(1).Visible = False
        lsData.Columns(2).ReadOnly = True
        lsData.Columns(3).ReadOnly = True
        lsData.Columns(4).ReadOnly = True

        lsData.Columns(5).ReadOnly = True
        lsData.Columns(6).ReadOnly = True
        lsData.Columns(7).ReadOnly = True


        Call DisconnectDatabase()
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmColPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillagent()
        filltrip()
    End Sub

    Private Sub cmdfilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfilter.Click
        filltiket()
    End Sub

    Private Sub lsData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lsData.CellContentClick
        If lsData.Rows(e.RowIndex).Cells(1).Value = 0 Then
            '' MsgBox(LsData.Rows(e.RowIndex.ToString).Cells(5).Value & "Clicked", vbOKOnly, "Process")
            txttotal.Text = Val(txttotal.Text) + Val(lsData.Rows(e.RowIndex).Cells(7).Value)
            lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 1
            Exit Sub
        Else
            txttotal.Text = Val(txttotal.Text) - Val(lsData.Rows(e.RowIndex).Cells(7).Value)
            lsData.Rows(e.RowIndex.ToString).Cells(1).Value = 0
            Exit Sub
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Dim I As Integer = lsData.RowCount
        Dim a, x As Integer
        Dim stSql As String
        BookcOLL()
        ''Dim dtx, dty As Date
        x = 0
        For a = 0 To (I - 1)
            If lsData.Rows(a).Cells(1).Value = 1 Then
                x = x + 1
                Try
                    Call ConnectDatabase()
                    Dim cmd As MySqlCommand
                    'strSql = "insert into coldtl (ID,NoCollect,NoTiket,NoEtiket,Total)value(" & a & ", '" & txtNoBook.Text & "','" & lsData.Rows(a).Cells(3).Value & "','" & lsData.Rows(a).Cells(2).Value & "'," & lsData.Rows(a).Cells(7).Value & ")"
                    'cmd = New MySqlCommand(strSql, conn)
                    'cmd.ExecuteScalar()
                    Dim ttl, tsisa, tkomisi
                    Dim ttlj = NZx(GetField("TotalJual", "tiketdtl", "NoEtiket='" & lsData.Rows(a).Cells(2).Value & "'"))
                    Dim ttlc = NZx(GetField("TotalCollect", "tiketdtl", "NoEtiket='" & lsData.Rows(a).Cells(2).Value & "'"))
                    Dim sisa = NZx(GetField("Sisa", "tiketdtl", "NoEtiket='" & lsData.Rows(a).Cells(2).Value & "'"))

                    'If (ttlc <> 0) Then
                    'ttl = ttlj - (ttlc + lsData.Rows(a).Cells(7).Value)
                    ttlc = ttlc - lsData.Rows(a).Cells(10).Value
                    tsisa = ttlj - ttlc
                    'tsisa = ttlj - ttl
                    If tsisa < 0 Then
                        tkomisi = tsisa * -1
                        tsisa = 0
                    Else
                        tkomisi = 0
                        tsisa = tsisa
                    End If
                    'Else
                    'ttl = lsData.Rows(a).Cells(7).Value
                    'tsisa = ttlj + lsData.Rows(a).Cells(7).Value
                    'If tsisa < 0 Then
                    '    tkomisi = tsisa * -1
                    '    tsisa = 0
                    'Else
                    '    tkomisi = 0
                    '    tsisa = tsisa
                    'End If
                    'End If
            Call ConnectDatabase()
            Dim cmds As MySqlCommand
                    stSql = "Update tiketdtl set  NoCollect='', tglcollect=null,sisa=" & tsisa & ",komisi=" & tkomisi & ",TotalCollect=" & ttlc & " where NoETiket='" & lsData.Rows(a).Cells(2).Value & "'"
            cmds = New MySqlCommand(stSql, conn)
                    cmds.ExecuteScalar()
                    FillLog(usr, "Cancel  Collect", " No.Etiket : " & lsData.Rows(a).Cells(2).Value, "", "")
            Call DisconnectDatabase()
                Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try
            End If
        Next
            Try
               
                If (MsgBox("Process Saved Are You want to Create NewOne?", vbYesNo, "Success")) = vbNo Then
                    Me.Close()
                Else
                    lsData.DataSource = ""
                    fillagent()

                End If
                Call DisconnectDatabase()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                ' Close connection
                Call DisconnectDatabase()
            End Try

    End Sub
End Class