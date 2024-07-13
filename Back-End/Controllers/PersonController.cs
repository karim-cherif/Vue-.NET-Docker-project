using Back_End.Dtos.PersonDtos;
using Back_End.Interfaces;
using Back_End.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IpersonRepository _personRepository;
        public PersonController(IpersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var people = await _personRepository.GetPersonsAsync();
            var peopleDto = people.Select(person => person.PersonToPersonDto());
            return Ok(peopleDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person.PersonToPersonDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto createPersonDto)
        {
            var person = await _personRepository.CreatePersonAsync(createPersonDto);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person.PersonToPersonDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] UpdatePersonDto updatePersonDto)
        {
            var person = await _personRepository.UpdatePersonAsync(id, updatePersonDto);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person.PersonToPersonDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            var person = await _personRepository.DeletePersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
