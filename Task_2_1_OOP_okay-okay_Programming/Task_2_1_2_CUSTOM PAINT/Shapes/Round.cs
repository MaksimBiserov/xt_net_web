﻿using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // Окружность
    class Round : Shape
    {
        double radius = 0;
        public Point Center { get; set; }
        public double Radius { get; set; }
        public double Length { get; set; }
        public Round()
        {
            Console.WriteLine("Координаты центра");
            Center = new Point();
            Console.WriteLine("Введите длину радиуса");
            while (!double.TryParse(Console.ReadLine(), out radius) || radius < 0)
            {
                Console.WriteLine("Ошибка ввода! Введите неотрицательное число");
            }
            Radius = radius;
            Length = Math.PI * 2 * Radius;
            Console.WriteLine("Фигура создана!");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return string.Format($"Фигура ОКРУЖНОСТЬ. Координаты центра: {Center}; длина радиуса: {Radius};" +
                $" длина {Length}");
        }
    }
}