Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text


Module Module1

    '指定資料庫位置
    Public Const mydata = "\\sslproj01\00_tps\HRMS\HRMS_0.mdb"

    Public objCon As MySQLConnection
    Public objCmd As MySQLCommand
    Public objDataReader As MySQLDataReader
    Public objDataAdapter As MySQLDataAdapter

    '設定軟體版本
    Public Const version = "0.037"

    '確認資料庫存在
    Public Function mDB_Exist1()

        On Error GoTo Err_Handle
        If Dir(mydata) = "" Then mDB_Exist1 = "N" Else mDB_Exist1 = "Y"
        Exit Function

Err_Handle:
        Call ABNormal()
        mDB_Exist1 = "N"
    End Function

    Public Function Version_Check()
        Dim strSQL As String
        Call mDB_Link()
        strSQL = ""
        strSQL = "select S_VER from software where Active = true"

        '撈出目前生效的軟體版本,並且回傳

        Version_Check = DATA_ReadS(strSQL)


    End Function

    Public Function mDB_Link()
        Dim strDbCon As String
        On Error GoTo Err_Handle

        '資料庫連線字串
        strDbCon = " Provider=Microsoft.JET.MySQL.4.0; Data Source=" & mydata & "; user Id=admin; password="
        strDbCon = " Server=EH113040;User=root; Password=pigo1405; Database=HRMS; Pooling=false;"

        objCon = New MySQLConnection(strDbCon)

        objCon.Open()

        mDB_Link = "Y"

        Exit Function
Err_Handle:
        Call ABNormal()
        mDB_Link = "N"
    End Function

    Public Function executeSQL(ByVal strSQL As String)
        On Error GoTo Err_Handle
        Dim INS_Result As String

        '執行SQL指令
        objCmd = New MySQLCommand(strSQL, objCon)

        INS_Result = objCmd.ExecuteNonQuery()

        objCon.Close()

        objCmd = Nothing

        Return "Y"
        Exit Function
Err_Handle:
        Call ABNormal()
        executeSQL = "N"

    End Function

    Public Sub DATA_Read(ByVal strSQL, ByVal objCon)

        Dim DATALine As String
        Dim objDataset As DataSet

        On Error GoTo Err_Handle

        '將查詢內容串成字串回饋
        DATALine = ""
        objCmd = New MySQLCommand(strSQL, objCon)
        objDataReader = objCmd.ExecuteReader

        Do While objDataReader.Read()

            For I = 1 To objDataReader.FieldCount - 1

                DATALine &= objDataReader.Item(I) & vbTab

            Next

            DATALine &= vbNewLine

        Loop

        objCmd = Nothing
        objDataAdapter = Nothing
        objDataReader = Nothing

        objCon.close()

        Exit Sub

Err_Handle:
        Call ABNormal()
    End Sub


    Public Function DATA_ReadF(ByVal strSQL As String, ByVal D_Name As String)
        Dim objDataset As DataSet
        On Error GoTo Err_Handle

        'MsgBox(strSQL)
        '將資料用DATASet 傳回去
        objDataAdapter = New MySQLDataAdapter(strSQL, objCon)
        objDataset = New DataSet()

        objDataAdapter.SelectCommand.CommandTimeout = 0 ' 指定查詢超時限制為無限制

        objDataAdapter.Fill(objDataset)


        objDataset.Tables(0).TableName = D_Name

        objCmd = Nothing
        objDataAdapter = Nothing
        objDataReader = Nothing

        objCon.Close()
        Return objDataset
        Exit Function
Err_Handle:
        Call ABNormal()
    End Function

    Public Sub Item_Update(ByVal objCombobox As ComboBox, ByVal strSQL As String)
        Dim mDB_stat, INS_Result As String

        On Error GoTo Err_Handle

        '將查詢資料傳給 Combobox 的選項
        objCombobox.Items.Clear()
        Call mDB_Link()

        objCmd = New MySQLCommand(strSQL, objCon)
        objDataReader = objCmd.ExecuteReader(CommandBehavior.CloseConnection)

        If objDataReader.HasRows Then
            Do While objDataReader.Read()
                objCombobox.Items.Add(objDataReader.Item(0))
            Loop
        End If

        objCmd = Nothing
        objDataReader = Nothing

        objCon.Close()


        Exit Sub

