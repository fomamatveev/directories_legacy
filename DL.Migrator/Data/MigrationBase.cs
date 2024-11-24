namespace DL.Migrator.Data;

internal abstract class MigrationBase
{
    protected readonly DatabaseConnection DatabaseConnection;

    protected MigrationBase(DatabaseConnection databaseConnection)
    {
        DatabaseConnection = databaseConnection;
    }
    
    public virtual void Up() {}

    public virtual void Down() {}
}