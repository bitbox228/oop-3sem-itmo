namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class JumpingEngineTypeAlpha : JumpingEngineBase
{
    private const double JumpingEngineTypeAlphaRange = 100;

    public JumpingEngineTypeAlpha()
        : base(JumpingEngineTypeAlphaRange)
    {
    }

    public override double CalculateFuel(double distance)
    {
        double fuel = CalculateTime(distance) * FuelConsumption;
        return fuel;
    }
}