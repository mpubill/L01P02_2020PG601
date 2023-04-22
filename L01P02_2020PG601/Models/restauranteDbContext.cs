using Microsoft.EntityFrameworkCore;

namespace L01P02_2020PG601.Models
{
    public class restauranteDbContext : DbContext
    {
        public restauranteDbContext(DbContextOptions options) : base(options) {
        
        }

        public DbSet<clientes> clientes { get; set; }
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<platos> platos { get; set; }
        public DbSet<motoristas> motoristas { get; set;}
    }
}
