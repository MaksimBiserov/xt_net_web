using System;
using static System.Console;

namespace Task_3_3_3_Pizza_Time
{
    internal class PizzaShop
    {
        public event OrdersHandler onIssueOrder;

        public string Name { get; set; }

        public PizzaShop(string name)
        {
            Name = name;
        }

        public void CookOrder()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{Name} => Готовлю пиццу...");
            ResetColor();
        }

        public void DisplayOnScoreboard()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{Name} => Ваш заказ готов!");
            ResetColor();
            onIssueOrder?.Invoke();
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