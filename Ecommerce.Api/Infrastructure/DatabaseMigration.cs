using DbUp;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ecommerce.Infrastructure.Database;

public static class DatabaseMigration
{
    public static void Run(IConfiguration config)
    {
        try
        {
            Console.WriteLine("Iniciando execução de migrations...");

            var connectionString = config.GetConnectionString("Postgres")
            ?? throw new Exception("Connection string 'Postgres' not found.");

            var connection = connectionString.Trim().Trim('"').Trim('\'');

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connection)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro aplicando migrations:");
                Console.WriteLine(result.Error);
                Console.ResetColor();
                throw result.Error!; // Rejoga para impedir o start da API se quiser
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Migrations aplicadas com sucesso!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro durante execução das migrations:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();

            // 🔥 Decide aqui:
            // Se quiser impedir o start da API quando falhar:
            throw;
        }
    }
}