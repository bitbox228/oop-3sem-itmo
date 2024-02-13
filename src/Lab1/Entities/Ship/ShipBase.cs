using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class ShipBase
{
    protected const int SmallWeightDimensionalCharacteristics = 100;
    protected const int MediumWeightDimensionalCharacteristics = 200;
    protected const int BigWeightDimensionalCharacteristics = 300;

    protected ShipBase(
        ImpulseEngineBase impulseEngine,
        JumpingEngineBase jumpingEngine,
        DeflectorBase deflector,
        ShellBase shell,
        bool antiNitrineEmitter,
        int weightDimensionalCharacteristics)
    {
        ImpulseEngine = impulseEngine ?? throw new ArgumentNullException(nameof(impulseEngine));
        JumpingEngine = jumpingEngine ?? throw new ArgumentNullException(nameof(jumpingEngine));
        Deflector = deflector ?? throw new ArgumentNullException(nameof(deflector));
        Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        AntiNitrineEmitter = antiNitrineEmitter;
        WeightDimensionalCharacteristics = weightDimensionalCharacteristics < 0
            ? throw new NegativeWeightDimensionalCharacteristicsException()
            : weightDimensionalCharacteristics;
        IsShipDead = false;
        IsCrewDead = false;
    }

    public bool AntiNitrineEmitter { get; private set; }

    public bool IsShipDead { get; protected set; }

    public bool IsCrewDead { get; protected set; }

    public int WeightDimensionalCharacteristics { get; private set; }

    public ImpulseEngineBase ImpulseEngine { get; }

    public JumpingEngineBase JumpingEngine { get; }

    public DeflectorBase Deflector { get; }

    public ShellBase Shell { get; }

    public bool IsAlive => !IsShipDead && !IsCrewDead;

    public void Collision(SpaceWhales obstacle)
    {
        if (AntiNitrineEmitter || obstacle is null)
        {
            return;
        }

        Deflector.TakeDamage(obstacle);
        Shell.TakeDamage(obstacle);

        if (obstacle.Damage > 0)
        {
            IsShipDead = true;
        }
    }

    public void Collision(AntimatterFlash obstacle)
    {
        if (obstacle is null) return;

        Deflector.TakeDamage(obstacle);
        Shell.TakeDamage(obstacle);

        if (obstacle.Damage > 0)
        {
            IsCrewDead = true;
        }
    }

    public void Collision(Meteorite obstacle)
    {
        if (obstacle is null) return;
        Deflector.TakeDamage(obstacle);
        Shell.TakeDamage(obstacle);

        if (obstacle.Damage > 0)
        {
            IsShipDead = true;
        }
    }

    public void Collision(Asteroid obstacle)
    {
        if (obstacle is null) return;
        Deflector.TakeDamage(obstacle);
        Shell.TakeDamage(obstacle);

        if (obstacle.Damage > 0)
        {
            IsShipDead = true;
        }
    }
}