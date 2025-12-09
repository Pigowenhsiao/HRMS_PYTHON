Public Class TE_Area_desc

    Private Sub BT_AREA_CLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AREA_CLOSE.Click
        Me.Close()
        TE_Start_Page.Show()
    End Sub


    Private Sub BT_Area_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Area_GetData.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        Call mDB_Link()
        strSQL = "Select Area as 工作類別,Area_DESC as 工作定義,Active from Area"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")
        DGV_Area.DataSource = objDataset.Tables(0)

    End Sub


    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Area.MouseClick
        Dim Area, Area_desc As String
        Dim Area_active As Boolean

        Area = DGV_Area.CurrentRow.Cells(0).Value
        Area_desc = DGV_Area.CurrentRow.Cells(1).Value
        Area_active = DGV_Area.CurrentRow.Cells(2).Value


        TB_Area_NAME.Text = Area
        TB_Area_DESC.Text = Area_desc
        CB_Area_ACT.Checked = Area_active
    End Sub


    Private Sub BT_Area_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Area_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL &= "update Area "
        strSQL &= "set Area_desc='" & TB_Area_DESC.Text & "', "
        strSQL &= " Active=" & CB_Area_ACT.Checked
        strSQL &= " where Area='" & TB_Area_NAME.Text & "'"

        If MsgBox("請問確定要修改工作名稱=" & TB_Area_NAME.Text & ", 工作描述=" & TB_Area_DESC.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經修改")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select Area as 工作類別,Area_DESC as 工作定義,Active from Area"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")
        DGV_Area.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub BT_Area_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Area_Del.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "delete from Area "
        strSQL &= " where Area='" & TB_Area_NAME.Text & "'"

        If MsgBox("請問確定要刪除工作名稱=" & TB_Area_NAME.Text & ", 工作描述=" & TB_Area_DESC.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經刪除")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select Area as 工作類別,Area_DESC as 工作定義,Active from Area"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")
        DGV_Area.DataSource = objDataset.Tables(0)


        Exit Sub

Err_Handle:
        Call ABNormal()
    End Sub

    Private Sub BT_Area_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Area_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into Area (Area,Area_DESC,Active) "
        strSQL &= " values ('" & TB_Area_NAME.Text & "','" & TB_Area_DESC.Text & "'," & CB_Area_ACT.Checked & ")"

        If MsgBox("請問確定要新增工作名稱=" & TB_Area_NAME.Text & ", 工作描述=" & TB_Area_DESC.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經新增")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select Area as 工作類別,Area_DESC as 工作定義,Active from Area"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")
        DGV_Area.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AREA_CLOSE.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Private Sub TE_Area_desc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_Area.Height = Me.Height - 268
        DGV_Area.Width = Me.Width - 20
    End Sub

    Private Sub TE_Area_desc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub
End Class
