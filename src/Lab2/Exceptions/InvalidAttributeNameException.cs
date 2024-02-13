using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class InvalidAttributeNameException : Exception
{
    public InvalidAttributeNameException(string attributeType, string attributeName)
        : this($"{attributeType} : {attributeName}")
    {
    }

    public InvalidAttributeNameException(string message)
        : base($"Invalid name of component attribute {message}")
    {
    }

    public InvalidAttributeNameException()
    {
    }

    public InvalidAttributeNameException(string message, Exception innerException)
        : base($"Invalid name of component attribute {message}", innerException)
    {
    }
}