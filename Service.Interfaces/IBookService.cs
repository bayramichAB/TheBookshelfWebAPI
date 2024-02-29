using Entities.Models;
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
        BookDto GetSingleBook(Guid bookId,bool trackChanges);

        IEnumerable<BookDto> GetAllBooks(bool trackChanges);

        BookDto GetCategoryBook(Guid categoryId, Guid Id, bool trackChanges);

        BookDto GetAuthorBook(Guid authorId, Guid Id, bool trackChanges);

        IEnumerable<BookDto> GetCategoryBooks(Guid categoryId,bool trackChanges);

        IEnumerable<BookDto> GetAuthorBooks(Guid authorId, bool trackChanges);

        BookDto GetBookForCategoryAndAuthor(Guid categoryId, Guid authorId,Guid Id, bool trackChanges);

        IEnumerable<BookDto> GetBooksForCategoryAndAuthor(Guid categoryId,Guid authorId,bool trackChanges);

        BookDto CreateBook(Guid categoryId,Guid authorId, BookForCreationDto bookForCreation, bool trackChanges);

        void DeleteBook(Guid categoryId,Guid authorId,Guid id,bool trackChanges);

        void UpdateBookForCategoryAndAuthor(Guid categoryId, Guid authorId, Guid id,BookForUpdateDto bookForUpdateDto,
            bool catTrackChanges,bool authTrackChanges,bool bookTrackChanges);

        (BookForUpdateDto bookToPatch, Book bookEntity) GetBookForPatch(Guid categoryId, Guid id,
            bool catTrackChanges, bool bookTrackChanges);

        void SaveChangesForPatch(BookForUpdateDto bookToPatch, Book bookEntity);
    }
}
