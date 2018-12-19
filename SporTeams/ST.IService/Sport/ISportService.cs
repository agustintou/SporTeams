using ST.IService.Sport.DTOs;
using System.Collections.Generic;

namespace ST.IService.Sport
{
    public interface ISportService
    {
        void Add(SportDto dto);

        void Update(SportDto dto);

        void Delete(long entidadId);

        IEnumerable<SportDto> GetByFilter(string cadenaBuscar);

        SportDto GetById(long entidadId);
    }
}
