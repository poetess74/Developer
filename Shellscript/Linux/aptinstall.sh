#!/bin/bash

installLoc=~/.local
downloadPath=~/Temp
targetPath=("bin" "etc" "include" "lib" "share")
rmerror=0
inerror=1


function installPath() {
    ls | grep -o "$1" > /dev/null 2>&1
    if [ "$?" == "0" ]; then
        if [ "$1" == "bin" ]; then
            inerror=0
        fi
        mkdir $installLoc/$1/$2
        mv $1/* $installLoc/$1/$2
        rm -rf $1
    fi
}

function uninstall() {
    for ((i=0;i<5;i++)); do
        ls $installLoc/${targetPath[i]}/$1 > /dev/null 2>&1
        if [ "$?" != "0" ]; then
            rmerror=$(($rmerror+1))
        else
            rm -rf $installLoc/${targetPath[i]}/$1 2> /dev/null
        fi
    done
    if [ $rmerror == 5 ]; then
        echo "$1 remove has failed. package has already removed or not installed. "
    else
        rm -f $installLoc/.installed/$1.log
        grep "=\"$installLoc/bin/$1/$1\"" ~/.bashrc > /dev/null 2>&1
        if [ "$?" == 0 ]; then
            echo "$1 remove has successful. You will remove alias $1 package manually. "
        else
            echo "$1 remove has successful."
        fi
    fi
}

function install() {
    cd $downloadPath
    apt download $1
    dpkg -x *.deb $downloadPath
    for ((i=0;i<5;i++)); do
        installPath "${targetPath[i]}" "$1"
    done
    cd $downloadPath/usr
    if [ "$?" == "0" ]; then
        for ((i=0;i<5;i++)); do
            installPath "${targetPath[i]}" "$1"
        done
        cd ..
        rm -rf usr
    fi
    rm -rf $downloadPath/*.deb
    if [ $inerror == 1 ]; then
        echo "$1 package install failed. Uninstalling."
        uninstall $1
    else
        apt show $1 > $installLoc/.installed/$1.log
        grep "alias $1=\"$installLoc/bin/$1/$1\"" ~/.bashrc > /dev/null 2>&1
        if [ "$?" != 0 ]; then
            echo -n "Would you like add $1 to your bashrc file? (Y/n) > "
            read input
            if [ "$input" == "Y" -o "$input" == "y" -o x$input == x ]; then
                echo "alias $1=\"$installLoc/bin/$1/$1\"" >> ~/.bashrc
                alias $1=\"$installLoc/bin/$1/$1\"
                echo -e "Please relogin session or enter command \033[0;1msource ~/.bashrc\033[m to apply package alias. "
                echo "And you will edit call alias or delete if you want. "
            fi
        fi
    fi
}

function helpPrinter() {
    echo "USAGE: $0 [OPTION] [PACKAGE]"
    echo "OPTIONS: "
    echo -e "install: install apt package\n remove: remove apt package"
    echo "   show: print specify installed apt package [--online: print detail apt package using apt server]"
    echo "   list: print local installed apt package [--global: print global & local installed apt package]"
    echo " update: print specify local upgradable package [--global: print global upgradable package]"
    echo "   help: print this message"
}

function aptGlobalList() {
    echo "--- Global install package(s) ---"
    apt --installed list
    aptLocalList
}

function aptLocalList() {
    echo -e "--- Local install package(s) ---"
    echo "Listing... Done"
    ls $installLoc/bin 2> /dev/null
}

if [ "$1" == "help" ]; then
    echo "OVERVIEW: This script manage apt packages in your local. "
    helpPrinter
elif [ "$1" == "install" ]; then
    install "$2"
elif [ "$1" == "remove" ]; then
    uninstall "$2"
elif [ "$1" == "show" -a "$2" == "--online" ]; then
    apt show $3
elif [ "$1" == "--online" -a "$2" == "show" ]; then
    apt show $3
elif [ "$1" == "show" ]; then
    cat $installLoc/.installed/$2.log
elif [ "$1" == "list" -a "$2" == "--global" ]; then
    aptGlobalList
elif [ "$1" == "--global" -a "$2" == "list" ]; then
    aptGlobalList
elif [ "$1" == "list" ]; then
    aptLocalList
elif [ "$1" == "--global" -a "$2" == "update" ]; then
    echo "--- Global upgradable package(s) ---"
    apt --upgradable list
elif [ "$1" == "update" -a "$2" == "--global" ]; then
    echo "--- Global upgradable package(s) ---"
    apt --upgradable list
elif [ "$1" == "update" ]; then
    apt show $2 > $downloadPath/$2.log
    diff $downloadPath/$2.log $installLoc/.installed/$2.log > /dev/null 2>&1
    if [ $? != 0 ]; then
        echo "$2 package has outdated. Would you like upgrade package now? (Y/n) >"
        read input
        if [ "$input" == "n" -o "$input" == "N" ]; then
            echo "Please rerun update manualy."
        else
            uninstall "$2"
            install "$2"
        fi
    else
        echo "$2 package has up to date. "
    fi
    rm $downloadPath/$2.log
elif [ x$1 == x ]; then
    exit 1
else
    echo "Unknown command $1"
    helpPrinter
    exit 1
fi
