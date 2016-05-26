using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.SeasonInterface;


namespace CtrLayer
{
    interface ISæsonBeskrivelseController
    {
        string RedigerStartDato(string nyStartDato);
        string RedigerSlutDato(string nySlutDato);
        string RedigerBeskrivelse(string nyBeskrivelse);

        SæsonBeskrivelse HentNuværendeSæson();

        SæsonBeskrivelse OpdaterSæsonBeskrivelse(string beskrivelse, string start, string slut);
    }
}
