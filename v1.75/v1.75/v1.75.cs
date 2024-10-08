﻿/*
 * «p» - число пи
 * «E» - модуль упругости материала
 * «L0» - первоначальная длинна болванки
 * «D0» - первоначальеый диаметр болванки
 * «P» - растягивающая сила, прилагаемая к болванке
 * «F0» - площадь поперечного сечения растягиваемой части болванки
 * «dL» - дельта длины, разница между первоначальной длиной болванки и длиной болванки после растяжения
 * «L1» - длина болванки после растяжения
 * «q» - напряжение во время растяжения
 * «T» - работа деформации до предела упругости
 * «Tl» - работа деформации до момнета разрыва
 * «Pmax» - нагрузка равная пределу прочгости
 */

namespace Steel
{
    class Program
    {
        static void Main()
        {
            const double p = Math.PI;                                                                       // Константа числа пи
            double E = 0.675 * Math.Pow(10, 6);                                                             // Модуль упругости алюминия
            int Pmax = 90;                                                                                  // Предел прочности алюминия
            double D0, P;                                                                                   // Переменные, которые задаются пользователем
            double L0, F0, dL, L1, q;                                                                       // Переменные, которые расчитываются программой
            double T, Tl;                                                                                   // Переменные, которые расчитываются программой и применяются для графика
            int[] Array = new int[1000];                                                                    // Объявление массива значений для построения графика

            Console.Write("Введите измеренный диаметр образца (см): ");
            D0 = Convert.ToDouble(Console.ReadLine());                                                      // Ввод диаметра образца

            if (D0 > 0)                                                                                     // Если диаметр строго больше 0, тогда
            {
                if (D0 < 1)                                                                                 // Если диаметр строго меньше единицы, тогда
                {
                    L0 = D0 * 5;                                                                            // Длинна образца будет в 5 раз больше диаметра
                    Console.Write($"Длина образца {Math.Round(L0, 2)} см\n");

                    Console.Write("Введите силу растяжения образца (кг): ");
                    P = Convert.ToDouble(Console.ReadLine());                                               // Ввод силы растяжения образца

                    calculations();                                                                         // Вызов функции расчёта удлинения образца
                    stretching_work();                                                                      // Вызов функции расчёта нагрузки до разрушения

                    Console.WriteLine($"\nОбразец удленился на: {Math.Round(dL, 2)} см");                   // Вывод значения на сколько образец удленился
                    Console.WriteLine($"Итоговая длина образца {Math.Round(L1, 2)} см");                    // Вывод значения итоговой длины после разрыва
                    Console.WriteLine($"Напряжение в болванке в ходе растяжения {Math.Round(q, 2)}");       // Вывод значени напряжения в болванке во время растяжения
                    Console.WriteLine($"\nРабота до предела текучести {Math.Round(T, 2)}");                 // Работа, совершённая до предела текучести
                    Console.WriteLine($"Работа от предела текучести до разрыва {Math.Round(Tl, 2)}");       // Работа, совершённая после предела текучести

                    filling_in_the_array();
                }
                else if (D0 >= 1)                                                                           // Если диаметр больше или равен единицы, тогда
                {
                    L0 = D0 * 10;
                    Console.Write($"Длина образца {Math.Round(L0, 2)} см\n");

                    Console.Write("Введите силу растяжения образца (кг): ");
                    P = Convert.ToDouble(Console.ReadLine());

                    calculations();
                    stretching_work();

                    Console.WriteLine($"\nОбразец удленился на: {Math.Round(dL, 2)} см");
                    Console.WriteLine($"Итоговая длина образца {Math.Round(L1, 2)} см");
                    Console.WriteLine($"Напряжение в болванке в ходе растяжения {Math.Round(q, 2)}");
                    Console.WriteLine($"\nРабота до предела текучести {Math.Round(T, 2)}");
                    Console.WriteLine($"Работа от предела текучести до разрыва {Math.Round(Tl, 2)}");

                    filling_in_the_array();
                }
            }
            else
                Console.Write("Вы ввели не корректные значения");                                           // Ели диаметр меньше нуля , тогда вывести сообщение о некорректных данных

            void calculations()                                                                             // Функция для расчёта удлинения образца
            {
                F0 = (p * Math.Pow(D0, 2)) / 4;                                                             // Расчёт поперечного сечения образца
                dL = (P * L0) / (E * F0);                                                                   // Расчёт на сколько растянуля образец
                L1 = dL + L0;                                                                               // Итоговая длина образца
                q = P / F0;                                                                                 // Расчёт напряжения во время растяжения образца
            }

            void stretching_work()                                                                          // Расчёт значений для графика
            {
                T = (Math.Pow(dL, 2) * E * F0) / 2 * L0;                                                    // Расчёт работы до предела упругой деформации
                Tl = 0.9 * Pmax * dL;                                                                       // Расчёт работы до момента разрыва
            }

            void filling_in_the_array()
            {
                stretching_work();
                double Ts = T + Tl;

                for (int i = 0; i < Ts; i++)
                {
                    Array[i] = i;
                    Console.WriteLine(Array[i]);
                }
            }
        }
    }
}

