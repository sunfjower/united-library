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

        public ICollection<Writer> GetWriters()
        {
            List<Writer> writers = _context.Writers.ToList();
            return writers;
        }
    }
}
