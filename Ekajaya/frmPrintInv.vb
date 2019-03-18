Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmPrintInv
    Public NoInvPrint As String
    Public reserv As String = ""
    Dim sqlPrint As String = ""
    Private Sub frmPrintInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sqlPrint = "SELECT `agent`.`AgentName`, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`NoInv`, `invoice`.`Tgl`, `rute`.`RuteName`, `trip`.`TripName`,IF(`tiketdtl`.QtyTipe = 1, tiketdtl.qty,0) AS Adult, IF(`tiketdtl`.QtyTipe = 2,tiketdtl.qty, 0) AS Child,IF(`tiketdtl`.QtyTipe >= 3,tiketdtl.qty,0) AS FOC, `tiketdtl`.`komisi`, `tiketdtl`.`GoDate`, `tiketdtl`.`Guest`, `tiketdtl`.`TotalJual`, `tiketdtl`.`Qty`, `tiketdtl`.`TotalCollect`, `tiketdtl`.`Tipe` FROM `ekajaya`.`agent` INNER JOIN `ekajaya`.`tiketdtl` ON (`agent`.`AgentID` = `tiketdtl`.`AgentID`) INNER JOIN `ekajaya`.`invoice` ON (`invoice`.`NoInv` = `tiketdtl`.`NoInv`) INNER JOIN `ekajaya`.`rute` ON (`rute`.`RuteID` = `tiketdtl`.`GoRuteID`) INNER JOIN `ekajaya`.`trip` ON (`trip`.`TripID` = `tiketdtl`.`GoTrip`) where tiketdtl.NoInv='" & NoInvPrint & "' AND tiketdtl.STATUS=1 ORDER BY  `tiketdtl`.`GoDate` ASC"
        Dim crp
        If reserv = "" Then
            crp = New crInvoice
        Else
            crp = New crproInvoice
        End If
        'Dim crp As New crInvoice
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(sqlPrint, conn)
        dt = New DataTable
        da.Fill(dt)
        crp.SetDataSource(dt)
        CrystalReportViewer1.ReportSource = crp
        CrystalReportViewer1.Refresh()
    End Sub
End Class