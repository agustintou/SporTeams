using ST.Domain.Repository.Sport;
using ST.IService.Sport;
using ST.IService.Sport.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST.Service.Sport
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _sportRepository;

        public SportService(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public void Add(SportDto dto)
        {
            var nowSport = new Domain.Entities.Sport
            {
                Description = dto.Description,
                Image = dto.Image,
                PlayersByTeam = dto.PlayersByTeam,
                Removed = dto.Removed,
            };

            _sportRepository.Add(nowSport);
            _sportRepository.Save();
        }

        public void Delete(long entidadId)
        {
            _sportRepository.Delete(entidadId);
            _sportRepository.Save();
        }

        public IEnumerable<SportDto> GetByFilter(string searchChain)
        {
            return _sportRepository.GetByFilter(x => x.Description.Contains(searchChain))
            .Select(x => new SportDto
            {
                Description = x.Description,
                Image = x.Image,
                PlayersByTeam = x.PlayersByTeam,
                Removed = x.Removed,
                Id = x.Id,
                RowVersion = x.RowVersion
            }).OrderBy(x => x.Description)
            .ToList();
        }

        public SportDto GetById(long entidadId)
        {
            var sportGet = _sportRepository.GetById(entidadId);

            if (sportGet == null)
                throw new Exception("The sport was not found.");

            return new SportDto
            {
                Description = sportGet.Description,
                Image = sportGet.Image,
                PlayersByTeam = sportGet.PlayersByTeam,
                Removed = sportGet.Removed,
                Id = sportGet.Id,
                RowVersion = sportGet.RowVersion
            };
        }

        public void Update(SportDto dto)
        {
            var sportGet = _sportRepository.GetById(dto.Id);

            if (sportGet == null)
                throw new Exception("The sport was not found.");

            _sportRepository.Update(sportGet);

            sportGet.Removed = dto.Removed;
            sportGet.Image = dto.Image;
            sportGet.PlayersByTeam = dto.PlayersByTeam;
            sportGet.Description = dto.Description;

            _sportRepository.Save();
        }
    }
}
