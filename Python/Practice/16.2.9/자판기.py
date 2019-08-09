#-*- coding: utf-8 -*-
import sys
keyinput = '0'
reject = 0
extract = 200
money = 0
print("""
        1. 사용 가능한 동전은 ￦500, ￦100, ￦50, ￦10
        2. 편의상 음료 자판기의 지급 버튼은 1개라고 가정

           * 음료 1잔의 가격은 ￦200
           * 음료 지금 버튼이 눌려지면 음료를 지급하고
        \t기억된 돈의 합에서 ￦200원을 감소시키고
        \t남은돈이 ￦200 미만이면 자동으로 돌려준다.
        3. 반환 버튼이 눌려지면 메모리되어 있는 돈
        \t을 고액권 우선으로 돌려준다.
        """)
print("동전을 삽입하십시오...")
print("사용 가능한 동전은 ￦500, ￦100, ￦50, ￦10입니다.")
print("￦ 빼고 입력")
keyinput = input("삽입할 동전 : ")
money = keyinput
if keyinput == 500:
    print("음료 1잔을 구입하시겠습니까? ￦200")
    keyinput = input("구입하시려면 1을 입력하십시오 : ")
    if keyinput == 1:
        reject = (int(money) - int(extract))
        print("거스름돈은 ￦%d입니다." % (reject))
        sys.exit(0)
    else:
        money = 0
        sys.exit(0)
elif keyinput == 100:
    print("음료 1잔을 구입하시겠습니까? ￦200")
    keyinput = input("구입하시려면 1을 입력하십시오 : ")
    if keyinput == 1:
        print("잔액이 부족합니다.")
        money = 0
        sys.exit(0)
    else:
        money = 0
        sys.exit(0)
elif keyinput == 50:
    print("음료 1잔을 구입하시겠습니까? ￦200")
    keyinput = input("구입하시려면 1을 입력하십시오 : ")
    if keyinput == 1:
        print("잔액이 부족합니다.")
        money = 0
        sys.exit(0)
    else:
        money = 0
        sys.exit(0)
elif keyinput == 10:
    print("음료 1잔을 구입하시겠습니까? ￦200")
    keyinput = input("구입하시려면 1을 입력하십시오 : ")
    if keyinput == 1:
        print("잔액이 부족합니다.")
        money = 0
        sys.exit(0)
    else:
        money = 0
        sys.exit(0)
else:
    pass
    sys.exit(-1)
