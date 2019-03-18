Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRute
    Dim Cmd As MySqlCommand
    Sub cls()
        txtrute.Text = ""
        txtket.Text = ""
        txtID.Text = ""
        txtket.Text = ""
        txtadl.Text = ""
        txtchd.Text = ""
        txtinf.Text = ""
        txtfoc.Text = ""
    End Sub
    Sub fillport()

        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select PortID,PortName from port order by PortName asc", conn)
        dt = New DataTable
        Dim dr As DataRow = dt.NewRow
        da.Fill(dt)
        dr("PortID") = 0
        dr("PortName") = ""
        dt.Rows.InsertAt(dr, 0)
        cboport.DataSource = dt
        cboport.DisplayMember = "PortName"

        Call DisconnectDatabase()
    End Sub
    Sub fillData()
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter("select rute.RuteID,rute.RuteName,rute.PortStart,port.PortName,rute.Adult,rute.Child,rute.Inf as Infant,rute.foc,rute.Note,IF(rute.TIPE=1,'1 - Reguler(RT/OW)','2 - 3ANGEL') AS TIPE from rute inner join port on rute.PortStart=port.PortID", conn)
        dt = New DataTable
        da.Fill(dt)
        lsData.DataSource = dt
        lsData.AllowUserToAddRows = False
        lsData.AllowUserToDeleteRows = False
        lsData.Columns(0).ReadOnly = True
        lsData.Columns(1).ReadOnly = True
        lsData.Columns(2).ReadOnly = True
        lsData.Columns(2).Visible = False
        lsData.Columns(3).ReadOnly = True
        lsData.Columns(4).ReadOnly = True
        lsData.Columns(5).ReadOnly = True
        lsData.Columns(6).ReadOnly = True
        lsData.Columns(7).ReadOnly = True
        lsData.Columns(8).ReadOnly = True
        lsData.Columns(9).ReadOnly = True
        Call DisconnectDatabase()
    End Sub

    Private Sub frmRute_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillData()
        cls()
        GB3.Visible = False
        fillport()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Hide()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        cls()
        fillport()
        GB3.Visible = True
        GB3.Enabled = True
        txtrute.Focus()
        lsData.Enabled = False
        GroupBox1.Enabled = False
    End Sub

    Private Sub txtrute_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrute.LostFocus
        txtrute.Text = UCase(txtrute.Text)
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

        txtrute.Text = lsData.CurrentRow.Cells(1).Value
        txtket.Text = lsData.CurrentRow.Cells(8).Value
        txtadl.Text = lsData.CurrentRow.Cells(4).Value
        txtchd.Text = lsData.CurrentRow.Cells(5).Value
        txtinf.Text = lsData.CurrentRow.Cells(6).Value
        txtfoc.Text = lsData.CurrentRow.Cells(7).Value
        cboTipe.Text = lsData.CurrentRow.Cells(9).Value
        cboport.Text = lsData.CurrentRow.Cells(3).Value
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
                    Dim chk = cxField("RuteName", "rute", "RuteName='" & txtrute.Text & "'")
                    If chk = 1 Then
                        MsgBox("Rute sudah ada sebelumnya", vbOKOnly, "Error Rute")
                        Exit Sub
                    End If
                    ''MsgBox(div(0), vbOKOnly, )
                    Dim strSql As String
                    Call ConnectDatabase()
                    strSql = "insert into rute(`RuteName`,`Note`,PortStart,Adult,Child,Inf,Foc,tipe)values('" & txtrute.Text & "', '" & txtket.Text & "', " & cboport.SelectedItem("PortID").ToString & "," & txtadl.Text & "," & txtchd.Text & "," & txtinf.Text & "," & txtfoc.Text & "," & Mid(cboTipe.Text, 1, 1) & ")"
                    Cmd = New MySqlCommand(strSql, conn)
                    Cmd.ExecuteScalar()
                    FillLog(usr, "Add New Rute ", "Rute Name: " & txtrute.Text & " ", "", "")
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
                    Dim cpss = GetField("RuteName", "rute", "RuteID='" & txtID.Text & "'")
                    Dim cdiv = GetField("Note", "rute", "RuteID='" & txtID.Text & "'")
                    Dim cadl = GetField("Adult", "rute", "RuteID='" & txtID.Text & "'")
                    Dim cchd = GetField("Child", "rute", "RuteID='" & txtID.Text & "'")
                    Dim cinf = GetField("Inf", "rute", "RuteID='" & txtID.Text & "'")
                    Dim cfoc = GetField("foc", "rute", "RuteID='" & txtID.Text & "'")
                    Dim ctipe = GetField("tipe", "rute", "RuteID='" & txtID.Text & "'")

                    'Dim rID = GetField("PortStart", "rute", "RuteID='" & txtID.Text & "'")
                    Call ConnectDatabase()
                    strSql = "update rute set RuteName='" & txtrute.Text & "',note='" & txtket.Text & "',PortStart=" & cboport.SelectedItem("PortID") & ",Adult=" & txtadl.Text & ",Child=" & txtchd.Text & ",Inf=" & txtinf.Text & ",Foc=" & txtfoc.Text & ",Tipe=" & Mid(cboTipe.Text, 1, 1) & " where RuteID='" & txtID.Text & "'"
                    Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
                    Comd.ExecuteNonQuery()
                    Dim strLog, strold As String
                    strLog = ""
                    strold = ""
                    If txtrute.Text <> cpss Then
                        strold = strold & ",RuteName =" & cpss
                        strLog = strLog & " ,RuteName = " & txtrute.Text & "`"
                    End If
                    If txtket.Text <> cdiv Then
                        strold = strold & ",Note =" & cdiv
                        strLog = strLog & ", Note=" & txtket.Text
                    End If
                    If txtadl.Text <> cadl Then
                        strold = strold & ",Adult =" & cadl
                        strLog = strLog & " Adult=" & txtadl.Text
                    End If
                    If txtchd.Text <> cchd Then
                        strold = strold & ",Child =" & cchd
                        strLog = strLog & " , Child=" & txtchd.Text
                    End If
                    If txtinf.Text <> cinf Then
                        strold = strold & ",Inf =" & cinf
                        strLog = strLog & ", Inf = " & txtinf.Text
                    End If
                    If txtfoc.Text <> cfoc Then
                        strold = strold & ",FOC =" & cfoc
                        strLog = strLog & " ,FOC Price=" & txtfoc.Text
                    End If
                    If Mid(cboTipe.Text, 1, 1) <> ctipe Then
                        strold = strold & ",tipe =" & ctipe
                        strLog = strLog & " ,Tipe=" & Mid(cboTipe.Text, 1, 11)
                    End If

                    FillLog(usr, "Update Rute ", "Change RuteName from " & cpss & " to " & txtrute.Text & "", strold, strLog)
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