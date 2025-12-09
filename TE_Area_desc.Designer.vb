<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Area_desc
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.BT_Area_GetData = New System.Windows.Forms.Button
        Me.DGV_Area = New System.Windows.Forms.DataGridView
        Me.BT_AREA_CLOSE = New System.Windows.Forms.Button
        Me.CB_Area_ACT = New System.Windows.Forms.CheckBox
        Me.TB_Area_Name = New System.Windows.Forms.TextBox
        Me.TB_Area_DESC = New System.Windows.Forms.TextBox
        Me.BT_Area_Create = New System.Windows.Forms.Button
        Me.BT_Area_Modify = New System.Windows.Forms.Button
        Me.BT_Area_Del = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.DGV_Area, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 35)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "工作區域定義作業"
        '
        'BT_Area_GetData
        '
        Me.BT_Area_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Area_GetData.Location = New System.Drawing.Point(18, 47)
        Me.BT_Area_GetData.Name = "BT_Area_GetData"
        Me.BT_Area_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_Area_GetData.TabIndex = 1
        Me.BT_Area_GetData.Text = "撈資料"
        Me.BT_Area_GetData.UseVisualStyleBackColor = True
        '
        'DGV_Area
        '
        Me.DGV_Area.AllowUserToAddRows = False
        Me.DGV_Area.AllowUserToDeleteRows = False
        Me.DGV_Area.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Area.Location = New System.Drawing.Point(6, 238)
        Me.DGV_Area.Name = "DGV_Area"
        Me.DGV_Area.RowTemplate.Height = 24
        Me.DGV_Area.Size = New System.Drawing.Size(541, 248)
        Me.DGV_Area.TabIndex = 2
        '
        'BT_AREA_CLOSE
        '
        Me.BT_AREA_CLOSE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_AREA_CLOSE.Location = New System.Drawing.Point(18, 201)
        Me.BT_AREA_CLOSE.Name = "BT_AREA_CLOSE"
        Me.BT_AREA_CLOSE.Size = New System.Drawing.Size(146, 31)
        Me.BT_AREA_CLOSE.TabIndex = 3
        Me.BT_AREA_CLOSE.Text = "Main Page"
        Me.BT_AREA_CLOSE.UseVisualStyleBackColor = True
        '
        'CB_Area_ACT
        '
        Me.CB_Area_ACT.AutoSize = True
        Me.CB_Area_ACT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Area_ACT.Location = New System.Drawing.Point(292, 129)
        Me.CB_Area_ACT.Name = "CB_Area_ACT"
        Me.CB_Area_ACT.Size = New System.Drawing.Size(92, 24)
        Me.CB_Area_ACT.TabIndex = 4
        Me.CB_Area_ACT.Text = "是否生效"
        Me.CB_Area_ACT.UseVisualStyleBackColor = True
        '
        'TB_Area_Name
        '
        Me.TB_Area_Name.Location = New System.Drawing.Point(292, 55)
        Me.TB_Area_Name.Name = "TB_Area_Name"
        Me.TB_Area_Name.Size = New System.Drawing.Size(163, 22)
        Me.TB_Area_Name.TabIndex = 5
        '
        'TB_Area_DESC
        '
        Me.TB_Area_DESC.Location = New System.Drawing.Point(293, 92)
        Me.TB_Area_DESC.Name = "TB_Area_DESC"
        Me.TB_Area_DESC.Size = New System.Drawing.Size(163, 22)
        Me.TB_Area_DESC.TabIndex = 6
        '
        'BT_Area_Create
        '
        Me.BT_Area_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Area_Create.Location = New System.Drawing.Point(18, 84)
        Me.BT_Area_Create.Name = "BT_Area_Create"
        Me.BT_Area_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Area_Create.TabIndex = 7
        Me.BT_Area_Create.Text = "新增資料"
        Me.BT_Area_Create.UseVisualStyleBackColor = True
        '
        'BT_Area_Modify
        '
        Me.BT_Area_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Area_Modify.Location = New System.Drawing.Point(18, 125)
        Me.BT_Area_Modify.Name = "BT_Area_Modify"
        Me.BT_Area_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Area_Modify.TabIndex = 8
        Me.BT_Area_Modify.Text = "修改資料"
        Me.BT_Area_Modify.UseVisualStyleBackColor = True
        '
        'BT_Area_Del
        '
        Me.BT_Area_Del.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Area_Del.Location = New System.Drawing.Point(18, 164)
        Me.BT_Area_Del.Name = "BT_Area_Del"
        Me.BT_Area_Del.Size = New System.Drawing.Size(146, 31)
        Me.BT_Area_Del.TabIndex = 9
        Me.BT_Area_Del.Text = "刪除資料"
        Me.BT_Area_Del.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(188, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Area_Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(188, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Area_Desc"
        '
        'Area_desc
        '
        Me.ClientSize = New System.Drawing.Size(555, 489)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BT_Area_Del)
        Me.Controls.Add(Me.BT_Area_Modify)
        Me.Controls.Add(Me.BT_Area_Create)
        Me.Controls.Add(Me.TB_Area_DESC)
        Me.Controls.Add(Me.TB_Area_Name)
        Me.Controls.Add(Me.CB_Area_ACT)
        Me.Controls.Add(Me.BT_AREA_CLOSE)
        Me.Controls.Add(Me.DGV_Area)
        Me.Controls.Add(Me.BT_Area_GetData)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Area_desc"
        Me.Text = "Area Define"
        CType(Me.DGV_Area, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Job As System.Windows.Forms.DataGridView
    Friend WithEvents BT_JOB_Main As System.Windows.Forms.Button
    Friend WithEvents BT_JOB_GetData As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BT_Job_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Job_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_JOB_Del As System.Windows.Forms.Button
    Friend WithEvents TB_JOB_NAME As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_JOB_DESC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CB_JOB_ACT As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BT_Area_GetData As System.Windows.Forms.Button
    Friend WithEvents DGV_Area As System.Windows.Forms.DataGridView
    Friend WithEvents BT_AREA_CLOSE As System.Windows.Forms.Button
    Friend WithEvents CB_Area_ACT As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Area_Name As System.Windows.Forms.TextBox
    Friend WithEvents TB_Area_DESC As System.Windows.Forms.TextBox
    Friend WithEvents BT_Area_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Area_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_Area_Del As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
