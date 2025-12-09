Public Class TE_Start_Page

    Private Sub Start_Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim mDb_Stat As String
        Dim strSQL, Version_Check As String
        mDb_Stat = mDB_Exist()

        If mDb_Stat = "Y" Then

        Else
            MsgBox("找不到資料庫,請確認", MsgBoxStyle.OkOnly, "無法連結資料庫")
            Me.Close()
            Exit Sub
        End If

        mDB_Exist()

        strSQL = ""
        strSQL = "select S_VER from software where Active = true"

        Version_Check = DATA_ReadS(strSQL)

        If Version_Check <> version Then
            MsgBox("請到//sslproj01/00_TPS/HRMS/Setup.exe, 更新軟體版本.  目前版本 " & version & " 現行版本 " & Version_Check, MsgBoxStyle.OkOnly)
            Me.Close()
        End If




        strSQL = ""
        strSQL = "select S_Account from Authority where Active = true and S_Account ='" & Environment.UserName & "'"

        Version_Check = DATA_ReadS(strSQL)

        If Version_Check <> Environment.UserName Then
            BT_AREA.Visible = False
            BT_Authority.Visible = False
            BT_Section.Visible = False
            BT_TEB.Visible = False
            BT_TEE.Visible = False
            BT_PBASIC.Visible = False
            BT_MESUPDATE.Visible = False
            BT_Certify_Setting.Visible = False
            BT_Certify_Tool_Map.Visible = False

        Else
            BT_AREA.Visible = True
            BT_Authority.Visible = True
            BT_Section.Visible = True
            BT_TEB.Visible = True
            BT_TEE.Visible = True
            BT_PBASIC.Visible = True
            BT_MESUPDATE.Visible = True
            BT_Certify_Setting.Visible = True
            BT_Certify_Tool_Map.Visible = True
        End If



        ' MsgBox(Version_Check)


        'MsgBox(Environment.UserName)

    End Sub


    Private Sub BT_JOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_JOB.Click
        TE_Job_desc.Show()
    End Sub

    Private Sub BT_AREA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AREA.Click
        TE_Area_desc.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Shop.Click
        TE_Shop_desc.Show()
    End Sub

    Private Sub BT_Section_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Section.Click
        TE_Section_Desc.Show()
    End Sub

    Private Sub BT_TEB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB.Click
        TE_BASIC.Show()
    End Sub

    Private Sub BT_TEE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEE.Click
        TE_Education.Show()
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
        TE_Personal_INFO.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CF_Check_OverDue.Show()
    End Sub

    Private Sub BT_Certify_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Certify_Report.Click
        CF_Report.Show()
    End Sub
End Class
