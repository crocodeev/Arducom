const int LedPin = 13;  
int ledState = 0;
unsigned long Timer;
  
void setup()  
{   
  pinMode(LedPin, OUTPUT);
  Serial.begin(9600);
}  
  
void loop()  
{   
    char receiveVal;     
     
    if(Serial.available() > 0)  
    {          
        receiveVal = Serial.read();  
          
        switch(receiveVal){
          case '1':
          if(!digitalRead(LedPin)){
            digitalWrite(LedPin, HIGH);
            Timer = millis();
          }
          break;
          case '2':
          break;
          case '3':
          break;
          case '4':
          break;
          case '5':
          break;
          default:
          break;
        }   
    }

    if(digitalRead(LedPin)) {

      if(millis() - Timer > 500){
        digitalWrite(LedPin, LOW);
        Timer = 0;
      }
    }     
        
       
}