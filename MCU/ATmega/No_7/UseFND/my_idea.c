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

    while(1) {             // Infinite loop; define here the
        PORTA = 0xFF;
        _delay_ms(500);
        PORTA = 0x00;
        _delay_ms(500);
    }
}
