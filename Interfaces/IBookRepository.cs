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
        IEnumerable<Book> GetBooks(Guid categoryId, bool trackChanges);
        Book? GetBook(Guid categoryId, Guid bookId, bool trackChanges);
        Book? GetAuthorBook(Guid authorId, Guid bookId, bool trackChanges);

        IEnumerable<Book> GetAuthorBooks(Guid authorId, bool trackChanges);
        void CreateBook(Guid categoryId,Book book);


        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book? GetSingleBook(Guid bookId,bool trackChanges);
    }
}
