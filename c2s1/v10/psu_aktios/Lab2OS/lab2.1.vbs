Set WshShell = WScript.CreateObject("WScript.Shell")
Set WshSysEnv = WshShell.Environment("SYSTEM")
Set WshProEnv = WshShell.Environment("PROCESS")

SysInfo = SysInfo + "Processor: " + _
WshSysEnv("NUMBER_OF_PROCESSORS") + Chr(10)
SysInfo = SysInfo + "Architecture: " + _
WshSysEnv("PROCESSOR_ARCHITECTURE") + Chr(10)
SysInfo = SysInfo + "ID: " + _
WshSysEnv("PROCESSOR_IDENTIFIER") + Chr(10)
SysInfo = SysInfo + "Level: " + _
WshSysEnv("PROCESSOR_LEVEL") + Chr(10)
SysInfo = SysInfo + "OS: " + WshSysEnv("OS") + Chr(10)
SysInfo = SysInfo + "PATH " + WshProEnv("PATH") + Chr(10)
SysInfo = SysInfo + "PathEXT" + _
WshSysEnv("PATHEXT") + Chr(10)
SysInfo = SysInfo + "Windir: " + _
WshProEnv("WINDIR") + Chr(10)
SysInfo = SysInfo + "Temp: " + WshProEnv("TEMP") + Chr(10)
MsgBox SysInfo