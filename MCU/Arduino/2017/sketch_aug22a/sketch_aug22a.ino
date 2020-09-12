#include <Servo.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>    

LiquidCrystal_I2C lcd(0x27, 16, 2);
const int trigPin = 10;
const int echoPin = 11;
const int soundPin = 9;
const int backPin = 6;
const int cdsPin = 0;
long duration;
int distance;
int lightLV;
int temp = 1;
Servo myServo;

void setup() {
  pinMode(trigPin, OUTPUT);
  pinMode(soundPin, OUTPUT);
  pinMode(echoPin, INPUT); 
  pinMode(backPin, OUTPUT);
  pinMode(cdsPin, INPUT);
  Serial.begin(9600);
  lcd.begin();
  lcd.clear();
  lightLV = analogRead(cdsPin);
  manualTune();
  analogWrite(backPin, 10);
  lcd.print(" UNO REACTIVATE");
  lcd.setCursor(0,1);
  delay(1000);
  lcd.print(" Radar Project");
  delay(5000);
  lcd.clear();
  lcd.print("PORT ANALYZING");
  delay(1000);
  lcd.setCursor(0,1);
  lcd.print("Dct 5IN, 4OUT");
  delay(1000);
  lcd.clear();
  lcd.print("LCD 16*2");
  delay(200);
  lcd.setCursor(0,1);
  lcd.print("cds");
  delay(200);
  lcd.clear();
  lcd.print("HC- SR04");
  delay(200);
  lcd.setCursor(0,1);
  lcd.print("hm-mpr");
  delay(200);
  lcd.clear();
  lcd.print("Micro Servo 9g");
  delay(200);
  lcd.setCursor(0,1);
  lcd.print("Piezo Buzzer");
  delay(200);
  lcd.clear();
  lcd.print("hm-mpr > 5v IN");
  delay(200);
  lcd.clear();
  lcd.print("V OUT ANALYZING");
  delay(1000);
  lcd.setCursor(0,1);
  lcd.print("Dct 5 OUT");
  delay(1000);
  lcd.clear();
  lcd.print("Micro Servo 9g");
  delay(200);
  lcd.setCursor(0,1);
  lcd.print("HC- SR04");
  delay(200);
  lcd.clear();
  lcd.print("LCD 16*2");
  delay(100);
  lightLV = analogRead(cdsPin);
  manualTune();
  analogWrite(backPin, lightLV);
  delay(100);
  lcd.setCursor(0,1);
  lcd.print("cds");
  delay(200);
  lcd.clear();
  lcd.print("Piezo Buzzer");
  delay(200);
  lcd.clear();
  lcd.print("Used App");
  delay(500);
  lcd.setCursor(0,1);
  lcd.print("2 Applications");
  delay(1000);
  lcd.clear();
  lcd.print("Genuino");
  delay(200);
  lcd.setCursor(0,1);
  lcd.print("Processing 3");
  delay(200);
  lcd.clear();
  delay(500);
  myServo.attach(12);
  delay(100);
}

void loop() {
  for(int i=15;i<=165;i++){ 
  lightLV = analogRead(cdsPin);
  manualTune();
  analogWrite(backPin, lightLV);
  myServo.write(i);
  delay(30);
  distance = calculateDistance();
  Serial.print(i); 
  Serial.print(","); 
  Serial.print(distance);
  Serial.print(".");
  if (distance > 0 && distance <= 40) {
    lcd.clear();
    lcd.print("    In Range");
    lcd.setCursor(0,1);
    lcd.print(i);
    lcd.print("' ");
    lcd.print("Dist:");
    lcd.print(distance);
    lcd.print("cm");
    if (lightLV >= 10) {
     tone(soundPin, 5024, 100);
      }
    } else {
      lcd.clear();
      lcd.print("  Out of Range");
      lcd.setCursor(0,1);
      lcd.print(i);
      lcd.print("' ");
      lcd.print("Dist:N/A");
    }
  }
  
  for(int i=165;i>15;i--){
  lightLV = analogRead(cdsPin);
  manualTune();
  analogWrite(backPin, lightLV);
  myServo.write(i);
  delay(30);
  distance = calculateDistance();
  Serial.print(i);
  Serial.print(",");
  Serial.print(distance);
  Serial.print(".");
  if (distance > 0 && distance <= 40) {
    lcd.clear();
    lcd.print("    In Range");
    lcd.setCursor(0,1);
    lcd.print(i);
    lcd.print("' ");
    lcd.print("Dist:");
    lcd.print(distance);
    lcd.print("cm");
    if (lightLV >= 10) {
      tone(soundPin, 5024, 100);
      }
    } else {
      lcd.clear();
      lcd.print("  Out of Range");
      lcd.setCursor(0,1);
      lcd.print(i);
      lcd.print("' ");
      lcd.print("Dist:N/A");
    }
  }
}

void manualTune()
{
  lightLV = map(lightLV, 500, 1023, 0, 255);
  lightLV = constrain(lightLV, 0, 255);
}

int calculateDistance(){ 
  
  digitalWrite(trigPin, LOW); 
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH); 
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  duration = pulseIn(echoPin, HIGH); 
  distance= duration*0.034/2;
  return distance;
}
