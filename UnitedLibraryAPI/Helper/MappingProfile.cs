using AutoMapper;
using UnitedLibraryAPI.Dto;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, BookDto>();
        }
    }
}
