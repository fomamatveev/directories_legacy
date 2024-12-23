using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2024._10;

internal class Migration2024101901(DatabaseConnection databaseConnection) : MigrationBase(databaseConnection)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS "User" (
                                                    "Id" SERIAL PRIMARY KEY,
                                                    "Username" VARCHAR(100) NOT NULL UNIQUE,
                                                    "PasswordHash" BYTEA NOT NULL,
                                                    "PasswordSalt" BYTEA NOT NULL,
                                                    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP);
                     """;

        DatabaseConnection.ExecuteNonQuery(query);
    }

    public override void Down()
    {
        var query = @"DROP TABLE IF EXISTS Users;";
        
        DatabaseConnection.ExecuteNonQuery(query);
    }
}