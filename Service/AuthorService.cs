using Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class AuthorService:IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public AuthorService(IRepositoryManager repository,ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
