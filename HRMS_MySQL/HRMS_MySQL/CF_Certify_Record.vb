Public Class CF_Certify_Record

    Private Sub BT_Certify_Record_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Record_GetData.Click
        Call GetData()
    End Sub

    Sub GetData()
        Dim strSQL As String
        Dim objDataset As DataSet
        On Error GoTo Err_Handle

        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID, trim(A.Dept_Code) as 班別, trim(C_Name) as 姓名,trim(On_Board_Date) as 到職日,trim(Area) as 區域,"
        strSQL &= " trim(C.Certify_ID1) as 認證ID, B.Certify_date as 認證日期,trim(C.Certify_Grade) as 認證區域, "
        strSQL &= " b.active as 是否有效,trim(C.Certify_type) as 認證類別,(B.Remark) as 備註,  "
        strSQL &= "  Case B.Cer_type when '1' then '新認證' when '2' then '重新認證' else '訓練' end as 認証種類, "
        strSQL &= " Certify_No, datediff(now(),certify_date) as 已過幾日,C.Score as 認證分數 "
        strSQL &= " from Basic A,  "
        strSQL &= " Training_record B, "
        strSQL &= " (select  (trim(certify_id)  & ' '  & trim(certify_name)) as Certify_ID1,Certify_Grade,Certify_type,active,Score from Certify_items) C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID)"
        strSQL &= " and B.Certify_ID=left(C.Certify_ID1,9) "
        strSQL &= " and A.active =true "
        strSQL &= " and B.active =true "
        strSQL &= " and c.active =true "
        strSQL &= " order by (A.EMP_ID) ;"


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_Record.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub BT_Certify_Record_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Record_close.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Private Sub CF_Certify_Record_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize


        DGV_Certify_Record.Height = Me.Height - 260
        DGV_Certify_Record.Width = Me.Width - 20


    End Sub


    Private Sub CB_Certify_Record_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Certify_Record_ID.SelectedIndexChanged
        Dim strSQL As String
        On Error GoTo Err_Handle
        strSQL = ""
        strSQL = " select distinct trim(C_Name) from Basic where active =true and Trim(EMP_ID) ='" & Trim(CB_Certify_Record_ID.Text) & "' "

        LB_Certify_Record_Name.Text = DATA_ReadS(strSQL)


        Call Index_Change()
        Exit Sub

