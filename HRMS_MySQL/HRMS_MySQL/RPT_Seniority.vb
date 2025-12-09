Public Class RPT_Seniority


    Public Sub GetDATA()
        Dim strSQL As String
        Dim objDataset As New DataSet
        On Error GoTo Err_Handle

        Call mDB_Link()
        strSQL = ""
        strSQL = " select EMP_ID,trim(B.Dept_Desc) as 單位, trim(Area) as 工作區域,C_NAme as 姓名, "
        strSQL &= " date_format(on_Board_date_2,'%Y/%m/%d') as 到職日, "
        strSQL &= " date_format(Area_Date,'%Y/%m/%d') as 區域日期,  "
        strSQL &= " Round(datediff(now(),Area_Date)/30,2) as 區域月資歷, "
        strSQL &= " Round(datediff(now(),on_Board_date_2)/30,2) as 工作月資歷 "
        strSQL &= " from BASIC A, L_Section B "
        strSQL &= " where A.Dept_Code=B.Dept_Code and A.active = true "
        strSQL &= " order by EMP_ID; "

        objDataset = DATA_ReadF(strSQL, "Section")

        DGV_RPT_Indices.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub


    Private Sub BT_RPT_Seniority_GETDATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RPT_Seniority_GETDATA.Click
        Call GetDATA()
    End Sub

    Private Sub BT_RPT_INDEX_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RPT_INDEX_Export.Click

        'Call Excel_Export(DGV_RPT_Indices)
        Call DATAGRIDVIEW_TO_EXCEL(DGV_RPT_Indices)



    End Sub

    Private Sub RPT_Seniority_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_RPT_Indices.Height = Me.Height - 120
        DGV_RPT_Indices.Width = Me.Width - 20
    End Sub

    Private Sub RPT_Seniority_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub
End Class