' Use to get path windows folder 
set shell = WScript.CreateObject("WScript.Shell")
' Use to get names of user and computer
set network = WScript.CreateObject("WScript.Network")
windowsdir = SysInfo = "Системные параметры компьютера:" + Chr(10)+ Chr(10)
SysInfo = SysInfo + "Процессоров: " + _
WshSysEnv("NUMBER_OF_PROCESSORS") + Chr(10)
SysInfo = SysInfo + "Архитектура: " + _
WshSysEnv("PROCESSOR_ARCHITECTURE") + Chr(10)
SysInfo = SysInfo + "ID процессора: " + _
WshSysEnv("PROCESSOR_IDENTIFIER") + Chr(10)
SysInfo = SysInfo + "Поколение: " + _
WshSysEnv("PROCESSOR_LEVEL") + Chr(10)
SysInfo = SysInfo + "Операционная система: " + WshSysEnv("OS") + Chr(10)
SysInfo = SysInfo + "Файл командной строки: " + _
WshProEnv("COMSPEC") + Chr(10)
SysInfo = SysInfo + "Пути: " + WshProEnv("PATH") + Chr(10)
SysInfo = SysInfo + "Исполняемые файлы: " + _
            
MsgBox(SysInfo)

strComputer = "."_
Set objWMIService = GetObject("winmgmts:" _
    & "{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")

Set colInstalledPrinters = objWMIService.ExecQuery _
    ("Select * from Win32_Printer")

For Each objPrinter in colInstalledPrinters
    MsgBox("Name: " & objPrinter.Name & vbCRLF & "Default: " & objPrinter.Default) 

    intAnswer = _
    Msgbox("Do you want set this printer as default", _
        vbYesNo, "Set as default: " & objPrinter.Name)
    If intAnswer = vbYes Then
            network.SetDefaultPrinter(objPrinter.Name)
            Msgbox("Printer was set to default")
    Else
    End If
Next

dim nameDrive, remotePath,userName, password, profile 
nameDrive = InputBox("Enter name of network drive")
remotePath = InputBox("Enter remote path")
userName = InputBox("Enter username")
password = InputBox("Enter password")
profile = InputBox("Enter profile(true/false)")


' try catch
On Error Resume Next
    network.MapNetworkDrive nameDrive, remotePath, profile, userName, password

    If Err.Number <> 0 Then
        WScript.Echo Err.Description
        Err.Clear
    End If

On Error Goto 0