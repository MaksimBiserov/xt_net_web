using System;
using System.Collections.Generic;

namespace Task_2_2_1_Game
{
    class Objects
    {
        public static List<Objects> objects = new List<Objects>();
        Random random = new Random((int)DateTime.Now.Ticks); // Datetime with a minimum step of 100 nanoseconds
                                                             // allows to draw objects at different points in the field
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Objects()
        {
            CoordinateX = random.Next(1, Field.x);
            CoordinateY = random.Next(1, Field.y);
            objects.Add(this);
        }
        public void ObjectAdd(char visualAppearance, ConsoleColor color)
        {
            Point obj = new Point();
            obj.Brick = visualAppearance;
            Console.SetCursorPosition(CoordinateX, CoordinateY);
            Console.ForegroundColor = color;
            Console.Write(obj.Brick);
            Console.ResetColor();
        }
        public void ObjectErase()
        {
            Console.SetCursorPosition(CoordinateX, CoordinateY);
            Console.Write(' ');
            objects.Remove(this);
        }
    }
    class Bonuses : Objects
    {
        public Bonuses() : base() { }
    }
    class Barriers : Objects
    {
        public Barriers() : base() { }
    }
}