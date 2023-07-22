using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ICollection<BookNovel> Books { get; set; }



    }
}
