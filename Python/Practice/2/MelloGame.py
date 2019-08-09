######################################
#이 프로그램은 텍스트 게임입니다.
# Mello Game Beta           Offline
######################################
import os
import sys
import platform
import getpass
import time
import yaml
import random
import math
import signal

up = 0 # 0 : 최신 | 1 : 구버전
breakpoint = 0
breakpointo = 0

gameovernum = 0

pascos = 2
pascom = 0
pascoh = 0
tck = 2

reject = 0
inventory = []
i = 1
temp = 0
reject = 0
inputkey = 0
config = {}
User = {}
username = ''
questlist = ['몹 한마리 죽이기', '상점에서 토큰 충전하기']
questnum = len(questlist)
pharmacy = ['HP + 100', ' HP + 1000', 'HP + 10000', 'MP + 50', 'SP + 100']
weapon = ['공격력', '방어력']
#캐릭터
LV = 1
HP = 50 
fHP = 50
MP = 50
fMP = 50
uHP = 15  #캐릭터가 입히는 데미지
auHP = 15 #같은레밸의 최소 데미지
fuHP = 15 #캐릭터의 최고데미지
money = 0
EXP = 0
fSP = 15
SP = 15
#몹
eLV = 0
eHP = 0
feHP = 0
feMP = 0
eMP = 0
mHP = 0 #몹이 입히는 데미지
poison = 0 # 독 함유량
eEXP = 0 #경험치 증가
class const:
    INFO_DASH = '=' * 49
    WARN_DASH = '=' * 19
    less_INFO = '=' * 20

def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')

def readConfig():
    global config
    stream = open('userdb.dat', 'r')
    config = yaml.load(stream)
    if not 'accounts' in config:
        print("설정파일에 회원정보가 없습니다.")
        print("프로그램을 종료합니다.")
        sys.exit(-1)

def dataupload():
    global gameovernum
    global username
    user = dict(
            ID = ("%s"%(username)),
            data = dict(
                HP = ("%d"%(HP)),
                fHP = ("%d"%(fHP)),
                MP = ("%d"%(MP)),
                fMP = ("%d"%(fMP)),
                SP = ("%d"%(SP)),
                fSP = ("%d"%(fSP)),
                uHP = ("%d"%(uHP)),
                fuHP = ("%d"%(fuHP)),
                auHP = ("%d"%(auHP)),
                EXP = ("%d"%(EXP)),
                money = ("%d"%(money)),
                gameover = ("%d"%(gameovernum))
            )
    )
    with open('userprofiledata.dat', 'w') as outfile:
        outfile.write(yaml.dump(user, default_flow_style=True))
        
def login():
    global username
    clearScreen()
    print("WELCOME TO TEXT GAME!")
    username = input('ID: ')
    password = getpass.getpass("PW: ")
    accounts = config["accounts"]
    if not username in accounts:
        print("ID 또는 비밀번호가 다릅니다.")
        return False

    if accounts[username] != password:
        print("ID 또는 비밀번호가 다릅니다.")
        return False
    return True

def idpwchange():
    global username
    global password
    print("ID를 변경하시려면 1키,  PW를 변경하시려면 2키를 누르십시오.")
    inputkey = input("\n#] ")
    if inputkey == '1':
        print("기능을 준비중 입니다")
        time.sleep(1)
    if inputkey == '2':
        print("기능을 준비중 입니다")
        time.sleep(1)
def mainMenu():
    global pascos
    pascos = 2
    clearScreen()
    print("환영합니다 \'%s\'님" % (username))
    if username == 'test':
        up = 1
        print(const.WARN_DASH, "테스트 계정", const.WARN_DASH)
    print('하실 작업을 선택하십시오.')
    print('''
                q : 퀘스트
                p : 프로필
                f : 결투장...       <준비중>
                o : 설정| 정보      <준비중>
                s : 상점...
                x : 로그아웃
            ''')

    inputKey = input("\n#] ")
    inputKey = inputKey.lower()

    if inputKey == "q":
        clearScreen()
        print(const.less_INFO, "퀘스트", const.less_INFO)
        quest()
    elif inputKey == "p":
        clearScreen()
        print(const.less_INFO, "프로필", const.less_INFO)
        profile()
        time.sleep(10)
    elif inputKey == "f":
        clearScreen()
        print(const.less_INFO, "결투장", const.less_INFO)
        arena()
    elif inputKey == "o":
        clearScreen()
        print(const.less_INFO, "설정| 정보", const.less_INFO)
        option()
    elif inputKey == "s":
        clearScreen()
        print(const.less_INFO, "상점", const.less_INFO)
        shop()
    elif inputKey == "x":
        return False
    else:
        print("명령어를 찾지 못했습니다.")
        print("다시 입력하여 주십시오.")
        time.sleep(2)

