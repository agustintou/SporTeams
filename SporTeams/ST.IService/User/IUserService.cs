using ST.IService.User.DTOs;
using System.Collections.Generic;

namespace ST.IService.User
{
    public interface IUserService
    {
        void Add(UserDto dto);

        void Update(UserDto dto);

        void Delete(long entidadId);

        IEnumerable<UserDto> GetByFilter(string cadenaBuscar);

        UserDto GetById(long entidadId);
    }
}
