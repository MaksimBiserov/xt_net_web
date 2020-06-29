using System;
using System.Collections.Generic;

namespace Task_3_1_1_WEAKEST_LINK
{
    static class Game
    {
        public static void LaunchDialogConsole()
        {
            int numberOfPeople = 0;
            int numberDelete = 0;
            Console.WriteLine("Введите количество людей");
            while (!int.TryParse(Console.ReadLine(), out numberOfPeople))
            {
                Console.WriteLine("Ошибка, введите целое число");
            }
            Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд");
            while (!int.TryParse(Console.ReadLine(), out numberDelete))
            {
                Console.WriteLine("Ошибка, введите целое число");
            }
            CountInCircle(numberOfPeople, numberDelete);
        }
        public static void CountInCircle(int numberOfPeople, int numberDelete)
        {
            int numberOfPeopleBegin = numberOfPeople;
            int countRound = 0;
            int begin = 0;
            int deleted = 0;
            int search = 0;
            Dictionary<int, string> list = new Dictionary<int, string>();
            list.Add(begin + 1, (begin + 1).ToString());
            for (int i = begin + 1; i < numberOfPeople; i++)
            {
                list.Add(i + 1, (i + 1).ToString());
            }
            Console.WriteLine($"Сгенерирован круг из {numberOfPeople} людей.");
            foreach (KeyValuePair<int, string> keyValue in list)
            {
                Console.WriteLine(keyValue.Value + "-ый участник");
            }
            Console.WriteLine($"Начинаем вычеркивать каждого {numberDelete}-го");

            while (numberOfPeople > 1)
            {
                if ((numberDelete + begin + deleted <= numberOfPeopleBegin))
                {
                    search = numberDelete + begin + deleted;
                }
                else
                {
                    search = numberDelete + begin - numberOfPeopleBegin + deleted;
                    deleted += 2;
                }
                list.Remove(search);
                begin = search;
                numberOfPeople--;
                countRound++;
                Console.WriteLine($"Раунд {countRound}. Вычеркнут {search}-ый участник. Людей осталось: {numberOfPeople}");
                foreach (KeyValuePair<int, string> keyValue in list)
                {
                    Console.WriteLine(keyValue.Value + "-ый");
                }
            }
            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
        }
    }
}