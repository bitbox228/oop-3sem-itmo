using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public class ComponentRepository<T>
    where T : ComputerComponentBase
{
    private readonly HashSet<T> _componentList;

    public ComponentRepository()
    {
        _componentList = new HashSet<T>();
    }

    public void AddComponent(T component)
    {
        _componentList.Add(component);
    }

    public T? FindComponentByName(string name)
    {
        return _componentList.FirstOrDefault(component => component.Name.Equals(name, StringComparison.Ordinal));
    }
}