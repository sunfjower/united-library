using System.ComponentModel.DataAnnotations;

namespace UnitedLibraryAPI.Models
{
    public class BookNovel
    {
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        public int NovelId { get; set; }
        public Novel Novel { get; set; }

    }
}
