<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CF_Certify_Tool_Map
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
        Me.DGV_Certify_CFTM = New System.Windows.Forms.DataGridView
        Me.BT_Certify_CTM_GetData = New System.Windows.Forms.Button
        Me.BT_Certify_CTM_Create = New System.Windows.Forms.Button
        Me.BT_Certify_CTM_Modify = New System.Windows.Forms.Button
        Me.BT_Certify_CTM_Close = New System.Windows.Forms.Button
        Me.BT_Certify_CTM_Fail = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CB_Certify_CTM_Active = New System.Windows.Forms.CheckBox
        Me.CB_Certify_CTM_CertifyID = New System.Windows.Forms.ComboBox
        Me.TB_Certify_CTM_TOOLID = New System.Windows.Forms.TextBox
        Me.TB_Certify_CTM_Remark = New System.Windows.Forms.TextBox
        Me.BT_Certify_CTM_TOOLIDQ = New System.Windows.Forms.Button
        Me.BT_Certify_CTM_CertifyidQ = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.LB_Certify_CTM_Name = New System.Windows.Forms.Label
        CType(Me.DGV_Certify_CFTM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(363, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Certify Tool Mapping 作業維護"
        '
        'DGV_Certify_CFTM
        '
        Me.DGV_Certify_CFTM.AllowUserToAddRows = False
        Me.DGV_Certify_CFTM.AllowUserToDeleteRows = False
        Me.DGV_Certify_CFTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Certify_CFTM.Location = New System.Drawing.Point(10, 233)
        Me.DGV_Certify_CFTM.Name = "DGV_Certify_CFTM"
        Me.DGV_Certify_CFTM.ReadOnly = True
        Me.DGV_Certify_CFTM.RowTemplate.Height = 24
        Me.DGV_Certify_CFTM.Size = New System.Drawing.Size(692, 239)
        Me.DGV_Certify_CFTM.TabIndex = 1
        '
        'BT_Certify_CTM_GetData
        '
        Me.BT_Certify_CTM_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_CTM_GetData.Location = New System.Drawing.Point(21, 47)
        Me.BT_Certify_CTM_GetData.Name = "BT_Certify_CTM_GetData"
        Me.BT_Certify_CTM_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_CTM_GetData.TabIndex = 2
        Me.BT_Certify_CTM_GetData.Text = "撈資料"
        Me.BT_Certify_CTM_GetData.UseVisualStyleBackColor = True
        '
        'BT_Certify_CTM_Create
        '
        Me.BT_Certify_CTM_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_CTM_Create.Location = New System.Drawing.Point(21, 84)
        Me.BT_Certify_CTM_Create.Name = "BT_Certify_CTM_Create"
        Me.BT_Certify_CTM_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_CTM_Create.TabIndex = 3
        Me.BT_Certify_CTM_Create.Text = "新增資料"
        Me.BT_Certify_CTM_Create.UseVisualStyleBackColor = True
        '
        'BT_Certify_CTM_Modify
        '
        Me.BT_Certify_CTM_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_CTM_Modify.Location = New System.Drawing.Point(21, 121)
        Me.BT_Certify_CTM_Modify.Name = "BT_Certify_CTM_Modify"
        Me.BT_Certify_CTM_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_CTM_Modify.TabIndex = 4
        Me.BT_Certify_CTM_Modify.Text = "修改資料"
        Me.BT_Certify_CTM_Modify.UseVisualStyleBackColor = True
        '
        'BT_Certify_CTM_Close
        '
        Me.BT_Certify_CTM_Close.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_CTM_Close.Location = New System.Drawing.Point(21, 197)
        Me.BT_Certify_CTM_Close.Name = "BT_Certify_CTM_Close"
        Me.BT_Certify_CTM_Close.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_CTM_Close.TabIndex = 5
        Me.BT_Certify_CTM_Close.Text = "Main Page"
        Me.BT_Certify_CTM_Close.UseVisualStyleBackColor = True
        '
        'BT_Certify_CTM_Fail
        '
        Me.BT_Certify_CTM_Fail.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_CTM_Fail.Location = New System.Drawing.Point(21, 158)
        Me.BT_Certify_CTM_Fail.Name = "BT_Certify_CTM_Fail"
        Me.BT_Certify_CTM_Fail.Size = New System.Drawing.Size(146, 31)
        Me.BT_Certify_CTM_Fail.TabIndex = 6
        Me.BT_Certify_CTM_Fail.Text = "失效資料"
        Me.BT_Certify_CTM_Fail.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(202, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Certify ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(216, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 21)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tool ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(211, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 21)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Remark"
        '
        'CB_Certify_CTM_Active
        '
        Me.CB_Certify_CTM_Active.AutoSize = True
        Me.CB_Certify_CTM_Active.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Certify_CTM_Active.Location = New System.Drawing.Point(286, 196)
        Me.CB_Certify_CTM_Active.Name = "CB_Certify_CTM_Active"
        Me.CB_Certify_CTM_Active.Size = New System.Drawing.Size(93, 25)
        Me.CB_Certify_CTM_Active.TabIndex = 10
        Me.CB_Certify_CTM_Active.Text = "是否有效"
        Me.CB_Certify_CTM_Active.UseVisualStyleBackColor = True
        '
        'CB_Certify_CTM_CertifyID
        '
        Me.CB_Certify_CTM_CertifyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Certify_CTM_CertifyID.FormattingEnabled = True
        Me.CB_Certify_CTM_CertifyID.Location = New System.Drawing.Point(286, 44)
        Me.CB_Certify_CTM_CertifyID.Name = "CB_Certify_CTM_CertifyID"
        Me.CB_Certify_CTM_CertifyID.Size = New System.Drawing.Size(206, 20)
        Me.CB_Certify_CTM_CertifyID.TabIndex = 11
        '
        'TB_Certify_CTM_TOOLID
        '
        Me.TB_Certify_CTM_TOOLID.Location = New System.Drawing.Point(286, 121)
        Me.TB_Certify_CTM_TOOLID.Name = "TB_Certify_CTM_TOOLID"
        Me.TB_Certify_CTM_TOOLID.Size = New System.Drawing.Size(205, 22)
        Me.TB_Certify_CTM_TOOLID.TabIndex = 12
        '
        'TB_Certify_CTM_Remark
        '
        Me.TB_Certify_CTM_Remark.Location = New System.Drawing.Point(286, 158)
        Me.TB_Certify_CTM_Remark.Name = "TB_Certify_CTM_Remark"
        Me.TB_Certify_CTM_Remark.Size = New System.Drawing.Size(408, 22)
        Me.TB_Certify_CTM_Remark.TabIndex = 13
        '
        'BT_Certify_CTM_TOOLIDQ
        '
        Me.BT_Certify_CTM_TOOLIDQ.Location = New System.Drawing.Point(510, 122)
        Me.BT_Certify_CTM_TOOLIDQ.Name = "BT_Certify_CTM_TOOLIDQ"
        Me.BT_Certify_CTM_TOOLIDQ.Size = New System.Drawing.Size(26, 20)
        Me.BT_Certify_CTM_TOOLIDQ.TabIndex = 14
        Me.BT_Certify_CTM_TOOLIDQ.Text = "Q"
        Me.BT_Certify_CTM_TOOLIDQ.UseVisualStyleBackColor = True
        '
        'BT_Certify_CTM_CertifyidQ
        '
        Me.BT_Certify_CTM_CertifyidQ.Location = New System.Drawing.Point(510, 44)
        Me.BT_Certify_CTM_CertifyidQ.Name = "BT_Certify_CTM_CertifyidQ"
        Me.BT_Certify_CTM_CertifyidQ.Size = New System.Drawing.Size(26, 20)
        Me.BT_Certify_CTM_CertifyidQ.TabIndex = 15
        Me.BT_Certify_CTM_CertifyidQ.Text = "Q"
        Me.BT_Certify_CTM_CertifyidQ.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(173, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 21)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Certify Name"
        '
        'LB_Certify_CTM_Name
        '
        Me.LB_Certify_CTM_Name.AutoSize = True
        Me.LB_Certify_CTM_Name.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_Certify_CTM_Name.Location = New System.Drawing.Point(294, 86)
        Me.LB_Certify_CTM_Name.Name = "LB_Certify_CTM_Name"
        Me.LB_Certify_CTM_Name.Size = New System.Drawing.Size(0, 21)
        Me.LB_Certify_CTM_Name.TabIndex = 17
        '
        'CF_Certify_Tool_Map
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 477)
        Me.Controls.Add(Me.LB_Certify_CTM_Name)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BT_Certify_CTM_CertifyidQ)
        Me.Controls.Add(Me.BT_Certify_CTM_TOOLIDQ)
        Me.Controls.Add(Me.TB_Certify_CTM_Remark)
        Me.Controls.Add(Me.TB_Certify_CTM_TOOLID)
        Me.Controls.Add(Me.CB_Certify_CTM_CertifyID)
        Me.Controls.Add(Me.CB_Certify_CTM_Active)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BT_Certify_CTM_Fail)
        Me.Controls.Add(Me.BT_Certify_CTM_Close)
        Me.Controls.Add(Me.BT_Certify_CTM_Modify)
        Me.Controls.Add(Me.BT_Certify_CTM_Create)
        Me.Controls.Add(Me.BT_Certify_CTM_GetData)
        Me.Controls.Add(Me.DGV_Certify_CFTM)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CF_Certify_Tool_Map"
        Me.Text = "CF_Certify_Tool_Map"
        CType(Me.DGV_Certify_CFTM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Certify_CFTM As System.Windows.Forms.DataGridView
    Friend WithEvents BT_Certify_CTM_GetData As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_CTM_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_CTM_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_CTM_Close As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_CTM_Fail As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_Certify_CTM_Active As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Certify_CTM_CertifyID As System.Windows.Forms.ComboBox
    Friend WithEvents TB_Certify_CTM_TOOLID As System.Windows.Forms.TextBox
    Friend WithEvents TB_Certify_CTM_Remark As System.Windows.Forms.TextBox
    Friend WithEvents BT_Certify_CTM_TOOLIDQ As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_CTM_CertifyidQ As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LB_Certify_CTM_Name As System.Windows.Forms.Label
End Class
