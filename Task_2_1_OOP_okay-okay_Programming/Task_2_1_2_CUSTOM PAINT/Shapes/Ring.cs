using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // Кольцо
    // В данном классе НЕ используется агрегация класса Circle для описания внутреннего и внешнего круга
    // т. к. это привело бы не к сокращению, а к увеличению количества кода - пришлось бы делать перегрузку конструктора
    // в классе Circle для получения входных параметров
    class Ring : Shape
    {
        double externalRadius = 0;
        double internalRadius = 0;
        public Point Center { get; }
        public double ExternalRadius { get; }
        public double InternalRadius { get; }
        public double Area { get; }
        public double Length { get; }
        public Ring()
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
            ExternalRadius = externalRadius;
            InternalRadius = internalRadius;
            Length = (Math.PI * 2 * ExternalRadius) + (Math.PI * 2 * InternalRadius);
            Area = (Math.PI * Math.Pow(ExternalRadius, 2)) - (Math.PI * Math.Pow(InternalRadius, 2));
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