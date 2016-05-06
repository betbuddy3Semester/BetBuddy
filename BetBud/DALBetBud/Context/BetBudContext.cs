using System.Data.Entity;
using ModelLibrary.Bruger;
using ModelLibrary.Chat;
using ModelLibrary.Kupon;

namespace DALBetBud.Context
{
    public class BetBudContext : DbContext
    {
        public BetBudContext() : base("BetBudContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Bruger> Brugere { get; set; }
        public DbSet<Kupon> Kuponer { get; set; } 
        public DbSet<Kamp> Kampe { get; set; }
        public DbSet<AServer> ChatServers { get; set; }


    }

}