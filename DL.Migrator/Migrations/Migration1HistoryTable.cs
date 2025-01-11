using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations;

internal class Migration1HistoryTable(DbConnection databaseConnection) : MigrationBase(databaseConnection, 1)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS "MigrationHistory" ("MigrationNumber" BIGINT NOT NULL)
                     """;

        DatabaseConnection.Execute(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.Execute(query);
    }
}