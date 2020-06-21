using System;

namespace Task_2_2_1_Game
{
    class Subjects : Objects
    {
        public Subjects() : base() { }

        // to avoid collision between the moving entity is used in the method GoIntoField()
        public bool AvoidCollision(Objects objects)
        {
            if (this.CoordinateX == objects.CoordinateX && this.CoordinateY == objects.CoordinateY)
                return true;
            else
                return false;
        }
    }
    class Hero : Subjects
    {
        public int Count { get; set; } = 0;
        public bool Life { get; set; } = true;
        public Hero() : base() { }
        public void GoIntoField() // a method that allows the main character to move and meet other objects
        {
            int lastX = this.CoordinateX;
            int lastY = this.CoordinateY;
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        if (this.CoordinateX > 1)
                        {
                            this.ObjectErase();
                            this.CoordinateX--;
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        if (this.CoordinateX < Field.x - 1)
                        {
                            this.ObjectErase();
                            this.CoordinateX++;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        if (this.CoordinateY < Field.y - 1)
                        {
                            this.ObjectErase();
                            this.CoordinateY++;
                        }
                    }
                    break;
                case ConsoleKey.UpArrow:
                    {
                        if (this.CoordinateY > 1)
                        {
                            this.ObjectErase();
                            this.CoordinateY--;
                        }
                    }
                    break;
            }
            for (int i = 0; i < objects.Count; i++)
            {
                if (this != objects[i] && this.AvoidCollision(objects[i]) == true)
                {
                    if (objects[i] is Bonuses)
                    {
                        objects[i].ObjectErase();
                        this.Count++;
                    }
                    else if (objects[i] is Monsters)
                    {
                        this.ObjectErase();
                        this.Life = false;
                    }
                    else if (objects[i] is Barriers)
                    {
                        this.CoordinateX = lastX;
                        this.CoordinateY = lastY;
                    }
                }
            }
        }
    }
    class Monsters : Subjects
    {
        public Monsters() : base() { }
        public static void GoIntoField(Monsters monster, Hero hero) // a method for moving monsters
                                                                    // and meeting them with other objects
        {
            int lastX = monster.CoordinateX;
            int lastY = monster.CoordinateY;
            if (monster.CoordinateX < hero.CoordinateX && monster.CoordinateY > 1)
            {
                monster.ObjectErase();
                monster.CoordinateX++;
                monster.CoordinateY--;
            }
            else if (monster.CoordinateX > hero.CoordinateX && monster.CoordinateY > 1)
            {
                monster.ObjectErase();
                monster.CoordinateX--;
                monster.CoordinateY--;
            }
            else if (monster.CoordinateY < hero.CoordinateY && monster.CoordinateX < Field.x - 1)
            {
                monster.ObjectErase();
                monster.CoordinateY++;
                monster.CoordinateX++;
            }
            else if (monster.CoordinateY > hero.CoordinateY && monster.CoordinateX > 1)
            {
                monster.ObjectErase();
                monster.CoordinateY--;
                monster.CoordinateX--;
            }
            if(monster.CoordinateX == hero.CoordinateX && monster.CoordinateY == hero.CoordinateY)
            {
                GameHandler.ShowGameOver(hero);
            }
            for (int i = 0; i < objects.Count; i++)
            {
                if (monster != objects[i] && monster.AvoidCollision(objects[i]) == true)
                {
                    if (objects[i] is Barriers || objects[i] is Bonuses)
                    {
                        monster.CoordinateX = lastX;
                        monster.CoordinateY = lastY;
                    }
                }   
            }
        }
    }
}