using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace sp_test
{
    public partial class Form1 : Form
    {

        public Form1()
        { 
            InitializeComponent();
           tabPage2.Parent = null; // скрытие понели "ностройки порта"
           data.number_of_measurements = 10; // количество измерений присваевается 10
           data.puls_data = new int[data.number_of_measurements]; // массив считываемых данных
           data.file_data = new int[data.number_of_measurements]; // массив данных из файла
        }



        private void button1_Click_1(object sender, EventArgs e) // считывание параметров с датчика
        {
            progressBar1.Maximum = data.number_of_measurements; // максимальное значение процесбара
            progressBar1.Value = 0; // обнуление значения процессбара
            tabPage2.Parent = null; // скрытие понели "ностройки порта"
            data.value_port = true; // кастыль убрать на релизе и на реальном датчике
            if (data.value_port == false) // проверка открыть ли порт
            {
                MessageBox.Show("Подключите порт"); // проверка включен ли порт 
            }
            else {
                data.puls_cikl = 0; // обнуление цикла измерений
                data.form1.progressBar1.Value = 0; // обнуление процесс бара
                this.chart1.Series[0].Points.Clear(); //очистка графика
                int x = 0; // точна начал кординат х 
                for (int i = 0; i < data.number_of_measurements; i++) // вычисление кординаты у 
                {
                    puls_scan.scan(data.puls_data); // функция считывания данных с датчика
                    this.chart1.Series[0].Points.AddXY(x, data.puls_data[i]); // прорисовка графика
                    progressBar1.Value = i; // изменение значения процессбара
                }
                progressBar1.Value = progressBar1.Value + 1; // увеличение процессбара на 1
            }
            znach.sr_zn(); // функция среднего значения
            data.max_mas = data.puls_data.Max(); // функция минимального значения
            data.min_mas = data.puls_data.Min(); // функция максимального значения
            label17.Text = Convert.ToString(data.number_of_measurements); // количество повторений на лейбле
            label15.Text = Convert.ToString(data.sr_mas); // среднее значение на лейбле
            label13.Text = Convert.ToString(data.min_mas);// минимальное значение на лейбле
            label14.Text = Convert.ToString(data.max_mas);// максимальное значение на лейбле
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // закрытие приложения
        {
            data.value_port = false; // значение порта закрыт
            data.port1.Close(); // закрытие порта
            this.Close(); // закрытие приложения
        }


        private void button2_Click(object sender, EventArgs e) // кнопка сравнить показания
        {
            open_file.open(); // функция открытие файла
            comparison_data.comparison(); // функция сравнения данных
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)// кнопка сохранить
        {
            save_us.us(data.puls_data);// функция сохранить
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e) // кнопка сохранить как
        {
            save_data.save(data.puls_data); // функция сохранить как
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) //кнопка открытия порта
        {
            data.port1.Open(); // открытие порта
            data.value_port = true;
        }

        private void параметрыПортаToolStripMenuItem_Click(object sender, EventArgs e) // открытие настроек порта
        {
            tabPage2.Parent = tabControl1; 
            tabControl1.SelectTab(tabPage2);
        }

        private void скрытьНастройкиПортаToolStripMenuItem_Click(object sender, EventArgs e) // Скрытие настроек порта
        {
            tabPage2.Parent = null; 
        }

        private void button3_Click(object sender, EventArgs e) // изменение данных количесвто измерений, название порта, частота порта.
        {
            if (textBox1.Text != "") // проверка на данные в поле количество
            {
                if (comboBox1.SelectedIndex == -1) // проверка выбран ли порт 
                {
                    MessageBox.Show("Выберите название порты или используйте ручной ввод"); // сообщение если порт пустой
                }
                else
                {
                    data.number_of_measurements = Convert.ToInt32(textBox1.Text); // количество измерений
                    data.puls_data = new int[data.number_of_measurements]; // массив считываемых данных
                    data.file_data = new int[data.number_of_measurements]; // массив данных из файла
                    progressBar1.Maximum = data.number_of_measurements; // максимальная длина процессбара
                    switch (comboBox1.SelectedIndex) // выбор компорта
                    {
                        case 0:
                            data.com = "COM1";
                            break;
                        case 1:
                            data.com = "COM2";
                            break;
                        case 2:
                            data.com = "COM3";
                            break;
                        case 3:
                            data.com = "COM4";
                            break;
                        case 4:
                            data.com = "COM5";
                            break;
                        case 5:
                            data.com = textBox2.Text;
                            break;
                    }
                    if (textBox3.Text == "") // проверка на пустоту поля порта
                    {
                        MessageBox.Show("Необходимо вввести частоту порта"); // сообщение если поле путое
                    }
                    else
                    {
                        data.pete = Convert.ToInt32(textBox3.Text);
                    }
                }
            }
            else { MessageBox.Show("Необходимо вввести количество измерений для сохранения"); } // сообщение о пустом поле количество
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e) // кнопка "помощь"
        {
            Помощь f2 = new Помощь();
            f2.Show();
        }

        private void оПриложенииToolStripMenuItem_Click(object sender, EventArgs e) // кнопка "о приложении"
        {
            MessageBox.Show("Версия преложения 0.8 Разратотал Студет группы ВМ ИВТ 4-1 Зинченко К.А");
        }

    }
}
