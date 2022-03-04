using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class Calculator
    {
        public double Calculate(double x, double y, string operation)
        {
            if (!operations.Select(i => i.Item1).Contains(operation))
            {
                throw new InvalidOperationException($"Invalid operation {operation}");
            }

            return operations[operations.FindIndex(i => i.Item1 == operation)].Item2.Invoke(x,y);
        }

        
        private List<Tuple<string, Func<double, double, double>>> operations =
            new List<Tuple<string, Func<double, double, double>>>
            {
                new Tuple<string, Func<double, double, double>>("+", (x,y) => x+y),
                new Tuple<string, Func<double, double, double>>("-", (x,y) => x-y),
                new Tuple<string, Func<double, double, double>>("*", (x,y) => x*y),
                new Tuple<string, Func<double, double, double>>("/", (x,y) => x/y),
            };

        public void AddOperation(string operation, Func<double, double, double> func)
        {
            if (!operations.Select(i => i.Item1).Contains(operation))
            {
                throw new Exception($"Operation {operation} is already added");
            }
            operations.Add(new Tuple<string, Func<double, double, double>>(operation, func));
        }
    }
}