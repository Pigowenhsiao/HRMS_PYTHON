<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPT_Newadd
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
        Me.BT_Export = New System.Windows.Forms.Button
        Me.DGV_NewAdd = New System.Windows.Forms.DataGridView
        Me.BT_NewAdd_Certify = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TB_NewAdd_Date = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DGV_NewAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BT_Export
        '
        Me.BT_Export.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Export.Location = New System.Drawing.Point(405, 50)
        Me.BT_Export.Name = "BT_Export"
        Me.BT_Export.Size = New System.Drawing.Size(166, 35)
        Me.BT_Export.TabIndex = 19
        Me.BT_Export.Text = "Export Excel"
        Me.BT_Export.UseVisualStyleBackColor = True
        '
        'DGV_NewAdd
        '
        Me.DGV_NewAdd.AllowUserToAddRows = False
        Me.DGV_NewAdd.AllowUserToDeleteRows = False
        Me.DGV_NewAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_NewAdd.Location = New System.Drawing.Point(7, 92)
        Me.DGV_NewAdd.Name = "DGV_NewAdd"
        Me.DGV_NewAdd.ReadOnly = True
        Me.DGV_NewAdd.RowTemplate.Height = 24
        Me.DGV_NewAdd.Size = New System.Drawing.Size(822, 334)
        Me.DGV_NewAdd.TabIndex = 18
        '
        'BT_NewAdd_Certify
        '
        Me.BT_NewAdd_Certify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_NewAdd_Certify.Location = New System.Drawing.Point(18, 50)
        Me.BT_NewAdd_Certify.Name = "BT_NewAdd_Certify"
        Me.BT_NewAdd_Certify.Size = New System.Drawing.Size(163, 36)
        Me.BT_NewAdd_Certify.TabIndex = 17
        Me.BT_NewAdd_Certify.Text = "查詢特定日期之後"
        Me.BT_NewAdd_Certify.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 31)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Certify 期間查詢"
        '
        'TB_NewAdd_Date
        '
        Me.TB_NewAdd_Date.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_NewAdd_Date.Location = New System.Drawing.Point(249, 52)
        Me.TB_NewAdd_Date.Name = "TB_NewAdd_Date"
        Me.TB_NewAdd_Date.Size = New System.Drawing.Size(149, 29)
        Me.TB_NewAdd_Date.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(198, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "日期"
        '
        'RPT_Newadd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 435)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_NewAdd_Date)
        Me.Controls.Add(Me.BT_Export)
        Me.Controls.Add(Me.DGV_NewAdd)
        Me.Controls.Add(Me.BT_NewAdd_Certify)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RPT_Newadd"
        Me.Text = "新增項目"
        CType(Me.DGV_NewAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_Export As System.Windows.Forms.Button
    Friend WithEvents DGV_NewAdd As System.Windows.Forms.DataGridView
    Friend WithEvents BT_NewAdd_Certify As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_NewAdd_Date As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
