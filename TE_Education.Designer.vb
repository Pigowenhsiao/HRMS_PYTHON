<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Education
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
        Me.BT_TEE_GETDATA = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV_TEE = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LB_TEE_NAME = New System.Windows.Forms.Label
        Me.LB_TEE_ID = New System.Windows.Forms.Label
        Me.LB_TEE_EDU = New System.Windows.Forms.Label
        Me.LB_TEE_MAJOR = New System.Windows.Forms.Label
        Me.LB_TEE_GSCHOOL = New System.Windows.Forms.Label
        Me.BT_TEE_EDUQ = New System.Windows.Forms.Button
        Me.BTT_TEE_GSCHOOLQ = New System.Windows.Forms.Button
        Me.BT_TEE_MAJORQ = New System.Windows.Forms.Button
        CType(Me.DGV_TEE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BT_TEE_GETDATA
        '
        Me.BT_TEE_GETDATA.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_TEE_GETDATA.Location = New System.Drawing.Point(26, 46)
        Me.BT_TEE_GETDATA.Name = "BT_TEE_GETDATA"
        Me.BT_TEE_GETDATA.Size = New System.Drawing.Size(146, 31)
        Me.BT_TEE_GETDATA.TabIndex = 0
        Me.BT_TEE_GETDATA.Text = "撈資料"
        Me.BT_TEE_GETDATA.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "TE 學歷維護作業"
        '
        'DGV_TEE
        '
        Me.DGV_TEE.AllowUserToAddRows = False
        Me.DGV_TEE.AllowUserToDeleteRows = False
        Me.DGV_TEE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_TEE.Location = New System.Drawing.Point(8, 160)
        Me.DGV_TEE.Name = "DGV_TEE"
        Me.DGV_TEE.ReadOnly = True
        Me.DGV_TEE.RowTemplate.Height = 24
        Me.DGV_TEE.Size = New System.Drawing.Size(591, 316)
        Me.DGV_TEE.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(193, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "姓        名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(366, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "工      號"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(193, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "學        歷"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(193, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "畢業學校"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(366, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 20)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "主      修"
        '
        'LB_TEE_NAME
        '
        Me.LB_TEE_NAME.AutoSize = True
        Me.LB_TEE_NAME.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_TEE_NAME.Location = New System.Drawing.Point(272, 49)
        Me.LB_TEE_NAME.Name = "LB_TEE_NAME"
        Me.LB_TEE_NAME.Size = New System.Drawing.Size(0, 20)
        Me.LB_TEE_NAME.TabIndex = 8
        '
        'LB_TEE_ID
        '
        Me.LB_TEE_ID.AutoSize = True
        Me.LB_TEE_ID.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_TEE_ID.Location = New System.Drawing.Point(437, 49)
        Me.LB_TEE_ID.Name = "LB_TEE_ID"
        Me.LB_TEE_ID.Size = New System.Drawing.Size(0, 20)
        Me.LB_TEE_ID.TabIndex = 9
        '
        'LB_TEE_EDU
        '
        Me.LB_TEE_EDU.AutoSize = True
        Me.LB_TEE_EDU.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_TEE_EDU.Location = New System.Drawing.Point(272, 89)
        Me.LB_TEE_EDU.Name = "LB_TEE_EDU"
        Me.LB_TEE_EDU.Size = New System.Drawing.Size(0, 20)
        Me.LB_TEE_EDU.TabIndex = 10
        '
        'LB_TEE_MAJOR
        '
        Me.LB_TEE_MAJOR.AutoSize = True
        Me.LB_TEE_MAJOR.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_TEE_MAJOR.Location = New System.Drawing.Point(437, 89)
        Me.LB_TEE_MAJOR.Name = "LB_TEE_MAJOR"
        Me.LB_TEE_MAJOR.Size = New System.Drawing.Size(0, 20)
        Me.LB_TEE_MAJOR.TabIndex = 11
        '
        'LB_TEE_GSCHOOL
        '
        Me.LB_TEE_GSCHOOL.AutoSize = True
        Me.LB_TEE_GSCHOOL.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LB_TEE_GSCHOOL.Location = New System.Drawing.Point(272, 126)
        Me.LB_TEE_GSCHOOL.Name = "LB_TEE_GSCHOOL"
        Me.LB_TEE_GSCHOOL.Size = New System.Drawing.Size(0, 20)
        Me.LB_TEE_GSCHOOL.TabIndex = 12
        '
        'BT_TEE_EDUQ
        '
        Me.BT_TEE_EDUQ.Location = New System.Drawing.Point(162, 88)
        Me.BT_TEE_EDUQ.Name = "BT_TEE_EDUQ"
        Me.BT_TEE_EDUQ.Size = New System.Drawing.Size(25, 26)
        Me.BT_TEE_EDUQ.TabIndex = 13
        Me.BT_TEE_EDUQ.Text = "Q"
        Me.BT_TEE_EDUQ.UseVisualStyleBackColor = True
        '
        'BTT_TEE_GSCHOOLQ
        '
        Me.BTT_TEE_GSCHOOLQ.Location = New System.Drawing.Point(162, 126)
        Me.BTT_TEE_GSCHOOLQ.Name = "BTT_TEE_GSCHOOLQ"
        Me.BTT_TEE_GSCHOOLQ.Size = New System.Drawing.Size(25, 26)
        Me.BTT_TEE_GSCHOOLQ.TabIndex = 14
        Me.BTT_TEE_GSCHOOLQ.Text = "Q"
        Me.BTT_TEE_GSCHOOLQ.UseVisualStyleBackColor = True
        '
        'BT_TEE_MAJORQ
        '
        Me.BT_TEE_MAJORQ.Location = New System.Drawing.Point(345, 88)
        Me.BT_TEE_MAJORQ.Name = "BT_TEE_MAJORQ"
        Me.BT_TEE_MAJORQ.Size = New System.Drawing.Size(25, 26)
        Me.BT_TEE_MAJORQ.TabIndex = 15
        Me.BT_TEE_MAJORQ.Text = "Q"
        Me.BT_TEE_MAJORQ.UseVisualStyleBackColor = True
        '
        'TE_Education
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 489)
        Me.Controls.Add(Me.BT_TEE_MAJORQ)
        Me.Controls.Add(Me.BTT_TEE_GSCHOOLQ)
        Me.Controls.Add(Me.BT_TEE_EDUQ)
        Me.Controls.Add(Me.LB_TEE_GSCHOOL)
        Me.Controls.Add(Me.LB_TEE_MAJOR)
        Me.Controls.Add(Me.LB_TEE_EDU)
        Me.Controls.Add(Me.LB_TEE_ID)
        Me.Controls.Add(Me.LB_TEE_NAME)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV_TEE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BT_TEE_GETDATA)
        Me.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "TE_Education"
        Me.Text = "TE Education Maniatince"
        CType(Me.DGV_TEE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_TEE_GETDATA As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_TEE As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LB_TEE_NAME As System.Windows.Forms.Label
    Friend WithEvents LB_TEE_ID As System.Windows.Forms.Label
    Friend WithEvents LB_TEE_EDU As System.Windows.Forms.Label
    Friend WithEvents LB_TEE_MAJOR As System.Windows.Forms.Label
    Friend WithEvents LB_TEE_GSCHOOL As System.Windows.Forms.Label
    Friend WithEvents BT_TEE_EDUQ As System.Windows.Forms.Button
    Friend WithEvents BTT_TEE_GSCHOOLQ As System.Windows.Forms.Button
    Friend WithEvents BT_TEE_MAJORQ As System.Windows.Forms.Button
End Class
