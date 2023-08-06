using AutoMapper;
using UnitedLibraryAPI.Dto;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Novels, opt => opt.MapFrom(src => src.Novels.Select(src => src.Novel).ToList()));
            CreateMap<Address, AddressDto>();
            CreateMap<Novel, NovelDto>()
                .ForMember(dest => dest.Writers, opt => opt.MapFrom(src => src.Writers.Select(src => src.Writer).ToList()));
        }
    }
}
