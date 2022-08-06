using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sp_test
{
    internal class znach
    {
        public static void sr_zn() // функция определения среднего значения
        {
            for (int i = 0; i < data.number_of_measurements; i++)
            {
                data.sr_mas = data.puls_data[i] + data.sr_mas;
            }
            data.sr_mas = data.sr_mas / data.number_of_measurements;
        }
    }
}
