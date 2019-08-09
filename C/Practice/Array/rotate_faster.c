#include <stdio.h>
#include <memory.h>

#define SIZE 5 

int array[SIZE * SIZE];

void print_array()
{
    for (int i = 0; i < SIZE * SIZE; i++)
    {
        printf("%2d ", array[i]);
        if ((i + 1) % SIZE == 0)
            printf("\n");

    }
}

void rotate_array()
{
    int temp_array[SIZE * SIZE];
   
    for (int i = 0; i < SIZE * SIZE; i++)
        temp_array[(i % SIZE) * SIZE + SIZE - (i / SIZE) - 1] = array[(i / SIZE) * SIZE + i % SIZE];

    // copy temp_array to array by memcpy
    memcpy(array, temp_array, SIZE * SIZE * sizeof(int));
}

int main()
{
    // initialize array
    for (int i = 0; i < SIZE * SIZE; i++)
        array[i] = i;

    print_array();

    int rotate_count;

    printf("\n---------- 입력 ----------\n");
    scanf("%d", &rotate_count);

    for (int i = 0; i < rotate_count; i++)
    {
        rotate_array();
    }

    printf("\n---------- 출력 ----------\n");
    print_array();
}
