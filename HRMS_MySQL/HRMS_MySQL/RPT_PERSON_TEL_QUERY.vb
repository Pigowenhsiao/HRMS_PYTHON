Public Class RPT_PERSON_TEL_QUERY

    Private Sub BT_RPT_INDICES_GETDATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RPT_TEL_GETDATA.Click
        Call GetDATA()
    End Sub

    Public Sub GetDATA()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "select A.EMP_ID as 工號,C_NAme as 姓名, Dept_Name as 課別,Sex as 性別, format(Birthday,'mm') as 生日月,Home_Phone as 住家電話,Current_phone as 目前電話,"
        strSQL &= "Cell_phone as 行動電話,Living_place as 居住地,living_place2 as 居住地2, EMG_NAME1 as 緊急聯絡人1,EMG_PHONE1 as 緊急連絡人1電話, "
        strSQL &= " EMG_RELEASION1 as 關係, EMG_NAME2 as 緊急連絡人2, EMG_PHONE2 as 緊急連絡人2電話, EMG_RELEASION2 as 關係2, "
        strSQL &= "Perf_year as 專業年資,excomp_year as 前公司年資,ex_compy_type as 前公司型態,A.Meno as 備註,a.active as 是否有效 "
        strSQL &= " from Person_Info A, Basic B, L_Section C"
        strSQL &= " where A.EMP_ID=B.EMP_ID and B.Dept_Code=C.Dept_Code  "

        If Trim(TB_TEL_NAME.Text) <> "" Then
            strSQL &= " and C_NAME='" & Trim(TB_TEL_NAME.Text) & "'"
        End If


        strSQL &= " order by A.EMP_ID "

        objDataset = DATA_ReadF(strSQL, "BASIC")


        DGV_RPT_TEL.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub RPT_PERSON_TEL_QUERY_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_RPT_TEL.Height = Me.Height - 110
        DGV_RPT_TEL.Width = Me.Width - 20
    End Sub

    Private Sub RPT_PERSON_TEL_QUERY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub
End Class