namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Result;

public abstract record class RouteResult
{
    private RouteResult() { }

    public sealed record class Success(double Time = 0, double Fuel = 0) : RouteResult
    {
        public double Time { get; set; } = Time;
        public double Fuel { get; set; } = Fuel;
    }

    public sealed record ShipLost() : RouteResult;

    public sealed record ShipDead() : RouteResult;

    public sealed record CrewDead() : RouteResult;
}