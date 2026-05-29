# include <HCSR04.h>
# define TRIG 9
# define ECHO 10
void setup() {
 Serial.begin(9600);
 int echoCount = 1;   // wie viele Sensoren sind angeschlossen
 byte* echoPins = new byte[1] {ECHO};
 HCSR04.begin(TRIG, echoPins, echoCount);
 

}




void loop() {
  // put your main code here, to run repeatedly:
  double* dist = HCSR04.measureDistanceCm();
  Serial.println(dist[0]);
  delay (109);
}
