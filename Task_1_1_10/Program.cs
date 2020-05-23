// Элемент двумерного массива считается стоящим на чётной позиции,
// если сумма номеров его позиций по обеим размерностям является чётным числом
// (например, [1, 1] — чётная позиция, а[1, 2] — нет).
// Определить сумму элементов массива, стоящих на чётных позициях.

using System;
using System.Threading;
using static System.Console;

namespace Task_1_1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[5, 5];
            Random random = new Random();
            WriteLine("Array is generated. The elements that will be summed up are highlighted in red...\n");
            Thread.Sleep(1000);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(0, 5);
                    if((i + j) % 2 == 0 && i + j != 0)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        Write($"{arr[i, j]}  ");
                        ResetColor();
                    }
                    else
                        Write($"{arr[i, j]}  ");
                }
                WriteLine();
            }
            int sumEvenPosition = SumEvenPosition(arr);
            WriteLine($"\nSum of the selection of elements is {sumEvenPosition}");
            ReadKey();
        }
        static int SumEvenPosition(int[,] arr)
        {
            int sumEvenPosition = 0;
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0 && (i + j != 0)) sumEvenPosition += arr[i, j];
                }
            }
            return sumEvenPosition;
        }
    }
}
