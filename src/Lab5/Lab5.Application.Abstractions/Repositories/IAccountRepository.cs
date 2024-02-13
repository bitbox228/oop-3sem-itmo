using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Task<Account?> FindAccountByLogin(string login);

    Task<RepositoryResult> SaveAccount(Account account);

    Task<RepositoryResult> UpdateBalance(string login, long newBalance);
}