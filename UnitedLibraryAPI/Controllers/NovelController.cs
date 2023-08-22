using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitedLibraryAPI.Dto;
using UnitedLibraryAPI.Interfaces;

namespace UnitedLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovelController : Controller
    {
        private readonly INovelRepository _novelRepository;
        private readonly IMapper _mapper;

        public NovelController(INovelRepository novelRepository, IMapper mapper) 
        {
            _novelRepository = novelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async  Task<IActionResult> GetNovels() 
        {
            var novels = await _novelRepository.GetAllNovels();
            return Ok(novels);
        }
    }
}
