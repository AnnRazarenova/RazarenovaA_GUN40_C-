using System.Text;

namespace StringsAndSymbols
{
    internal class Program
    {

        // Task #1
        static public string ConcatenateStrings(string str1, string str2)
        {
            return string.Concat(str1, str2);
        }

        // Task #2
        static public string GreetUser(string name, int age) 
        {
            return $"Hello, {name}! \nYou are {age} years old";
        }

        // Task #3
        static public string AnalyzeString(string str)
        {
            return $"Количество символов в строке: {str.Length.ToString()}\n\nCтрока в верхнем регистре:\n{str.ToUpper()}\n\nСтроку в нижнем регистре:\n{str.ToLower()}";
        }
        
        // Task #4
        static public string FirstSimbols(string str)
        {
            return str.Substring(0, 5);
        }

        // Task #5
        static public StringBuilder CombinesLines(string[] strings)
        {
            var builder = new StringBuilder();

            foreach (var s in strings)
            {
                builder.Append(s);
                builder.Append(' ');
            }

            return builder;
        }

        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord) 
        {
            return inputString.Replace(wordToReplace, replacementWord);
        }

        static void Main(string[] args)
        {
            // Task #1
            Console.WriteLine("Task #1:");
            Console.WriteLine(ConcatenateStrings("Meow", "Meow"));
            Console.WriteLine();

            // Task #2
            Console.WriteLine("Task #2:");
            Console.WriteLine(GreetUser("Sergey", 21));
            Console.WriteLine();

            // Task #3
            Console.WriteLine("Task #3:");
            Console.WriteLine(AnalyzeString("Hello, world\nProgrammed to work and not to feel\nNot even sure that this is real\nHello, world"));
            Console.WriteLine();

            // Task #4
            Console.WriteLine("Task #4:");
            Console.WriteLine(FirstSimbols("Kitty! Hello Cat, kitty-kitty!"));
            Console.WriteLine();

            // Task #5
            Console.WriteLine("Task #5:");
            var strings = new string[] { "I", "brought", "you", "some", "food" };
            Console.WriteLine(CombinesLines(strings));
            Console.WriteLine();

            // Task #5
            Console.WriteLine("Task #6:");
            Console.WriteLine(ReplaceWords("It's a bird!", "bird", "plane"));


        }
    }
}
