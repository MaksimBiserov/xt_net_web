// Написать программу, которая запрашивает с клавиатуры число N
// и выводит на экран следующее «изображение», состоящее из N треугольников

using System;
using static System.Console;

namespace Task_1_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WriteLine("Enter value:");
                int n = int.Parse(ReadLine());
                ForegroundColor = ConsoleColor.Green;
                DrawXMasTree(n);
                ResetColor();
            }
            catch (FormatException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            ReadKey();
        }
        static void DrawXMasTree(int n)
        {
            for (int i = 1; i <= n + 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    string s = new string('*', j);
                    WriteLine(s.PadLeft(n + 3) + "*" + s);
                }
            }
        }
    }
}