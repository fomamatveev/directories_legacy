using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2024._12;

internal class Migration2024122201(DbConnection databaseConnection) : MigrationBase(databaseConnection, 2024122201)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS "StorageLocation" (
                                                    "Id" BIGSERIAL PRIMARY KEY,
                                                    "Name" VARCHAR(100),
                                                    "ShortName" VARCHAR(100),
                                                    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "CreatedBy" BIGINT NOT NULL,
                                                    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "UpdatedBy" BIGINT NOT NULL,
                                                    "Rack" INT,
                                                    "Compartment" INT,
                                                    "Part" INT);

                     ALTER TABLE IF EXISTS "Product" DROP CONSTRAINT IF EXISTS "fk_storage_location";
                     ALTER TABLE IF EXISTS "Product" ADD CONSTRAINT "fk_storage_location" FOREIGN KEY ("StorageLocationId") REFERENCES "StorageLocation"("Id");
                     
                     ALTER TABLE IF EXISTS "StorageLocation" DROP CONSTRAINT IF EXISTS "fk_user_created_by";
                     ALTER TABLE IF EXISTS "StorageLocation" ADD CONSTRAINT "fk_user_created_by" FOREIGN KEY ("CreatedBy") REFERENCES "User"("Id");

                     ALTER TABLE IF EXISTS "StorageLocation" DROP CONSTRAINT IF EXISTS "fk_user_updated_by";
                     ALTER TABLE IF EXISTS "StorageLocation" ADD CONSTRAINT "fk_user_updated_by" FOREIGN KEY ("UpdatedBy") REFERENCES "User"("Id");
                     """;

        DatabaseConnection.Execute(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.Execute(query);
    }
}