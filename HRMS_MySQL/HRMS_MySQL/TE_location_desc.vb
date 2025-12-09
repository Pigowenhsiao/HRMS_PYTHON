Public Class TE_Loc_Desc



    Private Sub BT_Shop_CLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        Me.Close()
        TE_Start_Page.Show()
    End Sub


    Private Sub BT_Shop_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GetData.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = "Select B.EMP_ID,B.C_NAME, A.Certify_Area from TE_LOCATION A right join BASIC B on A.EMP_ID=B.EMP_ID where B.active=true"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Shop")
        DGV_Location.DataSource = objDataset.Tables(0)

    End Sub


    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Location.MouseClick

        On Error Resume Next

        TB_LOEMP_ID.Text = Trim(DGV_Location.CurrentRow.Cells(0).Value)
        LB_5.Text = Trim(DGV_Location.CurrentRow.Cells(1).Value)
        TB_Location.Text = ""
        TB_Location.Text = Trim(DGV_Location.CurrentRow.Cells(2).Value)


        ' Shop_active = DGV_Shop.CurrentRow.Cells(2).Value.ToString



    End Sub


    Private Sub BT_Shop_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL &= "update TE_LOCATION "
        strSQL &= "set EMP_ID=trim('" & TB_LOEMP_ID.Text & "'), "
        strSQL &= " Certify_Area=trim('" & TB_Location.Text & "') "
        strSQL &= " where EMP_ID=trim('" & TB_LOEMP_ID.Text & "')"

        If MsgBox("請問確定要修改工號=" & TB_LOEMP_ID.Text & ", 工作區域=" & TB_Location.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經修改")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select B.EMP_ID,B.C_NAME, A.Certify_Area from TE_LOCATION A right join BASIC B on A.EMP_ID=B.EMP_ID where B.active=true"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Shop")
        DGV_Location.DataSource = objDataset.Tables(0)

    End Sub



    Private Sub BT_Shop_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into TE_Location (EMP_ID,Certify_Area,Active) "
        strSQL &= " values ('" & TB_LOEMP_ID.Text & "','" & TB_Location.Text & "',True)"

        If MsgBox("請問確定要新增工號" & TB_LOEMP_ID.Text & ", 工作描區域=" & LB_5.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經新增")
        Else
            Exit Sub

        End If



        Call mDB_Link()

        strSQL = "Select B.EMP_ID,B.C_NAME, A.Certify_Area from TE_LOCATION A right join BASIC B on A.EMP_ID=B.EMP_ID where B.active=true"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Shop")
        DGV_Location.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub



    Private Sub TE_location_desc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_Location.Height = Me.Height - 230
        DGV_Location.Width = Me.Width - 20
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        Call mDB_Link()

        If Trim(TB_LOEMP_ID.Text) <> "" Then
            strSQL = "Select A.EMP_ID,B.C_NAME, A.Certify_Area from TE_LOCATION A, BASIC B where A.EMP_ID=B.EMP_ID and A.EMP_ID='" & Trim(TB_LOEMP_ID.Text) & "'"
        Else
            MsgBox("尚未輸入工號")
            Exit Sub
        End If

        objDataset = DATA_ReadF(strSQL, "Shop")

        'Call DATA_Read(strSQL)
        If objDataset Is Nothing Then MsgBox("該工號尚未指定工作區域,請使用新增功能") : Exit Sub

        DGV_Location.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub TE_location_desc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class

