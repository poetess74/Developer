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

void LCD_display_clear() {
    LCD_command(0b00000001);
    _delay_ms(2);
}

void LCD_cursor_home() {
    LCD_command(0b00000010);
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
    unsigned char str1[] = "Clear display";
    unsigned char str2[] = "Cursor home";

    while(1) {            // Infinite loop; define here the
        LCD_string(0x80, str1);
        _delay_ms(1000);
        LCD_display_clear();
        _delay_ms(1000);
        LCD_string(0xC0, str2);
        _delay_ms(1000);
        LCD_cursor_home();
        _delay_ms(1000);
    }
}

