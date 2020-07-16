int pill_sensor = A0;
int warn_LED = 5;
int warn_piezo = 3;
int pill_ejectSwitch = 4;

int tones[] = { 261, 294, 330, 349, 392, 440, 494, 523};

void setup() {
	pinMode(pill_sensor, INPUT);
	pinMode(pill_ejectSwitch, INPUT);
	pinMode(warn_LED, OUTPUT);
	pinMode(warn_piezo, OUTPUT);
}

void loop() {
	if (/*TODO: IR SENSOR ACT CODE */ pill_ejectSwitch == LOW) {
		int i = 0;
		digitalWrite(warn_LED, HIGH);
		tone(warn_piezo, tones[i]);
		i > 8 ? i = 0 : i++;
		delay(500);
		digitalWrite(warn_LED, LOW);
		delay(1000);
	}
}