int DELAY = 200;
int onPin = 2;
int dir = 1;

void setup () {
  for (int i = 2; i <= 6; i++) {
    pinMode(i, OUTPUT);
  }
}

void loop () {
  for (int i = 2; i <= 6; i++) {
    digitalWrite(i, LOW);
  }

  digitalWrite(onPin, HIGH);
  delay(DELAY); 
  
  onPin += dir;
  
  if (onPin == 7) {
    dir = -1;
    onPin = 6;
  } else if (onPin == 1) {
    dir = 1;
    onPin = 2;
  }
}
