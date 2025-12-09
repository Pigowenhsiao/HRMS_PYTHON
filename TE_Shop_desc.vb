Public Class TE_Shop_desc



    Private Sub BT_Shop_CLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Shop_Close.Click
        Me.Close()
        TE_Start_Page.Show()
    End Sub


    Private Sub BT_Shop_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Shop_GetData.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        Call mDB_Link()
        strSQL = "Select Shop as 工作類別,Shop_DESC as 工作定義,Active from Shop"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Shop")
        DGV_Shop.DataSource = objDataset.Tables(0)

    End Sub


    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Shop.MouseClick
        Dim Shop, Shop_desc As String
        Dim Shop_active As Boolean

        Shop = DGV_Shop.CurrentRow.Cells(0).Value
        Shop_desc = DGV_Shop.CurrentRow.Cells(1).Value
        Shop_active = DGV_Shop.CurrentRow.Cells(2).Value


        TB_Shop_Name.Text = Shop
        TB_Shop_Desc.Text = Shop_desc
        CB_Shop_ACT.Checked = Shop_active
    End Sub


    Private Sub BT_Shop_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Shop_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL &= "update Shop "
        strSQL &= "set Shop_desc='" & TB_Shop_Desc.Text & "', "
        strSQL &= " Active=" & CB_Shop_ACT.Checked
        strSQL &= " where Shop='" & TB_Shop_Name.Text & "'"

        If MsgBox("請問確定要修改工作名稱=" & TB_Shop_Name.Text & ", 工作描述=" & TB_Shop_Desc.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經修改")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select Shop as 工作類別,Shop_DESC as 工作定義,Active from Shop"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Shop")
        DGV_Shop.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub BT_Shop_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Shop_Del.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "delete from Shop "
        strSQL &= " where Shop='" & TB_Shop_Name.Text & "'"

        If MsgBox("請問確定要刪除工作名稱=" & TB_Shop_Name.Text & ", 工作描述=" & TB_Shop_Desc.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經刪除")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select Shop as 工作類別,Shop_DESC as 工作定義,Active from Shop"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Shop")
        DGV_Shop.DataSource = objDataset.Tables(0)


        Exit Sub

Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub

    Private Sub BT_Shop_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Shop_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into Shop (Shop,Shop_DESC,Active) "
        strSQL &= " values ('" & TB_Shop_Name.Text & "','" & TB_Shop_Desc.Text & "'," & CB_Shop_ACT.Checked & ")"

        If MsgBox("請問確定要新增工作名稱=" & TB_Shop_Name.Text & ", 工作描述=" & TB_Shop_Desc.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經新增")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select Shop as 工作類別,Shop_DESC as 工作定義,Active from Shop"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Shop")
        DGV_Shop.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Shop_Close.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Private Sub Shop_desc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = FormatDateTime(Today(), DateFormat.ShortDate)
    End Sub
End Class

