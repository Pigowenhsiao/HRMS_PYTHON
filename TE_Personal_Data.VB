Public Class TE_Personal_Data

    Private Sub Personal_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim StrSQL As String
        Dim objDataSet As DataSet


        Call mDB_Link()

        StrSQL = ""
        StrSQL = "select A.EMP_ID as 工號,C_NAme as 姓名, Sex as 性別,Format(Birthday,'yyyy/mm/dd') as 生日,  Home_Phone as 住家電話,Current_phone as 目前電話,"
        StrSQL &= "Cell_phone as 行動電話,Living_place as 居住地,living_place2 as 居住地2, EMG_NAME1 as 緊急聯絡人1,EMG_PHONE1 as 緊急連絡人1電話, "
        StrSQL &= " EMG_RELEASION1 as 關係, EMG_NAME2 as 緊急連絡人2, EMG_PHONE2 as 緊急連絡人2電話, EMG_RELEASION2 as 關係2, "
        StrSQL &= "Perf_year as 專業年資,excomp_year as 前公司年資,ex_compy_type as 前公司型態,A.Meno as 備註,a.active as 是否有效 "
        StrSQL &= " from Person_Info A, Basic B"
        StrSQL &= " where A.EMP_ID=B.EMP_ID and A.Active = True order by A.EMP_ID"

        objDataSet = DATA_ReadF(StrSQL, "BASIC")
        DGV_PBASIC.DataSource = objDataSet.Tables(0)

    End Sub


    Private Sub Personal_Data_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_PBASIC.Height = Me.Height - 110
        DGV_PBASIC.Width = Me.Width - 20
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


End Class