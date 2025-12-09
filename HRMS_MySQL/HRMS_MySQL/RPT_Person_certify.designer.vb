<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPT_Person_certify
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
        Me.DGV_Person_Certify = New System.Windows.Forms.DataGridView
        Me.BT_Person_Certify = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.BT_Export = New System.Windows.Forms.Button
        CType(Me.DGV_Person_Certify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Person_Certify
        '
        Me.DGV_Person_Certify.AllowUserToAddRows = False
        Me.DGV_Person_Certify.AllowUserToDeleteRows = False
        Me.DGV_Person_Certify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Person_Certify.Location = New System.Drawing.Point(7, 85)
        Me.DGV_Person_Certify.Name = "DGV_Person_Certify"
        Me.DGV_Person_Certify.ReadOnly = True
        Me.DGV_Person_Certify.RowTemplate.Height = 24
        Me.DGV_Person_Certify.Size = New System.Drawing.Size(822, 334)
        Me.DGV_Person_Certify.TabIndex = 14
        '
        'BT_Person_Certify
        '
        Me.BT_Person_Certify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Person_Certify.Location = New System.Drawing.Point(18, 43)
        Me.BT_Person_Certify.Name = "BT_Person_Certify"
        Me.BT_Person_Certify.Size = New System.Drawing.Size(163, 36)
        Me.BT_Person_Certify.TabIndex = 13
        Me.BT_Person_Certify.Text = "查詢全部"
        Me.BT_Person_Certify.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 31)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Certify 期間查詢"
        '
        'BT_Export
        '
        Me.BT_Export.Location = New System.Drawing.Point(195, 43)
        Me.BT_Export.Name = "BT_Export"
        Me.BT_Export.Size = New System.Drawing.Size(166, 35)
        Me.BT_Export.TabIndex = 15
        Me.BT_Export.Text = "Export Excel"
        Me.BT_Export.UseVisualStyleBackColor = True
        '
        'RPT_Person_certify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 429)
        Me.Controls.Add(Me.BT_Export)
        Me.Controls.Add(Me.DGV_Person_Certify)
        Me.Controls.Add(Me.BT_Person_Certify)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "RPT_Person_certify"
        Me.Text = "個人不重複的認證項目"
        CType(Me.DGV_Person_Certify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Person_Certify As System.Windows.Forms.DataGridView
    Friend WithEvents BT_Person_Certify As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_Export As System.Windows.Forms.Button
End Class