def quest():
    global questnum
    if questnum >= 1:
        print("%d개의 퀘스트가 있습니다." % (questnum))
        print(questlist)
        time.sleep(2)
    elif questnum == 0:
        print("퀘스트가 없습니다.")
        time.sleep(1)

def skill():
    print("공격력 : %d / %d | AVG : %d, 방어력 : - / - | AVG : -" %(uHP, fuHP, auHP))
    print("방어력이 보이지 않는 이유는 몹에 따라 방어력 수치가 변경되기 떄문입니다.")
def gameover():
    global gameovernum
    gameovernum = 1
    print("GAME OVER!")
    time.sleep(5)
    print("더이상 게임이 진행 될 수 없습니다.")
    print("게임을 종료합니다.")
    dataupload()
    time.sleep(5)
    clearScreen()
    sys.exit(3)

def profile():
    global LV
    global money
    global HP
    global fHP
    global EXP
    global MP
    global fMP
    global SP
    if username == "test":
        print(const.WARN_DASH, "테스트 계정", const.WARN_DASH)
    print("ID : %s, LV : %d, tc : %d" % (username, LV, money))
#####################################
#Profile 출력 제어문 시작
#####################################
#양수로 변환
    if HP > fHP:
        HP = fHP
    if HP < 0:
        HP = 0
    if EXP < 0:
        EXP = 0
    print("스테미나 : %d / %d, HP : %d / %d, MP : %d / %d, EXP : %s / 100" % (SP, fSP, HP, fHP, MP, fMP, EXP))
    if HP >= 11 and MP >= 11 and SP >= 11:
        print(const.INFO_DASH)
    if HP < 11 or MP < 11 or SP < 11:
        print(const.WARN_DASH, "IMPORTANT", const.WARN_DASH)
    #HP 판별식
    if HP < 11 and HP > 4:
        print("\tHP 가 부족합니다.\t\t\t%d" %(HP))
    if HP < 5 and HP > 0:
        print("\tHP 가 위험수준에 도달하였습니다.\t%d" % (HP))
    if HP == 0:
        print("\tHP 가 없습니다.")
    #MP 판별식
    if MP < 11 and MP > 4:
        print("\tMP 가 부족합니다.\t\t\t%d" % (MP))
    if MP < 5 and MP > 0:
        print("\tMP 가 위험수준에 도달하였습니다.\t%d" % (MP))
    if MP == 0:
        print("\tMP 가 없습니다.")
    if SP < 11 and SP > 4:
    #스테미나 판별식
        print("\t스테미나가 부족합니다.\t\t\t%d" % (SP))
    if SP < 5 and SP > 1:
        print("\t스테미나가 위험수준에 도달하였습니다.\t%d" % (SP))
    if SP == 1 and SP == 0:
        print ("\t스테미나가 없습니다.")
    if HP < 11 or MP < 11 or SP < 11: 
        print(const.INFO_DASH)
    #게임오버 판정
    dataupload()
    if SP < 10 and HP == 0 and MP < 10 and EXP < 10 and money < 10:
        gameover()
#####################################
#Profile 제어문 끝
#####################################
def arena(): #결투장
    global uHP
    global HP
    global eLV
    global feHP
    global feMP
    global mHP
    global eEXP
    global inmoney
    global poison
    global MP
    if SP <= 1:
        print("죄송합니다. 스테미나가 부족하여 결투장에 진입할 수 없습니다.")
        time.sleep(2)
    if HP <= 0:
        print("죄송합니다. HP가 부족하여 결투장에 진입할 수 없습니다.")
        time.sleep(2)
    if HP > 0 and SP > 1:
        print("결투장에 오신것을 환영합니다.")
        print("무작위로 대상을 선택합니다.")
        if LV <= 10:
            eLV = random.randrange(1, 16)
            feHP = random.randrange(50, 80)
            feMP = random.randrange(50, 80)
            mHP = random.randrange(1, 21)
            eEXP = random.randrange(1, 21)
            inmoney = random.randrange(5, 20)
            poison = random.randrange(0, 6)
            if uHP >= poison:
                uHP = (uHP - poison)
            if HP >= poison:
                HP = (HP - poison)
            if MP >= poison:
                MP = (MP - poison)
            clearScreen()
            fighting()
        else:
            print("랭크를 준비중입니다.")
    time.sleep(1)

