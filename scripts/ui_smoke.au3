#NoTrayIcon
Opt("WinTitleMatchMode", 4)

Global $g_log = "E:\python_Code\HRMS_PYTHON\test_results.txt"
FileDelete($g_log)

Func LogLine($msg)
    FileWriteLine($g_log, $msg)
EndFunc

Func ClickRel($hwnd, $rx, $ry)
    Local $pos = WinGetPos($hwnd)
    If @error Then
        Return False
    EndIf
    Local $x = $pos[0] + Int($pos[2] * $rx)
    Local $y = $pos[1] + Int($pos[3] * $ry)
    MouseClick("left", $x, $y, 1, 0)
    Sleep(600)
    Return True
EndFunc

Func ClickRelYOffset($hwnd, $rx, $ry, $yOffset)
    Local $pos = WinGetPos($hwnd)
    If @error Then
        Return False
    EndIf
    Local $x = $pos[0] + Int($pos[2] * $rx)
    Local $y = $pos[1] + Int($pos[3] * $ry) + $yOffset
    MouseClick("left", $x, $y, 1, 0)
    Sleep(600)
    Return True
EndFunc

Func OpenDialogByClick($main, $rx, $ry, $closeKey)
    Local $prev = WinGetHandle("[ACTIVE]")
    If Not ClickRel($main, $rx, $ry) Then
        Return False
    EndIf
    Local $t = TimerInit()
    While TimerDiff($t) < 8000
        Local $cur = WinGetHandle("[ACTIVE]")
        If $cur <> $prev Then
            Sleep(600)
            Send($closeKey)
            Sleep(800)
            Return True
        EndIf
        Sleep(200)
    WEnd
    Return False
EndFunc

Func OpenDialogByClickAndWaitNewWindow($main, $pid, $rx, $ry, $closeKey)
    Local $before = "|"
    Local $list = WinList()
    For $i = 1 To $list[0][0]
        Local $h = $list[$i][1]
        If $h <> 0 And WinGetProcess($h) = $pid Then
            If BitAND(WinGetState($h), 2) Then
                $before &= $h & "|"
            EndIf
        EndIf
    Next
    If Not ClickRel($main, $rx, $ry) Then
        Return False
    EndIf
    Local $t = TimerInit()
    While TimerDiff($t) < 8000
        $list = WinList()
        For $i = 1 To $list[0][0]
            Local $h = $list[$i][1]
            If $h <> 0 And WinGetProcess($h) = $pid Then
                If BitAND(WinGetState($h), 2) Then
                    If StringInStr($before, "|" & $h & "|") = 0 Then
                        WinActivate($h)
                        Sleep(400)
                        Send($closeKey)
                        Sleep(600)
                        Return True
                    EndIf
                EndIf
            EndIf
        Next
        Sleep(200)
    WEnd
    Return False
EndFunc

Func FindWindowByPid($pid)
    Local $list = WinList()
    For $i = 1 To $list[0][0]
        Local $h = $list[$i][1]
        If WinGetProcess($h) = $pid Then
            If BitAND(WinGetState($h), 2) Then
                Return $h
            EndIf
        EndIf
    Next
    Return 0
EndFunc

Func WaitForWindowByPid($pid, $timeoutMs)
    Local $t = TimerInit()
    While TimerDiff($t) < $timeoutMs
        Local $h = FindWindowByPid($pid)
        If $h <> 0 Then
            Return $h
        EndIf
        Sleep(200)
    WEnd
    Return 0
EndFunc

Func FindWindowByTitleAndPid($titleRegex, $pid)
    Local $list = WinList()
    For $i = 1 To $list[0][0]
        Local $title = $list[$i][0]
        Local $h = $list[$i][1]
        If $title <> "" And WinGetProcess($h) = $pid Then
            If StringRegExp($title, $titleRegex) Then
                Return $h
            EndIf
        EndIf
    Next
    Return 0
EndFunc

Func FindWindowByTitleRegex($titleRegex)
    Local $list = WinList()
    For $i = 1 To $list[0][0]
        Local $title = $list[$i][0]
        Local $h = $list[$i][1]
        If $title <> "" Then
            If StringRegExp($title, $titleRegex) Then
                Return $h
            EndIf
        EndIf
    Next
    Return 0
EndFunc

Func WaitForWindowByTitleAndPid($titleRegex, $pid, $timeoutMs)
    Local $t = TimerInit()
    While TimerDiff($t) < $timeoutMs
        Local $h = FindWindowByTitleAndPid($titleRegex, $pid)
        If $h <> 0 Then
            Return $h
        EndIf
        Sleep(200)
    WEnd
    Return 0
EndFunc

Func CloseErrorDialogs($pid)
    Local $list = WinList()
    For $i = 1 To $list[0][0]
        Local $title = $list[$i][0]
        Local $h = $list[$i][1]
        If $title <> "" Then
            If StringRegExp($title, "(?i)(エラー|Error|錯誤)") Then
                If $pid = 0 Or WinGetProcess($h) = $pid Then
                    WinActivate($h)
                    Sleep(200)
                    Send("{ENTER}")
                    Sleep(300)
                    Send("!{F4}")
                    LogLine("error_closed:" & $title)
                EndIf
            EndIf
        EndIf
    Next
