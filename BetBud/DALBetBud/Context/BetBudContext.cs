using System.Data.Entity;
using ModelLibrary.Interfaces;
using ModelLibrary.Interfaces.SeasonInterface;
using ModelLibrary.Models;
using ModelLibrary.Models.Bruger;
using ModelLibrary.Models.Kupon;
using ModelLibrary.Models.ReservedNames;
using ModelLibrary.Models.Sęson;

namespace DALBetBud.Context
{
    public class BetBudContext : DbContext
    {
        public BetBudContext() : base("BetBudContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Bruger> Brugere { get; set; }
        public DbSet<Kupon> Kuponer { get; set; } 
        public DbSet<Kamp> Kampe { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<ReservedNames> ReservedNames { get; set; }
        public DbSet<SęsonBruger> SęsonBrugere { get; set; }
        public DbSet<Sęson> Sęsoner { get; set; }
        public DbSet<SęsonBeskrivelse> AktuelSęsonInfo { get; set; }
    }
}