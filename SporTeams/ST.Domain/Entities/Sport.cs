using ST.Domain.Base;
using ST.Domain.Metadatas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    [Table("Sports")]
    [MetadataType(typeof(ISport))]
    public class Sport : EntityBase
    {
        public string Description { get; set; }

        public string Removed { get; set; }

        public int PlayersByTeam { get; set; }

        public byte[] Image { get; set; }
    }
}
