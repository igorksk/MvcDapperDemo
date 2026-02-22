using Dapper;
using Microsoft.Data.Sqlite;
using MvcDapperDemo.Models;

namespace MvcDapperDemo.Data;

public class PersonRepository
{
    private readonly string _connectionString;

    public PersonRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private SqliteConnection Connection() => new(_connectionString);

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        using var db = Connection();
        var sql = "SELECT Id, Name, Age FROM People ORDER BY Id";
        return await db.QueryAsync<Person>(sql);
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        using var db = Connection();
        var sql = "SELECT Id, Name, Age FROM People WHERE Id = @Id";
        return await db.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Person person)
    {
        using var db = Connection();
        var sql = "INSERT INTO People (Name, Age) VALUES (@Name, @Age); SELECT last_insert_rowid();";
        var id = await db.ExecuteScalarAsync<long>(sql, person);
        return (int)id;
    }

    public async Task<int> UpdateAsync(Person person)
    {
        using var db = Connection();
        var sql = "UPDATE People SET Name = @Name, Age = @Age WHERE Id = @Id";
        return await db.ExecuteAsync(sql, person);
    }

    public async Task<int> DeleteAsync(int id)
    {
        using var db = Connection();
        var sql = "DELETE FROM People WHERE Id = @Id";
        return await db.ExecuteAsync(sql, new { Id = id });
    }
}
