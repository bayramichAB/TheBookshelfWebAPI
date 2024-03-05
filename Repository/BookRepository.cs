using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
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
        
        public async Task<Book?> GetSingleBookAsync(Guid bookId, bool trackChanges) => 
            await FindByCondition(b => b.Id.Equals(bookId), trackChanges).SingleOrDefaultAsync();

        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            var books = await FindAll(trackChanges).OrderBy(b => b.Name).ToListAsync();
            return PagedList<Book>.ToPagedList(books, bookParameters.PageNumber, bookParameters.PageSize);
        }
        public async Task<Book?> GetBookForCategoryAsync(Guid categoryId, Guid Id, bool trackChanges) =>
            await FindByCondition(b => b.CategoryID.Equals(categoryId) && b.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public async Task<PagedList<Book>> GetBooksForCategoryAsync(Guid categoryId, BookParameters bookParameters, bool trackChanges)
        {
            var books = await FindByCondition(c => c.CategoryID.Equals(categoryId), trackChanges).OrderBy(b => b.Name).ToListAsync();

            return PagedList<Book>.ToPagedList(books,bookParameters.PageNumber, bookParameters.PageSize);
        }

        public async Task<Book?> GetAuthorBookAsync(Guid authorId, Guid bookId, bool trackChanges) =>
            await FindByCondition(a => a.AuthorID.Equals(authorId) && a.Id.Equals(bookId), trackChanges).SingleOrDefaultAsync();

        public async Task<PagedList<Book>> GetAuthorBooksAsync(Guid authorId, BookParameters bookParameters, bool trackChanges)
        {
            var books = await FindByCondition(a => a.AuthorID.Equals(authorId), trackChanges).OrderBy(a => a.Name).ToListAsync();
            return PagedList<Book>.ToPagedList(books,bookParameters.PageNumber,bookParameters.PageSize);
        }
        public async Task<Book?> GetBookForCategoryAndAuthorAsync(Guid categoryId, Guid authorId, Guid id, bool trackChanges) =>
            await FindByCondition(b => b.CategoryID.Equals(categoryId) && b.AuthorID.Equals(authorId) && b.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<PagedList<Book>> GetBooksForCategoryAndAuthorAsync(Guid categoryId, Guid authorId, BookParameters bookParameters, bool trackChanges)
        {
            var books = await FindByCondition(b => b.CategoryID.Equals(categoryId) && b.AuthorID.Equals(authorId), trackChanges).ToListAsync();
            return PagedList<Book>.ToPagedList(books, bookParameters.PageNumber, bookParameters.PageSize);
        }
        public void CreateBook(Guid categoryId, Guid authorId, Book book)
        {
            book.CategoryID=categoryId;
            book.AuthorID=authorId;
            Create(book);
        }

        public void DeleteBook(Book book) => Delete(book);
    }
}
