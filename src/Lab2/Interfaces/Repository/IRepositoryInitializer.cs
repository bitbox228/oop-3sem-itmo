using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;

public interface IRepositoryInitializer
{
    void Initialize(ComputerComponentsRepository repository);
}