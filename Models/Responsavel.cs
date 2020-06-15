using System;
using System.Collections.Generic;

namespace InvestCarWeb.Models
{
    public class Responsavel
    {
        public int DespesaId { get; set; }
        public string ParceiroId { get; set; }
        public double Valor { get; set; }

        public Despesa Despesa { get; set; }
        public Parceiro Parceiro { get; set; }
    }
}
