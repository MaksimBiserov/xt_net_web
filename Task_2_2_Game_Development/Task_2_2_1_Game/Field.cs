using System.Collections.Generic;

namespace Task_2_2_1_Game
{
    // class that draws the boundaries of a rectangular field
    class Field
    {
        public static readonly int x = 120;
        public static readonly int y = 35;
        char brick;
        List<Point> wall = new List<Point>();
        public Field(int x, int y, char brick)
        {
            this.brick = brick;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x, y);
        }
        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point p = (i, y, brick);
                p.Draw();
                wall.Add(p);
            }
        }
        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = (x, i, brick);
                p.Draw();
                wall.Add(p);
            }
        }
    }
}