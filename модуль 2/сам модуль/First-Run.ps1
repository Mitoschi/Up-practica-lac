param(
    [string]$DatabaseName = 'MedTest_Dev',
    [string]$ServerInstance = '(localdb)\MSSQLLocalDB'
)
$ErrorActionPreference = 'Stop'
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
Write-Host 'МедТест — первый запуск'
Write-Host 'Подготовка базы данных. Если база уже есть, данные и пароли сохраняются.'
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) { throw 'Требуется .NET SDK 10: https://dotnet.microsoft.com/download' }
if (Get-Command sqllocaldb -ErrorAction SilentlyContinue) {
    & sqllocaldb info MSSQLLocalDB *> $null
    if ($LASTEXITCODE -ne 0) { & sqllocaldb create MSSQLLocalDB -s | Out-Null } else { & sqllocaldb start MSSQLLocalDB | Out-Null }
} else { Write-Host 'Внимание: не найдена утилита sqllocaldb. Установите SQL Server Express LocalDB, если подключение не удастся.' }

& dotnet build (Join-Path $PSScriptRoot 'MedTest.slnx') -c Release --nologo -v minimal
if ($LASTEXITCODE -ne 0) { throw 'Не удалось собрать проект.' }
$setup = @('run', '--project', (Join-Path $PSScriptRoot 'tools/MedTest.Setup'), '-c', 'Release', '--no-build', '--', '--server', $ServerInstance, '--database', $DatabaseName)

function Read-Password($title) {
    while ($true) {
        $p1 = Read-Host "$title — пароль (8–128 символов)" -AsSecureString
        $p2 = Read-Host 'Повторите пароль' -AsSecureString
        try {
            $a = [Net.NetworkCredential]::new('', $p1).Password; $b = [Net.NetworkCredential]::new('', $p2).Password
            if ($a.Length -lt 8 -or $a.Length -gt 128) { Write-Host 'Пароль должен содержать от 8 до 128 символов.'; continue }
            if (-not [string]::Equals($a, $b, [StringComparison]::Ordinal)) { Write-Host 'Пароли не совпали. Повторите ввод.'; continue }
            return $a
        } finally { $p1.Dispose(); $p2.Dispose() }
    }
}
function Read-Default($title, $default) { $v = Read-Host "$title [$default]"; if ([string]::IsNullOrWhiteSpace($v)) { $default } else { $v.Trim() } }

$status = & dotnet @setup --status
if ($LASTEXITCODE -ne 0) { throw 'Не удалось подключиться к базе. Проверьте, что установлен SQL Server Express LocalDB.' }
$names = 'MEDTEST_ADMIN_LOGIN','MEDTEST_ADMIN_PASSWORD','MEDTEST_ADMIN_NAME','MEDTEST_DOCTOR_LOGIN','MEDTEST_DOCTOR_PASSWORD','MEDTEST_DOCTOR_NAME'
$saved = @{}; foreach ($n in $names) { $saved[$n] = [Environment]::GetEnvironmentVariable($n) }
try {
    if ($status -contains 'ADMIN_MISSING') {
        Write-Host ''; Write-Host 'Создание администратора (справочники, нормы показателей, сотрудники).'
        $env:MEDTEST_ADMIN_LOGIN = Read-Default 'Логин администратора' 'admin'
        $env:MEDTEST_ADMIN_NAME = Read-Default 'ФИО администратора' 'Администратор'
        $env:MEDTEST_ADMIN_PASSWORD = Read-Password 'Администратор'
    } else { Write-Host 'Администратор уже есть, его пароль не изменён.' }
    if ($status -contains 'DOCTOR_MISSING') {
        Write-Host ''; Write-Host 'Создание врача (пациенты, ввод показателей, карты).'
        $env:MEDTEST_DOCTOR_LOGIN = Read-Default 'Логин врача' 'doctor'
        $env:MEDTEST_DOCTOR_NAME = Read-Default 'ФИО врача' 'Врач'
        $env:MEDTEST_DOCTOR_PASSWORD = Read-Password 'Врач'
    } else { Write-Host 'Врач уже есть, его пароль не изменён.' }
    $extra = @()
    $answer = Read-Host 'Добавить примеры: 36 пациентов с обследованиями, чтобы статистика и графики были видны сразу? [Д/н]'
    if ($answer -notmatch '^(н|n)') { $extra = @('--sample') }
    & dotnet @setup @extra
    if ($LASTEXITCODE -ne 0) { throw 'Настройка базы завершилась с ошибкой.' }
} finally { foreach ($n in $names) { [Environment]::SetEnvironmentVariable($n, $saved[$n]) } }
Write-Host ''
Write-Host 'Готово. Запускайте Открыть_приложение.cmd.'
Write-Host 'Пароли хранятся в базе только как PBKDF2-SHA256 с индивидуальной солью.'
