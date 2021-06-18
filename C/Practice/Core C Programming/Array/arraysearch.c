#include <stdio.h>

int main() {
    int data[] = {78, 34, 52, 15, 63, 15, 25};
    int size, key;

    size = sizeof(data) / sizeof(data[0]);
    printf("arr = ");
    for (int i = 0; i < size; i++) {
        printf("%d ", data[i]);
    }
    printf("\n");
    printf("search key : ");
    scanf("%d", &key);
    for (int i = 0; i < size; i++) {
        if (data[i] == key) {
            printf("result index : %d\n", i);
        }
    }
    return 0;
}
