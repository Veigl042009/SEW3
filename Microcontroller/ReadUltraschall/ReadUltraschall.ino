
# define TRIG 9
# define ECHO 10
void setup() {
 Serial.begin(9600);
 pinMode(TRIG, OUTPUT);
 pinMode(ECHO, INPUT);

}

long distance () {
  digitalWrite(TRIG, LOW);
  delayMicroseconds(2);
  digitalWrite(TRIG, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIG, LOW);

  // Schallgeschwindigkeit: 343 m/s
  // v = s/t
  // --> 58 microseconds / cm für hin und zurück
  long duration = pulseIn(ECHO, HIGH, 30000); // Timeout 30ms
  return duration / 58; // --> Distance in cm
}

void loop() {
  // put your main code here, to run repeatedly:
  long dist = distance();
  Serial.println(dist);
  delay (109);
}
