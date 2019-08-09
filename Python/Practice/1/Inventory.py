#-*- coding: utf-8 -*-
#이 프로그램은 택스트 게임입니다.

import os
import os.path
import platform
import sys
import signal
import time
import pickle
import random

_History = {
        'memos' : []
        }
loop = 0
temp = 0
inputkey = [0]
money = 100
inventory = [0]
world  = 0
temp1 = 0
store = ['a','b','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t']
def load():
    f = open(const.SAVE_FILE_NAME)
    signal.signal(signal.SIGINT, signalHandler)
    line = f.readlines()
    for line in lines:
        print(line)
    f.close()
def save():
    global _History
    f = open(const.SAVE_FILE_NAME)
def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')
def inputNum(prompt):
    text = input(prompt)
    if text == '':
        return 0
    else:
        return ord(text[0:1]) - ord('0')
def signalHandler(signal, frame):
    print("\n@] ", end="", flush=True)
    time.sleep(0.05)
    print("^C")
    print("Keyboard Interrupt")
    time.sleep(0.5)
    sys.exit(0)
def progressbar():
    print ("[", end="", flush=True);
    while loop == 0:
        global temp
        signal.signal(signal.SIGINT, signalHandler)
        print ("#", end="", flush=True);
        time.sleep(0.5)
        temp += 1
        if temp == 50:
            break
    print("]")
clearScreen()
signal.signal(signal.SIGINT, signalHandler)
print ("WELCOME TO TEXT GAME!")
print ("게임을 로드할때 까지 잠시만 기다려 주세요.")
progressbar()
print("게임 로드 완료. 게임을 실행합니다.")
print("인벤토리에 있는 물건을 확인하시러면 \'I\'를 누르십시오")
print("상점은 \'T\'키를 누르십시오")
print("설정은 \'S\'키를 누르십시오(대/소문자 구별 없음)")
print("명령어에 대한 도움말은 \'H\'키를 누르십시오.")
print("파산하면 게임은 끝나게 됩니다.")
print("처음 지급되는 돈은 100@ 입니다.")
time.sleep(10)
clearScreen()
while True:
    signal.signal(signal.SIGINT, signalHandler)
    temp = 0
    if money > 0:
        store.sort()
        inputkey = input("\n#] ")
        if "" == inputkey:
            temp = 1
            pass
        result = inputkey.lower()
        if "h" == result:
            clearScreen()
            print("""
                    i = 인벤토리
                    t = 상점
                    s = 설정
                    w = 서버
                    h = 도움말
                """)
            temp = 1
        if "i" == result:
            clearScreen()
            if inventory != [0]:
                print(inventory)
            else:
                print("표시할 품목이 없습니다.")
                time.sleep(2)
                clearScreen()
            inputkey = 0
            temp = 1
        if "w" == result:
            clearScreen()
            print("변경할 수 있는 서버 없습니다.")
            time.sleep(2)
            temp = 1
        if "t" == result:
            clearScreen()
            print(store)
            print("구입 할 물건이 있으면 \'1\'키를 누르십시오.")
            inputkey = 0
            inputkey = input("\n%] ")
            if '1' == inputkey:
                inputkey = '0'
                clearScreen()
                print("구입하실 목록을 입력하여 주십시오.")
                print(store)
                inputkey = inputNum("\n$] ")
                store.pop(result)
                inventory.append(result)
                inventory.sort()
            else:
                clearScreen()
            temp = 1
        if "s" == result:
            clearScreen()
            print("\t\t설정")
            print("""
                    1 : 게임 난이도 변경
                    2 : 모든 게임 기록 초기화
                    """)
            inputkey = "0"
            inputkey = input("\n#] ")
            temp = 1
            if "1" == inputkey:
                clearScreen()
                inputkey = 0
                print("게임 난이도 : \"HARD\", HARDER, HARDEST, EXTREME, HELL")
                print("\"<body>\" 는 현재 선택되어 있는 난이도.")
                print("대/소문자 구별없이 입력 가능")
                inputkey = input("\n%] ")
                result = inputkey.lower()
                if "hard" == result:
                    print("이미 선택되어 있는 난이도 입니다.")
                else:
                    print("다른 난이도는 아직 개발중에 있습니다.")
                inputkey = 0
            if "2" == inputkey:
                clearScreen()
                print("""
                        정말로 모든 파일을 지우시겠습니까?
                        해당 파일은 영원히 삭제됩니다...
                        """)
                print("""
                        1 : 삭제
                        2 : 취소
                        """)
                inputkey = 0
                inputkey = input("\n#] ")
                if "1" == inputkey:
                    clearScreen()
                    print("초기화 중입니다 잠시만 기다려 주십시오.")
                    del _History['memos']
                    progressbar()
                    print("게임 기록이 초기화되었습니다.")
                    time.sleep(2)
                    clearScreen()
                    inputkey = "0"
                    print("게임을 종료하시려면 \'1\'키를 누르십시오.")
                    inputkey = input("\n#] ")
                    if "1" == inputkey:
                        clearScreen()
                        sys.exit(0)
                    else:
                        pass
                else:
                    clearScreen()
            if "" == inputkey:
                pass
        else:
            if temp == 0:
                print("명령어를 찾지 못했습니다.")
    else:
        print("파산이므로 게임을 종료합니다.")
        print("게임 통계 로드중...")
        progressbar()
        print("게임 통계 : ")
        load()
        sys.exit(0)
