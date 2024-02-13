using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.CurrentUsers;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Operations;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _operationRepository;
    private readonly CurrentUserService _currentUserService;

    public OperationService(IOperationRepository operationRepository, CurrentUserService currentUserService)
    {
        _operationRepository = operationRepository;
        _currentUserService = currentUserService;
    }

    public async IAsyncEnumerable<Operation> ShowHistory()
    {
        if (_currentUserService.User is not Account account)
        {
            yield break;
        }

        await foreach (Operation operation in _operationRepository.GetOperationsByAccountLogin(account.Login))
        {
            yield return operation;
        }
    }

    public async Task<ServiceResult> AddOperation(Operation operation)
    {
        RepositoryResult repositoryResult = await _operationRepository.SaveOperation(operation);

        return repositoryResult switch
        {
            RepositoryResult.Success => new ServiceResult.Success(),
            RepositoryResult.Failed failedResult => new ServiceResult.Failed(failedResult.Message),
            _ => new ServiceResult.Failed("Undefined behaviour"),
        };
    }
}