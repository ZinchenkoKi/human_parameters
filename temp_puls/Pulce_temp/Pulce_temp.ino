extern uint8_t MediumFontRus[]; 
//#define led_red
const int num_of_beats = 3; // количество пиков пульсовой волны для вычисления текущего значения пульса
int beat[3] = {0, 0, 0}; // массив, который хранит тройку последних значений
unsigned long first = 0, last = 0, heart_beat = 0, prev_heart_beat = 0; // переменные, которые хранят отметки времени между вычислениями пульса
int i = 0; // переменная-счетчик пиков пульсовой волны 
int pulse; // переменные, которые хранят отметки времени между вычислениями пульса
int temp_pin =A1;
void setup()
{
 // pinMode(led_red, OUTPUT);
 // pinMode(led_green, OUTPUT);
  pinMode(3, OUTPUT);
  Serial.begin(9600);
}

void loop()
{
  // сдвигаем значения в массиве и считываем текущее значение пульсовой волны
  beat[0] = beat[1];
  beat[1] = beat[2];
  beat[2] = analogRead(A0);
  //Serial.println(beat[2]);
  if (beat[0] < beat[1] && beat[1] > beat[2]){ // если второе значение в массиве будет больше первого и второго, значит был зарегистрирован пик пульсовой волны
    prev_heart_beat = heart_beat;
    heart_beat = millis();
    if (heart_beat - prev_heart_beat > 200){ // если расстояние между соседними пиками больше 200 мс.
      i++; // инкрементируем счетчик
    }
  }
  if(i == num_of_beats){ // когда подсчитано пиков достаночно для вычисления пульса
    last = millis();
    i = 0; // обнуляем счетчик
    pulse = num_of_beats * 60000 / (last-first); // вычисляем пульс (чсс)
    first = last;
    Serial.println(pulse);
  }                               
  delay(300);
  int reading = analogRead(temp_pin); //считываем показания датчика
  float voltage = reading *5.0; // преобразуем показания в напряжение 
  voltage /= 1024.0;
  float tenperatureC = (voltage - 0.5)* 100; // расчитваем температуру, исходя из 10 мВ на градус (со смещением 500мВ)
  //Serial.println("degrees C");
  delay(300); 
}
