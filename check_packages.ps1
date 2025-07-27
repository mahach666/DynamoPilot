# Скрипт для проверки копирования пакетов
Write-Host "Проверка копирования пакетов..." -ForegroundColor Green

$pilotIcePath = "$env:LOCALAPPDATA\ASCON\Pilot-ICE Enterprise\Development\DynamoPilot.App\packages"
$pilotBimPath = "$env:LOCALAPPDATA\ASCON\Pilot-BIM\Development\DynamoPilot.App\packages"

Write-Host "`nПроверка Pilot-ICE Enterprise:" -ForegroundColor Yellow
if (Test-Path $pilotIcePath) {
    Write-Host "  Папка существует: $pilotIcePath" -ForegroundColor Green
    $packages = Get-ChildItem $pilotIcePath -Directory
    Write-Host "  Найдено пакетов: $($packages.Count)" -ForegroundColor Green
    
    foreach ($pkg in $packages) {
        Write-Host "    - $($pkg.Name)" -ForegroundColor Cyan
        $binPath = Join-Path $pkg.FullName "bin"
        if (Test-Path $binPath) {
            $files = Get-ChildItem $binPath -File
            Write-Host "      Файлов в bin: $($files.Count)" -ForegroundColor Gray
            foreach ($file in $files) {
                Write-Host "        $($file.Name)" -ForegroundColor Gray
            }
        } else {
            Write-Host "      Папка bin не найдена!" -ForegroundColor Red
        }
    }
} else {
    Write-Host "  Папка не существует: $pilotIcePath" -ForegroundColor Red
}

Write-Host "`nПроверка Pilot-BIM:" -ForegroundColor Yellow
if (Test-Path $pilotBimPath) {
    Write-Host "  Папка существует: $pilotBimPath" -ForegroundColor Green
    $packages = Get-ChildItem $pilotBimPath -Directory
    Write-Host "  Найдено пакетов: $($packages.Count)" -ForegroundColor Green
    
    foreach ($pkg in $packages) {
        Write-Host "    - $($pkg.Name)" -ForegroundColor Cyan
        $binPath = Join-Path $pkg.FullName "bin"
        if (Test-Path $binPath) {
            $files = Get-ChildItem $binPath -File
            Write-Host "      Файлов в bin: $($files.Count)" -ForegroundColor Gray
            foreach ($file in $files) {
                Write-Host "        $($file.Name)" -ForegroundColor Gray
            }
        } else {
            Write-Host "      Папка bin не найдена!" -ForegroundColor Red
        }
    }
} else {
    Write-Host "  Папка не существует: $pilotBimPath" -ForegroundColor Red
}

Write-Host "`nПроверка завершена." -ForegroundColor Green 

Write-Host "=== Проверка файлов пакета PilotNodes ===" -ForegroundColor Green

# Пути для проверки
$paths = @(
    "C:\Users\maxah\AppData\Local\ASCON\Pilot-ICE Enterprise\Development\DynamoPilot.App\packages\PilotNodes",
    "C:\Users\maxah\AppData\Local\ASCON\Pilot-BIM\Development\DynamoPilot.App\packages\PilotNodes",
    "C:\Users\maxah\source\repos\DynamoPilot\src\bin\Debug\net481\Dynamo\packages\PilotNodes"
)

foreach ($path in $paths) {
    Write-Host "`nПроверяем: $path" -ForegroundColor Yellow
    
    if (Test-Path $path) {
        Write-Host "  ✓ Папка существует" -ForegroundColor Green
        
        # Проверяем package.json
        $packageJson = Join-Path $path "package.json"
        if (Test-Path $packageJson) {
            Write-Host "  ✓ package.json найден" -ForegroundColor Green
            $content = Get-Content $packageJson -Raw
            Write-Host "  Содержимое package.json:" -ForegroundColor Cyan
            Write-Host $content
        } else {
            Write-Host "  ✗ package.json НЕ найден" -ForegroundColor Red
        }
        
        # Проверяем папку bin
        $binPath = Join-Path $path "bin"
        if (Test-Path $binPath) {
            Write-Host "  ✓ Папка bin существует" -ForegroundColor Green
            
            # Проверяем DLL файлы
            $dlls = Get-ChildItem $binPath -Filter "*.dll"
            foreach ($dll in $dlls) {
                Write-Host "  ✓ Найден: $($dll.Name)" -ForegroundColor Green
            }
        } else {
            Write-Host "  ✗ Папка bin НЕ найдена" -ForegroundColor Red
        }
    } else {
        Write-Host "  ✗ Папка НЕ существует" -ForegroundColor Red
    }
}

Write-Host "`n=== Проверка завершена ===" -ForegroundColor Green 