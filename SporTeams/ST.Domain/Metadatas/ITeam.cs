using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Metadatas
{
    public interface ITeam
    {
        [Index("Index_Team_TeamName", IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(25, ErrorMessage = "The field {0} must be less than {1} characters.")]
        string TeamName { get; set; }

        [Index("Index_Team_Alias", IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(3, ErrorMessage = "The field {0} must be less than {1} characters.")]     
        string Alias { get; set; }

        int Points { get; set; }

        byte[] Log { get; set; }
    }
}
