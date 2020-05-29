// Написать программу, которая запрашивает с клавиатуры число N
// и выводит на экран следующее «изображение», состоящее из N строк

using System;
using static System.Console;

namespace Task_1_1_2
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
                DrawRectangle(n);
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
        static void DrawRectangle(int n)
        {
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Write("*");
                }
                WriteLine();
            }
        }
    }
}