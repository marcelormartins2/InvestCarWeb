using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InvestCarWeb.Models
{
    public class Veiculo
    {
        public Veiculo()
        {
            Participacao = new HashSet<Participacao>();
        }

        public int Id { get; set; }
        public string Modelo_Fabricante { get; set; }
        public string Placa { get; set; }
        public string Chassis { get; set; }
        public string Cor { get; set; }
        public string Dut { get; set; }
        public int? Hodometro { get; set; }
        [DisplayName(displayName: "AnoFab")]
        public int AnoFab { get; set; }
        [DisplayName(displayName: "AnoMod")]
        public int AnoModelo { get; set; }
        public string Origem { get; set; }
        public int? Renavam { get; set; }
        [DisplayName(displayName: "Fipe")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public double? ValorFipe { get; set; }
        [DisplayName(displayName: "Compra")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public double? ValorPago { get; set; }
        [DisplayName(displayName: "Venda")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public double? ValorVenda { get; set; }
        public int? DespesaId { get; set; }
        public int NumConsultas { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        [DisplayName(displayName: "DtCompra")]
        public DateTime DtCadastro { get; set; }

        public Despesa Despesa { get; set; }
        public ICollection<Participacao> Participacao { get; set; }
    }
}
