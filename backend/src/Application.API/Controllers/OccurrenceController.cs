using Domain.DTO;
using Domain.Interfeces.IRepositories;
using Domain.Interfeces.IServices;
using Infra.Data.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.OData;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccurrenceController : ControllerBase
    {
        private readonly IOccurrenceService _occurrenceService;
        private readonly IOccurrenceRepository _occurrenceRepository;
        public OccurrenceController(IOccurrenceService occurrenceService, IOccurrenceRepository occurrenceRepository)
        {
            _occurrenceRepository = occurrenceRepository;
            _occurrenceService = occurrenceService;

        }

        // GET: api/<OccurrenceController>
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<OccurrenceDTO>>> Get()
        {
            return Ok(_occurrenceService.FindAll());
        }

        // GET api/<OccurrenceController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OccurrenceDTO>> Get(int id)
        {
            OccurrenceDTO occurrence = new OccurrenceDTO();

            try
            {
                occurrence = await _occurrenceService.FindById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(occurrence);
        }

        [HttpGet("idPerson/{id}")]
        public async Task<ActionResult<List<OccurrenceDTO>>> GetAllByIdPerson(int id)
        {
            List<OccurrenceDTO> lista = new List<OccurrenceDTO>();

            var teste = _occurrenceService.FindAll();

            foreach (var item in teste)
            {
                if(item.idPerson == id)
                {
                    lista.Add(item);
                }
            }

            return lista;
        }

        // POST api/<OccurrenceController>
        [HttpPost]
        public async Task<ActionResult<OccurrenceDTO>> Post([FromBody] OccurrenceDTO occurrence)
        {
            if (occurrence == null) return BadRequest();
            return new ObjectResult(await _occurrenceService.Save(occurrence));
        }

        // PUT api/<OccurrenceController>/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OccurrenceDTO occurrence)
        {
            if (occurrence == null) return BadRequest();
            return new ObjectResult(await _occurrenceService.Update(occurrence));
        }

        // DELETE api/<OccurrenceController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _occurrenceService.Delete(id));
        }
    }
}
