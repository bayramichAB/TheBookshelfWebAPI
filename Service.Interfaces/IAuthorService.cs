using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthorService
    {
        void DeleteAuthor(Guid authorId, bool trackChanges);
        IEnumerable<AuthorDto> GetAllAuthors(bool trackChanges);
        AuthorDto GetAuthor(Guid Id, bool trackChanges);
        AuthorDto CreateAuthor(AuthorForCreationDto author);
    }
}
