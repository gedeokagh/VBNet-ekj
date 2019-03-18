<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgentRate
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.CboAgent = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lsData = New System.Windows.Forms.DataGridView()
        Me.GB3 = New System.Windows.Forms.GroupBox()
        Me.cxshuttle = New System.Windows.Forms.CheckBox()
        Me.txtnobook = New System.Windows.Forms.TextBox()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.lsRute = New System.Windows.Forms.DataGridView()
        Me.txtend = New System.Windows.Forms.DateTimePicker()
        Me.txtstart = New System.Windows.Forms.DateTimePicker()
        Me.cmdAgLs = New System.Windows.Forms.Button()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.txtsurecharge = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GB2 = New System.Windows.Forms.GroupBox()
        Me.txt3a = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.lsData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB3.SuspendLayout()
        CType(Me.lsRute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(694, 122)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdEdit)
        Me.GroupBox1.Controls.Add(Me.cmdAdd)
        Me.GroupBox1.Controls.Add(Me.CboAgent)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmdExit)
        Me.GroupBox1.Controls.Add(Me.cmdFilter)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(684, 108)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(332, 53)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdEdit.TabIndex = 8
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(332, 27)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 7
        Me.cmdAdd.Text = "&Add New"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'CboAgent
        '
        Me.CboAgent.FormattingEnabled = True
        Me.CboAgent.Location = New System.Drawing.Point(115, 55)
        Me.CboAgent.Name = "CboAgent"
        Me.CboAgent.Size = New System.Drawing.Size(121, 21)
        Me.CboAgent.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Select Agent"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(332, 77)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdFilter
        '
        Me.cmdFilter.Location = New System.Drawing.Point(242, 53)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(75, 23)
        Me.cmdFilter.TabIndex = 1
        Me.cmdFilter.Text = "&Fillter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agent Rate"
        '
        'lsData
        '
        Me.lsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lsData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsData.Location = New System.Drawing.Point(10, 23)
        Me.lsData.Name = "lsData"
        Me.lsData.Size = New System.Drawing.Size(674, 438)
        Me.lsData.TabIndex = 0
        '
        'GB3
        '
        Me.GB3.Controls.Add(Me.txt3a)
        Me.GB3.Controls.Add(Me.Label7)
        Me.GB3.Controls.Add(Me.cxshuttle)
        Me.GB3.Controls.Add(Me.txtnobook)
        Me.GB3.Controls.Add(Me.txtid)
        Me.GB3.Controls.Add(Me.lsRute)
        Me.GB3.Controls.Add(Me.txtend)
        Me.GB3.Controls.Add(Me.txtstart)
        Me.GB3.Controls.Add(Me.cmdAgLs)
        Me.GB3.Controls.Add(Me.txtname)
        Me.GB3.Controls.Add(Me.cmdCancel)
        Me.GB3.Controls.Add(Me.cmdSave)
        Me.GB3.Controls.Add(Me.txtsurecharge)
        Me.GB3.Controls.Add(Me.Label6)
        Me.GB3.Controls.Add(Me.Label5)
        Me.GB3.Controls.Add(Me.Label4)
        Me.GB3.Controls.Add(Me.Label3)
        Me.GB3.Location = New System.Drawing.Point(73, 6)
        Me.GB3.Name = "GB3"
        Me.GB3.Size = New System.Drawing.Size(549, 452)
        Me.GB3.TabIndex = 1
        Me.GB3.TabStop = False
        '
        'cxshuttle
        '
        Me.cxshuttle.AutoSize = True
        Me.cxshuttle.Location = New System.Drawing.Point(405, 119)
        Me.cxshuttle.Name = "cxshuttle"
        Me.cxshuttle.Size = New System.Drawing.Size(138, 17)
        Me.cxshuttle.TabIndex = 25
        Me.cxshuttle.Text = "All Price Include Shuttle"
        Me.cxshuttle.UseVisualStyleBackColor = True
        Me.cxshuttle.Visible = False
        '
        'txtnobook
        '
        Me.txtnobook.Location = New System.Drawing.Point(193, 10)
        Me.txtnobook.Name = "txtnobook"
        Me.txtnobook.Size = New System.Drawing.Size(89, 20)
        Me.txtnobook.TabIndex = 24
        Me.txtnobook.Visible = False
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(73, 10)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(114, 20)
        Me.txtid.TabIndex = 23
        Me.txtid.Visible = False
        '
        'lsRute
        '
        Me.lsRute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lsRute.Location = New System.Drawing.Point(8, 142)
        Me.lsRute.Name = "lsRute"
        Me.lsRute.Size = New System.Drawing.Size(532, 304)
        Me.lsRute.TabIndex = 22
        '
        'txtend
        '
        Me.txtend.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtend.Location = New System.Drawing.Point(277, 71)
        Me.txtend.Name = "txtend"
        Me.txtend.Size = New System.Drawing.Size(155, 20)
        Me.txtend.TabIndex = 21
        '
        'txtstart
        '
        Me.txtstart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtstart.Location = New System.Drawing.Point(277, 32)
        Me.txtstart.Name = "txtstart"
        Me.txtstart.Size = New System.Drawing.Size(155, 20)
        Me.txtstart.TabIndex = 20
        '
        'cmdAgLs
        '
        Me.cmdAgLs.Location = New System.Drawing.Point(211, 31)
        Me.cmdAgLs.Name = "cmdAgLs"
        Me.cmdAgLs.Size = New System.Drawing.Size(27, 20)
        Me.cmdAgLs.TabIndex = 19
        Me.cmdAgLs.Text = "+"
        Me.cmdAgLs.UseVisualStyleBackColor = True
        '
        'txtname
        '
        Me.txtname.Location = New System.Drawing.Point(23, 32)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(182, 20)
        Me.txtname.TabIndex = 18
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(448, 69)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(448, 30)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 16
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'txtsurecharge
        '
        Me.txtsurecharge.Location = New System.Drawing.Point(23, 71)
        Me.txtsurecharge.Name = "txtsurecharge"
        Me.txtsurecharge.Size = New System.Drawing.Size(215, 20)
        Me.txtsurecharge.TabIndex = 15
        Me.txtsurecharge.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Surecharge"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(279, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(280, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Validity Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "AgentID"
        '
        'GB2
        '
        Me.GB2.Controls.Add(Me.GB3)
        Me.GB2.Controls.Add(Me.lsData)
        Me.GB2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB2.Location = New System.Drawing.Point(0, 122)
        Me.GB2.Name = "GB2"
        Me.GB2.Padding = New System.Windows.Forms.Padding(10)
        Me.GB2.Size = New System.Drawing.Size(694, 471)
        Me.GB2.TabIndex = 11
        Me.GB2.TabStop = False
        '
        'txt3a
        '
        Me.txt3a.Location = New System.Drawing.Point(24, 110)
        Me.txt3a.Name = "txt3a"
        Me.txt3a.Size = New System.Drawing.Size(215, 20)
        Me.txt3a.TabIndex = 27
        Me.txt3a.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "3 Angle"
        '
        'frmAgentRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(694, 593)
        Me.Controls.Add(Me.GB2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmAgentRate"
        Me.Text = "Agent Rate"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.lsData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB3.ResumeLayout(False)
        Me.GB3.PerformLayout()
        CType(Me.lsRute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents CboAgent As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lsData As System.Windows.Forms.DataGridView
    Friend WithEvents GB3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtsurecharge As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GB2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtend As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtstart As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdAgLs As System.Windows.Forms.Button
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents lsRute As System.Windows.Forms.DataGridView
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents txtnobook As System.Windows.Forms.TextBox
    Friend WithEvents cxshuttle As System.Windows.Forms.CheckBox
    Friend WithEvents txt3a As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
