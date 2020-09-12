void setup() {
    pinMode (4, OUTPUT);
    pinMode (6, OUTPUT);
}

void loop() {
    digitalWrite (4, HIGH);
    digitalWrite (6, HIGH);
    delay (1000);
    digitalWrite (4, LOW);
    digitalWrite (6, LOW);
    delay (1000);
    digitalWrite (4, HIGH);
    digitalWrite (6, HIGH);
    delay (1000);
    digitalWrite (4, LOW);
    digitalWrite (6, LOW);
    delay (1000);
}
