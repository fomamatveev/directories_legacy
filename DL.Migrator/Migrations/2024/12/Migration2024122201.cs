using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2024._12;

internal class Migration2024122201(DatabaseConnection databaseConnection) : MigrationBase(databaseConnection)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS "StorageLocation" (
                                                    "Id" SERIAL PRIMARY KEY,
                                                    "Name" VARCHAR(100),
                                                    "ShortName" VARCHAR(100),
                                                    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                    "Rack" INT,
                                                    "Compartment" INT,
                                                    "Part" INT);
                     ALTER TABLE IF EXISTS "Product" DROP CONSTRAINT IF EXISTS "fk_storage_location";
                     ALTER TABLE IF EXISTS "Product" ADD CONSTRAINT "fk_storage_location" FOREIGN KEY ("StorageLocationId") REFERENCES "StorageLocation"("Id");
                     """;

        DatabaseConnection.ExecuteNonQuery(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.ExecuteNonQuery(query);
    }
}