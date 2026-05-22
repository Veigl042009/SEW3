#define ROT 8
#define GELB 7
#define GRUEN 4
void setup() {
  Serial.begin(9600);
  pinMode(ROT, OUTPUT);
  pinMode(GELB, OUTPUT);
  pinMode(GRUEN, OUTPUT);

  // put your setup code here, to run once:

}

void loop() {
  digitalWrite(ROT, HIGH);
  delay(500); // millisekunden
  
  digitalWrite(GELB, LOW);
  delay(500); // millisekunden

  digitalWrite(GRUEN, LOW);
  delay(500); // millisekunden

}
