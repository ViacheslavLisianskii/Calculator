using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Calculator.Objects;

namespace Calculator.Parser
{
    public class EquationParser : IEquationParser
    {
        public Equation ParseLine(string input)
        {
            var tokens = Regex.Matches(input, Pattern)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();

            return Parse(tokens);
        }

        public Equation ParseArgs(string[] args)
        {
            return Parse(args);
        }

        private static Equation Parse(IReadOnlyList<string> args)
        {
            var firstArgument = args[0];
            var operatorString = args[1];
            var secondArgument = args[2];

            if (!string.IsNullOrWhiteSpace(firstArgument) && !string.IsNullOrWhiteSpace(operatorString) &&
                !string.IsNullOrWhiteSpace(secondArgument))
            {
                return new Equation
                {
                    FirstArgument = Convert.ToDouble(firstArgument),
                    Operator = operatorString,
                    SecondArgument = Convert.ToDouble(secondArgument)
                };
            }

            throw new ArgumentException($"Input string is invalid");
        }

        private const string Pattern = @"[0-9]*\.?[0-9]+([eE][-+*/]?[0-9]+)?|[-^+*/()]|\w+";
    }
}