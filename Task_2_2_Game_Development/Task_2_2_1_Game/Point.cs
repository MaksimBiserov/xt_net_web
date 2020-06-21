using System;

namespace Task_2_2_1_Game
{
    class Point // class responsible for drawing and erasing characters
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Brick { get; set; }
        

        public static implicit operator Point((int, int, char) value)
        {
            return new Point { X = value.Item1, Y = value.Item2, Brick = value.Item3 };
        }
        public void Draw()
        {
            DrawPoint(Brick);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char brick)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(brick);
        }
    }
}