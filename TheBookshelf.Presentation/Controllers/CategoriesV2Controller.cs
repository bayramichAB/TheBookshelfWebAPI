using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookshelf.Presentation.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/categories")]
    [ApiController]
    public class CategoriesV2Controller : ControllerBase
    {
        private readonly IServiceManager _service;

        public CategoriesV2Controller(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories() 
        {
            var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);

            var categoriesV2 = categories.Select(x=>$"{x.Name} V2");

            return Ok(categoriesV2);
        }
    }
}
