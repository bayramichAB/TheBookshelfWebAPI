using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository:RepositoryBase<Book>,IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }

        public Book? GetBook(Guid categoryId, Guid Id, bool trackChanges) =>
            FindByCondition(b => b.CategoryID.Equals(categoryId) && b.Id.Equals(Id), trackChanges).SingleOrDefault();

        public IEnumerable<Book> GetBooks(Guid categoryId, bool trackChanges) =>
            FindByCondition(c => c.CategoryID.Equals(categoryId), trackChanges).OrderBy(b=>b.Name).ToList();


    }
}
