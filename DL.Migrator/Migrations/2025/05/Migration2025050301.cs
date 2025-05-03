using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2025._05;

internal class Migration2025050301(DbConnection databaseConnection) : MigrationBase(databaseConnection, 2025050301)
{
    public override void Up()
    {
        var query = """
                        CREATE TABLE IF NOT EXISTS "ProductName" (
                                "Id" BIGSERIAL PRIMARY KEY,
                                "Name" VARCHAR(100),
                                "ShortName" VARCHAR(100),
                                "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                "CreatedBy" BIGINT NOT NULL,
                                "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                "UpdatedBy" BIGINT NOT NULL);

                        ALTER TABLE "Product" ADD COLUMN "ProductNameId" BIGINT NOT NULL;

                        ALTER TABLE IF EXISTS "Product" DROP CONSTRAINT IF EXISTS "fk_product_name";
                        ALTER TABLE IF EXISTS "Product" ADD CONSTRAINT "fk_product_name" FOREIGN KEY ("ProductNameId") REFERENCES "ProductName"("Id");

                        INSERT INTO "EntityType" ("EntityId", "EntityCodeName", "EntityName") VALUES (5, 'ProductName', 'Позиция');
                    """;

        DatabaseConnection.Execute(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.Execute(query);
    }
}