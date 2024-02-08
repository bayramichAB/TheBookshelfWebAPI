using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DataTransferObjects;


namespace TheBookshelf.Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriesController(IServiceManager service)=>_service = service;

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _service.CategoryService.GetAllCategories(trackChanges: false);
            return Ok(categories);
        }

        [HttpGet("{id:guid}",Name ="CategoryById")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _service.CategoryService.GetCategory(id,trackChanges:false);
            return Ok(category);
        }


        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryForCreationDto category)
        {
            if (category is null)
            {
                return BadRequest("CategoryForCreationDto object is null");
            }

            var createdCategory = _service.CategoryService.CreateCategory(category);

            return CreatedAtRoute("CategoryById", new {id=createdCategory.Id},createdCategory);
        }
    }
}
