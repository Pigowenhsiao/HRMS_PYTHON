Public Class CF_Certify_Tool_Map


    Private Sub BT_Certify_CTM_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_CTM_GetData.Click
        Call GetData()
    End Sub

    Sub GetData()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(A.Certify_ID) as Certify_ID,trim(Certify_Name) as Certify_Name, trim(Tool_id) as Tool_ID, "
        strSQL &= "  trim(A.Remark) as 備註,  A.Active"
        strSQL &= " from Certify_Tool_Map A, Certify_items B where A.Active =true "
        strSQL &= " and A.Certify_ID=B.Certify_ID order by trim(A.Certify_ID) "


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_CFTM.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub CF_Certify_Tool_Map_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        DGV_Certify_CFTM.Height = Me.Height - 250
        DGV_Certify_CFTM.Width = Me.Width - 20

    End Sub

    Private Sub BT_Certify_CTM_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_CTM_Close.Click

        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Private Sub CF_Certify_Tool_Map_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        strSQL = ""
        strSQL = " select distinct trim(Certify_ID) from Certify_items where active =true order by trim(Certify_ID) "

        Item_Update(CB_Certify_CTM_CertifyID, strSQL)




    End Sub

  
    Private Sub DGV_Certify_CFTM_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Certify_CFTM.MouseClick

        Dim CTM_ID, CTM_TOOLID, CTM_REMARK, CTM_NAME As String
        Dim CTM_active As Boolean

        CTM_ID = DGV_Certify_CFTM.CurrentRow.Cells(0).Value.ToString
        CTM_NAME = DGV_Certify_CFTM.CurrentRow.Cells(1).Value.ToString
        CTM_TOOLID = DGV_Certify_CFTM.CurrentRow.Cells(2).Value
        CTM_REMARK = DGV_Certify_CFTM.CurrentRow.Cells(3).Value.ToString
        CTM_active = DGV_Certify_CFTM.CurrentRow.Cells(4).Value

        CB_Certify_CTM_CertifyID.Text = CTM_ID
        TB_Certify_CTM_TOOLID.Text = CTM_TOOLID
        TB_Certify_CTM_Remark.Text = CTM_REMARK
        CB_Certify_CTM_Active.Checked = CTM_active
        LB_Certify_CTM_Name.Text = CTM_NAME
        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub

    Private Sub BT_Certify_CTM_TOOLIDQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_CTM_TOOLIDQ.Click

        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(A.Certify_ID) as Certify_ID,trim(Certify_Name) as Certify_Name, trim(Tool_id) as Tool_ID, "
        strSQL &= "  trim(A.Remark) as 備註,  A.Active"
        strSQL &= " from Certify_Tool_Map A, Certify_items B"
        strSQL &= " where A.Certify_ID=B.Certify_ID and A.active = true and TOOL_ID ='" & TB_Certify_CTM_TOOLID.Text & "' order by trim(A.Certify_ID)"


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_CFTM.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub BT_Certify_CTM_CertifyidQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_CTM_CertifyidQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(A.Certify_ID) as Certify_ID,trim(Certify_Name) as Certify_Name, trim(Tool_id) as Tool_ID, "
        strSQL &= "  trim(A.Remark) as 備註,  A.Active"
        strSQL &= " from Certify_Tool_Map A, Certify_items B where A.active = true and A.Certify_ID=B.Certify_ID "
        strSQL &= " and A.Certify_ID ='" & CB_Certify_CTM_CertifyID.Text & "' order by trim(A.Certify_ID)"


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_CFTM.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub BT_Certify_CTM_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_CTM_Create.Click
        Dim strSQL As String
        Dim INS_Result As String


        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into Certify_Tool_Map (Certify_ID,TOOL_ID,Update_Date,Remark,Active) "
        strSQL &= " values ('" & Trim(CB_Certify_CTM_CertifyID.Text) & "','" & Trim(TB_Certify_CTM_TOOLID.Text) & "','" & Format(Now, "yyyyMMdd") & "','"
        strSQL &= Trim(TB_Certify_CTM_Remark.Text) & "'," & CB_Certify_CTM_Active.Checked & ")"

        If MsgBox("請問確定要新增Certify ID=" & Trim(CB_Certify_CTM_CertifyID.Text) & ", Certify 名稱=" & Trim(TB_Certify_CTM_TOOLID.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經新增")
        Else
            Exit Sub

        End If



        Call GetData()
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub BT_Certify_CTM_Fail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_CTM_Fail.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(A.Certify_ID) as Certify_ID,trim(Certify_Name) as Certify_Name, trim(Tool_id) as Tool_ID, "
        strSQL &= "  trim(A.Remark) as 備註,  A.Active"
        strSQL &= " from Certify_Tool_Map A, Certify_items B where A.Active =False "
        strSQL &= " and A.Certify_ID=B.Certify_ID order by trim(A.Certify_ID) "


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_CFTM.DataSource = objDataset.Tables(0)


    End Sub

    Private Sub BT_Certify_CTM_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_CTM_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String

        On Error GoTo Err_Handle
        Call mDB_Link()
        strSQL = ""
        strSQL &= "update Certify_Tool_Map "
        strSQL &= "set Certify_ID='" & Trim(CB_Certify_CTM_CertifyID.Text) & "', "
        strSQL &= " Tool_ID = '" & Trim(TB_Certify_CTM_TOOLID.Text) & "',"
        strSQL &= " Remark = '" & Trim(TB_Certify_CTM_Remark.Text) & "',"
        strSQL &= " Update_date = '" & Trim(Format(Now, "yyyyMMdd")) & "',"
        strSQL &= " Active=" & CB_Certify_CTM_Active.Checked
        strSQL &= " where trim(Certify_ID)='" & Trim(CB_Certify_CTM_CertifyID.Text) & "' "
        strSQL &= " and Tool_ID = '" & Trim(TB_Certify_CTM_TOOLID.Text) & "'"

        If MsgBox("請問確定要修改Certify ID=" & Trim(CB_Certify_CTM_CertifyID.Text) & ", Certify Name=" & Trim(TB_Certify_CTM_TOOLID.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經修改")
        Else
            Exit Sub
        End If

        Call GetData()
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub
End Class