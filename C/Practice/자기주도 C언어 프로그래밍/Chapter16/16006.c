#include <stdio.h>

struct data {
    char name[12];
    int height;
    float weight;
} stu[5];

void input() {
    for (int i = 0; i < 5; i++) {
        scanf("%s %d %f", stu[i].name, &stu[i].height, &stu[i].weight);
    }
}

void sort() {
    struct data temp;
    for (int i = 0; i < 4; i++) {
        for (int j = i + 1; j < 5; j++) {
            if (stu[i].height > stu[j].height) {
                temp = stu[i];
                stu[i] = stu[j];
                stu[j] = temp;
            }
        }
    }
}

void output() {
    for (int i = 0; i < 5; i++) {
        printf("%s %d %.1f\n", stu[i].name, stu[i].height, stu[i].weight);
    }
}

int main() {
    input();
    sort();
    output();
    return 0;
}
