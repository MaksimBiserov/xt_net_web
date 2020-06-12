using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // Прямоугольник
    // Строится по координатам левой верхней вершины, и параллельным осям координат длине и высоте, задаваемыми Пользователем.
    class Rectangle : Shape
    {
        double width = 0;
        double height = 0;
        readonly Point a;
        readonly Point b;
        readonly Point c;
        readonly Point d;
        public double Width { get; }
        public double Height { get; }
        public double Perimeter { get; }
        public double Area { get; }
        public Rectangle()
        {
            Console.WriteLine("Координаты вершины A");
            a = new Point();
            Console.WriteLine("Введите длину");
            while (!double.TryParse(Console.ReadLine(), out width) || width < 0)
            {
                Console.WriteLine("Ошибка ввода! Введите неотрицательное число");
            }
            Console.WriteLine("Введите высоту");
            while (!double.TryParse(Console.ReadLine(), out height) || height < 0)
            {
                Console.WriteLine("Ошибка ввода! Введите неотрицательное число");
            }
            Width = width;
            Height = height;
            b = new Point(a.X + Width, a.Y);
            c = new Point(b.X, b.Y - Height);
            d = new Point(a.X, c.Y);
            Perimeter = (Width + Height) * 2;
            Area = Width * Height;
            Console.WriteLine("Фигура создана!");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return string.Format($"Фигура ПРЯМОУГОЛЬНИК. Координаты вершины A: {a};" +
                $" Координаты вершины B: {b}; Координаты вершины C: {c}; Координаты вершины D: {d}; " +
                $"периметр: {Perimeter}; площадь: {Area}");
        }
    }
}