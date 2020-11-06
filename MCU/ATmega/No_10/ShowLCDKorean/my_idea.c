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

void LCD_display_ONOFF(int D, int C, int B) {
    unsigned char cmd;
    cmd = 0b00001000;
    if (D == 1) cmd = cmd | 0b00000100;
    if (C == 1) cmd = cmd | 0b00000010;
    if (B == 1) cmd = cmd | 0b00000001;
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
    unsigned char data[] = {
        0x09, 0x15, 0x15, 0x09, 0x00, 0x08, 0x0f, 0x00
    };
    LCD_initialize();
    LCD_display_ONOFF(1, 0, 1);
    LCD_command(0x40);

    for(int i = 0; i < 8; i++) {
        LCD_data(data[i]);
        _delay_ms(30);
    }
    LCD_command(0xC0);
    LCD_data(0x00);
}
