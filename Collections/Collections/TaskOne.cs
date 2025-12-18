using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class TaskOne
    {
        List<string> list = new List<string>() { "Яблоко", "Груша", "Апельсин", "Мандарин"};

        public void TaskLoop()
        {
            Console.WriteLine("Enter fruit's name");
            string firstSrting = Console.ReadLine();
            
            list.Add(firstSrting);

            for (int i = 0; i < list.Count; i++) 
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine("Enter another fruit's name");
            string secondSrting = Console.ReadLine();

            list.Insert((list.Count / 2) + 1, secondSrting);

            Console.WriteLine("New list:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
