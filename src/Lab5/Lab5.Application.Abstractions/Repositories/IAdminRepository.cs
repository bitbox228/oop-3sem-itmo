using Lab5.Application.Models.Admins;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Task<Admin?> FindAdminByLogin(string login);

    Task<RepositoryResult> SaveAdmin(Admin admin);
}