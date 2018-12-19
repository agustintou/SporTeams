using ST.Domain.Base;
using ST.Domain.Metadatas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    [Table("Teams")]
    [MetadataType(typeof(ITeam))]
    public class Team : EntityBase
    {
        public string TeamName { get; set; }

        public string Alias { get; set; }

        public int Points { get; set; }

        public byte[] Logo { get; set; }
    }
}