EndFunc

Func LogWindowsByPid($pid)
    Local $list = WinList()
    For $i = 1 To $list[0][0]
        Local $h = $list[$i][1]
        If WinGetProcess($h) = $pid Then
            Local $title = $list[$i][0]
            Local $state = WinGetState($h)
            LogLine("pid_window:" & $h & ":" & $title & ":state=" & $state)
        EndIf
    Next
EndFunc

LogLine("start")

Local $main = FindWindowByTitleRegex("(?i)HRMS")
Local $pid = 0
If $main <> 0 Then
    $pid = WinGetProcess($main)
    LogLine("reuse_main_window:" & $main & ":pid=" & $pid)
    WinActivate($main)
    Sleep(500)
Else
    LogLine("launching")
    $pid = Run("python HRMS.py", "E:\python_Code\HRMS_PYTHON", @SW_SHOW)
    If $pid = 0 Then
        LogLine("launch_failed")
        Exit 1
    EndIf
    LogLine("launched_pid:" & $pid)

    Local $login = WaitForWindowByTitleAndPid("(?i)(ログイン|Login|登入)", $pid, 20000)
    If $login <> 0 Then
        WinActivate($login)
        Sleep(500)
        LogLine("login_window_title:" & WinGetTitle($login))
        Local $accOk = ControlSetText($login, "", "[CLASS:QLineEdit; INSTANCE:1]", "admin")
        Local $pwdOk = ControlSetText($login, "", "[CLASS:QLineEdit; INSTANCE:2]", "admin123")
        LogLine("login_fields_set:" & $accOk & ":" & $pwdOk)
        If $accOk And $pwdOk Then
            ControlSend($login, "", "[CLASS:QLineEdit; INSTANCE:2]", "{ENTER}")
        Else
            Send("{TAB}admin{TAB}admin123{ENTER}")
        EndIf
    Else
        LogLine("login_window_missing")
        LogWindowsByPid($pid)
    EndIf

    CloseErrorDialogs($pid)

    $main = WaitForWindowByTitleAndPid("(?i)HRMS", $pid, 30000)
    If $main = 0 Then
        LogLine("main_window_timeout")
        LogWindowsByPid($pid)
        Exit 1
    EndIf
    WinActivate($main)
EndIf
LogLine("main_window_ready")

; Employee section (default)
LogLine("employee_basic:" & OpenDialogByClick($main, 0.42, 0.38, "!{F4}"))
WinActivate($main)
LogLine("employee_personal:" & OpenDialogByClick($main, 0.72, 0.38, "!{F4}"))
WinActivate($main)
LogLine("employee_education:" & OpenDialogByClick($main, 0.42, 0.54, "!{F4}"))
WinActivate($main)

; Certify section
ClickRel($main, 0.08, 0.42)
Sleep(500)
LogLine("certify_items:" & OpenDialogByClick($main, 0.42, 0.38, "!{F4}"))
WinActivate($main)
LogLine("certify_tool_map:" & OpenDialogByClick($main, 0.72, 0.38, "!{F4}"))
WinActivate($main)
LogLine("certify_record:" & OpenDialogByClick($main, 0.42, 0.54, "!{F4}"))
WinActivate($main)
LogLine("certify_overdue:" & OpenDialogByClick($main, 0.72, 0.54, "!{F4}"))
WinActivate($main)

; Admin section
ClickRel($main, 0.08, 0.48)
Sleep(500)
LogLine("authority:" & OpenDialogByClick($main, 0.42, 0.38, "!{F4}"))
WinActivate($main)
LogLine("sync_mes_export:SKIP")
WinActivate($main)
LogLine("area_window:" & OpenDialogByClick($main, 0.42, 0.54, "!{F4}"))
WinActivate($main)
LogLine("section_window:" & OpenDialogByClick($main, 0.72, 0.54, "!{F4}"))
WinActivate($main)
LogLine("job_window:" & OpenDialogByClick($main, 0.56, 0.70, "!{F4}"))
WinActivate($main)

; Reports section
ClickRelYOffset($main, 0.08, 0.54, 10)
Sleep(500)
LogLine("report_training:" & OpenDialogByClick($main, 0.42, 0.38, "!{F4}"))     
WinActivate($main)
Local $reportCustomOk = OpenDialogByClickAndWaitNewWindow($main, $pid, 0.72, 0.38, "!{F4}")
If Not $reportCustomOk Then
    $reportCustomOk = OpenDialogByClickAndWaitNewWindow($main, $pid, 0.68, 0.38, "!{F4}")
EndIf
If $reportCustomOk Then
    LogLine("report_custom:True")
Else
    LogLine("report_custom:SKIP")
EndIf
WinActivate($main)

Send("!{F4}")
LogLine("done")
Exit 0
