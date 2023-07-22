using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitedLibraryAPI.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        public Address PhysicalAddress { get; set; }

        public ICollection<LibraryBook> Books { get; set; }
    }
}
