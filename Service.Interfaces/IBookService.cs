using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetCategoryBooks(Guid categoryId,bool trackChanges);
        IEnumerable<BookDto> GetAuthorBooks(Guid authorId, bool trackChanges);
        BookDto GetCategoryBook(Guid categoryId, Guid Id, bool trackChanges);
        BookDto GetAuthorBook(Guid authorId, Guid Id, bool trackChanges);

        IEnumerable<BookDto> GetBooksForCategoryAndAuthor(Guid categoryId,Guid authorId,bool trackChanges);

        BookDto GetBookForCategoryAndAuthor(Guid categoryId, Guid authorId,Guid Id, bool trackChanges);

        BookDto CreateBook(Guid categoryId,Guid authorId, BookForCreationDto bookForCreation, bool trackChanges);


        void DeleteBook(Guid categoryId,Guid authorId,Guid id,bool trackChanges);

        IEnumerable<BookDto> GetAllBooks(bool trackChanges);
        BookDto GetSingleBook(Guid bookId,bool trackChanges);
    }
}
