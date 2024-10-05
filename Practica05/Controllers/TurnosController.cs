using Microsoft.AspNetCore.Mvc;
using Practica05.Models;
using Practica05.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private ITurnosRepository _repo;

        public TurnosController(ITurnosRepository repository)
        {
            _repo = repository;
        }

        // GET: api/<TurnosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch(Exception)
            {
                return StatusCode(500,"Ah ocurrido un error con el servidor");
            }
        }

        // GET api/<TurnosController>/5
        [HttpGet("/filtros")]
        public IActionResult Get([FromQuery] string? cliente=null, [FromQuery] string? fecha=null, [FromQuery] string? hora=null)
        {
            try
            {
                if (cliente!=null)
                {
                    return Ok(_repo.GetAllByFilters(cliente, fecha, hora));
                }
                else
                {
                    return BadRequest("El Campo 'cliente' es obligatorio");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ah ocurrido un error con el servidor");
            }
        }

        // POST api/<TurnosController>
        [HttpPost]
        public IActionResult Post([FromBody] Turno turno)
        {
            try
            {
                if (_repo.Save(turno))
                {
                    return Ok("Turno insertado con exito!");
                }
                else
                {
                    return BadRequest("Error al insertar el turno, ingrese correctamente los datos");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ah ocurrido un error con el servidor");
            }
        }

        // PUT api/<TurnosController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Turno turno)
        {
            try
            {
                if (_repo.Update(turno))
                {
                    return Ok("Turno actualizado con exito!");
                }
                else
                {
                    return BadRequest("Error al actualizar el turno, ingrese correctamente los datos");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ah ocurrido un error con el servidor");
            }
        }

        // DELETE api/<TurnosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_repo.Delete(id))
                {
                    return Ok("Turno removido con exito!");
                }
                else
                {
                    return BadRequest("Error al remover el turno, ingrese correctamente los datos");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ah ocurrido un error con el servidor");
            }
        }
    }
}
