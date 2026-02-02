namespace Test
{
    public struct TestStruct
    {
        public int XStruct;

        public TestStruct(int x)
        {
            XStruct = x; 
        }

    }

    internal class Test
    {

        public int X;

        public Test(int x)
        {
            X = x;
        }

        static void Main(string[] args)
        {
            int number = 1000;

            Test test1 = new Test(number);
            
            Test test2 = new Test(10);

            Console.WriteLine(test1.X);
            Console.WriteLine(test2.X);
            Console.WriteLine();

            var test3 = test1;

            Console.WriteLine(test1.X);
            Console.WriteLine(test2.X);
            Console.WriteLine(test3.X);
            Console.WriteLine();

            test3.X = 25;

            Console.WriteLine("After: ");
            
            Console.WriteLine(test1.X);
            Console.WriteLine(test2.X);
            Console.WriteLine(test3.X);
            Console.WriteLine();

            TestStruct testStruct1 = new TestStruct(number);
            TestStruct testStruct2 = new TestStruct(10);

            Console.WriteLine(testStruct1.XStruct);
            Console.WriteLine(testStruct2.XStruct);
            Console.WriteLine();

            var testStruct3 = testStruct1;

            Console.WriteLine(testStruct1.XStruct);
            Console.WriteLine(testStruct2.XStruct);
            Console.WriteLine(testStruct3.XStruct);
            Console.WriteLine();

            testStruct3.XStruct = 25;

            Console.WriteLine("After: ");

            Console.WriteLine(testStruct1.XStruct);
            Console.WriteLine(testStruct2.XStruct);
            Console.WriteLine(testStruct3.XStruct);


        }
    }
}
