using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Admins;
using Lab5.Application.Models.ResultTypes;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Admin?> FindAdminByLogin(string login)
    {
        const string sqlQuery = """
                                SELECT Login, Password
                                FROM Admins
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

        return new Admin(
            Login: reader.GetString(0),
            Password: reader.GetString(1));
    }

    public async Task<RepositoryResult> SaveAdmin(Admin admin)
    {
        admin = admin ?? throw new ArgumentNullException(nameof(admin));

        const string sqlQuery = """
                                INSERT INTO Admins(Login, Password)
                                VALUES (@login, @password);
                                """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sqlQuery, connection);

        command
            .AddParameter("login", admin.Login)
            .AddParameter("password", admin.Password);

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected switch
        {
            1 => new RepositoryResult.Success(),
            _ => new RepositoryResult.Failed("Can't connect."),
        };
    }
}