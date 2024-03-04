using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAuthorRepository
    {     
        Task<Author?> GetAuthorAsync(Guid authorId, bool trachChanges);

        Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
        
        void CreateAuthor(Author author);

        void DeleteAuthor(Author author);
    }
}
