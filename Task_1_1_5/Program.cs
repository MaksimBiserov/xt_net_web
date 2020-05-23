﻿// Если выписать все натуральные числа меньше 10,
// кратные 3 или 5, то получим 3, 5, 6 и 9.
// Сумма этих чисел будет равна 23. Напишите программу,
// которая выводит на экран сумму всех чисел меньше 1000, кратных 3 или 5.

using System;
using static System.Console;

namespace Task_1_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            SumNumbers();
            ReadKey();
        }
        static void SumNumbers()
        {
            int sum = 0;
            for(int i = 3; i < 1000; i++)
            {
                if(i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            WriteLine(sum);
        }
    }
}
