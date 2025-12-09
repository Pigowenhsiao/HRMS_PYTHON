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
        Me.BT_TEB_Del.Text = "刪除資料"
        Me.BT_TEB_Del.UseVisualStyleBackColor = True
        Me.BT_TEB_Del.Visible = False
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
        Me.DGV_TEB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_TEB.Location = New System.Drawing.Point(5, 271)
        Me.DGV_TEB.Name = "DGV_TEB"
        Me.DGV_TEB.ReadOnly = True
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
        Me.Label5.Location = New System.Drawing.Point(209, 160)
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
        Me.Label7.Location = New System.Drawing.Point(566, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "班        別"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(566, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "工作區域"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(566, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "備        註"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(566, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 20)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "工作內容"
        '
        'TB_TEB_NAME
        '
        Me.TB_TEB_NAME.Location = New System.Drawing.Point(288, 89)
        Me.TB_TEB_NAME.Name = "TB_TEB_NAME"
        Me.TB_TEB_NAME.Size = New System.Drawing.Size(171, 22)
        Me.TB_TEB_NAME.TabIndex = 17
        '
        'TB_TEB_Title
        '
        Me.TB_TEB_Title.Location = New System.Drawing.Point(288, 158)
        Me.TB_TEB_Title.Name = "TB_TEB_Title"
        Me.TB_TEB_Title.Size = New System.Drawing.Size(171, 22)
        Me.TB_TEB_Title.TabIndex = 19
        '
        'TB_TEB_OnBoardDate
        '
        Me.TB_TEB_OnBoardDate.Location = New System.Drawing.Point(288, 195)
        Me.TB_TEB_OnBoardDate.Name = "TB_TEB_OnBoardDate"
        Me.TB_TEB_OnBoardDate.Size = New System.Drawing.Size(171, 22)
        Me.TB_TEB_OnBoardDate.TabIndex = 20
        '
        'CB_TEB_DeptCode
        '
        Me.CB_TEB_DeptCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TEB_DeptCode.FormattingEnabled = True
        Me.CB_TEB_DeptCode.Location = New System.Drawing.Point(288, 122)
        Me.CB_TEB_DeptCode.Name = "CB_TEB_DeptCode"
        Me.CB_TEB_DeptCode.Size = New System.Drawing.Size(171, 20)
        Me.CB_TEB_DeptCode.TabIndex = 21
        '
        'CB_TEB_AREA
        '
        Me.CB_TEB_AREA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TEB_AREA.FormattingEnabled = True
        Me.CB_TEB_AREA.Location = New System.Drawing.Point(645, 86)
        Me.CB_TEB_AREA.Name = "CB_TEB_AREA"
        Me.CB_TEB_AREA.Size = New System.Drawing.Size(171, 20)
        Me.CB_TEB_AREA.TabIndex = 23
        '
        'CB_TEB_FUNCTION
        '
        Me.CB_TEB_FUNCTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TEB_FUNCTION.FormattingEnabled = True
        Me.CB_TEB_FUNCTION.Location = New System.Drawing.Point(645, 123)
        Me.CB_TEB_FUNCTION.Name = "CB_TEB_FUNCTION"
        Me.CB_TEB_FUNCTION.Size = New System.Drawing.Size(171, 20)
        Me.CB_TEB_FUNCTION.TabIndex = 24
        '
        'TB_TEB_MENO
        '
        Me.TB_TEB_MENO.Location = New System.Drawing.Point(645, 163)
        Me.TB_TEB_MENO.Name = "TB_TEB_MENO"
        Me.TB_TEB_MENO.Size = New System.Drawing.Size(171, 22)
        Me.TB_TEB_MENO.TabIndex = 25
        '
        'TB_TEB_ID
        '
        Me.TB_TEB_ID.Location = New System.Drawing.Point(288, 54)
        Me.TB_TEB_ID.Name = "TB_TEB_ID"
        Me.TB_TEB_ID.Size = New System.Drawing.Size(171, 22)
        Me.TB_TEB_ID.TabIndex = 26
        '
        'LB_TEB_SHIFT
        '
        Me.LB_TEB_SHIFT.AutoSize = True
        Me.LB_TEB_SHIFT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_TEB_SHIFT.Location = New System.Drawing.Point(645, 54)
        Me.LB_TEB_SHIFT.Name = "LB_TEB_SHIFT"
        Me.LB_TEB_SHIFT.Size = New System.Drawing.Size(0, 20)
        Me.LB_TEB_SHIFT.TabIndex = 27
        '
        'CB_TEB_Active
        '
        Me.CB_TEB_Active.AutoSize = True
        Me.CB_TEB_Active.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_TEB_Active.Location = New System.Drawing.Point(647, 198)
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
        Me.BT_TEB_AREAQ.Location = New System.Drawing.Point(837, 88)
        Me.BT_TEB_AREAQ.Name = "BT_TEB_AREAQ"
        Me.BT_TEB_AREAQ.Size = New System.Drawing.Size(29, 21)
        Me.BT_TEB_AREAQ.TabIndex = 34
        Me.BT_TEB_AREAQ.Text = "Q"
        Me.BT_TEB_AREAQ.UseVisualStyleBackColor = True
        '
        'BT_TEB_FunctionQ
        '
        Me.BT_TEB_FunctionQ.Location = New System.Drawing.Point(837, 125)
        Me.BT_TEB_FunctionQ.Name = "BT_TEB_FunctionQ"
        Me.BT_TEB_FunctionQ.Size = New System.Drawing.Size(29, 21)
        Me.BT_TEB_FunctionQ.TabIndex = 35
        Me.BT_TEB_FunctionQ.Text = "Q"
        Me.BT_TEB_FunctionQ.UseVisualStyleBackColor = True
        '
        'TE_BASIC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 550)
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
End Class
