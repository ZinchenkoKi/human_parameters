using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sp_test
{
    internal class save_us // функция сохранить 
    {
        public static void us(int[] s)
        {
            if (data.save.FileName == "") // проверка имени файла
            {
                save_data.save(data.puls_data); // сохранить как 
            }
            else
            {
                for (int i = 0; i < data.number_of_measurements; i++)
                {
                    System.IO.File.AppendAllText(data.save.FileName, Convert.ToString(s[i] + "\n")); 
                }
                MessageBox.Show("Файл сохранен");
            }
        }
    }
}
