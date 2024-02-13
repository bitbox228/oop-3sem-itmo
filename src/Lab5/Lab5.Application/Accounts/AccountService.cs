using System.Security.Cryptography;
using System.Text;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.CurrentUsers;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IOperationService _operationService;
    private readonly CurrentUserService _currentUserService;

    public AccountService(
        IAccountRepository accountRepository,
        IOperationService operationService,
        CurrentUserService currentUserService)
    {
        _accountRepository = accountRepository;
        _operationService = operationService;
        _currentUserService = currentUserService;
    }

    public async Task<ServiceResult> Login(string login, string password)
    {
        if (_currentUserService.User is not null)
        {
            return new ServiceResult.Failed("Logout to login.");
        }

        Account? account = await _accountRepository.FindAccountByLogin(login);

        if (account is null)
        {
            return new ServiceResult.Failed("Account doesn't exists.");
        }

        byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
        byte[] hashedBytes = SHA256.HashData(passwordBytes);
        string hashedPassword = Convert.ToBase64String(hashedBytes);

        if (!hashedPassword.Equals(account.Password, StringComparison.Ordinal))
        {
            return new ServiceResult.Failed("Incorrect password.");
        }

        _currentUserService.User = account;

        return new ServiceResult.Success();
    }

    public async Task<ServiceResult> Register(string login, string password)
    {
        if (_currentUserService.User is not null)
        {
            return new ServiceResult.Failed("Logout to register.");
        }

        if (await _accountRepository.FindAccountByLogin(login) is not null)
        {
            return new ServiceResult.Failed("Account already exists.");
        }

        byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
        byte[] hashedBytes = SHA256.HashData(passwordBytes);
        string hashedPassword = Convert.ToBase64String(hashedBytes);

        RepositoryResult result = await _accountRepository.SaveAccount(new Account(login, hashedPassword, 0));

        return result switch
        {
            RepositoryResult.Success => new ServiceResult.Success(),
            RepositoryResult.Failed failedResult => new ServiceResult.Failed(failedResult.Message),
            _ => new ServiceResult.Failed("Undefined behaviour."),
        };
    }

    public async Task<ServiceResult> WithdrawMoney(long money)
    {
        if (money <= 0)
        {
            return new ServiceResult.Failed("Money can't be negative or zero");
        }

        if (_currentUserService.User is not Account account)
        {
            return new ServiceResult.Failed("Logout to register.");
        }

        if (account.Balance < money)
        {
            return new ServiceResult.Failed("Not enough money.");
        }

        _currentUserService.User = new Account(account.Login, account.Password, account.Balance - money);

        RepositoryResult repositoryResult =
            await _accountRepository.UpdateBalance(account.Login, account.Balance - money);

        if (repositoryResult is RepositoryResult.Failed failedRepositoryResult)
        {
            return new ServiceResult.Failed(failedRepositoryResult.Message);
        }

        return await _operationService.AddOperation(new Operation(account.Login, -money));
    }

    public async Task<ServiceResult> DepositMoney(long money)
    {
        if (money <= 0)
        {
            return new ServiceResult.Failed("Money can't be negative or zero");
        }

        if (_currentUserService.User is not Account account)
        {
            return new ServiceResult.Failed("Logout to register.");
        }

        _currentUserService.User = new Account(account.Login, account.Password, account.Balance + money);

        RepositoryResult repositoryResult =
            await _accountRepository.UpdateBalance(account.Login, account.Balance + money);

        if (repositoryResult is RepositoryResult.Failed failedRepositoryResult)
        {
            return new ServiceResult.Failed(failedRepositoryResult.Message);
        }

        return await _operationService.AddOperation(new Operation(account.Login, money));
    }

    public ServiceResult Logout()
    {
        if (_currentUserService.User is null)
        {
            return new ServiceResult.Failed("Not logged in.");
        }

        _currentUserService.User = null;

        return new ServiceResult.Success();
    }
}