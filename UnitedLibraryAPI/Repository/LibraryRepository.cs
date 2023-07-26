using Microsoft.EntityFrameworkCore.Query.Internal;
using UnitedLibraryAPI.Data;
using UnitedLibraryAPI.Interfaces;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly UnitedLibraryContext _context;
        public LibraryRepository(UnitedLibraryContext context) 
        {
            _context = context;
        }

        public ICollection<Library> GetLibraries()
        {
            List<Library> libraries = _context.Libraries.OrderBy(l => l.Name).ToList();
            return libraries;
        }

        public ICollection<Library> GetLibraries(string city)
        {
            List<Library> libraries = _context.Libraries.Where(l => l.PhysicalAddress.City == city).ToList();
            return libraries;
        }
    }
}
