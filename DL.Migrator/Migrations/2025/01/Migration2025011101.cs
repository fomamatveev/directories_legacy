using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2025._01;

internal class Migration2025011101(DbConnection databaseConnection) : MigrationBase(databaseConnection, 2025011101)
{
    public override void Up()
    {
        var query = $"""
                     CREATE TABLE IF NOT EXISTS "AuditLog" (
                                                    "Id" BIGSERIAL PRIMARY KEY,
                                                    "Action" INT NOT NULL,
                                                    "EntityName" VARCHAR(100) NOT NULL,
                                                    "EntityId" BIGINT NOT NULL,
                                                    "Changes" VARCHAR(1000) NOT NULL,
                                                    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
                                                    "UpdatedBy" BIGINT NOT NULL);

                     ALTER TABLE IF EXISTS "AuditLog" DROP CONSTRAINT IF EXISTS "fk_user_updated_by";
                     ALTER TABLE IF EXISTS "AuditLog" ADD CONSTRAINT "fk_user_updated_by" FOREIGN KEY ("UpdatedBy") REFERENCES "User"("Id");
                     """;

        DatabaseConnection.Execute(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.Execute(query);
    }
}