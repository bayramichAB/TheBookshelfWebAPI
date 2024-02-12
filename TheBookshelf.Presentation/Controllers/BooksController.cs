using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookshelf.Presentation.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BooksController(IServiceManager service)=>_service = service;

        [HttpGet("api/books")]
        public IActionResult GetAllBooks()
        {
            var books = _service.BookService.GetAllBooks(trackChanges:false);
            return Ok(books);
        }

        [HttpGet("api/books/{bookId:guid}")]
        public IActionResult GetBook(Guid bookId)
        {
            var book = _service.BookService.GetSingleBook(bookId,trackChanges:false);
            return Ok(book);
        }


        [HttpGet("api/categories/{categoryId}/books")]
        public IActionResult GetBooksForCategory(Guid categoryId)
        {
            var books = _service.BookService.GetBooks(categoryId,trackChanges:false);
            return Ok(books);
        }

        [HttpGet("api/categories/{categoryId}/books/{id:guid}",Name = "GetBookForCategory")]
        public IActionResult GetBookForCategory(Guid categoryId, Guid Id)
        {
            var book = _service.BookService.GetBook(categoryId, Id, trackChanges:false);
            return Ok(book);
        }


        [HttpGet("api/authors/{authorId}/books")]
        public IActionResult GetBooksForAuthor(Guid authorId)
        {
            var books = _service.BookService.GetAuthorBooks(authorId, trackChanges: false);
            return Ok(books);
        }


        [HttpGet("api/authors/{authorId}/books/{id:guid}")]
        public IActionResult GetBookForAuthor(Guid authorId, Guid Id)
        {
            var book = _service.BookService.GetAuthorBook(authorId,Id, trackChanges: false);
            return Ok(book);
        }


        [HttpGet("api/categories/{categoryId}/authors/{authorId}/books", Name = "GetBookForCategoryAndAuthor")]
        public IActionResult GetBookForCategoryAndAuthor(Guid categoryId, Guid authorId)
        {
            var book = _service.BookService.GetBookForCategoryAndAuthor(categoryId,authorId,trackChanges:false);
            return Ok(book);
        }

        [HttpPost("api/categories/{categoryId}/authors/{authorId}/books")]
        public IActionResult CreateBook(Guid categoryId,Guid authorId, [FromBody]BookForCreationDto book)
        {
            if (book is null)
            {
                return BadRequest("BookForCreationDto is null");
            }
            var bookToReturn = _service.BookService.CreateBook(categoryId,authorId, book, trackChanges: false);

            return CreatedAtRoute("GetBookForCategoryAndAuthor", new { categoryId, id = bookToReturn.Id }, bookToReturn);
        }
    }
}
