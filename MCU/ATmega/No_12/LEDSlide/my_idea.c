// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <avr/interrupt.h>
#include <util/delay.h>

unsigned char index = 0;
unsigned char seg[8] = {0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80};

ISR (INT0_vect) {
    EIMSK = 0x00;
    if (index >= 7) {
        index = 0;
    } else {
        index++;
    }
    _delay_ms(100);
    EIMSK = 0x03;
}

ISR (INT1_vect) {
    EIMSK = 0x00;
    if (index <= 0) {
        index = 7;
    } else {
        index--;
    }
    _delay_ms(100);
    EIMSK = 0x03;
}

int main(void) {
    DDRC = 0xFF;
    PORTC = 0xFF;
    DDRD = 0x00;
    PORTD = 0xFF;

    EICRA = 0x00;
    EIMSK = 0x03;
    SREG = 0x80;

    while(1) {
        PORTC = ~seg[index];
    }
}
