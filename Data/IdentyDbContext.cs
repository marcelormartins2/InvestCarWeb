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
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<LeilaoProduto> LeilaoProduto { get; set; }
        public virtual DbSet<Leilao> Leilao { get; set; }
        public virtual DbSet<Leiloeiro> Leiloeiro { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<LeilaoProduto>()
                .HasKey(pf => new { pf.ProdutoId, pf.LeilaoId});
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Participacao>()
                .HasKey(pf => new { pf.ParceiroId, pf.VeiculoId });
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Responsavel>()
                .HasKey(pf => new { pf.ParceiroId, pf.DespesaId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
