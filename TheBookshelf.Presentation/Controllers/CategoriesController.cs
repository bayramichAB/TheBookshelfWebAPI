using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DataTransferObjects;
using TheBookshelf.Presentation.ActionFilters;
using TheBookshelf.Presentation.ModelBinders;


namespace TheBookshelf.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/categories")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    //[ResponseCache(CacheProfileName = "120SecondsDuration")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriesController(IServiceManager service)=>_service = service;

        
        [HttpGet("{id:guid}",Name ="CategoryById")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _service.CategoryService.GetCategoryAsync(id,trackChanges:false);
            return Ok(category);
        }

        /// <summary>
        /// Gets the list of all categories
        /// </summary>
        /// <returns>The categories list</returns>

        [HttpGet(Name = "GetCategories")]
        [Authorize(Roles = "Manager")]
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


        /// <summary>
        /// Creates a newly created category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>A newly created category</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);

            return CreatedAtRoute("CategoryById", new {id=createdCategory.Id},createdCategory);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCategoryCollection([FromBody] IEnumerable<CategoryForCreationDto> categoryCollection)
        {
            var result = await _service.CategoryService.CreateCategoryCollectionAsync(categoryCollection);
            return CreatedAtRoute("CategoryCollection", new { result.ids }, result.categories);
        }

        [Authorize(Roles = "Administrator")]
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
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }
    }
}
