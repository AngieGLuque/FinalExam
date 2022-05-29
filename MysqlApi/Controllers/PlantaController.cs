using Microsoft.AspNetCore.Mvc;
using MysqlApi.Modelo;
using MysqlApi.Persistencia;

namespace MysqlApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PlantaController : ControllerBase
    {
        private readonly ContextoPlanta _context;

        public PlantaController(ContextoPlanta contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorID(int IdPlanta)
        {
            var planta = _context.Plantas.Find(IdPlanta);
            if (planta == null)
                return NotFound();
            await _context.SaveChangesAsync();
            return Ok(planta);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorNombre(string Nombre)
        {
            var planta = _context.Plantas.FirstOrDefault(x => x.Nombre == Nombre);
            if (planta == null)
                return NotFound();
            await _context.SaveChangesAsync();
            return Ok(planta);
        }

        [HttpPut]
        public async Task<bool> EditarRegistro(Planta planta)
        {
            _context.Update(planta);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost]
        public async Task<bool> AgregarNuevoRegistro(Planta planta)
        {
            _context.Add(planta);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        public async Task<bool> BorrarNuevoRegistro(int IdPlanta)
        {
            var planta = _context.Plantas.Find(IdPlanta);
            if (planta == null)
            {
                return false;
            }
            else
            {
                _context.Plantas.Remove(planta);
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
        
}
