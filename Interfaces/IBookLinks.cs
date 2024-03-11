using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBookLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<BookDto> booksDto, string? fields, Guid categoryId, HttpContext httpContext);
        LinkResponse TryGenerateLinks(IEnumerable<BookDto> booksDto, string? fields, Guid categoryId,Guid authorId, HttpContext httpContext);
    }
}
