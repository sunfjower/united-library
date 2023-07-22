using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitedLibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string FrontCoverPath { get; set; }

        public ICollection<LibraryBook> Libraries { get; set; }

        public ICollection<BookNovel> Novels { get; set; }
    }
}
