using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class EmptyRouteException : Exception
{
    public EmptyRouteException(string message)
        : base(message)
    {
    }

    public EmptyRouteException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EmptyRouteException()
    {
    }
}