using Domain.DTO;
using Domain.Interfeces.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> Get()
        {
            return Ok(_addressService.FindAll());
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> Get(int id)
        {
            AddressDTO address = new AddressDTO();

            try
            {
                address = await _addressService.FindById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult<AddressDTO>> Post([FromBody] AddressDTO address)
        {
            if (address == null) return BadRequest();
            return new ObjectResult(await _addressService.Save(address));
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AddressDTO address)
        {
            if (address == null) return BadRequest();
            return new ObjectResult(await _addressService.Update(address));
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _addressService.Delete(id));
        }
    }
}
