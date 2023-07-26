using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetLibraries()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var libraries = _libraryRepository.GetLibraries();
            return Ok(libraries);
        }

        [HttpGet("{libraryCity}")]
        public IActionResult GetLibraries(string libraryCity) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var libraries = _libraryRepository.GetLibraries(libraryCity);
            return Ok(libraries);
        }
    }
}
