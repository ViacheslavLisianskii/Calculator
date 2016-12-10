using Calculator.Objects;

namespace Calculator.Parser
{
    public interface IEquationParser
    {
        Equation ParseLine(string input);

        Equation ParseArgs(string[] args);
    }
}
