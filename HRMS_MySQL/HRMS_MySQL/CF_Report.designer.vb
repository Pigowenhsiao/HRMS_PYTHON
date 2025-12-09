<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CF_Report
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
        Me.DGV_CF_OverDue = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_CF_OverDue_Secial = New System.Windows.Forms.TextBox
        Me.BT_CF_OverDue_Special = New System.Windows.Forms.Button
        Me.BT_CF_OverDue_Getdata = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.CB_SHIFT = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.DGV_CF_OverDue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_CF_OverDue
        '
        Me.DGV_CF_OverDue.AllowUserToAddRows = False
        Me.DGV_CF_OverDue.AllowUserToDeleteRows = False
        Me.DGV_CF_OverDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_CF_OverDue.Location = New System.Drawing.Point(5, 95)
        Me.DGV_CF_OverDue.Name = "DGV_CF_OverDue"
        Me.DGV_CF_OverDue.ReadOnly = True
        Me.DGV_CF_OverDue.RowTemplate.Height = 24
        Me.DGV_CF_OverDue.Size = New System.Drawing.Size(804, 334)
        Me.DGV_CF_OverDue.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(737, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "請用日數"
        '
        'TB_CF_OverDue_Secial
        '
        Me.TB_CF_OverDue_Secial.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_CF_OverDue_Secial.Location = New System.Drawing.Point(646, 48)
        Me.TB_CF_OverDue_Secial.Name = "TB_CF_OverDue_Secial"
        Me.TB_CF_OverDue_Secial.Size = New System.Drawing.Size(85, 29)
        Me.TB_CF_OverDue_Secial.TabIndex = 9
        '
        'BT_CF_OverDue_Special
        '
        Me.BT_CF_OverDue_Special.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_CF_OverDue_Special.Location = New System.Drawing.Point(467, 44)
        Me.BT_CF_OverDue_Special.Name = "BT_CF_OverDue_Special"
        Me.BT_CF_OverDue_Special.Size = New System.Drawing.Size(163, 36)
        Me.BT_CF_OverDue_Special.TabIndex = 8
        Me.BT_CF_OverDue_Special.Text = "查詢特定日期之後"
        Me.BT_CF_OverDue_Special.UseVisualStyleBackColor = True
        '
        'BT_CF_OverDue_Getdata
        '
        Me.BT_CF_OverDue_Getdata.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_CF_OverDue_Getdata.Location = New System.Drawing.Point(5, 44)
        Me.BT_CF_OverDue_Getdata.Name = "BT_CF_OverDue_Getdata"
        Me.BT_CF_OverDue_Getdata.Size = New System.Drawing.Size(163, 36)
        Me.BT_CF_OverDue_Getdata.TabIndex = 7
        Me.BT_CF_OverDue_Getdata.Text = "查詢全部"
        Me.BT_CF_OverDue_Getdata.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 31)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Certify 期間查詢"
        '
        'CB_SHIFT
        '
        Me.CB_SHIFT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_SHIFT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_SHIFT.FormattingEnabled = True
        Me.CB_SHIFT.Location = New System.Drawing.Point(258, 49)
        Me.CB_SHIFT.Name = "CB_SHIFT"
        Me.CB_SHIFT.Size = New System.Drawing.Size(180, 28)
        Me.CB_SHIFT.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(211, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "班別"
        '
        'CF_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 436)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CB_SHIFT)
        Me.Controls.Add(Me.DGV_CF_OverDue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_CF_OverDue_Secial)
        Me.Controls.Add(Me.BT_CF_OverDue_Special)
        Me.Controls.Add(Me.BT_CF_OverDue_Getdata)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CF_Report"
        Me.Text = "CF_Report"
        CType(Me.DGV_CF_OverDue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_CF_OverDue As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_CF_OverDue_Secial As System.Windows.Forms.TextBox
    Friend WithEvents BT_CF_OverDue_Special As System.Windows.Forms.Button
    Friend WithEvents BT_CF_OverDue_Getdata As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_SHIFT As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
