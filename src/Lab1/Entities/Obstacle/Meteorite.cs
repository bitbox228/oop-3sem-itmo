using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Meteorite : ObstacleBase
{
    private const int MeteoriteDamage = 1;

    public Meteorite()
    {
        Damage = MeteoriteDamage;
    }

    public override void Collision(ShipBase ship)
    {
        if (ship is null) return;
        ship.Collision(this);
    }
}