RMDIR /S /Q ..\binaries
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ..\..\src\Relic.sln -t:Clean
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ..\..\src\Relic.sln -p:Configuration=Release

xcopy /Y binaries\*.* Relic\lib

xcopy /Y /S /I ..\..\src\Relic\*.cs Relic\src\Relic
nuget pack Relic/Relic.nuspec -symbols

pause