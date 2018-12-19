using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Metadatas
{
    public interface ISport
    {
        [Index("Index_Sport_Description", IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be less than {1} characters.")]
        string Description { get; set; }

        bool Removed { get; set; }

        int PlayersByTeam { get; set; }

        byte[] Image { get; set; }
    }
}
