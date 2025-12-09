Public Class Authority_Control

    Private Sub BT_Authority_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_GetData.Click
        Call GetDATA()
    End Sub

    Sub GetData()
        Dim strSQL As String
        Dim objDataset As DataSet
        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(S_Account) as NT帳號,Active from Authority where Active =true  order by S_Account"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")
        DGV_Authority.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub BT_Authority_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_Close.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Private Sub DGV_Authority_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Authority.MouseClick

        TB_Authority_Account.Text = DGV_Authority.CurrentRow.Cells(0).Value
        CB_Authority_Active.Checked = DGV_Authority.CurrentRow.Cells(1).Value

    End Sub

    Private Sub BT_Authority_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into Authority (S_Account,Update_Date,Active) "
        strSQL &= " values ('" & Trim(TB_Authority_Account.Text) & "','" & Format(Now, "yyyy/MM/dd") & "',"
        strSQL &= CB_Authority_Active.Checked & ")"

        If MsgBox("請問確定要新增 NT帳號=" & TB_Authority_Account.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料新增作業完成")
        Else
            Exit Sub

        End If
        Call GetData()
        Exit Sub
Err_Handle:
        Call ABNormal()

    End Sub

    Private Sub BT_Authority_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String

        Call mDB_Link()
        strSQL = ""
        strSQL &= "update Authority "
        strSQL &= "set  Active=" & CB_Authority_Active.Checked
        strSQL &= ", Update_Date ='" & Format(Now, "yyyy/MM/dd") & "'"
        strSQL &= " where S_Account='" & Trim(TB_Authority_Account.Text) & "'"

        If MsgBox("請問確定要修改工作名稱=" & Trim(TB_Authority_Account.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            If INS_Result = "Y" Then MsgBox("資料已經修改")
        Else
            Exit Sub

        End If

        Call GetData()

    End Sub

    Private Sub BT_Authority_Fail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Authority_Fail.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        Call mDB_Link()
        strSQL = ""
        strSQL = "Select trim(S_Account) as NT帳號,Active from Authority where Active =False order by S_Account"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")
        DGV_Authority.DataSource = objDataset.Tables(0)

    End Sub


End Class