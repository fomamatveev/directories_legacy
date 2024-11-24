using Npgsql;

namespace DL.Migrator.Data;

internal sealed class DatabaseConnection(NpgsqlConnection npgsqlConnection) : IDisposable
{
    private readonly NpgsqlConnection _npgsqlConnection = npgsqlConnection;

    public void ExecuteNonQuery(string query)
    {
        using var command = new NpgsqlCommand(query, _npgsqlConnection);
        command.ExecuteNonQuery();
    }

    public void Dispose()
    {
        _npgsqlConnection?.Dispose();
    }
}