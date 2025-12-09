<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Tool_desc
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
        Me.DGV_Job = New System.Windows.Forms.DataGridView
        Me.BT_Tool_Main = New System.Windows.Forms.Button
        Me.BT_Tool_GetData = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.BT_Tool_Create = New System.Windows.Forms.Button
        Me.BT_Tool_Modify = New System.Windows.Forms.Button
        Me.TB_Tool_ID = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CB_Tool_ACT = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.DGV_Job, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Job
        '
        Me.DGV_Job.AllowUserToAddRows = False
        Me.DGV_Job.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Job.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Job.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Job.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Job.Location = New System.Drawing.Point(3, 219)
        Me.DGV_Job.Name = "DGV_Job"
        Me.DGV_Job.ReadOnly = True
        Me.DGV_Job.RowTemplate.Height = 24
        Me.DGV_Job.Size = New System.Drawing.Size(578, 246)
        Me.DGV_Job.TabIndex = 0
        '
        'BT_Tool_Main
        '
        Me.BT_Tool_Main.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Tool_Main.Location = New System.Drawing.Point(36, 172)
        Me.BT_Tool_Main.Name = "BT_Tool_Main"
        Me.BT_Tool_Main.Size = New System.Drawing.Size(146, 41)
        Me.BT_Tool_Main.TabIndex = 2
        Me.BT_Tool_Main.Text = "Main Page"
        Me.BT_Tool_Main.UseVisualStyleBackColor = True
        '
        'BT_Tool_GetData
        '
        Me.BT_Tool_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Tool_GetData.Location = New System.Drawing.Point(36, 61)
        Me.BT_Tool_GetData.Name = "BT_Tool_GetData"
        Me.BT_Tool_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_Tool_GetData.TabIndex = 3
        Me.BT_Tool_GetData.Text = "撈資料"
        Me.BT_Tool_GetData.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(243, 35)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "免Certify 機台設定"
        '
        'BT_Tool_Create
        '
        Me.BT_Tool_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Tool_Create.Location = New System.Drawing.Point(36, 98)
        Me.BT_Tool_Create.Name = "BT_Tool_Create"
        Me.BT_Tool_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Tool_Create.TabIndex = 5
        Me.BT_Tool_Create.Text = "新增資料"
        Me.BT_Tool_Create.UseVisualStyleBackColor = True
        '
        'BT_Tool_Modify
        '
        Me.BT_Tool_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Tool_Modify.Location = New System.Drawing.Point(36, 135)
        Me.BT_Tool_Modify.Name = "BT_Tool_Modify"
        Me.BT_Tool_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Tool_Modify.TabIndex = 6
        Me.BT_Tool_Modify.Text = "修改資料"
        Me.BT_Tool_Modify.UseVisualStyleBackColor = True
        '
        'TB_Tool_ID
        '
        Me.TB_Tool_ID.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_Tool_ID.Location = New System.Drawing.Point(296, 58)
        Me.TB_Tool_ID.Name = "TB_Tool_ID"
        Me.TB_Tool_ID.Size = New System.Drawing.Size(200, 23)
        Me.TB_Tool_ID.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(208, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "機台編號"
        '
        'CB_Tool_ACT
        '
        Me.CB_Tool_ACT.AutoSize = True
        Me.CB_Tool_ACT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_Tool_ACT.Location = New System.Drawing.Point(296, 98)
        Me.CB_Tool_ACT.Name = "CB_Tool_ACT"
        Me.CB_Tool_ACT.Size = New System.Drawing.Size(92, 24)
        Me.CB_Tool_ACT.TabIndex = 13
        Me.CB_Tool_ACT.Text = "是否生效"
        Me.CB_Tool_ACT.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(218, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(373, 35)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "注意,設定後新進人員才會生效"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(218, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(258, 35)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "現有人員須另外作業"
        '
        'TE_Tool_desc
        '
        Me.ClientSize = New System.Drawing.Size(584, 471)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CB_Tool_ACT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_Tool_ID)
        Me.Controls.Add(Me.BT_Tool_Modify)
        Me.Controls.Add(Me.BT_Tool_Create)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BT_Tool_GetData)
        Me.Controls.Add(Me.BT_Tool_Main)
        Me.Controls.Add(Me.DGV_Job)
        Me.Name = "TE_Tool_desc"
        CType(Me.DGV_Job, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Job As System.Windows.Forms.DataGridView
    Friend WithEvents BT_Tool_Main As System.Windows.Forms.Button
    Friend WithEvents BT_Tool_GetData As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BT_Tool_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Tool_Modify As System.Windows.Forms.Button
    Friend WithEvents TB_Tool_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_Tool_ACT As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
