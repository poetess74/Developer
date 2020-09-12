int cds = 0;
void setup () {
  pinMode (0, OUTPUT);
  pinMode (1, OUTPUT);
  pinMode (2, OUTPUT);
  pinMode (10, OUTPUT);
  pinMode (11, OUTPUT);
  pinMode (12, OUTPUT);
  
}
void loop () {
  int lightLevel = analogRead(cds);
  lightLevel = map(lightLevel, 0, 1023, 0, 255);
  analogWrite(0, 255 - lightLevel);
  delay(100);  
}
