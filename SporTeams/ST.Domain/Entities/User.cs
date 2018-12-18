using ST.Domain.Base;
using ST.Domain.Metadatas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    [Table("Users")]
    [MetadataType(typeof(IUser))]
    public class User : EntityBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Locked { get; set; }
    }
}
