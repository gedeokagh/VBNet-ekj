Imports MySql.Data.MySqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmLog
    Sub fillData()
        Dim str As String
        str = "select `Date`,`time`,Logtipe,logs from Userlog where username='" & usr & "' AND  date='" & Str2Date(txtdate.Text) & "'"
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(str, conn)
        dt = New DataTable
        da.Fill(dt)
        LsData.DataSource = dt
        LsData.AllowUserToAddRows = False
        LsData.AllowUserToDeleteRows = False
        LsData.Columns(0).ReadOnly = True
        LsData.Columns(1).ReadOnly = True
        LsData.Columns(2).ReadOnly = True
        LsData.Columns(3).ReadOnly = True
        'LsData.Columns(3).AutoSizeMode = True
        'LsData.Columns(2).AutoSizeMode = True

        Call DisconnectDatabase()
    End Sub
    Private Sub frmLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillData()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        fillData()
    End Sub
End Class