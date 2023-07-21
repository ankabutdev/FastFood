using Npgsql;

namespace FastFood.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=FastFood-db; User Id=postgres; Password=Ankabut");
    }
}
