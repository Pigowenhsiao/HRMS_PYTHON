<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Job_desc
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
        Me.DGV_Job = New System.Windows.Forms.DataGridView
        Me.BT_JOB_Main = New System.Windows.Forms.Button
        Me.BT_JOB_GetData = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.BT_Job_Create = New System.Windows.Forms.Button
        Me.BT_Job_Modify = New System.Windows.Forms.Button
        Me.BT_JOB_Del = New System.Windows.Forms.Button
        Me.TB_JOB_NAME = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_JOB_DESC = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CB_JOB_ACT = New System.Windows.Forms.CheckBox
        CType(Me.DGV_Job, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Job
        '
        Me.DGV_Job.AllowUserToAddRows = False
        Me.DGV_Job.AllowUserToDeleteRows = False
        Me.DGV_Job.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Job.Location = New System.Drawing.Point(15, 244)
        Me.DGV_Job.Name = "DGV_Job"
        Me.DGV_Job.ReadOnly = True
        Me.DGV_Job.RowTemplate.Height = 24
        Me.DGV_Job.Size = New System.Drawing.Size(578, 227)
        Me.DGV_Job.TabIndex = 0
        '
        'BT_JOB_Main
        '
        Me.BT_JOB_Main.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_JOB_Main.Location = New System.Drawing.Point(36, 197)
        Me.BT_JOB_Main.Name = "BT_JOB_Main"
        Me.BT_JOB_Main.Size = New System.Drawing.Size(146, 41)
        Me.BT_JOB_Main.TabIndex = 2
        Me.BT_JOB_Main.Text = "Main Page"
        Me.BT_JOB_Main.UseVisualStyleBackColor = True
        '
        'BT_JOB_GetData
        '
        Me.BT_JOB_GetData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_JOB_GetData.Location = New System.Drawing.Point(36, 50)
        Me.BT_JOB_GetData.Name = "BT_JOB_GetData"
        Me.BT_JOB_GetData.Size = New System.Drawing.Size(146, 31)
        Me.BT_JOB_GetData.TabIndex = 3
        Me.BT_JOB_GetData.Text = "撈資料"
        Me.BT_JOB_GetData.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 35)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "作業類別定義作業"
        '
        'BT_Job_Create
        '
        Me.BT_Job_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Job_Create.Location = New System.Drawing.Point(36, 87)
        Me.BT_Job_Create.Name = "BT_Job_Create"
        Me.BT_Job_Create.Size = New System.Drawing.Size(146, 31)
        Me.BT_Job_Create.TabIndex = 5
        Me.BT_Job_Create.Text = "新增資料"
        Me.BT_Job_Create.UseVisualStyleBackColor = True
        '
        'BT_Job_Modify
        '
        Me.BT_Job_Modify.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_Job_Modify.Location = New System.Drawing.Point(36, 124)
        Me.BT_Job_Modify.Name = "BT_Job_Modify"
        Me.BT_Job_Modify.Size = New System.Drawing.Size(146, 31)
        Me.BT_Job_Modify.TabIndex = 6
        Me.BT_Job_Modify.Text = "修改資料"
        Me.BT_Job_Modify.UseVisualStyleBackColor = True
        '
        'BT_JOB_Del
        '
        Me.BT_JOB_Del.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BT_JOB_Del.Location = New System.Drawing.Point(36, 160)
        Me.BT_JOB_Del.Name = "BT_JOB_Del"
        Me.BT_JOB_Del.Size = New System.Drawing.Size(146, 31)
        Me.BT_JOB_Del.TabIndex = 7
        Me.BT_JOB_Del.Text = "刪除資料"
        Me.BT_JOB_Del.UseVisualStyleBackColor = True
        '
        'TB_JOB_NAME
        '
        Me.TB_JOB_NAME.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_JOB_NAME.Location = New System.Drawing.Point(296, 47)
        Me.TB_JOB_NAME.Name = "TB_JOB_NAME"
        Me.TB_JOB_NAME.Size = New System.Drawing.Size(200, 23)
        Me.TB_JOB_NAME.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(208, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Job_Name"
        '
        'TB_JOB_DESC
        '
        Me.TB_JOB_DESC.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB_JOB_DESC.Location = New System.Drawing.Point(296, 75)
        Me.TB_JOB_DESC.Name = "TB_JOB_DESC"
        Me.TB_JOB_DESC.Size = New System.Drawing.Size(200, 23)
        Me.TB_JOB_DESC.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(208, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Job_Desc"
        '
        'CB_JOB_ACT
        '
        Me.CB_JOB_ACT.AutoSize = True
        Me.CB_JOB_ACT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB_JOB_ACT.Location = New System.Drawing.Point(296, 104)
        Me.CB_JOB_ACT.Name = "CB_JOB_ACT"
        Me.CB_JOB_ACT.Size = New System.Drawing.Size(92, 24)
        Me.CB_JOB_ACT.TabIndex = 13
        Me.CB_JOB_ACT.Text = "是否生效"
        Me.CB_JOB_ACT.UseVisualStyleBackColor = True
        '
        'Job_Desc
        '
        Me.ClientSize = New System.Drawing.Size(603, 477)
        Me.Controls.Add(Me.CB_JOB_ACT)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TB_JOB_DESC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_JOB_NAME)
        Me.Controls.Add(Me.BT_JOB_Del)
        Me.Controls.Add(Me.BT_Job_Modify)
        Me.Controls.Add(Me.BT_Job_Create)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BT_JOB_GetData)
        Me.Controls.Add(Me.BT_JOB_Main)
        Me.Controls.Add(Me.DGV_Job)
        Me.Name = "Job_Desc"
        CType(Me.DGV_Job, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Job As System.Windows.Forms.DataGridView
    Friend WithEvents BT_JOB_Main As System.Windows.Forms.Button
    Friend WithEvents BT_JOB_GetData As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BT_Job_Create As System.Windows.Forms.Button
    Friend WithEvents BT_Job_Modify As System.Windows.Forms.Button
    Friend WithEvents BT_JOB_Del As System.Windows.Forms.Button
    Friend WithEvents TB_JOB_NAME As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_JOB_DESC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CB_JOB_ACT As System.Windows.Forms.CheckBox

End Class
