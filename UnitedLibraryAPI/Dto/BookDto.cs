using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Novel> Novels { get; set; }
    }
}
