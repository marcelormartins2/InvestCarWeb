using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestCarWeb.Models
{
    public class Leilao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public double TaxaAvaliacao { get; set; }
        public double TaxaVenda { get; set; }

        public Leiloeiro Leiloeiro { get; set; }
        public int LeiloeiroId { get; set; }
    }
}
