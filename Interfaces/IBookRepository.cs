using Entities.Models;
using Shared.RequestFeatures;
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

        Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges);

        Task<Book?> GetBookForCategoryAsync(Guid categoryId, Guid bookId, bool trackChanges);

        Task<PagedList<Book>> GetBooksForCategoryAsync(Guid categoryId,BookParameters bookParameters, bool trackChanges);
        
        Task<Book?> GetAuthorBookAsync(Guid authorId, Guid bookId, bool trackChanges);
        
        Task<PagedList<Book>> GetAuthorBooksAsync(Guid authorId, BookParameters bookParameters, bool trackChanges);
        
        Task<Book?> GetBookForCategoryAndAuthorAsync(Guid categoryId, Guid authorId,Guid id, bool trackChanges);

        Task<PagedList<Book>> GetBooksForCategoryAndAuthorAsync(Guid categoryId,Guid authorId,BookParameters bookParameters,bool trackChanges);

        void CreateBook(Guid categoryId,Guid authorId,Book book);
        void DeleteBook(Book book);


        
        
    }
}
