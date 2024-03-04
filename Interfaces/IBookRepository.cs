using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBookRepository
    {    
        Task<Book?> GetSingleBookAsync(Guid bookId,bool trackChanges);

        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);

        Task<Book?> GetBookForCategoryAsync(Guid categoryId, Guid bookId, bool trackChanges);

        Task<IEnumerable<Book>> GetBooksForCategoryAsync(Guid categoryId, bool trackChanges);
        
        Task<Book?> GetAuthorBookAsync(Guid authorId, Guid bookId, bool trackChanges);
        
        Task<IEnumerable<Book>> GetAuthorBooksAsync(Guid authorId, bool trackChanges);
        
        Task<Book?> GetBookForCategoryAndAuthorAsync(Guid categoryId, Guid authorId,Guid id, bool trackChanges);

        Task<IEnumerable<Book>> GetBooksForCategoryAndAuthorAsync(Guid categoryId,Guid authorId,bool trackChanges);

        void CreateBook(Guid categoryId,Guid authorId,Book book);
        void DeleteBook(Book book);


        
        
    }
}
