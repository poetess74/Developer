#-*- coding: utf-8 -*-
print("로드중...")
number = 0
userip = 0
ram= 0
pwe = 0
temp = 0
pwt = 0
tri = 5
memo1 = 0
fndpw = 0
laspwt = 4
disk = 3



def input_num(prompt) :
    return int(input(prompt))
print("초기 패스코드는 \'0000\'입니다.")
while True :
    if pwt > 5:
        if temp == 1:
            print("패스코드를 리셋해야만 합니다.\n백업 패스코드를 입력하기 위해 아무 키나 입력하시거나,\n프로그램을 다시 실행하십시오.")
            if memo1 != 0:
                print("\t프로그램을 다시 실행하면 모든 메모는 영원히 삭제됩니다.")
            ram = input_num("숫자 입력 : ")
            if ram == 1:
                if disk != 0:
                    print("\t\t\t\t남은 횟수 : ", disk)
                else:
                    print("\t\t\t\t남은 횟수 : 없음")
                temp = input_num("백업 패스코드 입력 : ")
                if temp == fndpw:
                    temp = 0
                    pwt = 0
                    laspwt = 4
                    tri = 5
                    disk = 3
                    number = 0
                    print("패스코드를 리셋하였습니다.\'0000\'")
                    if memo1 != 0:
                        print("메모는 그대로 있습니다.")
                else:
                    print("\t<경고> 백업 패스코드가 다릅니다.")
                    laspwt -= 1
                    disk -= 1
                    temp = 0
                    if laspwt == 0:
                        print("\t시도 가능횟수를 초과하였습니다.")
                        number = 0
                        userip = 0
                        ram= 0
                        pwe = 0
                        temp = 0
                        pwt = 0
                        tri = 0
                        disk = 0
                        memo1 = 0
                        fndpw = 0
                        laspwt = 0
                        break
        else:
            if disk != 0:
                print("\t\t\t\t남은 횟수 : ", disk)
            else:
                print("\t\t\t\t남은 횟수 : 없음")
            temp = input_num("백업 패스코드 입력 : ")
            if temp == fndpw:
                temp = 0
                ram = 0
                pwt = 0
                tri = 5
                disk = 3
                laspwt = 4
                number = 0
                print("패스코드를 리셋하였습니다.\'0000\'")
                if memo1 != 0:
                    print("메모는 그대로 있습니다.")
            else:
                print("\t<경고> 백업 패스코드가 다릅니다.")
                disk -= 1
                laspwt -= 1
                temp = 0
                if laspwt == 0:
                    print("\t시도 가능횟수를 초과하였습니다.")
                    number = 0
                    userip = 0
                    ram= 0
                    pwe = 0
                    temp = 0
                    pwt = 0
                    tri = 0
                    disk = 0
                    memo1 = 0
                    fndpw = 0
                    laspwt = 0
                    break
    if  number <= 999 and number >= -999:
        print("오류코드 -2")
        pwe += 1
    if pwt < 6:
        userip = input_num("로그인 패스코드 : ")
        if number == userip:
            print("[########################################################]100.0%")
            pwt = 0
            tri = 5
            if pwe >= 1:
                print("\t\t\t*보안 문제*")
            print("성공적으로 로그인되었습니다.\t\t\t\t\tv0.0.5.2.3a\n\t환영합니다!\n====================설정====================\n숫자 1\t패스코드 변경\n숫자 2\t도움말\n숫자 3\t이 프로그램에 관하여\n숫자 4\t메모장\n숫자 5\t프로그램 종료\n숫자 6\t백업 패스코드 확인\n아무 키\t로그아웃")
            temp = 0
            ram = 0
            pwt = 0
            disk = 3
            tri = 5
            laspwt = 4
            ram = input_num("숫자 입력 : ")
            userip = 0
            if ram == 1:
                ram = 0
                print("====================패스코드 변경====================")
                ram = input_num("기존 패스코드 입력 : ")
                if ram == number:
                    print("패스코드는 \'±999\'보다 절댓값이 크고 정수여야 모든 기능을 사용할수 있습니다.")
                    print("나머지 설명은 도움말 참고")
                    temp = input_num("새로운 패스코드 입력 (4자리 이상) : ")
                    if temp == ram:
                        print("\t<경고>패스코드가 기존 패스코드와 동일합니다.")
                        continue
                    userip = input_num("새로운 패스코드 재입력 : ")
                    if temp != userip:
                        print("재입력한 패스코드가 일치하지 않습니다.\n\t변경사항 없음.")
                        userip = 0
                        temp = 0
                        ram = 0
                    else:
                        number = userip
                        temp = 0
                        print("[########################################################]100.0%")
                        print("패스코드가 정상적으로 바뀌었습니다.")
                        pwe = 0
                        ram = 0
                else:
                    print("\t<경고> 기존 패스코드가 일치하지 않습니다.")            
            if ram == 2:
                print("================================도움말======================================")
                print("\'메모장\' : 이 프로그램의 주요 기능으로서,\n하나의 메모리이지만, 강력한 PIN 보안 기능을\n가지고 있어서 안심하고 사용할 수 있습니다.")
                print("\n\'오류코드 -2\' : 로그인 패스코드가 너무 짧거나, 초기 로그인 패스코드가 설정되어 있는경우, \n\t이 프로그램은 보안 문제에 대해 경고해 줍니다.")
                print("\n\'패스코드\' : 패스코드는 메모를 안전하게 보호할 수 있는 매개체이며,\n\t이는 이 프로그램에서 두번째로 가장 중요한 기능입니다.")
                print("패스코드 설정방법은 \'±999\'보다 절댓값이 크고 정수여야 합니다. \n\t절댓값이 크지 않으면 보안 문제 이벤트가 발생하고, 정수가 아니면")
                print("프로그램이 다운됩니다. 참고로 숫자 0 옆에 있는 \'-\'을 이용해서 음수로 만들 수 있습니다. \n\t(바른 예시 : 1000, -1000, 올바르지 않은 예시 : 0900, 0000, -0450, 1000.99999)")
                print("\n\'백업 패스코드\' : 백업 패스코드는 패스코드를 6회 잘못 입력시 메모를 보존하고\n\t 패스코드만 복구할수 있는 기능입니다.")
                ram = 0
            if ram == 3:
                print("===================이 프로그램에 관하여===================")
                print("이 프로그램은 라이트 사용자를 위한 비밀메모장입니다.")
                print("메모의 저장 위치는 데스크탑(노트북)메모리에 있으며 프로그램을 재실행할 경우\n모든 메모와 설정내역이 지워집니다.")
                print("만든이 : 絹田明日賀 ")
                ram = 0
            if ram == 4:
                if pwe == 0:
                    print("====================메모장====================")
                    ram = 0
                    print("숫자 1\t메모 편집\n숫자 2\t새로 만들기\n숫자 3\t삭제할 메모 선택\n숫자 4\t메모 훓어보기\n아무 키\t상위 메뉴")
                    ram = input_num("숫자 입력 : ")
                    if ram == 1:
                        print("메모 편집")
                        ram = 0
                        if memo1 == 0:
                            print("\t편집할 메모 없음")
                        else:
                            print(memo1)
                            memo1 = input("텍스트 입력 :")
                    if ram ==  2:
                        print("\t새로만들기")
                        memo1 = input("텍스트 입력 : ")
                        ram = 0
                    if ram == 3:
                        print("\t삭제할 메모 선택")
                        ram = 0
                        if memo1 == 0:
                            print("\t삭제할 메모 없음.")
                        else:
                            print("메모를 삭제하시겠습니까? \n해당 메모 : ", memo1)
                            print("\n\t\t메모를 삭제하면 복구가 불가능 합니다.\n숫자 1\t메모 삭제\n아무 키\t상위 메뉴")
                            ram = input_num("숫자 입력 : ")
                            if ram == 1:
                                memo1 = 0
                                print("[########################################################]100.0%")
                                print("메모를 성공적으로 삭제하였습니다.")
                                ram = 0
                    if ram == 4:
                        print("\t메모 훓어보기")
                        ram = 0
                        if memo1 == 0:
                            print("\t메모 없음")
                        else:
                            print(memo1)
                else:
                    print("보안 문제로 인하여 메모장을 실행할 수 없습니다.")
                    print("패스코드를 바꾼후 다시 시도해 주십시오.")
            if ram == 5:
                if memo1 != 0:
                    ram = 0
                    ram = input_num("프로그램을 종료하면 메모가 삭제됩니다.\n그래도 하시겠으면 숫자 1을 입력하십시오 : ")
                    if ram == 1:
                        number = 0
                        userip = 0
                        ram= 0
                        pwe = 0
                        temp = 0
                        pwt = 0
                        tri = 0
                        disk = 0
                        memo1 = 0
                        fndpw = 0
                        laspwt = 0
                        break
                else:
                     break
            if ram == 6:
                 if pwe >= 1:
                    print("보안 문제로 인하여 백업 패스코드를 확인할 수 없습니다.")
                    print("패스코드를 바꾼후 다시 시도해 주십시오.")
                    ram = 0
                    continue
                 else:
                     print("\t백업 패스코드 확인")
                     ram = input_num("확인하시려면 \'1\'을 입력하십시오.")
                     if ram == 1:
                         print("백업 패스코드 : 0000")
                         ram = 0
        else:
            print("[#########################{로그인 실패]#####################]00.00%")
            print("실패 사유 : 잘못된 로그인 패스코드")
            pwt += 1
            if tri != 0:
                print("다시 입력하여 주시기 바랍니다. 만약 패스코드를 까먹었으면\n프로그램을 재실행하거나 백업 패스코드를 요청할때 입력하시기 바랍니다.")
                print("\t\t\t\t남은횟수 : ", tri)
                tri -= 1
                temp  =  1
            else:
                print("\t\t\t\t남은횟수 : 없음")
