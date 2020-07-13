using System;
using System.Threading;
using static System.Console;

namespace Task_3_3_3_Pizza_Time
{
    internal class PizzaShop
    {
        public event OrdersHandler onIssueOrder; // order availability event

        public string Name { get; set; }

        public PizzaShop(string name)
        {
            Name = name;
        }

        public void CookOrder(Menu order)
        {
            ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(1000);
            WriteLine($"{Name} -> Готовлю пиццу {order}...");
            Thread.Sleep(1500);
            ResetColor();
        }

        public void DisplayOnScoreboard(Menu order)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{Name} -> Ваш заказ готов!");
            ResetColor();
            onIssueOrder?.Invoke(order);
        }
    }

    public enum Menu
    {
        Carbonara,
        Caprese,
        Margherita,
        Napoletana,
        Padana,
        Tedesca,
        Tirolese
    }
}