#include <stdio.h>

typedef union color_t {
    unsigned int color;
    unsigned char rgb[4];
} COLOR_T;

int main() {
    COLOR_T c1;

    c1.rgb[0] = 0xFF;
    c1.rgb[1] = 0xAB;
    c1.rgb[2] = 0x1F;
    c1.rgb[3] = 0x00;

    printf("RGB color = %08X\n", c1.color);

    return 0;
}
