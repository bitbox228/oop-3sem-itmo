using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class InvalidComponentNameException : Exception
{
    public InvalidComponentNameException(string componentType, string componentName)
        : this($"{componentType} : {componentName}")
    {
    }

    public InvalidComponentNameException(string message)
        : base($"Invalid name of component {message}")
    {
    }

    public InvalidComponentNameException()
    {
    }

    public InvalidComponentNameException(string message, Exception innerException)
        : base($"Invalid name of component {message}", innerException)
    {
    }
}