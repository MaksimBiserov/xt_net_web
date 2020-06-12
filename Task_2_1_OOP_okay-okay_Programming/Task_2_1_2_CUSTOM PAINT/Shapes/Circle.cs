using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // Круг
    class Circle : Round
    {
        // Свойство площади круга, расширение функционала окружности
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