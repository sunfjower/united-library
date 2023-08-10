using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
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
        public async Task<IActionResult> GetAllBooks()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = await _bookRepository.GetAllBooks();
            var mappedBooks = _mapper.Map<List<BookDto>>(books);

            return Ok(mappedBooks);
        }

        [HttpGet("{state}/{city}/{novel}")]
        public async Task<IActionResult> GetBooksByLibraryAndNovel(string state, string city, string novel) 
        {
            var books = await _bookRepository.GetBooksByLibraryAndNovel(state, city, novel);
            var mappedBooks = _mapper.Map<List<BookDto>>(books);

            return Ok(mappedBooks);
        }
    }
}
