<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CF_Certify__EXAM
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
        Me.BT_CFEXAM_GetData = New System.Windows.Forms.Button
        Me.DGV_CFEXAM = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CB_CF_EXAM_Active = New System.Windows.Forms.CheckBox
        Me.TB_Certify_EXAM_ID = New System.Windows.Forms.TextBox
        Me.CB_Certify_Exam_Group = New System.Windows.Forms.ComboBox
        Me.TB_Certify_EXAM_Time = New System.Windows.Forms.TextBox
        Me.TB_Certify_Exam_Name = New System.Windows.Forms.TextBox
        Me.TB_Certify_Exam_Dept = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CB_Certify_Exam_Type = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.BT_Certify_Exam_Create = New System.Windows.Forms.Button
        Me.BT_CFEXAM_Modify = New System.Windows.Forms.Button
        Me.BT_Certify_Exam_Close = New System.Windows.Forms.Button
        Me.BT_CFEXAM_FailData = New System.Windows.Forms.Button
        Me.TB_Certify_Exam_Remark = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.DGV_CFEXAM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(313, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Certify 考卷與區域維護作業"
        '
        'BT_CFEXAM_GetData
        '
        Me.BT_CFEXAM_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_CFEXAM_GetData.Location = New System.Drawing.Point(24, 45)
        Me.BT_CFEXAM_GetData.Name = "BT_CFEXAM_GetData"
        Me.BT_CFEXAM_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_CFEXAM_GetData.TabIndex = 1
        Me.BT_CFEXAM_GetData.Text = "撈資料"
        Me.BT_CFEXAM_GetData.UseVisualStyleBackColor = True
        '
        'DGV_CFEXAM
        '
        Me.DGV_CFEXAM.AllowUserToAddRows = False
        Me.DGV_CFEXAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_CFEXAM.Location = New System.Drawing.Point(10, 220)
        Me.DGV_CFEXAM.Name = "DGV_CFEXAM"
        Me.DGV_CFEXAM.ReadOnly = True
        Me.DGV_CFEXAM.RowTemplate.Height = 24
        Me.DGV_CFEXAM.Size = New System.Drawing.Size(905, 281)
        Me.DGV_CFEXAM.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(181, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Certify_ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(181, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Certify_Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(554, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Certify_Group"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(181, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Certify_Time"
        '
        'CB_CF_EXAM_Active
        '
        Me.CB_CF_EXAM_Active.AutoSize = True
        Me.CB_CF_EXAM_Active.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_CF_EXAM_Active.Location = New System.Drawing.Point(298, 177)
        Me.CB_CF_EXAM_Active.Name = "CB_CF_EXAM_Active"
        Me.CB_CF_EXAM_Active.Size = New System.Drawing.Size(92, 24)
        Me.CB_CF_EXAM_Active.TabIndex = 7
        Me.CB_CF_EXAM_Active.Text = "是否有效"
        Me.CB_CF_EXAM_Active.UseVisualStyleBackColor = True
        '
        'TB_Certify_EXAM_ID
        '
        Me.TB_Certify_EXAM_ID.Location = New System.Drawing.Point(298, 73)
        Me.TB_Certify_EXAM_ID.Name = "TB_Certify_EXAM_ID"
        Me.TB_Certify_EXAM_ID.Size = New System.Drawing.Size(245, 22)
        Me.TB_Certify_EXAM_ID.TabIndex = 8
        '
        'CB_Certify_Exam_Group
        '
        Me.CB_Certify_Exam_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Certify_Exam_Group.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Certify_Exam_Group.FormattingEnabled = True
        Me.CB_Certify_Exam_Group.Location = New System.Drawing.Point(673, 41)
        Me.CB_Certify_Exam_Group.Name = "CB_Certify_Exam_Group"
        Me.CB_Certify_Exam_Group.Size = New System.Drawing.Size(242, 25)
        Me.CB_Certify_Exam_Group.TabIndex = 9
        '
        'TB_Certify_EXAM_Time
        '
        Me.TB_Certify_EXAM_Time.Location = New System.Drawing.Point(298, 101)
        Me.TB_Certify_EXAM_Time.Name = "TB_Certify_EXAM_Time"
        Me.TB_Certify_EXAM_Time.Size = New System.Drawing.Size(245, 22)
        Me.TB_Certify_EXAM_Time.TabIndex = 10
        '
        'TB_Certify_Exam_Name
        '
        Me.TB_Certify_Exam_Name.Location = New System.Drawing.Point(298, 129)
        Me.TB_Certify_Exam_Name.Name = "TB_Certify_Exam_Name"
        Me.TB_Certify_Exam_Name.Size = New System.Drawing.Size(617, 22)
        Me.TB_Certify_Exam_Name.TabIndex = 11
        '
        'TB_Certify_Exam_Dept
        '
        Me.TB_Certify_Exam_Dept.Location = New System.Drawing.Point(298, 44)
        Me.TB_Certify_Exam_Dept.Name = "TB_Certify_Exam_Dept"
        Me.TB_Certify_Exam_Dept.Size = New System.Drawing.Size(245, 22)
        Me.TB_Certify_Exam_Dept.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(181, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Dept"
        '
        'CB_Certify_Exam_Type
        '
        Me.CB_Certify_Exam_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Certify_Exam_Type.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Certify_Exam_Type.FormattingEnabled = True
        Me.CB_Certify_Exam_Type.Location = New System.Drawing.Point(673, 75)
        Me.CB_Certify_Exam_Type.Name = "CB_Certify_Exam_Type"
        Me.CB_Certify_Exam_Type.Size = New System.Drawing.Size(242, 25)
        Me.CB_Certify_Exam_Type.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(554, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Certify_Type"
        '
        'BT_Certify_Exam_Create
        '
        Me.BT_Certify_Exam_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_Exam_Create.Location = New System.Drawing.Point(24, 80)
        Me.BT_Certify_Exam_Create.Name = "BT_Certify_Exam_Create"
        Me.BT_Certify_Exam_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_Exam_Create.TabIndex = 16
        Me.BT_Certify_Exam_Create.Text = "新增資料"
        Me.BT_Certify_Exam_Create.UseVisualStyleBackColor = True
        '
        'BT_CFEXAM_Modify
        '
        Me.BT_CFEXAM_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_CFEXAM_Modify.Location = New System.Drawing.Point(24, 116)
        Me.BT_CFEXAM_Modify.Name = "BT_CFEXAM_Modify"
        Me.BT_CFEXAM_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_CFEXAM_Modify.TabIndex = 17
        Me.BT_CFEXAM_Modify.Text = "修改資料"
        Me.BT_CFEXAM_Modify.UseVisualStyleBackColor = True
        '
        'BT_Certify_Exam_Close
        '
        Me.BT_Certify_Exam_Close.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_Exam_Close.Location = New System.Drawing.Point(24, 186)
        Me.BT_Certify_Exam_Close.Name = "BT_Certify_Exam_Close"
        Me.BT_Certify_Exam_Close.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_Exam_Close.TabIndex = 18
        Me.BT_Certify_Exam_Close.Text = "Main Page"
        Me.BT_Certify_Exam_Close.UseVisualStyleBackColor = True
        '
        'BT_CFEXAM_FailData
        '
        Me.BT_CFEXAM_FailData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_CFEXAM_FailData.Location = New System.Drawing.Point(24, 151)
        Me.BT_CFEXAM_FailData.Name = "BT_CFEXAM_FailData"
        Me.BT_CFEXAM_FailData.Size = New System.Drawing.Size(146, 31)
        Me.BT_CFEXAM_FailData.TabIndex = 19
        Me.BT_CFEXAM_FailData.Text = "失效資料"
        Me.BT_CFEXAM_FailData.UseVisualStyleBackColor = True
        '
        'TB_Certify_Exam_Remark
        '
        Me.TB_Certify_Exam_Remark.Location = New System.Drawing.Point(298, 157)
        Me.TB_Certify_Exam_Remark.Name = "TB_Certify_Exam_Remark"
        Me.TB_Certify_Exam_Remark.Size = New System.Drawing.Size(617, 22)
        Me.TB_Certify_Exam_Remark.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(181, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 20)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Remark"
        '
        'CF_Certify__EXAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 504)
        Me.Controls.Add(Me.TB_Certify_Exam_Remark)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BT_CFEXAM_FailData)
        Me.Controls.Add(Me.BT_Certify_Exam_Close)
        Me.Controls.Add(Me.BT_CFEXAM_Modify)
        Me.Controls.Add(Me.BT_Certify_Exam_Create)
        Me.Controls.Add(Me.CB_Certify_Exam_Type)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TB_Certify_Exam_Dept)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TB_Certify_Exam_Name)
        Me.Controls.Add(Me.TB_Certify_EXAM_Time)
        Me.Controls.Add(Me.CB_Certify_Exam_Group)
        Me.Controls.Add(Me.TB_Certify_EXAM_ID)
        Me.Controls.Add(Me.CB_CF_EXAM_Active)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV_CFEXAM)
        Me.Controls.Add(Me.BT_CFEXAM_GetData)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CF_Certify__EXAM"
        Me.Text = "CF_Certify__EXAM"
        CType(Me.DGV_CFEXAM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_CFEXAM_GetData As System.Windows.Forms.Button
    Friend WithEvents DGV_CFEXAM As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CB_CF_EXAM_Active As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Certify_EXAM_ID As System.Windows.Forms.TextBox
    Friend WithEvents CB_Certify_Exam_Group As System.Windows.Forms.ComboBox
    Friend WithEvents TB_Certify_EXAM_Time As System.Windows.Forms.TextBox
    Friend WithEvents TB_Certify_Exam_Name As System.Windows.Forms.TextBox
    Friend WithEvents TB_Certify_Exam_Dept As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CB_Certify_Exam_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BT_Certify_Exam_Create As System.Windows.Forms.Button
    Friend WithEvents BT_CFEXAM_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_Exam_Close As System.Windows.Forms.Button
    Friend WithEvents BT_CFEXAM_FailData As System.Windows.Forms.Button
    Friend WithEvents TB_Certify_Exam_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
