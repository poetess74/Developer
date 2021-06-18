// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <util/delay.h>

int main(void) {
    DDRA = 0xFF;
    DDRB = 0xFF;
    PORTA = 0xFF;
    PORTB = 0xFF;
    int index = 0;

    char digit[16] = {
        0xC0, 0xF9, 0xA4, 0xB0, 
        0x99, 0x92, 0x82, 0xF8, 
        0x80, 0x90, 0x88, 0x83, 
        0xC6, 0xA1, 0x86, 0x8E
    };

    while(1) {             // Infinite loop; define here the
        PORTA = digit[index];
        _delay_ms(100);
        index > 15 ? index = 0 : index++;
    }
}
