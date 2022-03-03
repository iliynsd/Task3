using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            Console.WriteLine("Sum" + calc.Calculate(5, 6, calc.Sum));
            Console.WriteLine("Deduction" + calc.Calculate(5, 6, calc.Deducation));
            Console.WriteLine("Multiply" + calc.Calculate(5, 6, calc.Multiply));
            Console.WriteLine("Divide" + calc.Calculate(5, 6, calc.Divide));
        }
    }
}