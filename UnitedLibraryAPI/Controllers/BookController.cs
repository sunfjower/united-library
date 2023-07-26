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
        public IActionResult GetBooks() 
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());

            return Ok(books);
        }

        [HttpGet("{bookTitle}")]
        public IActionResult GetBooks(string bookTitle) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks(bookTitle));
           
            return Ok(books);
        }
    }
}
