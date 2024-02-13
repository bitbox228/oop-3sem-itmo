using Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;

public interface IFileSystemCommand
{
    CommandResult Execute(ApplicationState applicationState);
}