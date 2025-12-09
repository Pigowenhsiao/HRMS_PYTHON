<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Authority_Control
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
        Me.DGV_Authority = New System.Windows.Forms.DataGridView
        Me.BT_Authority_GetData = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.BT_Authority_Create = New System.Windows.Forms.Button
        Me.BT_Authority_Modify = New System.Windows.Forms.Button
        Me.BT_Authority_Close = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_Authority_Account = New System.Windows.Forms.TextBox
        Me.CB_Authority_Active = New System.Windows.Forms.CheckBox
        Me.BT_Authority_Fail = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RB_Auth_Keyin = New System.Windows.Forms.RadioButton
        Me.RB_Auth_Full = New System.Windows.Forms.RadioButton
        Me.CB_AUT_DEL_Certify = New System.Windows.Forms.CheckBox
        CType(Me.DGV_Authority, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_Authority
        '
        Me.DGV_Authority.AllowUserToAddRows = False
        Me.DGV_Authority.AllowUserToDeleteRows = False
        Me.DGV_Authority.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Authority.Location = New System.Drawing.Point(6, 228)
        Me.DGV_Authority.Name = "DGV_Authority"
        Me.DGV_Authority.ReadOnly = True
        Me.DGV_Authority.RowTemplate.Height = 24
        Me.DGV_Authority.Size = New System.Drawing.Size(435, 174)
        Me.DGV_Authority.TabIndex = 0
        '
        'BT_Authority_GetData
        '
        Me.BT_Authority_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Authority_GetData.Location = New System.Drawing.Point(12, 43)
        Me.BT_Authority_GetData.Name = "BT_Authority_GetData"
        Me.BT_Authority_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_Authority_GetData.TabIndex = 1
        Me.BT_Authority_GetData.Text = "目前權限設定"
        Me.BT_Authority_GetData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 31)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "工作帳號設定"
        '
        'BT_Authority_Create
        '
        Me.BT_Authority_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Authority_Create.Location = New System.Drawing.Point(12, 80)
        Me.BT_Authority_Create.Name = "BT_Authority_Create"
        Me.BT_Authority_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Authority_Create.TabIndex = 3
        Me.BT_Authority_Create.Text = "新增帳號權限"
        Me.BT_Authority_Create.UseVisualStyleBackColor = True
        '
        'BT_Authority_Modify
        '
        Me.BT_Authority_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Authority_Modify.Location = New System.Drawing.Point(12, 117)
        Me.BT_Authority_Modify.Name = "BT_Authority_Modify"
        Me.BT_Authority_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Authority_Modify.TabIndex = 4
        Me.BT_Authority_Modify.Text = "修改帳號權限"
        Me.BT_Authority_Modify.UseVisualStyleBackColor = True
        '
        'BT_Authority_Close
        '
        Me.BT_Authority_Close.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Authority_Close.Location = New System.Drawing.Point(12, 154)
        Me.BT_Authority_Close.Name = "BT_Authority_Close"
        Me.BT_Authority_Close.Size = New System.Drawing.Size(146, 31)
        Me.BT_Authority_Close.TabIndex = 5
        Me.BT_Authority_Close.Text = "Main Page"
        Me.BT_Authority_Close.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(165, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "NT 帳號"
        '
        'TB_Authority_Account
        '
        Me.TB_Authority_Account.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_Authority_Account.Location = New System.Drawing.Point(238, 43)
        Me.TB_Authority_Account.Name = "TB_Authority_Account"
        Me.TB_Authority_Account.Size = New System.Drawing.Size(165, 29)
        Me.TB_Authority_Account.TabIndex = 7
        '
        'CB_Authority_Active
        '
        Me.CB_Authority_Active.AutoSize = True
        Me.CB_Authority_Active.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Authority_Active.Location = New System.Drawing.Point(191, 84)
        Me.CB_Authority_Active.Name = "CB_Authority_Active"
        Me.CB_Authority_Active.Size = New System.Drawing.Size(92, 24)
        Me.CB_Authority_Active.TabIndex = 8
        Me.CB_Authority_Active.Text = "是否有效"
        Me.CB_Authority_Active.UseVisualStyleBackColor = True
        '
        'BT_Authority_Fail
        '
        Me.BT_Authority_Fail.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Authority_Fail.Location = New System.Drawing.Point(12, 191)
        Me.BT_Authority_Fail.Name = "BT_Authority_Fail"
        Me.BT_Authority_Fail.Size = New System.Drawing.Size(146, 31)
        Me.BT_Authority_Fail.TabIndex = 9
        Me.BT_Authority_Fail.Text = "失效資料"
        Me.BT_Authority_Fail.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_Auth_Keyin)
        Me.GroupBox1.Controls.Add(Me.RB_Auth_Full)
        Me.GroupBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(191, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 98)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "權限設定"
        '
        'RB_Auth_Keyin
        '
        Me.RB_Auth_Keyin.AutoSize = True
        Me.RB_Auth_Keyin.Location = New System.Drawing.Point(22, 60)
        Me.RB_Auth_Keyin.Name = "RB_Auth_Keyin"
        Me.RB_Auth_Keyin.Size = New System.Drawing.Size(161, 24)
        Me.RB_Auth_Keyin.TabIndex = 1
        Me.RB_Auth_Keyin.TabStop = True
        Me.RB_Auth_Keyin.Text = "Certify Key in 權限"
        Me.RB_Auth_Keyin.UseVisualStyleBackColor = True
        '
        'RB_Auth_Full
        '
        Me.RB_Auth_Full.AutoSize = True
        Me.RB_Auth_Full.Location = New System.Drawing.Point(22, 30)
        Me.RB_Auth_Full.Name = "RB_Auth_Full"
        Me.RB_Auth_Full.Size = New System.Drawing.Size(123, 24)
        Me.RB_Auth_Full.TabIndex = 0
        Me.RB_Auth_Full.TabStop = True
        Me.RB_Auth_Full.Text = "萬能天神權限"
        Me.RB_Auth_Full.UseVisualStyleBackColor = True
        '
        'CB_AUT_DEL_Certify
        '
        Me.CB_AUT_DEL_Certify.AutoSize = True
        Me.CB_AUT_DEL_Certify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_AUT_DEL_Certify.Location = New System.Drawing.Point(299, 84)
        Me.CB_AUT_DEL_Certify.Name = "CB_AUT_DEL_Certify"
        Me.CB_AUT_DEL_Certify.Size = New System.Drawing.Size(145, 24)
        Me.CB_AUT_DEL_Certify.TabIndex = 11
        Me.CB_AUT_DEL_Certify.Text = "刪除Certify 記錄"
        Me.CB_AUT_DEL_Certify.UseVisualStyleBackColor = True
        '
        'Authority_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 414)
        Me.Controls.Add(Me.CB_AUT_DEL_Certify)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BT_Authority_Fail)
        Me.Controls.Add(Me.CB_Authority_Active)
        Me.Controls.Add(Me.TB_Authority_Account)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BT_Authority_Close)
        Me.Controls.Add(Me.BT_Authority_Modify)
        Me.Controls.Add(Me.BT_Authority_Create)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BT_Authority_GetData)
        Me.Controls.Add(Me.DGV_Authority)
        Me.Name = "Authority_Control"
        Me.Text = "Authority_Control"
        CType(Me.DGV_Authority, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Authority As System.Windows.Forms.DataGridView
    Friend WithEvents BT_Authority_GetData As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_Authority_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Authority_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_Authority_Close As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Authority_Account As System.Windows.Forms.TextBox
    Friend WithEvents CB_Authority_Active As System.Windows.Forms.CheckBox
    Friend WithEvents BT_Authority_Fail As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RB_Auth_Keyin As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Auth_Full As System.Windows.Forms.RadioButton
    Friend WithEvents CB_AUT_DEL_Certify As System.Windows.Forms.CheckBox
End Class
