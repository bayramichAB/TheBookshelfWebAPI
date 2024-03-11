using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DataTransferObjects;
using TheBookshelf.Presentation.ActionFilters;
using TheBookshelf.Presentation.ModelBinders;


namespace TheBookshelf.Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriesController(IServiceManager service)=>_service = service;

        
        [HttpGet("{id:guid}",Name ="CategoryById")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _service.CategoryService.GetCategoryAsync(id,trackChanges:false);
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
            return Ok(categories);
        }

        [HttpGet("collection/({ids})", Name ="CategoryCollection")]
        public async Task<IActionResult> GetCategoryCollection([ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var categories = await _service.CategoryService.GetByIdsAsync(ids,trackChanges:false);
            return Ok(categories);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _service.CategoryService.DeleteCategoryAsync(id, trackChanges:false);
            return NoContent();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);

            return CreatedAtRoute("CategoryById", new {id=createdCategory.Id},createdCategory);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCategoryCollection([FromBody] IEnumerable<CategoryForCreationDto> categoryCollection)
        {
            var result = await _service.CategoryService.CreateCategoryCollectionAsync(categoryCollection);
            return CreatedAtRoute("CategoryCollection", new { result.ids }, result.categories);
        }
        
        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.CategoryService.UpdateCategoryAsync(id, category, trackChanges:true);
            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCategoriesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, DELETE");
            return Ok();
        }
    }
}
