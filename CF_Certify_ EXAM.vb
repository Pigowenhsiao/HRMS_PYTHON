Public Class CF_Certify__EXAM

    Private Sub BT_CFEXAM_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CFEXAM_GetData.Click
        Call GetDATA()
    End Sub

    Public Sub GetDATA()
        Dim strSQL As String
        Dim objDataset As DataSet
        On Error GoTo Err_Handle
        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(Dept) as Dept, trim(Certify_id) as Certify_id, "
        strSQL &= " trim(certify_name) as Certify_Name, trim(certify_Time) as Certify_time, "
        strSQL &= " trim(certify_Grade) as Certify_Grade, Active,trim(certify_Type) as Certify_Type,trim(Remark) as 備註 "
        strSQL &= " from Certify_items where active = true"


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_CFEXAM.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub

    Private Sub CF_Certify__EXAM_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_CFEXAM.Height = Me.Height - 250
        DGV_CFEXAM.Width = Me.Width - 20
    End Sub

    Private Sub CF_Certify__EXAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String

        On Error GoTo Err_Handle

        strSQL = ""
        strSQL = " select trim(Area) from Area order by area"

        Item_Update(CB_Certify_Exam_Group, strSQL)

        strSQL = ""
        strSQL = " select trim(Certify_Type) from Certify_type order by Certify_type"

        Item_Update(CB_Certify_Exam_Type, strSQL)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub DGV_CFEXAM_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_CFEXAM.MouseClick
        Dim Certify_Exam_Dept, Certify_Exam_ID, Certify_Exam_Name, Certify_Exam_time, Certify_Exam_Grade, Certify_Exam_Type As String
        Dim Certify_Exam_active As Boolean

        On Error GoTo Err_Handle

        Certify_Exam_Dept = DGV_CFEXAM.CurrentRow.Cells(0).Value
        Certify_Exam_ID = DGV_CFEXAM.CurrentRow.Cells(1).Value
        Certify_Exam_Name = DGV_CFEXAM.CurrentRow.Cells(2).Value
        Certify_Exam_time = DGV_CFEXAM.CurrentRow.Cells(3).Value
        Certify_Exam_Grade = DGV_CFEXAM.CurrentRow.Cells(4).Value
        Certify_Exam_active = DGV_CFEXAM.CurrentRow.Cells(5).Value
        Certify_Exam_Type = DGV_CFEXAM.CurrentRow.Cells(6).Value.ToString


        TB_Certify_Exam_Dept.Text = Certify_Exam_Dept
        TB_Certify_EXAM_ID.Text = Certify_Exam_ID
        TB_Certify_Exam_Name.Text = Certify_Exam_Name
        TB_Certify_EXAM_Time.Text = Certify_Exam_time
        CB_Certify_Exam_Group.Text = Certify_Exam_Grade
        CB_CF_EXAM_Active.Checked = Certify_Exam_active
        CB_Certify_Exam_Type.Text = Certify_Exam_Type
        TB_Certify_Exam_Remark.Text = DGV_CFEXAM.CurrentRow.Cells(7).Value.ToString
        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub


    Private Sub BT_Certify_Exam_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Exam_Close.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CFEXAM_FailData.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()
        strSQL = "Select trim(Dept) as Dept, trim(Certify_id) as Certify_id, "
        strSQL &= " trim(certify_name) as Certify_Name, trim(certify_Time) as Certify_time, "
        strSQL &= " trim(certify_Grade) as Certify_Grade, Active,trim(certify_Type) as Certify_Type,trim(Remark) as 備註 "
        strSQL &= " from Certify_items where Active=false order by Certify_ID"
        'strSQL = "Select * from TE_EDU A, BASIC B where A.EMP_ID=B.EMP_ID order by A.EMP_ID"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_CFEXAM.DataSource = objDataset.Tables(0)

        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub

    Private Sub BT_CFEXAM_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CFEXAM_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String

        On Error GoTo Err_Handle

        Call mDB_Link()
        strSQL = ""
        strSQL &= "update Certify_items "
        strSQL &= "set Dept='" & Trim(TB_Certify_Exam_Dept.Text) & "', "
        strSQL &= " Certify_name = '" & Trim(TB_Certify_Exam_Name.Text) & "',"
        strSQL &= " Certify_time = '" & Trim(TB_Certify_EXAM_Time.Text) & "',"
        strSQL &= " Certify_Grade = '" & Trim(CB_Certify_Exam_Group.Text) & "',"
        strSQL &= " Remark = '" & Trim(TB_Certify_Exam_Remark.Text) & "',"
        strSQL &= " Certify_Type = '" & Trim(CB_Certify_Exam_Type.Text) & "',"
        strSQL &= " Active=" & CB_CF_EXAM_Active.Checked
        strSQL &= " where trim(Certify_ID)='" & Trim(TB_Certify_EXAM_ID.Text) & "'"

        If MsgBox("請問確定要修改Certify ID=" & TB_Certify_EXAM_ID.Text & ", Certify Name=" & TB_Certify_Exam_Name.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料已經修改")
        Else
            Exit Sub
        End If

        Call GetDATA()
        Exit Sub
Err_Handle:
        Call ABnormal()
    End Sub

    Private Sub BT_Certify_Exam_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Exam_Create.Click
        Dim strSQL As String
        Dim INS_Result As String


        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into Certify_items (Dept,Certify_ID,Certify_name,Certify_Grade,Certify_Type,Active,Remark) "
        strSQL &= " values ('" & Trim(TB_Certify_Exam_Dept.Text) & "','" & Trim(TB_Certify_EXAM_ID.Text) & "'," & Trim(TB_Certify_Exam_Name.Text) & "',"
        strSQL &= Trim(CB_Certify_Exam_Group.Text) & " '," & Trim(CB_Certify_Exam_Type.Text) & "'," & CB_CF_EXAM_Active.Checked & ",'"
        strSQL &= TB_Certify_Exam_Remark.Text & "')"

        If MsgBox("請問確定要新增Certify ID=" & TB_Certify_EXAM_ID.Text & ", Certify 名稱=" & TB_Certify_Exam_Name.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料已經新增")
        Else
            Exit Sub

        End If



        Call GetDATA()
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub
End Class