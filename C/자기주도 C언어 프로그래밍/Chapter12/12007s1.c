//Unstable
#include <stdio.h>
#define N 10 
#define swap(x, y) {int z=x; x=y; y=z;}

void input(int a[], int count) {
    for (int i = 0; i < count; i++) {
        scanf("%d", &a[i]);
    } 
}

void sort(int a[], int count) {
    for (int i = count - 1; i > 0; i--) {
        for (int j = 0; j < i; j++) {
            if (a[j] > a[j + 1]) {
                swap(a[j], a[j + 1]);
            }
            printf("%d ", a[j]);
        }
        printf("\n");
    }
}

void output(int a[]) {
    for (int i = 0; i < N; i++) {
        printf("%d ", a[i]);
    }
}

int main() {
    int arr[N];
    input(arr, N);
    sort(arr, N);
    output(arr);
    printf("\n");
    return 0;
}
