using Back_End.Dtos.PersonDtos;
using Back_End.Models;

namespace Back_End.Mappers
{
    public static class PersonMappers
    {
        public static PersonDto PersonToPersonDto(this Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Address = person.Address
            };
        }

        public static Person CreatePersonDtoToPerson(this CreatePersonDto createPersonDto)
        {
            return new Person
            {
                Name = createPersonDto.Name,
                LastName = createPersonDto.LastName,
                DateOfBirth = createPersonDto.DateOfBirth,
                Address = createPersonDto.Address
            };
        }

        public static Person UpdatePersonDtoToPerson(this UpdatePersonDto updatePersonDto)
        {
            return new Person
            {
                Name = updatePersonDto.Name,
                LastName = updatePersonDto.LastName,
                DateOfBirth = updatePersonDto.DateOfBirth,
                Address = updatePersonDto.Address
            };
        }
    }
}