def Fight():
    print("하실 작업을 선택하십시오")
    print("""
            a : 공격                q : 퀘스트                e : 기권
            o : 설정<준비중>        p : 프로필
            """)
def fighting():
    global i
    global HP
    global SP
    global EXP
    global money
    global reject
    global temp
    i = 1
    while i == 1:
        print("당신은 이 몬스터와 결투하게 됩니다.")
        print("LV : %d, HP : %d, MP : %d" % (eLV, feHP, feMP))
        print("데미지 : %d" % mHP)  # 디버그
        eHP = feHP
        eMP = feMP
        Fight()
        inputkey = input("\n#] ")
        result = inputkey.lower()
        if "e" == inputkey:
            print("정말로 기권하시겠습니까?")
            print("기권하실 경우 스테미나가 4개 감소합니다.")
            print("기권하실려면 \'1\'키, 계속하시려면 \'2\'키를 누르십시오.")
            inputkey = input("\n#] ")
            if "1" == inputkey:
                if SP >= 4:
                    print("기권 요청을 완료하였습니다.")
                    SP = (SP - 4)
                    reject = 1
                    time.sleep(2)
                    i = 0
                else:
                    print("기권을 완료할 수 없습니다.")
                    time.sleep(2)
                    clearScreen()
                    continue
            if "2" == inputkey:
                clearScreen()
                continue
        if "p" == result:
            clearScreen()
            profile()
            time.sleep(5)
            clearScreen()
            continue
        if "q" == result:
            clearScreen()
            quest()
            time.sleep(5)
            clearScreen()
            continue
        if "o" == result:
            clearScreen()
            print("기능을 준비중입니다.")
            time.sleep(1)
            clearScreen()
            continue
        if "a" == result:
            clearScreen()
            temp = 1
            while eHP > 0 or HP > 0:
                time.sleep(0.5)
                print("진행상황 | %d회 진행중..." % temp)
                if eMP > feMP:
                    eMP = feMP
                if HP <= 0:
                    pass
                else:
                    eHP = (eHP - uHP)
                print("몬스터 HP : %d / %d, MP : %d / %d" % (eHP, feHP, eMP, feMP))
                if eHP <= 0:
                    pass
                else:
                    HP = (HP - mHP)
                    temp = (temp + 1)
                    print("캐릭터 HP : %d / %d, MP : %d / %d" % (HP, fHP, MP, fMP))
                if HP <= 0 or eHP <= 0:
                    if HP <= 0:
                        print("\t캐릭터가 죽었습니다.")
                        i = 0
                        if SP <= 2:
                            print("스테미나가 부족합니다.")
                            clearScreen()
                            profile()
                            time.sleep()
                            break
                        else:
                            SP = SP - 2
                        if EXP <= 0:
                            EXP = 0
                        else:
                            EXP = EXP - round(eEXP / 2)
                        time.sleep(0.2)
                        print("\t\t결투가 종료되었습니다.")
                        time.sleep(10)
                        clearScreen()
                        profile()
                        time.sleep(10)
                        break
                    else:
                        if eHP <= 0:
                            print("\t몬스터가 죽었습니다.")
                            time.sleep(0.2)
                            print("\t\t결투가 종료되었습니다.")
                            time.sleep(10)
                            clearScreen()
                            i = 0
                            EXP = EXP + eEXP
                            SP = SP - 2
                            money = (money + inmoney)
                            if EXP >= 100:
                                levelup()
                            else:
                                clearScreen()
                                profile()
                                time.sleep(10)
                            break
                        else:
                            print("스테미나가 부족합니다.")
                            time.sleep(10)
                            levelup()
                            clearScreen()
                            if EXP != 0:
                                profile()
                            time.sleep(10)
                            break
                        continue

def signalHandler(signal, frame):
    print(" 키를 눌렀습니다.")
    sys.exit(0)

