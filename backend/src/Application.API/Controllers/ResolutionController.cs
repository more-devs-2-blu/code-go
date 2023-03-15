using Domain.DTO;
using Domain.Entities;
using Domain.Interfeces.IRepositories;
using Domain.Interfeces.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolutionController : ControllerBase
    {
        private readonly IResolutionService _resolutionService;

        public ResolutionController(IResolutionService resolutionService)
        {
            _resolutionService = resolutionService;
        }

        // GET: api/<ResolutionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResolutionDTO>>> Get()
        {
            return Ok(_resolutionService.FindAll());
        }

        // GET api/<ResolutionController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ResolutionDTO>> Get(int id)
        {
            ResolutionDTO resolution = new ResolutionDTO();

            try
            {
                resolution = await _resolutionService.FindById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(resolution);
        }

        // POST api/<ResolutionController>
        [HttpPost]
        public async Task<ActionResult<ResolutionDTO>> Post([FromBody] ResolutionDTO resolution)
        {
            if (resolution == null) return BadRequest();
            return new ObjectResult(await _resolutionService.Save(resolution));
        }

        // PUT api/<ResolutionController>/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ResolutionDTO resolution)
        {
            if (resolution == null) return BadRequest();
            return new ObjectResult(await _resolutionService.Update(resolution));
        }

        // DELETE api/<ResolutionController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _resolutionService.Delete(id));
        }
    }
}
