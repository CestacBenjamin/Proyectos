using Microsoft.AspNetCore.Mvc;
using ProyectoTarea_04_.Data.Repositories;
using ProyectoTarea_04_.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTarea_04_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IServiceRepository _serviceRepository;
        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        // GET: api/<ServicesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_serviceRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno!!");
            }
        }

        // GET api/<ServicesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_serviceRepository.GetById(id));
            }
            catch (Exception) 
            {
                return BadRequest("Servicio No Encontrado!!");
            }
        }

        // POST api/<ServicesController>
        [HttpPost]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                var servicioUpdate = _serviceRepository.GetById(servicio.Id);
                if (servicioUpdate == null) 
                {
                    _serviceRepository.create(servicio);
                    return Ok("Servicio Creado Con Exito!!");
                }
                else
                {
                    _serviceRepository.Update(servicio);
                    return Ok("Servicio Actualizado con Exito!!");
                }
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ha ocurrido un error interno");

            }
        }

        // DELETE api/<ServicesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var serviceDelete = _serviceRepository.GetById(id);
                if(serviceDelete != null)
                {
                    _serviceRepository.Delete(id);
                    return Ok("Servicio eliminado con exito!");
                }
                else
                {
                    return BadRequest("No se encontro un servicio con este ID");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }
    }
}
