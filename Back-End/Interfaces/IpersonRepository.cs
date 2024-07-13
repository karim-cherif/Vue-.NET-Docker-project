using Back_End.Dtos.PersonDtos;
using Back_End.Models;

namespace Back_End.Interfaces
{
    public interface IpersonRepository
    {
        Task<List<Person>> GetPersonsAsync();
        Task<Person?> GetPersonByIdAsync(int Id);
        Task<Person> CreatePersonAsync(CreatePersonDto createPersonDto);
        Task<Person?> UpdatePersonAsync(int id,UpdatePersonDto updatePersonDto);
        Task<Person> DeletePersonAsync(int Id);
    }
}
