using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.CurrentUsers;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.ResultTypes;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MoneyTests
{
    [Fact]
    public async Task WithdrawMoneyNoErrorsTest()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository
            .UpdateBalance(Arg.Any<string>(), Arg.Any<long>())
            .Returns(new RepositoryResult.Success());
        IOperationService operationService = Substitute.For<IOperationService>();
        operationService
            .AddOperation(Arg.Any<Operation>())
            .Returns(new ServiceResult.Success());
        var currentUserService = new CurrentUserService();
        currentUserService.User = new Account("Nikita", "123", 1000);
        var accountService = new AccountService(accountRepository, operationService, currentUserService);

        // Act
        ServiceResult result = await accountService.WithdrawMoney(200);

        // Assert
        Assert.IsType<ServiceResult.Success>(result);
        await accountRepository.Received()
            .UpdateBalance(
                Arg.Do<string>(x => Assert.Equal("Nikita", x)),
                Arg.Do<long>(x => Assert.Equal(800, x)));
    }

    [Fact]
    public async Task WithdrawMoneyWithErrorsTest()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository
            .UpdateBalance(Arg.Any<string>(), Arg.Any<long>())
            .Returns(new RepositoryResult.Success());
        IOperationService operationService = Substitute.For<IOperationService>();
        operationService
            .AddOperation(Arg.Any<Operation>())
            .Returns(new ServiceResult.Success());
        var currentUserService = new CurrentUserService();
        currentUserService.User = new Account("Nikita", "123", 1000);
        var accountService = new AccountService(accountRepository, operationService, currentUserService);

        // Act
        ServiceResult result = await accountService.WithdrawMoney(1200);

        // Assert
        Assert.IsType<ServiceResult.Failed>(result);
    }

    [Fact]
    public async Task OnlyDepositMoneyTest()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository
            .UpdateBalance(Arg.Any<string>(), Arg.Any<long>())
            .Returns(new RepositoryResult.Success());
        IOperationService operationService = Substitute.For<IOperationService>();
        operationService
            .AddOperation(Arg.Any<Operation>())
            .Returns(new ServiceResult.Success());
        var currentUserService = new CurrentUserService();
        currentUserService.User = new Account("Nikita", "123", 1000);
        var accountService = new AccountService(accountRepository, operationService, currentUserService);

        // Act
        ServiceResult result = await accountService.DepositMoney(200);

        // Assert
        Assert.IsType<ServiceResult.Success>(result);
        await accountRepository.Received()
            .UpdateBalance(
                Arg.Do<string>(x => Assert.Equal("Nikita", x)),
                Arg.Do<long>(x => Assert.Equal(1200, x)));
    }

    [Fact]
    public async Task DepositAndWithdrawNoErrorsTest()
    {
        // Arrange
        long balance = 1000;
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository
            .UpdateBalance(Arg.Any<string>(), Arg.Any<long>())
            .Returns(new RepositoryResult.Success())
            .AndDoes(x => balance = (long)x[1]);
        IOperationService operationService = Substitute.For<IOperationService>();
        operationService
            .AddOperation(Arg.Any<Operation>())
            .Returns(new ServiceResult.Success());
        var currentUserService = new CurrentUserService();
        currentUserService.User = new Account("Nikita", "123", 1000);
        var accountService = new AccountService(accountRepository, operationService, currentUserService);

        // Act
        ServiceResult result1 = await accountService.DepositMoney(200);
        ServiceResult result2 = await accountService.WithdrawMoney(500);
        ServiceResult result3 = await accountService.WithdrawMoney(700);
        ServiceResult result4 = await accountService.DepositMoney(300);

        // Assert
        Assert.IsType<ServiceResult.Success>(result4);
        Assert.Equal(300, balance);
    }

    [Fact]
    public async Task DepositAndWithdrawWithErrorsTest()
    {
        // Arrange
        long balance = 1000;
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository
            .UpdateBalance(Arg.Any<string>(), Arg.Any<long>())
            .Returns(new RepositoryResult.Success())
            .AndDoes(x => balance = (long)x[1]);
        IOperationService operationService = Substitute.For<IOperationService>();
        operationService
            .AddOperation(Arg.Any<Operation>())
            .Returns(new ServiceResult.Success());
        var currentUserService = new CurrentUserService();
        currentUserService.User = new Account("Nikita", "123", 1000);
        var accountService = new AccountService(accountRepository, operationService, currentUserService);

        // Act
        ServiceResult result1 = await accountService.DepositMoney(200);
        ServiceResult result2 = await accountService.WithdrawMoney(500);
        ServiceResult result3 = await accountService.WithdrawMoney(1000);

        // Assert
        Assert.IsType<ServiceResult.Failed>(result3);
        Assert.Equal(700, balance);
    }
}