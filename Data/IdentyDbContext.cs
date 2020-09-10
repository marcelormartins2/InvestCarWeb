using InvestCarWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace InvestCarWeb.Data
{
    public class IdentyDbContext : IdentityDbContext<Parceiro>
    {
        public IdentyDbContext(DbContextOptions<IdentyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Despesa> Despesa { get; set; }
        public virtual DbSet<Parceiro> Parceiro { get; set; }
        public virtual DbSet<Participacao> Participacao { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<LeilaoProduto> LeilaoProduto { get; set; }
        public virtual DbSet<Leilao> Leilao { get; set; }
        public virtual DbSet<Leiloeiro> Leiloeiro { get; set; }


        
    }
}
