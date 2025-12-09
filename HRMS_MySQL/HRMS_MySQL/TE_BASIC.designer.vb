<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_BASIC
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.BT_TEB_GetData = New System.Windows.Forms.Button
        Me.BT_TEB_Create = New System.Windows.Forms.Button
        Me.BT_TEB_Modify = New System.Windows.Forms.Button
        Me.BT_TEB_Del = New System.Windows.Forms.Button
        Me.BT_TEB_Close = New System.Windows.Forms.Button
        Me.DGV_TEB = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_TEB_NAME = New System.Windows.Forms.TextBox
        Me.TB_TEB_Title = New System.Windows.Forms.TextBox
        Me.TB_TEB_OnBoardDate = New System.Windows.Forms.TextBox
        Me.CB_TEB_DeptCode = New System.Windows.Forms.ComboBox
        Me.CB_TEB_AREA = New System.Windows.Forms.ComboBox
        Me.CB_TEB_FUNCTION = New System.Windows.Forms.ComboBox
        Me.TB_TEB_MENO = New System.Windows.Forms.TextBox
        Me.TB_TEB_ID = New System.Windows.Forms.TextBox
        Me.LB_TEB_SHIFT = New System.Windows.Forms.Label
        Me.CB_TEB_Active = New System.Windows.Forms.CheckBox
        Me.BT_TEB_QUIT = New System.Windows.Forms.Button
        Me.BT_TEB_IDQ = New System.Windows.Forms.Button
        Me.BT_TEB_DEPQ = New System.Windows.Forms.Button
        Me.BT_TEB_TITLEQ = New System.Windows.Forms.Button
        Me.BT_TEB_AREAQ = New System.Windows.Forms.Button
        Me.BT_TEB_FunctionQ = New System.Windows.Forms.Button
        Me.CB_TEB_VACID = New System.Windows.Forms.ComboBox
        Me.LB_VAC_TITLE = New System.Windows.Forms.Label
        Me.LB_TEB_VAC_DESC = New System.Windows.Forms.Label
        Me.TB_TEB_Start_date = New System.Windows.Forms.TextBox
        Me.TB_TEB_END_DATE = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.BT_TE_VAC_QUERY = New System.Windows.Forms.Button
        Me.TB_TEB_AreaDate = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        CType(Me.DGV_TEB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "人員基本資料作業畫面"
        '
        'BT_TEB_GetData
        '
        Me.BT_TEB_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_TEB_GetData.Location = New System.Drawing.Point(24, 49)
        Me.BT_TEB_GetData.Name = "BT_TEB_GetData"
        Me.BT_TEB_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_TEB_GetData.TabIndex = 1
        Me.BT_TEB_GetData.Text = "撈資料"
        Me.BT_TEB_GetData.UseVisualStyleBackColor = True
        '
        'BT_TEB_Create
        '
        Me.BT_TEB_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_TEB_Create.Location = New System.Drawing.Point(24, 86)
        Me.BT_TEB_Create.Name = "BT_TEB_Create"
        Me.BT_TEB_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_TEB_Create.TabIndex = 2
        Me.BT_TEB_Create.Text = " 新增資料"
        Me.BT_TEB_Create.UseVisualStyleBackColor = True
        '
        'BT_TEB_Modify
        '
        Me.BT_TEB_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_TEB_Modify.Location = New System.Drawing.Point(24, 123)
        Me.BT_TEB_Modify.Name = "BT_TEB_Modify"
        Me.BT_TEB_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_TEB_Modify.TabIndex = 3
        Me.BT_TEB_Modify.Text = "修改資料"
        Me.BT_TEB_Modify.UseVisualStyleBackColor = True
        '
        'BT_TEB_Del
        '
        Me.BT_TEB_Del.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_TEB_Del.Location = New System.Drawing.Point(24, 160)
        Me.BT_TEB_Del.Name = "BT_TEB_Del"
        Me.BT_TEB_Del.Size = New System.Drawing.Size(146, 31)
        Me.BT_TEB_Del.TabIndex = 4
        Me.BT_TEB_Del.Text = "Export to Excel"
        Me.BT_TEB_Del.UseVisualStyleBackColor = True
        '
        'BT_TEB_Close
        '
        Me.BT_TEB_Close.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_TEB_Close.Location = New System.Drawing.Point(24, 197)
        Me.BT_TEB_Close.Name = "BT_TEB_Close"
        Me.BT_TEB_Close.Size = New System.Drawing.Size(146, 31)
        Me.BT_TEB_Close.TabIndex = 5
        Me.BT_TEB_Close.Text = "Main Page"
        Me.BT_TEB_Close.UseVisualStyleBackColor = True
        '
        'DGV_TEB
        '
        Me.DGV_TEB.AccessibleRole = System.Windows.Forms.AccessibleRole.ColumnHeader
        Me.DGV_TEB.AllowUserToAddRows = False
        Me.DGV_TEB.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_TEB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_TEB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_TEB.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_TEB.Location = New System.Drawing.Point(5, 293)
        Me.DGV_TEB.Name = "DGV_TEB"
        Me.DGV_TEB.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_TEB.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_TEB.RowTemplate.Height = 24
        Me.DGV_TEB.Size = New System.Drawing.Size(911, 254)
        Me.DGV_TEB.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(209, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "工        號"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(209, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "姓        名"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(209, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "部門代碼"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(209, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "職        稱"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(209, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "到職日期"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(566, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "班        別"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(566, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "工作區域"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(566, 172)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "備        註"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(566, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 20)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "工作內容"
        '
        'TB_TEB_NAME
        '
        Me.TB_TEB_NAME.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEB_NAME.Location = New System.Drawing.Point(288, 89)
        Me.TB_TEB_NAME.Name = "TB_TEB_NAME"
        Me.TB_TEB_NAME.Size = New System.Drawing.Size(171, 29)
        Me.TB_TEB_NAME.TabIndex = 17
        '
        'TB_TEB_Title
        '
        Me.TB_TEB_Title.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEB_Title.Location = New System.Drawing.Point(288, 158)
        Me.TB_TEB_Title.Name = "TB_TEB_Title"
        Me.TB_TEB_Title.Size = New System.Drawing.Size(171, 29)
        Me.TB_TEB_Title.TabIndex = 19
        '
        'TB_TEB_OnBoardDate
        '
        Me.TB_TEB_OnBoardDate.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEB_OnBoardDate.Location = New System.Drawing.Point(288, 195)
        Me.TB_TEB_OnBoardDate.Name = "TB_TEB_OnBoardDate"
        Me.TB_TEB_OnBoardDate.Size = New System.Drawing.Size(171, 29)
        Me.TB_TEB_OnBoardDate.TabIndex = 20
        '
        'CB_TEB_DeptCode
        '
        Me.CB_TEB_DeptCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TEB_DeptCode.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_TEB_DeptCode.FormattingEnabled = True
        Me.CB_TEB_DeptCode.Location = New System.Drawing.Point(288, 122)
        Me.CB_TEB_DeptCode.Name = "CB_TEB_DeptCode"
        Me.CB_TEB_DeptCode.Size = New System.Drawing.Size(171, 28)
        Me.CB_TEB_DeptCode.TabIndex = 21
        '
        'CB_TEB_AREA
        '
        Me.CB_TEB_AREA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TEB_AREA.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_TEB_AREA.FormattingEnabled = True
        Me.CB_TEB_AREA.Location = New System.Drawing.Point(645, 55)
        Me.CB_TEB_AREA.Name = "CB_TEB_AREA"
        Me.CB_TEB_AREA.Size = New System.Drawing.Size(171, 28)
        Me.CB_TEB_AREA.TabIndex = 23
        '
        'CB_TEB_FUNCTION
        '
        Me.CB_TEB_FUNCTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TEB_FUNCTION.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_TEB_FUNCTION.FormattingEnabled = True
        Me.CB_TEB_FUNCTION.Location = New System.Drawing.Point(645, 92)
        Me.CB_TEB_FUNCTION.Name = "CB_TEB_FUNCTION"
        Me.CB_TEB_FUNCTION.Size = New System.Drawing.Size(171, 28)
        Me.CB_TEB_FUNCTION.TabIndex = 24
        '
        'TB_TEB_MENO
        '
        Me.TB_TEB_MENO.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEB_MENO.Location = New System.Drawing.Point(645, 166)
        Me.TB_TEB_MENO.Name = "TB_TEB_MENO"
        Me.TB_TEB_MENO.Size = New System.Drawing.Size(171, 29)
        Me.TB_TEB_MENO.TabIndex = 25
        '
        'TB_TEB_ID
        '
        Me.TB_TEB_ID.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEB_ID.Location = New System.Drawing.Point(288, 54)
        Me.TB_TEB_ID.Name = "TB_TEB_ID"
        Me.TB_TEB_ID.Size = New System.Drawing.Size(171, 29)
        Me.TB_TEB_ID.TabIndex = 26
        '
        'LB_TEB_SHIFT
        '
        Me.LB_TEB_SHIFT.AutoSize = True
        Me.LB_TEB_SHIFT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_TEB_SHIFT.Location = New System.Drawing.Point(645, 23)
        Me.LB_TEB_SHIFT.Name = "LB_TEB_SHIFT"
        Me.LB_TEB_SHIFT.Size = New System.Drawing.Size(0, 20)
        Me.LB_TEB_SHIFT.TabIndex = 27
        '
        'CB_TEB_Active
        '
        Me.CB_TEB_Active.AutoSize = True
        Me.CB_TEB_Active.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_TEB_Active.Location = New System.Drawing.Point(652, 198)
        Me.CB_TEB_Active.Name = "CB_TEB_Active"
        Me.CB_TEB_Active.Size = New System.Drawing.Size(76, 24)
        Me.CB_TEB_Active.TabIndex = 28
        Me.CB_TEB_Active.Text = "在職否"
        Me.CB_TEB_Active.UseVisualStyleBackColor = True
        '
        'BT_TEB_QUIT
        '
        Me.BT_TEB_QUIT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_TEB_QUIT.Location = New System.Drawing.Point(24, 234)
        Me.BT_TEB_QUIT.Name = "BT_TEB_QUIT"
        Me.BT_TEB_QUIT.Size = New System.Drawing.Size(146, 31)
        Me.BT_TEB_QUIT.TabIndex = 29
        Me.BT_TEB_QUIT.Text = "離職人員資料"
        Me.BT_TEB_QUIT.UseVisualStyleBackColor = True
        '
        'BT_TEB_IDQ
        '
        Me.BT_TEB_IDQ.Location = New System.Drawing.Point(465, 54)
        Me.BT_TEB_IDQ.Name = "BT_TEB_IDQ"
        Me.BT_TEB_IDQ.Size = New System.Drawing.Size(29, 21)
        Me.BT_TEB_IDQ.TabIndex = 30
        Me.BT_TEB_IDQ.Text = "Q"
        Me.BT_TEB_IDQ.UseVisualStyleBackColor = True
        '
        'BT_TEB_DEPQ
        '
        Me.BT_TEB_DEPQ.Location = New System.Drawing.Point(465, 125)
        Me.BT_TEB_DEPQ.Name = "BT_TEB_DEPQ"
        Me.BT_TEB_DEPQ.Size = New System.Drawing.Size(29, 21)
        Me.BT_TEB_DEPQ.TabIndex = 31
        Me.BT_TEB_DEPQ.Text = "Q"
        Me.BT_TEB_DEPQ.UseVisualStyleBackColor = True
        '
        'BT_TEB_TITLEQ
        '
        Me.BT_TEB_TITLEQ.Location = New System.Drawing.Point(465, 162)
        Me.BT_TEB_TITLEQ.Name = "BT_TEB_TITLEQ"
        Me.BT_TEB_TITLEQ.Size = New System.Drawing.Size(29, 21)
        Me.BT_TEB_TITLEQ.TabIndex = 32
        Me.BT_TEB_TITLEQ.Text = "Q"
        Me.BT_TEB_TITLEQ.UseVisualStyleBackColor = True
        '
        'BT_TEB_AREAQ
        '
        Me.BT_TEB_AREAQ.Location = New System.Drawing.Point(837, 57)
        Me.BT_TEB_AREAQ.Name = "BT_TEB_AREAQ"
        Me.BT_TEB_AREAQ.Size = New System.Drawing.Size(29, 21)
        Me.BT_TEB_AREAQ.TabIndex = 34
        Me.BT_TEB_AREAQ.Text = "Q"
        Me.BT_TEB_AREAQ.UseVisualStyleBackColor = True
        '
        'BT_TEB_FunctionQ
        '
        Me.BT_TEB_FunctionQ.Location = New System.Drawing.Point(837, 94)
        Me.BT_TEB_FunctionQ.Name = "BT_TEB_FunctionQ"
        Me.BT_TEB_FunctionQ.Size = New System.Drawing.Size(29, 21)
        Me.BT_TEB_FunctionQ.TabIndex = 35
        Me.BT_TEB_FunctionQ.Text = "Q"
        Me.BT_TEB_FunctionQ.UseVisualStyleBackColor = True
        '
        'CB_TEB_VACID
        '
        Me.CB_TEB_VACID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TEB_VACID.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_TEB_VACID.FormattingEnabled = True
        Me.CB_TEB_VACID.Location = New System.Drawing.Point(288, 234)
        Me.CB_TEB_VACID.Name = "CB_TEB_VACID"
        Me.CB_TEB_VACID.Size = New System.Drawing.Size(136, 28)
        Me.CB_TEB_VACID.TabIndex = 36
        '
        'LB_VAC_TITLE
        '
        Me.LB_VAC_TITLE.AutoSize = True
        Me.LB_VAC_TITLE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_VAC_TITLE.Location = New System.Drawing.Point(215, 239)
        Me.LB_VAC_TITLE.Name = "LB_VAC_TITLE"
        Me.LB_VAC_TITLE.Size = New System.Drawing.Size(73, 20)
        Me.LB_VAC_TITLE.TabIndex = 37
        Me.LB_VAC_TITLE.Text = "假別編號"
        '
        'LB_TEB_VAC_DESC
        '
        Me.LB_TEB_VAC_DESC.AutoSize = True
        Me.LB_TEB_VAC_DESC.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_TEB_VAC_DESC.Location = New System.Drawing.Point(363, 234)
        Me.LB_TEB_VAC_DESC.Name = "LB_TEB_VAC_DESC"
        Me.LB_TEB_VAC_DESC.Size = New System.Drawing.Size(0, 20)
        Me.LB_TEB_VAC_DESC.TabIndex = 38
        '
        'TB_TEB_Start_date
        '
        Me.TB_TEB_Start_date.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEB_Start_date.Location = New System.Drawing.Point(541, 234)
        Me.TB_TEB_Start_date.Name = "TB_TEB_Start_date"
        Me.TB_TEB_Start_date.Size = New System.Drawing.Size(109, 29)
        Me.TB_TEB_Start_date.TabIndex = 39
        '
        'TB_TEB_END_DATE
        '
        Me.TB_TEB_END_DATE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEB_END_DATE.Location = New System.Drawing.Point(738, 236)
        Me.TB_TEB_END_DATE.Name = "TB_TEB_END_DATE"
        Me.TB_TEB_END_DATE.Size = New System.Drawing.Size(109, 29)
        Me.TB_TEB_END_DATE.TabIndex = 40
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(466, 240)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 20)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "開始日期"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(659, 240)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 20)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "結束日期"
        '
        'BT_TE_VAC_QUERY
        '
        Me.BT_TE_VAC_QUERY.Location = New System.Drawing.Point(430, 241)
        Me.BT_TE_VAC_QUERY.Name = "BT_TE_VAC_QUERY"
        Me.BT_TE_VAC_QUERY.Size = New System.Drawing.Size(29, 21)
        Me.BT_TE_VAC_QUERY.TabIndex = 43
        Me.BT_TE_VAC_QUERY.Text = "Q"
        Me.BT_TE_VAC_QUERY.UseVisualStyleBackColor = True
        '
        'TB_TEB_AreaDate
        '
        Me.TB_TEB_AreaDate.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEB_AreaDate.Location = New System.Drawing.Point(645, 131)
        Me.TB_TEB_AreaDate.Name = "TB_TEB_AreaDate"
        Me.TB_TEB_AreaDate.Size = New System.Drawing.Size(171, 29)
        Me.TB_TEB_AreaDate.TabIndex = 45
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(566, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 20)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "區域日期"
        '
        'TE_BASIC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 550)
        Me.Controls.Add(Me.TB_TEB_AreaDate)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.BT_TE_VAC_QUERY)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TB_TEB_END_DATE)
        Me.Controls.Add(Me.TB_TEB_Start_date)
        Me.Controls.Add(Me.LB_TEB_VAC_DESC)
        Me.Controls.Add(Me.LB_VAC_TITLE)
        Me.Controls.Add(Me.CB_TEB_VACID)
        Me.Controls.Add(Me.BT_TEB_FunctionQ)
        Me.Controls.Add(Me.BT_TEB_AREAQ)
        Me.Controls.Add(Me.BT_TEB_TITLEQ)
        Me.Controls.Add(Me.BT_TEB_DEPQ)
        Me.Controls.Add(Me.BT_TEB_IDQ)
        Me.Controls.Add(Me.BT_TEB_QUIT)
        Me.Controls.Add(Me.CB_TEB_Active)
        Me.Controls.Add(Me.LB_TEB_SHIFT)
        Me.Controls.Add(Me.TB_TEB_ID)
        Me.Controls.Add(Me.TB_TEB_MENO)
        Me.Controls.Add(Me.CB_TEB_FUNCTION)
        Me.Controls.Add(Me.CB_TEB_AREA)
        Me.Controls.Add(Me.CB_TEB_DeptCode)
        Me.Controls.Add(Me.TB_TEB_OnBoardDate)
        Me.Controls.Add(Me.TB_TEB_Title)
        Me.Controls.Add(Me.TB_TEB_NAME)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV_TEB)
        Me.Controls.Add(Me.BT_TEB_Close)
        Me.Controls.Add(Me.BT_TEB_Del)
        Me.Controls.Add(Me.BT_TEB_Modify)
        Me.Controls.Add(Me.BT_TEB_Create)
        Me.Controls.Add(Me.BT_TEB_GetData)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TE_BASIC"
        Me.Text = "TE_BASIC"
        CType(Me.DGV_TEB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_TEB_GetData As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_Create As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_Del As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_Close As System.Windows.Forms.Button
    Friend WithEvents DGV_TEB As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_TEB_NAME As System.Windows.Forms.TextBox
    Friend WithEvents TB_TEB_Title As System.Windows.Forms.TextBox
    Friend WithEvents TB_TEB_OnBoardDate As System.Windows.Forms.TextBox
    Friend WithEvents CB_TEB_DeptCode As System.Windows.Forms.ComboBox
    Friend WithEvents CB_TEB_AREA As System.Windows.Forms.ComboBox
    Friend WithEvents CB_TEB_FUNCTION As System.Windows.Forms.ComboBox
    Friend WithEvents TB_TEB_MENO As System.Windows.Forms.TextBox
    Friend WithEvents TB_TEB_ID As System.Windows.Forms.TextBox
    Friend WithEvents LB_TEB_SHIFT As System.Windows.Forms.Label
    Friend WithEvents CB_TEB_Active As System.Windows.Forms.CheckBox
    Friend WithEvents BT_TEB_QUIT As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_IDQ As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_DEPQ As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_TITLEQ As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_AREAQ As System.Windows.Forms.Button
    Friend WithEvents BT_TEB_FunctionQ As System.Windows.Forms.Button
    Friend WithEvents CB_TEB_VACID As System.Windows.Forms.ComboBox
    Friend WithEvents LB_VAC_TITLE As System.Windows.Forms.Label
    Friend WithEvents LB_TEB_VAC_DESC As System.Windows.Forms.Label
    Friend WithEvents TB_TEB_Start_date As System.Windows.Forms.TextBox
    Friend WithEvents TB_TEB_END_DATE As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BT_TE_VAC_QUERY As System.Windows.Forms.Button
    Friend WithEvents TB_TEB_AreaDate As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
