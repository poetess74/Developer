#include <stdio.h>

int main() {
    int data[] = {78, 34, 52, 15, 63, 15, 25};
    int size, key, found;

    size = sizeof(data) / sizeof(data[0]);
    printf("arr = ");
    for (i = 0; i < size; i++) {
        printf("%d ", data[i]);
    }
    printf("\n");
    printf("find key : ");
    found = 0;
    for (i = 0; i < size; i++) {
        if (data[i] == key) {
            found = 1;
            break;
        }
    }
    if (found) {
        printf("searched index : %d\n", i);
    } else {
        printf("no such find key");
    }
    return 0;
}
