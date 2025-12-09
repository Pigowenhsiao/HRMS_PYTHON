<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CF_Certify_Del
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
        Me.TB_Certify_ID = New System.Windows.Forms.TextBox
        Me.BT_Certify_ID_Q = New System.Windows.Forms.Button
        Me.BT_Certify_Delete = New System.Windows.Forms.Button
        Me.DGV_Certify_Data = New System.Windows.Forms.DataGridView
        CType(Me.DGV_Certify_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(233, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Certify 編號"
        '
        'TB_Certify_ID
        '
        Me.TB_Certify_ID.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_Certify_ID.Location = New System.Drawing.Point(333, 8)
        Me.TB_Certify_ID.Name = "TB_Certify_ID"
        Me.TB_Certify_ID.Size = New System.Drawing.Size(202, 29)
        Me.TB_Certify_ID.TabIndex = 1
        '
        'BT_Certify_ID_Q
        '
        Me.BT_Certify_ID_Q.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_ID_Q.Location = New System.Drawing.Point(545, 9)
        Me.BT_Certify_ID_Q.Name = "BT_Certify_ID_Q"
        Me.BT_Certify_ID_Q.Size = New System.Drawing.Size(27, 27)
        Me.BT_Certify_ID_Q.TabIndex = 2
        Me.BT_Certify_ID_Q.Text = "Q"
        Me.BT_Certify_ID_Q.UseVisualStyleBackColor = True
        '
        'BT_Certify_Delete
        '
        Me.BT_Certify_Delete.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Certify_Delete.Location = New System.Drawing.Point(14, 12)
        Me.BT_Certify_Delete.Name = "BT_Certify_Delete"
        Me.BT_Certify_Delete.Size = New System.Drawing.Size(145, 35)
        Me.BT_Certify_Delete.TabIndex = 3
        Me.BT_Certify_Delete.Text = "刪除記錄"
        Me.BT_Certify_Delete.UseVisualStyleBackColor = True
        '
        'DGV_Certify_Data
        '
        Me.DGV_Certify_Data.AllowUserToAddRows = False
        Me.DGV_Certify_Data.AllowUserToDeleteRows = False
        Me.DGV_Certify_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Certify_Data.Location = New System.Drawing.Point(3, 74)
        Me.DGV_Certify_Data.Name = "DGV_Certify_Data"
        Me.DGV_Certify_Data.ReadOnly = True
        Me.DGV_Certify_Data.RowTemplate.Height = 24
        Me.DGV_Certify_Data.Size = New System.Drawing.Size(652, 358)
        Me.DGV_Certify_Data.TabIndex = 4
        '
        'CF_Certify_Del
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 433)
        Me.Controls.Add(Me.DGV_Certify_Data)
        Me.Controls.Add(Me.BT_Certify_Delete)
        Me.Controls.Add(Me.BT_Certify_ID_Q)
        Me.Controls.Add(Me.TB_Certify_ID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CF_Certify_Del"
        Me.Text = "Certify Record Delete"
        CType(Me.DGV_Certify_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_Certify_ID As System.Windows.Forms.TextBox
    Friend WithEvents BT_Certify_ID_Q As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_Delete As System.Windows.Forms.Button
    Friend WithEvents DGV_Certify_Data As System.Windows.Forms.DataGridView
End Class
