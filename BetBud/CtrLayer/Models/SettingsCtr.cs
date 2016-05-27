using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DALBetBud.Context;

namespace CtrLayer.Models
{


    public class SettingsCtr
    {
        public int GetSeasonNr()
        {
            using (BetBudContext db = new BetBudContext())
            {
                return Int32.Parse(db.Settings.First(x => x.name == "Sæson").value);
            }
        }
    }


}
