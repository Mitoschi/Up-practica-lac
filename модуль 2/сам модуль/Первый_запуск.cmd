@echo off
chcp 65001 >nul
setlocal
cd /d "%~dp0"
if not exist "%~dp0First-Run.ps1" goto missing
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0First-Run.ps1" %*
if not "%errorlevel%"=="0" goto failed
echo.
echo МедТест: база готова. Запускайте Открыть_приложение.cmd.
pause
exit /b 0
:missing
echo Не найден служебный файл First-Run.ps1. Он должен лежать рядом с этим файлом.
:failed
echo.
echo Не удалось выполнить первый запуск. Сообщение об ошибке приведено выше.
pause
exit /b 1
