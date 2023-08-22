using Microsoft.EntityFrameworkCore;
using UnitedLibraryAPI.Data;
using UnitedLibraryAPI.Interfaces;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Repository
{
    public class WriterRepository : IWriterRepository
    {
        private readonly UnitedLibraryContext _context;

        public WriterRepository(UnitedLibraryContext context) 
        {
            _context = context;
        }

        public async Task<ICollection<Writer>> GetAllWriters()
        {
            List<Writer> writers = await _context.Writers.ToListAsync();
            return writers;
        }

        public async Task<ICollection<Writer>> GetWritersByBookId(int bookId)
        {
            List<Writer> writers = await _context.Writers
                .Where(w => w.Novels.Any(n => n.Novel.Books.Any(b => b.BookId == bookId)))
                .ToListAsync();
            return writers;
        }
    }
}
