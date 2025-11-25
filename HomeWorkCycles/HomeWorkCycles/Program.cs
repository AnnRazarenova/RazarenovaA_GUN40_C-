namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1 Fibonacci

            Console.WriteLine("Задание 1");
            int[] fibonacciArray = new int[10];
            for (int i = 0; i < fibonacciArray.Length; i++)
            {
                if (i == 0)
                {
                    fibonacciArray[i] = 0;
                    Console.WriteLine(i + ": " + fibonacciArray[i]);
                }
                else if (i == 1)
                {
                    fibonacciArray[i] = 1;
                    Console.WriteLine(i + ": " + fibonacciArray[i]);
                }
                else
                {
                    fibonacciArray[i] = fibonacciArray[i - 1] + fibonacciArray[i - 2];
                    Console.WriteLine(i + ": " + fibonacciArray[i]);
                }
            }
            Console.WriteLine("");


            // #2 Все чётные числа от 2 до 20
            Console.WriteLine("Задание 2");
            for (int i = 2; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }

            }
            Console.WriteLine("");

            // #3 Таблица умножения от 1 до 5

            Console.WriteLine("Задание 3");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine((i + 1) + " x " + (j + 1) + " = " + (i + 1) * (j + 1));
                }
            }
            Console.WriteLine("");


            Console.WriteLine("Задание 4");

            //Пароль

            string password = "qwerty";
            string passwordInput;

            do
            {
                Console.WriteLine("Enter the password");
                passwordInput = Console.ReadLine();
            } while (password != passwordInput);
            Console.WriteLine("Password is correct");
        }

    }



}