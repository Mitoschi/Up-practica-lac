$ErrorActionPreference = 'Stop'
$exe = Join-Path $PSScriptRoot 'src/MedTest.Desktop/bin/Release/net10.0-windows/MedTest.exe'
# Собираем, если программы ещё нет или исходники новее (например, после распаковки новой версии поверх старой).
$sources = Get-ChildItem (Join-Path $PSScriptRoot 'src') -Recurse -File -Include *.cs, *.resx, *.csproj, *.sql |
    Where-Object { $_.FullName -notmatch '\\(bin|obj)\\' }
$stale = -not (Test-Path $exe) -or ($sources | Where-Object { $_.LastWriteTime -gt (Get-Item $exe).LastWriteTime } | Select-Object -First 1)
if ($stale) {
    Write-Host 'Сборка приложения...'
    & dotnet build (Join-Path $PSScriptRoot 'src/MedTest.Desktop') -c Release --nologo -v minimal
    if ($LASTEXITCODE -ne 0) { throw 'Не удалось собрать приложение.' }
}
Start-Process -FilePath $exe -WorkingDirectory (Split-Path $exe)
