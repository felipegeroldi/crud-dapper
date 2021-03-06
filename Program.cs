using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;

public class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=Yes;";

    static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();

        ReadUsers(connection);
        ReadRoles(connection);
        ReadTags(connection);

        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var items = repository.GetAll();

        foreach (var item in items)
            Console.WriteLine(item.Name);
    }

    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new Repository<Role>(connection);
        var items = repository.GetAll();

        foreach (var item in items)
            Console.WriteLine(item.Name);
    }

    public static void ReadTags(SqlConnection connection)
    {
        var repository = new Repository<Tag>(connection);
        var items = repository.GetAll();

        foreach (var item in items)
            Console.WriteLine(item.Name);
    }
}