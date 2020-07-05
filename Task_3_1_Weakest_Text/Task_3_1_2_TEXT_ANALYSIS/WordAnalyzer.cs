using System;
using System.Collections.Generic;

namespace Task_3_1_2_TEXT_ANALYSIS
{
    internal class WordAnalyzer
    {
        // method that converts a string to an array of words
        internal static string[] DivideIntoWords(string phrase)
        {
            string[] words = phrase.Split(new[] { ' ', '!', '?', ':', ';', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        // method for checking for repeated words using a dictionary
        internal static void CountWords(string[] words)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            int count = 0;
            foreach (var item in words)
            {
                if (!wordsCount.ContainsKey(item))
                {
                    wordsCount.Add(item.ToLower(), 1);
                }
                else
                {
                    wordsCount[item] += 1;
                    count++;
                }
            }
            foreach (KeyValuePair<string, int> item in wordsCount)
            {
                if (item.Value > 1)
                {
                    Console.WriteLine($"Вы использовали слово {item.Key} {item.Value} раз.");
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Ваша речь разнообразна");
            }
            else
            {
                Console.WriteLine("Поработайте над разнообразием речи");
            }
        }
    }
}