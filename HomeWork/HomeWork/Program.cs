namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Здесь массивы заданий 1-4
            
            // #1 Массив чисел Фибоначчи

            //В задании не указали, вручную нужно заполнить массив или нет, поэтому сделала 2 варианта

            //int[] fibonacciArray = { 0, 1, 1, 2, 3, 5, 8, 13 };

            int[] fibonacciArray = new int [8];

            Console.WriteLine("Задание 1");
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


            // #2 Массив, содержащий названия месяцев
            string[] monthsArray = { "January", "February", "March", "April", "May", "June",
                                 "July", "August", "September", "October", "November", "December",};

            Console.WriteLine("Задание 2");
            for (int i = 0; i < monthsArray.Length; i++)
            {
                Console.WriteLine(i + ": " + monthsArray[i]);
            }
            Console.WriteLine("");

            // #3 Двумерный массив [3x3]
            //В задании не указали, вручную нужно заполнить массив или нет, поэтому сделала 2 варианта

            //int[,] twoDimensionalArray = { { 2, 3, 4 }, { 4, 9, 16 }, { 8, 27, 64 } };

            int n = 3;
            int[,] twoDimensionalArray = new int[n, n];

            Console.WriteLine("Задание 3");

            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        twoDimensionalArray[i, j] = (int)Math.Pow(2, i + 1);
                    }
                    else if (j == 1)
                    {
                        twoDimensionalArray[i, j] = (int)Math.Pow(3, i + 1);
                    }
                    else
                    {
                        twoDimensionalArray[i, j] = (int)Math.Pow(4, i + 1);
                    }
                    Console.WriteLine(i + ", " + j + ": " + twoDimensionalArray[i, j]);
                }
            }
            Console.WriteLine("");

            Console.WriteLine("Задание 4");

            double[][] jaggeArray = new double[3][] { 
                                                new double[5]{ 1, 2, 3, 4, 5 },
                                                new double[2]{ Math.E, Math.PI },
                                                new double[4]{ Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000) } };

            Console.WriteLine("");

            // массивы для заданий 5 и 6.
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
            

            Console.WriteLine("Задание 5");
            var result = CopyArrays(array, array2, 3);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(i + ": " + result[i]);
            }


            Console.WriteLine("");

            Console.WriteLine("Задание 6");
            ResizeArray(ref array, array.Length * 2);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(i + ": " + array[i]);
            }
        }

        static int[] CopyArrays(int[] array, int[] array2, int count)
        {
            //Array.Copy(array, 0, array2, 0, count);
            Array.Copy(array, array2, count);
            return array2;
        }

        static void ResizeArray(ref  int[] array, int length)
        {
            Array.Resize(ref array, length);
        }


    }



}