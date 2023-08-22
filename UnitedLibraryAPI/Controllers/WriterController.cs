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
        public async Task<IActionResult> GetAllWriters()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var writers = await _writerRepository.GetAllWriters();
            return Ok(writers);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetWritersByBookId(int bookId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var writers = await _writerRepository.GetWritersByBookId(bookId);
            return Ok(writers);
        }
    }
}
