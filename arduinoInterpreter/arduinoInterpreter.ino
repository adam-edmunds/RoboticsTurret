#include<Servo.h>

Servo serX;
Servo serY;

String serialData;

const int shootPin = 7;
const int xAxisServoPin = 9;
const int yAxisServoPin = 10;

void setup() {
  serX.attach(xAxisServoPin);
  serY.attach(yAxisServoPin);
  Serial.begin(9600);
  Serial.setTimeout(10);
  pinMode(shootPin, OUTPUT);
}

// we don't need to do anything here as the turret only moves based off the input
void loop() {
}

// this function handles all serial inputs that are sent to the arduino
void serialEvent() {
  serialData = Serial.readString();

  if (serialData == "Shoot") {
    digitalWrite(shootPin, HIGH);
    delay(250);
    digitalWrite(shootPin, LOW);
    delay(250);
  } else if(serialData.startsWith("X")) {
    serX.write(parseDataX(serialData));
    serY.write(parseDataY(serialData));
  }
}

// get the data sent from the app and extract the X-Axis data
int parseDataX(String data){
  data.remove(data.indexOf("Y"));
  data.remove(data.indexOf("X"), 1);
  currentX = data.toInt();
  return data.toInt();
}

// get the data sent from the app and extract the Y-Axis data
int parseDataY(String data){
  data.remove(0,data.indexOf("Y") + 1);
  currentY = data.toInt();
  return data.toInt();
}

