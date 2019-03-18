<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTourOrder
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.GB3 = New System.Windows.Forms.GroupBox()
        Me.txtremark = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtgodate = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTTGL = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtbacktripID = New System.Windows.Forms.TextBox()
        Me.txtgotripid = New System.Windows.Forms.TextBox()
        Me.txtbackruteid = New System.Windows.Forms.TextBox()
        Me.txtgoruteid = New System.Windows.Forms.TextBox()
        Me.txtbacktrip = New System.Windows.Forms.TextBox()
        Me.txtgotrip = New System.Windows.Forms.TextBox()
        Me.txtagentid = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtbackrute = New System.Windows.Forms.TextBox()
        Me.txtgorute = New System.Windows.Forms.TextBox()
        Me.cmdAgLs = New System.Windows.Forms.Button()
        Me.cbotour = New System.Windows.Forms.ComboBox()
        Me.txtagent = New System.Windows.Forms.TextBox()
        Me.TXTID = New System.Windows.Forms.TextBox()
        Me.txtnobook = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtnoID = New System.Windows.Forms.TextBox()
        Me.cbotipeID = New System.Windows.Forms.ComboBox()
        Me.txtpickupgo = New System.Windows.Forms.TextBox()
        Me.cboGst = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboGoArea = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboremove = New System.Windows.Forms.Button()
        Me.cboadd = New System.Windows.Forms.Button()
        Me.txtguest = New System.Windows.Forms.TextBox()
        Me.lblguest = New System.Windows.Forms.Label()
        Me.txttprice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lsAgent = New System.Windows.Forms.DataGridView()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.txtcollect = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GB3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.lsAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(866, 43)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Tour List"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(785, 9)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(703, 9)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 16
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'GB3
        '
        Me.GB3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GB3.Controls.Add(Me.txtcollect)
        Me.GB3.Controls.Add(Me.Label16)
        Me.GB3.Controls.Add(Me.txtremark)
        Me.GB3.Controls.Add(Me.Label15)
        Me.GB3.Controls.Add(Me.txtgodate)
        Me.GB3.Controls.Add(Me.Label14)
        Me.GB3.Controls.Add(Me.Label8)
        Me.GB3.Controls.Add(Me.TXTTGL)
        Me.GB3.Controls.Add(Me.Label6)
        Me.GB3.Controls.Add(Me.txtbacktripID)
        Me.GB3.Controls.Add(Me.txtgotripid)
        Me.GB3.Controls.Add(Me.txtbackruteid)
        Me.GB3.Controls.Add(Me.txtgoruteid)
        Me.GB3.Controls.Add(Me.txtbacktrip)
        Me.GB3.Controls.Add(Me.txtgotrip)
        Me.GB3.Controls.Add(Me.txtagentid)
        Me.GB3.Controls.Add(Me.Label7)
        Me.GB3.Controls.Add(Me.txtbackrute)
        Me.GB3.Controls.Add(Me.txtgorute)
        Me.GB3.Controls.Add(Me.cmdAgLs)
        Me.GB3.Controls.Add(Me.cbotour)
        Me.GB3.Controls.Add(Me.txtagent)
        Me.GB3.Controls.Add(Me.TXTID)
        Me.GB3.Controls.Add(Me.txtnobook)
        Me.GB3.Controls.Add(Me.GroupBox2)
        Me.GB3.Controls.Add(Me.txttprice)
        Me.GB3.Controls.Add(Me.Label5)
        Me.GB3.Controls.Add(Me.Label11)
        Me.GB3.Controls.Add(Me.Label3)
        Me.GB3.Controls.Add(Me.Label4)
        Me.GB3.Controls.Add(Me.Label2)
        Me.GB3.Controls.Add(Me.Label20)
        Me.GB3.Controls.Add(Me.lsAgent)
        Me.GB3.Controls.Add(Me.ShapeContainer1)
        Me.GB3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB3.Location = New System.Drawing.Point(0, 43)
        Me.GB3.Name = "GB3"
        Me.GB3.Size = New System.Drawing.Size(866, 483)
        Me.GB3.TabIndex = 5
        Me.GB3.TabStop = False
        '
        'txtremark
        '
        Me.txtremark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremark.Location = New System.Drawing.Point(576, 92)
        Me.txtremark.Margin = New System.Windows.Forms.Padding(5)
        Me.txtremark.Multiline = True
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(273, 49)
        Me.txtremark.TabIndex = 95
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(573, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 15)
        Me.Label15.TabIndex = 96
        Me.Label15.Text = "Remark"
        '
        'txtgodate
        '
        Me.txtgodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgodate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtgodate.Location = New System.Drawing.Point(655, 50)
        Me.txtgodate.Name = "txtgodate"
        Me.txtgodate.Size = New System.Drawing.Size(119, 21)
        Me.txtgodate.TabIndex = 91
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(573, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 92
        Me.Label14.Text = "Depart Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(291, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 15)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Date"
        '
        'TXTTGL
        '
        Me.TXTTGL.Location = New System.Drawing.Point(371, 15)
        Me.TXTTGL.Name = "TXTTGL"
        Me.TXTTGL.Size = New System.Drawing.Size(157, 20)
        Me.TXTTGL.TabIndex = 88
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(13, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "NoOrder"
        '
        'txtbacktripID
        '
        Me.txtbacktripID.Enabled = False
        Me.txtbacktripID.Location = New System.Drawing.Point(467, 99)
        Me.txtbacktripID.Name = "txtbacktripID"
        Me.txtbacktripID.Size = New System.Drawing.Size(28, 20)
        Me.txtbacktripID.TabIndex = 86
        Me.txtbacktripID.Visible = False
        '
        'txtgotripid
        '
        Me.txtgotripid.Enabled = False
        Me.txtgotripid.Location = New System.Drawing.Point(477, 77)
        Me.txtgotripid.Name = "txtgotripid"
        Me.txtgotripid.Size = New System.Drawing.Size(20, 20)
        Me.txtgotripid.TabIndex = 85
        Me.txtgotripid.Visible = False
        '
        'txtbackruteid
        '
        Me.txtbackruteid.Enabled = False
        Me.txtbackruteid.Location = New System.Drawing.Point(230, 98)
        Me.txtbackruteid.Name = "txtbackruteid"
        Me.txtbackruteid.Size = New System.Drawing.Size(38, 20)
        Me.txtbackruteid.TabIndex = 84
        Me.txtbackruteid.Visible = False
        '
        'txtgoruteid
        '
        Me.txtgoruteid.Enabled = False
        Me.txtgoruteid.Location = New System.Drawing.Point(247, 76)
        Me.txtgoruteid.Name = "txtgoruteid"
        Me.txtgoruteid.Size = New System.Drawing.Size(21, 20)
        Me.txtgoruteid.TabIndex = 83
        Me.txtgoruteid.Visible = False
        '
        'txtbacktrip
        '
        Me.txtbacktrip.Enabled = False
        Me.txtbacktrip.Location = New System.Drawing.Point(407, 99)
        Me.txtbacktrip.Margin = New System.Windows.Forms.Padding(5)
        Me.txtbacktrip.MaxLength = 11
        Me.txtbacktrip.Name = "txtbacktrip"
        Me.txtbacktrip.Size = New System.Drawing.Size(75, 20)
        Me.txtbacktrip.TabIndex = 82
        '
        'txtgotrip
        '
        Me.txtgotrip.Enabled = False
        Me.txtgotrip.Location = New System.Drawing.Point(407, 77)
        Me.txtgotrip.Margin = New System.Windows.Forms.Padding(5)
        Me.txtgotrip.MaxLength = 11
        Me.txtgotrip.Name = "txtgotrip"
        Me.txtgotrip.Size = New System.Drawing.Size(75, 20)
        Me.txtgotrip.TabIndex = 81
        '
        'txtagentid
        '
        Me.txtagentid.Location = New System.Drawing.Point(501, 51)
        Me.txtagentid.Name = "txtagentid"
        Me.txtagentid.Size = New System.Drawing.Size(38, 20)
        Me.txtagentid.TabIndex = 78
        Me.txtagentid.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(291, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Agent"
        '
        'txtbackrute
        '
        Me.txtbackrute.Enabled = False
        Me.txtbackrute.Location = New System.Drawing.Point(110, 98)
        Me.txtbackrute.Margin = New System.Windows.Forms.Padding(5)
        Me.txtbackrute.MaxLength = 11
        Me.txtbackrute.Name = "txtbackrute"
        Me.txtbackrute.Size = New System.Drawing.Size(141, 20)
        Me.txtbackrute.TabIndex = 80
        '
        'txtgorute
        '
        Me.txtgorute.Enabled = False
        Me.txtgorute.Location = New System.Drawing.Point(109, 76)
        Me.txtgorute.Margin = New System.Windows.Forms.Padding(5)
        Me.txtgorute.MaxLength = 11
        Me.txtgorute.Name = "txtgorute"
        Me.txtgorute.Size = New System.Drawing.Size(141, 20)
        Me.txtgorute.TabIndex = 79
        '
        'cmdAgLs
        '
        Me.cmdAgLs.Location = New System.Drawing.Point(538, 50)
        Me.cmdAgLs.Name = "cmdAgLs"
        Me.cmdAgLs.Size = New System.Drawing.Size(27, 20)
        Me.cmdAgLs.TabIndex = 77
        Me.cmdAgLs.Text = "+"
        Me.cmdAgLs.UseVisualStyleBackColor = True
        '
        'cbotour
        '
        Me.cbotour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotour.FormattingEnabled = True
        Me.cbotour.Location = New System.Drawing.Point(109, 49)
        Me.cbotour.Margin = New System.Windows.Forms.Padding(5)
        Me.cbotour.Name = "cbotour"
        Me.cbotour.Size = New System.Drawing.Size(141, 23)
        Me.cbotour.TabIndex = 78
        '
        'txtagent
        '
        Me.txtagent.Location = New System.Drawing.Point(408, 50)
        Me.txtagent.Name = "txtagent"
        Me.txtagent.Size = New System.Drawing.Size(131, 20)
        Me.txtagent.TabIndex = 76
        '
        'TXTID
        '
        Me.TXTID.Location = New System.Drawing.Point(536, 15)
        Me.TXTID.Name = "TXTID"
        Me.TXTID.Size = New System.Drawing.Size(31, 20)
        Me.TXTID.TabIndex = 77
        Me.TXTID.Visible = False
        '
        'txtnobook
        '
        Me.txtnobook.Enabled = False
        Me.txtnobook.Location = New System.Drawing.Point(109, 15)
        Me.txtnobook.Name = "txtnobook"
        Me.txtnobook.Size = New System.Drawing.Size(141, 20)
        Me.txtnobook.TabIndex = 76
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtnoID)
        Me.GroupBox2.Controls.Add(Me.cbotipeID)
        Me.GroupBox2.Controls.Add(Me.txtpickupgo)
        Me.GroupBox2.Controls.Add(Me.cboGst)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cboGoArea)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.cboremove)
        Me.GroupBox2.Controls.Add(Me.cboadd)
        Me.GroupBox2.Controls.Add(Me.txtguest)
        Me.GroupBox2.Controls.Add(Me.lblguest)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 143)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(842, 113)
        Me.GroupBox2.TabIndex = 75
        Me.GroupBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(6, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 15)
        Me.Label12.TabIndex = 97
        Me.Label12.Text = "ID"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(145, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 15)
        Me.Label13.TabIndex = 98
        Me.Label13.Text = "No. ID"
        '
        'txtnoID
        '
        Me.txtnoID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnoID.Location = New System.Drawing.Point(143, 84)
        Me.txtnoID.Margin = New System.Windows.Forms.Padding(5)
        Me.txtnoID.Name = "txtnoID"
        Me.txtnoID.Size = New System.Drawing.Size(134, 21)
        Me.txtnoID.TabIndex = 96
        '
        'cbotipeID
        '
        Me.cbotipeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbotipeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbotipeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotipeID.FormattingEnabled = True
        Me.cbotipeID.Items.AddRange(New Object() {"KTP", "Passport", "Kitas"})
        Me.cbotipeID.Location = New System.Drawing.Point(9, 82)
        Me.cbotipeID.Margin = New System.Windows.Forms.Padding(5)
        Me.cbotipeID.Name = "cbotipeID"
        Me.cbotipeID.Size = New System.Drawing.Size(121, 23)
        Me.cbotipeID.TabIndex = 95
        '
        'txtpickupgo
        '
        Me.txtpickupgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpickupgo.Location = New System.Drawing.Point(430, 42)
        Me.txtpickupgo.Margin = New System.Windows.Forms.Padding(5)
        Me.txtpickupgo.Multiline = True
        Me.txtpickupgo.Name = "txtpickupgo"
        Me.txtpickupgo.Size = New System.Drawing.Size(316, 59)
        Me.txtpickupgo.TabIndex = 92
        '
        'cboGst
        '
        Me.cboGst.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboGst.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGst.FormattingEnabled = True
        Me.cboGst.Items.AddRange(New Object() {"1 - Adult", "2 - Child", "3 - Infan", "4 - FOC"})
        Me.cboGst.Location = New System.Drawing.Point(140, 40)
        Me.cboGst.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGst.Name = "cboGst"
        Me.cboGst.Size = New System.Drawing.Size(121, 23)
        Me.cboGst.TabIndex = 82
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(427, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 15)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Pickup Location"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(145, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 15)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "Age's"
        '
        'cboGoArea
        '
        Me.cboGoArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboGoArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGoArea.DropDownWidth = 250
        Me.cboGoArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGoArea.FormattingEnabled = True
        Me.cboGoArea.Location = New System.Drawing.Point(271, 40)
        Me.cboGoArea.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGoArea.Name = "cboGoArea"
        Me.cboGoArea.Size = New System.Drawing.Size(142, 23)
        Me.cboGoArea.TabIndex = 91
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(275, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 15)
        Me.Label18.TabIndex = 93
        Me.Label18.Text = "Pickup Area"
        '
        'cboremove
        '
        Me.cboremove.Location = New System.Drawing.Point(760, 40)
        Me.cboremove.Name = "cboremove"
        Me.cboremove.Size = New System.Drawing.Size(75, 23)
        Me.cboremove.TabIndex = 80
        Me.cboremove.Text = "Remove"
        Me.cboremove.UseVisualStyleBackColor = True
        '
        'cboadd
        '
        Me.cboadd.Location = New System.Drawing.Point(761, 13)
        Me.cboadd.Name = "cboadd"
        Me.cboadd.Size = New System.Drawing.Size(75, 23)
        Me.cboadd.TabIndex = 76
        Me.cboadd.Text = "Add"
        Me.cboadd.UseVisualStyleBackColor = True
        '
        'txtguest
        '
        Me.txtguest.Location = New System.Drawing.Point(9, 42)
        Me.txtguest.Margin = New System.Windows.Forms.Padding(5)
        Me.txtguest.MaxLength = 11
        Me.txtguest.Name = "txtguest"
        Me.txtguest.Size = New System.Drawing.Size(121, 20)
        Me.txtguest.TabIndex = 73
        '
        'lblguest
        '
        Me.lblguest.AutoSize = True
        Me.lblguest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblguest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblguest.ForeColor = System.Drawing.Color.Black
        Me.lblguest.Location = New System.Drawing.Point(6, 16)
        Me.lblguest.Name = "lblguest"
        Me.lblguest.Size = New System.Drawing.Size(82, 15)
        Me.lblguest.TabIndex = 74
        Me.lblguest.Text = "GuestName"
        '
        'txttprice
        '
        Me.txttprice.Location = New System.Drawing.Point(110, 121)
        Me.txttprice.Margin = New System.Windows.Forms.Padding(5)
        Me.txttprice.MaxLength = 11
        Me.txttprice.Name = "txttprice"
        Me.txttprice.Size = New System.Drawing.Size(141, 20)
        Me.txttprice.TabIndex = 73
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(14, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Price"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(13, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 15)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "Tour Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(291, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Return Trip"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(291, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Depart Trip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Return Rute"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(14, 79)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 13)
        Me.Label20.TabIndex = 55
        Me.Label20.Text = "Depart Rute"
        '
        'lsAgent
        '
        Me.lsAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lsAgent.Location = New System.Drawing.Point(12, 268)
        Me.lsAgent.Name = "lsAgent"
        Me.lsAgent.Size = New System.Drawing.Size(842, 203)
        Me.lsAgent.TabIndex = 22
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 16)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(860, 464)
        Me.ShapeContainer1.TabIndex = 90
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 11
        Me.LineShape1.X2 = 851
        Me.LineShape1.Y1 = 23
        Me.LineShape1.Y2 = 23
        '
        'txtcollect
        '
        Me.txtcollect.Location = New System.Drawing.Point(407, 120)
        Me.txtcollect.Margin = New System.Windows.Forms.Padding(5)
        Me.txtcollect.MaxLength = 11
        Me.txtcollect.Name = "txtcollect"
        Me.txtcollect.Size = New System.Drawing.Size(141, 20)
        Me.txtcollect.TabIndex = 97
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(291, 121)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 15)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "Request Collect"
        '
        'frmTourOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 526)
        Me.Controls.Add(Me.GB3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTourOrder"
        Me.Text = "frmTourOrder"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GB3.ResumeLayout(False)
        Me.GB3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.lsAgent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GB3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbotour As System.Windows.Forms.ComboBox
    Friend WithEvents TXTID As System.Windows.Forms.TextBox
    Friend WithEvents txtnobook As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboremove As System.Windows.Forms.Button
    Friend WithEvents cboadd As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtagentid As System.Windows.Forms.TextBox
    Friend WithEvents cmdAgLs As System.Windows.Forms.Button
    Friend WithEvents txtagent As System.Windows.Forms.TextBox
    Friend WithEvents txtguest As System.Windows.Forms.TextBox
    Friend WithEvents lblguest As System.Windows.Forms.Label
    Friend WithEvents txttprice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lsAgent As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtbacktrip As System.Windows.Forms.TextBox
    Friend WithEvents txtgotrip As System.Windows.Forms.TextBox
    Friend WithEvents txtbackrute As System.Windows.Forms.TextBox
    Friend WithEvents txtgorute As System.Windows.Forms.TextBox
    Friend WithEvents txtbacktripID As System.Windows.Forms.TextBox
    Friend WithEvents txtgotripid As System.Windows.Forms.TextBox
    Friend WithEvents txtbackruteid As System.Windows.Forms.TextBox
    Friend WithEvents txtgoruteid As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTTGL As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboGst As System.Windows.Forms.ComboBox
    Friend WithEvents txtpickupgo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboGoArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtgodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtnoID As System.Windows.Forms.TextBox
    Friend WithEvents cbotipeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtremark As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtcollect As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