Err_Handle:
        Call ABNormal()
    End Sub
    Private Sub CB_Certify_Record_CID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Certify_Record_CID.SelectedIndexChanged
        Dim strSQL As String

        On Error GoTo Err_Handle
        strSQL = ""
        strSQL = " select distinct trim(Certify_Name) from Certify_items where active =true and Trim(Certify_ID) ='" & Trim(CB_Certify_Record_CID.Text) & "' "

        'LB_Certify_Record_CName.Text = DATA_ReadS(strSQL)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub
    Private Sub CF_Certify_Record_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim User_check As String
        Dim objDataSet As DataSet
        Dim Version_check2, Auth_Type As String
        Dim Version_DB As String

        Version_DB = Version_check
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_check, MsgBoxStyle.OkOnly)
            Me.Close()
        End If

        On Error GoTo Err_Handle

        RB_Certify_New.Checked = True

        strSQL = ""
        strSQL = " select distinct trim(EMP_ID) from BASIC where active =true order by trim(EMP_ID) "

        Item_Update(CB_Certify_Record_ID, strSQL)

        strSQL = ""
        strSQL = " select distinct trim(Certify_ID) + ' '  +trim(certify_Name) from Certify_items where active =true order by trim(Certify_ID)+' ' +trim(certify_Name) "

        Item_Update(CB_Certify_Record_CID, strSQL)



        strSQL = ""
        strSQL = "select S_Account,Auth_type from Authority where Active = true and S_Account ='" & LCase(Environment.UserName) & "'"

        'Version_Check = DATA_ReadS(strSQL)
        objDataSet = DATA_ReadF(strSQL, "Authority")
        If (objDataSet.Tables(0).Rows.Count) <= 0 Then
            Version_check2 = ""
            Auth_type = ""
        Else
            Version_check2 = Trim(objDataSet.Tables(0).Rows(0)(0).ToString)
            Auth_type = Trim(objDataSet.Tables(0).Rows(0)(1).ToString)
        End If
        If Auth_Type = "02" Or Auth_Type = "01" Then
            BT_Certify_Record_Create.Visible = True
            BT_Certify_Record_Modify.Visible = True

        Else
            BT_Certify_Record_Create.Visible = False
            BT_Certify_Record_Modify.Visible = False


        End If

        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub

    Private Sub BT_Certify_Record_Fail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Record_Fail.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        On Error GoTo Err_Handle
        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID, A.Dept_Code, C_Name,On_Board_Date,Area,B.Certify_ID,C.Certify_name,"
        strSQL &= " B.Certify_date,C.Certify_Grade,C.Certify_type,B.Active,B.Remark,Certify_No "
        strSQL &= " from Basic A, Training_record B, Certify_items C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID) "
        strSQL &= " and B.Certify_ID=C.Certify_ID "
        strSQL &= " and B.active = False "
        strSQL &= " order by (A.EMP_ID) "

        strSQL = ""
        strSQL = "select A.EMP_ID, trim(A.Dept_Code) as 班別, trim(C_Name) as 姓名,trim(On_Board_Date) as 到職日,trim(Area) as 區域,"
        strSQL &= " trim(C.Certify_ID1) as 認證ID, B.Certify_date as 認證日期,trim(C.Certify_Grade) as 認證區域, "
        strSQL &= " b.active as 是否有效,trim(C.Certify_type) as 認證類別,(B.Remark) as 備註, iif(B.Cer_type='1','新認證',iif(B.Cer_type='2','重新認證','訓練')) as 認証種類, "
        strSQL &= " Certify_No, int(now-certify_date) as 已過幾日,C.Score as 認證分數 "
        strSQL &= " from Basic A,  "
        strSQL &= " Training_record B, "
        strSQL &= " (select  (trim(certify_id) + ' ' +trim(certify_name)) as Certify_ID1,Certify_Grade,Certify_type,active,Score from Certify_items) C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID)"
        strSQL &= " and B.Certify_ID=left(C.Certify_ID1,9) "
        strSQL &= " and A.active =true "
        strSQL &= " and B.active =False "
        strSQL &= " and c.active =true "
        strSQL &= " order by (A.EMP_ID) ;"


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_Record.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub DGV_Certify_Record_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Certify_Record.MouseClick

        On Error GoTo Err_Handle
        CB_Certify_Record_ID.Text = DGV_Certify_Record.CurrentRow.Cells(0).Value.ToString
        TB_Certify_Record_Date.Text = Format(DGV_Certify_Record.CurrentRow.Cells(6).Value, "yyyy/MM/dd")
        CB_Certify_Record_CID.Text = DGV_Certify_Record.CurrentRow.Cells(5).Value.ToString
        CB_Certify_Record_Active.Checked = DGV_Certify_Record.CurrentRow.Cells(8).Value
        TB_Certify_Record_Remark.Text = DGV_Certify_Record.CurrentRow.Cells(10).Value.ToString
        LB_Certify_No.Text = DGV_Certify_Record.CurrentRow.Cells(12).Value.ToString

        If DGV_Certify_Record.CurrentRow.Cells(11).Value = "新認證" Then RB_Certify_New.Checked = True
        If DGV_Certify_Record.CurrentRow.Cells(11).Value = "訓練" Then RB_Certify_Training.Checked = True
        If DGV_Certify_Record.CurrentRow.Cells(11).Value = "重新認證" Then RB_Certify_RE.Checked = True


        Call Index_Change()
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub BT_Certify_record_IDQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_record_IDQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        On Error GoTo Err_Handle
        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID, trim(A.Dept_Code) as 班別, trim(C_Name) as 姓名,trim(On_Board_Date) as 到職日,trim(Area) as 區域,"
        strSQL &= " trim(C.Certify_ID1) as 認證ID, B.Certify_date as 認證日期,trim(C.Certify_Grade) as 認證區域, "
        strSQL &= " b.active as 是否有效,trim(C.Certify_type) as 認證類別,(B.Remark) as 備註, iif(B.Cer_type='1','新認證',iif(B.Cer_type='2','重新認證','訓練')) as 認証種類, "
        strSQL &= " Certify_No, int(now-certify_date) as 已過幾日,C.Score as 認證分數 "
        strSQL &= " from Basic A,  "
        strSQL &= " Training_record B, "
        strSQL &= " (select  (trim(certify_id) + ' ' +trim(certify_name)) as Certify_ID1,Certify_Grade,Certify_type,score,active from Certify_items) C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID)"
        strSQL &= " and B.Certify_ID=left(C.Certify_ID1,9) "
        strSQL &= " and A.active =true "
        strSQL &= " and c.active =true "
        strSQL &= " and A.EMP_ID = '" & Trim(CB_Certify_Record_ID.Text) & "'"
        strSQL &= " order by (A.EMP_ID) "


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_Record.DataSource = objDataset.Tables(0)

        'MsgBox(DGV_Certify_Record.CurrentRow.Cells(6).Value)


        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub


    Private Sub BT_Certify_record_CIDQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_record_CIDQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID, trim(A.Dept_Code) as 班別, trim(C_Name) as 姓名,trim(On_Board_Date) as 到職日,trim(Area) as 區域,"
        strSQL &= " trim(C.Certify_ID1) as 認證ID, B.Certify_date as 認證日期,trim(C.Certify_Grade) as 認證區域, "
        strSQL &= " b.active as 是否有效,trim(C.Certify_type) as 認證類別,(B.Remark) as 備註, iif(B.Cer_type='1','新認證',iif(B.Cer_type='2','重新認證','訓練')) as 認証種類, "
        strSQL &= " Certify_No, int(now-certify_date) as 已過幾日,C.Score as 認證分數 "
        strSQL &= " from Basic A,  "
        strSQL &= " Training_record B, "
        strSQL &= " (select  Certify_id,(trim(certify_id) + ' ' +trim(certify_name)) as Certify_ID1,Certify_Grade,Certify_type,score,active from Certify_items) C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID)"
        strSQL &= " and B.Certify_ID=left(C.Certify_ID1,9) "
        strSQL &= " and A.active =true "
        strSQL &= " and c.active =true "
        strSQL &= " and C.Certify_ID = '" & Strings.Left(Trim(CB_Certify_Record_CID.Text), 9) & "'"
        strSQL &= " order by (A.EMP_ID) "


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_Record.DataSource = objDataset.Tables(0)
    End Sub

    Sub Index_Change()
        Dim strSQL As String

        strSQL = ""
        strSQL = " select distinct trim(Certify_Name) from Certify_items where active =true and Trim(Certify_ID) ='" & Trim(CB_Certify_Record_CID.Text) & "' "

        LB_Certify_Record_CName.Text = DATA_ReadS(strSQL)

    End Sub

    Private Sub BT_Certify_Record_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Record_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim Certify_NO As Single
        Dim EMP_Name As String
        Dim C_type As String


        On Error GoTo Err_Handle
        C_type = ""
        If RB_Certify_New.Checked = True Then C_type = "1"
        If RB_Certify_RE.Checked = True Then C_type = "2"
        If RB_Certify_Training.Checked = True Then C_type = "3"

        '取得最新編號
        Call mDB_Link()
        strSQL = "select top 1 Certify_No+1 from training_record order by Certify_NO desc"
        Certify_NO = DATA_ReadS(strSQL)
        'MsgBox(Certify_NO)

        '從工號找到姓名
        Call mDB_Link()
        strSQL = ""
        strSQL = "select C_NAME from Basic where EMP_ID='" & Trim(CB_Certify_Record_ID.Text) & "'"
        EMP_Name = DATA_ReadS(strSQL)

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into Training_Record (EMP_ID,Certify_ID,Certify_Date,Certify_Type,Update_date,Remark,Active,updater,certify_NO,cer_type) "
        strSQL &= " values ('" & Trim(CB_Certify_Record_ID.Text) & "','" & Strings.Left(Trim(CB_Certify_Record_CID.Text), 9) & "','" & Trim(TB_Certify_Record_Date.Text) & "','"
        strSQL &= "內訓','" & Format(Now, "yyyy/MM/dd") & "','" & Trim(TB_Certify_Record_Remark.Text) & "'," & CB_Certify_Record_Active.Checked & ",'" & Environment.UserName & "'," & Certify_NO & ",'" & C_type & "')"

        If MsgBox("請問確定要新增工號=" & Trim(CB_Certify_Record_ID.Text) & " " & EMP_Name & ", Certify ID=" & Trim(CB_Certify_Record_CID.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料已經新增")
        Else
            Exit Sub

        End If

        strSQL = ""
        strSQL = "select ('L' + EMP_ID) as user_ID, Tool_ID, IIF(Active = True , 'Y', 'N')  as Certification "
        strSQL &= "from "
        strSQL &= "(Select EMP_ID, Certify_ID,Certify_date,Active from Training_Record ) A, "
        strSQL &= "(select Certify_ID, Tool_ID from Certify_tool_MAP where active =true)  B "
        strSQL &= "where A.Certify_ID = B.Certify_id and A.EMP_ID = '" & Trim(CB_Certify_Record_ID.Text) & "' and "
        strSQL &= " A.Certify_ID ='" & Strings.Left(Trim(CB_Certify_Record_CID.Text), 9) & "' and format(Certify_date,'yyyy/MM/dd') = '" & Trim(TB_Certify_Record_Date.Text) & "' "
        strSQL &= " order by Certify_date; "

        'MsgBox(strSQL)

        Call Export_CVS(strSQL, 1)


        Call GetData()
        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub

    Private Sub BT_Certify_Record_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Record_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim EMP_Name As String
        Dim D_type As String

        On Error GoTo Err_Handle
        D_type = ""
        If RB_Certify_New.Checked = True Then D_type = "1"
        If RB_Certify_RE.Checked = True Then D_type = "2"
        If RB_Certify_Training.Checked = True Then D_type = "3"

        Call mDB_Link()
        strSQL = ""
        strSQL = "select C_NAME from Basic where EMP_ID='" & Trim(CB_Certify_Record_ID.Text) & "'"
        EMP_Name = DATA_ReadS(strSQL)


        Call mDB_Link()
        strSQL = ""
        strSQL &= " update Training_Record "
        strSQL &= " set Certify_ID='" & Strings.Left(Trim(CB_Certify_Record_CID.Text), 9) & "', "
        strSQL &= " Certify_date = #" & Trim(TB_Certify_Record_Date.Text) & "#,"
        strSQL &= " Remark = '" & Trim(TB_Certify_Record_Remark.Text) & "',"
        strSQL &= " Updater = '" & Trim(Environment.UserName) & "',"
        strSQL &= " Update_date = '" & Trim(Format(Now, "yyyy/MM/dd")) & "',"
        strSQL &= " Active=" & CB_Certify_Record_Active.Checked & ","
        strSQL &= " Cer_Type = '" & D_type & "'"
        strSQL &= " where trim(Certify_ID)='" & Strings.Left(Trim(CB_Certify_Record_CID.Text), 9) & "' "
        strSQL &= " and EMP_ID = '" & Trim(CB_Certify_Record_ID.Text) & "' and Certify_NO =" & Trim(LB_Certify_No.Text)

        'MsgBox(strSQL)

        If MsgBox("請問確定要修改工號=" & Trim(CB_Certify_Record_ID.Text) & " " & EMP_Name & ", Certify ID=" & Trim(CB_Certify_Record_CID.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料已經修改")
        Else
            Exit Sub
        End If

        strSQL = ""
        strSQL = "select ('L' + EMP_ID) as user_ID, Tool_ID, IIF(Active = True , 'Y', 'N')  as Certification "
        strSQL &= "from "
        strSQL &= "(Select EMP_ID, Certify_ID,Certify_date,Active from Training_Record ) A, "
        strSQL &= "(select Certify_ID, Tool_ID from Certify_tool_MAP where active =true)  B "
        strSQL &= "where A.Certify_ID = B.Certify_id and A.EMP_ID = '" & Trim(CB_Certify_Record_ID.Text) & "' and  "
        strSQL &= " A.Certify_ID ='" & Strings.Left(Trim(CB_Certify_Record_CID.Text), 9) & "'"
        strSQL &= " order by Certify_date; "
        ' MsgBox(strSQL)
        Call Export_CVS(strSQL, 1)




        Call GetData()
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Call Excel_Export(DGV_Certify_Record)
        Call DATAGRIDVIEW_TO_EXCEL(DGV_Certify_Record)

        Exit Sub

Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub
End Class