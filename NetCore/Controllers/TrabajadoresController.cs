using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.DATA.Repositories;
using NetCore.Model;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ITrabajadorRepository _trabajadorRepository;

        public TrabajadoresController(ITrabajadorRepository trabajadorRepository)
        {
            _trabajadorRepository = trabajadorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrabajadores()
        {
            return Ok(await _trabajadorRepository.GetAllTrabajadores());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrabajadorDetails(int id)
        {
            return Ok(await _trabajadorRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrabajador([FromBody]Trabajador  trabajador)
        {
            if (trabajador == null)
                return BadRequest();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _trabajadorRepository.InsertTrabajador(trabajador);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrabajador([FromBody] Trabajador trabajador)
        {
            if (trabajador == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _trabajadorRepository.UpdateTrabajador(trabajador);
            return NoContent();
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteTrabajador(int id)
        {
            await _trabajadorRepository.DeleteTrabajador(new Trabajador { Id = id});
            return NoContent();
        }
    }
}
