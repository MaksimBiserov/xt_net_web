using System;

namespace Task_3_3_3_Pizza_Time
{
    public delegate void OrdersHandler(Menu order);

    internal class Program
    {
        static void Main(string[] args)
        {
            PizzaShop pizzaShop = new PizzaShop("Turtles Pizza Shop");

            User user01 = new User("01", "Leonardo");
            BuildProcessing(user01, pizzaShop, Menu.Caprese);

            User user02 = new User("02", "Raphael");
            BuildProcessing(user02, pizzaShop, Menu.Margherita);

            User user03 = new User("03", "Michelangelo");
            BuildProcessing(user03, pizzaShop, Menu.Padana);

            User user04 = new User("04", "Donatello");
            BuildProcessing(user04, pizzaShop, Menu.Tirolese);

            Console.ReadKey();
        }
        static void BuildProcessing(User user, PizzaShop pizzaShop, Menu order)
        {
            user.onMakeOrder += pizzaShop.CookOrder;
            user.onMakeOrder += pizzaShop.DisplayOnScoreboard;
            pizzaShop.onIssueOrder += user.PickUpOrder;
            user.MakeOrder(order);
            pizzaShop.onIssueOrder -= user.PickUpOrder;
        }
    }
}