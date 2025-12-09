Public Class RPT_Shift_Indices

    Private Sub BT_RPT_INDICES_GETDATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RPT_INDICES_GETDATA.Click
        Call GetDATA()
    End Sub
    Public Sub GetDATA()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = " select Dept_Desc,Certify_Grade,count(1) as Certify_Itm, DL_NO,format((Count(1)/DL_NO),'#0.00') as Ratio from "
        strSQL &= "(Select Distinct Certify_ID,EMP_ID, Active from training_Record where Active=True and Cer_type <> '3') A, "
        strSQL &= " (Select * from Basic where Active= true) B , "
        strSQL &= " L_Section C, "
        strSQL &= " (Select Area as Area_B,Dept_Code,count(1) as DL_NO from Basic  where Active=true Group by Area,Dept_Code) D, "
        strSQL &= " (Select Certify_ID,Certify_Grade from certify_items where Active =true and Certify_Type <> '訓練項目' ) E "
        strSQL &= " where(A.EMP_ID = B.EMP_ID And B.Dept_Code = C.Dept_Code) "
        strSQL &= " and B.Dept_Code = D.Dept_Code  and B.Area=D.Area_B "
        strSQL &= " and A.Certify_ID=E.Certify_ID and B.Area=E.Certify_Grade "
        strSQL &= " Group by Dept_Desc,DL_NO,Certify_Grade order by Dept_Desc,Certify_Grade; "
        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_RPT_Indices.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub RPT_Shift_Indices_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_RPT_Indices.Height = Me.Height - 120
        DGV_RPT_Indices.Width = Me.Width - 20
    End Sub

    Private Sub BT_RPT_INDEX_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RPT_INDEX_Export.Click
        'Call Excel_Export(DGV_RPT_Indices)
        Call DATAGRIDVIEW_TO_EXCEL(DGV_RPT_Indices)
    End Sub

    Sub GetData_Detail()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = " select A.EMP_ID,C_NAME,C.DEPT_Desc,B.AREA,format(Area_date,'yyyy/mm/dd') as 區域日期,A.Certify_ID,Certify_Name,Certify_Grade,A.Active,A.update_date from "
        strSQL &= " (Select Distinct Certify_ID,EMP_ID, Active,update_date from training_Record where Active=True and Cer_type <> '3' ) A, "
        strSQL &= " (Select * from Basic where Active= true) B ,  "
        strSQL &= " L_Section C, "
        strSQL &= " (Select Area as Area_B,Dept_Code,count(1) as DL_NO from Basic  where Active=true Group by Area,Dept_Code) D, "
        strSQL &= " (Select * from certify_items where Active =true and Certify_Type <> '訓練項目') E "
        strSQL &= " where(A.EMP_ID = B.EMP_ID And B.Dept_Code = C.Dept_Code) "
        strSQL &= " and B.Dept_Code = D.Dept_Code  and B.Area=D.Area_B "
        strSQL &= " and A.Certify_ID=E.Certify_ID and B.Area=E.Certify_Grade ;"
        'strSQL &= " Group by Dept_Desc,DL_NO,Certify_Grade order by Dept_Desc,Certify_Grade; "
        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_RPT_Indices.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub BT_GetDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GetDetail.Click
        Call GetData_Detail()
    End Sub

    Private Sub RPT_Shift_Indices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub
End Class