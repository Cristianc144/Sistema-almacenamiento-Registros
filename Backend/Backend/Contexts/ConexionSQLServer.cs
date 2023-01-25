using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts
{
    public class ConexionSQLServer: DbContext 
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options):base(options)
        {

        }
        public DbSet<Registros> Registros { get; set; }
    }
}
