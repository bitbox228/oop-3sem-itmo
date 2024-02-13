using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class ComputerRepositoryInitializer : IRepositoryInitializer
{
    private List<IRepositoryInitializer> _repositoryInitializer;

    public ComputerRepositoryInitializer()
    {
        _repositoryInitializer = new List<IRepositoryInitializer>();
    }

    public void Add(IRepositoryInitializer repositoryInitializer)
    {
        _repositoryInitializer.Add(repositoryInitializer);
    }

    public void Initialize(ComputerComponentsRepository repository)
    {
        foreach (IRepositoryInitializer repositoryInitializer in _repositoryInitializer)
        {
            repositoryInitializer.Initialize(repository);
        }
    }
}