Public Class CF_Certify_Del

    Sub GetData()
        Dim strSQL As String
        Dim objDataset As DataSet
        On Error GoTo Err_Handle

        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID, trim(A.Dept_Code) as 班別, trim(C_Name) as 姓名,trim(On_Board_Date) as 到職日,trim(Area) as 區域,"
        strSQL &= " trim(C.Certify_ID1) as 認證ID, B.Certify_date as 認證日期,trim(C.Certify_Grade) as 認證區域, "
        strSQL &= " b.active as 是否有效,trim(C.Certify_type) as 認證類別,(B.Remark) as 備註,iif(B.Cer_type='1','新認證','重新認證') as 認証種類, Certify_No, int(now-certify_date) as 已過幾日 "
        strSQL &= " from Basic A,  "
        strSQL &= " Training_record B, "
        strSQL &= " (select  (trim(certify_id) + ' ' +trim(certify_name)) as Certify_ID1,Certify_Grade,Certify_type, active from Certify_items) C "
        strSQL &= " where(A.EMP_ID = B.EMP_ID)"
        strSQL &= " and B.Certify_ID=left(C.Certify_ID1,9) "
        strSQL &= " and A.active =true "
        'strSQL &= " and B.active =true "
        strSQL &= " and c.active =true "
        If Trim(TB_Certify_ID.Text) <> "" Then
            strSQL &= " and Certify_No=" & Trim(TB_Certify_ID.Text) & " "
        End If
        strSQL &= " order by (A.EMP_ID) ;"


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Certify_Data.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub



    Private Sub BT_Certify_ID_Q_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_ID_Q.Click
        Call GetData()
    End Sub


    Private Sub CF_Certify_Del_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_Certify_Data.Height = Me.Height - 102
        DGV_Certify_Data.Width = Me.Width - 20
    End Sub

    Private Sub BT_Certify_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Delete.Click
        Dim strSQL As String
        Dim INS_Result

        If Trim(TB_Certify_ID.Text) = "" Then
            MsgBox("未指定刪除Certify NO")
            Exit Sub
        End If

        Call mDB_Link()

        strSQL = ""

        strSQL = "delete from Training_Record where Certify_No=" & Trim(TB_Certify_ID.Text) & ""

        On Error GoTo Err_Handle


        If MsgBox("請問確定要刪除認証編號=" & Trim(TB_Certify_ID.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料已經修改")
        Else
            Exit Sub
        End If

Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub CF_Certify_Del_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String
        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If
    End Sub
End Class