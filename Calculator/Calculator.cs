using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Calculator.Objects;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public Calculator(string cultureName)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
        }

        public double PerformOperation(Equation parsedInput)
        {
            var op = parsedInput.Operator.Trim();
            if (!_operations.ContainsKey(op))
                throw new ArgumentException($"Operation {op} is invalid", op);

            return _operations[op](parsedInput.FirstArgument, parsedInput.SecondArgument);
        }

        private static double DoAddition(double x, double y)
        {
            return x + y;
        }

        private static double DoSubtraction(double x, double y)
        {
            return x - y;
        }

        private static double DoDivision(double x, double y)
        {
            return x/y;
        }

        private static double DoMultiplication(double x, double y)
        {
            return x*y;
        }

        private static double DoPercentage(double x, double y)
        {
            return x%y;
        }

        private readonly Dictionary<string, Func<double, double, double>> _operations =
            new Dictionary<string, Func<double, double, double>>
            {
                {"+", DoAddition},
                {"-", DoSubtraction},
                {"*", DoMultiplication},
                {"/", DoDivision},
                {"%", DoPercentage}
            };
    }
}