using System;
using System.Threading;

namespace Task_2_2_1_Game
{
    class Program
    {
        static Hero hero = new Hero();
        static Monsters monster1;
        static Monsters monster2;
        static Monsters monster3;
        static void Main(string[] args)
        {
            GameHandler gameHandler = new GameHandler();
            AddGameObjects();
            LeadGame();
        }
        static void AddGameObjects()
        {
            Console.CursorVisible = false;

            Bonuses apple = new Bonuses();
            Thread.Sleep(10); // falling asleep for 10 milliseconds allows to draw objects at different points in the field
            Bonuses cherry = new Bonuses();
            Thread.Sleep(10);
            Bonuses mango = new Bonuses();
            Thread.Sleep(10);
            apple.ObjectAdd('@', ConsoleColor.Green);
            cherry.ObjectAdd('@', ConsoleColor.Red);
            mango.ObjectAdd('@', ConsoleColor.Yellow);

            Barriers stone = new Barriers();
            Thread.Sleep(10);
            Barriers wood = new Barriers();
            Thread.Sleep(10);
            Barriers mountain = new Barriers();
            Thread.Sleep(10);
            stone.ObjectAdd('O', ConsoleColor.Gray);
            wood.ObjectAdd('Y', ConsoleColor.Green);
            mountain.ObjectAdd('^', ConsoleColor.DarkCyan);

            monster1 = new Monsters();
            Thread.Sleep(10);
            monster2 = new Monsters();
            Thread.Sleep(10);
            monster3 = new Monsters();
            Thread.Sleep(10);
        }
        static void LeadGame() // drawing characters and displaying the results of the game
        {
            while (true)
            {
                hero.ObjectAdd('H', ConsoleColor.DarkYellow);
                monster1.ObjectAdd('M', ConsoleColor.Red);
                monster2.ObjectAdd('M', ConsoleColor.Red);
                monster3.ObjectAdd('M', ConsoleColor.Red);
                hero.GoIntoField();
                Monsters.GoIntoField(monster1, hero);
                Monsters.GoIntoField(monster2, hero);
                Monsters.GoIntoField(monster3, hero);
                if (hero.Life == false)
                {
                    while (true)
                    {
                        GameHandler.ShowGameOver(hero);
                    }
                }
                if (hero.Count == 3)
                {
                    while (true)
                    {
                        GameHandler.ShowWinner();
                    }
                }
            }
        }
    }
}