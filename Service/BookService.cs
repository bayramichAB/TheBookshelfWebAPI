using AutoMapper;
using Entities.Exceptions;
using Interfaces;
using Service.Interfaces;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class BookService:IBookService
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

        public BookDto GetAuthorBook(Guid authorId, Guid Id, bool trackChanges)
        {
            var author = _repositoryManager.Author.GetAuthor(authorId, trackChanges);
            if (author is null)
            {
                throw new AuthorNotFoundExeption(authorId);
            }

            var book = _repositoryManager.Book.GetAuthorBook(authorId, Id, trackChanges);

            if (book is null)
            {
                throw new BookNotFoundException(Id);
            }

            var bookDto=_mapper.Map<BookDto>(book);
            return bookDto;
        }

        public IEnumerable<BookDto> GetAuthorBooks(Guid authorId, bool trackChanges)
        {
            var author = _repositoryManager.Author.GetAuthor(authorId, trackChanges);
            if (author is null)
            {
                throw new AuthorNotFoundExeption(authorId);
            }

            var books = _repositoryManager.Book.GetAuthorBooks(authorId, trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return booksDto;
        }

        public BookDto GetBook(Guid categoryId, Guid Id, bool trackChanges)
        {
            var category = _repositoryManager.Category.GetCategory(categoryId,trackChanges);

            if (category is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            var book = _repositoryManager.Book.GetBook(categoryId, Id,trackChanges);

            if (book is null)
            {
                throw new BookNotFoundException(Id);
            }
            var booksDto= _mapper.Map<BookDto>(book);
            return booksDto;
        }

        public IEnumerable<BookDto> GetBooks(Guid categoryId, bool trackChanges)
        {
            var category = _repositoryManager.Category.GetCategory(categoryId,trackChanges);
            if (category is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            var books = _repositoryManager.Book.GetBooks(categoryId,trackChanges);
            var booksDto=_mapper.Map<IEnumerable< BookDto>>(books);

            return booksDto;
        }


    }
}
