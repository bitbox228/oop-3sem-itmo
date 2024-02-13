using Lab5.Application.Models.Operations;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    IAsyncEnumerable<Operation> GetOperationsByAccountLogin(string accountLogin);

    Task<RepositoryResult> SaveOperation(Operation operation);
}