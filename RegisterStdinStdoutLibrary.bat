@echo off
REM Quick test for Windows generation: UAC aware or not ; all OS before NT4 ignored for simplicity
SET NewOSWith_UAC=YES
VER | FINDSTR /IL "5." > NUL
IF %ERRORLEVEL% == 0 SET NewOSWith_UAC=NO
VER | FINDSTR /IL "4." > NUL
IF %ERRORLEVEL% == 0 SET NewOSWith_UAC=NO


REM Test if Admin
CALL NET SESSION >nul 2>&1
IF NOT %ERRORLEVEL% == 0 (

    if /i "%NewOSWith_UAC%"=="YES" (
        rem Start batch again with UAC
        echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
        echo UAC.ShellExecute "%~s0", "", "", "runas", 1 >> "%temp%\getadmin.vbs"
        "%temp%\getadmin.vbs"
        del "%temp%\getadmin.vbs"
        exit /B
    )

    rem Program will now start again automatically with admin rights! 
    rem pause
    goto :eof
)

REM The actual batch statements that need to be run as administrator start here
@echo on
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\RegAsm %~dp0\FitNesseForDataFlexStdinStdout\bin\Release\FitNesseForDataFlexStdinStdout.dll
@pause