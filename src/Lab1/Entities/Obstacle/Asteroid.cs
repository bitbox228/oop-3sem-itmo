using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : ObstacleBase
{
    private const int AsteroidDamage = 4;

    public Asteroid()
    {
        Damage = AsteroidDamage;
    }

    public override void Collision(ShipBase ship)
    {
        if (ship is null) return;
        ship.Collision(this);
    }
}