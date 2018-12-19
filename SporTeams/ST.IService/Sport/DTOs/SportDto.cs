using ST.Service.Base.DTOs;

namespace ST.IService.Sport.DTOs
{
    public class SportDto : DtoBase
    {
        public string Description { get; set; }

        public string Removed { get; set; }

        public int PlayersByTeam { get; set; }

        public byte[] Image { get; set; }
    }
}