#include <stdio.h>

int main() {
    int a[5];
    int *p = a;

    for (int i = 0; i < 5; i++) {
        scanf("%d", &*(p + i);
    }

//  scanf("%d %d %d %d %d", &*p, &*(p + 1), &*(p + 2), &*(p + 3), &*(p + 4));

    for (int i = 0; i < 5; i += 2) {
        printf("%d ", *(p + i));
    }

//  printf("%d %d %d\n", *p, *(p + 2), *(p + 4));
    return 0;
}
