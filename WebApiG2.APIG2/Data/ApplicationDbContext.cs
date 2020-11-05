using Microsoft.EntityFrameworkCore;
using WebApiG2.APIG2.Models;

namespace WebApiG2.APIG2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas{ get; set; }
        public virtual DbSet<Ciudad> Ciudades{ get; set; }
        public virtual DbSet<Depto> Deptos { get; set; }
    }
}
