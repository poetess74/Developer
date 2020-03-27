//Unstable
#include <stdio.h>

struct body {
    char name[12];
    int height;
};

struct body min(struct body array[], int input) {
    struct body mindata = array[0];
    for (int i = 1; i < input; i++) {
        if (mindata.height < array[i].height) {
            mindata = array[i];
        }
    }
    return mindata;
}

int main() {
    struct body name[5], height;
    for (int i = 0; i < 5; i++) {
    }
    height = min(name, 5);
    printf("%s %d\n", height.name, height.height);
    return 0;
}
