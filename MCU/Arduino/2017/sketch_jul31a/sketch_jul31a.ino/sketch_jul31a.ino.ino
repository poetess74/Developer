#include<IRremote.h>
 
IRsend irsend;
 
int val = 0;
 
void setup() {
  Serial.begin(9600);
}
 
void loop() {
 
  if ( Serial.available() > 0) {
    val = Serial.read();
    if (val == '1') {
      irsend.sendSony("72463F7", 12);
      delay(500);
      Serial.println("I A/C");
    } else if (val == '0') {
      irsend.sendSony("C6EE468A", 12);
      Serial.println("O A/C");
    }
  }
}
