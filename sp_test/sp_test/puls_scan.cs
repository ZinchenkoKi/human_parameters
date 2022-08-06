using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sp_test
{
    internal class puls_scan
    {
        Random rng = new Random(); // функция сканирования данных
        public static void scan(int[] a)
        {
            Random rng = new Random(); // рандомайзер убраь при реальных измеениях 
            a[data.puls_cikl] = rng.Next(50); // убраь при реальных измеениях 
            //MessageBox.Show("измерение № = "+ data.puls_cikl);
            //a[data.puls_cikl] = Convert.ToInt32(data.Distance); // запись показаний в массив
            data.puls_cikl++;
            data.form1.progressBar1.Value = data.form1.progressBar1.Value + 1;
            System.Threading.Thread.Sleep(300); // замедление убраь при реальных измеениях 
        }
    }
}
