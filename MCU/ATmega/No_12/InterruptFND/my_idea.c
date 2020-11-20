// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <util/delay.h>
#include <avr/interrupt.h>

int indexAA, indexAB, indexBA, indexBB;
char digit[16] = {
    0xC0, 0xF9, 0xA4, 0xB0, 0x99, 0x92, 0x82, 0xF8, 
    0x80, 0x90, 0x88, 0x83, 0xC6, 0xA1, 0x86, 0x8E
};

ISR (INT0_vect) {
    EIMSK = 0x00;
    if (indexAB > 16) {
        indexAB = 0;
        indexAA = indexAA > 15 ? 0 : indexAA + 1;
    } else {
        indexAB++;
    }
    EIMSK = 0x02;
}
ISR (INT1_vect) {
    EIMSK = 0x00;
    if (indexBB > 16) {
        indexBB = 0;
        indexBA = indexBA > 15 ? 0 : indexBA + 1;
    } else {
        indexBB++;
    }
    EIMSK = 0x02;
}

int main(void) {
    DDRA = 0xFF; DDRB = 0xFF;
    DDRC = 0xFF; DDRD = 0xFF;
    DDRE = 0xFF;

    DDRF = 0x00;

    PORTA = digit[indexAA]; PORTB = digit[indexAB];
    PORTC = digit[indexBA]; PORTD = digit[indexBB];

    PORTE = 0xFF;

    EICRA = 0x00;
    EIMSK = 0x02;
    SREG = 0x80;

    while(1) {             // Infinite loop; define here the
        PORTA = digit[indexAA];
        PORTB = digit[indexAB];
        PORTC = digit[indexBA];
        PORTD = digit[indexBB];
    }
}
