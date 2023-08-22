using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<Library>> GetAllLibraries()
        {
            List<Library> libraries = await _context.Libraries.OrderBy(l => l.Name).ToListAsync();
            return libraries;
        }

        public async Task<ICollection<Library>> GetLibrariesByLocationAndBookId(string state, string city, int bookId)
        {
            List<Library> libraries = await _context.Libraries
                .Where(l => l.PhysicalAddress.State == state && l.PhysicalAddress.City == city && l.Books.Any(b => b.BookId == bookId))
                .Include(l => l.PhysicalAddress)
                .ToListAsync();

            return libraries;
        }

        public async Task<ICollection<Library>> GetLibrariesByStateAndCity(string state, string city)
        {
            List<Library> libraries = await _context.Libraries
                .Where(l => l.PhysicalAddress.State == state && l.PhysicalAddress.City == city)
                .Include(l => l.PhysicalAddress)
                .ToListAsync();

            return libraries;
        }
    }
}
