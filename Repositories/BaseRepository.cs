using FastFood.Constants;
using Npgsql;

namespace FastFood.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        this._connection = new NpgsqlConnection(DbConstant.DB_CONNECTION_STRING);
    }
}
