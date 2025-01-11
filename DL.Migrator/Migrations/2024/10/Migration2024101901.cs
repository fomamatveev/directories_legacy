using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2024._10;

internal class Migration2024101901(DbConnection databaseConnection) : MigrationBase(databaseConnection, 2024101901)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS "User" (
                                                    "Id" BIGSERIAL PRIMARY KEY,
                                                    "Username" VARCHAR(100) NOT NULL UNIQUE,
                                                    "PasswordHash" BYTEA NOT NULL,
                                                    "PasswordSalt" BYTEA NOT NULL,
                                                    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP);
                     """;
        
        DatabaseConnection.Execute(query);
    }

    public override void Down()
    {
        var query = @"DROP TABLE IF EXISTS Users;";
        
        DatabaseConnection.Execute(query);
    }
}