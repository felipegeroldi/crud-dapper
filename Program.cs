using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;

public class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=Yes;";

    static void Main(string[] args)
    {
        // ReadUsers();
        // ReadUser();
        // CreateUser();
        DeleteUser();
    }

    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }

    public static void ReadUser()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(1);

            Console.WriteLine(user.Name);
        }
    }

    public static void CreateUser()
    {
        var user = new User()
        {
            Bio = "Teste",
            Email = "teste@teste.com",
            Image = "https://...",
            Name = "Usuario Teste",
            PasswordHash = "HASH",
            Slug = "usuario-teste"
        };

        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Insert<User>(user);
            Console.WriteLine("Cadastro realizado com sucesso");
        }
    }

    public static void UpdateUser()
    {
        var user = new User()
        {
            Id = 2,
            Bio = "Teste de Usuário",
            Email = "teste@teste.com.br",
            Image = "https://...",
            Name = "Usuario de Teste",
            PasswordHash = "HASH",
            Slug = "usuario-teste"
        };

        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Update<User>(user);
            Console.WriteLine("Atualização de usuário realizada com sucesso");
        }
    }

    public static void DeleteUser()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(2);

            connection.Delete<User>(user);
            Console.WriteLine("Remoção de usuário realizada com sucesso");
        }
    }
}