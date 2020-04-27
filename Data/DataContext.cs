using Microsoft.EntityFrameworkCore;

namespace ContratosApi.Data {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Contract> Contracts { get; set; }
    }
}