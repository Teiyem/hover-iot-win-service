cd /d "%~dp0"

@echo off

echo Starting to uninstall application.

REM Load settings from configuration file.
echo Loading settings from configuration file...

setlocal
set install_conf=.\install.conf
if exist %install_conf% (
    for /f "delims=" %%x in (%install_conf%) do set "%%x"
) else (
    echo Configuration file not found. Exiting...
    exit /b 1
)

echo Create Appliaction directory if it doesn't exist.

REM Create Application directory if it doesn't exist
echo Creating application directory...
if not exist "%app_dir%\%app_name%" (
    mkdir "%app_dir%\%app_name%" || (
        echo Unable to create application directory. Exiting...
        exit /b 1
    )
)

REM Check if the service already exists and delete it.
echo Checking if the service already exists and deleting it.
sc query | findstr %service_name%
if ERRORLEVEL 0 (
    sc stop %service_name%
    sc delete %service_name%
)

REM Build and publish the application.
echo Building and publishing application...
cd ..
dotnet publish "%app_name%\%app_name%.csproj" -c Release -r win-x64 --output "%app_dir%\%app_name%" --self-contained || (
    echo Failed to build and publish application. Exiting...
    exit /b 1
)

REM Set permissions on application directory.
echo Setting permissions on application directory...
icacls "%app_dir%\%app_name%" /grant:r "NT AUTHORITY\SYSTEM:(OI)(CI)F"
icacls "%app_dir%\%app_name%" /grant:r "BUILTIN\Administrators:(OI)(CI)F"
icacls "%app_dir%\%app_name%" /grant:r "%USERNAME%:(OI)(CI)F"

REM Create Windows service
echo Creating Windows service...
sc create %service_name% binpath="%app_dir%\%app_name%\%app_name%.exe" DisplayName="%service_display_name%" start=auto || (
    echo Failed to create Windows service. Exiting...
    exit /b 1
)

REM Start the service
echo Starting service...
net start %service_name% || (
    echo Failed to start Windows service. Exiting...
    exit /b 1
)

echo Successfully installed Hover Windows Service Application.
Pause