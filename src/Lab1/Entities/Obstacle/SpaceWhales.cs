using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class SpaceWhales : ObstacleBase
{
    private const int SpaceWhaleDamage = 40;
    private const int DefaultSpaceWhalesCount = 1;
    public SpaceWhales(int population = DefaultSpaceWhalesCount)
    {
        Damage = SpaceWhaleDamage * population;
    }

    public override void Collision(ShipBase ship)
    {
        if (ship is null) return;
        ship.Collision(this);
    }
}