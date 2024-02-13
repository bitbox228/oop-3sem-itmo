using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class InvalidObstacleOnEnvironmentException : Exception
{
    public InvalidObstacleOnEnvironmentException(string message)
        : base(message)
    {
    }

    public InvalidObstacleOnEnvironmentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidObstacleOnEnvironmentException()
    {
    }
}