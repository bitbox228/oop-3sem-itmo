using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class AlreadyReadMessageException : Exception
{
    public AlreadyReadMessageException(int messageId)
        : this(Convert.ToString(messageId, CultureInfo.InvariantCulture))
    {
    }

    public AlreadyReadMessageException(string message)
        : base($"Can't read message with ID = {message}, because it's already read.")
    {
    }

    public AlreadyReadMessageException()
    {
    }

    public AlreadyReadMessageException(string message, Exception innerException)
        : base($"Can't read message with ID = {message}, because it's already read.", innerException)
    {
    }
}