using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double p = Math.PI;                                                         // Константа числа пи
            double D0 = Convert.ToDouble(textBox1.Text);                                // Начальный диаметр
            double P = Convert.ToDouble(textBox2.Text);                                 // Сила растяжения
            double E = 0.675 * Math.Pow(10, 6);                                         // Модуль упругости алюминия
            double L0, F0, dL, L1, q, x = 0, y;                                         // L0 - начальная длина; F0 - первоначальная площадь сечения; dL - расстояние на которое изменилась болванка; L1 - конечная длина
            string error = "Вы ввели некорректное  или отрицательное значение";         // Текстовое оповещение при вводе 0 или отрициательного значения

            if (D0 > 0)                                                                 // Если диаметр больше 0
            {
                if (D0 < 1)                                                             // Если диаметр меньше 1
                {
                    L0 = D0 * 5;                                                        // Длина будет в 5 раз больше диаметра
                    matematics();                                                       // Вызов функции с расчётами
                }
                else                                                                    // Иначе
                {
                    L0 = D0 * 10;                                                       // Длина будет равна дестикратному размеру диаметра
                    matematics();
                }
            }
            else                                                                        // Иначе
            {
                textBox3.Text = error;                                                  // Вывести сообщение об ошибке
            }

            void matematics()                                                           // Функция расчётов
            {
                F0 = (p * Math.Pow(D0, 2)) / 4;                                         // Расчёт поперечного сечения образца
                dL = (P * L0) / (E * F0);                                               // Расчёт на сколько растянуля образец
                L1 = dL + L0;                                                           // Итоговая длина образца
                q = P / F0;                                                             // Расчёт напряжения во время растяжения образца

                this.chart1.Series[0].Points.Clear();                                   // Очистка поля от старого графика

                while (x <= L1)                                                         // Цикл работает пока x меньше L1
                {
                    y = Math.Atan(x) + ((L0 * 0.002) / 100) + ((L1 - L0) / L0) * 100;   // Функция графика
                    this.chart1.Series[0].Points.AddXY(x, y);                           // Построить график по получившимся значениям
                    x++;                                                               // Увеличить х на единицу
                }
            }
        }
    }
}
