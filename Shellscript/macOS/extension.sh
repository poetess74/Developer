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


if [ $LANG == "ko_KR.UTF-8" ]; then
    echo "MacVim.app 가상본 만드는 중..."
else
    echo "Creating MacVim.app alias..."
fi
if [ "$(uname -m)" == "arm64" ]; then
    if [ "$(which brew)" == "/usr/local/bin/brew" ]; then
        macvimPath=$(find /usr/local/Cellar/macvim -name "MacVim.app")
    else
        macvimPath=$(find /opt/homebrew/Cellar/macvim -name "MacVim.app")
    fi
else
    macvimPath=$(find /usr/local/Cellar/macvim -name "MacVim.app")
fi
if [ "$macvimPath" != "" ]; then
    ln -sF $macvimPath ~/Applications/
    if [ $? == 0 ]; then
        if [ $LANG == "ko_KR.UTF-8" ]; then
            echo "MacVim.app 가상본을 성공적으로 만들었습니다."
        else
            echo "Successfully create MacVim.app alias."
        fi
    else
        if [ $LANG == "ko_KR.UTF-8" ]; then
            echo "MacVim.app 가상본을 만드는데 에러가 발생하였습니다."
        else
            echo "Failed to create MacVim.app alias."
        fi
        errorCount=$((errorCount+1))
    fi
fi

softwareupdate -l
if [ $? != 0 ]; then
    errorCount=$((errorCount+1))
fi

cd ~/Documents/Release/aptall 2> /dev/null
if [ $? == 0 ]; then
    git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
fi

cd ~/Documents/Dev 2> /dev/null
if [ $? == 0 ]; then
    git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
fi

cd ~/Documents/Release/Recruitment-Assistant 2> /dev/null
if [ $? == 0 ]; then
    git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
fi
cd ~/Documents/Release/Timer 2> /dev/null
if [ $? == 0 ]; then
    git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
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
