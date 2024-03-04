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
        Task<AuthorDto> GetAuthorAsync(Guid Id, bool trackChanges); 

        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(bool trackChanges);

        Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author); 

        Task DeleteAuthorAsync(Guid authorId, bool trackChanges);

        Task UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto authorForUpdateDto,bool trackChanges);
    }
}
