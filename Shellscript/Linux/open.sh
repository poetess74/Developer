#!/bin/bash

targetDir=$(wslpath -w $1)
if [ $? != 0 ]; then
    echo "Usage: open <enter absolute path>"
    echo "(ex: open $HOME/Desktop)"
    exit 1
fi

explorer.exe $targetDir
