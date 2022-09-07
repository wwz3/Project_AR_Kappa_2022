#include <SoftwareSerial.h>

#define RX  10
#define TX  11
#define LED 7

SoftwareSerial mySerial(RX, TX);

int pot;

void setup() 
{
  Serial.begin(9600);
  pinMode(LED,OUTPUT);
  mySerial.begin(9600);
  pot = 0;
}

void loop() 
{
  //if(mySerial.available())
  //{
    pot = analogRead(A0);
    //pot = mySerial.read();
    Serial.println(pot);
    mySerial.println(pot);
    delay(1000);
  //}

}
