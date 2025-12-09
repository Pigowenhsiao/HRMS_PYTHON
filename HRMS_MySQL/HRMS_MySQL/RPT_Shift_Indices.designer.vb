<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPT_Shift_Indices
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DGV_RPT_Indices = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.BT_RPT_INDICES_GETDATA = New System.Windows.Forms.Button
        Me.BT_RPT_INDEX_Export = New System.Windows.Forms.Button
        Me.BT_GetDetail = New System.Windows.Forms.Button
        CType(Me.DGV_RPT_Indices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_RPT_Indices
        '
        Me.DGV_RPT_Indices.AllowUserToAddRows = False
        Me.DGV_RPT_Indices.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_RPT_Indices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_RPT_Indices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_RPT_Indices.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_RPT_Indices.Location = New System.Drawing.Point(3, 80)
        Me.DGV_RPT_Indices.Name = "DGV_RPT_Indices"
        Me.DGV_RPT_Indices.ReadOnly = True
        Me.DGV_RPT_Indices.RowTemplate.Height = 24
        Me.DGV_RPT_Indices.Size = New System.Drawing.Size(637, 427)
        Me.DGV_RPT_Indices.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "戰力指標報表"
        '
        'BT_RPT_INDICES_GETDATA
        '
        Me.BT_RPT_INDICES_GETDATA.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_RPT_INDICES_GETDATA.Location = New System.Drawing.Point(25, 43)
        Me.BT_RPT_INDICES_GETDATA.Name = "BT_RPT_INDICES_GETDATA"
        Me.BT_RPT_INDICES_GETDATA.Size = New System.Drawing.Size(146, 31)
        Me.BT_RPT_INDICES_GETDATA.TabIndex = 3
        Me.BT_RPT_INDICES_GETDATA.Text = "撈資料"
        Me.BT_RPT_INDICES_GETDATA.UseVisualStyleBackColor = True
        '
        'BT_RPT_INDEX_Export
        '
        Me.BT_RPT_INDEX_Export.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_RPT_INDEX_Export.Location = New System.Drawing.Point(361, 43)
        Me.BT_RPT_INDEX_Export.Name = "BT_RPT_INDEX_Export"
        Me.BT_RPT_INDEX_Export.Size = New System.Drawing.Size(146, 31)
        Me.BT_RPT_INDEX_Export.TabIndex = 6
        Me.BT_RPT_INDEX_Export.Text = "Export Excel"
        Me.BT_RPT_INDEX_Export.UseVisualStyleBackColor = True
        '
        'BT_GetDetail
        '
        Me.BT_GetDetail.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_GetDetail.Location = New System.Drawing.Point(193, 43)
        Me.BT_GetDetail.Name = "BT_GetDetail"
        Me.BT_GetDetail.Size = New System.Drawing.Size(146, 31)
        Me.BT_GetDetail.TabIndex = 7
        Me.BT_GetDetail.Text = "資料細項"
        Me.BT_GetDetail.UseVisualStyleBackColor = True
        '
        'RPT_Shift_Indices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 507)
        Me.Controls.Add(Me.BT_GetDetail)
        Me.Controls.Add(Me.BT_RPT_INDEX_Export)
        Me.Controls.Add(Me.DGV_RPT_Indices)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BT_RPT_INDICES_GETDATA)
        Me.Name = "RPT_Shift_Indices"
        Me.Text = "RPT_Shift_Indices"
        CType(Me.DGV_RPT_Indices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_RPT_Indices As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_RPT_INDICES_GETDATA As System.Windows.Forms.Button
    Friend WithEvents BT_RPT_INDEX_Export As System.Windows.Forms.Button
    Friend WithEvents BT_GetDetail As System.Windows.Forms.Button
End Class
