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
        strSQL = "select A.EMP_ID, A.Dept_Code, C_Name,On_Board_Date,Area,B.Certify_ID,C.Certify_name,"
        strSQL &= " B.Certify_date,C.Certify_Grade,C.Certify_type,C.active ,B.Remark, Certify_No, int(now-certify_date) as 已過幾日"
        strSQL &= " from Basic A, Training_record B, Certify_items C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID) "
        strSQL &= " and B.Certify_ID=C.Certify_ID "
        strSQL &= " and A.active =true "
        strSQL &= " and B.active =true "
        strSQL &= " and c.active =true "
        strSQL &= " order by (A.EMP_ID) "


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

        LB_Certify_Record_CName.Text = DATA_ReadS(strSQL)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub
    Private Sub CF_Certify_Record_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim User_check As String
        On Error GoTo Err_Handle
        strSQL = ""
        strSQL = " select distinct trim(EMP_ID) from BASIC where active =true order by trim(EMP_ID) "

        Item_Update(CB_Certify_Record_ID, strSQL)

        strSQL = ""
        strSQL = " select distinct trim(Certify_ID) from Certify_items where active =true order by trim(Certify_ID) "

        Item_Update(CB_Certify_Record_CID, strSQL)


        strSQL = ""
        strSQL = "select S_Account from Authority where Active = true and S_Account ='" & Environment.UserName & "'"

        User_check = DATA_ReadS(strSQL)

        If User_check <> Environment.UserName Then
            BT_Certify_Record_Create.Visible = False
            BT_Certify_Record_Modify.Visible = False
            BT_Certify_Record_Modify.Visible = False
        Else
            BT_Certify_Record_Create.Visible = True
            BT_Certify_Record_Modify.Visible = True
            BT_Certify_Record_Modify.Visible = True
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


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_Record.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub DGV_Certify_Record_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Certify_Record.MouseClick

        On Error GoTo Err_Handle
        CB_Certify_Record_ID.Text = DGV_Certify_Record.CurrentRow.Cells(0).Value.ToString
        TB_Certify_Record_Date.Text = Format(DGV_Certify_Record.CurrentRow.Cells(7).Value, "yyyy/MM/dd")
        CB_Certify_Record_CID.Text = DGV_Certify_Record.CurrentRow.Cells(5).Value.ToString
        CB_Certify_Record_Active.Checked = DGV_Certify_Record.CurrentRow.Cells(10).Value
        TB_Certify_Record_Remark.Text = DGV_Certify_Record.CurrentRow.Cells(11).Value.ToString
        LB_Certify_No.Text = DGV_Certify_Record.CurrentRow.Cells(12).Value.ToString


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
        strSQL = "select A.EMP_ID, A.Dept_Code, C_Name,On_Board_Date,Area,B.Certify_ID,C.Certify_name,"
        strSQL &= " B.Certify_date,C.Certify_Grade,C.Certify_type,C.active,B.Remark ,Certify_No"
        strSQL &= " from Basic A, Training_record B, Certify_items C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID) "
        strSQL &= " and B.Certify_ID=C.Certify_ID "
        strSQL &= " and A.active =true "
        strSQL &= " and B.active =true "
        strSQL &= " and c.active =true "
        strSQL &= " and A.EMP_ID = '" & Trim(CB_Certify_Record_ID.Text) & "'"
        strSQL &= " order by (A.EMP_ID) "


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_Record.DataSource = objDataset.Tables(0)

        CB_Certify_Record_ID.Text = DGV_Certify_Record.CurrentRow.Cells(0).Value.ToString
        TB_Certify_Record_Date.Text = Format(DGV_Certify_Record.CurrentRow.Cells(7).Value, "yyyy/MM/dd")
        CB_Certify_Record_CID.Text = DGV_Certify_Record.CurrentRow.Cells(5).Value.ToString
        CB_Certify_Record_Active.Checked = DGV_Certify_Record.CurrentRow.Cells(10).Value
        TB_Certify_Record_Remark.Text = DGV_Certify_Record.CurrentRow.Cells(11).Value.ToString
        LB_Certify_No.Text = DGV_Certify_Record.CurrentRow.Cells(12).Value.ToString


        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub


    Private Sub BT_Certify_record_CIDQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_record_CIDQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID, A.Dept_Code, C_Name,On_Board_Date,Area,B.Certify_ID,C.Certify_name,"
        strSQL &= " B.Certify_date,C.Certify_Grade,C.Certify_type,C.active,B.Remark,certify_No "
        strSQL &= " from Basic A, Training_record B, Certify_items C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID) "
        strSQL &= " and B.Certify_ID=C.Certify_ID "
        strSQL &= " and A.active =true "
        strSQL &= " and B.active =true "
        strSQL &= " and c.active =true "
        strSQL &= " and C.Certify_ID = '" & Trim(CB_Certify_Record_CID.Text) & "'"
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

        On Error GoTo Err_Handle

        Call mDB_Link()
        strSQL = "select top 1 Certify_No+1 from training_record order by Certify_NO desc"
        Certify_NO = DATA_ReadS(strSQL)
        'MsgBox(Certify_NO)

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into Training_Record (EMP_ID,Certify_ID,Certify_Date,Certify_Type,Update_date,Remark,Active,updater,certify_NO) "
        strSQL &= " values ('" & Trim(CB_Certify_Record_ID.Text) & "','" & Trim(CB_Certify_Record_CID.Text) & "','" & Trim(TB_Certify_Record_Date.Text) & "','"
        strSQL &= "內訓','" & Format(Now, "yyyy/MM/dd") & "','" & Trim(TB_Certify_Record_Remark.Text) & "'," & CB_Certify_Record_Active.Checked & ",'" & Environment.UserName & "'," & Certify_NO & ")"

        If MsgBox("請問確定要新增工號=" & Trim(CB_Certify_Record_ID.Text) & ", Certify ID=" & Trim(CB_Certify_Record_CID.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
        strSQL &= " A.Certify_ID ='" & Trim(CB_Certify_Record_CID.Text) & "'"
        strSQL &= " order by Certify_date; "

        Call Export_CVS(strSQL, 1)


        Call GetData()
        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub

    Private Sub BT_Certify_Record_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Record_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String

        On Error GoTo Err_Handle
        Call mDB_Link()
        strSQL = ""
        strSQL &= "update Training_Record "
        strSQL &= "set Certify_ID='" & Trim(CB_Certify_Record_CID.Text) & "', "
        'strSQL &= " Certify_date = '" & Trim(TB_Certify_Record_Date.Text) & "',"
        strSQL &= " Remark = '" & Trim(TB_Certify_Record_Remark.Text) & "',"
        strSQL &= " Updater = '" & Trim(Environment.UserName) & "',"
        strSQL &= " Update_date = '" & Trim(Format(Now, "yyyy/MM/dd")) & "',"
        strSQL &= " Active=" & CB_Certify_Record_Active.Checked
        strSQL &= " where trim(Certify_ID)='" & Trim(CB_Certify_Record_CID.Text) & "' "
        strSQL &= " and EMP_ID = '" & Trim(CB_Certify_Record_ID.Text) & "' and Certify_NO = " & Trim(LB_Certify_No.Text)

        ' MsgBox(strSQL)

        If MsgBox("請問確定要修改工號=" & Trim(CB_Certify_Record_ID.Text) & ", Certify ID=" & Trim(CB_Certify_Record_CID.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
        strSQL &= " A.Certify_ID ='" & Trim(CB_Certify_Record_CID.Text) & "'"
        strSQL &= " order by Certify_date; "
        ' MsgBox(strSQL)
        Call Export_CVS(strSQL, 1)




        Call GetData()
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub
End Class