using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number:");
        if (!Int32.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Not a number!");
            return;            
        }

        Console.WriteLine("Enter second number:");
        if (!Int32.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("Not a number!");
            return;
        }

        Console.WriteLine("Enter &, | or ^ :");
        var simbol = Console.ReadLine();

        if (simbol.Length == 0 || simbol.Length > 1)
        {
            Console.WriteLine("Wrong sigh");
            return;
        }

        switch(simbol[0])
        {
            case '&':
                Console.WriteLine("Binary: " + Convert.ToString(a & b, 2) + ",  Decimal: " + Convert.ToString(a & b, 10) + ",  Hexadecimal: " + Convert.ToString(a & b, 16));
                break;
            case '|':
                Console.WriteLine("Binary: " + Convert.ToString(a | b, 2) + ",  Decimal: " + Convert.ToString(a | b, 10) + ",  Hexadecimal: " + Convert.ToString(a | b, 16));
                break;
            case '^':
                Console.WriteLine("Binary: " + Convert.ToString(a ^ b, 2) + ",  Decimal: " + Convert.ToString(a ^ b, 10) + ",  Hexadecimal: " + Convert.ToString(a ^ b, 16));
                break;

        }



    }    
}