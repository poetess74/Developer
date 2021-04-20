#-*- coding: utf-8 -*-
import time
import sys

temp = ''
err = 0

# 수정 가능 변수 시작
Range    = 5    # LN 9] 반복 횟수 -1 
count    = 1    # LN A] 시작 세포수
after    = 6    # LN B] 분열 후 지연 시간
copy     = 7    # LN C] 복제기 지연시간
before   = 2    # LN D] 분열 전 지연 시간
division = 1    # LN E] 분열기 지연시간
# 수정 가능 변수 종료

print("다음 조건이 맞는지 확인하십시오. (y/N)")
print("반복 횟수 : "),
print(Range - 1)
print("시작 세포수 : "),
print(count)
print("분열 후 생장기 지연 시간 : "),
print(after)
print("DNA 복제기 지연 시간 : "),
print(copy)
print("분열 전 생장기 지연 시간 : "),
print(before)
print("분열기 지연시간 : "),
print(division)

temp = raw_input("#] ")
temp = temp.lower().encode('utf8')
if temp == 'y':
    pass
else:
    print("스크립트의 수정 가능 변수를 참조하시기 바랍니다.")
    time.sleep(2)
    sys.exit(1)

if Range <= 1:
    print("ERR (LN 9): 범위를 벗어납니다.")
    err = err + 1
if count <= 0:
    print("ERR (LN A): 세포가 0개 이하일 수는 없습니다.")
    err = err + 1
if after < 0:
    print("ERR (LN B): 지연 시간이 음수일 수는 없습니다.")
    err = err + 1
if copy < 0:
    print("ERR (LN C): 지연 시간이 음수일 수는 없습니다.")
    err = err + 1
if before < 0:
    print("ERR (LN D): 지연 시간이 음수일 수는 없습니다.")
    err = err + 1
if division < 0:
    print("ERR (LN E): 지연 시간이 음수일 수는 없습니다.")
    err = err + 1
if err > 0:
    print("=============== 결과 ===============")
    print("스크립트 실행중 오류가 "),
    print(err),
    print("개 발생하였습니다.")
    time.sleep(2)
    sys.exit(-1)

start = time.time()
for i in range (1, Range):
    print("=============== "),
    print(i),
    print("회 ===============")
    print("분열 후 생장기")
    time.sleep(after)
    print("DNA 복제기")
    time.sleep(copy)
    print("분열 전 생장기")
    time.sleep(before)
    print("분열기")
    time.sleep(division)
    count = count * 2 
    print("세포수가 "),
    print(count),
    print("개가 되었습니다.")

end = time.time() - start
print("=============== 결과 ===============")
print("세포 주기 : "),
print(i),
print("회")
print("지연 시간 : "),
print(end)
print("세 포  수 : "),
print(count),
print("개")
