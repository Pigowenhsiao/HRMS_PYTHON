Public Class TE_Personal_INFO


    Private Sub TE_Personal_INFO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        strSQL = ""
        strSQL = " select EMP_ID  from BASIC where active = true order by EMP_ID"
        Item_Update(CB_PBASIC_EMP_ID, strSQL)

    End Sub


    Private Sub CB_PBASIC_EMP_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_PBASIC_EMP_ID.SelectedIndexChanged
        Dim strSQL, INS_Result As String
        Dim objDataSet As DataSet
        On Error GoTo Err_Handle

        strSQL = ""
        strSQL = "select C_NAme from Basic where EMP_ID ='" & CB_PBASIC_EMP_ID.Text & "'"
        Call mDB_Link()
        LB_PBASIC_NAME.Text = ""
        LB_PBASIC_NAME.Text = DATA_ReadS(strSQL)

        strSQL = ""
        strSQL = "select Sex,Format(Birthday,'yyyy/mm/dd'), Personal_ID, Home_Phone,Current_phone,"
        strSQL &= "Cell_phone,Living_place,living_place2, EMG_NAME1,EMG_PHONE1,EMG_RELEASION1,EMG_NAME2,EMG_PHONE2,EMG_RELEASION2,"
        strSQL &= "Perf_year,excomp_year,ex_compy_type,Meno,active"
        strSQL &= " from Person_Info where EMP_ID ='" & CB_PBASIC_EMP_ID.Text & "'"

        objDataSet = DATA_ReadF(strSQL, "Person_Info")

        If Trim(objDataSet.Tables(0).Rows(0)(0)) = "F" Then
            RB_PBASIC_F.Checked = True
        Else
            RB_PBASIC_M.Checked = True
        End If

        TB_PBASIC_Birthday.Text = Trim(objDataSet.Tables(0).Rows(0)(1).ToString)
        TB_PBASIC_ID.Text = Trim(objDataSet.Tables(0).Rows(0)(2).ToString)
        TB_PBASIC_HOMEPHONE.Text = Trim(objDataSet.Tables(0).Rows(0)(3).ToString)
        TB_PBASIC_CURRENTPHONE.Text = Trim(objDataSet.Tables(0).Rows(0)(4).ToString)
        TB_PBASIC_CELLPHONE.Text = Trim(objDataSet.Tables(0).Rows(0)(5).ToString)
        TB_PBASIC_Livingplace.Text = Trim(objDataSet.Tables(0).Rows(0)(6).ToString)
        TB_PBASIC_Livingplace2.Text = Trim(objDataSet.Tables(0).Rows(0)(7).ToString)
        TB_PBASIC_EMG_NAME1.Text = Trim(objDataSet.Tables(0).Rows(0)(8).ToString)
        TB_PBASIC_EMG_PHONE1.Text = Trim(objDataSet.Tables(0).Rows(0)(9).ToString)
        TB_PBASIC_EMG_RELEASION1.Text = Trim(objDataSet.Tables(0).Rows(0)(10).ToString)
        TB_PBASIC_EMG_NAME2.Text = Trim(objDataSet.Tables(0).Rows(0)(11).ToString)
        TB_PBASIC_EMG_PHONE2.Text = Trim(objDataSet.Tables(0).Rows(0)(12).ToString)
        TB_PBASIC_EMG_RELEASION2.Text = Trim(objDataSet.Tables(0).Rows(0)(13).ToString)
        TB_PBASIC_PREF_YEAR.Text = Trim(objDataSet.Tables(0).Rows(0)(14).ToString)
        TB_PBASIC_EXCOMPY_YEAR.Text = Trim(objDataSet.Tables(0).Rows(0)(15).ToString)
        TB_PBASIC_EXCOMPY_TYPE.Text = Trim(objDataSet.Tables(0).Rows(0)(16).ToString)
        TB_PBASIC_MENO.Text = Trim(objDataSet.Tables(0).Rows(0)(17).ToString)
        CB_PBASIC_ACTIVE.Checked = Trim(objDataSet.Tables(0).Rows(0)(18).ToString)

        Exit Sub
