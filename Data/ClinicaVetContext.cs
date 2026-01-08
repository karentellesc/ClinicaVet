using Microsoft.EntityFrameworkCore;
using ClinicaVet.Models;

namespace ClinicaVet.Data
{
    public class ClinicaVetContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        public ClinicaVetContext(DbContextOptions<ClinicaVetContext> options)
            : base(options)
        {
        }

        public ClinicaVetContext()
        {
        }
    }
}
