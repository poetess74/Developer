#!/bin/bash

errorCount=0

pip3 install --upgrade pip
if [ $? != 0 ]; then
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo "pip3 을 업데이트 하는 도중 에러가 발생하였습니다. "
    else
        echo "An error occured when updating pip3."
    fi
    errorCount=$((errorCount+1))
fi

do-release-upgrade -d
if [ $? != 0 ]; then
    errorCount=$((errorCount+1))
fi

/bin/bash -c "export SKIP_PACKAGE_UPDATER=\"true\"; ~/Documents/Dev/Shellscript/updater.sh"
if [ $? != 0 ]; then
    errorCount=$((errorCount+1))
fi

/bin/zsh -c "source ~/.zshrc; omz update"
echo $!
if [ $? != 0 ]; then
    errorCount=$((errorCount+1))
fi

if [ $errorCount -gt 0 ]; then
    exit 1
else
    exit 0
fi
