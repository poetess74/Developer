#!/bin/bash

decodeKey="U2FsdGVkX1/QcnEakCnE+eo5FIqAzO57YMpvvbUp14U="
decodePass="P@ssw0rd"
decodeResult=$(echo $decodeKey | openssl enc -aes-256-cbc -a -pass pass:$decodePass -d) 

sshconfOrigin=/Users/hm/Library/Scripts/sshd_config
sshconfTarget=/etc/ssh/sshd_config

export LANG=en_US.UTF-8
export LC_ALL=en_US.UTF-8

w
echo ""

echo "$decodeResult" | sudo -S echo "null" &> /dev/null
sudo cp $sshconfOrigin $sshconfTarget

sudo -k
