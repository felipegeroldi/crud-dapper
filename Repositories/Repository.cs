using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;
public class Repository<TEntity> where TEntity : class
{
    protected readonly SqlConnection _connection;

    public Repository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<TEntity> GetAll()
        => _connection.GetAll<TEntity>();

    public TEntity Get(int id)
        => _connection.Get<TEntity>(id);

    public void Create(TEntity entity)
        => _connection.Insert<TEntity>(entity);

    public void Update(TEntity entity)
        => _connection.Update<TEntity>(entity);

    public void Delete(TEntity entity)
        => _connection.Delete<TEntity>(entity);

    public void Delete(int id)
    {
        var entity = _connection.Get<TEntity>(id);
        _connection.Delete<TEntity>(entity);
    }
}