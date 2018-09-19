#!/bin/sh

# mac
dirname $0 /dev/null
cd `dirname $0`
cd ../../

function clear_folder {
    if [ -e $1 ]; then
        rm -rf $1/*
        echo "清理目录"
        echo $1/*
    fi
}

osx_path=/Users/cc/Documents/eyu/slg/xfiles/number/Tools/Mac64/Osx64
win_path=/Users/cc/Documents/eyu/slg/xfiles/number/Tools/Win64

clear_folder $osx_path
clear_folder $win_path

dotnet publish -c Release -r osx-x64 -o $osx_path /p:TrimUnusedDependencies=true
# dotnet publish -c Release -o $osx_path /p:TrimUnusedDependencies=true
cp -r -p Template/. $osx_path/Template

dotnet publish -c Release -r win-x64 -o $win_path /p:TrimUnusedDependencies=true
cp -r -p Template/. $win_path/Template
