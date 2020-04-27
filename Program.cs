using ContratosApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UseInMemoryDatabaseNetCore3._1
{
    public class Program {
        public static void Main (string[] args) {
            var host = CreateHostBuilder (args).Build ();

            using (var scope = host.Services.CreateScope ()) {
                var context = scope.ServiceProvider.GetRequiredService<DataContext> ();

                context.Contracts.Add (new Contract { Code = 14, Bank = "Teste", Value = 100.50M, NumInstallments = 2 });
                context.SaveChanges ();
            }

            host.Run ();
        }

        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ();
            });
    }
}