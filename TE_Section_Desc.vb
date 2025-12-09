Public Class TE_Section_Desc

    Private Sub BT_Section_CLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Section_Close.Click
        Me.Close()
        TE_Start_Page.Show()
    End Sub


    Private Sub BT_Section_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Section_GetData.Click
        Dim strSQL As String
        Dim objDataset As DataSet
        On Error GoTo Err_Handle
        Call mDB_Link()
        strSQL = "Select trim(Dept_Code) as Dept_Code,Dept_Name,Dept_Desc,Supervisor from L_Section order by Dept_Code"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Section.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)

    End Sub


    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Section.MouseClick
        Dim Section_Code, Section_Name, Section_Desc, Supervisor As String
        '  Dim Section_Active As Boolean

        Section_Code = DGV_Section.CurrentRow.Cells(0).Value
        Section_Name = DGV_Section.CurrentRow.Cells(1).Value
        Section_desc = DGV_Section.CurrentRow.Cells(2).Value
        Supervisor = DGV_Section.CurrentRow.Cells(3).Value
        'Section_Active = DGV_Section.CurrentRow.Cells(4).Value



        TB_Section_Code.Text = Section_Code
        TB_Section_Name.Text = Section_Name
        TB_Section_Desc.Text = Section_Desc
        TB_Section_Supervisor.Text = Supervisor
        'CB_Section_ACT.Checked = Section_Active

    End Sub


    Private Sub BT_Section_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Section_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String

        Call mDB_Link()
        strSQL = ""
        strSQL &= "update L_Section "
        strSQL &= "set Dept_Code='" & TB_Section_Code.Text & "', "
        strSQL &= " Dept_Name='" & TB_Section_Name.Text & "', "
        strSQL &= " Dept_Desc='" & TB_Section_Desc.Text & "', "
        strSQL &= " Supervisor='" & TB_Section_Supervisor.Text & "' "
        strSQL &= " where Dept_Code='" & TB_Section_Code.Text & "'"

        If MsgBox("請問確定要修改課別編號=" & TB_Section_Code.Text & ", 課別名稱=" & TB_Section_Name.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經修改")
        Else
            Exit Sub

        End If



        Call GetDATA()

    End Sub

    Private Sub BT_Section_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Section_Del.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "delete from L_Section "
        strSQL &= " where Dept_Code='" & TB_Section_Code.Text & "'"

        If MsgBox("請問確定要刪除課別編號=" & TB_Section_Code.Text & ", 課別名稱=" & TB_Section_Name.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經刪除")
        Else
            Exit Sub

        End If



        Call GetDATA()


        Exit Sub

Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub

    Private Sub BT_Section_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Section_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into L_Section (Dept_Code,Dept_Name,Dept_DESC,Supervisor) "
        strSQL &= " values ('" & TB_Section_Code.Text & "','" & TB_Section_Name.Text & "','" & TB_Section_Desc.Text & "','" & TB_Section_Supervisor.Text & "')"

        If MsgBox("請問確定要新增課別編號=" & TB_Section_Code.Text & ", 課別名稱=" & TB_Section_Name.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經新增")
        Else
            Exit Sub

        End If


        Call GetDATA()

        Exit Sub
Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Section_Close.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Public Sub GetDATA()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = "Select trim(Dept_Code) as Dept_Code,Dept_Name,Dept_Desc,Supervisor from L_Section order by Dept_Code"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_Section.DataSource = objDataset.Tables(0)
    End Sub
    Sub Create_table()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = "CREATE TABLE Software_version(Version varchar(10) not null,Desc varchar(256), Publish_date date, Active Bollean)"
        objDataset = DATA_ReadF(strSQL, "Section")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Create_table()
    End Sub

    Private Sub TE_Section_Desc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_Section.Height = Me.Height - 275
        DGV_Section.Width = Me.Width - 20
    End Sub
End Class