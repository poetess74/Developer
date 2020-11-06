// ***********************************************************
// Project:
// Author:
// Module description:
// ***********************************************************

#include <avr/io.h>              // Most basic include files
#include <util/delay.h>

void  LCD_command(unsigned char command) {
    PORTC = 0x04;    // E = 1, R/W=0, RS=0 (???)
    PORTA = command;
    _delay_us(50);
    PORTC = 0X00;    // E=0 (Disable)
    _delay_us(50);
}

void LCD_data(unsigned char data) {
    PORTC = 0x05;  // E=1, R/W=0, RS=1 (???)
    _delay_us(1);
    PORTA = data;
    PORTC = 0x01;  // E = 0
    _delay_us(1);
}

void LCD_string(unsigned char command,  unsigned char *string) {
    LCD_command(command);
    while(*string != '\0') {
        LCD_data(*string);
        string++;
    }
}

void LCD_cursordisplay_shift (int SC, int RL) {
    unsigned char cmd;
    cmd = 0b00010000;
    if (SC == 1) cmd = cmd | 0b00001000;
    if (RL == 1) cmd = cmd | 0b00000100;
    LCD_command(cmd);
}

void LCD_initialize(void) {
    DDRA = 0xFF;
    DDRC = 0xFF;

    LCD_command(0x38);
    _delay_ms(4);
    LCD_command(0x38);
    _delay_ms(4);
    LCD_command(0x38);
    _delay_ms(4);

    _delay_ms(20);
    LCD_command(0x38);
    LCD_command(0x08);
    LCD_command(0x01);
    _delay_ms(2);
    LCD_command(0x06);
    LCD_command(0x0E);
}

int main(void) {

    LCD_initialize();
    unsigned char str1[] = "********";

    while(1) {            // Infinite loop; define here the
        LCD_string(0x80, str1);
        LCD_cursordisplay_shift(1, 1);
        _delay_ms(500);
    }
}

