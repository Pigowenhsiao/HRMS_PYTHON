Public Class TE_BASIC

    Private Sub BT_TEB_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_GetData.Click
        Call GetDATA()
    End Sub

   
    Private Sub DGV_TEB_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_TEB.MouseClick
        Dim TEB_ID, TEB_DeptCode, TEB_Title, TEB_NAME, TEB_Shift, TEB_AREA, TEB_Function, TEB_Meno As String
        Dim TEB_OnBoardDate As String
        Dim I As Integer
        Dim TEB_Active As Boolean

        On Error GoTo Err_Handle
        TEB_ID = DGV_TEB.CurrentRow.Cells(0).Value.ToString
        TEB_DeptCode = DGV_TEB.CurrentRow.Cells(1).Value.ToString
        TEB_NAME = DGV_TEB.CurrentRow.Cells(2).Value.ToString
        TEB_Title = DGV_TEB.CurrentRow.Cells(3).Value.ToString
        TEB_OnBoardDate = DGV_TEB.CurrentRow.Cells(4).Value.ToString
        TEB_Shift = DGV_TEB.CurrentRow.Cells(5).Value.ToString
        TEB_AREA = DGV_TEB.CurrentRow.Cells(6).Value.ToString
        TEB_Function = DGV_TEB.CurrentRow.Cells(7).Value.ToString
        TEB_Meno = DGV_TEB.CurrentRow.Cells(8).Value.ToString
        TEB_Active = DGV_TEB.CurrentRow.Cells(9).Value

        TB_TEB_ID.Text = Trim(TEB_ID).PadLeft(6, "0")
        CB_TEB_DeptCode.Text = Trim(TEB_DeptCode)
        TB_TEB_NAME.Text = Trim(TEB_NAME)
        TB_TEB_Title.Text = Trim(TEB_Title)
        TB_TEB_OnBoardDate.Text = Trim(TEB_OnBoardDate)
        LB_TEB_SHIFT.Text = Trim(TEB_Shift)
        CB_TEB_AREA.Text = Trim(TEB_AREA)
        CB_TEB_FUNCTION.Text = Trim(TEB_Function)
        TB_TEB_MENO.Text = Trim(TEB_Meno)
        CB_TEB_Active.Checked = TEB_Active
        Exit Sub
Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)
    End Sub



    Private Sub TE_BASIC_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_TEB.Height = Me.Height - 300
        DGV_TEB.Width = Me.Width - 20
    End Sub


    Private Sub TE_BASIC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String

        strSQL = ""
        strSQL = " select trim(Dept_code) from L_Section order by Dept_Code"

        Item_update(CB_TEB_DeptCode, strSQL)

        ' strSQL = ""
        ' strSQL = " select Shift & ',' & Shift_desc  from shift order by shift"
        ' Item_update(LB_TEB_SHIFT, strSQL)

        strSQL = ""
        strSQL = " select Area  from Area order by Area"
        Item_update(CB_TEB_AREA, strSQL)

        strSQL = ""
        strSQL = " select L_Job from L_Job order by L_JOB"
        Item_update(CB_TEB_FUNCTION, strSQL)

    End Sub

    Private Sub BT_TEB_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_Create.Click
        Dim strSQL, INS_result As String

        On Error GoTo Err_Handle

        strSQL = ""
        strSQL = " insert into basic ( EMP_ID,Dept_code, C_Name, Title, On_Board_Date,Shift,Meno,Update_date,Function,Area,Active) "
        strSQL &= " Values ('" & TB_TEB_ID.Text & "','"
        strSQL &= "" & CB_TEB_DeptCode.Text & "','"
        strSQL &= "" & TB_TEB_NAME.Text & "','"
        strSQL &= "" & TB_TEB_Title.Text & "','"
        strSQL &= "" & TB_TEB_OnBoardDate.Text & "','"
        strSQL &= "" & LB_TEB_SHIFT.Text & "','"
        strSQL &= "" & TB_TEB_MENO.Text & "','"
        strSQL &= "" & Mid(Today().ToString, 1, 10) & "','"
        strSQL &= "" & CB_TEB_FUNCTION.Text & "','"
        strSQL &= "" & CB_TEB_AREA.Text & " ',"
        strSQL &= "" & CB_TEB_Active.Checked & ")"

        Call mDB_Link()


        If MsgBox("確定要新增 工號=" & TB_TEB_ID.Text & " 姓名=" & TB_TEB_NAME.Text & "的個人資料?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_result = executeSQL(strSQL)
            strSQL = ""
            strSQL = " insert into Person_info (EMP_ID='" & TB_TEB_ID.Text & "')"
            INS_result = executeSQL(strSQL)
            MsgBox("資料已經新增")
        End If
        Call GetDATA()

        Exit Sub

Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)

    End Sub

    Private Sub BT_TEB_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_Modify.Click
        Dim strSQL, INS_Result As String
        On Error GoTo Err_Handle

        strSQL = ""
        strSQL = "update Basic  "
        strSQL &= "set Dept_code ='" & CB_TEB_DeptCode.Text & "',"
        strSQL &= " C_Name='" & TB_TEB_NAME.Text & "',"
        strSQL &= " Title='" & TB_TEB_Title.Text & "',"
        strSQL &= " On_Board_Date='" & TB_TEB_OnBoardDate.Text & "',"
        strSQL &= " shift='" & LB_TEB_SHIFT.Text & "',"
        strSQL &= " Meno='" & TB_TEB_MENO.Text & "',"
        strSQL &= " Update_date='" & Mid(Today().ToString, 1, 10) & "',"
        strSQL &= " Function='" & CB_TEB_FUNCTION.Text & "',"
        strSQL &= " Active=" & CB_TEB_Active.Checked & ","
        strSQL &= " Area='" & CB_TEB_AREA.Text & "' "
        strSQL &= " where EMP_ID ='" & TB_TEB_ID.Text & "'"

        Call mDB_Link()

        If MsgBox("確定要修改 工號=" & TB_TEB_ID.Text & " 姓名=" & TB_TEB_NAME.Text & "的個人資料?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經修改")
        End If
        Call GetDATA()

        Exit Sub

Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)

    End Sub

    Private Sub BT_TEB_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_Close.Click
        TE_Start_Page.Show()
        Me.Close()
    End Sub

    Private Sub BT_TEB_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_Del.Click
        Dim strSQL, INS_Result As String
        On Error GoTo Err_Handle

        strSQL = ""
        strSQL = "Delete from  Basic  "
        strSQL &= " where EMP_ID ='" & TB_TEB_ID.Text & "'"

        Call mDB_Link()

        If MsgBox("確定要刪除 工號=" & TB_TEB_ID.Text & " 姓名=" & TB_TEB_NAME.Text & "的個人資料?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            INS_Result = executeSQL(strSQL)
            MsgBox("資料已經刪除")
        End If
        Call GetDATA()


        Exit Sub

Err_Handle:
        MsgBox(Err.Number & "," & Err.Description)

    End Sub

    Public Sub GetDATA()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select right(('000000' & trim(EMP_ID)),6)  as 工號,A.Dept_Code as 部門代碼,C_Name as 姓名, Title AS 職稱, on_Board_Date as 到職日, "
        strSQL &= " trim(B.Dept_Desc) as 課別, Area as 區域,Function as 工作內容,Meno as 備註,A.Active as 在職否,A.Update_Date from basic A, L_Section B "
        strSQL &= " where trim(A.Dept_Code)=trim(B.Dept_code) and A.active=True order by EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEB.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub CB_TEB_DeptCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_TEB_DeptCode.SelectedIndexChanged
        Dim strSQL As String

        strSQL = ""
        strSQL = " select Dept_Desc from L_Section where trim(Dept_Code)='" & Trim(CB_TEB_DeptCode.Text) & "'"
        'strSQL = " select Dept_Code from L_Section"
        Call mDB_Link()
        LB_TEB_SHIFT.Text = ""
        LB_TEB_SHIFT.Text = DATA_ReadS(strSQL)



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_QUIT.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select right(('000000' & trim(EMP_ID)),6)  as 工號,A.Dept_Code as 部門代碼,C_Name as 姓名, Title AS 職稱, on_Board_Date as 到職日, "
        strSQL &= " trim(B.Dept_Desc) as 課別, Area as 區域,Function as 工作內容,Meno as 備註,A.Active as 在職否 from basic A, L_Section B "
        strSQL &= " where trim(A.Dept_Code)=trim(B.Dept_code) and A.active=False order by EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEB.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub BT_TEB_IDQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_IDQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select right(('000000' & trim(EMP_ID)),6)  as 工號,A.Dept_Code as 部門代碼,C_Name as 姓名, Title AS 職稱, on_Board_Date as 到職日, "
        strSQL &= " trim(B.Dept_Desc) as 課別, Area as 區域,Function as 工作內容,Meno as 備註,A.Active as 在職否 from basic A, L_Section B "
        strSQL &= " where trim(A.Dept_Code)=trim(B.Dept_code) and A.active=true and A.EMP_ID ='" & Trim(TB_TEB_ID.Text) & "' order by A.EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEB.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub BT_TEB_DEPQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_DEPQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select right(('000000' & trim(EMP_ID)),6)  as 工號,A.Dept_Code as 部門代碼,C_Name as 姓名, Title AS 職稱, on_Board_Date as 到職日, "
        strSQL &= " trim(B.Dept_Desc) as 課別, Area as 區域,Function as 工作內容,Meno as 備註,A.Active as 在職否 from basic A, L_Section B "
        strSQL &= " where trim(A.Dept_Code)=trim(B.Dept_code) and A.active=true and A.Dept_Code ='" & Trim(CB_TEB_DeptCode.Text) & "' order by A.EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEB.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub BT_TEB_TITLEQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_TITLEQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select right(('000000' & trim(EMP_ID)),6)  as 工號,A.Dept_Code as 部門代碼,C_Name as 姓名, Title AS 職稱, on_Board_Date as 到職日, "
        strSQL &= " trim(B.Dept_Desc) as 課別, Area as 區域,Function as 工作內容,Meno as 備註,A.Active as 在職否 from basic A, L_Section B "
        strSQL &= " where trim(A.Dept_Code)=trim(B.Dept_code) and A.active=true and A.Title ='" & Trim(TB_TEB_Title.Text) & "' order by A.EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEB.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub BT_TEB_AREAQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_AREAQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select right(('000000' & trim(EMP_ID)),6)  as 工號,A.Dept_Code as 部門代碼,C_Name as 姓名, Title AS 職稱, on_Board_Date as 到職日, "
        strSQL &= " trim(B.Dept_Desc) as 課別, Area as 區域,Function as 工作內容,Meno as 備註,A.Active as 在職否 from basic A, L_Section B "
        strSQL &= " where trim(A.Dept_Code)=trim(B.Dept_code) and A.active=true and A.Area ='" & Trim(CB_TEB_AREA.Text) & "' order by A.EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEB.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub BT_TEB_FunctionQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEB_FunctionQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select right(('000000' & trim(EMP_ID)),6)  as 工號,A.Dept_Code as 部門代碼,C_Name as 姓名, Title AS 職稱, on_Board_Date as 到職日, "
        strSQL &= " trim(B.Dept_Desc) as 課別, Area as 區域,Function as 工作內容,Meno as 備註,A.Active as 在職否 from basic A, L_Section B "
        strSQL &= " where trim(A.Dept_Code)=trim(B.Dept_code) and A.active=true and A.function ='" & Trim(CB_TEB_FUNCTION.Text) & "' order by A.EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEB.DataSource = objDataset.Tables(0)
    End Sub



End Class