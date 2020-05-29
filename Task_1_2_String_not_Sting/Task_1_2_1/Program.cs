// Напишите программу, которая определяет среднюю длину слова во введённой текстовой строке.
// Учтите, что символы пунктуации на длину слов влиять не должны.
// Не стоит искать каждый символ-разделитель вручную:
// пожалейте своё время и используйте стандартные методы классов String и Char.
// Регулярные выражения не использовать.
// В случае дробного результата (х.5) – можете как оставить его таким, так и округлить.
// Стоит оставить комментарий в коде, указывающий, какое решение вы приняли.
// Пример:
// ВВОД: Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате
// ВЫВОД: 6

using System;
using static System.Console;

namespace Task_1_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = "Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате";
            double averageLength = CalculateLength(phrase);
            WriteLine($"ВВОД: {phrase}");
            WriteLine($"ВЫВОД: { averageLength}");
            ReadKey();
        }
        // метод возвращает результат дробном виде
        static double CalculateLength(string phrase)
        {
            double numberLettersPhrase = 0;
            string[] words = phrase.Split(new[] { ' ', '!', '?', ':', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                numberLettersPhrase += word.Length;
            }
            return numberLettersPhrase / words.Length;
        }
    }
}