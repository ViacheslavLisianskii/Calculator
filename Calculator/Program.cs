using System;
using Calculator.Parser;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            _calculator = new Calculator(CultureName);
            _parser = new EquationParser();

            try
            {
                var parsedInput = _parser.ParseArgs(args);
                var result = _calculator.PerformOperation(parsedInput);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static ICalculator _calculator;
        private static IEquationParser _parser;
        private const string CultureName = "fr-FR";
    }
}