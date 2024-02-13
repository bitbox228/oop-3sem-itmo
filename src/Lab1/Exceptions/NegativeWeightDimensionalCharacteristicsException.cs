using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class NegativeWeightDimensionalCharacteristicsException : Exception
{
    public NegativeWeightDimensionalCharacteristicsException(string message)
        : base(message)
    {
    }

    public NegativeWeightDimensionalCharacteristicsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeWeightDimensionalCharacteristicsException()
    {
    }
}