using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2024._11;

internal class Migration2024113001(DatabaseConnection databaseConnection) : MigrationBase(databaseConnection)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS "Product" (
                                                    "Id" SERIAL PRIMARY KEY,
                                                    "Name" VARCHAR(100),
                                                    "ShortName" VARCHAR(100),
                                                    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "Description" VARCHAR(200),
                                                    "Quantity" INT,
                                                    "ProductTypeId" SERIAL,
                                                    "StorageLocationId" SERIAL);
                     CREATE TABLE IF NOT EXISTS "ProductType" (
                                                    "Id" SERIAL PRIMARY KEY,
                                                    "Name" VARCHAR(100),
                                                    "ShortName" VARCHAR(100),
                                                    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP);
                     ALTER TABLE IF EXISTS "Product" DROP CONSTRAINT IF EXISTS "fk_product_type";
                     ALTER TABLE IF EXISTS "Product" ADD CONSTRAINT "fk_product_type" FOREIGN KEY ("ProductTypeId") REFERENCES "ProductType"("Id");
                     """;

        DatabaseConnection.ExecuteNonQuery(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.ExecuteNonQuery(query);
    }
}