Err_Handle:
        MsgBox("找不到資料,應該是新人")
        TB_PBASIC_Birthday.Text = ""
        TB_PBASIC_ID.Text = ""
        TB_PBASIC_HOMEPHONE.Text = ""
        TB_PBASIC_CURRENTPHONE.Text = ""
        TB_PBASIC_CELLPHONE.Text = ""
        TB_PBASIC_Livingplace.Text = ""
        TB_PBASIC_Livingplace2.Text = ""
        TB_PBASIC_EMG_NAME1.Text = ""
        TB_PBASIC_EMG_PHONE1.Text = ""
        TB_PBASIC_EMG_RELEASION1.Text = ""
        TB_PBASIC_EMG_NAME2.Text = ""
        TB_PBASIC_EMG_PHONE2.Text = ""
        TB_PBASIC_EMG_RELEASION2.Text = ""
        TB_PBASIC_PREF_YEAR.Text = ""
        TB_PBASIC_EXCOMPY_YEAR.Text = ""
        TB_PBASIC_EXCOMPY_TYPE.Text = ""
        TB_PBASIC_MENO.Text = ""
        CB_PBASIC_ACTIVE.Checked = False

        strSQL = ""
        strSQL = "select EMP_ID from Person_Info where EMP_ID = '" & CB_PBASIC_EMP_ID.Text & "'"

        Call mDB_Link()

        INS_Result = DATA_ReadS(strSQL)

        If INS_Result = "" Then

            strSQL = ""
            strSQL = " insert into Person_Info (Emp_ID)  values ('" & CB_PBASIC_EMP_ID.Text & "')"

            Call mDB_Link()
            INS_Result = executeSQL(strSQL)
        End If

    End Sub

    Private Sub BT_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Modify.Click
        Dim strSQL, INS_Result As String
        Dim Sex_Code As String
        On Error GoTo Err_Handle

        If RB_PBASIC_F.Checked Then
            Sex_Code = "F"
        Else
            Sex_Code = "M"
        End If


        strSQL = ""
        strSQL = "update Person_Info  "
        strSQL &= "set Sex ='" & Sex_Code & "',"
        strSQL &= " Birthday='" & Trim(TB_PBASIC_Birthday.Text) & "',"
        strSQL &= " Personal_ID='" & Trim(TB_PBASIC_ID.Text) & "',"
        strSQL &= " Home_Phone='" & Trim(TB_PBASIC_HOMEPHONE.Text) & "',"
        strSQL &= " Current_Phone='" & Trim(TB_PBASIC_CELLPHONE.Text) & "',"
        strSQL &= " Cell_Phone='" & Trim(TB_PBASIC_CELLPHONE.Text) & "',"
        strSQL &= " Living_place='" & Trim(TB_PBASIC_Livingplace.Text) & "',"
        strSQL &= " Living_place2='" & Trim(TB_PBASIC_Livingplace2.Text) & "'"
        strSQL &= " where EMP_ID ='" & Trim(CB_PBASIC_EMP_ID.Text) & "'"

        Call mDB_Link()
        INS_Result = executeSQL(strSQL)

        strSQL = ""
        strSQL = "update Person_Info  "
        strSQL &= "set EMG_NAME1 ='" & Trim(TB_PBASIC_EMG_NAME1.Text) & "',"
        strSQL &= " EMG_Phone1='" & Trim(TB_PBASIC_EMG_PHONE1.Text) & "',"
        strSQL &= " EMG_Releasion1='" & Trim(TB_PBASIC_EMG_RELEASION1.Text) & "',"
        strSQL &= " EMG_NAME2 ='" & Trim(TB_PBASIC_EMG_NAME2.Text) & "',"
        strSQL &= " EMG_Phone2='" & Trim(TB_PBASIC_EMG_PHONE2.Text) & "',"
        strSQL &= " EMG_Releasion2='" & Trim(TB_PBASIC_EMG_RELEASION2.Text) & "'"
        strSQL &= " where EMP_ID ='" & CB_PBASIC_EMP_ID.Text & "'"

        Call mDB_Link()
        INS_Result = executeSQL(strSQL)
        'MsgBox(Format(Now, "yyyy/MM/dd"))
        strSQL = ""
        strSQL = "update Person_Info  "
        strSQL &= "set Perf_year ='" & Trim(TB_PBASIC_PREF_YEAR.Text) & "',"
        strSQL &= " excomp_year='" & Trim(TB_PBASIC_EXCOMPY_YEAR.Text) & "',"
        strSQL &= " ex_compy_type='" & Trim(TB_PBASIC_EXCOMPY_TYPE.Text) & "',"
        strSQL &= " Meno ='" & Trim(TB_PBASIC_MENO.Text) & "',"
        strSQL &= " Updater='" & Trim(Environment.UserName) & "',"
        strSQL &= " Updater_Date='" & Format(Now, "yyyy/MM/dd") & "',"
        strSQL &= " Active=" & CB_PBASIC_ACTIVE.Checked & " "
        strSQL &= " where EMP_ID ='" & CB_PBASIC_EMP_ID.Text & "'"

        Call mDB_Link()
        INS_Result = executeSQL(strSQL)



        MsgBox("資料已經修改")


        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub BT_PBASIC_GETDATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PBASIC_GETDATA.Click
        TE_Personal_Data.Show()
    End Sub

    Private Sub BT_PBASIC_CLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PBASIC_CLOSE.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub
End Class