using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sp_test
{
    internal class open_file
    {
      public  static void open()
      {
            data.open.ShowDialog();
            // получаем выбранный файл
            string filename = data.open.FileName;
            // читаем файл в строку
            for (int i = 0; i < data.number_of_measurements; i++)
            {
                data.file_data[i] = Convert.ToInt32(System.IO.File.ReadLines(filename).Skip(i).First());
                //MessageBox.Show(Convert.ToString(data.file_data[i]));
            }
            MessageBox.Show("Файл открыт");

      }
    }
}
