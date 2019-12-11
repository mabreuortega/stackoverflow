using System.Collections.Generic;
using System.Data.Entity;
using LibraryJoin;

namespace ConsoleApp1
{
    public class ContextJoin : DbContext
    {
        private readonly List<IDbContextRegistry> _registry = new List<IDbContextRegistry>();

        // Constructor to allow automatic DI injection for most modern containers
        public ContextJoin(IEnumerable<IDbContextRegistry> registry)
        {
            _registry.AddRange(registry);
        }

        public ContextJoin(params IDbContextRegistry[] registry) : this(_registry.AsEnumerable())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entry in _registry)
            {
                entry.Configure(modelBuilder);
            }
        }
    }
}
