using System.Security.Cryptography;
using System.Text;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.CurrentUsers;
using Lab5.Application.Models.Admins;

namespace Lab5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly CurrentUserService _currentUserService;

    public AdminService(IAdminRepository adminRepository, CurrentUserService currentUserService)
    {
        _adminRepository = adminRepository;
        _currentUserService = currentUserService;
    }

    public async Task<ServiceResult> Login(string login, string password)
    {
        if (_currentUserService.User is not null)
        {
            return new ServiceResult.Failed("Logout to login.");
        }

        Admin? admin = await _adminRepository.FindAdminByLogin(login);

        if (admin is null)
        {
            return new ServiceResult.Failed("Account doesn't exists.");
        }

        byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
        byte[] hashedBytes = SHA256.HashData(passwordBytes);
        string hashedPassword = Convert.ToBase64String(hashedBytes);

        if (!hashedPassword.Equals(admin.Password, StringComparison.Ordinal))
        {
            return new ServiceResult.Failed("Incorrect password.");
        }

        _currentUserService.User = admin;

        return new ServiceResult.Success();
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