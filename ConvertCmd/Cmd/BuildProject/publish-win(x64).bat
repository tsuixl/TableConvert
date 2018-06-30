cd ../../
dotnet publish -c Release -r win-x64 -o Publish\\Win64
xcopy Template Publish\\Win64\\Template /y /e /i
pause