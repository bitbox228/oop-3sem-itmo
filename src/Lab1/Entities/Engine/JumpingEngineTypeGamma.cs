using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class JumpingEngineTypeGamma : JumpingEngineBase
{
    private const int JumpingEngineTypeGammaRange = 200;

    public JumpingEngineTypeGamma()
        : base(JumpingEngineTypeGammaRange)
    {
    }

    public override double CalculateFuel(double distance)
    {
        double fuel = CalculateTime(distance) * FuelConsumption;
        return fuel * Math.Log(fuel);
    }
}