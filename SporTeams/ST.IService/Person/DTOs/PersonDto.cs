using ST.Service.Base.DTOs;
using System;

namespace ST.IService.Person.DTOs
{
    public class PersonDto : DtoBase
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
