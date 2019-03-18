Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmPrintShuttle
    Public sql As String
    Private Sub frmPrintShuttle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'sql = "SELECT `agent`.`AgentName`, `tiketdtl`.`NoETiket`, `tiketdtl`.`NoTiket`, `tiketdtl`.`NoInv`, `invoice`.`Tgl`, `rute`.`RuteName`, `trip`.`TripName`, `tiketdtl`.`Qty`, `tiketdtl`.`QtyTipe`, `tiketdtl`.`komisi`, `tiketdtl`.`GoDate`, `tiketdtl`.`Guest`, `tiketdtl`.`TotalJual`, `tiketdtl`.`TotalCollect` FROM `ekajaya`.`agent` INNER JOIN `ekajaya`.`tiketdtl` ON (`agent`.`AgentID` = `tiketdtl`.`AgentID`) INNER JOIN `ekajaya`.`invoice` ON (`invoice`.`NoInv` = `tiketdtl`.`NoInv`) INNER JOIN `ekajaya`.`rute` ON (`rute`.`RuteID` = `tiketdtl`.`GoRuteID`) INNER JOIN `ekajaya`.`trip` ON (`trip`.`TripID` = `tiketdtl`.`GoTrip`) where tiketdtl.NoInv='" & NoInvPrint & "'"
        CrystalReportViewer1.ReportSource = Nothing
        Dim crp As New rptShuttleList
        Call ConnectDatabase()
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        da = New MySqlDataAdapter(sql, conn)
        dt = New DataTable
        da.Fill(dt)
        crp.SetDataSource(dt)
        CrystalReportViewer1.ReportSource = crp
        CrystalReportViewer1.Refresh()
    End Sub
End Class