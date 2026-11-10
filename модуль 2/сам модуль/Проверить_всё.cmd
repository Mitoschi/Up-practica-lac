@echo off
chcp 65001 >nul
setlocal
cd /d "%~dp0"
if not exist "%~dp0Check-All.ps1" goto missing
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0Check-All.ps1" %*
if not "%errorlevel%"=="0" goto failed
echo.
echo Проверка завершена. Итог в папке Проверка.
pause
exit /b 0
:missing
echo Не найден служебный файл Check-All.ps1. Он должен лежать рядом с этим файлом.
:failed
echo.
echo Проверку не удалось запустить.
pause
exit /b 1
