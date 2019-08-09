//Unstable
#include <stdio.h>

int main() {
    int n[20], count, temp;
    scanf("%d", &count);
    if (count > 20 || count < 0) {
        return -1;
    }

    for (int i = 0; i < count; i++) {
        scanf("%d", &n[i]);
    }
    for (int i = 0; i < count; i++) {
        if (n[i] < n[i + 1]) {
            temp = n[i];
            n[i] = n[i + 1];
            n[i + 1] = temp;
        }
    }
    for (int i = 0; i < count; i++) {
        printf("%d\n", n[i]);
    }
    return 0;
}
