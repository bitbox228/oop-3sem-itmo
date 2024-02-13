using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class InvalidPathException : Exception
{
    public InvalidPathException(string path)
        : base($"Can't find path {path}")
    {
    }

    public InvalidPathException()
    {
    }

    public InvalidPathException(string path, Exception innerException)
        : base($"Can't find path {path}", innerException)
    {
    }
}