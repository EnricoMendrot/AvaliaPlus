using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2.Infrastructure
{
    public class ConnectionContext : DbContext

    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options)
        : base(options)
        {
        }

        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
