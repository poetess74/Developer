// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>
#include <util/delay.h>
#define INDEX_SIZE 9

int main(void) {
    DDRC = 0xFF;
    PORTC = 0X00;
    char indexArray[INDEX_SIZE] = {  0b11111111, 0b11111110, 0b11111100, // 0xFF, 0xFE, 0xFC
                                     0b11111000, 0b11110000, 0b11100000, // 0xF8, 0xF0, 0xE0
                                     0b11000000, 0b10000000, 0b00000000  // 0xC0, 0x80, 0x00
                                  };
    char index;

    while(1) {
        /* Use bit-shift operator */ 
        index = 0xFF;
        for(int i = 0; i < INDEX_SIZE; i++) {
            PORTC = index;
            _delay_ms(100);
            index <<= 1;
        }
        index = 0xFF;
        for(int i = 0; i < INDEX_SIZE; i++) {
            PORTC = ~index;
            _delay_ms(100);
            index >>= 1;
        }

        /* Use for-loop and array */
        for(int i = 0; i < INDEX_SIZE; i++) {
            PORTC = indexArray[i];
            _delay_ms(100);
        }
        for(int i = INDEX_SIZE - 1; i >= 0; i--) {
            PORTC = indexArray[i];
            _delay_ms(100);
        }
    }
}

