using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Metadatas
{
    public interface IUser
    {
        [Index("Index_User_UserName", IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(15, ErrorMessage = "The field {0} must be less than {1} characters.")]
        string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(15, ErrorMessage = "The field {0} must be less than {1} characters.")]
        string Password { get; set; }

        bool Locked { get; set; }

    }
}
