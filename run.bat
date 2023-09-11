@echo off
echo Building and running .NET and Angular applications

cd MagniFinanceTest.Angular
echo Installing Angular dependencies
call npm install
echo Starting Angular application
START npm run start

echo Checking if dotnet-ef tool is installed
dotnet tool list -g | findstr /C:"dotnet-ef" > nul

if %errorlevel% NEQ 0 (
    echo Installing dotnet-ef tool
    dotnet tool install --global dotnet-ef
) else (
    echo dotnet-ef tool is already installed.
)

echo Building .NET application
cd ../MagniFinanceTest.API
dotnet build
echo Creating Database and initializing seed data
dotnet ef database update

echo Running .NET application
cd ../MagniFinanceTest.API
dotnet run