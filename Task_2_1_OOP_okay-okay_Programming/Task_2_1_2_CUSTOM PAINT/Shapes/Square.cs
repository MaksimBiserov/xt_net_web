using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // It is based on the coordinates of the upper-left vertex and parallel to the coordinate axes of the face set by the User.
    class Square : Shape
    {
        double edge = 0;
        Point a;
        Point b;
        Point c;
        Point d;
        public double Edge { get; }
        public double Perimeter { get; }
        public double Area { get; }
        public Square()
        {
            CreateShape();
            Edge = edge;
            b = new Point(a.X + Edge, a.Y);
            c = new Point(b.X, b.Y - Edge);
            d = new Point(a.X, c.Y);
            Perimeter = Edge * 4;
            Area = Math.Pow(Edge, 2);
        }
        public override void CreateShape()
        {
            Console.WriteLine("Координаты вершины A");
            a = new Point();
            Console.WriteLine("Введите длину грани");
            while (!double.TryParse(Console.ReadLine(), out edge) || edge < 0)
            {
                Console.WriteLine("Ошибка ввода! Введите неотрицательное число");
            }
            Console.WriteLine("Фигура создана!");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return string.Format($"Фигура КВАДРАТ. Координаты вершины A: {a};" +
                $" Координаты вершины B: {b}; Координаты вершины C: {c}; Координаты вершины D: {d}; " +
                $"периметр: {Perimeter}; площадь: {Area}");
        }
    }
}