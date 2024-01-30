using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager:IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(repositoryContext));
            _bookRepository=new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
            _categoryRepository=new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
        }

        public IAuthorRepository Author=>_authorRepository.Value;
        public IBookRepository Book =>_bookRepository.Value;
        public ICategoryRepository Category =>_categoryRepository.Value;

        public void Save()=>_repositoryContext.SaveChanges();
    }
}
