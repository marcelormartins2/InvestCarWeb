using System;
using System.Collections.Generic;

namespace InvestCarWeb.Models
{
    public class Despesa
    {
        public Despesa()
        {
            Responsavel = new HashSet<Responsavel>();
            Veiculo = new HashSet<Veiculo>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }

        public ICollection<Responsavel> Responsavel { get; set; }
        public ICollection<Veiculo> Veiculo { get; set; }
    }
}
