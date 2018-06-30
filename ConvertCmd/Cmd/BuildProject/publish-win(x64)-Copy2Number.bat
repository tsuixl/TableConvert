cd ../../
dotnet publish -c Release -r win-x64 -o Publish\\Win64
xcopy Template Publish\\Win64\\Template /y /e /i
xcopy Publish\\Win64 C:\\Users\\tsuixl\\Documents\\Work\\eyu\\Slg\\xfiles\\number\\Tools\\Win64 /y /e /i
pause