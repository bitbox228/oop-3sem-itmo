using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class JumpingEngineTypeOmega : JumpingEngineBase
{
    private const int JumpingEngineTypeOmegaRange = 300;

    public JumpingEngineTypeOmega()
        : base(JumpingEngineTypeOmegaRange)
    {
    }

    public override double CalculateFuel(double distance)
    {
        double fuel = CalculateTime(distance) * FuelConsumption;
        return Math.Pow(fuel, 2);
    }
}