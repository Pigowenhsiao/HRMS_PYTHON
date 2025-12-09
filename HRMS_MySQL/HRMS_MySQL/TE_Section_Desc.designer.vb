<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Section_Desc
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
        Me.BT_Section_GetData = New System.Windows.Forms.Button
        Me.BT_Section_Create = New System.Windows.Forms.Button
        Me.BT_Section_Modify = New System.Windows.Forms.Button
        Me.BT_Section_Del = New System.Windows.Forms.Button
        Me.BT_Section_Close = New System.Windows.Forms.Button
        Me.DGV_Section = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Section_Code = New System.Windows.Forms.TextBox
        Me.TB_Section_Name = New System.Windows.Forms.TextBox
        Me.TB_Section_Desc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_Section_Supervisor = New System.Windows.Forms.TextBox
        CType(Me.DGV_Section, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "課別定義作業"
        '
        'BT_Section_GetData
        '
        Me.BT_Section_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Section_GetData.Location = New System.Drawing.Point(28, 47)
        Me.BT_Section_GetData.Name = "BT_Section_GetData"
        Me.BT_Section_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_Section_GetData.TabIndex = 1
        Me.BT_Section_GetData.Text = "撈資料"
        Me.BT_Section_GetData.UseVisualStyleBackColor = True
        '
        'BT_Section_Create
        '
        Me.BT_Section_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Section_Create.Location = New System.Drawing.Point(28, 84)
        Me.BT_Section_Create.Name = "BT_Section_Create"
        Me.BT_Section_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Section_Create.TabIndex = 2
        Me.BT_Section_Create.Text = "新增資料"
        Me.BT_Section_Create.UseVisualStyleBackColor = True
        '
        'BT_Section_Modify
        '
        Me.BT_Section_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Section_Modify.Location = New System.Drawing.Point(28, 121)
        Me.BT_Section_Modify.Name = "BT_Section_Modify"
        Me.BT_Section_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Section_Modify.TabIndex = 3
        Me.BT_Section_Modify.Text = "修改資料"
        Me.BT_Section_Modify.UseVisualStyleBackColor = True
        '
        'BT_Section_Del
        '
        Me.BT_Section_Del.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Section_Del.Location = New System.Drawing.Point(28, 158)
        Me.BT_Section_Del.Name = "BT_Section_Del"
        Me.BT_Section_Del.Size = New System.Drawing.Size(146, 31)
        Me.BT_Section_Del.TabIndex = 4
        Me.BT_Section_Del.Text = "刪除資料"
        Me.BT_Section_Del.UseVisualStyleBackColor = True
        '
        'BT_Section_Close
        '
        Me.BT_Section_Close.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Section_Close.Location = New System.Drawing.Point(28, 195)
        Me.BT_Section_Close.Name = "BT_Section_Close"
        Me.BT_Section_Close.Size = New System.Drawing.Size(146, 31)
        Me.BT_Section_Close.TabIndex = 5
        Me.BT_Section_Close.Text = "Main Page"
        Me.BT_Section_Close.UseVisualStyleBackColor = True
        '
        'DGV_Section
        '
        Me.DGV_Section.AllowUserToAddRows = False
        Me.DGV_Section.AllowUserToDeleteRows = False
        Me.DGV_Section.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Section.Location = New System.Drawing.Point(7, 244)
        Me.DGV_Section.Name = "DGV_Section"
        Me.DGV_Section.ReadOnly = True
        Me.DGV_Section.RowTemplate.Height = 24
        Me.DGV_Section.Size = New System.Drawing.Size(543, 241)
        Me.DGV_Section.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(207, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Section_Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(207, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Section_Name"
        '
        'TB_Section_Code
        '
        Me.TB_Section_Code.Location = New System.Drawing.Point(331, 50)
        Me.TB_Section_Code.Name = "TB_Section_Code"
        Me.TB_Section_Code.Size = New System.Drawing.Size(208, 22)
        Me.TB_Section_Code.TabIndex = 10
        '
        'TB_Section_Name
        '
        Me.TB_Section_Name.Location = New System.Drawing.Point(331, 87)
        Me.TB_Section_Name.Name = "TB_Section_Name"
        Me.TB_Section_Name.Size = New System.Drawing.Size(208, 22)
        Me.TB_Section_Name.TabIndex = 11
        '
        'TB_Section_Desc
        '
        Me.TB_Section_Desc.Location = New System.Drawing.Point(331, 121)
        Me.TB_Section_Desc.Name = "TB_Section_Desc"
        Me.TB_Section_Desc.Size = New System.Drawing.Size(208, 22)
        Me.TB_Section_Desc.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(207, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Section_Desc"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(207, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Section_SPV"
        '
        'TB_Section_Supervisor
        '
        Me.TB_Section_Supervisor.Location = New System.Drawing.Point(331, 158)
        Me.TB_Section_Supervisor.Name = "TB_Section_Supervisor"
        Me.TB_Section_Supervisor.Size = New System.Drawing.Size(208, 22)
        Me.TB_Section_Supervisor.TabIndex = 14
        '
        'TE_Section_Desc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 489)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TB_Section_Supervisor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_Section_Desc)
        Me.Controls.Add(Me.TB_Section_Name)
        Me.Controls.Add(Me.TB_Section_Code)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV_Section)
        Me.Controls.Add(Me.BT_Section_Close)
        Me.Controls.Add(Me.BT_Section_Del)
        Me.Controls.Add(Me.BT_Section_Modify)
        Me.Controls.Add(Me.BT_Section_Create)
        Me.Controls.Add(Me.BT_Section_GetData)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TE_Section_Desc"
        Me.Text = "Section Define"
        CType(Me.DGV_Section, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_Section_GetData As System.Windows.Forms.Button
    Friend WithEvents BT_Section_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Section_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_Section_Del As System.Windows.Forms.Button
    Friend WithEvents BT_Section_Close As System.Windows.Forms.Button
    Friend WithEvents DGV_Section As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Section_Code As System.Windows.Forms.TextBox
    Friend WithEvents TB_Section_Name As System.Windows.Forms.TextBox
    Friend WithEvents TB_Section_Desc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_Section_Supervisor As System.Windows.Forms.TextBox
End Class
