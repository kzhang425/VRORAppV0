#include <Servo.h>
#include <Stepper.h>

// Initialize devices
Servo servoPan;
Servo servoTilt;

const int stepsPerRev = 200;
Stepper myStepper= Stepper(stepsPerRev, 8, 9, 10, 12);

// Define constants and global variables
int del = 1000;
int enA = 6;
int enB = 11;
char buffer[10];
int movement;
int pos;
const char* delimiter = ",";


void setup() {
  // Initialize pins
  myStepper.setSpeed(15);
  servoPan.attach(3);
  servoTilt.attach(5);

  digitalWrite(enA, LOW);
  digitalWrite(enB, LOW);

  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:

  if (Serial.available()) {
    int read = Serial.readBytesUntil('\n', buffer, 9);
    buffer[read] = '\0';
    char* first = strtok(buffer, delimiter);
    char* second = strtok(NULL, delimiter);
    movement = atoi(first);
    pos = atoi(second);

    

    switch (movement) {
      case 0:
        servoPan.write(pos);
        Serial.print("ServoPan in position\n");
        Serial.println(pos);
        break;

      case 1:
        servoTilt.write(pos);
        Serial.print("ServoTilt in position\n");
        Serial.println(pos);
        break;

      case 2:
        digitalWrite(enA, HIGH);
        digitalWrite(enB, HIGH);

        myStepper.step(pos);
        delay(4000);
        Serial.print("Stepper in position\n");
        Serial.println(pos);
        break;
    }
  }
}
