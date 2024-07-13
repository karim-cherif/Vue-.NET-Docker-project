using Back_End.Data;
using Back_End.Dtos.PersonDtos;
using Back_End.Interfaces;
using Back_End.Mappers;
using Back_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Repositories
{
    public class PersonRepository : IpersonRepository
    {
        private readonly ApplicationDBContext _context;
        public PersonRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Person> CreatePersonAsync(CreatePersonDto createPersonDto)
        {
            var person = createPersonDto.CreatePersonDtoToPerson();
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }
        public async Task<Person> DeletePersonAsync(int Id)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Id == Id);
            if (person == null)
            {
                return null;
            }
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return person;
        }
        public async Task<Person?> GetPersonByIdAsync(int Id)
        {
            return await _context.People.FindAsync(Id);
        }
        public async Task<List<Person>> GetPersonsAsync()
        {
            return await _context.People.ToListAsync();
        }
        public async Task<Person?> UpdatePersonAsync(int id, UpdatePersonDto updatePersonDto)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                return null;
            }
            person.Name = updatePersonDto.Name;
            person.LastName = updatePersonDto.LastName;
            person.DateOfBirth = updatePersonDto.DateOfBirth;
            person.Address = updatePersonDto.Address;
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
