# Полная проверка: сборка, расчёты и база (тесты xUnit), окна приложения на тестовой базе.
# Журналы и снимки окон — в папке «Проверка», итог — в Проверка\00_ИТОГ.txt. Рабочая база MedTest_Dev не используется.
$ErrorActionPreference = 'Continue'
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
$root = $PSScriptRoot
$logs = Join-Path $root 'Проверка'
New-Item -ItemType Directory -Path $logs -Force | Out-Null
$summary = Join-Path $logs '00_ИТОГ.txt'
"Проверка МедТест $(Get-Date -Format 'yyyy-MM-dd HH:mm')" | Out-File $summary -Encoding utf8
if (Get-Command sqllocaldb -ErrorAction SilentlyContinue) { & sqllocaldb start MSSQLLocalDB | Out-Null }
Push-Location $root
$failed = 0
function Step($n, $name, [string[]]$a) {
  $log = Join-Path $logs ("{0:D2}_{1}.txt" -f $n, $name)
  Write-Host "== $n $name"
  & dotnet @a *>&1 | Out-File $log -Encoding utf8
  $code = $LASTEXITCODE
  if ($code -ne 0) { $script:failed++ }
  ("{0:D2} {1}: {2}" -f $n, $name, $(if ($code -eq 0) {'OK'} else {"ОШИБКА (код $code), см. $log"})) | Out-File $summary -Append -Encoding utf8
}
$env:MEDTEST_SHOTS = Join-Path $logs 'screens'
Step 1 'build' @('build','MedTest.slnx','-c','Release','--nologo')
Step 2 'calc-and-database-tests' @('test','tests/MedTest.Tests','-c','Release','--no-build','--logger','console;verbosity=normal')
Step 3 'app-windows' @('run','--project','tests/MedTest.Desktop.Tests','-c','Release','--no-build')
Pop-Location
Get-Content $summary
if ($failed -eq 0) { Write-Host 'Все проверки пройдены. Снимки окон: Проверка\screens' -ForegroundColor Green } else { Write-Host "Не пройдено проверок: $failed. Журналы в папке Проверка." -ForegroundColor Red }
