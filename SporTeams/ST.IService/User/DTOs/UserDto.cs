using ST.Service.Base.DTOs;

namespace ST.IService.User.DTOs
{
    public class UserDto : DtoBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Locked { get; set; }
    }
}
