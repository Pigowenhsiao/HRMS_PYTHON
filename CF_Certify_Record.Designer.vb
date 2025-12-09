<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CF_Certify_Record
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
        Me.BT_Certify_Record_GetData = New System.Windows.Forms.Button
        Me.DGV_Certify_Record = New System.Windows.Forms.DataGridView
        Me.BT_Certify_Record_Create = New System.Windows.Forms.Button
        Me.BT_Certify_Record_Modify = New System.Windows.Forms.Button
        Me.BT_Certify_Record_close = New System.Windows.Forms.Button
        Me.BT_Certify_Record_Fail = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.CB_Certify_Record_ID = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.LB_Certify_Record_Name = New System.Windows.Forms.Label
        Me.LB_Certify_Record_CName = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CB_Certify_Record_Active = New System.Windows.Forms.CheckBox
        Me.BT_Certify_record_IDQ = New System.Windows.Forms.Button
        Me.BT_Certify_record_CIDQ = New System.Windows.Forms.Button
        Me.CB_Certify_Record_CID = New System.Windows.Forms.ComboBox
        Me.TB_Certify_Record_Remark = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_Certify_Record_Date = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LB_Certify_No = New System.Windows.Forms.Label
        CType(Me.DGV_Certify_Record, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Certify 考卷登錄作業"
        '
        'BT_Certify_Record_GetData
        '
        Me.BT_Certify_Record_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_Record_GetData.Location = New System.Drawing.Point(22, 55)
        Me.BT_Certify_Record_GetData.Name = "BT_Certify_Record_GetData"
        Me.BT_Certify_Record_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_Record_GetData.TabIndex = 1
        Me.BT_Certify_Record_GetData.Text = "撈資料"
        Me.BT_Certify_Record_GetData.UseVisualStyleBackColor = True
        '
        'DGV_Certify_Record
        '
        Me.DGV_Certify_Record.AllowUserToAddRows = False
        Me.DGV_Certify_Record.AllowUserToDeleteRows = False
        Me.DGV_Certify_Record.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Certify_Record.Location = New System.Drawing.Point(9, 240)
        Me.DGV_Certify_Record.Name = "DGV_Certify_Record"
        Me.DGV_Certify_Record.ReadOnly = True
        Me.DGV_Certify_Record.RowTemplate.Height = 24
        Me.DGV_Certify_Record.Size = New System.Drawing.Size(942, 348)
        Me.DGV_Certify_Record.TabIndex = 2
        '
        'BT_Certify_Record_Create
        '
        Me.BT_Certify_Record_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_Record_Create.Location = New System.Drawing.Point(22, 92)
        Me.BT_Certify_Record_Create.Name = "BT_Certify_Record_Create"
        Me.BT_Certify_Record_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_Record_Create.TabIndex = 3
        Me.BT_Certify_Record_Create.Text = "新增資料"
        Me.BT_Certify_Record_Create.UseVisualStyleBackColor = True
        '
        'BT_Certify_Record_Modify
        '
        Me.BT_Certify_Record_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_Record_Modify.Location = New System.Drawing.Point(22, 129)
        Me.BT_Certify_Record_Modify.Name = "BT_Certify_Record_Modify"
        Me.BT_Certify_Record_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_Record_Modify.TabIndex = 4
        Me.BT_Certify_Record_Modify.Text = "修改資料"
        Me.BT_Certify_Record_Modify.UseVisualStyleBackColor = True
        '
        'BT_Certify_Record_close
        '
        Me.BT_Certify_Record_close.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_Record_close.Location = New System.Drawing.Point(22, 203)
        Me.BT_Certify_Record_close.Name = "BT_Certify_Record_close"
        Me.BT_Certify_Record_close.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_Record_close.TabIndex = 5
        Me.BT_Certify_Record_close.Text = "Main Page"
        Me.BT_Certify_Record_close.UseVisualStyleBackColor = True
        '
        'BT_Certify_Record_Fail
        '
        Me.BT_Certify_Record_Fail.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_Record_Fail.Location = New System.Drawing.Point(22, 166)
        Me.BT_Certify_Record_Fail.Name = "BT_Certify_Record_Fail"
        Me.BT_Certify_Record_Fail.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_Record_Fail.TabIndex = 6
        Me.BT_Certify_Record_Fail.Text = "失效資料資料"
        Me.BT_Certify_Record_Fail.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(192, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "工         號"
        '
        'CB_Certify_Record_ID
        '
        Me.CB_Certify_Record_ID.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Certify_Record_ID.FormattingEnabled = True
        Me.CB_Certify_Record_ID.Location = New System.Drawing.Point(275, 53)
        Me.CB_Certify_Record_ID.Name = "CB_Certify_Record_ID"
        Me.CB_Certify_Record_ID.Size = New System.Drawing.Size(218, 28)
        Me.CB_Certify_Record_ID.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(559, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "姓         名"
        '
        'LB_Certify_Record_Name
        '
        Me.LB_Certify_Record_Name.AutoSize = True
        Me.LB_Certify_Record_Name.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_Certify_Record_Name.Location = New System.Drawing.Point(653, 60)
        Me.LB_Certify_Record_Name.Name = "LB_Certify_Record_Name"
        Me.LB_Certify_Record_Name.Size = New System.Drawing.Size(0, 20)
        Me.LB_Certify_Record_Name.TabIndex = 10
        '
        'LB_Certify_Record_CName
        '
        Me.LB_Certify_Record_CName.AutoSize = True
        Me.LB_Certify_Record_CName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_Certify_Record_CName.Location = New System.Drawing.Point(310, 134)
        Me.LB_Certify_Record_CName.Name = "LB_Certify_Record_CName"
        Me.LB_Certify_Record_CName.Size = New System.Drawing.Size(0, 20)
        Me.LB_Certify_Record_CName.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(192, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Certify Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(192, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Certify ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(192, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Certify Date:"
        '
        'CB_Certify_Record_Active
        '
        Me.CB_Certify_Record_Active.AutoSize = True
        Me.CB_Certify_Record_Active.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Certify_Record_Active.Location = New System.Drawing.Point(297, 208)
        Me.CB_Certify_Record_Active.Name = "CB_Certify_Record_Active"
        Me.CB_Certify_Record_Active.Size = New System.Drawing.Size(92, 24)
        Me.CB_Certify_Record_Active.TabIndex = 17
        Me.CB_Certify_Record_Active.Text = "是否生效"
        Me.CB_Certify_Record_Active.UseVisualStyleBackColor = True
        '
        'BT_Certify_record_IDQ
        '
        Me.BT_Certify_record_IDQ.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_record_IDQ.Location = New System.Drawing.Point(500, 54)
        Me.BT_Certify_record_IDQ.Name = "BT_Certify_record_IDQ"
        Me.BT_Certify_record_IDQ.Size = New System.Drawing.Size(31, 25)
        Me.BT_Certify_record_IDQ.TabIndex = 18
        Me.BT_Certify_record_IDQ.Text = "Q"
        Me.BT_Certify_record_IDQ.UseVisualStyleBackColor = True
        '
        'BT_Certify_record_CIDQ
        '
        Me.BT_Certify_record_CIDQ.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_record_CIDQ.Location = New System.Drawing.Point(499, 94)
        Me.BT_Certify_record_CIDQ.Name = "BT_Certify_record_CIDQ"
        Me.BT_Certify_record_CIDQ.Size = New System.Drawing.Size(31, 28)
        Me.BT_Certify_record_CIDQ.TabIndex = 19
        Me.BT_Certify_record_CIDQ.Text = "Q"
        Me.BT_Certify_record_CIDQ.UseVisualStyleBackColor = True
        '
        'CB_Certify_Record_CID
        '
        Me.CB_Certify_Record_CID.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Certify_Record_CID.FormattingEnabled = True
        Me.CB_Certify_Record_CID.Location = New System.Drawing.Point(275, 94)
        Me.CB_Certify_Record_CID.Name = "CB_Certify_Record_CID"
        Me.CB_Certify_Record_CID.Size = New System.Drawing.Size(218, 28)
        Me.CB_Certify_Record_CID.TabIndex = 20
        '
        'TB_Certify_Record_Remark
        '
        Me.TB_Certify_Record_Remark.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_Certify_Record_Remark.Location = New System.Drawing.Point(607, 162)
        Me.TB_Certify_Record_Remark.Name = "TB_Certify_Record_Remark"
        Me.TB_Certify_Record_Remark.Size = New System.Drawing.Size(276, 29)
        Me.TB_Certify_Record_Remark.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(530, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 20)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Remark:"
        '
        'TB_Certify_Record_Date
        '
        Me.TB_Certify_Record_Date.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_Certify_Record_Date.Location = New System.Drawing.Point(300, 162)
        Me.TB_Certify_Record_Date.Name = "TB_Certify_Record_Date"
        Me.TB_Certify_Record_Date.Size = New System.Drawing.Size(193, 29)
        Me.TB_Certify_Record_Date.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(559, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 20)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "編         號"
        '
        'LB_Certify_No
        '
        Me.LB_Certify_No.AutoSize = True
        Me.LB_Certify_No.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_Certify_No.Location = New System.Drawing.Point(653, 103)
        Me.LB_Certify_No.Name = "LB_Certify_No"
        Me.LB_Certify_No.Size = New System.Drawing.Size(0, 20)
        Me.LB_Certify_No.TabIndex = 25
        '
        'CF_Certify_Record
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 589)
        Me.Controls.Add(Me.LB_Certify_No)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TB_Certify_Record_Date)
        Me.Controls.Add(Me.TB_Certify_Record_Remark)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CB_Certify_Record_CID)
        Me.Controls.Add(Me.BT_Certify_record_CIDQ)
        Me.Controls.Add(Me.BT_Certify_record_IDQ)
        Me.Controls.Add(Me.CB_Certify_Record_Active)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LB_Certify_Record_CName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LB_Certify_Record_Name)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CB_Certify_Record_ID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BT_Certify_Record_Fail)
        Me.Controls.Add(Me.BT_Certify_Record_close)
        Me.Controls.Add(Me.BT_Certify_Record_Modify)
        Me.Controls.Add(Me.BT_Certify_Record_Create)
        Me.Controls.Add(Me.DGV_Certify_Record)
        Me.Controls.Add(Me.BT_Certify_Record_GetData)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CF_Certify_Record"
        Me.Text = "CF_Certify_Record"
        CType(Me.DGV_Certify_Record, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_Certify_Record_GetData As System.Windows.Forms.Button
    Friend WithEvents DGV_Certify_Record As System.Windows.Forms.DataGridView
    Friend WithEvents BT_Certify_Record_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_Record_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_Record_close As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_Record_Fail As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_Certify_Record_ID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LB_Certify_Record_Name As System.Windows.Forms.Label
    Friend WithEvents LB_Certify_Record_CName As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_Certify_Record_Active As System.Windows.Forms.CheckBox
    Friend WithEvents BT_Certify_record_IDQ As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_record_CIDQ As System.Windows.Forms.Button
    Friend WithEvents CB_Certify_Record_CID As System.Windows.Forms.ComboBox
    Friend WithEvents TB_Certify_Record_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_Certify_Record_Date As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LB_Certify_No As System.Windows.Forms.Label
End Class
