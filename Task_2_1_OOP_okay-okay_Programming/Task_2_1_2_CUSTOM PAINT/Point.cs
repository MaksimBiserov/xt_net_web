using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // Класс, описывающий точку для задания координат.
    // Экземпляры данного класса создаются в классах фигур для описания вершин или центра.
    class Point
    {
        double coordinateX = 0;
        double coordinateY = 0;
        public double X { get; }
        public double Y { get; }
        public Point()
        {
            Console.WriteLine("Введите координату X");
            while (!double.TryParse(Console.ReadLine(), out coordinateX))
            {
                Console.WriteLine("Ошибка ввода! Введите число");
            }
            Console.WriteLine("Введите координату Y");
            while (!double.TryParse(Console.ReadLine(), out coordinateY))
            {
                Console.WriteLine("Ошибка ввода! Введите число");
            }
            X = coordinateX;
            Y = coordinateY;
        }
        // Перегрузка конструктора с 2-мя входными параметрами
        // используется в классах Rectangle и Square для вычисления координат вершин.
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }
}