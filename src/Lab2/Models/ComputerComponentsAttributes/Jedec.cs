using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class Jedec
{
    public Jedec(
        int frequency,
        RamTimings ramTimings)
    {
        ramTimings = ramTimings ?? throw new ArgumentNullException(nameof(ramTimings));

        if (frequency < 0) throw new NegativeValueException(nameof(frequency));

        Frequency = frequency;
        RamTimings = ramTimings;
    }

    public int Frequency { get; }
    public RamTimings RamTimings { get; }
}