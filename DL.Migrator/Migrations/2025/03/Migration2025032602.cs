using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2025._03;

internal class Migration2025032602(DbConnection databaseConnection) : MigrationBase(databaseConnection, 2025032602)
{
    public override void Up()
    {
        var query = """
                        CREATE TABLE IF NOT EXISTS "EntityType" (
                                "Id" BIGSERIAL PRIMARY KEY,
                                "EntityId" INT NOT NULL,
                                "EntityCodeName" VARCHAR(100) NOT NULL,
                                "EntityName" VARCHAR(100) NOT NULL);
                                    
                        INSERT INTO "EntityType" ("EntityId", "EntityCodeName", "EntityName") VALUES
                            (1, 'User', 'Пользователь'), (2, 'Product', 'Товар'), (3, 'ProductType', 'Категория товара'), (4, 'StorageLocation', 'Место хранения');
                    """;

        DatabaseConnection.Execute(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.Execute(query);
    }
}