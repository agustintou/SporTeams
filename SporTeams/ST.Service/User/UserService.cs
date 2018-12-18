using System;
using System.Collections.Generic;
using System.Linq;
using ST.Domain.Repository.User;
using ST.IService.User;
using ST.IService.User.DTOs;

namespace ST.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserDto dto)
        {
            var nowUser = new Domain.Entities.User
            {
                Locked = dto.Locked,
                Password = dto.Password,
                UserName = dto.UserName
            };

            _userRepository.Add(nowUser);
            _userRepository.Save();
        }

        public void Delete(long entidadId)
        {
            _userRepository.Delete(entidadId);
            _userRepository.Save();
        }

        public IEnumerable<UserDto> GetByFilter(string searchChain)
        {
            return _userRepository.GetByFilter(x => x.UserName.Contains(searchChain))
            .Select(x => new UserDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Locked = x.Locked,
                Password = x.Password,
                UserName = x.UserName
            }).OrderBy(x => x.UserName)
            .ToList();
        }

        public UserDto GetById(long entidadId)
        {
            var userGet = _userRepository.GetById(entidadId);

            if (userGet == null)
                throw new Exception("The user was not found.");

            return new UserDto
            {
                Id = userGet.Id,
                Locked = userGet.Locked,
                Password = userGet.Password,
                RowVersion = userGet.RowVersion,
                UserName = userGet.UserName
            };
        }

        public void Update(UserDto dto)
        {
            var userGet = _userRepository.GetById(dto.Id);

            if (userGet == null)
                throw new Exception("The user was not found.");

            _userRepository.Update(userGet);

            userGet.UserName = dto.UserName;
            userGet.Password = dto.Password;
            userGet.Locked = dto.Locked;

            _userRepository.Save();
        }
    }
}
