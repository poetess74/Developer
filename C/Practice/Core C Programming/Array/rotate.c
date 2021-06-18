#include <stdio.h>
#include <memory.h>

#define SIZE 5 

int array[SIZE][SIZE];

void print_array()
{
    for (int row = 0; row < SIZE; row++)
    {
        for (int col = 0; col < SIZE; col++)
        {
            printf("%2d ", array[row][col]);
        }
        printf("\n");
    }
}

void rotate_array()
{
    int temp_array[SIZE][SIZE];
   
    for (int row = 0; row < SIZE; row++)
    {
        for (int col = 0; col < SIZE; col++)
        {
            temp_array[col][SIZE - row - 1] = array[row][col];
        }
    }

    // copy temp_array to array by memcpy
    // memcpy(array, temp_array, SIZE * SIZE * sizeof(int));
   
    // copy temp_array to array
    for (int row = 0; row < SIZE; row++)
    {
        for (int col = 0; col < SIZE; col++)
        {
            array[row][col] = temp_array[row][col];
        }
    }
}

int main()
{
    // initialize array
    for (int row = 0; row < SIZE; row++)
    {
        for (int col = 0; col < SIZE; col++)
        {
            array[row][col] = SIZE * row + col + 1;
        }
    }

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
