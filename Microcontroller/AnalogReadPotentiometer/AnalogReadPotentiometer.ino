#define POTI A0
#define LED 3
void setup() {
  Serial.begin(9600);
  // bei PINs A= bis A5 muss PinMode nicht gesetzt werden
  pinMode(LED, OUTPUT);

  

}

void loop() {
  int value = analogRead(POTI);   // 0...1023
  Serial.println(value);
  int pwm = map(value, 0, 1023, 0, 255);
  analogWrite(LED, pwm);
  delay(100);
  

}
