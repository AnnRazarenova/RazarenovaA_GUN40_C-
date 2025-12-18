namespace Collections
{
    internal class Program
    {
        private static void CheckTaskFirst()
        {
            var taskOne = new TaskOne();
            taskOne.TaskLoop();
        }
        private static void CheckTaskSecond()
        {
            var taskTwo = new TaskTwo();
            taskTwo.TaskLoop();
        }
        private static void CheckTaskThird() 
        {
            var taskThree = new TaskThree();
            taskThree.TaskLoop();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
            int task = int.Parse(Console.ReadLine()); // Используйте tryParse
            switch (task)
            {
                case 1:
                    CheckTaskFirst();
                    break;
                case 2:
                    CheckTaskSecond();
                    break;
                case 3:
                    CheckTaskThird();
                    break;
            }
        }
    }
}
