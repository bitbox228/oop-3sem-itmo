using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class RamTimings : IEquatable<RamTimings>
{
    public RamTimings(
        int casLatency,
        int rasToCasDelay,
        int rasPrecharge,
        int activeToPrechargeDelay)
    {
        if (casLatency < 0) throw new NegativeValueException(nameof(casLatency));
        if (rasToCasDelay < 0) throw new NegativeValueException(nameof(rasToCasDelay));
        if (rasPrecharge < 0) throw new NegativeValueException(nameof(rasPrecharge));
        if (activeToPrechargeDelay < 0) throw new NegativeValueException(nameof(activeToPrechargeDelay));

        CasLatency = casLatency;
        RasToCasDelay = rasToCasDelay;
        RasPrecharge = rasPrecharge;
        ActiveToPrechargeDelay = activeToPrechargeDelay;
    }

    public int CasLatency { get; }
    public int RasToCasDelay { get; }
    public int RasPrecharge { get; }
    public int ActiveToPrechargeDelay { get; }

    public bool Equals(RamTimings? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return CasLatency == other.CasLatency &&
               RasToCasDelay == other.RasToCasDelay &&
               RasPrecharge == other.RasPrecharge &&
               ActiveToPrechargeDelay == other.ActiveToPrechargeDelay;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((RamTimings)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            CasLatency,
            RasToCasDelay,
            RasToCasDelay,
            ActiveToPrechargeDelay);
    }
}