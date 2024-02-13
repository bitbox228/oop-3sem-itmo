using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class Route
{
    public Route(IReadOnlyCollection<EnvironmentBase> environments)
    {
        Environments = environments;
    }

    public IReadOnlyCollection<EnvironmentBase> Environments { get; }

    public RouteResult Pass(ShipBase ship)
    {
        ship = ship ?? throw new ArgumentNullException(nameof(ship));

        RouteResult routeResult = new RouteResult.Success();

        foreach (EnvironmentBase environment in Environments)
        {
            routeResult = environment.Pass(ship, routeResult);
            if (routeResult is not RouteResult.Success)
            {
                return routeResult;
            }
        }

        return routeResult;
    }
}