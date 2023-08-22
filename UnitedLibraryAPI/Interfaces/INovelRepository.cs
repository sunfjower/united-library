using System.Collections;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface INovelRepository
    {
        Task<ICollection<Novel>> GetAllNovels();
    }
}
