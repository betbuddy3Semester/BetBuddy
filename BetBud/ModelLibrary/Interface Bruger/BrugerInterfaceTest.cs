using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interface_Bruger
{
    public class BrugerInterfaceTest : IBruger
    {
        public BrugerInterfaceTest()
        {
            Navn = "Bentemusen";
            
        }
        public string Alias
        {
            get
            {
                return Navn = "Bentemusen";
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string BrugerNavn
        {
            get
            {
                return BrugerNavn = "Bentemusen";
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Email
        {
            get
            {
                return Email = "Bentemuzzen@pølsemail.nu";
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Navn
        {
            get
            {
                return Navn = "Bente";
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
    

