using Npgsql;

public static class Db
{
    private static readonly string _connectionString =
        "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=trade_db";

    public static NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
