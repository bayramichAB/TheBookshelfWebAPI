using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookshelf.Presentation.Controllers
{
    [Route("api/categories/{categoryId}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BooksController(IServiceManager service)=>_service = service;

        [HttpGet]
        public IActionResult GetBooksForCategory(Guid categoryId)
        {
            var books = _service.BookService.GetBooks(categoryId,trackChanges:false);
            return Ok(books);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBookForCategory(Guid categoryId, Guid Id)
        {
            var book = _service.BookService.GetBook(categoryId, Id, trackChanges:false);
            return Ok(book);
        }
    }
}
