// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <avr/interrupt.h>
#include <util/delay.h>

ISR (INT0_vect) {
	PORTC = 0x00;
	_delay_ms(50);
	PORTC = 0xFF;
	_delay_ms(50);
}

int main(void) {
    DDRC = 0xFF;
    PORTC = 0xFF;
    DDRD = 0x00;
    PORTD = 0xFF;

    EICRA = 0x00;
    EIMSK = 0x01;

    sei();

    while(1);
}
