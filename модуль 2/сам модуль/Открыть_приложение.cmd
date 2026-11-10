@echo off
chcp 65001 >nul
setlocal
cd /d "%~dp0"
if not exist "%~dp0Start-App.ps1" goto missing
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0Start-App.ps1" %*
if not "%errorlevel%"=="0" goto failed
exit /b 0
:missing
echo Не найден служебный файл Start-App.ps1. Он должен лежать рядом с этим файлом.
:failed
echo.
echo Не удалось запустить приложение. Подробности выше.
pause
exit /b 1
