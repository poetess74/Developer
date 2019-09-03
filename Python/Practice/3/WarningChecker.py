import os
import sys
import platform
import getpass
import time
import random
import math
import signal

userInput = ''
userInputNum = 0
userSex = ''
userAge = 0
userScore = 0
tempInt = 0

###############################
# class 시작
###############################
class const:
    errorMSG = "테스트 참여 조건에 만족하지 않습니다. "

###############################
# class 끝 함수 시작
###############################
def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')

def unexpetectExit():
    print("\n개인정보보호법에 의거하여 다음 시간 후 버퍼 청소 예정...")
    for temp in range(0, 6):
        print(" %d .." % (5 - temp), end="", flush=True)
        time.sleep(1)
    clearScreen()
    sys.exit(-1)

def scoreResult():
    result = ""
    if userScore < 30:
        result = "안전"
    elif userScore < 60:
        result = "보통"
    elif userScore < 90:
        result = "높음"
    else:
        result = "위험"
    print("\n검사가 완료되었습니다. 당신의 음란 마귀 수준은 '%s' 입니다. " % (result))

    print("DEBUG (VAR : userScore): %d" % userScore)

    print("\n개인정보보호법에 의거하여 다음 시간 후 버퍼 청소 예정...")
    for temp in range(0, 6):
        print(" %d .." % (5 - temp), end="", flush=True)
        time.sleep(1)
    clearScreen()

def startMessage():
    clearScreen()
    print("음란 마귀 테스트")
    print("음란 마귀 테스트에 오신것을 환영합니다. \n먼저 참여조건에 만족하는지 확인하는 절차를 거치겠습니다. ")
    print("참여 조건은 테스트가 완료된 후 공개됩니다. ")

def testSuccessful():
    print("음란 마귀 테스트에 적합하신 것으로 보입니다. 그럼 테스트를 시작하겠습니다. ")
    print("\n\n\t\t\t\t* 테스트 조건 *")
    print("키스를 해보았고, 나이가 만 19세에서 40세까지일 경우에 조건 테스트가 통과됩니다. ")

#################################################
# 함수 끝 코드 시작                                     
#################################################
startMessage()
while True:
    userInput = input("\n키스를 해봤다 (y/n) : ")
    if userInput == 'y':
        break
    elif userInput == 'n':
        print(const.errorMSG, "이유 : 진정으로 사랑하는 사랑이 없는것 같음")
        unexpetectExit()
    else:
        print("잘못 입력하셨습니다. ")

userInputNum = int(input("\n참여자의 만 나이 : "))
if userInputNum < 19:
    print(const.errorMSG, "이유 : 청소년 이용불가 콘텐츠임")
    unexpetectExit()
elif userInputNum > 40:
    print(const.errorMSG, "이유 : 아직 성욕이 왕성하다면 건강하십니다. :)")
    unexpetectExit()
userAge = userInputNum

while True:
    userInput = input("\n참여자의 성별 (m/f) : ")
    if userInput == 'm':
        userSex = 'm'
        break
    elif userInput == 'f':
        userSex = 'f'
        break
    else:
        print("잘못 입력하셨습니다. ")

testSuccessful()
while True:
    userInput = input("\n섹스를 해봤다 (y/n) : ")
    if userInput == 'y':
        userScore += 10
        break
    elif userInput == 'n':
        break
    else:
        print("잘못 입력하셨습니다. ")

print("이제부터 성별에 따라 질문이 달라집니다. ")
if userSex == 'm':
    while True:
        userInputNum = int(input("\n자위 횟수 : "))
        if userInputNum > 7:
            userScore += 10
            break
        elif userInputNum > 3 and userInputNum < 8:
            userInputNum += 5
            break
        elif userInputNum < 4:
            break
        else:
            print("잘못 입력하셨습니다. ")
else:
    while True:
        userInput = input("\n자위를 해봤다. (y/n) : ")
        if userInput == 'y':
            userScore += 10
            break
        elif userInput == 'n':
            break
        else:
            print("잘못 입력하셨습니다. ")

scoreResult()
#########################################
# 코드 종료
#########################################
