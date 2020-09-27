// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <util/delay.h>

int main(void) {
    DDRC = 0xFF;
    while(1) {             // Infinite loop; define here the
        PORTC = 0xF0;
        _delay_ms(500);
        PORTC = 0x0F;
        _delay_ms(500);
    }
}

