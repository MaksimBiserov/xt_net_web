using System;

namespace Task_3_1_2_TEXT_ANALYSIS
{
    internal class MenuDialog
    {
        // method that provides interaction with the user
        public static void InteractWithUser()
        {
            Console.WriteLine("Добро пожаловать в программу TEXT ANALYSIS!");
            while (true)
            {
                Console.WriteLine("Введите текст или закройте программу для выхода");
                string phrase = Console.ReadLine();
                if (phrase.Length == 0)
                {
                    Console.WriteLine("Вы не ввели ни одного символа");
                }
                else
                {
                    string[] words = WordAnalyzer.DivideIntoWords(phrase);
                    WordAnalyzer.CountWords(words);
                }
            }
        }
    }
}