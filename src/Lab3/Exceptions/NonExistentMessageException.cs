using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class NonExistentMessageException : Exception
{
    public NonExistentMessageException(int messageId)
        : this(Convert.ToString(messageId, CultureInfo.InvariantCulture))
    {
    }

    public NonExistentMessageException(string message)
        : base($"Can't find message with ID = {message}.")
    {
    }

    public NonExistentMessageException() { }

    public NonExistentMessageException(string message, Exception innerException)
        : base($"Can't find message with ID = {message}.", innerException)
    {
    }
}