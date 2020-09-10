using System;
using System.Collections.Generic;

namespace InvestCarWeb.Models
{
    public class Participacao
    {
        public int Id { get; set; }
        public double PorcentagemCompra { get; set; }
        public double PorcentagemLucro { get; set; }

        public Parceiro Parceiro { get; set; }
        public int ParceiroId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
    }
}
