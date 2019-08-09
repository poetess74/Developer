#include <stdio.h>
#include <stdlib.h>

int main() {
    int num; 
    scanf("%d", &num);
    int* p = (int*)calloc(num, sizeof(int));

    for (int i = 0; i < num; i++) {
        scanf("%d", &p[i]);
    }
    for (int i = num - 1; i >=  0; i--) {
        printf("%d ", p[i]);
    }
    printf("\n");
    free(p);
    return 0;
}
