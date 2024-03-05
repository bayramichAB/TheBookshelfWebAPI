using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class BookService:IBookService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public BookService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
        {
            _repositoryManager = repository;
            _loggerManager = logger;
            _mapper = mapper;
        }

        private async Task<Category> GetCategoryAndCheckIfItExists(Guid categoryId, bool trackChanges)
        {
            var category = await _repositoryManager.Category.GetCategoryAsync(categoryId, trackChanges);

            if (category is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }
            return category;
        }

        private async Task<Author> GetAuthorAndCheckIfItExists(Guid authorId, bool trackChanges)
        {
            var author = await _repositoryManager.Author.GetAuthorAsync(authorId, trackChanges);
            if (author is null)
            {
                throw new AuthorNotFoundExeption(authorId);
            }
            return author;
        }



        public async Task <BookDto> GetSingleBookAsync(Guid bookId, bool trackChanges)
        {
            var book = await _repositoryManager.Book.GetSingleBookAsync(bookId,trackChanges);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges)
        {
            var booksWithMetaData = await _repositoryManager.Book.GetAllBooksAsync(bookParameters,trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            return (books:booksDto, metaData: booksWithMetaData.MetaData);
        } 

        public async Task<BookDto> GetCategoryBookAsync(Guid categoryId, Guid Id, bool trackChanges)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            var book = await _repositoryManager.Book.GetBookForCategoryAsync(categoryId, Id,trackChanges);

            if (book is null)
            {
                throw new BookNotFoundException(Id);
            }
            var booksDto= _mapper.Map<BookDto>(book);
            return booksDto;
        }
        
        public async Task<BookDto> GetAuthorBookAsync(Guid authorId, Guid Id, bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfItExists(authorId, trackChanges);

            var book = await _repositoryManager.Book.GetAuthorBookAsync(authorId, Id, trackChanges);

            if (book is null)
            {
                throw new BookNotFoundException(Id);
            }

            var bookDto=_mapper.Map<BookDto>(book);
            return bookDto;
        }
        
        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetCategoryBooksAsync(Guid categoryId,BookParameters bookParameters, bool trackChanges)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId,trackChanges);

            var booksWithMetaData = await _repositoryManager.Book.GetBooksForCategoryAsync(categoryId,bookParameters,trackChanges);
            var booksDto = _mapper.Map<IEnumerable< BookDto>>(booksWithMetaData);

            return (books: booksDto, metaData: booksWithMetaData.MetaData);
        }

        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetAuthorBooksAsync(Guid authorId,BookParameters bookParameters, bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfItExists(authorId, trackChanges);

            var booksWithMetaData = await _repositoryManager.Book.GetAuthorBooksAsync(authorId,bookParameters, trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            return (books: booksDto, metaData: booksWithMetaData.MetaData);
        }  
        
        public async Task<BookDto> GetBookForCategoryAndAuthorAsync(Guid categoryId, Guid authorId,Guid id, bool trackChanges)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            var author = await GetAuthorAndCheckIfItExists(authorId, trackChanges);

            var book = await _repositoryManager.Book.GetBookForCategoryAndAuthorAsync(categoryId, authorId,id, trackChanges);
            if (book is null)
            {
                throw new BookNotFoundException(id);
            }
            
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetBooksForCategoryAndAuthorAsync(Guid categoryId, Guid authorId, BookParameters bookParameters, bool trackChanges)
        {
             await GetCategoryAndCheckIfItExists(categoryId,trackChanges);

             await GetAuthorAndCheckIfItExists(authorId, trackChanges);

            var booksWithMetaData = await _repositoryManager.Book.GetBooksForCategoryAndAuthorAsync(categoryId, authorId,bookParameters, trackChanges);

            var bookDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            return (books: bookDto, metaData: booksWithMetaData.MetaData);
        }

        public async Task<BookDto> CreateBookAsync(Guid categoryId,Guid authorId, BookForCreationDto bookForCreation, bool trackChanges)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            var author = await GetAuthorAndCheckIfItExists(authorId, trackChanges);

            var bookEntity = _mapper.Map<Book>(bookForCreation);

            _repositoryManager.Book.CreateBook(categoryId,authorId,bookEntity);
            await _repositoryManager.SaveAsync();

            var bookToReturn = _mapper.Map<BookDto>(bookEntity);
            return bookToReturn;
        }

        public async Task DeleteBookAsync(Guid categoryId,Guid authorId, Guid id, bool trackChanges)
        {
            var category = GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            var author = GetAuthorAndCheckIfItExists(authorId, trackChanges);

            var bookForCategoryAndAuthor = await _repositoryManager.Book.GetBookForCategoryAndAuthorAsync(categoryId, authorId, id, trackChanges);
            if (bookForCategoryAndAuthor is null)
            {
                throw new BookNotFoundException(id);
            }

            _repositoryManager.Book.DeleteBook(bookForCategoryAndAuthor);
            await _repositoryManager.SaveAsync();
        }  

        public async Task UpdateBookForCategoryAndAuthorAsync(Guid categoryId, Guid authorId, Guid id, 
            BookForUpdateDto bookForUpdateDto, bool catTrackChanges, bool authTrackChanges, bool bookTrackChanges)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId, catTrackChanges);

            var author = await GetAuthorAndCheckIfItExists(authorId, authTrackChanges);

            var bookEntity = await _repositoryManager.Book.GetBookForCategoryAndAuthorAsync(categoryId,authorId,id,bookTrackChanges);
            if (bookEntity is null)
            {
                throw new BookNotFoundException(id);
            }

            _mapper.Map(bookForUpdateDto, bookEntity);
            await _repositoryManager.SaveAsync();
        }


        public async Task<(BookForUpdateDto bookToPatch, Book bookEntity)> GetBookForPatchAsync(Guid categoryId, Guid id, bool catTrackChanges, bool bookTrackChanges)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId,catTrackChanges);

            var bookEntity = await _repositoryManager.Book.GetBookForCategoryAsync(categoryId,id,bookTrackChanges);

            if (bookEntity is null)
            {
                throw new BookNotFoundException(categoryId);
            }

            var bookToPatch = _mapper.Map<BookForUpdateDto>(bookEntity);

            return (bookToPatch,bookEntity);
        }

        public async Task SaveChangesForPatchAsync(BookForUpdateDto bookToPatch, Book bookEntity)
        {
            _mapper.Map(bookToPatch, bookEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
