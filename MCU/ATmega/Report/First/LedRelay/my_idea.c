// ***********************************************************
// Project: First Report
// Subject: LED Relay
// Author: 20194315 Hyeongmin Kim
// ***********************************************************

#include <avr/io.h>
#include <util/delay.h>
#define LED_CTRL_INDEX 9

int main(void) {
    /* Define ports and value */
    DDRC = 0xFF;
    char index;
    char indexArray[LED_CTRL_INDEX] = {  0b11111111, 0b11111110, 0b11111100, // 0xFF, 0xFE, 0xFC
                                         0b11111000, 0b11110000, 0b11100000, // 0xF8, 0xF0, 0xE0
                                         0b11000000, 0b10000000, 0b00000000  // 0xC0, 0x80, 0x00
                                      };

    /* Initial setting (All LED off) */
    PORTC = 0XFF;

    while(1) {
        index = 0xFF;
        /* Use bit-shift operator */ 
        for(int i = 0; i < LED_CTRL_INDEX; i++) {
            PORTC = index;
            _delay_ms(100);
            index <<= 1;
        }
        index = 0x7F;
        for(int i = 0; i < LED_CTRL_INDEX - 1; i++) {
            PORTC = ~index;
            _delay_ms(100);
            index >>= 1;
        }

        /* Use for-loop and array */
        for(int i = 1; i < LED_CTRL_INDEX; i++) {
            PORTC = indexArray[i];
            _delay_ms(100);
        }
        for(int i = LED_CTRL_INDEX - 2; i > 0; i--) {
            PORTC = indexArray[i];
            _delay_ms(100);
        }
    }
}

