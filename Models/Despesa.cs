using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestCarWeb.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public double Valor { get; set; }

        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
        public Parceiro Parceiro { get; set; }
        public int ParceiroId { get; set; }
    }
}