def verCheck():
    global up
    global breakpoint
    global breakpointo
    if up != 1:
        pass
    if up == 1:
        print("새로운 버전이 있습니다. 업데이트를 해주시기 바랍니다.")
        breakpoint = (breakpoint + 1)
        breakpointo = (20 - breakpoint)
        if breakpointo > 0:
            print("프로그램 종료까지 %d회 남음." % (breakpointo))
        else:
            print("지금 프로그램이 종료되려고 합니다.")
        time.sleep(5)
        clearScreen()
        if breakpoint == 20:
            print("보안문제로 프로그램을 종료합니다.")
            print("다시 실행하여 게임을 계속하거나 업데이트를 진행하십시오.")
            time.sleep(5)
            clearScreen()
            sys.exit(-1)
 
def levelup():
    global EXP
    global SP
    global HP
    global LV
    global MP
    global uHP
    global auHP
    global fuHP
    global fSP
    global money
    global fMP
    global fHP
    if EXP >= 100 and LV < 200:
        clearScreen()
        if EXP > 100:
            EXP = (EXP - 100)
        else:
            EXP = 0
        fSP = (fSP + 1)
        SP = fSP
        auHP = (auHP + 2)
        fuHP = (fuHP + 2)
        uHP = fuHP
        LV = (LV + 1)
        fHP = (fHP + 2)
        HP = fHP
        fMP = (fMP + 2)
        MP = fMP
        money = (money + 10)
        print(const.less_INFO, "LEVEL UP", const.less_INFO)
        profile()
        time.sleep(10)

def option():
    global username
    print("""
                1 : ID/PW 변경          <준비중>
                2 : 게임 정보 보기      <80초 소요>
                3 : 업데이트 확인       <준비중>
                4 : 프로그램 종료
            """)
    inputkey = input("\n#] ")
    if inputkey == '1':
        clearScreen()
        print(const.less_INFO, "설정", const.less_INFO)
        print("""
                10초후 삭제  |            주의 사항         (20초)1 / 1\n
                1) ID 와 PW 를 변경하는 도중 잘 못 입력하였을 경우 찾을
                   방법이 없습니다.

                2) PW 는 남들이 추측하기 힘든 비밀번호를 사용하십시오.

                3) userdb.dat 파일을 절대 지우지 마십시오. 지울 경우 로
                   그인이 일체 되지 않습니다.
            """)
        time.sleep(10)
        clearScreen()
        idpwchange()
        time.sleep(2)
    elif inputkey == '2':
        clearScreen()
        print(const.less_INFO, "정보", const.less_INFO)
######################################
#HELP 시작
######################################
        print("""
                 30초후 삭제  | BETA    프로그램 정보   BETA (80초)1 / 3\n
                 1) MelloGame 을 불법적으로 다운 받았을 경우 무결성`이 
                    없어질 가능성이 있습니다. 정품 사용을 생활화 합시
                    다.

                 2) 이 프로그램은 텍스트 게임으로 뛰어난 그래픽과 연산능
                    력이 필요하지 않습니다. 또한 오프라인으로도 진행이 
                    가능합니다.

                 3) 지나친 게임시간은 건강을 해칠 수 있습니다.

                 ` 무결성 | 데이터의 정확성과 일관성을 유지하고 보증하는
                   것을 가리킨다. (출처 - 위키백과, 우리 모두의 백과사전)
                 """)
        time.sleep(30)
        clearScreen()
#        print(const.less_INFO, "정보", const.less_INFO)
        print("""
                 30초후 삭제  | BETA    프로그램 정보   BETA (80초)2 / 3\n
                 4) 핵심 파일을 지우지 마시기 바랍니다. [.dat 파일]
                    [파일 이름 : userdb.dat | userprofiledata.dat (2개)]
                             사용자 신상정보 | 사용자 프로파일 <ex : HP>

                 5) 이 프로그램은 베타버젼이며 지정된 개발자만 사용가능
                    하며, 인터넷에서 다운 받았을 경우 무결성을 보장할 수
                    없습니다.

                 6) 최적의 명령프롬프트(cmd) / 터미널의 해상도는 90 X 18
                    입니다.                                   가로 X 세로
                       이 앱의 정보가 끝났습니다.
                 """)
        time.sleep(25)
        clearScreen()
