#include <stdio.h>

void discomfortDefine();
void calcDiscomfortKH();
int discomfortIndex(int);
float calcDiscomfort(float, float); 

int main() {
    float temp, humidity, discomfort;
    discomfortDefine();
    printf("\n기온을 입력하여 주십시오(ºC) : ");
    scanf("%f", &temp);
    printf("습도를 입력하여 주십시오(%%) : ");
    scanf("%f", &humidity);
    discomfort = calcDiscomfort(temp, humidity);
    int index = discomfortIndex((int)discomfort);
    switch (index) {
        case 3:
            printf("\n불쾌지수는 %.2f이며 (매우 높음) 입니다. \n\n", discomfort);
            break;
        case 2:
            printf("\n불쾌지수는 %.2f이며 (높음) 입니다. \n\n", discomfort);
            break;
        case 1:
            printf("\n불쾌지수는 %.2f이며 (보통) 입니다. \n\n", discomfort);
            break;
        case 0:
            printf("\n불쾌지수는 %.2f이며 (낮음) 입니다. \n\n", discomfort);
            break;
    }
    calcDiscomfortKH();
    return 0;
}

void discomfortDefine() {
    printf("Copyright © 2009 KMA.All Rights RESERVED.\n");
    printf("정의\n");
    printf("불쾌지수란 기온과 습도의 조합으로 사람이 느끼는 온도를 표현한 것으로 온습도지수(THI)라고도 함\n");
    printf("불쾌지수는 여름철 실내의 무더위의 기준으로서만 사용되고 있을 뿐, 복사나 바람 조건은 포함되어 있지 않기 때문에 유의하여야 함\n");
    printf("개인에 따라 쾌감대의 범위가 다른것처럼 불쾌지수 값에 따라 불쾌감을 느끼는 정도도 개인에 따라 약간의 차이가 있음\n");
}

void calcDiscomfortKH() {
    printf("산출 방법\n");
    printf("참조: https://www.kma.go.kr/images/HELP/basic_new/modify_03.gif\n");
}

int discomfortIndex(int discomfort) {
    printf("\n  단계   지수범위       설명 및 주의사항        현재위치\n");
    if (discomfort >= 80) {
        printf("매우높음  80 이상      전원 불쾌감을 느낌          *\n");
        printf("  높음  75~80 미만    50%%정도 불쾌감을 느낌        \n");
        printf("  보통  68~75 미만   불쾌감을 나타내기 시작함       \n");
        printf("  낮음    68 미만      전원 쾌적함을 느낌           \n");
        return 3;
    } else if (discomfort < 80 && discomfort >= 75) {
        printf("매우높음  80 이상      전원 불쾌감을 느낌           \n");
        printf("  높음  75~80 미만    50%%정도 불쾌감을 느낌       *\n");
        printf("  보통  68~75 미만   불쾌감을 나타내기 시작함       \n");
        printf("  낮음    68 미만      전원 쾌적함을 느낌           \n");
        return 2;
    } else if (discomfort < 75 && discomfort >= 68) {
        printf("매우높음  80 이상      전원 불쾌감을 느낌           \n");
        printf("  높음  75~80 미만    50%%정도 불쾌감을 느낌        \n");
        printf("  보통  68~75 미만   불쾌감을 나타내기 시작함      *\n");
        printf("  낮음    68 미만      전원 쾌적함을 느낌           \n");
        return 1;
    } else {
        printf("매우높음  80 이상      전원 불쾌감을 느낌           \n");
        printf("  높음  75~80 미만    50%%정도 불쾌감을 느낌        \n");
        printf("  보통  68~75 미만   불쾌감을 나타내기 시작함       \n");
        printf("  낮음    68 미만      전원 쾌적함을 느낌          *\n");
        return 0;
    }
}

float calcDiscomfort(float temp, float humidity) {
    return (9/5*temp)-(0.55*(1-humidity/100)*(9/5*temp-26))+32;
}
