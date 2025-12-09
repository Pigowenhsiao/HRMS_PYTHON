<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Loc_Desc
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
        Me.BT_GetData = New System.Windows.Forms.Button
        Me.BT_Create = New System.Windows.Forms.Button
        Me.BT_Modify = New System.Windows.Forms.Button
        Me.BT_Close = New System.Windows.Forms.Button
        Me.DGV_Location = New System.Windows.Forms.DataGridView
        Me.LB_1 = New System.Windows.Forms.Label
        Me.LB_2 = New System.Windows.Forms.Label
        Me.TB_LOEMP_ID = New System.Windows.Forms.TextBox
        Me.TB_Location = New System.Windows.Forms.TextBox
        Me.LB_3 = New System.Windows.Forms.Label
        Me.LB_5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DGV_Location, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工作區域定義作業"
        '
        'BT_GetData
        '
        Me.BT_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_GetData.Location = New System.Drawing.Point(17, 54)
        Me.BT_GetData.Name = "BT_GetData"
        Me.BT_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_GetData.TabIndex = 1
        Me.BT_GetData.Text = "撈資料"
        Me.BT_GetData.UseVisualStyleBackColor = True
        '
        'BT_Create
        '
        Me.BT_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Create.Location = New System.Drawing.Point(17, 91)
        Me.BT_Create.Name = "BT_Create"
        Me.BT_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Create.TabIndex = 2
        Me.BT_Create.Text = "新增資料"
        Me.BT_Create.UseVisualStyleBackColor = True
        '
        'BT_Modify
        '
        Me.BT_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Modify.Location = New System.Drawing.Point(17, 128)
        Me.BT_Modify.Name = "BT_Modify"
        Me.BT_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Modify.TabIndex = 3
        Me.BT_Modify.Text = "修改資料"
        Me.BT_Modify.UseVisualStyleBackColor = True
        '
        'BT_Close
        '
        Me.BT_Close.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Close.Location = New System.Drawing.Point(17, 165)
        Me.BT_Close.Name = "BT_Close"
        Me.BT_Close.Size = New System.Drawing.Size(146, 31)
        Me.BT_Close.TabIndex = 5
        Me.BT_Close.Text = "Main Page"
        Me.BT_Close.UseVisualStyleBackColor = True
        '
        'DGV_Location
        '
        Me.DGV_Location.AllowUserToAddRows = False
        Me.DGV_Location.AllowUserToDeleteRows = False
        Me.DGV_Location.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Location.Location = New System.Drawing.Point(6, 202)
        Me.DGV_Location.Name = "DGV_Location"
        Me.DGV_Location.ReadOnly = True
        Me.DGV_Location.RowTemplate.Height = 24
        Me.DGV_Location.Size = New System.Drawing.Size(542, 281)
        Me.DGV_Location.TabIndex = 6
        '
        'LB_1
        '
        Me.LB_1.AutoSize = True
        Me.LB_1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_1.Location = New System.Drawing.Point(240, 59)
        Me.LB_1.Name = "LB_1"
        Me.LB_1.Size = New System.Drawing.Size(41, 20)
        Me.LB_1.TabIndex = 7
        Me.LB_1.Text = "工號"
        '
        'LB_2
        '
        Me.LB_2.AutoSize = True
        Me.LB_2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_2.Location = New System.Drawing.Point(240, 96)
        Me.LB_2.Name = "LB_2"
        Me.LB_2.Size = New System.Drawing.Size(41, 20)
        Me.LB_2.TabIndex = 8
        Me.LB_2.Text = "姓名"
        '
        'TB_LOEMP_ID
        '
        Me.TB_LOEMP_ID.Location = New System.Drawing.Point(287, 57)
        Me.TB_LOEMP_ID.Name = "TB_LOEMP_ID"
        Me.TB_LOEMP_ID.Size = New System.Drawing.Size(197, 22)
        Me.TB_LOEMP_ID.TabIndex = 10
        '
        'TB_Location
        '
        Me.TB_Location.Location = New System.Drawing.Point(287, 128)
        Me.TB_Location.Name = "TB_Location"
        Me.TB_Location.Size = New System.Drawing.Size(197, 22)
        Me.TB_Location.TabIndex = 12
        '
        'LB_3
        '
        Me.LB_3.AutoSize = True
        Me.LB_3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_3.Location = New System.Drawing.Point(240, 130)
        Me.LB_3.Name = "LB_3"
        Me.LB_3.Size = New System.Drawing.Size(41, 20)
        Me.LB_3.TabIndex = 13
        Me.LB_3.Text = "區域"
        '
        'LB_5
        '
        Me.LB_5.AutoSize = True
        Me.LB_5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_5.Location = New System.Drawing.Point(291, 96)
        Me.LB_5.Name = "LB_5"
        Me.LB_5.Size = New System.Drawing.Size(0, 20)
        Me.LB_5.TabIndex = 14
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(490, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 24)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Q"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TE_Loc_Desc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 489)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LB_5)
        Me.Controls.Add(Me.LB_3)
        Me.Controls.Add(Me.TB_Location)
        Me.Controls.Add(Me.TB_LOEMP_ID)
        Me.Controls.Add(Me.LB_2)
        Me.Controls.Add(Me.LB_1)
        Me.Controls.Add(Me.DGV_Location)
        Me.Controls.Add(Me.BT_Close)
        Me.Controls.Add(Me.BT_Modify)
        Me.Controls.Add(Me.BT_Create)
        Me.Controls.Add(Me.BT_GetData)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TE_Loc_Desc"
        Me.Text = "Shop Define"
        CType(Me.DGV_Location, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_GetData As System.Windows.Forms.Button
    Friend WithEvents BT_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_Close As System.Windows.Forms.Button
    Friend WithEvents DGV_Location As System.Windows.Forms.DataGridView
    Friend WithEvents LB_1 As System.Windows.Forms.Label
    Friend WithEvents LB_2 As System.Windows.Forms.Label
    Friend WithEvents TB_LOEMP_ID As System.Windows.Forms.TextBox
    Friend WithEvents TB_Location As System.Windows.Forms.TextBox
    Friend WithEvents LB_3 As System.Windows.Forms.Label
    Friend WithEvents LB_5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