#        print(const.less_INFO, "정보", const.less_INFO)
        print("""
                20초후 삭제  | BETA    프로그램 접근   BETA (80초)3 / 3\n
                    이 프로그램은 아래 나열한 곳에 접근할 수 있습니다.

                1) 사용자 플랫폼 : 버퍼를 깨끗이 청소하려면 사용자의 플
                                   랫홈에 맞춰서 명령해야 합니다.

                2) 로켤 디스크 : 이 소스코드와 같이 있는 .dat 파일에 접
                                 근하기 위해선 로켤디스크에 접근해야 합
                                 니다.

                    이 앱의 접근 목록이 끝났습니다.
                """)
        time.sleep(20)
    elif inputkey == '3':
        clearScreen()
        print("""
                10초후 삭제  |            약관 동의         (20초)1 / 1\n
                  다음 약관에 동의 하시면 업데이트 확인이 가능합니다.

                √ 프로그램 버전 개발자에 알리는데 동의

                √ 사용자의 운영체제 및 버전을 개발자에 알리는데 동의

                √ 충돌 데이터를 개발자에 공유하는데 동의

                위 사항을 모두 동의할 경우 1키 동의하지 않을경우 2키를
                눌러주세요.
                """)
        print("기능을 준비중입니다.")
        time.sleep(1)
    elif inputkey == '4':
        print("프로그램을 즉시 종료합니다.")
        time.sleep(1)
        clearScreen()
        sys.exit(-1)
