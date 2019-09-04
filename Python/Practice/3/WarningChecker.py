import os
import sys
import platform
import getpass
import time
import timeit
import random
import math
import signal

userInput = ''
userInputNum = 0
userSex = ''
userAge = 0
userScore = 0
tempInt = 0

AUTO_RELUNCH = False

###############################
# class 시작
###############################
class const:
    errorMSG = "테스트 참여 조건에 만족하지 않습니다. "
    untrustedAnswer = "신뢰성이 없는 답변"

###############################
# class 끝 함수 시작
###############################
def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')

def autoClearScreen():
    print("\n개인정보보호법에 의거하여 다음 시간 후 버퍼 청소 예정...")
    for temp in range(0, 6):
        print(" %d .." % (5 - temp), end="", flush=True)
        time.sleep(1)
    print(" TIME_OUT")
    clearScreen()


def unexpetectExit():
    global AUTO_RELUNCH
    autoClearScreen()
    if AUTO_RELUNCH == False:
        sys.exit(-1)
    else:
        startMessage()


def scoreResult():
    result = ""
    if userScore < 0:
        result = "현자"
    elif userScore < 20:
        result = "안전"
    elif userScore < 40:
        result = "보통"
    elif userScore < 60:
        result = "높음"
    elif userScore < 80:
        result = "위험"
    else:
        result = "만렙"
    print("\n검사가 완료되었습니다. 당신의 음란 마귀 수준은 '%s' 입니다. " % (result))

    unexpetectExit()

def startMessage():
    clearScreen()
    print("음란 마귀 테스트")
    print("음란 마귀 테스트에 오신것을 환영합니다. \n먼저 참여조건에 만족하는지 확인하는 절차를 거치겠습니다. ")
    print("참여 조건은 테스트가 완료된 후 공개됩니다. ")
    userCheck()

def testSuccessful():
    print("음란 마귀 테스트에 적합하신 것으로 보입니다. 그럼 테스트를 시작하겠습니다. ")
    print("\n\n\t\t\t\t* 테스트 조건 *")
    print("키스를 해보았고, 나이가 만 19세에서 40세까지일 경우에 조건 테스트가 통과됩니다. ")
    testStart()

def userCheck():
    global userScore
    global userAge
    global userSex
    while True:
        userInput = input("\n키스를 해봤다 (y/n) : ")
        if userInput == '':
            continue
        elif userInput == 'y':
            break
        elif userInput == 'n':
            print(const.errorMSG, "이유 : 진정으로 사랑하는 사랑이 없는것 같음")
            unexpetectExit()
        else:
            print("잘못 입력하셨습니다. ")

    while True:
        userInput = input("\n참여자의 성별 (m/f/mtf/ftm) : ")
        if userInput == '':
            continue
        if userInput == 'm':
            userSex = 'm'
            break
        elif userInput == 'f':
            userSex = 'f'
            break
        elif userInput == 'mtf':
            userSex = 'mtf'
            break
        elif userInput == 'ftm':
            userSex = 'ftm'
            break
        else:
            print("잘못 입력하셨습니다. ")

    while True:
        try:
            userInputNum = int(input("\n참여자의 만 나이 : "))
            if userInputNum < 0 or userInputNum > 300:
                raise ValueError
            raise StopIteration 
        except ValueError:
            print("잘못 입력하셨습니다. ")
        except StopIteration:
            break

    if userInputNum < 19:
        print(const.errorMSG, "이유 : 연령 등급 19+ | 상습적인/과격한 성적인 내용 및 노출")
        unexpetectExit()
    elif userInputNum > 40 and (userSex == 'm' or userSex == 'mtf'):
        print(const.errorMSG, "이유 : 아직 성욕이 왕성하다면 건강하십니다. :)")
        unexpetectExit()
    elif userInputNum > 50 and (userSex == 'f' or userSex == 'ftm'):
        print(const.errorMSG, "이유 : 아직 성욕이 왕성하다면 건강하십니다. :)")
        unexpetectExit()

    userAge = userInputNum
    if userAge < 30 and (userSex == 'm' or userSex == 'mtf'):
        userScore += 10
    elif userAge > 40 and (userSex == 'f' or userSex == 'ftm'):
        userScore += 10

    testSuccessful()

