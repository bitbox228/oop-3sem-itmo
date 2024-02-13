using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ResultTypes;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Account?> FindAccountByLogin(string login)
    {
        const string sqlQuery = """
                                SELECT Login, Password, Balance
                                FROM Accounts
                                WHERE Login = @login;
                                """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sqlQuery, connection);

        command.AddParameter("login", login);

        await using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
            return null;

        return new Account(
            Login: reader.GetString(0),
            Password: reader.GetString(1),
            Balance: reader.GetInt64(2));
    }

    public async Task<RepositoryResult> SaveAccount(Account account)
    {
        account = account ?? throw new ArgumentNullException(nameof(account));

        const string sqlQuery = """
                                INSERT INTO Accounts(Login, Password, Balance)
                                VALUES (@login, @password, @balance);
                                """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sqlQuery, connection);

        command
            .AddParameter("login", account.Login)
            .AddParameter("password", account.Password)
            .AddParameter("balance", account.Balance);

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected switch
        {
            1 => new RepositoryResult.Success(),
            _ => new RepositoryResult.Failed("Can't connect."),
        };
    }

    public async Task<RepositoryResult> UpdateBalance(string login, long newBalance)
    {
        const string sqlQuery = """
                                UPDATE Accounts
                                SET Balance = @newBalance
                                WHERE Login = @login;
                                """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sqlQuery, connection);

        command
            .AddParameter("newBalance", newBalance)
            .AddParameter("login", login);

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected switch
        {
            1 => new RepositoryResult.Success(),
            _ => new RepositoryResult.Failed("Can't connect."),
        };
    }
}