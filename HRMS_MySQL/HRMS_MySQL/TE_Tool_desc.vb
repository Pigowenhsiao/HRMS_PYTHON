Public Class TE_Tool_desc

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Tool_Main.Click
        Me.Close()
        TE_Start_Page.Show()
    End Sub


    Private Sub BT_JOB_GetData_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Tool_GetData.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = "Select Tool_ID as 機台編號,Active from Must_Tool"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "JOB")
        DGV_Job.DataSource = objDataset.Tables(0)

    End Sub


    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_Job.MouseClick
        Dim Tool_ID As String
        Dim Tool_active As Boolean

        Tool_ID = DGV_Job.CurrentRow.Cells(0).Value

        Tool_active = DGV_Job.CurrentRow.Cells(1).Value


        TB_Tool_ID.Text = Tool_ID

        CB_Tool_ACT.Checked = Tool_active
    End Sub


    Private Sub BT_Job_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Tool_Modify.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = ""
        strSQL &= "update Must_Tool "
        strSQL &= " Set Active=" & CB_Tool_ACT.Checked
        strSQL &= " where Tool_ID='" & TB_Tool_ID.Text & "'"

        If MsgBox("請問確定要修改機台=" & TB_Tool_ID.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經修改")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select Tool_ID as 機台編號,Active from Must_Tool"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "JOB")
        DGV_Job.DataSource = objDataset.Tables(0)

    End Sub



    Private Sub BT_Job_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Tool_Create.Click
        Dim strSQL As String
        Dim INS_Result As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        Call mDB_Link()

        strSQL = ""
        strSQL &= "Insert into Must_Tool (Tool_ID,Active) "
        strSQL &= " values ('" & TB_Tool_ID.Text & "'," & CB_Tool_ACT.Checked & ")"

        If MsgBox("請問確定要新增機台=" & TB_Tool_ID.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經新增")
        Else
            Exit Sub

        End If



        Call mDB_Link()
        strSQL = "Select Tool_ID as 機台編號,Active from Must_Tool"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "JOB")
        DGV_Job.DataSource = objDataset.Tables(0)
        Exit Sub
Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub

    Private Sub TE_Job_desc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_Job.Height = Me.Height - 280
        DGV_Job.Width = Me.Width - 20
    End Sub

    Private Sub TE_Tool_desc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version_DB As String

        Version_DB = Version_Check()
        If Version_DB <> version Then
            MsgBox("請由Report Viewer 重啟HRMS. 目前版本 " & version & " 現行版本 " & Version_Check(), MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub
End Class
