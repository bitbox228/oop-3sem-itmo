namespace Lab5.Application.Contracts.Admins;

public interface IAdminService
{
    Task<ServiceResult> Login(string login, string password);

    ServiceResult Logout();
}