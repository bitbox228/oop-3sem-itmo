namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class JumpingEngineBase
{
    protected const double FuelConsumption = 100;
    private const double Speed = 78;

    protected JumpingEngineBase(double range)
    {
        Range = range;
    }

    public double Range { get; }

    public double CalculateTime(double distance)
    {
        return distance / Speed;
    }

    public abstract double CalculateFuel(double distance);
}