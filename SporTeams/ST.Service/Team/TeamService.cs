using ST.Domain.Repository.Team;
using ST.IService.Team;
using ST.IService.Team.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST.Service.Team
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public void Add(TeamDto dto)
        {
            var nowTeam = new Domain.Entities.Team
            {
                Alias = dto.Alias,
                Logo = dto.Logo,
                Points = dto.Points,
                TeamName = dto.TeamName
            };

            _teamRepository.Add(nowTeam);
            _teamRepository.Save();
        }

        public void Delete(long entidadId)
        {
            _teamRepository.Delete(entidadId);
            _teamRepository.Save();
        }

        public IEnumerable<TeamDto> GetByFilter(string searchChain)
        {
            return _teamRepository.GetByFilter(x => x.TeamName.Contains(searchChain))
            .Select(x => new TeamDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Logo = x.Logo,
                Points = x.Points,
                TeamName = x.TeamName,
                Alias = x.Alias
            }).OrderBy(x => x.TeamName)
            .ToList();
        }

        public TeamDto GetById(long entidadId)
        {
            var teamGet = _teamRepository.GetById(entidadId);

            if (teamGet == null)
                throw new Exception("The team was not found.");

            return new TeamDto
            {
                Id = teamGet.Id,
                RowVersion = teamGet.RowVersion,
                Alias = teamGet.Alias,
                Logo = teamGet.Logo,
                Points = teamGet.Points,
                TeamName = teamGet.TeamName
            };
        }

        public void Update(TeamDto dto)
        {
            var teamGet = _teamRepository.GetById(dto.Id);

            if (teamGet == null)
                throw new Exception("The team was not found.");

            _teamRepository.Update(teamGet);

            teamGet.TeamName = dto.TeamName;
            teamGet.Points = dto.Points;
            teamGet.Logo = dto.Logo;
            teamGet.Alias = dto.Alias;

            _teamRepository.Save();
        }
    }
}
