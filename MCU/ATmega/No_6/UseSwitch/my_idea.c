// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <util/delay.h>

int main(void) {
    DDRA = 0xFF;
    DDRC = 0x00;
    PORTA = 0xFF;
    PORTC = 0xFF;

   while(1) {             // Infinite loop; define here the
        if ((PINC & 0xFE) == PINC) {
            PORTA = 0x00;
            _delay_ms(200);
            PORTA = 0xFF;
            _delay_ms(200);
        } else {
            PORTA = 0xFF;
        }
   }
}
