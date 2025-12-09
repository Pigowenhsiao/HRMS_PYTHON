Public Class CF_Report

    Private Sub BT_CF_OverDue_Getdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CF_OverDue_Getdata.Click
        Call GetData()
    End Sub


    Sub GetData()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID as 工號, C_NAME as 姓名,D.Dept_Desc as 單位, A.Certify_ID as 認證ID,Certify_Name as 認證名稱,"
        strSQL &= " Certify_date as 認證日期,int(now-certify_date) as 認證經過日期, A.ACtive as 有效 "
        strSQL &= " from Training_Record A, "
        strSQL &= " Certify_items B, "
        strSQL &= " L_Section D, "
        strSQL &= " Basic C "
        strSQL &= " where(C.EMP_ID = A.EMP_ID And Trim(B.Certify_ID) = Trim(A.Certify_ID)) "
        strSQL &= " and A.active =true and trim(C.Dept_Code) = trim(D.dept_Code)  and B.active=true and "
        strSQL &= " C.active=true and D.Dept_Code ='" & Mid(CB_SHIFT.Text, 1, 6) & "'"
        strSQL &= " order by A.EMP_ID, A.Certify_ID;"


        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_CF_OverDue.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub CF_Check_OverDue_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_CF_OverDue.Height = Me.Height - 130
        DGV_CF_OverDue.Width = Me.Width - 20
    End Sub

    Private Sub BT_CF_OverDue_Special_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CF_OverDue_Special.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        If TB_CF_OverDue_Secial.Text = "" Then TB_CF_OverDue_Secial.Text = "0"

        Call mDB_Link()
        strSQL = ""
        strSQL = "select A.EMP_ID as 工號, C_NAME as 姓名,D.Dept_Desc as 單位, A.Certify_ID as 認證ID,Certify_Name as 認證名稱,"
        strSQL &= " Certify_date as 認證日期,int(now-certify_date) as 認證經過日期,A.Active "
        strSQL &= " from Training_Record A, "
        strSQL &= " L_Section D, "
        strSQL &= " Certify_items B, "
        strSQL &= " Basic C "
        strSQL &= " where(C.EMP_ID = A.EMP_ID And Trim(B.Certify_ID) = Trim(A.Certify_ID)) and D.Dept_Code ='" & Mid(CB_SHIFT.Text, 1, 6) & "' "
        strSQL &= " and B.active=true and C.active=true and trim(C.Dept_Code) = trim(D.dept_Code) "
        strSQL &= "  and int(now-certify_date) >=" & Trim(TB_CF_OverDue_Secial.Text) & ""
        strSQL &= " order by int(now-certify_date) Desc;"

        'MsgBox(strSQL)
        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_CF_OverDue.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub CF_Check_OverDue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        TB_CF_OverDue_Secial.Text = "660"

        strSQL = ""
        strSQL = "select trim(Dept_Code) + ', ' + trim(dept_Desc) from L_section"

        Item_Update(CB_SHIFT, strSQL)

    End Sub
End Class