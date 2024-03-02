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
        public IActionResult GetAuthor(Guid Id)
        {
            var author = _serviceManager.AuthorService.GetAuthor(Id,trackChanges:false);
            return Ok(author);
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _serviceManager.AuthorService.GetAllAuthors(trackChanges:false);
            return Ok(authors);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author is null)
            {
                return BadRequest("AuthorForCreationDto object is null");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdAuthor = _serviceManager.AuthorService.CreateAuthor(author);
            return CreatedAtRoute("AuthorById",new {id=createdAuthor.Id},createdAuthor);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            _serviceManager.AuthorService.DeleteAuthor(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateAuthor(Guid id, [FromBody] AuthorForUpdateDto author)
        {
            if (author is null)
            {
                return BadRequest("AuthorForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _serviceManager.AuthorService.UpdateAuthor(id, author, trackChanges: true);
            return NoContent();
        }
        
    }
}
