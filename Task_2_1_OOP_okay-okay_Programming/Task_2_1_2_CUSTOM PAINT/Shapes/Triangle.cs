using System;

namespace Task_2_1_2_CUSTOM_PAINT
{
    // It is based on the coordinates of 3 sides set by the User.
    class Triangle : Shape
    {
        double ab, bc, ca;
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public double Perimeter { get; }
        public double Area { get; }
        public Triangle()
        {
            CreateShape();
            ab = Math.Pow(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2), 0.5);
            bc = Math.Pow(Math.Pow(B.X - C.X, 2) + Math.Pow(B.Y - C.Y, 2), 0.5);
            ca = Math.Pow(Math.Pow(C.X - A.X, 2) + Math.Pow(C.Y - A.Y, 2), 0.5);
            Perimeter = ab + bc + ca;
            Area = Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - ab) * (Perimeter / bc) * (Perimeter / ca));
        }
        public override void CreateShape()
        {
            Console.WriteLine("Координаты вершины А");
            A = new Point();
            Console.WriteLine("Координаты вершины B");
            B = new Point();
            Console.WriteLine("Координаты вершины C");
            C = new Point();
            Console.WriteLine("Фигура создана!");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return string.Format($"Фигура ТРЕУГОЛЬНИК. Координаты вершины А: {A}; координаты вершины B: {B}; координаты вершины C: {C};" +
                $" периметр: {Perimeter}; площадь: {Area}");
        }
    }
}