#!/bin/sh
dirname $0 /dev/null
cd `dirname $0`
cd ../../
dotnet publish -c Release -r win-x64 -o Publish/Win64 /p:TrimUnusedDependencies=true
# dotnet publish -c Release -o Publish/Osx64 /p:TrimUnusedDependencies=true
cp -r -p Template/. Publish/Win64/Template