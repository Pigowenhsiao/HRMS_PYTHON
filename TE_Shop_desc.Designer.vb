<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Shop_desc
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
        Me.BT_Shop_GetData = New System.Windows.Forms.Button
        Me.BT_Shop_Create = New System.Windows.Forms.Button
        Me.BT_Shop_Modify = New System.Windows.Forms.Button
        Me.BT_Shop_Del = New System.Windows.Forms.Button
        Me.BT_Shop_Close = New System.Windows.Forms.Button
        Me.DGV_Shop = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CB_Shop_ACT = New System.Windows.Forms.CheckBox
        Me.TB_Shop_Name = New System.Windows.Forms.TextBox
        Me.TB_Shop_Desc = New System.Windows.Forms.TextBox
        CType(Me.DGV_Shop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Shop定義作業"
        '
        'BT_Shop_GetData
        '
        Me.BT_Shop_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Shop_GetData.Location = New System.Drawing.Point(17, 54)
        Me.BT_Shop_GetData.Name = "BT_Shop_GetData"
        Me.BT_Shop_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_Shop_GetData.TabIndex = 1
        Me.BT_Shop_GetData.Text = "撈資料"
        Me.BT_Shop_GetData.UseVisualStyleBackColor = True
        '
        'BT_Shop_Create
        '
        Me.BT_Shop_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Shop_Create.Location = New System.Drawing.Point(17, 91)
        Me.BT_Shop_Create.Name = "BT_Shop_Create"
        Me.BT_Shop_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Shop_Create.TabIndex = 2
        Me.BT_Shop_Create.Text = "新增資料"
        Me.BT_Shop_Create.UseVisualStyleBackColor = True
        '
        'BT_Shop_Modify
        '
        Me.BT_Shop_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Shop_Modify.Location = New System.Drawing.Point(17, 128)
        Me.BT_Shop_Modify.Name = "BT_Shop_Modify"
        Me.BT_Shop_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Shop_Modify.TabIndex = 3
        Me.BT_Shop_Modify.Text = "修改資料"
        Me.BT_Shop_Modify.UseVisualStyleBackColor = True
        '
        'BT_Shop_Del
        '
        Me.BT_Shop_Del.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Shop_Del.Location = New System.Drawing.Point(17, 165)
        Me.BT_Shop_Del.Name = "BT_Shop_Del"
        Me.BT_Shop_Del.Size = New System.Drawing.Size(146, 31)
        Me.BT_Shop_Del.TabIndex = 4
        Me.BT_Shop_Del.Text = "刪除資料"
        Me.BT_Shop_Del.UseVisualStyleBackColor = True
        '
        'BT_Shop_Close
        '
        Me.BT_Shop_Close.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Shop_Close.Location = New System.Drawing.Point(17, 202)
        Me.BT_Shop_Close.Name = "BT_Shop_Close"
        Me.BT_Shop_Close.Size = New System.Drawing.Size(146, 31)
        Me.BT_Shop_Close.TabIndex = 5
        Me.BT_Shop_Close.Text = "Main Page"
        Me.BT_Shop_Close.UseVisualStyleBackColor = True
        '
        'DGV_Shop
        '
        Me.DGV_Shop.AllowUserToAddRows = False
        Me.DGV_Shop.AllowUserToDeleteRows = False
        Me.DGV_Shop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Shop.Location = New System.Drawing.Point(6, 245)
        Me.DGV_Shop.Name = "DGV_Shop"
        Me.DGV_Shop.ReadOnly = True
        Me.DGV_Shop.RowTemplate.Height = 24
        Me.DGV_Shop.Size = New System.Drawing.Size(542, 238)
        Me.DGV_Shop.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(206, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Shop Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(206, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Shop Desc"
        '
        'CB_Shop_ACT
        '
        Me.CB_Shop_ACT.AutoSize = True
        Me.CB_Shop_ACT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Shop_ACT.Location = New System.Drawing.Point(306, 132)
        Me.CB_Shop_ACT.Name = "CB_Shop_ACT"
        Me.CB_Shop_ACT.Size = New System.Drawing.Size(92, 24)
        Me.CB_Shop_ACT.TabIndex = 9
        Me.CB_Shop_ACT.Text = "是否有效"
        Me.CB_Shop_ACT.UseVisualStyleBackColor = True
        '
        'TB_Shop_Name
        '
        Me.TB_Shop_Name.Location = New System.Drawing.Point(306, 57)
        Me.TB_Shop_Name.Name = "TB_Shop_Name"
        Me.TB_Shop_Name.Size = New System.Drawing.Size(197, 22)
        Me.TB_Shop_Name.TabIndex = 10
        '
        'TB_Shop_Desc
        '
        Me.TB_Shop_Desc.Location = New System.Drawing.Point(306, 94)
        Me.TB_Shop_Desc.Name = "TB_Shop_Desc"
        Me.TB_Shop_Desc.Size = New System.Drawing.Size(197, 22)
        Me.TB_Shop_Desc.TabIndex = 11
        '
        'Shop_desc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 489)
        Me.Controls.Add(Me.TB_Shop_Desc)
        Me.Controls.Add(Me.TB_Shop_Name)
        Me.Controls.Add(Me.CB_Shop_ACT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV_Shop)
        Me.Controls.Add(Me.BT_Shop_Close)
        Me.Controls.Add(Me.BT_Shop_Del)
        Me.Controls.Add(Me.BT_Shop_Modify)
        Me.Controls.Add(Me.BT_Shop_Create)
        Me.Controls.Add(Me.BT_Shop_GetData)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Shop_desc"
        Me.Text = "Shop Define"
        CType(Me.DGV_Shop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_Shop_GetData As System.Windows.Forms.Button
    Friend WithEvents BT_Shop_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Shop_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_Shop_Del As System.Windows.Forms.Button
    Friend WithEvents BT_Shop_Close As System.Windows.Forms.Button
    Friend WithEvents DGV_Shop As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CB_Shop_ACT As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Shop_Name As System.Windows.Forms.TextBox
    Friend WithEvents TB_Shop_Desc As System.Windows.Forms.TextBox
End Class
