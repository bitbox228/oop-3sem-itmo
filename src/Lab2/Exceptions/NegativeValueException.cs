using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NegativeValueException : Exception
{
    public NegativeValueException(string message)
        : base($"Variable {message} can't be  negative")
    {
    }

    public NegativeValueException()
    {
    }

    public NegativeValueException(string message, Exception innerException)
        : base($"Variable {message} can't be  negative", innerException)
    {
    }
}