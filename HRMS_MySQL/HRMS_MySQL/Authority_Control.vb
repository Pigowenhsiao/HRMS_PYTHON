Public Class Authority_Control

    Private Sub BT_Authority_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_GetData.Click
        Call GetDATA()
    End Sub

    Sub GetData()
        Dim strSQL As String
        Dim objDataset As DataSet
        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(S_Account) as NT帳號,Active,Auth_Type from Authority where Active =true  order by S_Account"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")
        DGV_Authority.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub BT_Authority_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_Close.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Private Sub DGV_Authority_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Authority.MouseClick
        Dim StrSQL, INS_Result As String

        TB_Authority_Account.Text = DGV_Authority.CurrentRow.Cells(0).Value
        CB_Authority_Active.Checked = DGV_Authority.CurrentRow.Cells(1).Value
        If DGV_Authority.CurrentRow.Cells(2).Value = "01" Then
            RB_Auth_Full.Checked = True
        Else
            RB_Auth_Keyin.Checked = True
        End If

        Call mDB_Link()
        StrSQL = ""
        StrSQL = " select account_ID from DEL_Authority where Account_ID='" & Trim(TB_Authority_Account.Text) & "' and active=true"
        INS_Result = DATA_ReadS(StrSQL)
        If INS_Result <> "" Then CB_AUT_DEL_Certify.Checked = True Else CB_AUT_DEL_Certify.Checked = False


    End Sub

    Private Sub BT_Authority_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet
        Dim Auth_Type As String

        On Error GoTo Err_Handle

        Call mDB_Link()

        If RB_Auth_Full.Checked = True Then Auth_Type = "01" Else Auth_Type = "02"


        strSQL = ""
        strSQL &= "Insert into Authority (S_Account,Update_Date,Active,Auth_Type) "
        strSQL &= " values ('" & LCase(Trim(TB_Authority_Account.Text)) & "','" & Format(Now, "yyyy/MM/dd") & "',"
        strSQL &= CB_Authority_Active.Checked & ",'" & Auth_Type & "')"

        If MsgBox("請問確定要新增 NT帳號=" & TB_Authority_Account.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料新增作業完成")
        Else
            Exit Sub

        End If

        If CB_AUT_DEL_Certify.Checked = True Then Del_Authority_add(Trim(TB_Authority_Account.Text))
        If CB_AUT_DEL_Certify.Checked = False Then Del_Authority_Remove(Trim(TB_Authority_Account.Text))

        Call GetData()
        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub

    Private Sub BT_Authority_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim Auth_Type As String

        Call mDB_Link()

        If RB_Auth_Full.Checked = True Then Auth_Type = "01" Else Auth_Type = "02"

        strSQL = ""
        strSQL &= "update Authority "
        strSQL &= "set  Active=" & CB_Authority_Active.Checked
        strSQL &= ", Update_Date ='" & Format(Now, "yyyy/MM/dd") & "',"
        strSQL &= " Auth_Type = '" & Auth_Type & "' "
        strSQL &= " where S_Account='" & LCase(Trim(TB_Authority_Account.Text)) & "'"

        If MsgBox("請問確定要修改工作名稱=" & Trim(TB_Authority_Account.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料已經修改")
        Else
            Exit Sub

        End If

        If CB_AUT_DEL_Certify.Checked = True Then Del_Authority_add(Trim(TB_Authority_Account.Text))
        If CB_AUT_DEL_Certify.Checked = False Then Del_Authority_Remove(Trim(TB_Authority_Account.Text))

        Call GetData()

    End Sub

    Private Sub BT_Authority_Fail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_Fail.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(S_Account) as NT帳號,Active,Auth_Type from Authority where Active =False order by S_Account"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")
        DGV_Authority.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub Authority_Control_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_Authority.Width = Me.Width - 20
        DGV_Authority.Height = Me.Height - 260
    End Sub

    Sub Del_Authority_add(ByVal Account_ID As String)
        Dim StrSQL, INS_Result As String
        INS_Result = ""


        Call mDB_Link()
        strSQL = ""
        StrSQL = "Select Account_ID from DEL_Authority where Account_ID ='" & Trim(Account_ID) & "'"
        INS_Result = DATA_ReadS(strSQL)

        Call mDB_Link()

        If INS_Result = "" Then
            strSQL = ""
            StrSQL = "insert into DEL_authority (Account_ID,active) values ('" & Trim(Account_ID) & "',true)"
            INS_Result = executeSQL(strSQL)

        Else
            StrSQL = ""
            StrSQL = "update Del_Authority set active=true where Account_ID='" & Trim(Account_ID) & "'"
            INS_Result = executeSQL(StrSQL)

        End If

    End Sub
    Sub Del_Authority_Remove(ByVal Account_ID As String)
        Dim StrSQL, INS_Result As String
        INS_Result = ""


        Call mDB_Link()
        StrSQL = ""
        StrSQL = "Select Account_ID from DEL_Authority where Account_ID ='" & Trim(Account_ID) & "'"
        INS_Result = DATA_ReadS(StrSQL)

        Call mDB_Link()

        If INS_Result <> "" Then
            StrSQL = ""
            StrSQL = "update Del_Authority set Account_ID='" & Trim(Account_ID) & "',active=False"
            INS_Result = executeSQL(StrSQL)

        End If

    End Sub

    Private Sub Authority_Control_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String
        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub
End Class