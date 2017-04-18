using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LibraryJoin;

namespace LibraryB
{
    public class ContextB : DbContext, IDbContextRegistry
    {
        static ContextB()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextB, ConfigurationB>());
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configure(modelBuilder);
        }

        public void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelB>();
        }
    }

    internal sealed class ConfigurationB : DbMigrationsConfiguration<ContextB>
    {
        public ConfigurationB()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextB context)
        {
        }
    }

    public class ModelB
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
