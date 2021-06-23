#!/bin/bash

bgfile=/tmp/wallpaper.jpg
bgdownloc=https://unsplash.it/2560/1440/?random
pingloc=www.google.com

decodeKey="U2FsdGVkX19aI6PvgJN8EcjsCy2DjiixVfAN1dK6Mdc="
decodePass="P@ssw0rd"
decodeResult=$(echo $decodeKey | openssl enc -aes-256-cbc -a -pbkdf2 -pass pass:$decodePass -d) 

echo $decodeResult | sudo -S echo "null" > /dev/null 2>&1
if [ "$?" != 0 ]; then
    echo -e "\033[31mERR\033[m: Fatal: Please check \033[0;1m$bgfile\033[m permission."
    sudo -k
    exit 1
fi

sudo rm -f $bgfile
while true; do
    ping -c 1 -W 1 -q $pingloc &> /dev/null
    if [ "$?" == "0" ]; then
        wget -O $bgfile $bgdownloc &> /dev/null
        if [ "$?" != "0" ]; then
            continue
        fi
        break
    else
        echo -e "\033[31mERR\033[m: Please check your network connection."
        sleep 2
    fi
done

gsettings set org.gnome.desktop.background picture-uri file://$bgfile &> /dev/null
echo -e "\033[34mOK\033[m: Successfully changed desktop background."
sudo -k
exit 0
