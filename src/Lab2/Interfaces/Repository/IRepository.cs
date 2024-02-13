namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;

public interface IRepository<T>
{
    void Add(T component);

    T? FindComponent(string name);
}