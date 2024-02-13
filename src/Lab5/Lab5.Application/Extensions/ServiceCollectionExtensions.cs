using Lab5.Application.Accounts;
using Lab5.Application.Admins;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.Contracts.CurrentUsers;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.CurrentUsers;
using Lab5.Application.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<IOperationService, OperationService>();

        collection.AddScoped<CurrentUserService>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserService>());

        return collection;
    }
}