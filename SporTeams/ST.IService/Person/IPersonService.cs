using ST.IService.Person.DTOs;
using System.Collections.Generic;

namespace ST.IService.Person
{
    public interface IPersonService
    {
        void Add(PersonDto dto);

        void Update(PersonDto dto);

        void Delete(long entidadId);

        IEnumerable<PersonDto> GetByFilter(string cadenaBuscar);

        PersonDto GetById(long entidadId);
    }
}
