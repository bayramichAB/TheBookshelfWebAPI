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
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AuthorsController(IServiceManager serviceManager)=>_serviceManager = serviceManager;
        

        [HttpGet("{id:guid}", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthor(Guid Id)
        {
            var author = await _serviceManager.AuthorService.GetAuthorAsync(Id,trackChanges:false);
            return Ok(author);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _serviceManager.AuthorService.GetAllAuthorsAsync(trackChanges:false);
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author is null)
            {
                return BadRequest("AuthorForCreationDto object is null");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdAuthor = await _serviceManager.AuthorService.CreateAuthorAsync(author);
            return CreatedAtRoute("AuthorById",new {id=createdAuthor.Id},createdAuthor);
        }

        [HttpDelete("{id:guid}")]
        public async Task <IActionResult> DeleteAuthor(Guid id)
        {
            await _serviceManager.AuthorService.DeleteAuthorAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] AuthorForUpdateDto author)
        {
            if (author is null)
            {
                return BadRequest("AuthorForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.AuthorService.UpdateAuthorAsync(id, author, trackChanges: true);
            return NoContent();
        }
        
    }
}
