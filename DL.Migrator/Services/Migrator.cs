using System.Reflection;
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
        foreach (var t in migrationTypes)
        {
            using var tx = db.BeginTransaction();
            try
            {
                var connection = new DatabaseConnection(db);
                var m = (t.DeclaredConstructors.First()
                    .Invoke([connection]) as MigrationBase)!;
                m.Up();
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
            }
        }
    }
}