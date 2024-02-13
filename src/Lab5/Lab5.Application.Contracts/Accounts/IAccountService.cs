namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    Task<ServiceResult> Login(string login, string password);

    Task<ServiceResult> Register(string login, string password);

    Task<ServiceResult> WithdrawMoney(long money);

    Task<ServiceResult> DepositMoney(long money);

    ServiceResult Logout();
}