using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitedLibraryAPI.Dto;
using UnitedLibraryAPI.Interfaces;

namespace UnitedLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public LibraryController(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibraries()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var libraries = await _libraryRepository.GetAllLibraries();
            return Ok(libraries);
        }

        [HttpGet("{state}/{city}/{bookId}")]
        public async Task<IActionResult> GetLibrariesByLocationAndBookId(string state, string city, int bookId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var libraries = await _libraryRepository.GetLibrariesByLocationAndBookId(state, city, bookId);
            return Ok(libraries);
        }

        [HttpGet("{state}/{city}")]
        public async Task<IActionResult> GetLibrariesByStateAndCity(string state, string city) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var libraries = await _libraryRepository.GetLibrariesByStateAndCity(state, city);
            return Ok(libraries);
        }
    }
}
