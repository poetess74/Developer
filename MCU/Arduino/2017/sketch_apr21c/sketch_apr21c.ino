// http://dokkodai.tistory.com/103

#include <Servo.h>

Servo microServo;
const int servoPin = 3;

void setup() {
    Serial.begin(115200);
    Serial.println("===========RESTART============");
}

void loop() {
    int aValue = analogRead(A0);
    aValue = map(aValue, 0, 1023, 0, 169);
    microServo.write(aValue);
    Serial.println(aValue);
    delay (20);
}
