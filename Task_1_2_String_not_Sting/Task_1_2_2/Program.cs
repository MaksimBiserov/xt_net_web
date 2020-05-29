// Напишите программу, которая удваивает в первой введённой строке все символы, принадлежащие второй введённой строке.
// Пример:
// ВВОД 1: написать программу, которая
// ВВОД 2: описание
// ВЫВОД: ннааппииссаать ппроограамму, коотоораая

using System.Linq;
using static System.Console;

namespace Task_1_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = "написать программу, которая";
            string secondString = "описание";
            WriteLine($"ВВОД 1: {firstString}");
            WriteLine($"ВВОД 2: {secondString}");
            string stringResult = Redouble(firstString, secondString);
            WriteLine($"ВЫВОД: {stringResult}");
            ReadKey();
        }
        static string Redouble(string firstString, string secondString)
        {
            string stringResult = null;
            for(int i = 0; i < firstString.Length; i++)
            {
                if (secondString.Contains(firstString[i]))
                {
                    stringResult += firstString[i];
                    stringResult += firstString[i];
                }
                else
                {
                    stringResult += firstString[i];
                }
            }
            return stringResult;
        }
    }
}