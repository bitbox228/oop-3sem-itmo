using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : ShipBase
{
    public Stella(bool photonDeflectors = false)
        : base(
            new ImpulseEngineTypeC(),
            new JumpingEngineTypeOmega(),
            new DeflectorFirstType(photonDeflectors),
            new ShellFirstType(),
            false,
            SmallWeightDimensionalCharacteristics)
    {
    }
}