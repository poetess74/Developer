int a = 0;
int lp0 = 0;
int lp1 = 0;

void setup() {
    pinMode(0, OUTPUT);
    pinMode(1, OUTPUT);
    pinMode(2, OUTPUT);
    pinMode(3, OUTPUT);

    pinMode(10, OUTPUT);
    pinMode(11, OUTPUT);
    pinMode(12, OUTPUT);
    pinMode(13, OUTPUT);
}

void loop() {
    digitalWrite(0, HIGH);
    delay(1000);
    digitalWrite(0, LOW);
    delay(1000);

