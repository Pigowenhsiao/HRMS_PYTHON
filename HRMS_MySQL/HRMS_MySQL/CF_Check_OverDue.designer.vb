<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CF_Check_OverDue
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
        Me.BT_CF_OverDue_Getdata = New System.Windows.Forms.Button
        Me.BT_CF_OverDue_Special = New System.Windows.Forms.Button
        Me.TB_CF_OverDue_Secial = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV_CF_OverDue = New System.Windows.Forms.DataGridView
        CType(Me.DGV_CF_OverDue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Certify 期間查詢"
        '
        'BT_CF_OverDue_Getdata
        '
        Me.BT_CF_OverDue_Getdata.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_CF_OverDue_Getdata.Location = New System.Drawing.Point(24, 45)
        Me.BT_CF_OverDue_Getdata.Name = "BT_CF_OverDue_Getdata"
        Me.BT_CF_OverDue_Getdata.Size = New System.Drawing.Size(163, 36)
        Me.BT_CF_OverDue_Getdata.TabIndex = 1
        Me.BT_CF_OverDue_Getdata.Text = "查詢全部"
        Me.BT_CF_OverDue_Getdata.UseVisualStyleBackColor = True
        '
        'BT_CF_OverDue_Special
        '
        Me.BT_CF_OverDue_Special.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_CF_OverDue_Special.Location = New System.Drawing.Point(270, 45)
        Me.BT_CF_OverDue_Special.Name = "BT_CF_OverDue_Special"
        Me.BT_CF_OverDue_Special.Size = New System.Drawing.Size(163, 36)
        Me.BT_CF_OverDue_Special.TabIndex = 2
        Me.BT_CF_OverDue_Special.Text = "查詢特定日期之後"
        Me.BT_CF_OverDue_Special.UseVisualStyleBackColor = True
        '
        'TB_CF_OverDue_Secial
        '
        Me.TB_CF_OverDue_Secial.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_CF_OverDue_Secial.Location = New System.Drawing.Point(449, 49)
        Me.TB_CF_OverDue_Secial.Name = "TB_CF_OverDue_Secial"
        Me.TB_CF_OverDue_Secial.Size = New System.Drawing.Size(85, 29)
        Me.TB_CF_OverDue_Secial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(540, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "請用日數"
        '
        'DGV_CF_OverDue
        '
        Me.DGV_CF_OverDue.AllowUserToAddRows = False
        Me.DGV_CF_OverDue.AllowUserToDeleteRows = False
        Me.DGV_CF_OverDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_CF_OverDue.Location = New System.Drawing.Point(7, 96)
        Me.DGV_CF_OverDue.Name = "DGV_CF_OverDue"
        Me.DGV_CF_OverDue.ReadOnly = True
        Me.DGV_CF_OverDue.RowTemplate.Height = 24
        Me.DGV_CF_OverDue.Size = New System.Drawing.Size(646, 334)
        Me.DGV_CF_OverDue.TabIndex = 5
        '
        'CF_Check_OverDue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 437)
        Me.Controls.Add(Me.DGV_CF_OverDue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_CF_OverDue_Secial)
        Me.Controls.Add(Me.BT_CF_OverDue_Special)
        Me.Controls.Add(Me.BT_CF_OverDue_Getdata)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CF_Check_OverDue"
        Me.Text = "CF_Check_OverDue"
        CType(Me.DGV_CF_OverDue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_CF_OverDue_Getdata As System.Windows.Forms.Button
    Friend WithEvents BT_CF_OverDue_Special As System.Windows.Forms.Button
    Friend WithEvents TB_CF_OverDue_Secial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV_CF_OverDue As System.Windows.Forms.DataGridView
End Class
