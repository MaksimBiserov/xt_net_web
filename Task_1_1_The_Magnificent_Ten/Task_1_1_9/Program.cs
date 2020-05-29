// Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве.
// Число элементов в массиве и их тип определяются разработчиком.

using System;
using System.Threading;
using static System.Console;

namespace Task_1_1_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[20];
            Random random = new Random();
            WriteLine("Generate massive...");
            Thread.Sleep(1000);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100, 100);
                Write($"{arr[i]} ");
                Thread.Sleep(250);
            }
            int nonNegativeSum = CountNonNegativeSum(arr);
            WriteLine($"\nThe sum of non-negative array elements is {nonNegativeSum}");
            ReadKey();
        }
        static int CountNonNegativeSum(int[] arr)
        {
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                    sum += arr[i];
            }
            return sum;
        }
    }
}