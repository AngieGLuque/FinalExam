using System.ComponentModel.DataAnnotations;

namespace PostgresqlApi.Modelo
{
    public class Animal
    {
        [Key]
        public int IdAnimal { get; set; }
        public string Nombre { get; set; }
        public string Familia { get; set; }
        public string Orden { get; set; }
        public string Clase { get; set; }
    }
}
