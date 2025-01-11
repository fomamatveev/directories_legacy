using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2024._11;

internal class Migration2024113001(DbConnection databaseConnection) : MigrationBase(databaseConnection, 2024113001)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS "Product" (
                                                    "Id" BIGSERIAL PRIMARY KEY,
                                                    "Name" VARCHAR(100),
                                                    "ShortName" VARCHAR(100),
                                                    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "CreatedBy" BIGINT NOT NULL,
                                                    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "UpdatedBy" BIGINT NOT NULL,
                                                    "Description" VARCHAR(200),
                                                    "Quantity" INT,
                                                    "ProductTypeId" BIGINT NOT NULL,
                                                    "StorageLocationId" BIGINT NOT NULL);
                     CREATE TABLE IF NOT EXISTS "ProductType" (
                                                    "Id" BIGSERIAL PRIMARY KEY,
                                                    "Name" VARCHAR(100),
                                                    "ShortName" VARCHAR(100),
                                                    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "CreatedBy" BIGINT NOT NULL,
                                                    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "UpdatedBy" BIGINT NOT NULL);
                     
                     ALTER TABLE IF EXISTS "Product" DROP CONSTRAINT IF EXISTS "fk_product_type";
                     ALTER TABLE IF EXISTS "Product" ADD CONSTRAINT "fk_product_type" FOREIGN KEY ("ProductTypeId") REFERENCES "ProductType"("Id");

                     ALTER TABLE IF EXISTS "Product" DROP CONSTRAINT IF EXISTS "fk_user_created_by";
                     ALTER TABLE IF EXISTS "Product" ADD CONSTRAINT "fk_user_created_by" FOREIGN KEY ("CreatedBy") REFERENCES "User"("Id");

                     ALTER TABLE IF EXISTS "Product" DROP CONSTRAINT IF EXISTS "fk_user_updated_by";
                     ALTER TABLE IF EXISTS "Product" ADD CONSTRAINT "fk_user_updated_by" FOREIGN KEY ("UpdatedBy") REFERENCES "User"("Id");
                     
                     ALTER TABLE IF EXISTS "ProductType" DROP CONSTRAINT IF EXISTS "fk_user_created_by";
                     ALTER TABLE IF EXISTS "ProductType" ADD CONSTRAINT "fk_user_created_by" FOREIGN KEY ("CreatedBy") REFERENCES "User"("Id");

                     ALTER TABLE IF EXISTS "ProductType" DROP CONSTRAINT IF EXISTS "fk_user_updated_by";
                     ALTER TABLE IF EXISTS "ProductType" ADD CONSTRAINT "fk_user_updated_by" FOREIGN KEY ("UpdatedBy") REFERENCES "User"("Id");
                     """;

        DatabaseConnection.Execute(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.Execute(query);
    }
}