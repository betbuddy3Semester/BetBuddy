using System.Data.Entity;
using ModelLibrary.Bruger;
namespace DALBetBud.Context
{
    public class BetBudContext : DbContext
    {
        public BetBudContext() : base("name=BetBudContext")
        {
            
        }

        public DbSet<Bruger> Brugere { get; set; }


    }

}