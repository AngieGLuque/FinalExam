using System.ComponentModel.DataAnnotations;

namespace MysqlApi.Modelo
{
    public class Planta
    {
        [Key]
        public int IdPlanta { get; set; }
        public string Nombre { get; set; }
        public string Familia { get; set; }
        public string Orden { get; set; }
        public string Clase { get; set; }
    }
}
