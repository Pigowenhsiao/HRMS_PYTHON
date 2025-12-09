Public Class RPT_Person_certify

    Private Sub BT_CF_OverDue_Getdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Person_Certify.Click
        Call GetData()
    End Sub
    Sub GetData()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        ' strSQL = ""
        ' strSQL = " select A.EMP_ID as 工號, trim(A.Dept_Code) as 班別, trim(C_Name) as 姓名,trim(On_Board_Date) as 到職日, "
        ' strSQL &= " trim(Area) as 區域,trim(C.Certify_ID2) as 認證ID, B.Certify_date2 as 認證日期,trim(C.Certify_Grade) as 認證區域, "
        ' strSQL &= " b.active as 是否有效, trim(C.Certify_type) as 認證類別, (C.Remark) as 備註, case B.Cer_type when '1' then '新認證' else '重新認證' end as 認証種類 , "
        ' strSQL &= " datediff(now(),certify_date2) as 已過幾日, E.Certify_Area as 定義工作區 "
        ' strSQL &= " from  "
        ' strSQL &= " (select * from Basic where active =true) A, "
        ' strSQL &= " (select EMP_ID,Certify_ID,cer_type,Max(Certify_date) as certify_date2,active from Training_Record where Active=true and Cer_type <> '3' "
        ' strSQL &= " group by EMP_ID,Certify_ID,cer_type,active) B, "
        ' strSQL &= " (select *,Certify_ID +' ' +Certify_Name as Certify_ID2 from Certify_items where active =true and Certify_type <>'訓練項目') C, "
        ' strSQL &= " L_Section D , TE_LOCATION E"
        ' strSQL &= " where(B.EMP_ID = A.EMP_ID And Trim(B.Certify_ID) = Trim(C.Certify_ID)) "
        ' strSQL &= " and trim(A.Dept_Code) = trim(D.dept_Code) and Trim(A.EMP_ID) = Trim(E.EMP_ID) "
        ' strSQL &= " order by A.EMP_ID, B.Certify_ID; "

        strSQL = ""
        strSQL = "select * from Certify_Record_View;"

        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Person_Certify.DataSource = objDataset.Tables(0)
    End Sub


    Private Sub RPT_Person_certify_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_Person_Certify.Height = Me.Height - 130
        DGV_Person_Certify.Width = Me.Width - 20
    End Sub

    Private Sub BT_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Export.Click
        'Call Excel_Export(DGV_Person_Certify)
        Call DATAGRIDVIEW_TO_EXCEL(DGV_Person_Certify)
    End Sub

    Private Sub RPT_Person_certify_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub
End Class