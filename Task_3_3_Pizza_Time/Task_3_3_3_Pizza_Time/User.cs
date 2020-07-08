using System;
using static System.Console;

namespace Task_3_3_3_Pizza_Time
{
    internal class User
    {
        public event OrdersHandler onMakeOrder;

        public string ID { get; }
        public string Name { get; }

        public User(string iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public void MakeOrder(Menu order)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"ID: {ID} Name: {Name} => Заказываю пиццу {order}");
            ResetColor();
            onMakeOrder?.Invoke();
        }

        public void PickUpOrder()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"ID: {ID} Name: {Name} => Забираю заказ");
            ResetColor();
            WriteLine();
        }
    }
}