using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W5_D2_BACK
{
    public class Dipendente
    {
        public int IdDipendente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale { get; set; }
        public bool Coniugato { get; set; }
        public int NumeroFigli { get; set; }
        public string Mansione { get; set; }
        public decimal Stipendio { get; set; }

        public static List<Dipendente> ListaDipendenti = new List<Dipendente>();

    }
}