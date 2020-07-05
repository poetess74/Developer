int cds = A0;
int left_light = 5;
int right_light = 6;
int brake = 3;
int reverse_beam = 7;
int main_beam = 8;
int low_beam = 9;

int beam_status = 12;
int brake_status = 13;
int drive = 2;
int reverse = 4;

int load = -255;
int input = 0;
bool darken = false;

void blinkController(int, char, bool);
void brakeController(bool, bool);

void setup() {
    pinMode(cds, INPUT);
    pinMode(left_light, OUTPUT);
    pinMode(right_light, OUTPUT);
    pinMode(brake, OUTPUT);
    pinMode(reverse_beam, OUTPUT);
    pinMode(main_beam, OUTPUT);
    pinMode(low_beam, OUTPUT);
    pinMode(beam_status, OUTPUT);
    pinMode(brake_status, OUTPUT);
    pinMode(drive, OUTPUT);
    pinMode(reverse, OUTPUT);
}

void loop() {
    digitalWrite(brake_status, HIGH);
    digitalWrite(drive, LOW);
    load = analogRead(cds);
    darken = load < 50 ? true : false; 
    brakeController(false, darken);
    if (darken) {
        digitalWrite(beam_status, HIGH);
        analogWrite(low_beam, 255);
    } else {
        digitalWrite(beam_status, LOW);
        analogWrite(low_beam, 127);
    }
    delay(2500);
    digitalWrite(brake_status, LOW);
    brakeController(true, darken);
    delay(800);
    digitalWrite(reverse_beam, HIGH);
    digitalWrite(reverse, HIGH);
    brakeController(false, darken);
    blinkController(10, 'b', darken);
    brakeController(true, darken);
    blinkController(2, 'b', darken);
    digitalWrite(reverse_beam, LOW);
    digitalWrite(reverse, LOW);
    digitalWrite(drive, HIGH);
    blinkController(5, 'l', darken);
    brakeController(false, darken);
    blinkController(2, 'l', darken);
    delay(3000);
    blinkController(5, 'r', darken);
    digitalWrite(main_beam, HIGH);
    delay(500);
    digitalWrite(main_beam, LOW);
    brakeController(true, darken);
    digitalWrite(main_beam, HIGH);
    delay(500);
    digitalWrite(main_beam, LOW);
    blinkController(2, 'r', darken);
    brakeController(false, darken);
    delay(5000);
}

void blinkController(int control, char option, bool isDark) {
    if (option == 'b') {
        for(int i = 0; i < control; i++) {
            if (isDark) {
                analogWrite(left_light, 255);
                analogWrite(right_light, 255);
                delay(1000);
                analogWrite(left_light, 127);
                analogWrite(right_light, 127);
                delay(1000);
            } else {
                digitalWrite(left_light, HIGH);
                digitalWrite(right_light, HIGH);
                delay(1000); 
                digitalWrite(left_light, LOW);
                digitalWrite(right_light, LOW);
                delay(1000); 
            }
        }
    } else if (option == 'l') {
        for(int i = 0; i < control; i++) {
            if (isDark) {
                analogWrite(left_light, 255);
                delay(1000);
                analogWrite(left_light, 127);
                delay(1000);
            } else {
                digitalWrite(left_light, HIGH);
                delay(1000); 
                digitalWrite(left_light, LOW);
                delay(1000); 
            }
        }
    } else if (option == 'r') {
        for(int i = 0; i < control; i++) {
            if (isDark) {
                analogWrite(right_light, 255);
                delay(1000);
                analogWrite(right_light, 127);
                delay(1000);
            } else {
                digitalWrite(right_light, HIGH);
                delay(1000); 
                digitalWrite(right_light, LOW);
                delay(1000); 
            }
        }
    }
}

void brakeController(bool isActive, bool isDark) {
    if (isActive) {
        analogWrite(brake, 255);
    } else if (isDark) {
        analogWrite(brake, 127);
    } else {
        analogWrite(brake, 0);
    }
}
