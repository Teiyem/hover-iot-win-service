cd /d "%~dp0"

@echo off

echo Starting to uninstall application.

echo Load settings from configuration file.

REM Load settings from install configuration file.
setlocal
set install_conf=.\install.conf
if exist %install_conf% (
    for /f "delims=" %%x in (%install_conf%) do set "%%x"
)

REM Stop the service.
echo Stop the service.
net stop %service_name%

REM Delete the Windows service.
echo Delete the Windows service.
sc delete %service_name%

REM Remove application directory.
echo Remove application directory.
if exist "%app_dir%\%app_name%" (
    rmdir /s /q "%app_dir%\%app_name%"
)

echo Successfully uninstalled Hover Windows Service Application.
Pause