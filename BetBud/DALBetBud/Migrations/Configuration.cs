using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DALBetBud.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DALBetBud.Context.BetBudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DALBetBud.Context.BetBudContext context)
        {
        
        }

    }
}
