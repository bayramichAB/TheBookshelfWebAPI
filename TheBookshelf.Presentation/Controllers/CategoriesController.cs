using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try 
            {
                var categories = _service.CategoryService.GetAllCategories(trackChanges: false);
                return Ok(categories);
            }
            catch 
            {
                return StatusCode(500,"Internal server error");
            }
        }
    }
}
