// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <util/delay.h>

int main(void) {
    DDRC = 0xFF;
    char index = 0x01;
    while(1) {             // Infinite loop; define here the
        for(char i = 1; i < 8; i++) {
            PORTC = ~index;
            _delay_ms(200);
            index <<= 1;
        }
        index = 0X80;
        for(char i = 1; i < 8; i++) {
            PORTC = ~index;
            _delay_ms(200);
            index >>= 1;
        }
    }
}

