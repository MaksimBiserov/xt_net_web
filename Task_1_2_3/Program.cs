// Напишите программу, которая считает количество слов, начинающихся с маленькой буквы.
// Предлоги, союзы и междометия считаются словами.
// Финальную точку в предложении (как и любой другой знак) можно не учитывать.
// Вариант без * - разделителем между словами считать ТОЛЬКО пробелы
// Вариант со * - разделители между словами могут быть любые: запятые, двоеточия, точки с запятой.
// Пример без *:
// ВВОД: Антон выпил кофе и послушал Стинга
// ВЫВОД: 4
// Пример со *:
// ВВОД: Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны
// ВЫВОД: 8


using System;
using static System.Console;

namespace Task_1_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример без *
            string phrase = "Антон выпил кофе и послушал Стинга";
            int numberWords = CalculateWords(phrase);
            WriteLine($"ВВОД: {phrase}");
            WriteLine($"ВЫВОД: {numberWords}");
            // Пример со *
            phrase = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны";
            numberWords = CalculateWords(phrase);
            WriteLine($"ВВОД: {phrase}");
            WriteLine($"ВЫВОД: {numberWords}");
            ReadKey();
        }
        static int CalculateWords(string phrase)
        {
            int numberWords = 0;
            string[] words = phrase.Split(new[] { ' ', '!', '?', ':', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if(word[0].ToString() == word[0].ToString().ToLower())
                    numberWords += 1;
            }
            return numberWords;
        }
    }
}