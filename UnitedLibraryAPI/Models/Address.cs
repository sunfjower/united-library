using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UnitedLibraryAPI.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Street { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string State { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string ZipCode { get; set; }

        [JsonIgnore]
        public int LibraryId { get; set; }
        [JsonIgnore]
        public Library Library { get; set; }
    }
}
