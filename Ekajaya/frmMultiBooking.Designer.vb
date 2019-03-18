<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMultiBooking
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
        Me.txtagentid = New System.Windows.Forms.TextBox()
        Me.txtaid = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtlist = New System.Windows.Forms.TextBox()
        Me.cmdAgent = New System.Windows.Forms.Button()
        Me.txtagent = New System.Windows.Forms.TextBox()
        Me.CxOpen = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtPickupBack = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtbackDrive = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cboBackArea = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtpickupgo = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtdrivego = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboGoArea = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CxBackTrans = New System.Windows.Forms.CheckBox()
        Me.txtbackdate = New System.Windows.Forms.DateTimePicker()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.cbotripback = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cboruteback = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CxGoTrans = New System.Windows.Forms.CheckBox()
        Me.txtgodate = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboGotrip = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboGorute = New System.Windows.Forms.ComboBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbotipe = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtagentid)
        Me.Panel1.Controls.Add(Me.txtaid)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(7)
        Me.Panel1.Size = New System.Drawing.Size(597, 36)
        Me.Panel1.TabIndex = 7
        '
        'txtagentid
        '
        Me.txtagentid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtagentid.Location = New System.Drawing.Point(317, 10)
        Me.txtagentid.Margin = New System.Windows.Forms.Padding(5)
        Me.txtagentid.Name = "txtagentid"
        Me.txtagentid.Size = New System.Drawing.Size(96, 21)
        Me.txtagentid.TabIndex = 67
        Me.txtagentid.Visible = False
        '
        'txtaid
        '
        Me.txtaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaid.Location = New System.Drawing.Point(215, 10)
        Me.txtaid.Margin = New System.Windows.Forms.Padding(5)
        Me.txtaid.Name = "txtaid"
        Me.txtaid.Size = New System.Drawing.Size(96, 21)
        Me.txtaid.TabIndex = 66
        Me.txtaid.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(507, 7)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 59
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(426, 7)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 58
        Me.cmdSave.Text = "&Update"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label10.Location = New System.Drawing.Point(8, 7)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(192, 20)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "MULTI TIKET UPDATE"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cbotipe)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtlist)
        Me.Panel2.Controls.Add(Me.cmdAgent)
        Me.Panel2.Controls.Add(Me.txtagent)
        Me.Panel2.Controls.Add(Me.CxOpen)
        Me.Panel2.Controls.Add(Me.GroupBox6)
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(597, 320)
        Me.Panel2.TabIndex = 15
        '
        'txtlist
        '
        Me.txtlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlist.Location = New System.Drawing.Point(352, 7)
        Me.txtlist.Margin = New System.Windows.Forms.Padding(5)
        Me.txtlist.Name = "txtlist"
        Me.txtlist.Size = New System.Drawing.Size(229, 21)
        Me.txtlist.TabIndex = 67
        Me.txtlist.Visible = False
        '
        'cmdAgent
        '
        Me.cmdAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAgent.Location = New System.Drawing.Point(262, 6)
        Me.cmdAgent.Name = "cmdAgent"
        Me.cmdAgent.Size = New System.Drawing.Size(35, 23)
        Me.cmdAgent.TabIndex = 2
        Me.cmdAgent.Text = "..."
        Me.cmdAgent.UseVisualStyleBackColor = True
        '
        'txtagent
        '
        Me.txtagent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtagent.Location = New System.Drawing.Point(140, 8)
        Me.txtagent.Margin = New System.Windows.Forms.Padding(5)
        Me.txtagent.Name = "txtagent"
        Me.txtagent.Size = New System.Drawing.Size(121, 21)
        Me.txtagent.TabIndex = 63
        '
        'CxOpen
        '
        Me.CxOpen.AutoSize = True
        Me.CxOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CxOpen.Location = New System.Drawing.Point(310, 45)
        Me.CxOpen.Name = "CxOpen"
        Me.CxOpen.Size = New System.Drawing.Size(95, 19)
        Me.CxOpen.TabIndex = 20
        Me.CxOpen.Text = "Open Tiket"
        Me.CxOpen.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtPickupBack)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Controls.Add(Me.txtbackDrive)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.cboBackArea)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(303, 191)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(279, 116)
        Me.GroupBox6.TabIndex = 53
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Arrival Transport"
        '
        'txtPickupBack
        '
        Me.txtPickupBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPickupBack.Location = New System.Drawing.Point(123, 43)
        Me.txtPickupBack.Margin = New System.Windows.Forms.Padding(5)
        Me.txtPickupBack.Multiline = True
        Me.txtPickupBack.Name = "txtPickupBack"
        Me.txtPickupBack.Size = New System.Drawing.Size(143, 38)
        Me.txtPickupBack.TabIndex = 46
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(12, 47)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(62, 15)
        Me.Label36.TabIndex = 48
        Me.Label36.Text = "Location"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(12, 23)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(36, 15)
        Me.Label37.TabIndex = 47
        Me.Label37.Text = "Area"
        '
        'txtbackDrive
        '
        Me.txtbackDrive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbackDrive.Location = New System.Drawing.Point(123, 83)
        Me.txtbackDrive.Margin = New System.Windows.Forms.Padding(5)
        Me.txtbackDrive.Name = "txtbackDrive"
        Me.txtbackDrive.Size = New System.Drawing.Size(143, 21)
        Me.txtbackDrive.TabIndex = 21
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(12, 83)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(45, 15)
        Me.Label38.TabIndex = 42
        Me.Label38.Text = "Driver"
        '
        'cboBackArea
        '
        Me.cboBackArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboBackArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBackArea.DropDownWidth = 250
        Me.cboBackArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBackArea.FormattingEnabled = True
        Me.cboBackArea.Location = New System.Drawing.Point(123, 18)
        Me.cboBackArea.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBackArea.Name = "cboBackArea"
        Me.cboBackArea.Size = New System.Drawing.Size(143, 23)
        Me.cboBackArea.TabIndex = 45
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtpickupgo)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txtdrivego)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.cboGoArea)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(18, 189)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(279, 118)
        Me.GroupBox5.TabIndex = 52
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Depart Transport"
        '
        'txtpickupgo
        '
        Me.txtpickupgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpickupgo.Location = New System.Drawing.Point(122, 45)
        Me.txtpickupgo.Margin = New System.Windows.Forms.Padding(5)
        Me.txtpickupgo.Multiline = True
        Me.txtpickupgo.Name = "txtpickupgo"
        Me.txtpickupgo.Size = New System.Drawing.Size(143, 38)
        Me.txtpickupgo.TabIndex = 46
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(9, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 15)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "Location"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(9, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 15)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Area"
        '
        'txtdrivego
        '
        Me.txtdrivego.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdrivego.Location = New System.Drawing.Point(123, 87)
        Me.txtdrivego.Margin = New System.Windows.Forms.Padding(5)
        Me.txtdrivego.Name = "txtdrivego"
        Me.txtdrivego.Size = New System.Drawing.Size(142, 21)
        Me.txtdrivego.TabIndex = 21
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(9, 86)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 15)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Driver"
        '
        'cboGoArea
        '
        Me.cboGoArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboGoArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGoArea.DropDownWidth = 250
        Me.cboGoArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGoArea.FormattingEnabled = True
        Me.cboGoArea.Location = New System.Drawing.Point(122, 20)
        Me.cboGoArea.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGoArea.Name = "cboGoArea"
        Me.cboGoArea.Size = New System.Drawing.Size(142, 23)
        Me.cboGoArea.TabIndex = 45
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.CxBackTrans)
        Me.GroupBox4.Controls.Add(Me.txtbackdate)
        Me.GroupBox4.Controls.Add(Me.Label42)
        Me.GroupBox4.Controls.Add(Me.Label44)
        Me.GroupBox4.Controls.Add(Me.cbotripback)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.cboruteback)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(303, 67)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(279, 116)
        Me.GroupBox4.TabIndex = 48
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Arrival"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(228, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(38, 20)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CxBackTrans
        '
        Me.CxBackTrans.AutoSize = True
        Me.CxBackTrans.Location = New System.Drawing.Point(15, 94)
        Me.CxBackTrans.Name = "CxBackTrans"
        Me.CxBackTrans.Size = New System.Drawing.Size(87, 19)
        Me.CxBackTrans.TabIndex = 16
        Me.CxBackTrans.Text = "Transport"
        Me.CxBackTrans.UseVisualStyleBackColor = True
        '
        'txtbackdate
        '
        Me.txtbackdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbackdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtbackdate.Location = New System.Drawing.Point(124, 44)
        Me.txtbackdate.Name = "txtbackdate"
        Me.txtbackdate.Size = New System.Drawing.Size(98, 21)
        Me.txtbackdate.TabIndex = 13
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(12, 48)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(37, 15)
        Me.Label42.TabIndex = 33
        Me.Label42.Text = "Date"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(12, 74)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(32, 15)
        Me.Label44.TabIndex = 15
        Me.Label44.Text = "Trip"
        '
        'cbotripback
        '
        Me.cbotripback.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbotripback.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbotripback.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotripback.FormattingEnabled = True
        Me.cbotripback.Location = New System.Drawing.Point(124, 68)
        Me.cbotripback.Margin = New System.Windows.Forms.Padding(5)
        Me.cbotripback.Name = "cbotripback"
        Me.cbotripback.Size = New System.Drawing.Size(143, 23)
        Me.cbotripback.TabIndex = 14
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(12, 22)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(37, 15)
        Me.Label45.TabIndex = 13
        Me.Label45.Text = "Rute"
        '
        'cboruteback
        '
        Me.cboruteback.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboruteback.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboruteback.DropDownWidth = 250
        Me.cboruteback.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboruteback.FormattingEnabled = True
        Me.cboruteback.Location = New System.Drawing.Point(124, 18)
        Me.cboruteback.Margin = New System.Windows.Forms.Padding(5)
        Me.cboruteback.Name = "cboruteback"
        Me.cboruteback.Size = New System.Drawing.Size(143, 23)
        Me.cboruteback.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Agent"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.CxGoTrans)
        Me.GroupBox3.Controls.Add(Me.txtgodate)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.cboGotrip)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.cboGorute)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(18, 65)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 118)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Departure"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(227, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 20)
        Me.Button1.TabIndex = 47
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CxGoTrans
        '
        Me.CxGoTrans.AutoSize = True
        Me.CxGoTrans.Location = New System.Drawing.Point(13, 90)
        Me.CxGoTrans.Name = "CxGoTrans"
        Me.CxGoTrans.Size = New System.Drawing.Size(87, 19)
        Me.CxGoTrans.TabIndex = 17
        Me.CxGoTrans.Text = "Transport"
        Me.CxGoTrans.UseVisualStyleBackColor = True
        '
        'txtgodate
        '
        Me.txtgodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgodate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtgodate.Location = New System.Drawing.Point(123, 42)
        Me.txtgodate.Name = "txtgodate"
        Me.txtgodate.Size = New System.Drawing.Size(98, 21)
        Me.txtgodate.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(10, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 15)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Date"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(10, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 15)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Trip"
        '
        'cboGotrip
        '
        Me.cboGotrip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboGotrip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGotrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGotrip.FormattingEnabled = True
        Me.cboGotrip.Location = New System.Drawing.Point(123, 66)
        Me.cboGotrip.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGotrip.Name = "cboGotrip"
        Me.cboGotrip.Size = New System.Drawing.Size(143, 23)
        Me.cboGotrip.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(10, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 15)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Rute"
        '
        'cboGorute
        '
        Me.cboGorute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboGorute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGorute.DropDownWidth = 250
        Me.cboGorute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGorute.FormattingEnabled = True
        Me.cboGorute.Location = New System.Drawing.Point(123, 16)
        Me.cboGorute.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGorute.Name = "cboGorute"
        Me.cboGorute.Size = New System.Drawing.Size(143, 23)
        Me.cboGorute.TabIndex = 12
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(597, 320)
        Me.ShapeContainer1.TabIndex = 65
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 18
        Me.LineShape1.X2 = 581
        Me.LineShape1.Y1 = 33
        Me.LineShape1.Y2 = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Tipe Tiket"
        '
        'cbotipe
        '
        Me.cbotipe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbotipe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbotipe.DropDownWidth = 250
        Me.cbotipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotipe.FormattingEnabled = True
        Me.cbotipe.Items.AddRange(New Object() {"OW - One Way", "RT - Return"})
        Me.cbotipe.Location = New System.Drawing.Point(140, 43)
        Me.cbotipe.Margin = New System.Windows.Forms.Padding(5)
        Me.cbotipe.Name = "cbotipe"
        Me.cbotipe.Size = New System.Drawing.Size(140, 23)
        Me.cbotipe.TabIndex = 70
        '
        'frmMultiBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 355)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMultiBooking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMultiBooking"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtaid As System.Windows.Forms.TextBox
    Friend WithEvents cmdAgent As System.Windows.Forms.Button
    Friend WithEvents txtagent As System.Windows.Forms.TextBox
    Friend WithEvents CxOpen As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPickupBack As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtbackDrive As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cboBackArea As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtpickupgo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtdrivego As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboGoArea As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CxBackTrans As System.Windows.Forms.CheckBox
    Friend WithEvents txtbackdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cbotripback As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cboruteback As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CxGoTrans As System.Windows.Forms.CheckBox
    Friend WithEvents txtgodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboGotrip As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboGorute As System.Windows.Forms.ComboBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents txtlist As System.Windows.Forms.TextBox
    Friend WithEvents txtagentid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbotipe As System.Windows.Forms.ComboBox
End Class
