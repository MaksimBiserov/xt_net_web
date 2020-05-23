// Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
// Если пользователь вводит некорректные значения (отрицательные или ноль), должно выдаваться сообщение об ошибке.
// Возможность ввода пользователем строки вида «абвгд» или нецелых чисел игнорировать.

using System;
using static System.Console;

namespace Task_1_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WriteLine("Enter the height of rectangle:");
                int a = int.Parse(ReadLine());
                WriteLine("Enter width of rectangle:");
                int b = int.Parse(ReadLine());
                int area = GetRectangleArea(a, b);
                WriteLine($"The area of rectangle is equal to {area}");
            }
            catch (NonNegativeIntException ex)
            {
                WriteLine(ex.Message);
            }
            ReadKey();
        }
        static int GetRectangleArea(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                ForegroundColor = ConsoleColor.Red;
                throw new NonNegativeIntException("Enter non-negative integer values");
            }
            return a * b;
        }
    }
    class NonNegativeIntException : Exception
    {
        public NonNegativeIntException(string message) : base(message) { }
    }
}