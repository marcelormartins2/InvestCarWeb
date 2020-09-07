using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestCarWeb.Models
{
    public class Leilao
    {
        public Leilao()
        {
            Leiloeiro = new HashSet<Leiloeiro>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Data { get; set; }
        public double TaxaAvaliacao { get; set; }
        public double TaxaVenda { get; set; }

        public ICollection<Leiloeiro> Leiloeiro { get; set; }
    }
}
