<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Personal_Data
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.DGV_PBASIC = New System.Windows.Forms.DataGridView
        CType(Me.DGV_PBASIC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.Location = New System.Drawing.Point(39, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(175, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DGV_PBASIC
        '
        Me.DGV_PBASIC.AllowUserToAddRows = False
        Me.DGV_PBASIC.AllowUserToDeleteRows = False
        Me.DGV_PBASIC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_PBASIC.Location = New System.Drawing.Point(7, 85)
        Me.DGV_PBASIC.Name = "DGV_PBASIC"
        Me.DGV_PBASIC.ReadOnly = True
        Me.DGV_PBASIC.RowTemplate.Height = 24
        Me.DGV_PBASIC.Size = New System.Drawing.Size(843, 376)
        Me.DGV_PBASIC.TabIndex = 2
        '
        'Personal_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 467)
        Me.Controls.Add(Me.DGV_PBASIC)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Personal_Data"
        Me.Text = "Personal_Data"
        CType(Me.DGV_PBASIC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DGV_PBASIC As System.Windows.Forms.DataGridView
End Class
