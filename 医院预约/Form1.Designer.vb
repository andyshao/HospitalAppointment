<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.我的资料ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.工具TToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.刷新医院信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox2 = New System.Windows.Forms.ToolStripComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ExpertBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.LevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KeshiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GoodAtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yuyue = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpertBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.设置ToolStripMenuItem, Me.工具TToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '设置ToolStripMenuItem
        '
        Me.设置ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.我的资料ToolStripMenuItem})
        Me.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem"
        Me.设置ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.设置ToolStripMenuItem.Text = "设置"
        '
        '我的资料ToolStripMenuItem
        '
        Me.我的资料ToolStripMenuItem.Name = "我的资料ToolStripMenuItem"
        Me.我的资料ToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.我的资料ToolStripMenuItem.Text = "我的资料"
        '
        '工具TToolStripMenuItem
        '
        Me.工具TToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.刷新医院信息ToolStripMenuItem})
        Me.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem"
        Me.工具TToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.工具TToolStripMenuItem.Text = "工具(&T)"
        '
        '刷新医院信息ToolStripMenuItem
        '
        Me.刷新医院信息ToolStripMenuItem.Name = "刷新医院信息ToolStripMenuItem"
        Me.刷新医院信息ToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.刷新医院信息ToolStripMenuItem.Text = "刷新医院信息"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripComboBox1, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.ToolStripComboBox2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel1.Text = "医院："
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel2.Text = "科室："
        '
        'ToolStripComboBox2
        '
        Me.ToolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox2.Enabled = False
        Me.ToolStripComboBox2.Name = "ToolStripComboBox2"
        Me.ToolStripComboBox2.Size = New System.Drawing.Size(150, 25)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.LevelDataGridViewTextBoxColumn, Me.KeshiDataGridViewTextBoxColumn, Me.GoodAtDataGridViewTextBoxColumn, Me.yuyue})
        Me.DataGridView1.DataSource = Me.ExpertBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 49)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(784, 490)
        Me.DataGridView1.TabIndex = 2
        '
        'ExpertBindingSource
        '
        Me.ExpertBindingSource.DataSource = GetType(医院预约.Expert)
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "姓名"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.ReadOnly = True
        Me.NameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'LevelDataGridViewTextBoxColumn
        '
        Me.LevelDataGridViewTextBoxColumn.DataPropertyName = "Level"
        Me.LevelDataGridViewTextBoxColumn.HeaderText = "职称"
        Me.LevelDataGridViewTextBoxColumn.Name = "LevelDataGridViewTextBoxColumn"
        Me.LevelDataGridViewTextBoxColumn.ReadOnly = True
        '
        'KeshiDataGridViewTextBoxColumn
        '
        Me.KeshiDataGridViewTextBoxColumn.DataPropertyName = "Keshi"
        Me.KeshiDataGridViewTextBoxColumn.FillWeight = 200.0!
        Me.KeshiDataGridViewTextBoxColumn.HeaderText = "科室"
        Me.KeshiDataGridViewTextBoxColumn.Name = "KeshiDataGridViewTextBoxColumn"
        Me.KeshiDataGridViewTextBoxColumn.ReadOnly = True
        Me.KeshiDataGridViewTextBoxColumn.Width = 200
        '
        'GoodAtDataGridViewTextBoxColumn
        '
        Me.GoodAtDataGridViewTextBoxColumn.DataPropertyName = "GoodAt"
        Me.GoodAtDataGridViewTextBoxColumn.FillWeight = 250.0!
        Me.GoodAtDataGridViewTextBoxColumn.HeaderText = "专长"
        Me.GoodAtDataGridViewTextBoxColumn.Name = "GoodAtDataGridViewTextBoxColumn"
        Me.GoodAtDataGridViewTextBoxColumn.ReadOnly = True
        Me.GoodAtDataGridViewTextBoxColumn.Width = 250
        '
        'yuyue
        '
        Me.yuyue.HeaderText = "自动预约"
        Me.yuyue.Name = "yuyue"
        Me.yuyue.ReadOnly = True
        Me.yuyue.Text = "自动预约"
        Me.yuyue.UseColumnTextForLinkValue = True
        '
        'Timer1
        '
        Me.Timer1.Interval = Global.医院预约.My.MySettings.Default.扫描时间间隔
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(31, 17)
        Me.ToolStripStatusLabel1.Text = "就绪"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "医院预约"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpertBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 工具TToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 刷新医院信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBox2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents 设置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 我的资料ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ExpertBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents LevelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KeshiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GoodAtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yuyue As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel

End Class
