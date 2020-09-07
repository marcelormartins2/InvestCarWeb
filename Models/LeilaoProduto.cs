using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestCarWeb.Models
{
    public class LeilaoProduto
    {
        public int ProdutoId { get; set; }
        public int LeilaoId { get; set; }
        public int Lote { get; set; }
        public double VlAvalicao { get; set; }
        public double VlCondicional { get; set; }
        public double VlVenda { get; set; }

        public Produto Produto { get; set; }
        public Leilao Leilao { get; set; }
    }
}
