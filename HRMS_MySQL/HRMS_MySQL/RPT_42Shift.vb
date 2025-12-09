Public Class RPT_42Shift

    Private Sub BT_RPT_INDICES_GETDATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RPT_INDICES_GETDATA.Click
        Call GetDATA()
    End Sub
    Public Sub GetDATA()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "  select Trim(B.Dept_Desc) as 單位,trim(Area) as 工作區域, "
        strSQL &= " case when Title like '%技術員%' then '技術員'"
        strSQL &= "             when Title like '%組長%' then '組長' end as 身份別,trim(C_NAME) as 姓名,VAC_DESC "
        strSQL &= " from BaSIC A, "
        strSQL &= " L_Section B, "
        strSQL &= " VAC_TYPE C "
        strSQL &= " where(A.active = True And A.Dept_Code = B.Dept_Code And A.VAC_TYPE = C.VAC_ID) "
        strSQL &= " order by A.Dept_Code,Area,Title,EMP_ID ; "
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL = "  select Trim(B.Dept_Desc) as 單位,trim(Area) as 工作區域, "
        strSQL &= "           case when Title like '%技術員%' then '技術員'"
        strSQL &= "             when Title like '%組長%' then '組長' end as 身份別, Count(1) as 人數 "
        strSQL &= " from BaSIC A, "
        strSQL &= " L_Section B "
        strSQL &= " where(A.active = True And A.Dept_Code = B.Dept_Code) "
        strSQL &= " Group by  Trim(B.Dept_Desc),trim(Area),case when Title like '%技術員%' then '技術員'"
        strSQL &= "             when Title like '%組長%' then '組長' end ; "
        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_RPT_Indices.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub RPT_42Shift_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub
End Class