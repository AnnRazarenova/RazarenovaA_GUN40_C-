using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkClasses
{
    public struct Interval
    {
        public int Min { get; }
        public int Max { get; }

        static Random random = new Random();

        public int Get { get; set; }

        public Interval(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                int swap;
                swap = minValue;
                minValue = maxValue;
                maxValue = swap;

                Console.WriteLine("Incorrect input data");
            }
            else
            {
                if (minValue < 0)
                {
                    minValue = 0;
                    Console.WriteLine("Incorrect input data");

                }

                if (maxValue < 0)
                {
                    maxValue = 0;
                    Console.WriteLine("Incorrect input data");
                }

                if (minValue == maxValue)
                {
                    maxValue = minValue + 10;
                    Console.WriteLine("Incorrect input data");
                }


            }

            Min = minValue;
            Max = maxValue;

            Get = random.Next(minValue, maxValue);
        }

    }

}
