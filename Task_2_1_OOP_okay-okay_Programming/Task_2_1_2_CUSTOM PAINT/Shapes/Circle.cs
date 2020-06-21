using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    class Circle : Round
    {
        // Property the area of a circle, the expansion of the functionality of the circle
        public double Area { get; }
        public Circle() : base()
        {
            Area = Math.PI * Math.Pow(Radius, 2);
        }
        public override string ToString()
        {
            return string.Format($"Фигура КРУГ. Координаты центра: {Center}; длина радиуса: {Radius};" +
                $"  длина {Length}; площадь: {Area}");
        }
    }
}