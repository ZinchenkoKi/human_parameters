using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace sp_test
{
    internal class save_data
    {
        public static void save(int[] s) //функция сохраненить как
        {
            data.save.ShowDialog();
            string filename = data.save.FileName;
            // сохраняем текст в файл
            for (int i = 0; i < data.number_of_measurements; i++)
            {
                System.IO.File.AppendAllText(filename,Convert.ToString(s[i]+ "\n"));
            }
            MessageBox.Show("Файл сохранен");
        }
    }
}
