using ST.Service.Base.DTOs;

namespace ST.IService.Team.DTOs
{
    public class TeamDto : DtoBase
    {
        public string TeamName { get; set; }

        public string Alias { get; set; }

        public int Points { get; set; }

        public byte[] Logo { get; set; }
    }
}
