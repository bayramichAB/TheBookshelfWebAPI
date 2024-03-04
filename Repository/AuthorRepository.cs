using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthorRepository:RepositoryBase<Author>,IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }

        public async Task<Author?> GetAuthorAsync(Guid authorId, bool trachChanges) =>
            await FindByCondition(a => a.Id.Equals(authorId), trachChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(a => a.Name).ToListAsync();

        public void CreateAuthor(Author author) => Create(author);

        public void DeleteAuthor(Author author) => Delete(author);
    }
}
