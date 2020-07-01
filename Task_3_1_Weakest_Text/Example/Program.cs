using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Persons = new List<string>() { "Аня", "Катя", "Петя", "Маша", "Даша", "Коля", "Вася", "Дима", "Юра", "Наташа", "Виталя" };
            var Surviver = Lost(Persons);
            Console.ReadKey();
        }
        static public List<T> Lost<T>(List<T> persons)
        {
            List<T> Lostpersons = new List<T>();
            if (persons.Count < 2) return persons;
            else
            {
                for (int i = 0; i < persons.Count; i += 2)
                {
                    Lostpersons.Add(persons[i]);
                }
                Console.WriteLine("Остались в живых");
                foreach (var item in Lostpersons)
                {
                    Console.WriteLine(item.ToString());
                }
                return Lost<T>(Lostpersons);
            }
        }
    }
}