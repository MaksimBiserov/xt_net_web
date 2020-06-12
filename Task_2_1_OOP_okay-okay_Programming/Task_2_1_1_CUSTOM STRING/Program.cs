using System;
using CustomStringLibrary;

namespace Task_2_1_1_CUSTOM_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking ctor and prop CustomValue, Length");
            CustomString str1 = new CustomString(new[] { 'H', 'e', 'l', 'l', 'o' });
            Console.WriteLine(str1.CustomValue);
            Console.WriteLine(str1.Length);
            Console.WriteLine("Checking method CustomCompare");
            CustomString str2 = new CustomString(new[] { 'H', 'e', 'l', 'l', 'o' });
            Console.WriteLine(str2.CustomValue);
            Console.WriteLine(CustomString.CustomCompare(str1, str2));
            Console.WriteLine(str1 == str2);
            Console.WriteLine("Checking method CustomConcat");
            Console.WriteLine(CustomString.CustomConcat(str1, str2).CustomValue);
            Console.WriteLine("Checking method ToCustomString");
            Console.WriteLine(CustomString.ToCustomString(new[] { 'w', 'o', 'r', 'l', 'd' }).CustomValue);
            CustomString str3 = new CustomString(new[] { 'w', 'o', 'r', 'l', 'd' });
            Console.WriteLine(CustomString.ToCustomString(str3).CustomValue);
            Console.WriteLine("Checking method ToArray");
            CustomString str4 = new CustomString();
            str4 = str3;
            Console.WriteLine(CustomString.ToArray(str4));
            foreach (char ch in CustomString.ToArray(str4))
                Console.Write(ch);
            Console.WriteLine();
            Console.WriteLine("Checking method FindLiteral");
            int index = str4.FindLiteral('r');
            Console.WriteLine(index);
            Console.WriteLine("Checking method CustomReverse");
            Console.WriteLine(CustomString.CustomReverse(str4).CustomValue);
            Console.WriteLine("Checking reload operator +");
            Console.WriteLine((str2 + str3).CustomValue);
            Console.ReadKey();
        }
    }
}
