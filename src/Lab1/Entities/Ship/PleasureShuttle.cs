using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class PleasureShuttle : ShipBase
{
    public PleasureShuttle()
        : base(
            new ImpulseEngineTypeC(),
            new NullJumpingEngine(),
            new NullDeflector(),
            new ShellFirstType(),
            false,
            SmallWeightDimensionalCharacteristics)
    {
    }
}