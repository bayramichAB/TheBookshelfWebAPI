using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookshelf.Presentation.Controllers
{
    //[Route("")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BooksController(IServiceManager service)=>_service = service;

        [HttpGet("api/categories/{categoryId}/books")]
        public IActionResult GetBooksForCategory(Guid categoryId)
        {
            var books = _service.BookService.GetBooks(categoryId,trackChanges:false);
            return Ok(books);
        }

        [HttpGet("api/categories/{categoryId}/books/{id:guid}")]
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
    }
}
