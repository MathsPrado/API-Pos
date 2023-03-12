using Microsoft.EntityFrameworkCore;
using Student.API.Model;

namespace Student.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<SolicitacaoProjeto> SolicitacaoProjeto { get; set; }
        public DbSet<PropostaSolicitacaoProjeto> PropostaSolicitacaoProjeto { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<SolicitacaoProjeto>().HasKey(c => c.Id);
            mb.Entity<PropostaSolicitacaoProjeto>().HasKey(c => c.Id);
        }
    }
}
