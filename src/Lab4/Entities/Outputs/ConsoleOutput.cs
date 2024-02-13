using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Outputs;

public class ConsoleOutput : IOutput
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}