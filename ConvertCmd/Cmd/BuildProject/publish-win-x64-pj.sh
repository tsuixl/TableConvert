#!/bin/sh
dirname $0 /dev/null
cd `dirname $0`
cd ../../
dotnet publish -c Release -r win-x64 -o /Users/cc/Documents/eyu/slg/xfiles/number/Tools/Win64 /p:TrimUnusedDependencies=true
# dotnet publish -c Release -o Publish/Osx64 /p:TrimUnusedDependencies=true
cp -r -p Template/. /Users/cc/Documents/eyu/slg/xfiles/number/Tools/Win64/Template