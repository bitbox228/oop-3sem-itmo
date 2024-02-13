using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class PsuRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        repository.PsuRepository
            .AddComponent(new Psu(new string("MSI MAG A550BN"), 550));
    }
}