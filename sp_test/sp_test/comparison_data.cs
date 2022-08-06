using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sp_test
{
    internal class comparison_data
    {
     public static void comparison() // функция сравнения показаний
     {
            data.mas_sum = 0;
            data.mas_file_sum = 0;
            for (int i = 0; i < data.puls_data.Length; i++)
            {
                data.mas_sum = data.puls_data[i] + data.mas_sum;
            }

            for (int i = 0; i < data.file_data.Length; i++)
            {
                data.mas_file_sum = data.file_data[i] + data.mas_file_sum;
            }
            if (data.mas_file_sum == data.mas_sum)
            {
                MessageBox.Show("Показания стабильны");
            }
            else
            {
                if (data.mas_file_sum > data.mas_sum)
                {
                    MessageBox.Show("Показания выше нормы");
                }
                else
                {
                    MessageBox.Show("Показания ниже нормы");
                }
            }
      }

    }
}
