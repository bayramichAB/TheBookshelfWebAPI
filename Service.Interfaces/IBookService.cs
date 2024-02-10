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
        IEnumerable<BookDto> GetBooks(Guid categoryId,bool trackChanges);
        IEnumerable<BookDto> GetAuthorBooks(Guid authorId, bool trackChanges);
        BookDto GetBook(Guid categoryId, Guid Id, bool trackChanges);
        BookDto GetAuthorBook(Guid authorId, Guid Id, bool trackChanges);

        BookDto CreateBook(Guid categoryId, BookForCreationDto bookForCreation, bool trackChanges);


        IEnumerable<BookDto> GetAllBooks(bool trackChanges);
        BookDto GetSingleBook(Guid bookId,bool trackChanges);
    }
}
