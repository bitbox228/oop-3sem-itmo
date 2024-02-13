namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class ImpulseEngineTypeE : ImpulseEngineBase
{
    private const double ImpulseEngineTypeESpeed = 200;
    private const double ImpulseEngineTypeEFuelConsumption = 250;
    private const double ImpulseEngineTypeEStartFuelConsumption = 50;

    public ImpulseEngineTypeE()
        : base(
            ImpulseEngineTypeESpeed,
            ImpulseEngineTypeEFuelConsumption,
            ImpulseEngineTypeEStartFuelConsumption)
    {
    }
}