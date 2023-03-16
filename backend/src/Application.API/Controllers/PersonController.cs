using Domain.DTO;
using Domain.Interfeces.IServices;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/<PersonController>/{id}
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

        // GET api/<PersonController>/{id}
        [HttpGet("login/{email}&{senha}")]
        public async Task<bool> GetLogin(string email, string senha)
        {
            var person = _personService.FindAll();

            foreach (var item in person)
            {
                if(item.email == email && item.password == senha)
                {
                    return true;
                }
            }

            return false;
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<PersonDTO>> Post([FromBody] PersonDTO person)
        {
            person.createdOn = DateTime.Now;
            if (person == null) return BadRequest();
            return new ObjectResult(await _personService.Save(person));
        }

        // PUT api/<PersonController>/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PersonDTO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(await _personService.Update(person));
        }

        // DELETE api/<PersonController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _personService.Delete(id));
        }
    }
}
