using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;

public interface IFileSystemHandler
{
    HandleResult Handle(string consoleCommand);
}