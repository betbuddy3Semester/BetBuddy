using System.Data.Entity;

namespace DALBetBud.Context
{
    public class BetBudContext : DbContext
    {
        public BetBudContext() : base("name=BetBudContext")
        {
        }

    }

}