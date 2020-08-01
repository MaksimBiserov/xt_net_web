using System;
using System.Diagnostics;
using System.Reflection;
using static System.Console;

namespace Task_4_1_1_FILE_MANAGEMENT_SYSTEM
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            CreatorDefault.CreateSourceFilesAndFolders();
            Display();
        }

        private static void Display()
        {
            while (true)
            {
                WriteLine("Выберите режим");
                WriteLine("1 - наблюдение");
                WriteLine("2 - откат");
                string choose = ReadLine();

                if (choose == "1")
                {
                    WriteLine("Включён режим наблюдателя.");
                    WriteLine($"Рабочая папка: {CreatorDefault.PathMain}");
                    WriteLine($"Папка резервных копий: {CreatorDefault.PathRecovery}");
                    WriteLine($"Файл логирования изменений: {CreatorDefault.PathLog}");
                    WriteLine($"Пожалуйста, закройте файл {CreatorDefault.PathLog}, если он открыт.");
                    WriteLine("Для возврата в меню нажмите Enter");
                    Viewer.View();
                    ReadKey();

                    // restarting the application to copy files correctly if the user selects "2"

                    Process.Start(Assembly.GetExecutingAssembly().Location);
                    Environment.Exit(0);
                }

                else if (choose == "2")
                {
                    WriteLine("Включён режим отката.");
                    WriteLine("Введите желаемую дату в формате dd.mm.yyyy hh:mm:ss");
                    DateTime date;

                    while (!DateTime.TryParse(ReadLine(), out date))
                    {
                        WriteLine("При вводе используйте именно формат dd.mm.yyyy hh:mm:ss");
                    }

                    Recovery.Recover(date);
                    WriteLine("Копия восстановлена.");
                    WriteLine("Для возврата в меню нажмите Enter");
                    ReadKey();
                }

                else
                {
                    WriteLine("Введите одну из цифр, указанных в меню.");
                }
            }
        }
    }
}