using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2024._10;

internal class Migration2024101901(DatabaseConnection databaseConnection) : MigrationBase(databaseConnection)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS Users (
                                                    id serial PRIMARY KEY,
                                                    username VARCHAR(100) NOT NULL UNIQUE,
                                                    password_hash BYTEA NOT NULL,
                                                    password_salt BYTEA NOT NULL,
                                                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP);
                     """;

        DatabaseConnection.ExecuteNonQuery(query);
    }

    public override void Down()
    {
        var query = @"DROP TABLE IF EXISTS Users;";
        
        DatabaseConnection.ExecuteNonQuery(query);
    }
}