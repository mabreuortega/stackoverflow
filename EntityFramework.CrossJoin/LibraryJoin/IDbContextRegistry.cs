using System.Data.Entity;

namespace LibraryJoin
{
    public interface IDbContextRegistry
    {
        void Configure(DbModelBuilder builder);
    }
}
