// Написать программу, которая генерирует случайным образом элементы массива
// (число элементов в массиве и их тип определяются разработчиком),
// определяет для него максимальное и минимальное значения,
// сортирует массив и выводит полученный результат на экран.
// Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) использовать в данном задании запрещается.

using System;
using System.Threading;
using static System.Console;

namespace Task_1_1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = GenerateArray(20);
            int minValue = SearchMinValue(arr);
            int maxValue = SearchMaxValue(arr);
            WriteLine("Generate massive...");
            Thread.Sleep(1000);
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"{arr[i]} ");
                Thread.Sleep(250);
            }
            WriteLine($"\nThe massive generated succesfull.\n");
            Thread.Sleep(800);
            WriteLine($"Smallest value is { minValue }, largest value is { maxValue }.\n");
            WriteLine("Sort massive...");
            Thread.Sleep(1000);
            int[] arrSort = SortArray(arr);
            for(int i = 0; i < arrSort.Length; i++)
            {
                Write($"{arrSort[i]} ");
                Thread.Sleep(350);
            }
            WriteLine($"\nThe massive generated succesfull.");
            ReadKey();
        }
        static int[] GenerateArray(int size)
        {
            int[] arr = new int[size];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100, 100);
            }
            return arr;
        }
        static int SearchMinValue(int[] arr)
        {
            int minValue = 100;
            for(int i = 0; i < arr.Length; i++)
            {
                if (minValue > arr[i]) minValue = arr[i];
            }
            return minValue;
        }
        static int SearchMaxValue(int[] arr)
        {
            int maxValue = -100;
            for (int i = 0; i < arr.Length; i++)
            {
                if (maxValue < arr[i]) maxValue = arr[i];
            }
            return maxValue;
        }
        static int[] SortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
            return arr;
        }
    }
}