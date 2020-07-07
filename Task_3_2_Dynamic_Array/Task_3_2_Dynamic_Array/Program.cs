using System;
using DynamicArrayLibrary;
using static System.Console;

namespace Task_3_2_Dynamic_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            WriteLine("Исходный массив:");
            foreach (var item in array)
            {
                Write(item + "   ");
            }
            WriteLine();
            WriteLine("Свойство Capacity: " + array.Capacity);
            WriteLine("Свойство Length: " + array.Length);
            WriteLine();
            WriteLine("Применение Add:");
            array.Add(9);
            foreach (var item in array)
            {
                Write(item + "   ");
            }
            WriteLine();
            WriteLine("Свойство Capacity: " + array.Capacity);
            WriteLine("Свойство Length: " + array.Length);
            WriteLine();
            WriteLine("Применение AddRange:");
            array.AddRange(new int[] { 10, 11 });
            foreach (var item in array)
            {
                Console.Write(item + "   ");
            }
            WriteLine();
            WriteLine("Свойство Capacity: " + array.Capacity);
            WriteLine("Свойство Length: " + array.Length);
            WriteLine();
            WriteLine("Применение Remove:");
            array.Remove(9);
            foreach (var item in array)
            {
                Write(item + "   ");
            }
            WriteLine();
            WriteLine("Свойство Capacity: " + array.Capacity);
            WriteLine("Свойство Length: " + array.Length);
            WriteLine();
            WriteLine("Применение Insert:");
            array.Insert(2, 5);
            foreach (var item in array)
            {
                Write(item + "   ");
            }
            WriteLine();
            WriteLine("Свойство Capacity: " + array.Capacity);
            WriteLine("Свойство Length: " + array.Length);
            WriteLine();
            WriteLine("Применение ToArray:");
            int[] array2 = array.ToArray();
            for (int i = 0; i < array2.Length; i++)
            {
                Write(array2[i] + "   ");
            }
            WriteLine();

            ReadKey();
        }
    }
}