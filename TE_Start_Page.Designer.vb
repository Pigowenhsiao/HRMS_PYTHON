<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TE_Start_Page
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
        Me.BT_JOB = New System.Windows.Forms.Button
        Me.BT_AREA = New System.Windows.Forms.Button
        Me.BT_Shop = New System.Windows.Forms.Button
        Me.BT_Section = New System.Windows.Forms.Button
        Me.BT_TEB = New System.Windows.Forms.Button
        Me.BT_TEE = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BT_PBASIC = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BT_Certify_Report = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.BT_MESUPDATE = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.BT_Certify_Tool_Map = New System.Windows.Forms.Button
        Me.BT_Certify_Setting = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BT_Authority = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(354, 35)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TSMC SSL HRMS-工作類別"
        '
        'BT_JOB
        '
        Me.BT_JOB.Location = New System.Drawing.Point(6, 364)
        Me.BT_JOB.Name = "BT_JOB"
        Me.BT_JOB.Size = New System.Drawing.Size(225, 32)
        Me.BT_JOB.TabIndex = 4
        Me.BT_JOB.Text = "工作類別"
        Me.BT_JOB.UseVisualStyleBackColor = True
        Me.BT_JOB.Visible = False
        '
        'BT_AREA
        '
        Me.BT_AREA.Location = New System.Drawing.Point(6, 28)
        Me.BT_AREA.Name = "BT_AREA"
        Me.BT_AREA.Size = New System.Drawing.Size(225, 32)
        Me.BT_AREA.TabIndex = 5
        Me.BT_AREA.Text = "工作區域類別"
        Me.BT_AREA.UseVisualStyleBackColor = True
        '
        'BT_Shop
        '
        Me.BT_Shop.Location = New System.Drawing.Point(6, 402)
        Me.BT_Shop.Name = "BT_Shop"
        Me.BT_Shop.Size = New System.Drawing.Size(225, 32)
        Me.BT_Shop.TabIndex = 6
        Me.BT_Shop.Text = "Shop類別"
        Me.BT_Shop.UseVisualStyleBackColor = True
        Me.BT_Shop.Visible = False
        '
        'BT_Section
        '
        Me.BT_Section.Location = New System.Drawing.Point(6, 66)
        Me.BT_Section.Name = "BT_Section"
        Me.BT_Section.Size = New System.Drawing.Size(225, 32)
        Me.BT_Section.TabIndex = 7
        Me.BT_Section.Text = "Section 類別"
        Me.BT_Section.UseVisualStyleBackColor = True
        '
        'BT_TEB
        '
        Me.BT_TEB.Location = New System.Drawing.Point(6, 104)
        Me.BT_TEB.Name = "BT_TEB"
        Me.BT_TEB.Size = New System.Drawing.Size(225, 32)
        Me.BT_TEB.TabIndex = 8
        Me.BT_TEB.Text = "人員基本資料"
        Me.BT_TEB.UseVisualStyleBackColor = True
        '
        'BT_TEE
        '
        Me.BT_TEE.Location = New System.Drawing.Point(6, 142)
        Me.BT_TEE.Name = "BT_TEE"
        Me.BT_TEE.Size = New System.Drawing.Size(225, 32)
        Me.BT_TEE.TabIndex = 9
        Me.BT_TEE.Text = "學歷查詢作業"
        Me.BT_TEE.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BT_PBASIC)
        Me.GroupBox1.Controls.Add(Me.BT_JOB)
        Me.GroupBox1.Controls.Add(Me.BT_TEE)
        Me.GroupBox1.Controls.Add(Me.BT_AREA)
        Me.GroupBox1.Controls.Add(Me.BT_TEB)
        Me.GroupBox1.Controls.Add(Me.BT_Shop)
        Me.GroupBox1.Controls.Add(Me.BT_Section)
        Me.GroupBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(35, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 448)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "人員基本資料處理"
        '
        'BT_PBASIC
        '
        Me.BT_PBASIC.Location = New System.Drawing.Point(6, 180)
        Me.BT_PBASIC.Name = "BT_PBASIC"
        Me.BT_PBASIC.Size = New System.Drawing.Size(225, 32)
        Me.BT_PBASIC.TabIndex = 10
        Me.BT_PBASIC.Text = "個人資料維護作業"
        Me.BT_PBASIC.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BT_Certify_Report)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.BT_MESUPDATE)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.BT_Certify_Tool_Map)
        Me.GroupBox2.Controls.Add(Me.BT_Certify_Setting)
        Me.GroupBox2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(290, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(239, 448)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Certify 作業處理"
        '
        'BT_Certify_Report
        '
        Me.BT_Certify_Report.Location = New System.Drawing.Point(7, 219)
        Me.BT_Certify_Report.Name = "BT_Certify_Report"
        Me.BT_Certify_Report.Size = New System.Drawing.Size(225, 32)
        Me.BT_Certify_Report.TabIndex = 15
        Me.BT_Certify_Report.Text = "Certify Report"
        Me.BT_Certify_Report.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(7, 181)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(225, 32)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Certify 過期查詢"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'BT_MESUPDATE
        '
        Me.BT_MESUPDATE.Location = New System.Drawing.Point(7, 143)
        Me.BT_MESUPDATE.Name = "BT_MESUPDATE"
        Me.BT_MESUPDATE.Size = New System.Drawing.Size(225, 32)
        Me.BT_MESUPDATE.TabIndex = 13
        Me.BT_MESUPDATE.Text = "Certify 資料上傳MES 作業"
        Me.BT_MESUPDATE.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(8, 104)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(225, 32)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Certify Record 登錄"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BT_Certify_Tool_Map
        '
        Me.BT_Certify_Tool_Map.Location = New System.Drawing.Point(6, 66)
        Me.BT_Certify_Tool_Map.Name = "BT_Certify_Tool_Map"
        Me.BT_Certify_Tool_Map.Size = New System.Drawing.Size(225, 32)
        Me.BT_Certify_Tool_Map.TabIndex = 11
        Me.BT_Certify_Tool_Map.Text = "Certify Tool Mapping"
        Me.BT_Certify_Tool_Map.UseVisualStyleBackColor = True
        '
        'BT_Certify_Setting
        '
        Me.BT_Certify_Setting.Location = New System.Drawing.Point(6, 28)
        Me.BT_Certify_Setting.Name = "BT_Certify_Setting"
        Me.BT_Certify_Setting.Size = New System.Drawing.Size(225, 32)
        Me.BT_Certify_Setting.TabIndex = 10
        Me.BT_Certify_Setting.Text = "Certify Item"
        Me.BT_Certify_Setting.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(568, 498)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "TSMC SSL HRMS Create by C.W."
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BT_Authority)
        Me.GroupBox3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(539, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(241, 448)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "系統設定"
        '
        'BT_Authority
        '
        Me.BT_Authority.Location = New System.Drawing.Point(6, 28)
        Me.BT_Authority.Name = "BT_Authority"
        Me.BT_Authority.Size = New System.Drawing.Size(225, 32)
        Me.BT_Authority.TabIndex = 0
        Me.BT_Authority.Text = "帳號作業"
        Me.BT_Authority.UseVisualStyleBackColor = True
        '
        'TE_Start_Page
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 525)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "TE_Start_Page"
        Me.Text = "Start Page"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_JOB As System.Windows.Forms.Button
    Friend WithEvents BT_AREA As System.Windows.Forms.Button
    Friend WithEvents BT_Shop As System.Windows.Forms.Button
    Friend WithEvents BT_Section As System.Windows.Forms.Button
    Friend WithEvents BT_TEB As System.Windows.Forms.Button
    Friend WithEvents BT_TEE As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BT_Certify_Setting As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_Tool_Map As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BT_Authority As System.Windows.Forms.Button
    Friend WithEvents BT_MESUPDATE As System.Windows.Forms.Button
    Friend WithEvents BT_PBASIC As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents BT_Certify_Report As System.Windows.Forms.Button

End Class
