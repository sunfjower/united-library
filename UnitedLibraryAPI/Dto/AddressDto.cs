using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public int LibraryId { get; set; }
    }
}
