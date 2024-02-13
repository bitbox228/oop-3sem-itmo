namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class ImpulseEngineBase
{
    protected ImpulseEngineBase(
        double speed,
        double fuelConsumption,
        double startFuelConsumption)
    {
        Speed = speed;
        FuelConsumption = fuelConsumption;
        StartFuelConsumption = startFuelConsumption;
    }

    private double Speed { get; }

    private double FuelConsumption { get; }

    private double StartFuelConsumption { get; }

    public double CalculateTime(double distance)
    {
        return distance / Speed;
    }

    public double CalculateFuel(double distance)
    {
        return (CalculateTime(distance) * FuelConsumption) + StartFuelConsumption;
    }
}