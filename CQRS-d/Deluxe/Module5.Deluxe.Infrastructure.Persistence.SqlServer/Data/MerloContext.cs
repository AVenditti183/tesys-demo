using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Module5.Deluxe.Infrastructure.Persistence.SqlServer.Data
{
    public partial class MerloEntities : DbContext
    {
        public MerloEntities()
            : base("name=MerloEntities2")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<MerloEntities>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Court> Courts { get; set; }
    }
}