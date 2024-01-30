using Interfaces;
using Service.Interfaces;
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

        public BookService(IRepositoryManager repository,ILoggerManager logger)
        {
            _repositoryManager = repository;
            _loggerManager = logger;
        }
    }
}
