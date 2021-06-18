#include <stdio.h>

int main() {
    int a[3];
    int *pi = a;
    for (int i = 0; i < 3; i++) {
        scanf("%d", &pi[i]);
    }
    for (int i = 0; i < 3; i++) {
        printf("%d ", a[i]);
    }
    printf("\n");

    for (int i = 0; i < 3; i++) {
        scanf("%d", (a + i));
    }
    for (int i = 0; i < 3; i++) {
        printf("%d ", pi[i]);
    }
    printf("\n");

    char st[10];
    char *ps = st;
    scanf("%s", st);
    printf("%s\n", ps);
    scanf("%s", ps);
    printf("%s\n", st);
    return 0;
}
