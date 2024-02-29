using Microsoft.AspNetCore.JsonPatch;
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
            var books = _service.BookService.GetCategoryBooks(categoryId,trackChanges:false);
            return Ok(books);
        }


        [HttpGet("api/categories/{categoryId}/books/{id:guid}",Name = "GetBookForCategory")]
        public IActionResult GetBookForCategory(Guid categoryId, Guid Id)
        {
            var book = _service.BookService.GetCategoryBook(categoryId, Id, trackChanges:false);
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


        [HttpGet("api/categories/{categoryId}/authors/{authorId}/books", Name = "GetBooksForCategoryAndAuthor")]
        public IActionResult GetBooksForCategoryAndAuthor(Guid categoryId, Guid authorId)
        {
            var book = _service.BookService.GetBooksForCategoryAndAuthor(categoryId,authorId,trackChanges:false);
            return Ok(book);
        }


        [HttpGet("api/categories/{categoryId}/authors/{authorId}/books/{id:guid}")]
        public IActionResult GetBookForCategoryAndAuthor(Guid categoryId, Guid authorId,Guid Id)
        {
            var book = _service.BookService.GetBookForCategoryAndAuthor(categoryId, authorId, Id, trackChanges: false);
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

            return CreatedAtRoute("GetBooksForCategoryAndAuthor", new { categoryId, authorId, id = bookToReturn.Id }, bookToReturn);
        }


        [HttpDelete("api/categories/{categoryId}/authors/{authorId}/books/{id:guid}")]
        public IActionResult DeleteBookForCategoryAndAuthor(Guid categoryId, Guid authorId,Guid id)
        {
            _service.BookService.DeleteBook(categoryId, authorId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("api/categories/{categoryId}/authors/{authorId}/books/{id:guid}")]
        public IActionResult UpdateBookForCategoryAndAuthor(Guid categoryId,Guid authorId,Guid id,
            [FromBody] BookForUpdateDto book)
        {
            if (book is null)
            {
                return BadRequest("BookForUpdateDto object is null");
            }

            _service.BookService.UpdateBookForCategoryAndAuthor(categoryId,authorId,id,book,
                catTrackChanges:false,authTrackChanges:false,bookTrackChanges:true);
            return NoContent();
        }


        
        [HttpPatch("api/categories/{categoryId}/books/{id:guid}")]
        public IActionResult PartiallyUpdateBookForCategory(Guid categoryId, Guid id, [FromBody] JsonPatchDocument<BookForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null");
            }

            var result = _service.BookService.GetBookForPatch(categoryId,id,catTrackChanges:false,bookTrackChanges:true);
            patchDoc.ApplyTo(result.bookToPatch);

            _service.BookService.SaveChangesForPatch(result.bookToPatch,result.bookEntity);
            return NoContent();
        }
    }
}
