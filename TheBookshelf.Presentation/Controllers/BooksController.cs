using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheBookshelf.Presentation.ActionFilters;

namespace TheBookshelf.Presentation.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BooksController(IServiceManager service)=>_service = service;

        [HttpGet("api/books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _service.BookService.GetAllBooksAsync(trackChanges:false);
            return Ok(books);
        }


        [HttpGet("api/books/{bookId:guid}")]
        public async Task<IActionResult> GetBook(Guid bookId)
        {
            var book = await _service.BookService.GetSingleBookAsync(bookId,trackChanges:false);
            return Ok(book);
        }


        [HttpGet("api/categories/{categoryId}/books")]
        public async Task<IActionResult> GetBooksForCategory(Guid categoryId,
            [FromQuery] BookParameters bookParameters)
        {
            var pageResult = await _service.BookService.GetCategoryBooksAsync(categoryId,bookParameters,trackChanges:false);
            
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));

            return Ok(pageResult.books);
        }


        [HttpGet("api/categories/{categoryId}/books/{id:guid}",Name = "GetBookForCategory")]
        public async Task<IActionResult> GetBookForCategory(Guid categoryId, Guid Id)
        {
            var book = await _service.BookService.GetCategoryBookAsync(categoryId, Id, trackChanges:false);
            return Ok(book);
        }


        [HttpGet("api/authors/{authorId}/books")]
        public async Task<IActionResult> GetBooksForAuthor(Guid authorId)
        {
            var books = await _service.BookService.GetAuthorBooksAsync(authorId, trackChanges: false);
            return Ok(books);
        }


        [HttpGet("api/authors/{authorId}/books/{id:guid}")]
        public async Task<IActionResult> GetBookForAuthor(Guid authorId, Guid Id)
        {
            var book = await _service.BookService.GetAuthorBookAsync(authorId,Id, trackChanges: false);
            return Ok(book);
        }


        [HttpGet("api/categories/{categoryId}/authors/{authorId}/books", Name = "GetBooksForCategoryAndAuthor")]
        public async Task<IActionResult> GetBooksForCategoryAndAuthor(Guid categoryId, Guid authorId)
        {
            var book = await _service.BookService.GetBooksForCategoryAndAuthorAsync(categoryId,authorId,trackChanges:false);
            return Ok(book);
        }


        [HttpGet("api/categories/{categoryId}/authors/{authorId}/books/{id:guid}")]
        public async Task<IActionResult> GetBookForCategoryAndAuthor(Guid categoryId, Guid authorId,Guid Id)
        {
            var book = await _service.BookService.GetBookForCategoryAndAuthorAsync(categoryId, authorId, Id, trackChanges: false);
            return Ok(book);
        }


        [HttpPost("api/categories/{categoryId}/authors/{authorId}/books")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateBook(Guid categoryId,Guid authorId, [FromBody]BookForCreationDto book)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var bookToReturn = await _service.BookService.CreateBookAsync(categoryId,authorId, book, trackChanges: false);

            return CreatedAtRoute("GetBooksForCategoryAndAuthor", new { categoryId, authorId, id = bookToReturn.Id }, bookToReturn);
        }


        [HttpDelete("api/categories/{categoryId}/authors/{authorId}/books/{id:guid}")]
        public async Task<IActionResult> DeleteBookForCategoryAndAuthor(Guid categoryId, Guid authorId,Guid id)
        {
            await _service.BookService.DeleteBookAsync(categoryId, authorId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("api/categories/{categoryId}/authors/{authorId}/books/{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBookForCategoryAndAuthor(Guid categoryId,Guid authorId,Guid id,
            [FromBody] BookForUpdateDto book)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.BookService.UpdateBookForCategoryAndAuthorAsync(categoryId,authorId,id,book,
                catTrackChanges:false,authTrackChanges:false,bookTrackChanges:true);
            return NoContent();
        }


        [HttpPatch("api/categories/{categoryId}/books/{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateBookForCategory(Guid categoryId, Guid id, [FromBody] JsonPatchDocument<BookForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null");
            }

            var result = await _service.BookService.GetBookForPatchAsync(categoryId,id,catTrackChanges:false,bookTrackChanges:true);
            patchDoc.ApplyTo(result.bookToPatch,ModelState);

            TryValidateModel(result.bookToPatch);


            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.BookService.SaveChangesForPatchAsync(result.bookToPatch,result.bookEntity);
            return NoContent();
        }
    }
}
