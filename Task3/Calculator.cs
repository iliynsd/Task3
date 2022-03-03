using System;
using System.Diagnostics.CodeAnalysis;

namespace Task3
{
    public class Calculator
    {
        public  double Calculate(double x, double y, Func<double, double, double> func) => func(x, y);

        public  double Sum(double x, double y) => x + y;
        
        public  double Deducation(double x, double y) => x - y;

        public  double Multiply(double x, double y) => x * y;
        
        public  double Divide(double x, double y) => x / y;
    }
}