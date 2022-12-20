using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W5_D2_BACK
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public string TipoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal TotalePagamento { get; set; }
        public int IdDipendente { get; set; }

        public static List<Pagamento> ListaPagamenti = new List<Pagamento>();
    }
}