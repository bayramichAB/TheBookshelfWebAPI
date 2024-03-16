using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookshelf.Presentation.ActionFilters;

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

        /// <summary>
        /// Gets the list of all authors
        /// </summary>
        /// <returns>The authors list</returns>

        [HttpGet(Name = "GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _serviceManager.AuthorService.GetAllAuthorsAsync(trackChanges:false);
            return Ok(authors);
        }

        /// <summary>
        /// Creates a newly created author
        /// </summary>
        /// <param name="author"></param>
        /// <returns>A newly created author</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>

        [HttpPost(Name = "CreateAuthor")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto author)
        {
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] AuthorForUpdateDto author)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.AuthorService.UpdateAuthorAsync(id, author, trackChanges: true);
            return NoContent();
        }
        
    }
}
