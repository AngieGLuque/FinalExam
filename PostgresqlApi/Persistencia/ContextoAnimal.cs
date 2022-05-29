using PostgresqlApi.Modelo;
using Microsoft.EntityFrameworkCore;

namespace PostgresqlApi.Persistencia
{
    public class ContextoAnimal : DbContext
    {
        public ContextoAnimal(DbContextOptions<ContextoAnimal> options) : base(options)
        {
        }
        public DbSet<Animal> Animales { get; set; }
    }
}
