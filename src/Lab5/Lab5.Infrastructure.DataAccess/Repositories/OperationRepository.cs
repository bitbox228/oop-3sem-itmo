using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.ResultTypes;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<Operation> GetOperationsByAccountLogin(string accountLogin)
    {
        const string sqlQuery = """
                                SELECT AccountLogin, Value
                                FROM Operations
                                WHERE AccountLogin = @login;
                                """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sqlQuery, connection);
        command.AddParameter("login", accountLogin);

        await using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            yield return new Operation(
                AccountLogin: reader.GetString(0),
                Value: reader.GetInt64(1));
        }
    }

    public async Task<RepositoryResult> SaveOperation(Operation operation)
    {
        operation = operation ?? throw new ArgumentNullException(nameof(operation));

        const string sqlQuery = """
                                INSERT INTO Operations(AccountLogin, Value)
                                VALUES (@accountLogin, @value);
                                """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sqlQuery, connection);

        command
            .AddParameter("accountLogin", operation.AccountLogin)
            .AddParameter("value", operation.Value);

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected switch
        {
            1 => new RepositoryResult.Success(),
            _ => new RepositoryResult.Failed("Can't connect."),
        };
    }
}