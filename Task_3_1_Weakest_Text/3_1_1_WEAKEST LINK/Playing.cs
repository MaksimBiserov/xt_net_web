using System.Collections.Generic;
using static System.Console;

namespace Task_3_1_1_WEAKEST_LINK
{
    internal static class Playing
    {
        public static void LaunchDialogConsole()
        {
            int totalNumber = 0;
            int deletedNumber = 0;
            WriteLine("Введите общее количество участников");
            while (!int.TryParse(ReadLine(), out totalNumber) || totalNumber < 2)
            {
                WriteLine("Ошибка, введите целое число участников. В кругу должно быть не менее 2-х участников");
            }
            WriteLine("Введите, какой по счету участник будет вычеркнут в каждом раунде");
            while (!int.TryParse(ReadLine(), out deletedNumber) || deletedNumber < 2)
            {
                WriteLine("Ошибка, введите целое число больше 1");
            }
            GenerateParticipants(totalNumber, deletedNumber);
        }

        static void GenerateParticipants(int totalNumber, int deletedNumber)
        {
            List<Participant> list = new List<Participant>();
            int countRound = 0;
            int temp = deletedNumber;
            int counter = 0;
            int deleted = 0;

            for (int i = 1; i <= totalNumber; i++)
            {
                list.Add(new Participant(i));
            }

            WriteLine($"Сгенерирован круг из {totalNumber} людей.");

            foreach (var i in list)
            {
                WriteLine(i.Number + "-ый участник");
            }

            WriteLine($"Начинаем вычеркивать каждого {deletedNumber}-го");

            while (list.Count != 1)
            {
                --temp;
                if (counter >= list.Count)
                {
                    counter = 0;
                }
                if (temp == 0)
                {
                    deleted = list[counter].Number;
                    list.RemoveAt(counter);
                    counter--;
                    temp = deletedNumber;
                    countRound++;
                    WriteLine($"Раунд {countRound}. Вычеркнут {deleted}-ый участник. Людей осталось: {list.Count}");
                    foreach (var i in list)
                    {
                        WriteLine(i.Number + "-ый участник");
                    }
                }
                counter++;
            }
            WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
            ReadKey();
        }
    }
}