using AutoMapper;
using Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<ICategoryService> _categoryService;

        public ServiceManager(IRepositoryManager repositoryManager,ILoggerManager logger,IMapper mapper)
        {
            _authorService = new Lazy<IAuthorService>(()=>new AuthorService(repositoryManager,logger, mapper));
            _bookService=new Lazy<IBookService>(()=>new  BookService(repositoryManager,logger, mapper));
            _categoryService= new Lazy<ICategoryService>(()=>new CategoryService(repositoryManager,logger, mapper));
        }

        public IAuthorService AuthorService => _authorService.Value;
        public IBookService BookService => _bookService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
    }
}
