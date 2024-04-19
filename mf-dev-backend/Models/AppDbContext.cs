using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace mf_dev_backend.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ } // Me passa as opções que eu configuro pra você

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
