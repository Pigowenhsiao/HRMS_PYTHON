<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPT_PERSON_TEL_QUERY
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
        Me.DGV_RPT_TEL = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.BT_RPT_TEL_GETDATA = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_TEL_NAME = New System.Windows.Forms.TextBox
        CType(Me.DGV_RPT_TEL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_RPT_TEL
        '
        Me.DGV_RPT_TEL.AllowUserToAddRows = False
        Me.DGV_RPT_TEL.AllowUserToDeleteRows = False
        Me.DGV_RPT_TEL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_RPT_TEL.Location = New System.Drawing.Point(6, 76)
        Me.DGV_RPT_TEL.Name = "DGV_RPT_TEL"
        Me.DGV_RPT_TEL.ReadOnly = True
        Me.DGV_RPT_TEL.RowTemplate.Height = 24
        Me.DGV_RPT_TEL.Size = New System.Drawing.Size(637, 427)
        Me.DGV_RPT_TEL.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 31)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "MFG 人員聯絡表"
        '
        'BT_RPT_TEL_GETDATA
        '
        Me.BT_RPT_TEL_GETDATA.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_RPT_TEL_GETDATA.Location = New System.Drawing.Point(15, 39)
        Me.BT_RPT_TEL_GETDATA.Name = "BT_RPT_TEL_GETDATA"
        Me.BT_RPT_TEL_GETDATA.Size = New System.Drawing.Size(146, 31)
        Me.BT_RPT_TEL_GETDATA.TabIndex = 11
        Me.BT_RPT_TEL_GETDATA.Text = "Get Data"
        Me.BT_RPT_TEL_GETDATA.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(193, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "查詢姓名"
        '
        'TB_TEL_NAME
        '
        Me.TB_TEL_NAME.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_TEL_NAME.Location = New System.Drawing.Point(272, 39)
        Me.TB_TEL_NAME.Name = "TB_TEL_NAME"
        Me.TB_TEL_NAME.Size = New System.Drawing.Size(200, 29)
        Me.TB_TEL_NAME.TabIndex = 15
        '
        'RPT_PERSON_TEL_QUERY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 507)
        Me.Controls.Add(Me.TB_TEL_NAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV_RPT_TEL)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BT_RPT_TEL_GETDATA)
        Me.Name = "RPT_PERSON_TEL_QUERY"
        Me.Text = "MFG 人員電話查詢"
        CType(Me.DGV_RPT_TEL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_RPT_TEL As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_RPT_TEL_GETDATA As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_TEL_NAME As System.Windows.Forms.TextBox
End Class
