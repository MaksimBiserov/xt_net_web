using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // Класс квадрат
    // Строится по координатам левой верхней вершины, и параллельной осям координат грани, задаваемыми Пользователем.
    class Square : Shape
    {
        double edge = 0;
        readonly Point a;
        readonly Point b;
        readonly Point c;
        readonly Point d;
        public double Edge { get; }
        public double Perimeter { get; }
        public double Area { get; }
        public Square()
        {
            Console.WriteLine("Координаты вершины A");
            a = new Point();
            Console.WriteLine("Введите длину грани");
            while (!double.TryParse(Console.ReadLine(), out edge) || edge < 0)
            {
                Console.WriteLine("Ошибка ввода! Введите неотрицательное число");
            }
            Edge = edge;
            b = new Point(a.X + Edge, a.Y);
            c = new Point(b.X, b.Y - Edge);
            d = new Point(a.X, c.Y);
            Perimeter = Edge * 4;
            Area = Math.Pow(Edge, 2);
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