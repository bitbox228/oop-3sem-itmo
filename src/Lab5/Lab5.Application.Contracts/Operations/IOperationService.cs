using Lab5.Application.Models.Operations;

namespace Lab5.Application.Contracts.Operations;

public interface IOperationService
{
    IAsyncEnumerable<Operation> ShowHistory();

    Task<ServiceResult> AddOperation(Operation operation);
}