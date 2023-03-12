using Domain.DTO;
using Domain.Interfeces.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> Get(int id)
        {
            PersonDTO person = new PersonDTO();

            try
            {
                person = await _personService.FindById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<PersonDTO>> Post([FromBody] PersonDTO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(await _personService.Save(person));
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PersonDTO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(await _personService.Update(person));
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _personService.Delete(id));
        }
    }
}
