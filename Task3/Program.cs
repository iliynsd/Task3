using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            Console.WriteLine("Sum = " + calc.Calculate(5,9,"+"));
            Console.WriteLine("Difference = " + calc.Calculate(5,9,"-"));
            Console.WriteLine("Multiply = " + calc.Calculate(5,9,"*"));
            Console.WriteLine("Divide = " + calc.Calculate(5,9,"/"));
        }
    }
}