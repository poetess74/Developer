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

mas outdated
if [ $? != 0 ]; then
    errorCount=$((errorCount+1))
fi

pipupgrade --latest -y
if [ $? != 0 ]; then
    errorCount=$((errorCount+1))
fi

echo -e "\n\033[0;1mCheck for updates manually for the apps below that use the Sparkle framework.\033[m"
noSuchSparkle="\033[33mWRN\033[m: Sparkle framework not found in"

if [ -d /Applications ]; then
    echo "--- System Applications ---"
    find /Applications -name Sparkle.framework -maxdepth 7 -mindepth 3 1> ~/Library/Logs/find.log 2> /dev/null
    if [ "$(cat ~/Library/Logs/find.log)" == "" ]; then
        echo -e "$noSuchSparkle \033[0;4m/Applications\033[m"
    else
        grep -ioE '.*\.app' ~/Library/Logs/find.log > ~/Library/Logs/find1.log 2>/dev/null
        while read line; do
            appVersion=$(mdls -raw -name kMDItemVersion "$line")
            echo "$line ($appVersion)" >> ~/Library/Logs/find2.log
        done < ~/Library/Logs/find1.log

        nl ~/Library/Logs/find2.log

        rm ~/Library/Logs/find.log ~/Library/Logs/find1.log ~/Library/Logs/find2.log 2> /dev/null
    fi
fi
if [ -d /Volumes/External\ HD/Applications ]; then
    echo -e "\n--- External Applications ---"
    find /Volumes/External\ HD/Applications -name Sparkle.framework  -maxdepth 7 -mindepth 3 1> ~/Library/Logs/find.log 2> /dev/null
    if [ "$(cat ~/Library/Logs/find.log)" == "" ]; then
        echo -e "$noSuchSparkle \033[0;4m/Volumes/External HD/Applications\033[m"
    else
        grep -ioE '.*\.app' ~/Library/Logs/find.log > ~/Library/Logs/find1.log 2>/dev/null
        while read line; do
            appVersion=$(mdls -raw -name kMDItemVersion "$line")
            echo "$line ($appVersion)" >> ~/Library/Logs/find2.log
        done < ~/Library/Logs/find1.log

        nl ~/Library/Logs/find2.log

        rm ~/Library/Logs/find.log ~/Library/Logs/find1.log ~/Library/Logs/find2.log 2> /dev/null
    fi
fi
if [ -d $HOME/Applications ]; then
    echo -e "\n--- User Applications ---"
    find ~/Applications -name Sparkle.framework  -maxdepth 7 -mindepth 3 1> ~/Library/Logs/find.log 2> /dev/null
    if [ "$(cat ~/Library/Logs/find.log)" == "" ]; then
        echo -e "$noSuchSparkle \033[0;4m$HOME/Applications\033[m"
    else
        grep -ioE '.*\.app' ~/Library/Logs/find.log > ~/Library/Logs/find1.log 2>/dev/null
        while read line; do
            appVersion=$(mdls -raw -name kMDItemVersion "$line")
            echo "$line ($appVersion)" >> ~/Library/Logs/find2.log
        done < ~/Library/Logs/find1.log

        nl ~/Library/Logs/find2.log

        rm ~/Library/Logs/find.log ~/Library/Logs/find1.log ~/Library/Logs/find2.log 2> /dev/null
    fi
fi
if [ -d /Volumes/External\ HD$HOME/Applications ]; then
    echo -e "\n--- External User Applications ---"
    find /Volumes/External\ HD$HOME/Applications -name Sparkle.framework  -maxdepth 7 -mindepth 3 1> ~/Library/Logs/find.log 2> /dev/null
    if [ "$(cat ~/Library/Logs/find.log)" == "" ]; then
        echo -e "$noSuchSparkle \033[0;4m/Volumes/External\ HD$HOME/Applications\033[m"
    else
        grep -ioE '.*\.app' ~/Library/Logs/find.log > ~/Library/Logs/find1.log 2>/dev/null
        while read line; do
            appVersion=$(mdls -raw -name kMDItemVersion "$line")
            echo "$line ($appVersion)" >> ~/Library/Logs/find2.log
        done < ~/Library/Logs/find1.log

        nl ~/Library/Logs/find2.log

        rm ~/Library/Logs/find.log ~/Library/Logs/find1.log ~/Library/Logs/find2.log 2> /dev/null
    fi
fi

/bin/zsh -c "source ~/.zshrc; omz update && exit"
if [ $? != 0 ]; then
    errorCount=$((errorCount+1))
fi


if [ $errorCount -gt 0 ]; then
    exit 1
else
    exit 0
fi