Err_Handle:
        Call ABNormal()
    End Sub

    Public Function DATA_ReadS(ByVal strSQL As String)
        Dim INS_Result As String
        On Error GoTo Err_Handle


        '將查詢的單一值傳回去
        DATA_ReadS = ""

        objCmd = New MySQLCommand(strSQL, objCon)
        objDataReader = objCmd.ExecuteReader(CommandBehavior.CloseConnection)

        If objDataReader.HasRows Then
            Do While objDataReader.Read()
                DATA_ReadS &= Trim(objDataReader.Item(0))
            Loop
        End If

        INS_Result = DATA_ReadS

        Return INS_Result

        objCmd = Nothing
        objDataReader = Nothing

        objCon.Close()
        Exit Function
Err_Handle:
        Call ABNormal()
    End Function


    Public Sub ABNormal()
        MsgBox(Err.Number & "," & Err.Description)
    End Sub

    Public Function Export(ByVal ds As DataSet, ByVal dtName As String, ByVal colList() As String, ByVal colValue() As Integer) As String
        Dim header As String = ""
        Dim body As String = ""
        Dim record As String = ""
        For Each col As String In colList
            header = header & Chr(34) & col & Chr(34) & ","
        Next
        header = header.Substring(0, header.Length - 1)
        For Each row As DataRow In ds.Tables(dtName).Rows
            Dim arr() As Object = row.ItemArray()
            For Each i As Integer In colValue
                If arr(i).ToString().IndexOf(",") > 0 Then
                    record = record & Chr(34) & arr(i).ToString() & Chr(34) & ","
                Else
                    record = record & arr(i).ToString() & ","
                End If
            Next
            body = body & record.Substring(0, record.Length - 1) & vbCrLf
            record = ""
        Next
        Return header & vbCrLf & body
    End Function
    Public Sub Export_CVS(ByVal strSQL As String, ByVal Chose As Integer)
        Dim Title As String
        Dim objDataset As DataSet
        Dim colList() As String = {"User_ID", "Tool_ID", "Certification"}
        Dim colValue() As Integer = {0, 1, 2}
        Dim I As Integer
        Dim C_Path As String
        Dim ID, Tool As String
        '指定MES權限寫入位置(MES正式位置)
        Dim MES_PATH = "\\tsmcssl.com\cim\Upload\TE_Certification_Upload\Certify_data_" & Second(Now()) & ".CSV"

        'MES 權限寫入的暫時位置
        Dim FilePath = "D:\Certify_data_" & Second(Now()) & ".CSV"
        'On Error GoTo Err_HAndle

        If Chose = 1 Then C_Path = MES_PATH Else C_Path = FilePath

        Call mDB_Link()

        Try
            Using fs As IO.FileStream = New IO.FileStream(C_Path, IO.FileMode.Append)    '把FilePath 改成MES 路徑就可以
                Using sw As StreamWriter = New StreamWriter(fs, Encoding.Default)
                    Title = "User ID,Tool ID,Certification" & vbNewLine
                    sw.Write(Title) '寫入表頭
                    sw.Flush() '執行寫入動作
                End Using
            End Using
        Catch ex As Exception
        End Try





        'Call DATA_Read(strSQL)
        objDataset = DATA_ReadF(strSQL, "Area")



        '寫入內容
        Try
            Using fs As IO.FileStream = New IO.FileStream(C_Path, IO.FileMode.Append)      '把FilePath 改成MES 路徑就可以
                Using sw As StreamWriter = New StreamWriter(fs, Encoding.Default)
                    For I = 0 To objDataset.Tables(0).Rows.Count

                        ID = Trim(objDataset.Tables(0).Rows(I)(0))
                        Tool = Trim(objDataset.Tables(0).Rows(I)(1))

                        'For 特殊工號/帳號的處理
                        If ID = "L000113" Then ID = "E004927" '璻華
                        If ID = "L000126" Then ID = "E065583"
                        If ID = "L000133" Then ID = "E065674"
                        If ID = "L000146" Then ID = "E067005"
                        If ID = "L000150" Then ID = "E067116"
                        If ID = "L000152" Then ID = "E067143"
                        If ID = "L000164" Then ID = "E067688"
                        If ID = "L000166" Then ID = "E067690"
                        If ID = "L000167" Then ID = "E067691"
                        If ID = "L000174" Then ID = "E067734"
                        If ID = "L000175" Then ID = "E067735"
                        If ID = "L000181" Then ID = "E067741"
                        If ID = "L000125" Then ID = "E065582"
                        If ID = "L000177" Then ID = "E067737"
                        If ID = "L000134" Then ID = "E065675"
                        If ID = "L000154" Then ID = "E067146"

                        Dim str As String = ID & "," & Tool & "," & Trim(objDataset.Tables(0).Rows(I)(2)) & vbNewLine
                        sw.Write(str) '第一行 
                        'sw.WriteLine(str) '插入一整行 
                        sw.Flush() '執行寫入動作
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try


        If Chose <> 1 Then
            MsgBox("資料已經寫入D:\Certify_data.csv,請確認權限設定是否正確,之後再上傳到 MES 資料夾 (測試階段暫不直接寫入)")
        End If
        Exit Sub

