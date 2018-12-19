using ST.IService.Team.DTOs;
using System.Collections.Generic;

namespace ST.IService.Team
{
    public interface ITeamService
    {
        void Add(TeamDto dto);

        void Update(TeamDto dto);

        void Delete(long entidadId);

        IEnumerable<TeamDto> GetByFilter(string cadenaBuscar);

        TeamDto GetById(long entidadId);
    }
}
