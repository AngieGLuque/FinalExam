using Microsoft.AspNetCore.Mvc;
using PostgresqlApi.Modelo;
using PostgresqlApi.Persistencia;


namespace PostgresqlApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AnimalController : ControllerBase
    {
        private readonly ContextoAnimal _context;

        public AnimalController(ContextoAnimal contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorID(int IdAnimal)
        {
            var animal = _context.Animales.Find(IdAnimal);
            if (animal == null)
                return NotFound();
            await _context.SaveChangesAsync();
            return Ok(animal);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorNombre(string Nombre)
        {
            var animal = _context.Animales.FirstOrDefault(x => x.Nombre == Nombre);
            if (animal == null)
                return NotFound();
            await _context.SaveChangesAsync();
            return Ok(animal);
        }

        [HttpPut]
        public async Task<bool> EditarRegistro(Animal animal)
        {
            _context.Update(animal);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost]
        public async Task<bool> AgregarNuevoRegistro(Animal animal)
        {
            _context.Add(animal);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        public async Task<bool> BorrarNuevoRegistro(int IdAnimal)
        {
            var animal = _context.Animales.Find(IdAnimal);
            if (animal == null)
            {
                return false;
            }
            else
            {
                _context.Animales.Remove(animal);
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
