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

        public void CreateBook(Guid categoryId, Guid authorId, Book book)
        {
            book.CategoryID=categoryId;
            book.AuthorID=authorId;
            Create(book);
        }

        public void DeleteBook(Book book) => Delete(book);

        public IEnumerable<Book> GetAllBooks(bool trackChanges) => FindAll(trackChanges).OrderBy(b=>b.Name).ToList();

        public Book? GetAuthorBook(Guid authorId, Guid bookId, bool trackChanges) =>
            FindByCondition(a => a.AuthorID.Equals(authorId) && a.Id.Equals(bookId), trackChanges).SingleOrDefault();

        public IEnumerable<Book> GetAuthorBooks(Guid authorId, bool trackChanges) =>
            FindByCondition(a => a.AuthorID.Equals(authorId), trackChanges).OrderBy(a => a.Name).ToList();

        public Book? GetBookForCategory(Guid categoryId, Guid Id, bool trackChanges) =>
            FindByCondition(b => b.CategoryID.Equals(categoryId) && b.Id.Equals(Id), trackChanges).SingleOrDefault();

        public Book? GetSingleBook(Guid bookId, bool trackChanges) => FindByCondition(b => b.Id.Equals(bookId), trackChanges).SingleOrDefault();

        public IEnumerable<Book> GetBooksForCategory(Guid categoryId, bool trackChanges) =>
            FindByCondition(c => c.CategoryID.Equals(categoryId), trackChanges).OrderBy(b=>b.Name).ToList();


        public IEnumerable<Book> GetBooksForCategoryAndAuthor(Guid categoryId, Guid authorId, bool trackChanges) =>
            FindByCondition(b => b.CategoryID.Equals(categoryId) && b.AuthorID.Equals(authorId), trackChanges).ToList();

        public Book? GetBookForCategoryAndAuthor(Guid categoryId, Guid authorId, Guid id, bool trackChanges) =>
            FindByCondition(b => b.CategoryID.Equals(categoryId) && b.AuthorID.Equals(authorId) && b.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
