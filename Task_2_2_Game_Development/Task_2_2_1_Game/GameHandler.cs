using System;

namespace Task_2_2_1_Game
{
    class GameHandler
    {
        public GameHandler()
        {
            Console.SetWindowSize(Field.x + 1, Field.y + 1);
            Console.SetBufferSize(Field.x + 1, Field.y + 1);
            Console.CursorVisible = false;
            Field field = new Field(Field.x, Field.y, '*');
        }
        public static void ShowGameOver(Hero hero) // method showing a message about the defeat
        {
            Console.SetCursorPosition(3, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game over!");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Главный герой съеден монстром");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("Для выхода из игры закройте программу");
            Console.ResetColor();
            hero.Life = false;
        }
        public static void ShowWinner() // method showing a message about the win
        {
            Console.SetCursorPosition(3, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Winner!");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Главный герой собрал все бонусы");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("Для выхода из игры закройте программу");
            Console.ResetColor();
        }
    }
}
