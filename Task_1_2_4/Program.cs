// Напишите программу, которая заменяет первую букву первого слова в предложении на заглавную.
// В качестве окончания предложения можете считать только «.|?|!». Многоточие и «?!» можете опустить.
// Пример:
// ВВОД: я плохо учил русский язык.забываю начинать предложения с заглавной.хорошо, что можно написать программу!
// ВЫВОД: Я плохо учил русский язык.Забываю начинать предложения с заглавной.Хорошо, что можно написать программу!

using static System.Console;

namespace Task_1_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPhrase = "я плохо учил русский язык.забываю начинать предложения с заглавной.хорошо, что можно написать программу!";
            string outputPhrase = PhraseValidate(inputPhrase);
            WriteLine($"ВВОД: {inputPhrase}");
            WriteLine($"ВЫВОД: {outputPhrase}");
            ReadKey();
        }
        static string PhraseValidate(string phrase)
        {
            char[] output = new char[phrase.Length];
            string outputPhrase = null;
            for(int i = 0; i < phrase.Length - 1; i++)
            {
                if (i == 0)
                    output[i] = char.ToUpper(phrase[i]);
                else if(phrase[i] == '.' || phrase[i] == '?' || phrase[i] == '!')
                    output[i + 1] = char.ToUpper(phrase[i + 1]);
                else
                    output[i + 1] = phrase[i + 1];
            }
            for(int i = 0; i < output.Length; i++)
                outputPhrase += output[i];
            return outputPhrase;
        }
    }
}