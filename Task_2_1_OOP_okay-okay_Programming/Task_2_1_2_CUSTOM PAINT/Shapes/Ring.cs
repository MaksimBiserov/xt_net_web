using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // This class does NOT use aggregation of the Circle class to describe an inner and outer circle
    // because this would lead not to a reduction, but to an increase in the amount of code
    // we would have to overload the constructor in the Circle class to get input parameters
    class Ring : Shape
    {
        double externalRadius = 0;
        double internalRadius = 0;
        public Point Center { get; set; }
        public double ExternalRadius { get; }
        public double InternalRadius { get; }
        public double Area { get; }
        public double Length { get; }
        public Ring()
        {
            CreateShape();
            ExternalRadius = externalRadius;
            InternalRadius = internalRadius;
            Length = (Math.PI * 2 * ExternalRadius) + (Math.PI * 2 * InternalRadius);
            Area = (Math.PI * Math.Pow(ExternalRadius, 2)) - (Math.PI * Math.Pow(InternalRadius, 2));
        }
        public override void CreateShape()
        {
            Console.WriteLine("Координаты центра");
            Center = new Point();
            Console.WriteLine("Введите длину внешнего радиуса");
            while (!double.TryParse(Console.ReadLine(), out externalRadius) || externalRadius < 0)
            {
                Console.WriteLine("Ошибка ввода! Введите неотрицательное число");
            }
            Console.WriteLine("Введите длину внутреннего радиуса");
            while (!double.TryParse(Console.ReadLine(), out internalRadius) || internalRadius < 0)
            {
                Console.WriteLine("Ошибка ввода! Введите неотрицательное число");
            }
            while (internalRadius > externalRadius)
            {
                Console.WriteLine("Некорректные данные! Внешний радиус не может быть больше внутреннего");
                Console.WriteLine("Введите длину внутреннего радиуса");
                while (!double.TryParse(Console.ReadLine(), out internalRadius) || internalRadius < 0)
                {
                    Console.WriteLine("Ошибка ввода! Введите неотрицательное число");
                }
            }
            Console.WriteLine("Фигура создана!");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return string.Format($"Фигура КОЛЬЦО. Координаты центра: {Center}; длина внешнего радиуса: {ExternalRadius};" +
                $" длина внутреннего радиуса: {InternalRadius}; суммарная длина внешней и внутренней окружностей: {Length};" +
                $" площадь: {Area}");
        }
    }
}