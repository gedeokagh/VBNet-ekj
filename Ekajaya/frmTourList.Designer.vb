<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTourList
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
        Me.LsData = New System.Windows.Forms.DataGridView()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.GB3 = New System.Windows.Forms.GroupBox()
        Me.lsAgent = New System.Windows.Forms.DataGridView()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboGorute = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbobackrute = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbobacktrip = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboGotrip = New System.Windows.Forms.ComboBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txttprice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtprice = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtagentid = New System.Windows.Forms.TextBox()
        Me.cmdAgLs = New System.Windows.Forms.Button()
        Me.txtagent = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboadd = New System.Windows.Forms.Button()
        Me.txtnobook = New System.Windows.Forms.TextBox()
        Me.cboremove = New System.Windows.Forms.Button()
        Me.TXTID = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.LsData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB3.SuspendLayout()
        CType(Me.lsAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.cmdEdit)
        Me.Panel1.Controls.Add(Me.cmdAdd)
        Me.Panel1.Controls.Add(Me.cmdExit)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(751, 43)
        Me.Panel1.TabIndex = 2
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
        'LsData
        '
        Me.LsData.AllowUserToAddRows = False
        Me.LsData.AllowUserToDeleteRows = False
        Me.LsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LsData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsData.Location = New System.Drawing.Point(0, 43)
        Me.LsData.Name = "LsData"
        Me.LsData.ReadOnly = True
        Me.LsData.Size = New System.Drawing.Size(751, 526)
        Me.LsData.TabIndex = 3
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(584, 12)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdEdit.TabIndex = 13
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(503, 12)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 12
        Me.cmdAdd.Text = "&Add New"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(665, 12)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GB3
        '
        Me.GB3.Controls.Add(Me.TXTID)
        Me.GB3.Controls.Add(Me.txtnobook)
        Me.GB3.Controls.Add(Me.GroupBox2)
        Me.GB3.Controls.Add(Me.txttprice)
        Me.GB3.Controls.Add(Me.Label5)
        Me.GB3.Controls.Add(Me.txtname)
        Me.GB3.Controls.Add(Me.Label11)
        Me.GB3.Controls.Add(Me.Label3)
        Me.GB3.Controls.Add(Me.cbobacktrip)
        Me.GB3.Controls.Add(Me.Label4)
        Me.GB3.Controls.Add(Me.cboGotrip)
        Me.GB3.Controls.Add(Me.Label2)
        Me.GB3.Controls.Add(Me.cbobackrute)
        Me.GB3.Controls.Add(Me.Label20)
        Me.GB3.Controls.Add(Me.cboGorute)
        Me.GB3.Controls.Add(Me.lsAgent)
        Me.GB3.Controls.Add(Me.cmdCancel)
        Me.GB3.Controls.Add(Me.cmdSave)
        Me.GB3.Location = New System.Drawing.Point(137, 49)
        Me.GB3.Name = "GB3"
        Me.GB3.Size = New System.Drawing.Size(508, 425)
        Me.GB3.TabIndex = 4
        Me.GB3.TabStop = False
        '
        'lsAgent
        '
        Me.lsAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lsAgent.Location = New System.Drawing.Point(12, 216)
        Me.lsAgent.Name = "lsAgent"
        Me.lsAgent.Size = New System.Drawing.Size(484, 195)
        Me.lsAgent.TabIndex = 22
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(421, 101)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(339, 101)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 16
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(9, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 13)
        Me.Label20.TabIndex = 55
        Me.Label20.Text = "Depart Rute"
        '
        'cboGorute
        '
        Me.cboGorute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGorute.FormattingEnabled = True
        Me.cboGorute.Location = New System.Drawing.Point(104, 44)
        Me.cboGorute.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGorute.Name = "cboGorute"
        Me.cboGorute.Size = New System.Drawing.Size(141, 23)
        Me.cboGorute.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Return Rute"
        '
        'cbobackrute
        '
        Me.cbobackrute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobackrute.FormattingEnabled = True
        Me.cbobackrute.Location = New System.Drawing.Point(104, 70)
        Me.cbobackrute.Margin = New System.Windows.Forms.Padding(5)
        Me.cbobackrute.Name = "cbobackrute"
        Me.cbobackrute.Size = New System.Drawing.Size(141, 23)
        Me.cbobackrute.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(260, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Return Trip"
        '
        'cbobacktrip
        '
        Me.cbobacktrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobacktrip.FormattingEnabled = True
        Me.cbobacktrip.Location = New System.Drawing.Point(355, 70)
        Me.cbobacktrip.Margin = New System.Windows.Forms.Padding(5)
        Me.cbobacktrip.Name = "cbobacktrip"
        Me.cbobacktrip.Size = New System.Drawing.Size(141, 23)
        Me.cbobacktrip.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(260, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Depart Trip"
        '
        'cboGotrip
        '
        Me.cboGotrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGotrip.FormattingEnabled = True
        Me.cboGotrip.Location = New System.Drawing.Point(355, 44)
        Me.cboGotrip.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGotrip.Name = "cboGotrip"
        Me.cboGotrip.Size = New System.Drawing.Size(141, 23)
        Me.cboGotrip.TabIndex = 58
        '
        'txtname
        '
        Me.txtname.Location = New System.Drawing.Point(104, 21)
        Me.txtname.Margin = New System.Windows.Forms.Padding(5)
        Me.txtname.MaxLength = 25
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(227, 20)
        Me.txtname.TabIndex = 71
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 15)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "Tour Name"
        '
        'txttprice
        '
        Me.txttprice.Location = New System.Drawing.Point(104, 96)
        Me.txttprice.Margin = New System.Windows.Forms.Padding(5)
        Me.txttprice.MaxLength = 11
        Me.txttprice.Name = "txttprice"
        Me.txttprice.Size = New System.Drawing.Size(141, 20)
        Me.txttprice.TabIndex = 73
        Me.txttprice.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Price"
        Me.Label5.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboremove)
        Me.GroupBox2.Controls.Add(Me.cboadd)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtagentid)
        Me.GroupBox2.Controls.Add(Me.cmdAgLs)
        Me.GroupBox2.Controls.Add(Me.txtagent)
        Me.GroupBox2.Controls.Add(Me.txtprice)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 129)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(484, 74)
        Me.GroupBox2.TabIndex = 75
        Me.GroupBox2.TabStop = False
        '
        'txtprice
        '
        Me.txtprice.Location = New System.Drawing.Point(265, 33)
        Me.txtprice.Margin = New System.Windows.Forms.Padding(5)
        Me.txtprice.MaxLength = 11
        Me.txtprice.Name = "txtprice"
        Me.txtprice.Size = New System.Drawing.Size(121, 20)
        Me.txtprice.TabIndex = 73
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(262, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 15)
        Me.Label25.TabIndex = 74
        Me.Label25.Text = "Harga"
        '
        'txtagentid
        '
        Me.txtagentid.Location = New System.Drawing.Point(60, 11)
        Me.txtagentid.Name = "txtagentid"
        Me.txtagentid.Size = New System.Drawing.Size(38, 20)
        Me.txtagentid.TabIndex = 78
        Me.txtagentid.Visible = False
        '
        'cmdAgLs
        '
        Me.cmdAgLs.Location = New System.Drawing.Point(202, 33)
        Me.cmdAgLs.Name = "cmdAgLs"
        Me.cmdAgLs.Size = New System.Drawing.Size(27, 20)
        Me.cmdAgLs.TabIndex = 77
        Me.cmdAgLs.Text = "+"
        Me.cmdAgLs.UseVisualStyleBackColor = True
        '
        'txtagent
        '
        Me.txtagent.Location = New System.Drawing.Point(14, 34)
        Me.txtagent.Name = "txtagent"
        Me.txtagent.Size = New System.Drawing.Size(182, 20)
        Me.txtagent.TabIndex = 76
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(11, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Agent"
        '
        'cboadd
        '
        Me.cboadd.Location = New System.Drawing.Point(403, 16)
        Me.cboadd.Name = "cboadd"
        Me.cboadd.Size = New System.Drawing.Size(75, 23)
        Me.cboadd.TabIndex = 76
        Me.cboadd.Text = "Add"
        Me.cboadd.UseVisualStyleBackColor = True
        '
        'txtnobook
        '
        Me.txtnobook.Location = New System.Drawing.Point(355, 16)
        Me.txtnobook.Name = "txtnobook"
        Me.txtnobook.Size = New System.Drawing.Size(89, 20)
        Me.txtnobook.TabIndex = 76
        Me.txtnobook.Visible = False
        '
        'cboremove
        '
        Me.cboremove.Location = New System.Drawing.Point(403, 43)
        Me.cboremove.Name = "cboremove"
        Me.cboremove.Size = New System.Drawing.Size(75, 23)
        Me.cboremove.TabIndex = 80
        Me.cboremove.Text = "Remove"
        Me.cboremove.UseVisualStyleBackColor = True
        '
        'TXTID
        '
        Me.TXTID.Location = New System.Drawing.Point(450, 16)
        Me.TXTID.Name = "TXTID"
        Me.TXTID.Size = New System.Drawing.Size(31, 20)
        Me.TXTID.TabIndex = 77
        Me.TXTID.Visible = False
        '
        'frmTourList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 569)
        Me.Controls.Add(Me.GB3)
        Me.Controls.Add(Me.LsData)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTourList"
        Me.Text = "frmTourList"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.LsData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB3.ResumeLayout(False)
        Me.GB3.PerformLayout()
        CType(Me.lsAgent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LsData As System.Windows.Forms.DataGridView
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GB3 As System.Windows.Forms.GroupBox
    Friend WithEvents lsAgent As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbobackrute As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboGorute As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbobacktrip As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboGotrip As System.Windows.Forms.ComboBox
    Friend WithEvents txttprice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtprice As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboadd As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtagentid As System.Windows.Forms.TextBox
    Friend WithEvents cmdAgLs As System.Windows.Forms.Button
    Friend WithEvents txtagent As System.Windows.Forms.TextBox
    Friend WithEvents txtnobook As System.Windows.Forms.TextBox
    Friend WithEvents cboremove As System.Windows.Forms.Button
    Friend WithEvents TXTID As System.Windows.Forms.TextBox
End Class
