using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookshelf.Presentation.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        public RootController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name ="Accept")] string mediaType)
        {
            if (mediaType.Contains("application/vnd.codemaze.apiroot"))
            {
                var list = new List<Link>()
                {
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot),new {}),
                        Rel = "self",
                        Method = "GET",
                    },
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, "GetCategories",new {}),
                        Rel = "categories",
                        Method = "GET",
                    },
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, "CreateCategory", new {}),
                        Rel = "create_category",
                        Method = "POST",
                    },
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, "GetAuthors", new{}),
                        Rel = "authors",
                        Method = "GET",
                    },
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext , "CreateAuthor", new{}),
                        Rel = "create_author",
                        Method = "POST",
                    }

                };
                return Ok(list);
            }
            return NoContent();
        }
    }
}
