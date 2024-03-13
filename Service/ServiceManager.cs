using AutoMapper;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;
using Shared.DataTransferObjects;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager,ILoggerManager logger,IMapper mapper,
            IBookLinks bookLinks, UserManager<User> userManager, IConfiguration configuration)
        {
            _authorService = new Lazy<IAuthorService>(()=>new AuthorService(repositoryManager,logger, mapper));
            _bookService=new Lazy<IBookService>(()=>new  BookService(repositoryManager,logger, mapper, bookLinks));
            _categoryService= new Lazy<ICategoryService>(()=>new CategoryService(repositoryManager,logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));

        }

        public IAuthorService AuthorService => _authorService.Value;
        public IBookService BookService => _bookService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
