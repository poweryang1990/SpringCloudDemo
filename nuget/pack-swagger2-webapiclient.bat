@echo off
set path=.
if not [%1]==[] set path=%1

IF NOT EXIST Packages MKDIR Packages

echo Creating Swagger2WebApiClient Package
 %path%\.\NuGet.exe pack %path%\..\Swagger2WebApiClient\Swagger2WebApiClient.csproj -Build -IncludeReferencedProjects -OutputDirectory %path%\Packages -Properties Configuration=Release 

if errorlevel 1 echo Error creating Swagger2WebApiClient Package

pause;