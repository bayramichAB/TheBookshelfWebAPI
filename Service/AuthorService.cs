using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
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
    internal sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AuthorService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        private async Task<Author> GetAuthorAndCheckIfItExists(Guid authorId, bool trackChanges)
        {
            var author = await _repository.Author.GetAuthorAsync(authorId, trackChanges);
            if (author is null)
            {
                throw new AuthorNotFoundExeption(authorId);
            }
            return author;
        }
        public async Task<AuthorDto> GetAuthorAsync(Guid authorId, bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfItExists(authorId, trackChanges);

            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }  

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(bool trackChanges)
        {
            var authors = await _repository.Author.GetAllAuthorsAsync(trackChanges);
            
            var authersDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authersDto;
        }

        public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);

            _repository.Author.CreateAuthor(authorEntity);
            await _repository.SaveAsync();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return authorToReturn;
        }  

        public async Task DeleteAuthorAsync(Guid authorId,bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfItExists(authorId,trackChanges);

            _repository.Author.DeleteAuthor(author);
            await _repository.SaveAsync();
        }

        public async Task UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto authorForUpdate,bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfItExists(authorId, trackChanges);

            _mapper.Map(authorForUpdate,author);
            await _repository.SaveAsync();
        }
    }
}
