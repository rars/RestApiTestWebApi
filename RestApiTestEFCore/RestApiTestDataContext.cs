using Microsoft.EntityFrameworkCore;
using RestApiTestDomain.Models;

namespace RestApiTestEFCore
{
    public class RestApiTestDataContext : DbContext
    {
        public DbSet<RestApi> RestApis { get; set; }

        public DbSet<RestApiTest> RestApiTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestApi>().HasKey("Name");
            modelBuilder.Entity<RestApiTest>().HasKey("RestApiTestId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=testing-framework.db", o => o.MigrationsAssembly("DatabaseMigrations"));
        }
    }
}
