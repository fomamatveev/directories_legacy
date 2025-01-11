using System.Data;
using System.Reflection;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Services;

public class Migrator(DatabaseConnectionFactory databaseConnectionFactory)
{
    public void UpdateDatabase()
    {
        var migrationTypes = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.IsAssignableTo(typeof(MigrationBase))
            && !x.IsInterface
            && !x.IsAbstract).OrderBy(x => x.Name);

        var db = databaseConnectionFactory.CreateConnection();
        db.Open();
        
        var tableExists = db.ExecuteScalar<bool>(
            $"""
             SELECT EXISTS (
                         SELECT 1
                         FROM information_schema.tables
                         WHERE table_schema = 'public'
                           AND table_name = 'MigrationHistory');
             """);
        
        foreach (var t in migrationTypes)
        {
            using var tx = db.BeginTransaction();
            try
            {
                var m = (t.DeclaredConstructors.First().Invoke([db]) as MigrationBase)!;

                long completedMigration = default;
                
                if (tableExists)
                {
                    completedMigration = db.QueryFirstOrDefault<long>
                        ($"""SELECT "MigrationNumber" FROM "MigrationHistory" WHERE "MigrationNumber" = {m.MigrationNumber};""");
                }
                
                if (completedMigration == default)
                {
                    m.Up();
                    tx.Commit();

                    db.Execute($"""INSERT INTO "MigrationHistory" VALUES ({m.MigrationNumber});""");
                }
            }
            catch
            {
                tx.Rollback();
            }
        }
    }
}