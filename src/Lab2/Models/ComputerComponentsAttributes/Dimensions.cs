using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class Dimensions
{
    public Dimensions(int width, int length, int height)
    {
        if (width < 0) throw new NegativeValueException(nameof(width));
        if (length < 0) throw new NegativeValueException(nameof(length));
        if (height < 0) throw new NegativeValueException(nameof(height));

        Width = width;
        Length = length;
        Height = height;
    }

    public int Width { get; }
    public int Length { get; }
    public int Height { get; }
}