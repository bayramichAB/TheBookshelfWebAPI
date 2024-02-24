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
        IEnumerable<Book> GetBooksForCategory(Guid categoryId, bool trackChanges);
        Book? GetBookForCategory(Guid categoryId, Guid bookId, bool trackChanges);
        Book? GetAuthorBook(Guid authorId, Guid bookId, bool trackChanges);

        IEnumerable<Book> GetBooksForCategoryAndAuthor(Guid categoryId,Guid authorId,bool trackChanges);

        Book? GetBookForCategoryAndAuthor(Guid categoryId, Guid authorId,Guid id, bool trackChanges);

        IEnumerable<Book> GetAuthorBooks(Guid authorId, bool trackChanges);
        void CreateBook(Guid categoryId,Guid authorId,Book book);
        void DeleteBook(Book book);


        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book? GetSingleBook(Guid bookId,bool trackChanges);
    }
}
