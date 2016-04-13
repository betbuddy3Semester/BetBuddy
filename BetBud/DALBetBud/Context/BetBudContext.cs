using System.Data.Entity;
using BusinessLogicLayer.ApplicationLayer.ModelLayer;
using WFCLayer;

namespace DALBetBud.Context
{
    public class BetBudContext : DbContext
    {
        public BetBudContext() : base("name=BetBudContext")
        {
        }

    }

}