using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Meridian : ShipBase
{
    public Meridian(bool photonDeflectors = false)
        : base(
            new ImpulseEngineTypeE(),
            new JumpingEngineTypeGamma(),
            new DeflectorFirstType(photonDeflectors),
            new ShellSecondType(),
            true,
            MediumWeightDimensionalCharacteristics)
    {
    }
}