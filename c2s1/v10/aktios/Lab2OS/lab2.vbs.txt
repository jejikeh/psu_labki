' Use to get path windows folder 
set shell = WScript.CreateObject("WScript.Shell")
' Use to get names of user and computer
set network = WScript.CreateObject("WScript.Network")
windowsdir = "Windows folder: " & shell.ExpandEnvironmentStrings("%windir%") & vbCRLF & _
        "Computer name: " & network.ComputerName & vbCRLF  & _
        "Username: " & network.UserName
            
MsgBox(windowsdir)

strComputer = "."
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