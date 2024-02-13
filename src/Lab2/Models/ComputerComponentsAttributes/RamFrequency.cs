using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class RamFrequency
{
    public RamFrequency(int bottomValue, int topValue)
    {
        if (bottomValue < 0) throw new NegativeValueException(nameof(bottomValue));
        if (topValue < 0) throw new NegativeValueException(nameof(topValue));

        BottomValue = bottomValue;
        TopValue = topValue;
    }

    public int BottomValue { get; }
    public int TopValue { get; }
}