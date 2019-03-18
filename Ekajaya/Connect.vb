Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Module Connect
    Public conn As New MySqlConnection
    Public usr, AgentID As String
    Public msg As String
    Public level As Integer
    Public Sub ConnectDatabase()

        'Try
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = msg & ";charset=utf8;Convert Zero Datetime=true"
            
            conn.Open()
        End If

    End Sub

    Public Sub DisconnectDatabase()
        Try
            conn.Close()
        Catch myerror As MySql.Data.MySqlClient.MySqlException

        End Try
    End Sub

    Public Function GetField(ByVal strField As String, ByVal strTable As String, ByVal strCriteria As String)
        Call ConnectDatabase()
        Try
            Dim strSql As String
            strSql = "select `" & strField & "` from `" & strTable & "` where " & strCriteria
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim reader As MySqlDataReader = Comd.ExecuteReader
            While (reader.Read)
                GetField = reader(strField).ToString()

            End While
            reader.Close()
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try

    End Function
    Public Function cxField(ByVal strField As String, ByVal strTable As String, ByVal strCriteria As String)
        Call ConnectDatabase()
        Try
            Dim strSql As String
            strSql = "select count(`" & strField & "`) from `" & strTable & "` where " & strCriteria
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim reader As Integer = Comd.ExecuteScalar
            cxField = reader
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try

    End Function

    Public Function ChField(ByVal strQry As String)
        Call ConnectDatabase()
        Try
            Dim strSql As String
            strSql = strQry
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim reader = Comd.ExecuteScalar
            ChField = reader
            'reader.Close()
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try

    End Function

    Public Function FillLog(ByVal strUsr As String, ByVal strLogTYPE As String, ByVal strLog As String, ByVal OldVal As String, ByVal NewVal As String)
        Call ConnectDatabase()
        Try
            Dim strSql As String
            strSql = "insert into userlog (username,Date,time,LogTipe,logs,OldValue,NewValue) values('" & strUsr & "',CURDATE(),CURTIME(),'" & strLogTYPE & "','" & strLog & "','" & OldVal & "','" & NewVal & "')"

            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Comd.ExecuteScalar()
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try

    End Function
    Public Function numx(ByVal vals, ByVal leng)
        Dim x As Integer
        Dim s As String
        x = 1
        s = ""
        While x <= leng
            s = s & "0"
            x = x + 1
        End While
        numx = Format(vals, s)
    End Function
    Public Function DLast(ByVal strField As String, ByVal strTable As String, ByVal strCriteria As String)
        Call ConnectDatabase()
        Try
            Dim strSql As String
            strSql = "select " & strField & " from `" & strTable & "` where " & strCriteria & " order by " & strField & " DESC limit 0,1"
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            DLast = Comd.ExecuteScalar
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try

    End Function
    Public Function LUser(ByVal strField As String, ByVal strTable As String)
        Call ConnectDatabase()
        Try
            Dim strSql As String
            strSql = "select " & strField & " from `" & strTable & "` order by " & strField & " DESC limit 0,1"
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim readerX As Integer = Comd.ExecuteScalar
            LUser = readerX
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try

    End Function
    Public Function Str2Date(ByVal strField As String)
        If strField = " " Then
            Exit Function
        End If
        Dim br = Split(strField, "/")
        If br(1) > 12 Then
            Str2Date = br(2) & "-" & br(0) & "-" & br(1)
        Else
            Str2Date = Mid(br(2), 1, 4) & "-" & br(1) & "-" & br(0)
        End If
    End Function

    Public Function NNULL(ByVal strField)
        If IsNothing(strField) Then
            NNULL = ""
        Else
            If IsDBNull(strField) Then
                NNULL = ""
            ElseIf (strField <> "") Then
                NNULL = strField
            Else
                NNULL = ""
            End If
        End If
    End Function
    Public Function NNULLs(ByVal strField)
        If IsNothing(strField) Then
            NNULLs = Nothing
        Else
            If IsDBNull(strField) Then
                NNULLs = Nothing
            ElseIf (strField <> "") Then
                NNULLs = strField
            Else
                NNULLs = Nothing
            End If
        End If
    End Function
    Public Function NZx(ByVal strField)
        If IsNothing(strField) Then
            NZx = 0
        Else
            If IsNumeric(strField) Then
                NZx = strField
            Else
                NZx = 0
            End If
        End If
    End Function

    Public Function cxTklist(ByVal strTiket)
        
        Call ConnectDatabase()
        Try
            Dim strSql As String
            strSql = "select count(`NoTiket`) from ticket where NoTiket = '" & strTiket & "' group by AgentID"
            Dim Comd As MySqlCommand = New MySqlCommand(strSql, conn)
            Dim reader As Integer = Comd.ExecuteScalar
            cxTklist = reader
            Call DisconnectDatabase()
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ' Close connection
            Call DisconnectDatabase()
        End Try
    End Function

End Module