def testStart():
    global userScore
    global userSex
    global userAge
    while True:
        userInput = input("\n섹스를 해봤다 (y/n) : ")
        if userInput == '':
            continue
        if userInput == 'y':
            if userSex == 'm' or userSex == 'f':
                userScore += 5
            else:
                userScore += 10
            break
        elif userInput == 'n':
            break
        else:
            print("잘못 입력하셨습니다. ")

    while True:
        userInput = input("\n성인물을 봤다 (y/n) : ")
        if userInput == '':
            continue
        if userInput == 'y':
            if userSex == 'f' or userSex == 'mtf':
                userScore += 10
            else:
                userScore += 5
            break
        elif userInput == 'n':
            while True:
                start = timeit.default_timer()
                userInput = input("정말로 19금 콘텐츠를 한번도 안봤습니까? (y/n) : ")
                if userInput == '':
                    continue
                if userInput == 'y':
                    end = timeit.default_timer()
                    if (end - start) < 1:
                        print(const.untrustedAnswer)
                    if userSex == 'm' or userSex == 'ftm':
                        userScore -= 10
                    else:
                        userScore -= 5
                    break
                elif userInput == 'n':
                    break
                else:
                    print("잘못 입력하셨습니다. ")
            if userInput == 'y':
                break
        else:
            print("잘못 입력하셨습니다. ")

    while True:
        userInput = input("\n자위중 기구 삽입을 해봤다 (y/n) : ")
        if userInput == '':
            continue
        if userInput == 'y':
            if userSex == 'f' or userSex == 'mtf':
                userScore += 5
            elif userSex == 'm' or userSex == 'ftm':
                userScore += 10
            break
        elif userInput == 'n':
            break
        else:
            print("잘못 입력하셨습니다. ")

    print("이제부터 성별에 따라 질문이 달라집니다. ")
    if userSex == 'm' or userSex == 'ftm':
        while True:
            userInput = input("\n한달 이상 사귄 여친이 있거나 있었다 (y/n) : ")
            if userInput == '':
                continue
            if userInput == 'y':
                userScore -= 10
                break
            elif userInput == 'n':
                userScore += 5
                break
            else:
                print("잘못 입력하셨습니다. ")
    elif userSex == 'f' or userSex == 'mtf':
        while True:
            userInput = input("\n한달 이상 사귄 남친이 있거나 있었다 (y/n) : ")
            if userInput == '':
                continue
            if userInput == 'y':
                userScore -= 5
                break
            elif userInput == 'n':
                userScore += 10
                break
            else:
                print("잘못 입력하셨습니다. ")

    if userSex == 'm' or userSex == 'ftm':
        while True:
            try:
                userInputNum = int(input("\n하루 최대 자위 후 사정횟수 : "))
                raise StopIteration
            except ValueError:
                print("잘못 입력하셨습니다. ")
            except StopIteration:
                break

        if userInputNum > 7:
            if userSex == 'm':
                userScore += 10
            else:
                userScore += 15
        elif userInputNum > 3 and userInputNum < 8:
            if userSex == 'm':
                userScore += 5
            else:
                userScore += 10
        elif userInputNum < 4 and userInputNum > 1:
            if userSex == 'ftm':
                userInputNum += 5
    else:
        while True:
            userInput = input("\n자위를 해봤다. (y/n) : ")
            if userInput == '':
                continue
            if userInput == 'y':
                if userSex == 'f':
                    userScore += 5 
                else:
                    userScore += 10
                break
            elif userInput == 'n':
                break
            else:
                print("잘못 입력하셨습니다. ")


    scoreResult()

#################################################
# 함수 끝 코드 시작 
#################################################
startMessage()
########################################
#  코드 종료
########################################
