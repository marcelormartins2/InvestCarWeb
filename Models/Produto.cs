﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InvestCarWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Data { get; set; }
        [DisplayName(displayName: "Valor Anunciado")]
        public double? VlAnunciado { get; set; }
        [DisplayName(displayName: "Valor Negociado")]
        public double? VlNegociado { get; set; }
        [DisplayName(displayName: "Valor Pago")]
        public double? VlCompra { get; set; }
        [DisplayName(displayName: "Valor de Venda")]
        public double? VlVenda { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Localizacao{ get; set; }
        public string Anuncio { get; set; }
        public string Telefone { get; set; }
        public string Vendedor { get; set; }

        public Parceiro Parceiro { get; set; }
        [Required()]
        public string ParceiroId { get; set; }

        public ICollection<Lote> Lote { get; set; } = new List<Lote>();

    }
}
