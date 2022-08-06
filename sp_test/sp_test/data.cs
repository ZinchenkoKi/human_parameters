using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace sp_test
{
    internal class data
    {
      public static int[] puls_data = new int[number_of_measurements]; // массив считываемых данных
      public static int[] file_data = new int[number_of_measurements]; // массив данных из файла
      public static SaveFileDialog save = new SaveFileDialog(); // клас сохранения файла
      public static OpenFileDialog open = new OpenFileDialog();// клас открытия файла
      public static string com = "COM1"; // название COM порта
      public static int pete = 9600; // скорость потока
      public static SerialPort port1 = new System.IO.Ports.SerialPort(com, pete, Parity.None, 8, StopBits.One); // параметры порта
      public static string Distance; // переменаая для сиитывание данных с датчика
      public static int puls_cikl = 0; // цикл датчика пульса
      public static Form1 form1 = new Form1(); // класс формы
      public static int number_of_measurements = 100; // количестов измерений
      public static bool value_port = false; // значение активности порта
      public static int mas_sum = 0; // общаая сумма 
      public static int mas_file_sum = 0; //  общая сумма из файла
      public static int min_mas = 100000; // минимальное значение
       public static int max_mas = 0; // максимальное значение
      public static int sr_mas = 0; // среднее значение

    }
}
