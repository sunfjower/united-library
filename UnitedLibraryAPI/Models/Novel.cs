using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UnitedLibraryAPI.Models
{
    public class Novel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        public ICollection<NovelWriter> Writers { get; set; }

        [JsonIgnore]
        public ICollection<BookNovel> Books { get; set; }
    }
}
