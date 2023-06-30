// See https://aka.ms/new-console-template for more information

using System.Transactions;
using Npgsql;

public static class Program
{
    public static void Main()
    {
        using (var scope = new TransactionScope())
        {
            for (var i = 0; i < 30; i++)
            {
                using var connection = new NpgsqlConnection("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres;Pooling=false;");
                connection.Open();
                using var cmd = connection.CreateCommand();
                cmd.CommandText = "select 1;";
                cmd.ExecuteNonQuery();
            }
            
            scope.Complete();
        }
    }
}
