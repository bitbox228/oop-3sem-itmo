using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public abstract class EnvironmentBase
{
    protected EnvironmentBase(
        double distance,
        IReadOnlyCollection<ObstacleBase>? obstacles)
    {
        Distance = distance;
        Obstacles = obstacles;
    }

    public double Distance { get; private set; }

    public IReadOnlyCollection<ObstacleBase>? Obstacles { get; }

    public abstract RouteResult Pass(ShipBase ship, RouteResult routeResult);
}