using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2_1_2_CUSTOM_PAINT
{
    class MenuDialog
    {
        List<Shape> shapes = new List<Shape>();
        string login = null;
        public void WorkRedactor() // method of interaction with the User
        {
            do
            {
                Authorize();
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Добавить фигуру");
                Console.WriteLine("2. Вывести фигуры");
                Console.WriteLine("3. Очистить холст");
                Console.WriteLine("4. Выход");
                Console.WriteLine("5. Сменить пользователя");
                int variant;
                while (!int.TryParse(Console.ReadLine(), out variant))
                    Console.WriteLine("Введите корректное значение (число от 1 до 5)");

                switch (variant)
                {
                    case 1:
                        CreateShape();
                        break;
                    case 2:
                        DrawShapes();
                        break;
                    case 3:
                        {
                            ClearCanvas();
                            Console.WriteLine("Холст очищен");
                            Console.WriteLine();
                        }
                        
                        break;
                    case 4:
                        {
                            Console.WriteLine("Нажмите любую клавишу для выхода");
                            Console.WriteLine();
                            return;
                        }
                    case 5:
                        login = null;
                        break;
                    default:
                        break;
                }
            }
            while (true);
        }

        private void CreateShape() // method for adding shapes
        {
            Console.WriteLine("Выберите фигуру");
            Console.WriteLine("1. Линия");
            Console.WriteLine("2. Окружность");
            Console.WriteLine("3. Круг");
            Console.WriteLine("4. Кольцо");
            Console.WriteLine("5. Треугольник");
            Console.WriteLine("6. Прямоугольник");
            Console.WriteLine("7. Квадрат");
            Console.WriteLine();
            int variant;
            while (!int.TryParse(Console.ReadLine(), out variant))
                Console.WriteLine("Введите корректное значение");

            switch (variant)
            {
                case 1:
                    shapes.Add(new Line());
                    break;
                case 2:
                    shapes.Add(new Round());
                    break;
                case 3:
                    shapes.Add(new Circle());
                    break;
                case 4:
                    shapes.Add(new Ring());
                    break;
                case 5:
                    shapes.Add(new Triangle());
                    break;
                case 6:
                    shapes.Add(new Rectangle());
                    break;
                case 7:
                    shapes.Add(new Square());
                    break;
                default:
                    break;
            }
        }
        void Authorize() // the implementation of the variant with * - Add User
        {
            if (login == null)
            {
                Console.WriteLine("Введите имя");
                login = Console.ReadLine();
                Console.WriteLine($"Добро пожаловать, {login}");
            }
        }
        void DrawShapes() // Method for drawing shapes
        {
            Console.WriteLine("Вывод фигур:");

            if (shapes.Count() == 0)
                Console.WriteLine("Список пуст");

            foreach (Shape shape in shapes)
                Console.WriteLine(shape.ToString());
        }

        void ClearCanvas() // Method for clearing the canvas (list)
        {
            shapes.Clear();
        }
    }
}