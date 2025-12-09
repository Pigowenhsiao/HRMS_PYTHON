<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPT_Seniority
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
        Me.BT_RPT_INDEX_Export = New System.Windows.Forms.Button
        Me.DGV_RPT_Indices = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.BT_RPT_Seniority_GETDATA = New System.Windows.Forms.Button
        CType(Me.DGV_RPT_Indices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BT_RPT_INDEX_Export
        '
        Me.BT_RPT_INDEX_Export.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_RPT_INDEX_Export.Location = New System.Drawing.Point(445, 44)
        Me.BT_RPT_INDEX_Export.Name = "BT_RPT_INDEX_Export"
        Me.BT_RPT_INDEX_Export.Size = New System.Drawing.Size(146, 31)
        Me.BT_RPT_INDEX_Export.TabIndex = 15
        Me.BT_RPT_INDEX_Export.Text = "Export Excel"
        Me.BT_RPT_INDEX_Export.UseVisualStyleBackColor = True
        '
        'DGV_RPT_Indices
        '
        Me.DGV_RPT_Indices.AllowUserToAddRows = False
        Me.DGV_RPT_Indices.AllowUserToDeleteRows = False
        Me.DGV_RPT_Indices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_RPT_Indices.Location = New System.Drawing.Point(2, 81)
        Me.DGV_RPT_Indices.Name = "DGV_RPT_Indices"
        Me.DGV_RPT_Indices.ReadOnly = True
        Me.DGV_RPT_Indices.RowTemplate.Height = 24
        Me.DGV_RPT_Indices.Size = New System.Drawing.Size(637, 427)
        Me.DGV_RPT_Indices.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 31)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "人員年資/區域年資報表"
        '
        'BT_RPT_Seniority_GETDATA
        '
        Me.BT_RPT_Seniority_GETDATA.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_RPT_Seniority_GETDATA.Location = New System.Drawing.Point(24, 44)
        Me.BT_RPT_Seniority_GETDATA.Name = "BT_RPT_Seniority_GETDATA"
        Me.BT_RPT_Seniority_GETDATA.Size = New System.Drawing.Size(146, 31)
        Me.BT_RPT_Seniority_GETDATA.TabIndex = 12
        Me.BT_RPT_Seniority_GETDATA.Text = "撈資料"
        Me.BT_RPT_Seniority_GETDATA.UseVisualStyleBackColor = True
        '
        'RPT_Seniority
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 512)
        Me.Controls.Add(Me.BT_RPT_INDEX_Export)
        Me.Controls.Add(Me.DGV_RPT_Indices)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BT_RPT_Seniority_GETDATA)
        Me.Name = "RPT_Seniority"
        Me.Text = "RPT_Seniority"
        CType(Me.DGV_RPT_Indices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_RPT_INDEX_Export As System.Windows.Forms.Button
    Friend WithEvents DGV_RPT_Indices As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_RPT_Seniority_GETDATA As System.Windows.Forms.Button
End Class
