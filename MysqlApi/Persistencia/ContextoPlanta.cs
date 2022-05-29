using MysqlApi.Modelo;
using Microsoft.EntityFrameworkCore;

namespace MysqlApi.Persistencia
{
    public class ContextoPlanta : DbContext
    {
        public ContextoPlanta(DbContextOptions<ContextoPlanta> options) : base(options)
        {
        }
        public DbSet<Planta> Plantas { get; set; }
    }
}
