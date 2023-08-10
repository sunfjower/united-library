using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UnitedLibraryAPI.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ThirdName { get; set; }

        [JsonIgnore]
        public ICollection<NovelWriter> Novels { get; set; }

    }
}
