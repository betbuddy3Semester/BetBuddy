using ModelLibrary;
using ModelLibrary.Bruger;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CtrLayer
{
       
        public interface IBrugerController
        {
            //Returner den enkelte bruger ud fra id
            
            Bruger getBruger(int id);

            //Returner alle brugere
            
            IEnumerable<Bruger> getBrugere();

            
            void opretBruger(Bruger bruger);

            
            void opdaterBruger(Bruger bruger);

            
            void sletBruger(int id);


        }
    }
}
