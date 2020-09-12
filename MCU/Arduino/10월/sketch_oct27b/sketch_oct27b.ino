int temp = 0;
int start = 0;
void setup() {
    pinMode(2, OUTPUT);
    pinMode(3, OUTPUT);
    pinMode(4, OUTPUT);
    pinMode(5, OUTPUT);
    pinMode(6, OUTPUT);
    pinMode(8, OUTPUT);
    pinMode(9, OUTPUT);
    pinMode(10, OUTPUT);
    pinMode(11, OUTPUT);
    pinMode(12, OUTPUT);
}

void loop() {
    digitalWrite(9, HIGH);
    for (start = 0; start < 3; start ++) {
        digitalWrite(2, HIGH);
        digitalWrite(4, HIGH);
        delay(2500);
        digitalWrite(2, LOW);
        digitalWrite(4, LOW);
    }
    digitalWrite(2, LOW);
    digitalWrite(4, LOW);
    digitalWrite(6, HIGH);
    digitalWrite(12, HIGH);
    digitalWrite(3, HIGH);
    digitalWrite(5, HIGH);
    delay(2500);
    digitalWrite(6, LOW);
    digitalWrite(3, LOW);
    delay(3000);
    digitalWrite(3, HIGH);
    for (temp = 0; temp < 11; temp ++) {
        digitalWrite(2, HIGH);
        delay(2500);
        digitalWrite(2, LOW);
    }
    digitalWrite(2, LOW);
    digitalWrite(3, LOW);
    delay(5000);
    digitalWrite(9, LOW);
    digitalWrite(10, HIGH);
    digitalWrite(3, HIGH);
    for (temp = 0; temp < 6; temp ++) {
        digitalWrite(8, LOW);
        delay(1500);
        digitalWrite(8, HIGH);
    }
    digitalWrite(8, LOW);
    digitalWrite(3, LOW);
    digitalWrite(6, HIGH);
    delay(500);
    digitalWrite(3, HIGH);
    for(temp = 0; temp < 6; temp ++) {
        digitalWrite(2, HIGH);
        digitalWrite(4, HIGH);
        delay(2500);
        digitalWrite(2, LOW);
        digitalWrite(4, LOW);
    }
    digitalWrite(10, LOW);
    digitalWrite(11, HIGH);
    digitalWrite(2, LOW);
    digitalWrite(4, LOW);
    digitalWrite(5, LOW);
    digitalWrite(12, LOW);
    delay(200);
    digitalWrite(3, LOW);
    delay(5000);
    digitalWrite(6, LOW);
    delay(500);
    digitalWrite(11, LOW);
}
