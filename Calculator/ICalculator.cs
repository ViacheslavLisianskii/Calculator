using Calculator.Objects;

namespace Calculator
{
    public interface ICalculator
    {
        double PerformOperation(Equation parsedInput);
    }
}
