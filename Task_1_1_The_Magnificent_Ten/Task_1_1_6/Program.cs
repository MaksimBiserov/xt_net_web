// Для форматирования текста надписи можно использовать различные начертания:
// полужирное, курсивное и подчёркнутое, а также их сочетания.
// Предложите способ хранения информации о форматировании текста надписи и напишите программу,
// которая позволяет устанавливать и изменять начертание

using System;
using static System.Console;

namespace Task_1_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Green;
            StoreFonts();
            ReadKey();
        }
        static void StoreFonts()
        {
            Fonts storage = Fonts.None;
            string status = null;
            do
            {
                WriteLine($"Параметры надписи: {storage}\nВведите\n\t1: bold\n\t2: italic\n\t3: underline");
                status = ReadLine();
                switch (status)
                {
                    case "1":
                        if (storage.HasFlag(Fonts.Bold))
                        {
                            storage = storage ^ Fonts.Bold;
                            if(storage == 0)
                                storage = Fonts.None;
                        }
                            
                        else
                        {
                            if (storage.HasFlag(Fonts.None))
                            {
                                storage = storage ^ Fonts.None;
                            }
                            storage = storage | Fonts.Bold;
                        }
                        break;
                    case "2":
                        if (storage.HasFlag(Fonts.Italic))
                        {
                            storage = storage ^ Fonts.Italic;
                            if (storage == 0)
                                storage = Fonts.None;
                        }
                            
                        else
                        {
                            if (storage.HasFlag(Fonts.None))
                            {
                                storage = storage ^ Fonts.None;
                            }
                            storage = storage | Fonts.Italic;
                        }
                        break;
                    case "3":
                        if (storage.HasFlag(Fonts.Underline))
                        {
                            storage = storage ^ Fonts.Underline;
                            if (storage == 0)
                                storage = Fonts.None;
                        }
                        else
                        {
                            if (storage.HasFlag(Fonts.None))
                            {
                                storage = storage ^ Fonts.None;
                            }
                            storage = storage | Fonts.Underline;
                        }
                        break;
                }
            }
            while (status == "1" || status == "2" || status == "3");
            
        }
        [Flags]
        enum Fonts
        {
            None = 1,
            Bold = 2,
            Italic = 4,
            Underline = 8
        }
    }
}