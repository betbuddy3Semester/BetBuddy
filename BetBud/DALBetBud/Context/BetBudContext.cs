using System.Data.Entity;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace DALBetBud.Context
{
    public class BetBudContext : DbContext
    {
        public BetBudContext() : base("BetBudContext")
        {
            
        }

        public DbSet<Bruger> Brugere { get; set; }
        public DbSet<Kupon> Kuponer { get; set; } 
        public DbSet<Kamp> Kampe { get; set; } 


    }

}