######################################
# HELP 끝
######################################
def shop():
    clearScreen()
    global HP
    global MP
    global money
    global SP
    global EXP
    global fuHP
    global eMP
    global uHP
    print("구입하실 목록을 선택하여 주십시오.")
    print("약품 (1), 무기구 (2) me구입 (3) | 가진 tc : %dtc" % (money))
    inputkey = input("\n#] ")
    if '1' == inputkey:
        profile()
        print(pharmacy)
        print("구입하실 목록을 숫자로 선택하여 주십시오")
        print("왼쪽부터 1 ~ 5")
        print("이는 즉시 적용됩니다.")
        inputkey = input("\n#] ")
        if '1' == inputkey:
            print("HP + 100을 선택하셨습니다.")
            if money >= 10:
                print("HP가 100 회복 됩니다.")
                HP = HP + 100
                money = (money - 10)
                if HP >= fHP:
                    HP = fHP
                time.sleep(2)
            else:
                print("tc가 부족합니다.")
                time.sleep(2)
        if '2' == inputkey:
            print("HP + 1000을 선택하셨습니다")
            if money >= 20:
                print("HP가 1,000회복 됩니다.")
                HP = HP + 1000
                money = (money - 20)
                if HP >= fHP:
                    HP = fHP
                time.sleep(2)
            else:
                print("tc가 부족합니다.")
                time.sleep(2)
        if '3' == inputkey:
            print("HP + 10000을 선택하셨습니다")
            if money >= 50:
                print("HP가 10,000 회복 됩니다.")
                HP = HP + 10000
                money = (money - 50)
                if HP >= fHP:
                    HP = fHP
                time.sleep(2)
            else:
                print("tc가 부족합니다.")
                time.sleep(2)
        if '4' == inputkey:
            print("MP + 50을 선택하셨습니다")
            if money >= 30:
                print("MP가 50 회복 됩니다.")
                MP = MP + 50
                money = (money - 30)
                if MP >= fMP:
                    HP = fMP
                time.sleep(2)
            else:
                print("tc가 부족합니다.")
                time.sleep(2)
        if '5' == inputkey:
            print("SP + 100를 선택하셨습니다.")
            if money >= 5:
                print("스테미나가 100회복됩니다.")
                SP = SP + 100
                money = (money - 5)
                if SP >= fSP:
                    SP = fSP
                time.sleep(2)
            elif inputkey != 1 and inputkey != 2 and inputkey != 3 and inputkey != 4 and inputkey != 5:
                print("잘못 입력하셨습니다.\n다시 입력하여 주십시오.")
                time.sleep(5)
                pass
            else:
                print("tc가 부족합니다.")
                time.sleep(2)
    if '2' == inputkey:
        skill()
        print(weapon)
        print("구입하실 목록을 숫자로 선택하여 주십시오\n(시작번호 : 왼쪽부터 1 / 8). 이는 인벤토리에 저장됩니다.")
        inputkey = input("\n#] ")
        if '1' == inputkey:
            print("공격력을 선택하셨습니다.")
            if money >= 50:
                inventory.append('공격력')
                uHP = (uHP + 10)
                fuHP = uHP
                money = (money - 50)
                time.sleep(2)
            else:
                print("tc가 부족합니다")
                time.sleep(2)
        if '2' == inputkey:
            print("방어력를 선택하셨습니다.")
            if money >= 50:
                inventory.append('방어력')
                eMP = (eMP - 10)
                money = (money - 50)
                time.sleep(2)
            else:
                print("tc가 부족합니다")
                time.sleep(2)
        else:
            print("잘못 입력하셨습니다.\n다시 입력하여 주십시오.")
            time.sleep(2)
    if '3' == inputkey:
        clearScreen()
        print("충전하실 돈을 선택하십시오.")
        print("능력치는 결제수단으로 사용됩니다.")
        print("""
            	   1번과 2번만 사용 가능합니다.
                1 : 10 tc       2 : 50  tc
                3 : 100 tc      4 : 500 tc
                5 : 1,000 tc    6 : 5,000 tc
                """)
        inputkey = input("\n#] ")
        print("결제 수단을 선택하십시오.")
        print("""
                1 : HP          2: MP
                3 : 스테미나    4: EXP
              """)
        paykey = input("\n#] ")
        if inputkey == '1':
            print("충전금액 : 10tc")
            print("충전을 시작합니다.")
            if paykey == '1':
                if HP >= 10:
                    HP = (HP - 10)
                    money = (money + 10)
                    print("HP가 10 감소되었습니다")
                else:
                    print("지불 가능한 HP가 없습니다")
                time.sleep(2)
            if paykey == '2':
                if MP >= 10:
                    MP = (MP - 10)
                    money = (money + 10)
                    print("MP가 10 감소되었습니다.")
                else:
                    print("지불 가능한 MP가 없습니다")
                time.sleep(2)
            if paykey == '3':
                if SP >= 10:
                    SP = (SP - 10)
                    money = (money + 10)
                    print("스테미나가 10 감소되었습니다.")
                else:
                    print("지불가능한 스테미나가 없습니다")
                time.sleep(2)
            if paykey == '4':
                if EXP >= 10:
                    EXP = (EXP - 10)
                    money = (money + 10)
                    print("EXP가 10 감소되었습니다.")
                else:
                    print("지불 가능한 EXP가 없습니다")
                time.sleep(2)
        if inputkey == '2':
            print("충전금액 : 50 tc")
            print("충전을 시작합니다.")
            if paykey == '1':
                if HP >= 50:
                    HP = (HP - 50)
                    money = (money + 50)
                    print("HP가 50 감소되었습니다.")
                else:
                    print("지불 가능한 HP가 없습니다.")
                time.sleep(2)
            if paykey == '2':
                if MP >= 50:
                    MP = (MP - 50)
                    money = (money + 50)
                    print("MP가 50 감소되었습니다.")
                else:
                    print("지불 가능한 MP가 없습니다.")
                time.sleep(2)
            if paykey == '3':
                if SP >= 50:
                    SP = (SP - 50)
                    money = (money + 50)
                    print("스테미나가 50 감소되었습니다.")
                else:
                    print("지불가능한 스테미나가 없습니다.")
                time.sleep(2)
            if paykey == '4':
                if EXP >= 50:
                    EXP = (EXP - 50)
                    money = (money + 50)
                    print("EXP가 50 감소되었습니다.")
                else:
                    print("지불 가능한 EXP가 없습니다.")
                time.sleep(2)
#######################################
# 게임 시작
#######################################
readConfig()
while True:
    signal.signal(signal.SIGINT, signalHandler)
    verCheck()
    while not login():
        if pascos < 60:
            print("%d초 후에 재입력 가능합니다."%pascos)
        if pascos >= 60 and pascos < 3600:
            pascom = (pascos/60)
            print("약%d분 후에 재입력 가능합니다."%pascom)
        if pascos >= 3600 and pascos < 86400:
            pascoh = (pascos/3600)
            print("약%d시간 후에 재입력 가능합니다."%pascoh)
        if pascos >= 86400:
            print("보안문제로 프로그램을 즉시 종료합니다.")
            time.sleep(2)
            sys.exit(-1)
        time.sleep(pascos)
        pascos = (pascos * 2)
    while mainMenu():
        pass

    username = ""

