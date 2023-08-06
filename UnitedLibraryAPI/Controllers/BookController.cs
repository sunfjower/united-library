using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitedLibraryAPI.Dto;
using UnitedLibraryAPI.Interfaces;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetAllBooks());

            return Ok(books);
        }

        [HttpGet("{state}/{city}/{novel}")]
        public IActionResult GetBooksByLibraryAndNovel(string state, string city, string novel) 
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooksByLibraryAndNovel(state, city, novel));
            
            return Ok(books);
        }
    }
}