Err_Handle:
        Call ABNormal()
    End Sub

    Sub Excel_Export(ByVal DGV_Target As DataGridView)
        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application()
        MyExcel.Application.Workbooks.Add()
        MyExcel.Visible = True
        On Error GoTo Err_Handle
        '獲取標題
        Dim Cols As Integer
        For Cols = 1 To DGV_Target.Columns.Count
            MyExcel.Cells(1, Cols) = DGV_Target.Columns(Cols - 1).HeaderText
        Next

        '往excel表裡添加資料()
        Dim i As Integer
        For i = 0 To DGV_Target.RowCount - 1
            Dim j As Integer
            For j = 0 To DGV_Target.ColumnCount - 1
                If DGV_Target(j, i).Value Is System.DBNull.Value Then

                    MyExcel.Cells(i + 2, j + 1) = ""
                Else
                    MyExcel.Cells(i + 2, j + 1) = DGV_Target(j, i).Value.ToString

                End If
            Next (j)
        Next (i)
        Exit Sub
Err_Handle:
        Call ABNormal()
    End Sub

    Sub DATAGRIDVIEW_TO_EXCEL(ByVal DGV As DataGridView)
        Try
            Dim DTB = New DataTable, RWS As Integer, CLS As Integer

            For CLS = 0 To DGV.ColumnCount - 1 ' COLUMNS OF DTB
                DTB.Columns.Add(DGV.Columns(CLS).Name.ToString)
            Next

            Dim DRW As DataRow

            For RWS = 0 To DGV.Rows.Count - 1 ' FILL DTB WITH DATAGRIDVIEW
                DRW = DTB.NewRow

                For CLS = 0 To DGV.ColumnCount - 1
                    Try
                        DRW(DTB.Columns(CLS).ColumnName.ToString) = DGV.Rows(RWS).Cells(CLS).Value.ToString
                    Catch ex As Exception

                    End Try
                Next

                DTB.Rows.Add(DRW)
            Next

            DTB.AcceptChanges()

            Dim DST As New DataSet

            DST.Tables.Add(DTB)

            Dim FLE As String = "D:\TEST.XML" ' PATH AND FILE NAME WHERE THE XML WIL BE CREATED (EXEMPLE: C:\REPS\XML.xml)

            DTB.WriteXml(FLE)
            'Dim EXL As String = "C:\Program Files\Microsoft Office\Office12\excel.exe" ' PATH OF/ EXCEL.EXE IN YOUR MICROSOFT OFFICE
            'Shell(Chr(34) & EXL & Chr(34) & " " & Chr(34) & FLE & Chr(34), vbNormalFocus) ' OPEN XML WITH EXCEL

            Process.Start("excel.exe", FLE)  '直接指定系統開啟excel 並同時開啟指定的XML

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


End Module
