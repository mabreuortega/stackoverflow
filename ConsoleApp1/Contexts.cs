using System.Collections.Generic;
using System.Data.Entity;
using LibraryJoin;

namespace ConsoleApp1
{
    public class ContextJoin : DbContext
    {
        private readonly List<IDbContextRegistry> _registry = new List<IDbContextRegistry>();

        public ContextJoin(params IDbContextRegistry[] registry)
        {
            _registry.AddRange(registry);
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
