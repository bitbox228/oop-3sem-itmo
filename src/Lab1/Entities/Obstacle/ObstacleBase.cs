using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public abstract class ObstacleBase
{
    public int Damage { get; protected set; }

    public abstract void Collision(ShipBase ship);

    public void TakeDamage(int damage)
    {
        Damage -= damage;
    }
}