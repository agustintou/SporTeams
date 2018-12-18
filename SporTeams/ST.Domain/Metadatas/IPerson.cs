using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Metadatas
{
    public interface IPerson
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be less than {1} characters.")]
        string FullName { get; set; }

        [Index("Index_Person_Email", IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be less than {1} characters.")]
        string Email { get; set; }

        DateTime Birthdate { get; set; }

    }
}
