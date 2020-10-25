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
    DDRC = 0x00;
    PORTA = 0xFF;
    PORTB = 0xFF;
    PORTC = 0xFF;
    int index = 0;

    char digit[6] = {
        0xC0, 0xF9, 0xA4, 
        0xB0, 0x99, 0x92
    };

    while(1) {             // Infinite loop; define here the
        if (PINC == 0xFE) {
            PORTB = 0b10101010;
        } else if(PINC == 0xFD) {
            PORTB = 0b01010101;
        } else {
            PORTB = 0xFF;
        }
        PORTA = digit[index];
        _delay_ms(100);
        index > 5 ? index = 0 : index++;
    }
}
