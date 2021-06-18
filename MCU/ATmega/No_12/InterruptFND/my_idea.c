// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <util/delay.h>
#include <avr/interrupt.h>

int indexA = 0, indexB = 0, indexC = 0, indexE = 0;
char digit[16] = {
    0xC0, 0xF9, 0xA4, 0xB0, 0x99, 0x92, 0x82, 0xF8, 
    0x80, 0x90, 0x88, 0x83, 0xC6, 0xA1, 0x86, 0x8E
};

ISR (INT0_vect) {
    EIMSK = 0x00;
    if (indexB >= 15) {
        indexB = 0;
        indexA = indexA >= 15 ? 0 : indexA + 1;
    } else {
        indexB++;
    }
    _delay_ms(100);
    EIMSK = 0x03;
}
ISR (INT1_vect) {
    EIMSK = 0x00;
    if (indexE >= 15) {
        indexE = 0;
        indexC = indexC >= 15 ? 0 : indexC + 1;
    } else {
        indexE++;
    }
    _delay_ms(100);
    EIMSK = 0x03;
}

int main(void) {
    DDRA = 0xFF; DDRB = 0xFF;
    DDRC = 0xFF; DDRE = 0xFF;
    DDRF = 0xFF; DDRG = 0xFF;

    DDRD = 0x00;

    PORTA = digit[indexA]; PORTB = digit[indexB];
    PORTC = digit[indexC]; PORTE = digit[indexE];
    PORTF = digit[0];

    PORTG = 0xFF;
    PORTD = 0xFF;

    EICRA = 0x00;
    EIMSK = 0x03;
    SREG = 0x80;

    while(1) {             // Infinite loop; define here the
        PORTA = digit[indexA];
        PORTB = digit[indexB];
        PORTC = digit[indexC];
        PORTE = digit[indexE];
    }
}
