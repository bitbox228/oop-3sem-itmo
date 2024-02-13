using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.PcBuilder;

public interface IPcDirectorBuilder
{
    IPcBuilder Direct(
        IPcBuilder pcBuilder,
        Specification specification,
        ComputerComponentsRepository repository);
}