void setup() {
    pinMode(3, OUTPUT);
    pinMode(5, OUTPUT);
    pinMode(9, OUTPUT);
}
void loop() {
    digitalWrite(3, HIGH);
    delay(1000);
    digitalWrite(3, LOW);
    digitalWrite(5, HIGH);
    delay(1000);
    digitalWrite(5, LOW);
    digitalWrite(9, HIGH);
    delay(1000);
    digitalWrite(9, LOW);
    digitalWrite(3, HIGH);
    digitalWrite(5, HIGH);
    delay(1000);
    digitalWrite(3, LOW);
    digitalWrite(5, LOW);
    digitalWrite(5, HIGH);
    digitalWrite(9, HIGH);
    delay(1000);
    digitalWrite(5, LOW);
    digitalWrite(9, LOW);
    digitalWrite(9, HIGH);
    digitalWrite(3, HIGH);
    delay(1000);
    digitalWrite(9, LOW);
    digitalWrite(3, LOW);
    delay(1000);
    digitalWrite(3, HIGH);
    digitalWrite(5, HIGH);
    digitalWrite(9, HIGH);
    delay(1000);
    digitalWrite(3, LOW);
    digitalWrite(5, LOW);
    digitalWrite(9, LOW);
    delay(1000);
}
