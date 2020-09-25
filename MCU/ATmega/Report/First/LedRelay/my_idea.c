// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <util/delay.h>

int main(void) {
    DDRC = 0xFF;
    PORTC = 0X00;
    char index[9] = {0b11111111, 0b01111111, 0b00111111, 
                     0b00011111, 0b00001111, 0b00000111, 
                     0b00000011, 0b00000001, 0b00000000
                    };
    while(1) {             // Infinite loop; define here the
        for(int i = 0; i < 9; i++) {
            PORTC = index[i];
            _delay_ms(200);
        }
        for(int i = 8; i >= 0; i--) {
            PORTC = index[i];
            _delay_ms(200);
        }
    }
}

