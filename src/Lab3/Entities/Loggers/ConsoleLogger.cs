using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public class ConsoleLogger : ILogger
{
    public void Output(string text)
    {
        Console.WriteLine(text);
    }
}