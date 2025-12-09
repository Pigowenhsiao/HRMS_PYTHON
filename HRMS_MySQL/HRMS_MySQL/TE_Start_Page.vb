Public Class TE_Start_Page

    Private Sub Start_Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL, Version_Check As String
        Dim objDataSet As DataSet
        Dim Auth_type As String
        Dim INS_Result As String

        Call mDB_Link()

        strSQL = ""
        strSQL = "select S_VER from software where Active = true"

        Version_Check = DATA_ReadS(strSQL)

        If Version_Check <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check, MsgBoxStyle.OkOnly)
            Me.Close()
        End If


        Call mDB_Link()

        strSQL = ""
        strSQL = "select S_Account,Auth_type from Authority where Active = true and S_Account ='" & LCase(Environment.UserName) & "'"

        'Version_Check = DATA_ReadS(strSQL)
        objDataSet = DATA_ReadF(strSQL, "Authority")
        If (objDataSet.Tables(0).Rows.Count) <= 0 Then
            Version_Check = ""
            Auth_type = ""
        Else
            Version_Check = Trim(objDataSet.Tables(0).Rows(0)(0).ToString)
            Auth_type = Trim(objDataSet.Tables(0).Rows(0)(1).ToString)
        End If

        '萬能天神權限
        If Auth_type = "01" Then
            BT_AREA.Visible = True
            BT_Authority.Visible = True
            BT_Section.Visible = True
            BT_TEB.Visible = True
            BT_TEE.Visible = True
            BT_PBASIC.Visible = True
            BT_MESUPDATE.Visible = False
            BT_Certify_Setting.Visible = True
            BT_Certify_Tool_Map.Visible = True
            BT_VAC_TYPE.Visible = True
            BT_JOB.Visible = True
            BT_Person_TEL_Query.Visible = True
            BT_Shop.Visible = True
        End If

        'key_In 及一般權線
        If Version_Check <> LCase(Environment.UserName) Or Auth_type = "02" Then
            BT_AREA.Visible = False
            BT_Authority.Visible = False
            BT_Section.Visible = False
            BT_TEB.Visible = False
            BT_TEE.Visible = False
            BT_PBASIC.Visible = False
            BT_MESUPDATE.Visible = False
            BT_Certify_Setting.Visible = False
            BT_Certify_Tool_Map.Visible = False
            BT_VAC_TYPE.Visible = False
            BT_JOB.Visible = False
            BT_PBASIC.Visible = False
            BT_Person_TEL_Query.Visible = False
            BT_Shop.Visible = False
        End If
        '開Key_In權限
        If Auth_type = "02" Then
            BT_Person_TEL_Query.Visible = True
            BT_Person_TEL_Query.Visible = True
            BT_Shop.Visible = True
        End If

        '開刪除Certify 權限 

        Call mDB_Link()
        strSQL = ""
        strSQL = "select Account_ID from Del_Authority where Active = true and Account_ID ='" & LCase(Environment.UserName) & "'"

        INS_Result = DATA_ReadS(strSQL)

        If INS_Result <> "" Then
            BT_Certift_DEL.Visible = True
        Else
            BT_Certift_DEL.Visible = False
        End If

    End Sub


    Private Sub BT_JOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_JOB.Click
        TE_Tool_desc.Show()
    End Sub

    Private Sub BT_AREA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AREA.Click
        TE_Area_desc.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Shop.Click
        TE_Loc_Desc.Show()
    End Sub

    Private Sub BT_Section_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Section.Click
        TE_Section_Desc.Show()
    End Sub

    Private Sub BT_TEB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB.Click
        TE_BASIC.Show()
    End Sub

    Private Sub BT_TEE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEE.Click
        'TE_Education.Show()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Setting.Click
        CF_Certify__EXAM.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Tool_Map.Click
        CF_Certify_Tool_Map.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CF_Certify_Record.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority.Click
        Authority_Control.Show()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_MESUPDATE.Click
        Dim strSQL As String
        strSQL = ""
        strSQL = "select ('L' + EMP_ID) as user_ID, Tool_ID, IIF(Active = True , 'Y', 'N')  as Certification "
        strSQL &= "from "
        strSQL &= "(Select EMP_ID, Certify_ID,Certify_date,Active from Training_Record ) A, "
        strSQL &= "(select Certify_ID, Tool_ID from Certify_tool_MAP where active =true)  B "
        strSQL &= "where A.Certify_ID = B.Certify_id order by Certify_date; "

        Call Export_CVS(strSQL, 2)
    End Sub

    Private Sub BT_PBASIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PBASIC.Click
        ' TE_Personal_INFO.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CF_Check_OverDue.Show()
    End Sub

    Private Sub BT_Certify_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Report.Click
        CF_Report.Show()
    End Sub

    Private Sub BT_VAC_TYPE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_VAC_TYPE.Click
        '  TE_VAC_TYPE.Show()
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RPT_Shift_Indices.Show()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RPT_42Shift.Show()
    End Sub

    Private Sub BT_RPT_Seniority_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RPT_Seniority.Click
        RPT_Seniority.Show()
    End Sub

    Private Sub Button4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        RPT_Person_certify.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RPT_Newadd.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certift_DEL.Click
        ' CF_Certify_Del.Show()
    End Sub

    Private Sub BT_Person_TEL_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Person_TEL_Query.Click
        ' RPT_PERSON_TEL_QUERY.Show()
    End Sub
End Class
