# define LEDGreen 9
void setup() {
  pinMode(LEDGreen, OUTPUT);
  

}

void loop() {
  // Wertebereich analogWrite 0..255
  for(int i = 0 ; i < 255; i++){
    analogWrite(LEDGreen, i);
    delay(20);
  }

  for(int i = 255 ; i > 0; i--){
    analogWrite(LEDGreen, i);
    delay(20);
  }
}
