# -*- coding: <ISO-2022-JP> -*-

import os
import os.path
import sys
import signal
import time
import random
import platform

######################################################
#Value Start
######################################################
classStudent = 0
picker = 0
picker1 = 0
result = []
inputnum = 0

######################################################
#Souce Code Start
######################################################
def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')

def signalHandler(signal, frame):
    print("キーボード入力")
    time.sleep(0.5)
    sys.exit(0)

######################################################
try:
    signal.signal(signal.SIGINT, signalHandler)
    clearScreen()
    print("初期化中...", end="", flush=True)
    time.sleep(5)
    print(" - 完了")
    time.sleep(1)
    clearScreen()
    while True:
        result = []
        picker = 0
        if classStudent <= 1:
            print("全学生数の入力", end="", flush=True)
            classStudent = int(input(" : "))
        print("選出する学生数の入力", end="", flush=True)
        picker = int(input(" : "))
        if classStudent <= 1:
            print("エラー：全体生徒数が1よりも小さいかです。")
            time.sleep(5)
            clearScreen()
            continue
        if picker <= 0:
            print("エラー：選出する学生数が0よりも小さいかです。")
            print("全体生徒数「%d」を変更するには「1」を入力するか、" % (classStudent))
            print("続行するには、エンターキーを押してください。")
            inputkey = input("#]")
            if inputkey == '1':
                clearScreen()
                classStudent = 0
                continue
            else:
                clearScreen()
                continue
            clearScreen()
            continue
        if classStudent <= picker:
            print("エラー：生徒数「%d」が選出「%d」することができ、より小さいかです。" % (classStudent, picker))
            print("全体生徒数を変更するには「1」を入力するか、")
            print("続行するには、エンターキーを押してください。")
            inputkey = input("#]")
            if inputkey == '1':
                clearScreen()
                classStudent = 0
                continue
            else:
                clearScreen()
                continue
            clearScreen()
            continue
        picker1 = picker
        while picker1 <= picker and picker1 != 0:
            result.append(random.randrange(1, classStudent + 1))
            result = list(set(result))
            picker1 = picker - len(result)
            result.sort()
        clearScreen()
        time.sleep(0.2)
        print("%d人選出が完了しました。" % (picker))
        print("選出番号： ", end="", flush=True)
        print(result)
        time.sleep(1)
        print("続行するには、エンターキーを押してください。")
        inputkey = input("")
        if inputkey == "":
            clearScreen()
            continue
 
except EOFError:
    print("^Dキーボード入力")
    time.sleep(0.5)
    sys.exit(0)

except ValueError:
    print("数字のみ入力可能です。")
    time.sleep(0.5)
    sys.exit(-1)
