using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShipFinder;

public class OptimalShipFinder
{
    public ShipBase? Find(IReadOnlyCollection<ShipBase> ships, Route route)
    {
        ships = ships ?? throw new ArgumentNullException(nameof(ships));
        route = route ?? throw new ArgumentNullException(nameof(route));

        if (ships.Count == 0)
        {
            throw new EmptyRouteException();
        }

        RouteResult? bestRouteResult = null;
        ShipBase? bestShip = null;

        foreach (ShipBase ship in ships)
        {
            var routeCopy = new Route(route.Environments);
            RouteResult routeResult = routeCopy.Pass(ship);
            if (bestRouteResult is null && routeResult is RouteResult.Success)
            {
                bestRouteResult = routeResult;
                bestShip = ship;
            }
            else if (bestRouteResult is RouteResult.Success && routeResult is RouteResult.Success)
            {
                var bestRouteResultSuccess = (RouteResult.Success)bestRouteResult;
                var routeResultSuccess = (RouteResult.Success)routeResult;
                if (
                    bestRouteResultSuccess.Fuel > routeResultSuccess.Fuel ||
                    (bestRouteResultSuccess.Fuel == routeResultSuccess.Fuel &&
                     bestRouteResultSuccess.Time > routeResultSuccess.Time))
                {
                    bestRouteResult = routeResult;
                }
            }
        }

        return bestShip;
    }
}