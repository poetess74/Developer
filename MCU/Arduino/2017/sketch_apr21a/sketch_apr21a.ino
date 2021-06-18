// http://dokkodai.tistory.com/103
// 서보모터는 0 ~ 170도를 반복적으로 움직임

#include <Servo.h>

Servo microServo;
const int servoPin = 3;

void setup() {
    Serial.begin(115200);
    Serial.println("============RESTART=============")
    microServo.attach(servoPin);
}

void loop() {
    int angle;
    for (angle = 0; angle < 170; angle++) {
        microServo.write(angle);
        Serial.println(angle);
        delay(10);
    }
    for (angle = 170; angle > 0; angle--) {
        microServo.write(angle);
        Serial.println(angle);
        delay(10); 
    }
}
