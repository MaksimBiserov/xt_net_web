// Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули.
// Число элементов в массиве и их тип определяются разработчиком.

using System;
using static System.Console;

namespace Task_1_1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] arr = new int[3, 3, 3];
            Random random = new Random();
            WriteLine("Original array: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        arr[i, j, k] = random.Next(-10, 10);
                        Write($"{arr[i, j, k]} ");
                    }
                    WriteLine();
                }
                WriteLine();
            }
                
            int[,,] resultArr = GetNoPositiveArray(arr);
            WriteLine("Non-positive array: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Write($"{resultArr[i, j, k]} ");
                    }
                    WriteLine();
                }
                WriteLine();
            }
                
            ReadKey();
        }
        static int[,,] GetNoPositiveArray(int[,,] arr)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        if (arr[i, j, k] > 0) arr[i, j, k] = 0;
            return arr;
        }
    }
}