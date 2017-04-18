using System.Data.Entity;
using System.Data.Entity.Migrations;
using LibraryJoin;

namespace LibraryA
{
    public class ContextA : DbContext, IDbContextRegistry
    {
        static ContextA()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextA, ConfigurationA>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configure(modelBuilder);
        }

        public void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelA>();
        }
    }

    internal sealed class ConfigurationA : DbMigrationsConfiguration<ContextA>
    {
        public ConfigurationA()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextA context)
        {
        }
    }

    public class ModelA
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
