using System;
using System.Collections.Generic;
using System.Linq;
using ST.Domain.Repository.Person;
using ST.IService.Person;
using ST.IService.Person.DTOs;

namespace ST.Service.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Add(PersonDto dto)
        {
            var nowPerson = new Domain.Entities.Person
            {
                Birthdate = dto.Birthdate,
                Email = dto.Email,
                FullName = dto.FullName
            };

            _personRepository.Add(nowPerson);
            _personRepository.Save();
        }

        public void Delete(long entidadId)
        {
            _personRepository.Delete(entidadId);
            _personRepository.Save();
        }

        public IEnumerable<PersonDto> GetByFilter(string cadenaBuscar)
        {
            return _personRepository.GetByFilter(x => x.Email.Contains(cadenaBuscar)
            || x.FullName.Contains(cadenaBuscar))
            .Select(x => new PersonDto
            {
                Birthdate = x.Birthdate,
                Email = x.Email,
                FullName = x.FullName,
                Id = x.Id,
                RowVersion = x.RowVersion
            }).OrderBy(x => x.FullName)
            .ToList();
        }

        public PersonDto GetById(long entidadId)
        {
            var personGet = _personRepository.GetById(entidadId);

            if (personGet == null)
                throw new Exception("The company was not found.");

            return new PersonDto
            {
                Birthdate = personGet.Birthdate,
                Email = personGet.Email,
                FullName = personGet.FullName,
                Id = personGet.Id,
                RowVersion = personGet.RowVersion
            };
        }

        public void Update(PersonDto dto)
        {
            var personGet = _personRepository.GetById(dto.Id);

            if (personGet == null)
                throw new Exception("The company was not found.");

            _personRepository.Update(personGet);

            personGet.FullName = dto.FullName;
            personGet.Email = dto.Email;
            personGet.Birthdate = dto.Birthdate;

            _personRepository.Save();
        }
    }
}
