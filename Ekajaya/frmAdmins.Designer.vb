<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmins
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataRuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataTripToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataAgentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyAvailabilityTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgentPriceListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PromoTiketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpecialEventToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lv34 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdvoid = New System.Windows.Forms.Button()
        Me.cmdEdBook = New System.Windows.Forms.Button()
        Me.cmdShutle = New System.Windows.Forms.Button()
        Me.cmdBook = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.LBLUSER = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbodrv = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbotipe = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboGorute = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txtgodate2 = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.txtgodate = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        Me.cboGotrip = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboPort = New System.Windows.Forms.ComboBox()
        Me.LsData = New System.Windows.Forms.DataGridView()
        Me.TopSupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.lv34.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.LsData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterToolStripMenuItem, Me.SalesToolStripMenuItem, Me.TopSupportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1147, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterToolStripMenuItem
        '
        Me.MasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataRuteToolStripMenuItem, Me.DataTripToolStripMenuItem, Me.DataAgentToolStripMenuItem, Me.DailyAvailabilityTicketToolStripMenuItem, Me.DataPortToolStripMenuItem})
        Me.MasterToolStripMenuItem.Name = "MasterToolStripMenuItem"
        Me.MasterToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.MasterToolStripMenuItem.Text = "&Master"
        '
        'DataRuteToolStripMenuItem
        '
        Me.DataRuteToolStripMenuItem.Name = "DataRuteToolStripMenuItem"
        Me.DataRuteToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DataRuteToolStripMenuItem.Text = "Data &Rute"
        '
        'DataTripToolStripMenuItem
        '
        Me.DataTripToolStripMenuItem.Name = "DataTripToolStripMenuItem"
        Me.DataTripToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DataTripToolStripMenuItem.Text = "Data &Trip"
        '
        'DataAgentToolStripMenuItem
        '
        Me.DataAgentToolStripMenuItem.Name = "DataAgentToolStripMenuItem"
        Me.DataAgentToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DataAgentToolStripMenuItem.Text = "Data A&gent"
        '
        'DailyAvailabilityTicketToolStripMenuItem
        '
        Me.DailyAvailabilityTicketToolStripMenuItem.Name = "DailyAvailabilityTicketToolStripMenuItem"
        Me.DailyAvailabilityTicketToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DailyAvailabilityTicketToolStripMenuItem.Text = "Daily Availability Ticket"
        '
        'DataPortToolStripMenuItem
        '
        Me.DataPortToolStripMenuItem.Name = "DataPortToolStripMenuItem"
        Me.DataPortToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DataPortToolStripMenuItem.Text = "Data Port"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgentPriceListToolStripMenuItem, Me.PromoTiketToolStripMenuItem, Me.SpecialEventToolStripMenuItem, Me.TourToolStripMenuItem})
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.SalesToolStripMenuItem.Text = "&Sales"
        '
        'AgentPriceListToolStripMenuItem
        '
        Me.AgentPriceListToolStripMenuItem.Name = "AgentPriceListToolStripMenuItem"
        Me.AgentPriceListToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AgentPriceListToolStripMenuItem.Text = "Agent &PriceList"
        '
        'PromoTiketToolStripMenuItem
        '
        Me.PromoTiketToolStripMenuItem.Name = "PromoTiketToolStripMenuItem"
        Me.PromoTiketToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.PromoTiketToolStripMenuItem.Text = "Promo Tiket"
        '
        'SpecialEventToolStripMenuItem
        '
        Me.SpecialEventToolStripMenuItem.Name = "SpecialEventToolStripMenuItem"
        Me.SpecialEventToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.SpecialEventToolStripMenuItem.Text = "Special Event"
        '
        'TourToolStripMenuItem
        '
        Me.TourToolStripMenuItem.Name = "TourToolStripMenuItem"
        Me.TourToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.TourToolStripMenuItem.Text = "Tour"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lv34)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 398)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(1147, 75)
        Me.Panel2.TabIndex = 9
        '
        'lv34
        '
        Me.lv34.Controls.Add(Me.Button2)
        Me.lv34.Controls.Add(Me.cmdvoid)
        Me.lv34.Controls.Add(Me.cmdEdBook)
        Me.lv34.Controls.Add(Me.cmdShutle)
        Me.lv34.Controls.Add(Me.cmdBook)
        Me.lv34.Controls.Add(Me.cmdPrint)
        Me.lv34.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lv34.Location = New System.Drawing.Point(10, 3)
        Me.lv34.Name = "lv34"
        Me.lv34.Size = New System.Drawing.Size(1127, 62)
        Me.lv34.TabIndex = 1
        Me.lv34.TabStop = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(458, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 33)
        Me.Button2.TabIndex = 63
        Me.Button2.Text = "Reset"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cmdvoid
        '
        Me.cmdvoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdvoid.Location = New System.Drawing.Point(559, 19)
        Me.cmdvoid.Name = "cmdvoid"
        Me.cmdvoid.Size = New System.Drawing.Size(95, 33)
        Me.cmdvoid.TabIndex = 2
        Me.cmdvoid.Text = "&Void Tiket"
        Me.cmdvoid.UseVisualStyleBackColor = True
        Me.cmdvoid.Visible = False
        '
        'cmdEdBook
        '
        Me.cmdEdBook.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdBook.Location = New System.Drawing.Point(137, 19)
        Me.cmdEdBook.Name = "cmdEdBook"
        Me.cmdEdBook.Size = New System.Drawing.Size(86, 33)
        Me.cmdEdBook.TabIndex = 1
        Me.cmdEdBook.Text = "&Edit Tiket"
        Me.cmdEdBook.UseVisualStyleBackColor = True
        '
        'cmdShutle
        '
        Me.cmdShutle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShutle.Location = New System.Drawing.Point(229, 19)
        Me.cmdShutle.Name = "cmdShutle"
        Me.cmdShutle.Size = New System.Drawing.Size(97, 33)
        Me.cmdShutle.TabIndex = 1
        Me.cmdShutle.Text = "Shuttle"
        Me.cmdShutle.UseVisualStyleBackColor = True
        '
        'cmdBook
        '
        Me.cmdBook.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBook.Location = New System.Drawing.Point(15, 20)
        Me.cmdBook.Name = "cmdBook"
        Me.cmdBook.Size = New System.Drawing.Size(116, 33)
        Me.cmdBook.TabIndex = 0
        Me.cmdBook.Text = "&Add Booking"
        Me.cmdBook.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(332, 19)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(120, 33)
        Me.cmdPrint.TabIndex = 6
        Me.cmdPrint.Text = "&Passanger List"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Teal
        Me.Panel3.Controls.Add(Me.Text1)
        Me.Panel3.Controls.Add(Me.lblTotal)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cmdExport)
        Me.Panel3.Controls.Add(Me.LBLUSER)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.cmdFilter)
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1147, 142)
        Me.Panel3.TabIndex = 11
        '
        'Text1
        '
        Me.Text1.Location = New System.Drawing.Point(408, 10)
        Me.Text1.Name = "Text1"
        Me.Text1.Size = New System.Drawing.Size(100, 20)
        Me.Text1.TabIndex = 69
        Me.Text1.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTotal.AutoSize = True
        Me.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal.Location = New System.Drawing.Point(845, 61)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(137, 31)
        Me.lblTotal.TabIndex = 68
        Me.lblTotal.Text = "Total Pax"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(845, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Total Pax"
        '
        'cmdExport
        '
        Me.cmdExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExport.Location = New System.Drawing.Point(711, 88)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(97, 33)
        Me.cmdExport.TabIndex = 66
        Me.cmdExport.Text = "&Export XLS"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'LBLUSER
        '
        Me.LBLUSER.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LBLUSER.AutoSize = True
        Me.LBLUSER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LBLUSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUSER.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LBLUSER.Location = New System.Drawing.Point(548, 13)
        Me.LBLUSER.Name = "LBLUSER"
        Me.LBLUSER.Size = New System.Drawing.Size(148, 15)
        Me.LBLUSER.TabIndex = 60
        Me.LBLUSER.Text = "TIKET RESERVATION "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(9, 8)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "TIKET RESERVATION "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbodrv)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cbotipe)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(455, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(241, 99)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        '
        'cbodrv
        '
        Me.cbodrv.FormattingEnabled = True
        Me.cbodrv.Items.AddRange(New Object() {"OW - One Way", "RT - Return", "3A - 3ANGEL"})
        Me.cbodrv.Location = New System.Drawing.Point(108, 66)
        Me.cbodrv.Margin = New System.Windows.Forms.Padding(5)
        Me.cbodrv.Name = "cbodrv"
        Me.cbodrv.Size = New System.Drawing.Size(121, 21)
        Me.cbodrv.TabIndex = 71
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(12, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "Driver"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(108, 41)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBox1.MaxLength = 11
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 20)
        Me.TextBox1.TabIndex = 69
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label11.Location = New System.Drawing.Point(12, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 15)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "Guest Name"
        '
        'cbotipe
        '
        Me.cbotipe.FormattingEnabled = True
        Me.cbotipe.Items.AddRange(New Object() {"OW - One Way", "RT - Return", "3A - 3ANGEL"})
        Me.cbotipe.Location = New System.Drawing.Point(108, 17)
        Me.cbotipe.Margin = New System.Windows.Forms.Padding(5)
        Me.cbotipe.Name = "cbotipe"
        Me.cbotipe.Size = New System.Drawing.Size(121, 21)
        Me.cbotipe.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Ticket Type"
        '
        'cmdFilter
        '
        Me.cmdFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFilter.Location = New System.Drawing.Point(711, 48)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(97, 33)
        Me.cmdFilter.TabIndex = 2
        Me.cmdFilter.Text = "&Filter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.cboGorute)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.txtgodate2)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.txtgodate)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.cboAgent)
        Me.GroupBox3.Controls.Add(Me.cboGotrip)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.cboPort)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(437, 98)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Departure"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(230, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(34, 13)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "Rute"
        '
        'cboGorute
        '
        Me.cboGorute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGorute.FormattingEnabled = True
        Me.cboGorute.Location = New System.Drawing.Point(287, 16)
        Me.cboGorute.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGorute.Name = "cboGorute"
        Me.cboGorute.Size = New System.Drawing.Size(141, 23)
        Me.cboGorute.TabIndex = 52
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(390, 43)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(38, 20)
        Me.Button6.TabIndex = 51
        Me.Button6.Text = "..."
        Me.Button6.UseVisualStyleBackColor = True
        '
        'txtgodate2
        '
        Me.txtgodate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgodate2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtgodate2.Location = New System.Drawing.Point(288, 43)
        Me.txtgodate2.Name = "txtgodate2"
        Me.txtgodate2.Size = New System.Drawing.Size(96, 21)
        Me.txtgodate2.TabIndex = 49
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(231, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "To"
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(174, 42)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(38, 20)
        Me.Button7.TabIndex = 48
        Me.Button7.Text = "..."
        Me.Button7.UseVisualStyleBackColor = True
        '
        'txtgodate
        '
        Me.txtgodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgodate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtgodate.Location = New System.Drawing.Point(72, 42)
        Me.txtgodate.Name = "txtgodate"
        Me.txtgodate.Size = New System.Drawing.Size(96, 21)
        Me.txtgodate.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(15, 42)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(233, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Agent"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(15, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Trip"
        '
        'cboAgent
        '
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(287, 68)
        Me.cboAgent.Margin = New System.Windows.Forms.Padding(5)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(121, 21)
        Me.cboAgent.TabIndex = 18
        '
        'cboGotrip
        '
        Me.cboGotrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGotrip.FormattingEnabled = True
        Me.cboGotrip.Location = New System.Drawing.Point(72, 67)
        Me.cboGotrip.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGotrip.Name = "cboGotrip"
        Me.cboGotrip.Size = New System.Drawing.Size(141, 23)
        Me.cboGotrip.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(15, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Port"
        '
        'cboPort
        '
        Me.cboPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(72, 17)
        Me.cboPort.Margin = New System.Windows.Forms.Padding(5)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(141, 23)
        Me.cboPort.TabIndex = 12
        '
        'LsData
        '
        Me.LsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LsData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsData.Location = New System.Drawing.Point(0, 166)
        Me.LsData.Margin = New System.Windows.Forms.Padding(10)
        Me.LsData.Name = "LsData"
        Me.LsData.Size = New System.Drawing.Size(1147, 232)
        Me.LsData.TabIndex = 12
        '
        'TopSupportToolStripMenuItem
        '
        Me.TopSupportToolStripMenuItem.Name = "TopSupportToolStripMenuItem"
        Me.TopSupportToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.TopSupportToolStripMenuItem.Text = "Top Support"
        '
        'frmAdmins
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 473)
        Me.Controls.Add(Me.LsData)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmAdmins"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAdmins"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.lv34.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.LsData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataRuteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataTripToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataAgentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyAvailabilityTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgentPriceListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PromoTiketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpecialEventToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents lv34 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdvoid As System.Windows.Forms.Button
    Friend WithEvents cmdEdBook As System.Windows.Forms.Button
    Friend WithEvents cmdShutle As System.Windows.Forms.Button
    Friend WithEvents cmdBook As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents LBLUSER As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbodrv As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboGorute As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtgodate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents cbotipe As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtgodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboAgent As System.Windows.Forms.ComboBox
    Friend WithEvents cboGotrip As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents LsData As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Text1 As System.Windows.Forms.TextBox
    Friend WithEvents TourToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TopSupportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
