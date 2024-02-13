using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1)]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        return """
               CREATE TABLE Accounts
               (
               Login TEXT PRIMARY KEY NOT NULL ,
               Password TEXT NOT NULL ,
               Balance BIGINT NOT NULL
               );

               CREATE TABLE Admins
               (
               Login TEXT PRIMARY KEY NOT NULL ,
               Password TEXT NOT NULL
               );

               CREATE TABLE Operations
               (
               AccountLogin TEXT NOT NULL ,
               Value BIGINT NOT NULL
               );

               INSERT INTO Admins(Login, Password) VALUES ('admin', 'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=');
               """;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        return """
               DROP TABLE Accounts;
               DROP TABLE Admins;
               DROP TABLE Operations;
               """;
    }
}