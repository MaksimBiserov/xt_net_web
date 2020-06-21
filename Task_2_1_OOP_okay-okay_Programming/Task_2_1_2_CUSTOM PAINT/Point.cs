using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // Class that describes the point for setting coordinates.
    // Instances of this class are created in shape classes to describe vertices or centers.
    class Point
    {
        double coordinateX = 0;
        double coordinateY = 0;
        public double X { get; }
        public double Y { get; }
        public Point()
        {
            CreatePoint();
            X = coordinateX;
            Y = coordinateY;
        }
        // Overloading the constructor with 2 input parameters
        // used in the Rectangle and Square classes for calculating vertex coordinates.
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public void CreatePoint()
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
        }
        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }
}