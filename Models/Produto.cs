using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestCarWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Data { get; set; }
        public double VlAnunciado { get; set; }
        public double VlPago { get; set; }
        public double VlVendido { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Localizacao{ get; set; }
        public string Anuncio { get; set; }
        public string Telefone { get; set; }
        public string Vendedor { get; set; }
    }
}
