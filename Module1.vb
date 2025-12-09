Imports System.Data.OleDb
Imports System.IO
Imports System.Text

Module Module1

    '指定資料庫位置
    Public Const mydata = "\\sslproj01\00_tps\HRMS\HRMS.mdb"

    Public objCon As OleDbConnection
    Public objCmd As OleDbCommand
    Public objDataReader As OleDbDataReader
    Public objDataAdapter As OleDbDataAdapter

    '設定軟體版本
    Public Const version = "0.032"

    '確認資料庫存在
    Public Function mDB_Exist()
        On Error GoTo Err_Handle
        If Dir(mydata) = "" Then mDB_Exist = "N" Else mDB_Exist = "Y"
        Exit Function

Err_Handle:
        Call ABNormal()
        mDB_Exist = "N"
    End Function

    Public Function mDB_Link()
        Dim strDbCon As String
        On Error GoTo Err_Handle

        '資料庫連線字串
        strDbCon = " Provider=Microsoft.JET.OLEDB.4.0; Data Source=" & mydata

        objCon = New OleDbConnection(strDbCon)

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
        objCmd = New OleDbCommand(strSQL, objCon)

        INS_Result = objCmd.ExecuteNonQuery()

        objCon.Close()

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
        objCmd = New OleDbCommand(strSQL, objCon)
        objDataReader = objCmd.ExecuteReader

        Do While objDataReader.Read()

            For I = 1 To objDataReader.FieldCount - 1

                DATALine &= objDataReader.Item(I) & vbTab

            Next

            DATALine &= vbNewLine

        Loop

        objCon.close()


        Exit Sub

Err_Handle:
        Call ABNormal()
    End Sub


    Public Function DATA_ReadF(ByVal strSQL As String, ByVal D_Name As String)
        Dim objDataset As DataSet
        On Error GoTo Err_Handle

        '將資料用DATASet 傳回去
        objDataAdapter = New OleDbDataAdapter(strSQL, objCon)
        objDataset = New DataSet()
        objDataAdapter.Fill(objDataset)
        objDataset.Tables(0).TableName = D_Name
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

        objCmd = New OleDbCommand(strSQL, objCon)
        objDataReader = objCmd.ExecuteReader(CommandBehavior.CloseConnection)

        If objDataReader.HasRows Then
            Do While objDataReader.Read()
                objCombobox.Items.Add(objDataReader.Item(0))
            Loop
        End If

        Exit Sub
        objCon.Close()
Err_Handle:
        Call ABNormal()
    End Sub

    Public Function DATA_ReadS(ByVal strSQL As String)
        Dim INS_Result As String
        On Error GoTo Err_Handle

        Call mDB_Link()

        '將查詢的單一值傳回去
        DATA_ReadS = ""

        objCmd = New OleDbCommand(strSQL, objCon)
        objDataReader = objCmd.ExecuteReader(CommandBehavior.CloseConnection)

        If objDataReader.HasRows Then
            Do While objDataReader.Read()
                DATA_ReadS &= Trim(objDataReader.Item(0))
            Loop
        End If

        INS_Result = DATA_ReadS

        Return INS_Result

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
                        Dim str As String = Trim(objDataset.Tables(0).Rows(I)(0)) & "," & Trim(objDataset.Tables(0).Rows(I)(1)) & "," _
                                            & Trim(objDataset.Tables(0).Rows(I)(2)) & vbNewLine
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

End Module
