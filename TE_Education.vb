Public Class TE_Education

    Private Sub BT_TEE_GETDATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEE_GETDATA.Click
        Call GetDATA()
    End Sub

    Public Sub GetDATA()
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()
        strSQL = "Select A.EMP_ID as 工號,B.C_NAME as 姓名,Education as 教育程度,G_School as 畢業學校, "
        strSQL &= "Major as 主修 from TE_EDU A, BASIC B where A.EMP_ID=B.EMP_ID and B.Active=true order by A.EMP_ID"
        'strSQL = "Select * from TE_EDU A, BASIC B where A.EMP_ID=B.EMP_ID order by A.EMP_ID"

        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Section")
        DGV_TEE.DataSource = objDataset.Tables(0)
    End Sub


    Private Sub TE_Education_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DGV_TEE.Height = Me.Height - 200
        DGV_TEE.Width = Me.Width - 20
    End Sub



    Private Sub DGV_TEE_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_TEE.MouseClick
        Dim TEE_ID, TEE_Name, TEE_EDU, TEE_MAJOR, TEE_GSCHOOL, TEE_ As String
        Dim TEB_OnBoardDate As String
        Dim I As Integer
        Dim TEB_Active As Boolean

        On Error GoTo Err_Handle
        TEE_ID = DGV_TEE.CurrentRow.Cells(0).Value.ToString
        TEE_Name = DGV_TEE.CurrentRow.Cells(1).Value.ToString
        TEE_EDU = DGV_TEE.CurrentRow.Cells(2).Value.ToString
        TEE_GSCHOOL = DGV_TEE.CurrentRow.Cells(3).Value.ToString
        TEE_MAJOR = DGV_TEE.CurrentRow.Cells(4).Value.ToString

        LB_TEE_NAME.Text = Trim(TEE_Name)
        LB_TEE_ID.Text = Trim(TEE_ID)
        LB_TEE_EDU.Text = Trim(TEE_EDU)
        LB_TEE_GSCHOOL.Text = Trim(TEE_GSCHOOL)
        LB_TEE_MAJOR.Text = Trim(TEE_MAJOR)

        Exit Sub
Err_Handle:
        MsgBox(Err.Number & "," & Err().Description)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEE_EDUQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select A.EMP_ID as 工號,B.C_NAME as 姓名,Education as 教育程度,G_School as 畢業學校, "
        strSQL &= "Major as 主修 from TE_EDU A, BASIC B where A.EMP_ID=B.EMP_ID and B.Active=true "
        strSQL &= "and trim(education)='" & Trim(LB_TEE_EDU.Text) & "' order by A.EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEE.DataSource = objDataset.Tables(0)
    End Sub

    Private Sub BTT_TEE_GSCHOOLQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTT_TEE_GSCHOOLQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select A.EMP_ID as 工號,B.C_NAME as 姓名,Education as 教育程度,G_School as 畢業學校, "
        strSQL &= "Major as 主修 from TE_EDU A, BASIC B where A.EMP_ID=B.EMP_ID and B.Active=true "
        strSQL &= "and trim(G_SCHOOL)='" & Trim(LB_TEE_GSCHOOL.Text) & "' order by A.EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEE.DataSource = objDataset.Tables(0)

    End Sub

    Private Sub BT_TEE_MAJORQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TEE_MAJORQ.Click
        Dim strSQL As String
        Dim objDataset As DataSet

        Call mDB_Link()

        strSQL = ""
        strSQL = "Select A.EMP_ID as 工號,B.C_NAME as 姓名,Education as 教育程度,G_School as 畢業學校, "
        strSQL &= "Major as 主修 from TE_EDU A, BASIC B where A.EMP_ID=B.EMP_ID and B.Active=true "
        strSQL &= "and trim(MAJOR)='" & Trim(LB_TEE_MAJOR.Text) & "' order by A.EMP_ID"


        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "BASIC")
        DGV_TEE.DataSource = objDataset.Tables(0)

    End Sub
End Class