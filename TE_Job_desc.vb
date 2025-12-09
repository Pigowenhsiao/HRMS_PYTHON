Public Class TE_Job_desc

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_JOB_Main.Click
        Me.Close()
        TE_Start_Page.Show()
    End Sub


    Private Sub BT_JOB_GetData_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_JOB_GetData.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        Call mDB_Link()
        strSQL = "Select L_JOB as 工作類別,L_JOB_DESC as 工作定義,Active from L_Job"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "JOB")
        DGV_Job.DataSource = objDataset.Tables(0)

    End Sub


    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Job.MouseClick
        Dim Job, Job_desc As String
        Dim Job_active As Boolean

        Job = DGV_Job.CurrentRow.Cells(0).Value
        Job_desc = DGV_Job.CurrentRow.Cells(1).Value
        Job_active = DGV_Job.CurrentRow.Cells(2).Value


        TB_JOB_NAME.Text = Job
        TB_JOB_DESC.Text = Job_desc
        CB_JOB_ACT.Checked = Job_active
    End Sub


    Private Sub BT_Job_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Job_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL &= "update L_Job "
        strSQL &= "set L_job_desc='" & TB_JOB_DESC.Text & "', "
        strSQL &= " Active=" & CB_JOB_ACT.Checked
        strSQL &= " where L_JOB='" & TB_JOB_NAME.Text & "'"

        If MsgBox("請問確定要修改工作名稱=" & TB_JOB_NAME.Text & ", 工作描述=" & TB_JOB_DESC.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經修改")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select L_JOB as 工作類別,L_JOB_DESC as 工作定義,Active from L_Job"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "JOB")
        DGV_Job.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub BT_JOB_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_JOB_Del.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "delete from L_Job "
        strSQL &= " where L_JOB='" & TB_JOB_NAME.Text & "'"

        If MsgBox("請問確定要刪除工作名稱=" & TB_JOB_NAME.Text & ", 工作描述=" & TB_JOB_DESC.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經刪除")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select L_JOB as 工作類別,L_JOB_DESC as 工作定義,Active from L_Job"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "JOB")
        DGV_Job.DataSource = objDataset.Tables(0)


        Exit Sub

Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub

    Private Sub BT_Job_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Job_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into L_Job (L_Job,L_Job_DESC,Active) "
        strSQL &= " values ('" & TB_JOB_NAME.Text & "','" & TB_JOB_DESC.Text & "'," & CB_JOB_ACT.Checked & ")"

        If MsgBox("請問確定要新增工作名稱=" & TB_JOB_NAME.Text & ", 工作描述=" & TB_JOB_DESC.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經新增")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select L_JOB as 工作類別,L_JOB_DESC as 工作定義,Active from L_Job"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "JOB")
        DGV_Job.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub

    Private Sub TE_Job_desc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_Job.Height = Me.Height - 277
        DGV_Job.Width = Me.Width - 20
    End Sub
End Class
