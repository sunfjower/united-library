using System.ComponentModel.DataAnnotations;

namespace UnitedLibraryAPI.Models
{
    public class LibraryBook
    {
        public int InAvailable { get; set; }

        [Required]
        public int LibraryId { get; set; }
        public Library Library { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
