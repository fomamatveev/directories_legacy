using System.Data;
using System.Data.Common;

namespace DL.Migrator.Data;

internal abstract class MigrationBase
{
    protected readonly IDbConnection DatabaseConnection;
    
    public long MigrationNumber { get; }

    protected MigrationBase(IDbConnection databaseConnection, long migrationNumber)
    {
        DatabaseConnection = databaseConnection;
        MigrationNumber = migrationNumber;
    }
    
    public virtual void Up() {}

    public virtual void Down() {}
}