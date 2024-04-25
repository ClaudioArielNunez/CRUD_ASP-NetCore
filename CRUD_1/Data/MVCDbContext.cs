using CRUD_1.Models.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CRUD_1.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
