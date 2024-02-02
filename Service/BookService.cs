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
