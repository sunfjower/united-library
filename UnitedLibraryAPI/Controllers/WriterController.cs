using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitedLibraryAPI.Interfaces;

namespace UnitedLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : Controller
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;

        public WriterController(IWriterRepository writerRepository, IMapper mapper)
        {
            _writerRepository = writerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWriters()
        {
            var writers = _writerRepository.GetWriters();
            return Ok(writers);
        }
    }
}
