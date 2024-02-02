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
        public IActionResult GetBookForCategory(Guid categoryId)
        {
            var books = _service.BookService.GetBooks(categoryId,trackChanges:false);
            return Ok(books);
        }
    }
}
