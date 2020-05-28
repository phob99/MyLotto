<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_EnterData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.T_BuyerBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbBuyer = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLottoDate = New System.Windows.Forms.Label()
        Me.GB1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNumberType = New System.Windows.Forms.Label()
        Me.txtLang = New System.Windows.Forms.TextBox()
        Me.txtTod = New System.Windows.Forms.TextBox()
        Me.txtBon = New System.Windows.Forms.TextBox()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.lblLottoBill_ID = New System.Windows.Forms.Label()
        Me.btnEditBuyer = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GB1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 23)
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 23)
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(100, 23)
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(23, 23)
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 23)
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 23)
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 23)
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 23)
        '
        'T_BuyerBindingNavigatorSaveItem
        '
        Me.T_BuyerBindingNavigatorSaveItem.Name = "T_BuyerBindingNavigatorSaveItem"
        Me.T_BuyerBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnEditBuyer)
        Me.GroupBox2.Controls.Add(Me.lblLottoBill_ID)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbBuyer)
        Me.GroupBox2.Font = Global.MyLotto.My.MySettings.Default.TabFont
        Me.GroupBox2.Location = New System.Drawing.Point(362, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(576, 100)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "บิล"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label4.Font = Global.MyLotto.My.MySettings.Default.TabFont
        Me.Label4.Location = New System.Drawing.Point(6, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 39)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ที่"
        '
        'cbBuyer
        '
        Me.cbBuyer.DisplayMember = "Id"
        Me.cbBuyer.FormattingEnabled = True
        Me.cbBuyer.Location = New System.Drawing.Point(131, 39)
        Me.cbBuyer.Name = "cbBuyer"
        Me.cbBuyer.Size = New System.Drawing.Size(373, 47)
        Me.cbBuyer.TabIndex = 0
        Me.cbBuyer.ValueMember = "Id"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblLottoDate)
        Me.GroupBox1.Font = Global.MyLotto.My.MySettings.Default.TabFont
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "งวด"
        '
        'lblLottoDate
        '
        Me.lblLottoDate.AutoSize = True
        Me.lblLottoDate.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblLottoDate.Font = Global.MyLotto.My.MySettings.Default.TabFont
        Me.lblLottoDate.Location = New System.Drawing.Point(6, 42)
        Me.lblLottoDate.Name = "lblLottoDate"
        Me.lblLottoDate.Size = New System.Drawing.Size(331, 39)
        Me.lblLottoDate.TabIndex = 0
        Me.lblLottoDate.Text = "วันที่ 1 มิถุนายน 2563"
        '
        'GB1
        '
        Me.GB1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB1.Controls.Add(Me.DataGridView1)
        Me.GB1.Controls.Add(Me.Label3)
        Me.GB1.Controls.Add(Me.Label2)
        Me.GB1.Controls.Add(Me.Label1)
        Me.GB1.Controls.Add(Me.lblNumberType)
        Me.GB1.Controls.Add(Me.txtLang)
        Me.GB1.Controls.Add(Me.txtTod)
        Me.GB1.Controls.Add(Me.txtBon)
        Me.GB1.Controls.Add(Me.txtNumber)
        Me.GB1.Font = Global.MyLotto.My.MySettings.Default.TabFont
        Me.GB1.Location = New System.Drawing.Point(12, 118)
        Me.GB1.Name = "GB1"
        Me.GB1.Size = New System.Drawing.Size(926, 754)
        Me.GB1.TabIndex = 1
        Me.GB1.TabStop = False
        Me.GB1.Text = "ใส่ข้อมูล"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(34, 274)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(242, 209)
        Me.DataGridView1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(733, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 55)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ล่าง"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(514, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 55)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "โต๊ด"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 55)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "บน"
        '
        'lblNumberType
        '
        Me.lblNumberType.AutoSize = True
        Me.lblNumberType.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblNumberType.Location = New System.Drawing.Point(37, 166)
        Me.lblNumberType.Name = "lblNumberType"
        Me.lblNumberType.Size = New System.Drawing.Size(0, 39)
        Me.lblNumberType.TabIndex = 1
        '
        'txtLang
        '
        Me.txtLang.Font = Global.MyLotto.My.MySettings.Default.ValueText
        Me.txtLang.Location = New System.Drawing.Point(700, 78)
        Me.txtLang.MaxLength = 100
        Me.txtLang.Name = "txtLang"
        Me.txtLang.Size = New System.Drawing.Size(170, 52)
        Me.txtLang.TabIndex = 4
        Me.txtLang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTod
        '
        Me.txtTod.Font = Global.MyLotto.My.MySettings.Default.ValueText
        Me.txtTod.Location = New System.Drawing.Point(481, 78)
        Me.txtTod.MaxLength = 100
        Me.txtTod.Name = "txtTod"
        Me.txtTod.Size = New System.Drawing.Size(170, 52)
        Me.txtTod.TabIndex = 3
        Me.txtTod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBon
        '
        Me.txtBon.Font = Global.MyLotto.My.MySettings.Default.ValueText
        Me.txtBon.Location = New System.Drawing.Point(258, 78)
        Me.txtBon.MaxLength = 100
        Me.txtBon.Name = "txtBon"
        Me.txtBon.Size = New System.Drawing.Size(170, 52)
        Me.txtBon.TabIndex = 2
        Me.txtBon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumber
        '
        Me.txtNumber.Font = Global.MyLotto.My.MySettings.Default.NumberText
        Me.txtNumber.Location = New System.Drawing.Point(34, 78)
        Me.txtNumber.MaxLength = 3
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(170, 85)
        Me.txtNumber.TabIndex = 1
        Me.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLottoBill_ID
        '
        Me.lblLottoBill_ID.AutoSize = True
        Me.lblLottoBill_ID.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblLottoBill_ID.Font = Global.MyLotto.My.MySettings.Default.TabFont
        Me.lblLottoBill_ID.Location = New System.Drawing.Point(38, 42)
        Me.lblLottoBill_ID.Name = "lblLottoBill_ID"
        Me.lblLottoBill_ID.Size = New System.Drawing.Size(0, 39)
        Me.lblLottoBill_ID.TabIndex = 0
        '
        'btnEditBuyer
        '
        Me.btnEditBuyer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditBuyer.Location = New System.Drawing.Point(510, 42)
        Me.btnEditBuyer.Name = "btnEditBuyer"
        Me.btnEditBuyer.Size = New System.Drawing.Size(60, 39)
        Me.btnEditBuyer.TabIndex = 0
        Me.btnEditBuyer.Text = "..."
        Me.btnEditBuyer.UseVisualStyleBackColor = True
        Me.btnEditBuyer.Visible = False
        '
        'frm_EnterData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 778)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GB1)
        Me.Name = "frm_EnterData"
        Me.ShowIcon = False
        Me.Text = "คีย์ข้อมูล"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GB1.ResumeLayout(False)
        Me.GB1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GB1 As GroupBox
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents lblNumberType As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTod As TextBox
    Friend WithEvents txtBon As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLang As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblLottoDate As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents T_BuyerBindingSource As BindingSource
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents T_BuyerBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents cbBuyer As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblLottoBill_ID As Label
    Private WithEvents btnEditBuyer As Button
End Class
