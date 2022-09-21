using System.Data.Entity;
using Module5.Regular.ReadStack.Model;

namespace Module5.Regular.ReadStack
{
    class QueryDbContext : DbContext
    {
        public QueryDbContext()
            : base("name=MerloEntities")
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<Match> Matches { get; set; }
    }
}