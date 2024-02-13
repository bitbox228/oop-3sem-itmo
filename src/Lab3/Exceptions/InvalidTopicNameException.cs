using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class InvalidTopicNameException : Exception
{
    public InvalidTopicNameException(string message)
        : base($"No topic with name {message}")
    {
    }

    public InvalidTopicNameException()
    {
    }

    public InvalidTopicNameException(string message, Exception innerException)
        : base($"No topic with name {message}", innerException)
    {
    }
}