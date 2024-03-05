using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetSingleBookAsync(Guid bookId,bool trackChanges);

        Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges);

        Task<BookDto> GetCategoryBookAsync(Guid categoryId, Guid Id, bool trackChanges);

        Task<BookDto> GetAuthorBookAsync(Guid authorId, Guid Id, bool trackChanges);

        Task<(IEnumerable<BookDto> books, MetaData metaData)> GetCategoryBooksAsync(Guid categoryId,BookParameters bookParameters,bool trackChanges);

        Task<IEnumerable<BookDto>> GetAuthorBooksAsync(Guid authorId, bool trackChanges);

        Task<BookDto> GetBookForCategoryAndAuthorAsync(Guid categoryId, Guid authorId,Guid Id, bool trackChanges);

        Task<IEnumerable<BookDto>> GetBooksForCategoryAndAuthorAsync(Guid categoryId,Guid authorId,bool trackChanges);

        Task<BookDto> CreateBookAsync(Guid categoryId,Guid authorId, BookForCreationDto bookForCreation, bool trackChanges);

        Task DeleteBookAsync(Guid categoryId,Guid authorId,Guid id,bool trackChanges);

        Task UpdateBookForCategoryAndAuthorAsync(Guid categoryId, Guid authorId, Guid id,BookForUpdateDto bookForUpdateDto,
            bool catTrackChanges,bool authTrackChanges,bool bookTrackChanges);

        Task<(BookForUpdateDto bookToPatch, Book bookEntity)> GetBookForPatchAsync(Guid categoryId, Guid id,
            bool catTrackChanges, bool bookTrackChanges);

        Task SaveChangesForPatchAsync(BookForUpdateDto bookToPatch, Book bookEntity);
    }
}
