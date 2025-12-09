Public Class RPT_Newadd

    Private Sub RPT_Newadd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

        TB_NewAdd_Date.Text = "2014/04/01"
    End Sub

    Sub GetData()
        Dim strSQL As String
        Dim objDataset As DataSet
        Dim Date_Index As String

        Date_Index = TB_NewAdd_Date.Text


        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID as 工號, C_NAME as 姓名,D.Dept_Desc as 單位, A.Certify_ID as 認證ID,Certify_Name as 認證名稱,trim(B.Certify_Grade) as 認證區域,Score as 認證分數, "
        strSQL &= " Certify_date2 as 認證日期,datediff(now(),certify_date2) as 認證經過日期, A.ACtive as 有效 "
        strSQL &= " ,case Cer_type when '1' then '新認證' else '重新認證' end  as 認証種類, "
        strSQL &= " C.area as 目前工作區, E.Certify_Area as 定義工作區 "
        strSQL &= "from (select EMP_ID,Certify_ID,cer_type,Min(Certify_date) as certify_date2,active from Training_Record "
        strSQL &= " Where Cer_type = '1' "
        strSQL &= " group by EMP_ID,Certify_ID,cer_type,active ) A, "
        strSQL &= " (select * from Certify_items where active = true and certify_type <>'訓練項目') B, "
        strSQL &= " L_Section D, "
        strSQL &= " (select * from Basic where Active=true) C , TE_LOCATION E "
        strSQL &= " where(C.EMP_ID = A.EMP_ID And Trim(B.Certify_ID) = Trim(A.Certify_ID)) and E.EMP_ID=A.EMP_ID "
        strSQL &= " and A.active =true and trim(C.Dept_Code) = trim(D.dept_Code)  and B.active=true and "
        strSQL &= " C.active = True and Certify_date2 >= date_format('" & Date_Index & "','%Y/%m/%d') "
        strSQL &= " order by A.EMP_ID, A.Certify_ID;"

        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_NewAdd.DataSource = objDataset.Tables(0)
    End Sub


    Private Sub RPT_Person_certify_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_NewAdd.Height = Me.Height - 130
        DGV_NewAdd.Width = Me.Width - 20
    End Sub

    Private Sub BT_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Export.Click
        'Call Excel_Export(DGV_NewAdd)
        Call DATAGRIDVIEW_TO_EXCEL(DGV_NewAdd)

    End Sub

    Private Sub BT_NewAdd_Certify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_NewAdd_Certify.Click
        Call GetData()
    End Sub
End Class