using ST.Domain.Base;
using ST.Domain.Metadatas;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    [Table("Persons")]
    [MetadataType(typeof(IPerson))]
    public class Person : EntityBase
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
