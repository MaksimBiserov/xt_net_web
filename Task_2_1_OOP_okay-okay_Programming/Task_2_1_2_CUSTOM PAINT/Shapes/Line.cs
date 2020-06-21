using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    class Line : Shape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public double Length { get; }
        public Line()
        {
            CreateShape();
            Length = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }
        public override void CreateShape()
        {
            Console.WriteLine("Координаты первой точки");
            A = new Point();
            Console.WriteLine("Координаты второй точки");
            B = new Point();
            Console.WriteLine("Фигура создана!");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return string.Format($"Фигура ЛИНИЯ. Координаты точки A: {A}; координаты точки B: {B}; длина: {Length};");
        }
    }
}