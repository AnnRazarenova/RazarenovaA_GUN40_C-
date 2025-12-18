using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class TaskTwo
    {
        Dictionary<string, double> dictionary = new Dictionary<string, double>();
        public void TaskLoop()
        {
            CreateDictionary();

            foreach (var (key, val) in dictionary)
            {
                Console.WriteLine($"Имя студента: {key}  средняя оценка: {val}");
            }

            Console.WriteLine();

            Console.WriteLine("Enter student's name to add them:");
            string studenAddtName = Console.ReadLine();

            Console.WriteLine("Enter student's grade ( use , ):");
            double studentGrade = double.Parse(Console.ReadLine());

            if (studentGrade >= 2 && studentGrade <= 5) 
            {
                dictionary.Add(studenAddtName, studentGrade);
            }
            else
            {
                Console.WriteLine("Student's grade is incorrect:");
            }

            foreach (var (key, val) in dictionary)
            {
                Console.WriteLine($"Имя студента: {key}  средняя оценка: {val}");
            }


            Console.WriteLine();

            Console.WriteLine("Enter student's name to find them:");

            
            string studenFindtName = Console.ReadLine(); ;

            bool findStudent = dictionary.ContainsKey(studenFindtName);

            while (!findStudent)
            {
                Console.WriteLine("Student not found");
                Console.WriteLine("Enter student's name to find them:");    
            }
            
            Console.WriteLine(dictionary[studenFindtName]);
        }

        public void CreateDictionary()
        {
            dictionary.Add("Ivan Ivanov Ivanovich", 3.8);
            dictionary.Add("Olga Romanovich Kirilovna", 2.8);
            dictionary.Add("Sergey Kalugin Sergeevich", 4.8);
            dictionary.Add("Artem Smagin Vasilevich", 4.5);
            dictionary.Add("Vladislave Tislenko Alexsandrovich", 4.0);
        }
    }
}
